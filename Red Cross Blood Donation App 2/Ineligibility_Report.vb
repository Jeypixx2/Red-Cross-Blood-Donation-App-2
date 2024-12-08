Imports Microsoft.Reporting.WinForms
Imports MySql.Data.MySqlClient

Public Class Ineligibility_Report
    Private Sub Ineligibility_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' Use the connection within a Using block to automatically close it
            Using connection As New MySqlConnection(modDB.conn.ConnectionString)
                connection.Open() ' Open connection

                ' SQL query
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

                ' Use MySqlDataAdapter to fill DataTable
                Dim cmd As New MySqlCommand(query, connection)
                Dim da As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                ' Check if data exists
                If dt.Rows.Count = 0 Then
                    MsgBox("No data found for this report.", MsgBoxStyle.Information)
                    Return
                End If

                ' Set up the report viewer with the data
                With Me.ReportViewer1.LocalReport
                    .DataSources.Clear()
                    Dim reportPath As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "Ineligibility_Rep.rdlc")
                    .ReportPath = reportPath
                    .DataSources.Add(New ReportDataSource("DataSet4", dt))
                End With

                ' Refresh the report
                Me.ReportViewer1.RefreshReport()

            End Using ' Connection will automatically close here

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
        Admin_Dashboard.Show()
    End Sub
End Class
