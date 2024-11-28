Imports Microsoft.Reporting.WinForms
Imports MySql.Data.MySqlClient

Public Class Ineligibility_Report
    Private Sub Ineligibility_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim connection As MySqlConnection = MySQLModule.conn
            If connection IsNot Nothing AndAlso connection.State = ConnectionState.Open Then

                Dim query As String = "
            SELECT 
                donors.DonorID, 
                donors.FirstName, 
                donors.LastName, 
                CASE 
                    WHEN eligibility.EligibilityStatus = 0 THEN 'Ineligible' 
                END AS EligibilityStatus, 
                donation.NextEligibilityDate
            FROM 
                donors
            JOIN 
                eligibility ON donors.DonorID = eligibility.DonorID
            JOIN 
                donation ON donors.DonorID = donation.DonorID
            WHERE 
                eligibility.EligibilityStatus = 0;
        "

                Dim cmd As New MySqlCommand(query, conn)
                Dim da As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)

                If dt.Rows.Count = 0 Then
                    MsgBox("No data found for this report.", MsgBoxStyle.Information)
                End If

                With Me.ReportViewer1.LocalReport
                    .DataSources.Clear()
                    .ReportPath = "C:\Users\WINDOWS\source\repos\Red Cross Blood Donation App 2\Red Cross Blood Donation App 2\Ineligibility_Rep.rdlc"
                    .DataSources.Add(New ReportDataSource("DataSet4", dt))
                End With

                Me.ReportViewer1.RefreshReport()
            Else
                MessageBox.Show("Database connection is not open.")
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
        End Try
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class