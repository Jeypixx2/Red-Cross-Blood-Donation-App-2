Imports MySql.Data.MySqlClient

Public Class Donor_Management_New
    Public DonorID As Integer
    Public BloodType As String

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        User_Status.Show()
    End Sub

    ' Calculate Age based on DateofBirth and current date (RegDate)
    Private Function CalculateAge(dateOfBirth As DateTime) As Integer
        Dim age As Integer = DateTime.Now.Year - dateOfBirth.Year
        If DateTime.Now < dateOfBirth.AddYears(age) Then
            age -= 1
        End If
        Return age
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Open connection using modDB.openConn
        modDB.openConn("redcrossdb")

        ' Check if the connection is open
        If modDB.conn.State = ConnectionState.Open Then
            Try
                ' Log the input values for debugging purposes
                MessageBox.Show("First Name: " & txtFirstName.Text)
                MessageBox.Show("Last Name: " & txtlastname.Text)
                MessageBox.Show("Date of Birth: " & MonthCalendar1.SelectionStart.ToString("MM/dd/yyyy"))

                ' Check for empty fields
                If String.IsNullOrEmpty(txtlastname.Text) OrElse String.IsNullOrEmpty(txtFirstName.Text) OrElse MonthCalendar1.SelectionStart = Nothing Then
                    MessageBox.Show("Please fill in all required fields.")
                    Exit Sub
                End If

                ' Validate date of birth
                Dim dob As DateTime = MonthCalendar1.SelectionStart
                If dob = Nothing Then
                    MessageBox.Show("Invalid date format. Please select a valid date.")
                    Exit Sub
                End If

                ' Check for duplicate entries
                Dim duplicateCheckQuery As String = "SELECT COUNT(*) FROM donors WHERE LastName = @LastName AND FirstName = @FirstName AND DateofBirth = @DateOfBirth AND BloodType = @BloodType"
                Using duplicateCheckCmd As New MySqlCommand(duplicateCheckQuery, modDB.conn)
                    duplicateCheckCmd.Parameters.AddWithValue("@LastName", txtlastname.Text)
                    duplicateCheckCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
                    duplicateCheckCmd.Parameters.AddWithValue("@DateOfBirth", dob.ToString("yyyy-MM-dd"))
                    duplicateCheckCmd.Parameters.AddWithValue("@BloodType", txtbloodtype.Text)

                    Dim count As Integer = Convert.ToInt32(duplicateCheckCmd.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("A donor with these details already exists.")
                        Exit Sub
                    End If
                End Using

                ' Insert new donor record
                Dim query As String = "INSERT INTO donors (LastName, FirstName, MiddleName, Baranggay, City, Province, DateofBirth, Sex, BloodType, RegDate, Age, CivilStatus, Nationality, Occupation) " &
                                      "VALUES (@LastName, @FirstName, @MiddleName, @Baranggay, @City, @Province, @DateOfBirth, @Sex, @BloodType, @RegDate, @Age, @CivilStatus, @Nationality, @Occupation)"
                Using cmd As New MySqlCommand(query, modDB.conn)
                    cmd.Parameters.AddWithValue("@LastName", txtlastname.Text)
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
                    cmd.Parameters.AddWithValue("@MiddleName", txtmiddlename.Text)
                    cmd.Parameters.AddWithValue("@Baranggay", TxtBaranggay.Text)
                    cmd.Parameters.AddWithValue("@City", txtcity.Text)
                    cmd.Parameters.AddWithValue("@Province", txtprovince.Text)
                    cmd.Parameters.AddWithValue("@DateOfBirth", dob.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@Sex", txtsex.Text)
                    cmd.Parameters.AddWithValue("@BloodType", txtbloodtype.Text)
                    cmd.Parameters.AddWithValue("@RegDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    cmd.Parameters.AddWithValue("@Age", CalculateAge(dob)) ' Pass the calculated age here
                    cmd.Parameters.AddWithValue("@CivilStatus", txtcivilstatus.Text)
                    cmd.Parameters.AddWithValue("@Nationality", txtnationality.Text)
                    cmd.Parameters.AddWithValue("@Occupation", txtoccupation.Text)

                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Donor information has been successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Retrieve Donor Data after insertion
                RetrieveDonorData()

                ' Pass DonorID, BloodType, and Age to Eligibility_Checker_new form
                Eligibility_Checker_new.DonorID = Me.DonorID
                Eligibility_Checker_new.BloodType = Me.BloodType
                Eligibility_Checker_new.DonorAge = CalculateAge(MonthCalendar1.SelectionStart) ' Pass the calculated age
                Eligibility_Checker_new.Show()
                Me.Hide()

            Catch ex As MySqlException
                MessageBox.Show("MySQL Error: " & ex.Message)
            Catch ex As Exception
                MessageBox.Show("General Error: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Database connection is not open.")
        End If
    End Sub

    ' Function to retrieve donor data
    Private Sub RetrieveDonorData()
        ' Ensure the connection is open before querying
        modDB.openConn("redcrossdb")

        ' Query to get DonorID and BloodType
        Dim getDonorIdQuery As String = "SELECT DonorID, BloodType FROM donors WHERE LastName = @LastName AND FirstName = @FirstName AND DateofBirth = @DateOfBirth"
        Using getCmd As New MySqlCommand(getDonorIdQuery, modDB.conn)
            getCmd.Parameters.AddWithValue("@LastName", txtlastname.Text)
            getCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
            getCmd.Parameters.AddWithValue("@DateOfBirth", MonthCalendar1.SelectionStart)

            Using reader As MySqlDataReader = getCmd.ExecuteReader()
                If reader.Read() Then
                    DonorID = reader.GetInt32("DonorID")
                    BloodType = reader("BloodType").ToString()
                End If
            End Using
        End Using
    End Sub

    Private Sub Donor_Management_New_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
