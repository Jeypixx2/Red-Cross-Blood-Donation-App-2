Public Class User_Status

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
        GoBack(Me)
        Me.Hide()
    End Sub
End Class
