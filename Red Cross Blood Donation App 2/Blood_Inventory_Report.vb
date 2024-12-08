Imports Microsoft.Reporting.WinForms
Imports MySql.Data.MySqlClient

Public Class Blood_Inventory_Report
    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            modDB.openConn(modDB.db_name)

            Dim query As String = "SELECT 
                    donors.BloodType,
                    donation.Blood_Group,
                    donation.RhesusFactor,
                    COALESCE(donation.Expiration_Date, '1900-01-01') AS Expiration_Date
                FROM 
                    donors
                JOIN 
                    donation
                ON 
                    donors.DonorID = donation.DonorID;"

            Dim cmd As New MySqlCommand(query, conn)
            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()

                ' Build the dynamic path to the .rdlc file
                Dim reportPath As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "Blood_Inven_Report.rdlc")
                .ReportPath = reportPath
                .DataSources.Add(New ReportDataSource("DataSet3", dt))
            End With

            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
        Admin_Dashboard.Show()
    End Sub

    Private Sub Blood_Inventory_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class