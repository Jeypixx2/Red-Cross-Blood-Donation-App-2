Imports Microsoft.Reporting.WinForms
Imports MySql.Data.MySqlClient

Public Class Donation_History_Report
    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Donation_History_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
        Admin_Dashboard.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            modDB.openConn(modDB.db_name)

            Dim query As String = "SELECT  
    donation.DonorID, 
    donors.FirstName, 
    donors.LastName, 
    donation.DonationDate, 
    donors.BloodType,  -- BloodType is in the donors table
    donation.BloodVolume  -- BloodVolume is in the donation table
FROM 
    donation
JOIN 
    donors ON donation.DonorID = donors.DonorID;"

                Dim cmd As New MySqlCommand(query, conn)
                Dim da As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)

                With Me.ReportViewer1.LocalReport
                    .DataSources.Clear()
                    Dim reportPath As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "Donation_Hist_Report.rdlc")
                    .ReportPath = reportPath
                    .DataSources.Add(New ReportDataSource("DataSet2", dt))
                End With

            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
        End Try
    End Sub
End Class