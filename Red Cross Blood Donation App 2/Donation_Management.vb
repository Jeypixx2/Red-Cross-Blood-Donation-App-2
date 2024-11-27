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


    ' Method to split BloodType and assign values to txtBloodType and txtRhesusFactor
    Private Sub SetBloodTypeAndRhesus()
        If Not String.IsNullOrEmpty(BloodType) Then
            ' Remove the last character if it's a + or -
            Dim bloodTypeChar As String = BloodType.Substring(0, BloodType.Length - 1)
            ' Set the Rhesus factor based on the last character
            Dim rhesusFactor As String = If(BloodType.Last() = "+", "Rh+", "Rh-")

            ' Update the text boxes
            txtBloodType.Text = bloodTypeChar
            txtRhesusFactor.Text = rhesusFactor
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

        ' Proceed with donation data insertion
        Try
            ' Insert donation data into the database
            InsertDonationData()
            ' Hide current form and show the success message
            Me.Hide()
            Process_Success.Show()
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message)
        End Try
    End Sub

    ' Method to validate blood volume
    Private Function IsBloodVolumeValid() As Boolean
        Return Not String.IsNullOrEmpty(txtBloodVolume.Text) AndAlso IsNumeric(txtBloodVolume.Text)
    End Function

    ' Method to insert donation data into the database
    Private Sub InsertDonationData()
        Dim connectionString As String = "Server=localhost;Database=redcrossdb;Uid=root;Pwd=;"
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

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
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    ' Function to calculate the next eligibility date
    Private Function CalculateNextEligibilityDate() As String
        ' Assuming a 3-month wait period after donation
        Return DateTime.Now.AddMonths(3).ToString("yyyy-MM-dd")
    End Function

    Private Sub DonationTypeCheckedlist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DonationTypeCheckedlist.SelectedIndexChanged

    End Sub
End Class
