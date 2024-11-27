Imports MySql.Data.MySqlClient

Public Class Eligibility_Checker_new

    Public frmHelper As New FormHelper
    Public Property DonorID As Integer
    Public Property EligibilityID As Integer
    Public Property DonorName As String
    Public Property BloodType As String
    Public Property HemoglobinLevel As String
    Public Property BloodPressure As String
    Public Property DonorAge As Integer


    Private Sub Eligibility_Checker_new_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Display DonorID and BloodType on load
        MessageBox.Show($"Donor ID: {DonorID}, Blood Type: {BloodType}")
    End Sub

    ' Proceed button event handler
    Private Sub Proceed_Click(sender As Object, e As EventArgs) Handles Proceed.Click
        If Not ValidateDonorID() Then
            MessageBox.Show("Error: DonorID is not set. Please ensure donor information is correctly retrieved.")
            Return
        End If

        If SaveEligibilityData() Then
            If IsEligibleForDonation() Then
                ' Proceed to Donation_Management_new form
                Dim donationForm As New Donation_Management_new() With {
                    .DonorID = Me.DonorID,
                    .DonorName = Me.DonorName,
                    .BloodType = Me.BloodType,
                    .HemoglobinLevel = Me.HemoglobinLevel,
                    .BloodPressure = Me.BloodPressure
                }
                donationForm.Show()
                Me.Hide()
            Else
                MessageBox.Show("Donor is not eligible for blood donation.")
                Admin_Dashboard.Show()
                Me.Hide()
            End If
        End If
    End Sub

    ' Validate DonorID
    Private Function ValidateDonorID() As Boolean
        Return DonorID > 0
    End Function

    ' Save eligibility data to the database
    Private Function SaveEligibilityData() As Boolean
        Dim connectionString As String = "Server=localhost;Database=redcrossdb;Uid=root;Pwd=;"
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                ' Fetch donor full name and birthdate (we need birthdate for age calculation)
                DonorName = GetDonorFullName(connection)
                Dim birthdate As DateTime = GetDonorBirthdate(connection)  ' Assuming GetDonorBirthdate function is added

                ' Insert eligibility data and flag permanent ineligibility if needed
                If InsertEligibilityData(connection) Then
                    ' Calculate and update donor age
                    Dim age As Integer = CalculateAge(birthdate)
                    If UpdateDonorAge(connection, age) Then
                        MessageBox.Show("Data saved successfully!")
                    Else
                        MessageBox.Show("Error updating age.")
                    End If

                    Return True
                Else
                    MessageBox.Show("Error saving data.")
                    Return False
                End If
            Catch ex As MySqlException
                MessageBox.Show($"An error occurred: {ex.Message}")
                Return False
            End Try
        End Using
    End Function

    Private Function GetDonorBirthdate(connection As MySqlConnection) As DateTime
        ' Ensure the query is correctly referencing the Birthdate column
        Dim query As String = "SELECT DateofBirth FROM donors WHERE DonorID = @DonorID"
        Using cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@DonorID", DonorID)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    ' Make sure the Birthdate column exists in the result set and is properly cast to DateTime
                    Return Convert.ToDateTime(reader("DateofBirth"))
                End If
            End Using
        End Using
        ' Return an empty date if not found
        Return DateTime.MinValue
    End Function



    ' Retrieve donor's full name
    Private Function GetDonorFullName(connection As MySqlConnection) As String
        Dim query As String = "SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS FullName FROM donors WHERE DonorID = @DonorID"
        Using cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@DonorID", DonorID)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    Return reader("FullName").ToString()
                End If
            End Using
        End Using
        Return String.Empty
    End Function

    ' Insert eligibility data into the database and flag as permanently ineligible if necessary
    Private Function InsertEligibilityData(connection As MySqlConnection) As Boolean
        Dim query As String = "INSERT INTO eligibility (DonorID, Weight, BloodPressure, Hemoglobin, ConditionCheck, ConditionType, Substance, SubstanceDate, TattooPiercing, TattooPiercingDate, Medication, MedicationDate, EligibilityStatus, EligibilityDate) " &
                          "VALUES (@DonorID, @Weight, @BloodPressure, @Hemoglobin, @ConditionCheck, @ConditionType, @Substance, @SubstanceDate, @TattooPiercing, @TattooPiercingDate, @Medication, @MedicationDate, @EligibilityStatus, @EligibilityDate)"

        Using cmd As New MySqlCommand(query, connection)
            ' Add parameters
            AddEligibilityParameters(cmd)

            ' Flag permanent ineligibility if needed
            If GetConditionCheck() = 1 AndAlso Not String.IsNullOrEmpty(conditiontypetextbox.Text) Then
                FlagPermanentIneligibility(connection)
                MessageBox.Show("Donor flagged as permanently ineligible due to specific conditions.")
            End If

            cmd.ExecuteNonQuery()
        End Using

        ' Calculate and update donor age
        Dim birthdate As DateTime = GetDonorBirthdate(connection)  ' You may need to handle if the birthdate is not found
        Dim age As Integer = CalculateAge(birthdate)
        Return UpdateDonorAge(connection, age)
    End Function

    ' Calculate age based on birthdate
    Private Function CalculateAge(birthdate As DateTime) As Integer
        Dim today As DateTime = DateTime.Today
        Dim age As Integer = today.Year - birthdate.Year

        ' Adjust age if the birthday hasn't occurred yet this year
        If today.Month < birthdate.Month OrElse (today.Month = birthdate.Month AndAlso today.Day < birthdate.Day) Then
            age -= 1
        End If

        Return age
    End Function

    ' Add parameters to eligibility insert query
    Private Sub AddEligibilityParameters(cmd As MySqlCommand)
        cmd.Parameters.AddWithValue("@DonorID", DonorID)
        cmd.Parameters.AddWithValue("@Weight", ParseIntegerField(weighttextbox.Text, "weight"))
        cmd.Parameters.AddWithValue("@BloodPressure", GetBloodPressure())
        cmd.Parameters.AddWithValue("@Hemoglobin", hemoglobinleveltextbox.Text)
        cmd.Parameters.AddWithValue("@ConditionCheck", GetConditionCheck())
        cmd.Parameters.AddWithValue("@ConditionType", conditiontypetextbox.Text)
        cmd.Parameters.AddWithValue("@Substance", GetSubstanceUse())

        ' Set SubstanceDate to NULL if SubstanceCheck is "No"
        If GetSubstanceUse() = 0 Then
            cmd.Parameters.AddWithValue("@SubstanceDate", DBNull.Value)
        Else
            cmd.Parameters.AddWithValue("@SubstanceDate", substanceDatePicker.Value.ToString("yyyy-MM-dd"))
        End If

        cmd.Parameters.AddWithValue("@TattooPiercing", GetTattooPiercing())

        ' Set TattooPiercingDate to NULL if TattooPiercingCheck is "No"
        If GetTattooPiercing() = 0 Then
            cmd.Parameters.AddWithValue("@TattooPiercingDate", DBNull.Value)
        Else
            cmd.Parameters.AddWithValue("@TattooPiercingDate", tattooDatePicker.Value.ToString("yyyy-MM-dd"))
        End If

        cmd.Parameters.AddWithValue("@Medication", GetMedicationUse())

        ' Set MedicationDate to NULL if MedicationCheck is "No"
        If GetMedicationUse() = 0 Then
            cmd.Parameters.AddWithValue("@MedicationDate", DBNull.Value)
        Else
            cmd.Parameters.AddWithValue("@MedicationDate", medicationDatePicker.Value.ToString("yyyy-MM-dd"))
        End If

        cmd.Parameters.AddWithValue("@EligibilityStatus", CalculateEligibilityStatus())
        cmd.Parameters.AddWithValue("@EligibilityDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
    End Sub

    ' Flag donor as permanently ineligible
    Private Sub FlagPermanentIneligibility(connection As MySqlConnection)
        Dim query As String = "UPDATE donors SET EligibilityStatus = 'Ineligible' WHERE DonorID = @DonorID"
        Using cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@DonorID", DonorID)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    ' Update donor age in the database
    Private Function UpdateDonorAge(connection As MySqlConnection, age As Integer) As Boolean
        Dim query As String = "UPDATE donors SET Age = @Age WHERE DonorID = @DonorID"
        Using cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@Age", age)
            cmd.Parameters.AddWithValue("@DonorID", DonorID)
            Return cmd.ExecuteNonQuery() > 0
        End Using
    End Function


    ' Parse integer fields with error handling
    Private Function ParseIntegerField(text As String, fieldName As String) As Integer
        Dim value As Integer
        If Not Integer.TryParse(text, value) Then
            MessageBox.Show($"Please enter a valid {fieldName}.")
            Throw New InvalidOperationException($"Invalid input for {fieldName}")
        End If
        Return value
    End Function

    ' Get formatted blood pressure value
    Private Function GetBloodPressure() As String
        If String.IsNullOrEmpty(bloodpressuretextbox1.Text) OrElse String.IsNullOrEmpty(bloodpressuretextbox2.Text) Then
            MessageBox.Show("Please provide valid blood pressure readings.")
            Throw New InvalidOperationException("Invalid blood pressure input.")
        End If
        Return $"{bloodpressuretextbox1.Text}/{bloodpressuretextbox2.Text}"
    End Function

    ' Calculate eligibility status based on donor's information
    Private Function CalculateEligibilityStatus() As Boolean
        Return IsEligibleForDonation()
    End Function

    ' Check if donor meets eligibility criteria
    Private Function IsSubstanceEligible() As Boolean
        If GetSubstanceUse() = 1 Then
            ' Assuming substanceDatePicker is a DateTimePicker control
            Dim substanceDate As DateTime = substanceDatePicker.Value
            Dim hoursSinceUse As Double = (DateTime.Now - substanceDate).TotalHours
            ' Example rule: Donor is ineligible if substance use was within the last 12 hours
            If hoursSinceUse < 12 Then
                MessageBox.Show("Donor is not eligible due to recent substance use (within the last 12 hours).")
                Return False
            End If
        End If
        Return True
    End Function

    ' Check if the donor is eligible based on medication use rules
    Private Function IsMedicationEligible() As Boolean
        If GetMedicationUse() = 1 Then
            ' Assuming medicationDatePicker is a DateTimePicker control
            Dim medicationDate As DateTime = medicationDatePicker.Value
            Dim daysSinceUse As Integer = (DateTime.Now - medicationDate).Days
            ' Example rule: Donor is ineligible if medication use was within the last 7 days
            If daysSinceUse < 7 Then
                MessageBox.Show("Donor is not eligible due to recent medication use (within the last 7 days).")
                Return False
            End If
        End If
        Return True
    End Function

    ' Check if the donor is eligible based on tattoo/piercing date rules
    Private Function IsTattooEligible() As Boolean
        If GetTattooPiercing() = 1 Then
            ' Assuming tattooDatePicker is a DateTimePicker control
            Dim tattooDate As DateTime = tattooDatePicker.Value
            Dim monthsSinceTattoo As Integer = (DateTime.Now.Year - tattooDate.Year) * 12 + DateTime.Now.Month - tattooDate.Month
            ' Example rule: Donor is ineligible if tattoo or piercing was done within the last 12 months
            If monthsSinceTattoo < 12 Then
                MessageBox.Show("Donor is not eligible due to recent tattoo or piercing (within the last 12 months).")
                Return False
            End If
        End If
        Return True
    End Function

    ' Check if donor meets eligibility criteria
    Private Function IsEligibleForDonation() As Boolean
        ' Validate age (check if it is between 16 and 65)
        If DonorAge < 16 OrElse DonorAge > 65 Then
            MessageBox.Show("Age must be between 16 and 65.")
            Return False
        End If

        ' Continue with other checks (weight, hemoglobin level, blood pressure, etc.)
        If ParseIntegerField(weighttextbox.Text, "weight") < 50 Then Return False
        If ParseIntegerField(hemoglobinleveltextbox.Text, "hemoglobin") < 12 Then Return False
        If ParseIntegerField(bloodpressuretextbox1.Text, "systolic") < 90 OrElse ParseIntegerField(bloodpressuretextbox1.Text, "systolic") > 120 Then Return False
        If ParseIntegerField(bloodpressuretextbox2.Text, "diastolic") < 60 OrElse ParseIntegerField(bloodpressuretextbox2.Text, "diastolic") > 80 Then Return False

        ' Check conditions from CheckedListBox inputs, based on dates
        If Not IsSubstanceEligible() Then Return False
        If Not IsMedicationEligible() Then Return False
        If Not IsTattooEligible() Then Return False

        Return True
    End Function

    ' Get condition check, substance use, tattoo/piercing, and medication use values
    Private Function GetConditionCheck() As Integer
        Return GetYesNoValueFromCheckedListBox(conditionCheckCheckedListBox)
    End Function

    Private Function GetSubstanceUse() As Integer
        Return GetYesNoValueFromCheckedListBox(substanceCheckedListBox)
    End Function

    Private Function GetTattooPiercing() As Integer
        Return GetYesNoValueFromCheckedListBox(tattoopiercingCheckedListBox)
    End Function

    Private Function GetMedicationUse() As Integer
        Return GetYesNoValueFromCheckedListBox(medicationCheckedListBox)
    End Function

    ' Get Yes/No value from checked list box (1 for Yes, 0 for No)
    Private Function GetYesNoValueFromCheckedListBox(clb As CheckedListBox) As Integer
        Return If(clb.CheckedItems.Contains("Yes"), 1, 0)
    End Function

End Class
