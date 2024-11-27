Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms

Public Class Donor_Registration_Report
    Private Sub Donor_Registration_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Connect()

            Dim query As String = "SELECT donors.DonorID, donors.FirstName, donors.MiddleName, donors.LastName, donors.BloodType, donors.RegDate, " &
                                  "CASE " &
                                  "    WHEN eligibility.EligibilityStatus = 1 THEN 'Eligible' " &
                                  "    WHEN eligibility.EligibilityStatus = 0 THEN 'Not Eligible' " &
                                  "END AS EligibilityStatus " &
                                  "FROM donors " &
                                  "JOIN eligibility ON donors.DonorID = eligibility.DonorID"
            Dim cmd As New MySqlCommand(query, conn)
            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "C:\Users\WINDOWS\source\repos\Red Cross Blood Donation App 2\Red Cross Blood Donation App 2\Donor_Reg_Report.rdlc" ' Adjust path if needed
                .DataSources.Add(New ReportDataSource("DataSet1", dt))
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
