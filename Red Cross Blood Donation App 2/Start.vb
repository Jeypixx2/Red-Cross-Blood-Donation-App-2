' Start.vb (Main Form)
Imports MySql.Data.MySqlClient

Public Class Start
    Public frmhelper As New FormHelper


    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the database connection
        frmhelper.Seeders()
        UpdateConnectionString()
        openConn("redcrossdb")


    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        Me.Hide()
        Admin_Access.Show()
    End Sub

    Private Sub btnHealthcareprovider_Click(sender As Object, e As EventArgs) Handles btnHealthcareprovider.Click
        Me.Hide()
        HealthCare_Access.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        SuperAdmin_Access.Show()
    End Sub


End Class

Public Class DonorData
    Public Property DonorID As Integer
    Public Property BloodComponent As String
    Public Property BloodVolume As Decimal
End Class

