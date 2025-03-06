Imports Microsoft.Reporting.WinForms
Imports MySql.Data.MySqlClient

Public Class Health_Provider_Report
    Private Sub Health_Provider_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            modDB.openConn(modDB.db_name)

            ' Get the selected date range from the DateTimePicker controls
            Dim fromDate As String = dtpFrom.Value.ToString("yyyy-MM-dd")
            Dim toDate As String = dtpTo.Value.ToString("yyyy-MM-dd")

            ' Update the query to include a date filter for registration dates
            Dim query As String = "SELECT 
    RetrieveID, 
    HealthProviderID, 
    CompanyHospitalName, 
    PersonnelID, 
    PersonnelName, 
    BloodID, 
    RetrieveDate
FROM healthprovider
WHERE RetrieveDate BETWEEN @FromDate AND @ToDate;


"

            ' Prepare the command with parameters
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@FromDate", fromDate)
            cmd.Parameters.AddWithValue("@ToDate", toDate)

            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            ' Check if data exists
            If dt.Rows.Count = 0 Then
                MsgBox("No donor registrations found within the selected date range.", MsgBoxStyle.Information)
                Return
            End If

            ' Set up the report data source and path
            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                Dim reportPath As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "Health_Provider_Report.rdlc")
                .ReportPath = reportPath
                .DataSources.Add(New ReportDataSource("DataSet5", dt))
            End With

            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub
End Class