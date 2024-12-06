Imports MySql.Data.MySqlClient

Public Class User_Status_Old
    Public DonorID As Integer ' Variable to hold DonorID
    Public DonorFullName As String ' Variable to hold Full Name
    Public BloodType As String ' Variable to hold BloodType
    Public DonorAge As Integer ' Variable to hold calculated Age

    Private Sub Search_Click(sender As Object, e As EventArgs) Handles Search.Click
        Dim firstName As String = FirstNameTextBox.Text
        Dim middleName As String = MiddleNameTextBox.Text
        Dim lastName As String = LastNameTextBox.Text

        If String.IsNullOrEmpty(firstName) OrElse String.IsNullOrEmpty(middleName) OrElse String.IsNullOrEmpty(lastName) Then
            MessageBox.Show("Please fill in all name fields.")
            Return
        End If

        Try
            ' Open the connection using modDB.openConn
            modDB.openConn("redcrossdb")
            Dim connection As MySqlConnection = modDB.conn

            ' Query to retrieve donor details and latest NextEligibilityDate
            Dim donorQuery As String = "SELECT DonorID, BloodType, DateOfBirth, CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS FullName " &
                                       "FROM donors WHERE FirstName = @firstName AND MiddleName = @middleName AND LastName = @lastName"
            Using command As New MySqlCommand(donorQuery, connection)
                command.Parameters.AddWithValue("@firstName", firstName.Trim())
                command.Parameters.AddWithValue("@middleName", middleName.Trim())
                command.Parameters.AddWithValue("@lastName", lastName.Trim())

                Using reader As MySqlDataReader = command.ExecuteReader()
                    If reader.HasRows Then
                        While reader.Read()
                            DonorID = Convert.ToInt32(reader("DonorID"))
                            BloodType = reader("BloodType").ToString()

                            ' Calculate the donor's age using DateOfBirth
                            Dim birthdate As DateTime = Convert.ToDateTime(reader("DateOfBirth"))
                            DonorAge = CalculateAge(birthdate)

                            ' After retrieving DonorID, check NextEligibilityDate
                            reader.Close() ' Close the reader before executing the next query

                            ' Query to retrieve the latest NextEligibilityDate
                            Dim eligibilityQuery As String = "SELECT NextEligibilityDate FROM donation WHERE DonorID = @DonorID ORDER BY NextEligibilityDate DESC LIMIT 1"
                            Using eligibilityCmd As New MySqlCommand(eligibilityQuery, connection)
                                eligibilityCmd.Parameters.AddWithValue("@DonorID", DonorID)
                                Dim nextEligibilityDate As Object = eligibilityCmd.ExecuteScalar()

                                If nextEligibilityDate IsNot DBNull.Value Then
                                    Dim eligibilityDate As DateTime = Convert.ToDateTime(nextEligibilityDate)

                                    If DateTime.Now < eligibilityDate Then
                                        MessageBox.Show("You have a recent Donation. Unable to continue the process. Please return on " & eligibilityDate.ToString("yyyy-MM-dd") & ".")
                                        Return
                                    End If
                                End If
                            End Using

                            ' Set values in the next form
                            Eligibility_Checker_old.BloodType = BloodType
                            Eligibility_Checker_old.DonorID = DonorID
                            Eligibility_Checker_old.DonorAge = DonorAge

                            ' Show the next form and hide the current form
                            Eligibility_Checker_old.Show()
                            Me.Hide()
                            Exit Sub
                        End While
                    Else
                        MessageBox.Show("No users found with that name.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    ' Age calculation method
    Private Function CalculateAge(birthdate As DateTime) As Integer
        Dim today As DateTime = DateTime.Now
        Dim age As Integer = today.Year - birthdate.Year

        ' If birthday hasn't occurred yet this year, subtract 1 from age
        If today.Month < birthdate.Month OrElse (today.Month = birthdate.Month AndAlso today.Day < birthdate.Day) Then
            age -= 1
        End If

        Return age
    End Function

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Admin_Dashboard.Show()
        Me.Hide()
    End Sub

    Private Sub User_Status_Old_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ensure the connection is opened when form loads
        modDB.openConn("redcrossdb")
    End Sub
End Class
