Public Class User_Status
    Private Sub User_Status_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Code to run when the form loads can go here, such as initializing controls or loading data.
    End Sub

    ' Event handler for the "New Donor" button
    Private Sub btnNewDonor_Click(sender As Object, e As EventArgs) Handles New_Donor.Click
        Donor_Management_New.Show()
        Me.Hide()
    End Sub

    ' Event handler for the "Old Donor" button
    Private Sub btnOldDonor_Click(sender As Object, e As EventArgs) Handles Old_Donor.Click
        User_Status_Old.Show()
        Me.Hide()
    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Admin_Dashboard.Show()
        Me.Hide()
    End Sub
End Class
