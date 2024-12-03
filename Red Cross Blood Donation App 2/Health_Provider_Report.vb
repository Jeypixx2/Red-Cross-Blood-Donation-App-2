Imports Microsoft.Reporting.WinForms
Imports MySql.Data.MySqlClient

Public Class Health_Provider_Report
    Private Sub Health_Provider_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            modDB.openConn(modDB.db_name)
            Dim query As String = "SELECT 
    hp.RetrieveID,
    hp.HealthProviderID,
    hp.CompanyHospitalName,
    hp.PersonnelID,
    hp.PersonnelName,
    d.BloodID,
    hp.RetrieveDate
FROM 
    healthprovider hp
JOIN 
    donation d ON hp.BloodID = d.BloodID  -- Use BloodID to join the tables
JOIN 
    donors dn ON dn.DonorID = d.DonorID;
"


            Dim cmd As New MySqlCommand(query, conn)
                Dim da As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)

                With Me.ReportViewer1.LocalReport
                    .DataSources.Clear()

                    ' Build the dynamic path to the .rdlc file
                    Dim reportPath As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "Health_Provider_Report.rdlc")
                    .ReportPath = reportPath
                    .DataSources.Add(New ReportDataSource("DataSet5", dt))
                End With

            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
        End Try
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Admin_Dashboard.Show()
        Me.Hide()
    End Sub
End Class