Imports MySql.Data.MySqlClient

Public Class Donation_Management_old
    ' Properties to hold values from the previous forms
    Public Property DonorID As Integer
    Public Property DonorName As String
    Public Property BloodType As String
    Public Property HemoglobinLevel As String
    Public Property BloodPressure As String

    ' Event handler for form load
    Private Sub Donation_Management_old_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Check if BloodType has a valid length and remove the symbol
        If Not String.IsNullOrEmpty(BloodType) AndAlso BloodType.Length > 1 Then
            ' Extract the blood group without the last character (assumed to be + or -)
            txtBloodType.Text = BloodType.Substring(0, BloodType.Length - 1)
            txtRhesusFactor.Text = If(BloodType.Last() = "+", "Rh+", "Rh-")
        Else
            ' Handle cases where BloodType may not have the expected format
            txtBloodType.Text = BloodType
            txtRhesusFactor.Text = "Unknown"
        End If
    End Sub

    ' Event handler for the 'Proceed' button click
    Private Sub Proceed_Click(sender As Object, e As EventArgs) Handles Proceed.Click
        ' Check required fields
        If Not IsBloodVolumeValid() Then
            MessageBox.Show("Please enter a valid blood volume.")
            Return
        End If

        If String.IsNullOrEmpty(CollectionCheckedList.Text) OrElse String.IsNullOrEmpty(DonationTypeCheckedlist.Text) Then
            MessageBox.Show("Collection Method and Donation Type cannot be empty.")
            Return
        End If

        ' Check if donation data exists
        If DonationExists() Then
            UpdateDonationData()
        Else
            InsertDonationData()
        End If

        ' Hide current form and show the success message
        Me.Hide()
        Process_Success.Show()
    End Sub

    ' Method to validate blood volume
    Private Function IsBloodVolumeValid() As Boolean
        Return Not String.IsNullOrEmpty(txtBloodVolume.Text) AndAlso IsNumeric(txtBloodVolume.Text)
    End Function

    ' Method to check if donation data already exists
    Private Function DonationExists() As Boolean
        Dim connection As MySqlConnection = modDB.conn
        Dim query As String = "SELECT COUNT(*) FROM donation WHERE DonorID = @DonorID"
        Using cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@DonorID", DonorID)
            Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
        End Using
    End Function

    ' Method to insert donation data into the database
    Private Sub InsertDonationData()
        Dim connection As MySqlConnection = modDB.conn
        If connection IsNot Nothing AndAlso connection.State = ConnectionState.Open Then
            Try
                Dim query As String = "INSERT INTO donation (DonationDate, DonorID, Blood_Group, RhesusFactor, BloodVolume, CollectionMethod, DonationTime, DonationType, NextEligibilityDate, BloodComponent, Compatibility, BagType, Expiration_Date, StorageLocation) " &
                                      "VALUES (@DonationDate, @DonorID, @Blood_Group, @RhesusFactor, @BloodVolume, @CollectionMethod, @DonationTime, @DonationType, @NextEligibilityDate, @BloodComponent, @Compatibility, @BagType, @Expiration_Date, @StorageLocation)"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@DonationDate", DateTime.Now.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@DonorID", DonorID)
                    cmd.Parameters.AddWithValue("@Blood_Group", txtBloodType.Text)
                    cmd.Parameters.AddWithValue("@RhesusFactor", txtRhesusFactor.Text)
                    cmd.Parameters.AddWithValue("@BloodVolume", txtBloodVolume.Text)
                    cmd.Parameters.AddWithValue("@CollectionMethod", CollectionCheckedList.Text)
                    cmd.Parameters.AddWithValue("@DonationTime", DateTime.Now.ToString("HH:mm:ss"))
                    cmd.Parameters.AddWithValue("@DonationType", DonationTypeCheckedlist.Text)
                    cmd.Parameters.AddWithValue("@NextEligibilityDate", CalculateNextEligibilityDate())
                    cmd.Parameters.AddWithValue("@BagType", BagTypeCheckedlist.Text)
                    cmd.Parameters.AddWithValue("@BloodComponent", CheckBloodComponent())
                    cmd.Parameters.AddWithValue("@Compatibility", CheckCompatibility(BloodType))
                    cmd.Parameters.AddWithValue("@Expiration_Date", CalculateExpirationDate())
                    cmd.Parameters.AddWithValue("@StorageLocation", CheckStorageLocation())

                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Donation data successfully added.")
                End Using
            Catch ex As MySqlException
                MessageBox.Show("Database error: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Database connection is not open.")
        End If
    End Sub

    ' Method to update donation data in the database
    Private Sub UpdateDonationData()
        Dim connection As MySqlConnection = modDB.conn
        If connection IsNot Nothing AndAlso connection.State = ConnectionState.Open Then
            Try
                Dim query As String = "UPDATE donation SET " &
                                  "Blood_Group = @Blood_Group, " &
                                  "RhesusFactor = @RhesusFactor, " &
                                  "BloodVolume = @BloodVolume, " &
                                  "CollectionMethod = @CollectionMethod, " &
                                  "DonationTime = @DonationTime, " &
                                  "DonationType = @DonationType, " &
                                  "NextEligibilityDate = @NextEligibilityDate, " &
                                  "BagType = @BagType, " &
                                  "BloodComponent = @BloodComponent, " &
                                  "Compatibility = @Compatibility, " &
                                  "Expiration_Date = @Expiration_Date, " &
                                  "StorageLocation = @StorageLocation " &
                                  "WHERE DonorID = @DonorID"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@Blood_Group", txtBloodType.Text)
                    cmd.Parameters.AddWithValue("@RhesusFactor", txtRhesusFactor.Text)
                    cmd.Parameters.AddWithValue("@BloodVolume", txtBloodVolume.Text)
                    cmd.Parameters.AddWithValue("@CollectionMethod", CollectionCheckedList.Text)
                    cmd.Parameters.AddWithValue("@DonationTime", DateTime.Now.ToString("HH:mm:ss"))
                    cmd.Parameters.AddWithValue("@DonationType", DonationTypeCheckedlist.Text)
                    cmd.Parameters.AddWithValue("@NextEligibilityDate", CalculateNextEligibilityDate())
                    cmd.Parameters.AddWithValue("@BagType", BagTypeCheckedList.Text)
                    cmd.Parameters.AddWithValue("@BloodComponent", CheckBloodComponent())
                    cmd.Parameters.AddWithValue("@Compatibility", CheckCompatibility(BloodType))
                    cmd.Parameters.AddWithValue("@Expiration_Date", CalculateExpirationDate())
                    cmd.Parameters.AddWithValue("@StorageLocation", CheckStorageLocation())
                    cmd.Parameters.AddWithValue("@DonorID", DonorID)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Donation data successfully updated.")
                End Using
            Catch ex As MySqlException
                MessageBox.Show("Database error: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Database connection is not open.")
        End If
    End Sub

    ' Function to calculate the next eligibility date
    Private Function CalculateNextEligibilityDate() As String
        Return DateTime.Now.AddMonths(3).ToString("yyyy-MM-dd")
    End Function

    Private Function CheckStorageLocation() As String
        Select Case DonationTypeCheckedlist.Text
            Case "Whole Blood Donation", "Red Blood Cell Donation (Apheresis)"
                Return "Refrigerated Storage"
            Case "Plasma Donation (Apheresis)"
                Return "Frozen Storage"
            Case "Platelet Donation (Apheresis)"
                Return "Platelet Storage"
            Case "White Blood Cell Donatation (Apheresis"
                Return "White Blood Cell Storage"
            Case Else
                Return "Unknown"
        End Select
    End Function

    Private Function CheckBloodComponent() As String
        Select Case DonationTypeCheckedlist.Text
            Case "Whole Blood Donation"
                Return "Whole Blood"
            Case "Plasma Donation (Apheresis)"
                Return "Plasma"
            Case "Platelet Donation (Apheresis)"
                Return "Platelets"
            Case "Red Blood Cell Donation (Apheresis)"
                Return "Red Blood Cells"
            Case "White Blood Cell Donation (Apheresis)"
                Return "White Blood Cells"
            Case Else
                Return "Unknown"
        End Select
    End Function

    Private Function CheckCompatibility(BloodType As String) As String
        ' Compatibility rules for blood types and Rh factors
        Select Case BloodType
            Case "O-"
                Return "Compatible with all blood types"
            Case "O+"
                Return "Compatible with O+, A+, B+, AB+"
            Case "A-"
                Return "Compatible with A-, A+, AB-, AB+"
            Case "A+"
                Return "Compatible with A+ and AB+"
            Case "B-"
                Return "Compatible with B-, B+, AB-, AB+"
            Case "B+"
                Return "Compatible with B+ and AB+"
            Case "AB-"
                Return "Compatible with AB-, AB+"
            Case "AB+"
                Return "Compatible with AB+ only"
            Case Else
                Return "Unknown compatibility"
        End Select
    End Function

    Private Function CalculateExpirationDate() As String
        Dim expirationDate As DateTime

        ' Get the blood component type from the checked list
        Dim bloodComponent As String = CheckBloodComponent()

        ' Calculate expiration date based on the blood component
        Select Case bloodComponent
            Case "Whole Blood"
                expirationDate = DateTime.Now.AddDays(35)
            Case "Plasma"
                expirationDate = DateTime.Now.AddDays(365)
            Case "Platelets"
                expirationDate = DateTime.Now.AddDays(5)
            Case "Red Blood Cells"
                expirationDate = DateTime.Now.AddDays(42)
            Case "White Blood Cells"
                expirationDate = DateTime.Now.AddDays(1) ' 24 hours
            Case Else
                Return "Unknown expiration date"
        End Select

        ' Return the expiration date as a string
        Return expirationDate.ToString("yyyy-MM-dd")
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Eligibility_Checker_new.Show()
        Me.Hide()
    End Sub

End Class
