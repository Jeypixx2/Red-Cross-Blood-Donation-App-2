Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms

Public Class Donor_Registration_Report
    Private Sub Donor_Registration_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load
        ' Any additional logic for ReportViewer1 Load can go here
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' Use the existing connection from MySQLModule
            Dim connection As MySqlConnection = modDB.conn

            If connection IsNot Nothing AndAlso connection.State = ConnectionState.Open Then
                Dim query As String = "SELECT donors.DonorID, donors.FirstName, donors.MiddleName, donors.LastName, donors.BloodType, donors.RegDate, " &
                                      "CASE " &
                                      "    WHEN eligibility.EligibilityStatus = 1 THEN 'Eligible' " &
                                      "    WHEN eligibility.EligibilityStatus = 0 THEN 'Not Eligible' " &
                                      "END AS EligibilityStatus " &
                                      "FROM donors " &
                                      "JOIN eligibility ON donors.DonorID = eligibility.DonorID"
                Dim cmd As New MySqlCommand(query, connection)
                Dim da As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)

                ' Set up the report data source and path
                With Me.ReportViewer1.LocalReport
                    .DataSources.Clear()
                    .ReportPath = "C:\Users\WINDOWS\source\repos\Red Cross Blood Donation App 2\Red Cross Blood Donation App 2\Donor_Reg_Report.rdlc" ' Adjust path if needed
                    .DataSources.Add(New ReportDataSource("DataSet1", dt))
                End With

                Me.ReportViewer1.RefreshReport()
            Else
                MessageBox.Show("Database connection is not open.")
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            ' No need to close the connection here since it's managed by MySQLModule
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
        Admin_Dashboard.Show()
    End Sub
End Class
