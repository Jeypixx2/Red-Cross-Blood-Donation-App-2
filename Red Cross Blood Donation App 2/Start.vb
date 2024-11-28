Public Class Start
    Public frmhelper As New FormHelper
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'frmhelper.Seeders()
        MySQLModule.Connect()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles pbLogo.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        Me.Hide()
        Admin_Access.Show()
    End Sub

    Private Sub btnHealthcareprovider_Click(sender As Object, e As EventArgs) Handles btnHealthcareprovider.Click
        Me.Hide()
        HealthCare_Access.Show()
    End Sub
End Class
