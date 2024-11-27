Imports Microsoft.Reporting.WinForms
Imports MySql.Data.MySqlClient

Public Class Blood_Inventory_Report
    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Connect()

            Dim query As String = "SELECT 
                    donors.BloodType,
                    donation.Blood_Group,
                    donation.RhesusFactor,
                    donation.Number_Of_Unit,
                    donation.Expiration_Date
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
                .ReportPath = "C:\Users\WINDOWS\source\repos\Red Cross Blood Donation App 2\Red Cross Blood Donation App 2\Blood_Inven_Report.rdlc"
                .DataSources.Add(New ReportDataSource("DataSet3", dt))
            End With

            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub
End Class