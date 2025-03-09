' Start.vb (Main Form)
Imports System.Data.SqlClient

Public Class Start
    Public frmhelper As New FormHelper


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the connection (if needed)
        'frmhelper.Seeders()
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



