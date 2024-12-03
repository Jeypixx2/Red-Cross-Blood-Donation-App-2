Imports MySql.Data.MySqlClient

Public Class Donation_Management_new
    ' Properties to hold values from the previous forms
    Public Property DonorID As Integer
    Public Property DonorName As String
    Public Property BloodType As String
    Public Property HemoglobinLevel As String
    Public Property BloodPressure As String

    ' Event handler for form load
    Private Sub Donation_Management_new_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ensure MySQLModule.conn is already available (connection established in the Start form)

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

    ' Method to insert donation data into the database
    Private Sub InsertDonationData()
        ' Use the existing connection from MySQLModule (no need to call Connect again)
        Dim connection As MySqlConnection = modDB.conn

        If connection IsNot Nothing AndAlso connection.State = ConnectionState.Open Then
            Try
                ' SQL query for inserting the donation data into the database
                Dim query As String = "INSERT INTO donation (DonationDate, DonorID, BloodType, RhesusFactor, BloodVolume, CollectionMethod, DonationTime, DonationType, NextEligibilityDate) " &
                                      "VALUES (@DonationDate, @DonorID, @BloodType, @RhesusFactor, @BloodVolume, @CollectionMethod, @DonationTime, @DonationType, @NextEligibilityDate)"
                Using cmd As New MySqlCommand(query, connection)
                    ' Set parameters for the query
                    cmd.Parameters.AddWithValue("@DonationDate", DateTime.Now.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@DonorID", DonorID)

                    cmd.Parameters.AddWithValue("@BloodType", txtBloodType.Text)
                    cmd.Parameters.AddWithValue("@RhesusFactor", txtRhesusFactor.Text)
                    cmd.Parameters.AddWithValue("@BloodVolume", txtBloodVolume.Text)
                    cmd.Parameters.AddWithValue("@CollectionMethod", CollectionCheckedList.Text)
                    cmd.Parameters.AddWithValue("@DonationTime", DateTime.Now.ToString("HH:mm:ss"))
                    cmd.Parameters.AddWithValue("@DonationType", DonationTypeCheckedlist.Text)
                    cmd.Parameters.AddWithValue("@NextEligibilityDate", CalculateNextEligibilityDate())

                    ' Execute the query
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

    ' Function to calculate the next eligibility date
    Private Function CalculateNextEligibilityDate() As String
        ' Assuming a 3-month wait period after donation
        Return DateTime.Now.AddMonths(3).ToString("yyyy-MM-dd")
    End Function

    Private Sub Proceed_Click(sender As Object, e As EventArgs) Handles Proceed.Click
        Process_Success.Show()
        Me.Hide()
    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Eligibility_Checker_new.Show()
        Me.Hide()
    End Sub

End Class
