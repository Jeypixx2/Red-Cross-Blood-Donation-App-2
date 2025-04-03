Imports Microsoft.Reporting.WinForms
Imports MySql.Data.MySqlClient

Public Class Print
    Private Sub Print_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            modDB.openConn(modDB.db_name)

            Dim fromDate As String = dtpFrom.Value.ToString("yyyy-MM-dd")
            Dim toDate As String = dtpTo.Value.ToString("yyyy-MM-dd")

            Dim query As String = "SELECT 
                                    RetrieveID, 
                                    CompanyHospitalName, 
                                    PersonnelName, 
                                    BloodID, 
                                    LastName, 
                                    FirstName, 
                                    Blood_Group
                                FROM healthprovider
                                WHERE RetrieveDate BETWEEN @FromDate AND @ToDate;"

            Dim cmd As New MySqlCommand(query, modDB.conn)
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
                Dim reportPath As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "Health_Report.rdlc")
                .ReportPath = reportPath
                .DataSources.Add(New ReportDataSource("DataSet6", dt))
            End With

            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ' Find existing form if it's already open
        For Each f As Form In Application.OpenForms
            If TypeOf f Is HealthCare_Dashboard Then
                f.Show()
                Me.Close()
                Return
            End If
        Next
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged

    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged

    End Sub
End Class