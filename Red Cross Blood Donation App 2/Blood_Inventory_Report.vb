Imports Microsoft.Reporting.WinForms
Imports MySql.Data.MySqlClient

Public Class Blood_Inventory_Report
    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            modDB.openConn(modDB.db_name)

            ' Get the selected date range from the DateTimePicker controls
            Dim fromDate As String = dtpFrom.Value.ToString("yyyy-MM-dd")
            Dim toDate As String = dtpTo.Value.ToString("yyyy-MM-dd")

            ' Update the query to filter by the date range
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
                donors.DonorID = donation.DonorID
            WHERE 
                donation.Expiration_Date BETWEEN @FromDate AND @ToDate;"

            ' Prepare the command with parameters
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@FromDate", fromDate)
            cmd.Parameters.AddWithValue("@ToDate", toDate)

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
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
        Admin_Dashboard.Show()
    End Sub

    Private Sub Blood_Inventory_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged

    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged

    End Sub
End Class