Imports System.Windows.Forms.DataVisualization.Charting
Imports MySql.Data.MySqlClient

Public Class SuperAdmin_Dashboard
    Public currentTable As String
    Public GlobalModel As New Global_model
    Public DoubleBuffering As New DoubleBuffering
    Public SelectedDate As Date
    Public dbDateColumn As String
    Public Calendar As Integer

    ' Mapping of table names to their primary key column names
    Dim tablePrimaryKeys As New Dictionary(Of String, String) From {
        {"donors", "DonorID"},
        {"eligibility", "EligibilityID"},
        {"donation", "bloodID"},
        {"healthprovider", "RetrieveID"},
        {"history", "HistoryID"},
        {"logs", "user_accounts_id"},
        {"accounts", "adminID"},
        {"healthprovideraccounts", "HCPid"}
    }

    Private searchTimer As New Timer()

    Private Sub SuperAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnableEditingAndDeleting()
        Try
            Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
            Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
            Me.Width = screenWidth * 0.8
            Me.Height = screenHeight * 0.8
            UpdateConnectionString()
            DoubleBuffering.EnableDoubleBuffering(dgvInventory)
            currentTable = "donors"
            dbDateColumn = "RegDate"
            Calendar = 1
            modDB.Logs("Load SuperAdmin Dashboard Successfully!")

            If SelectedDate = Date.MinValue Then
                SelectedDate = DateTime.Now
            End If

            Dim query As String = $"SELECT * FROM {currentTable} WHERE DATE({dbDateColumn}) = '{SelectedDate:yyyy-MM-dd}'"
            modDB.readQuery(query)

            If modDB.cmdRead IsNot Nothing AndAlso modDB.cmdRead.HasRows Then
                Dim dt As New DataTable
                dt.Load(modDB.cmdRead)
                dgvInventory.DataSource = dt
                dgvInventory.Refresh()
            Else
                MessageBox.Show("No records found for the selected date.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            cmbBloodType.Items.AddRange(New String() {"A-", "A+", "B-", "B+", "AB-", "AB+", "O-", "O+"})
            cmbBloodType.SelectedItem = "O-"

            dtpDonutMonth.Format = DateTimePickerFormat.Custom
            dtpDonutMonth.CustomFormat = "MMMM yyyy"
            dtpDonutMonth.ShowUpDown = True
            dtpDonutMonth.Value = DateTime.Now

            AddHandler searchTimer.Tick, AddressOf PerformSearch

            LoadDonutChart()
            If cmbBloodType.SelectedItem IsNot Nothing Then
                LoadBarChart(cmbBloodType.SelectedItem.ToString())
            End If
        Catch ex As Exception
            MessageBox.Show("Error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PopulateMonths()
        cmbMonths.Items.Clear()
        For month As Integer = 1 To 12
            cmbMonths.Items.Add(Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month))
        Next
        If cmbMonths.Items.Count > 0 Then cmbMonths.SelectedIndex = 0
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Daily.Click
        dtpCalendar.Visible = True
        cmbMonths.Visible = False
        modDB.Logs("Filter Daily")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Weekly.Click
        Calendar = 2
        dtpCalendar.Visible = True
        cmbMonths.Visible = False
        modDB.Logs("Filter Weekly")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Monthly.Click
        PopulateMonths()
        dtpCalendar.Visible = False
        cmbMonths.Visible = True
        modDB.Logs("Filter Monthly")
    End Sub

    Private Sub cmbMonths_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMonths.SelectedIndexChanged
        Dim selectedMonth As Integer = cmbMonths.SelectedIndex + 1
        Dim currentYear As Integer = DateTime.Now.Year
        Dim dataTable = GlobalModel.GetAll(currentTable, 3, dbDateColumn, selectedMonth, currentYear)
        GlobalModel.UpdateDataGridView(dataTable, dgvInventory)
        cmbMonths.Visible = False
    End Sub

    Private Sub DonorRecord_Click(sender As Object, e As EventArgs) Handles DonorRecord.Click
        UpdateConnectionString()
        DoubleBuffering.EnableDoubleBuffering(dgvInventory)
        currentTable = "donors"
        dbDateColumn = "RegDate"
        Calendar = 1
        Dim query As String = $"SELECT * FROM {currentTable}"
        Dim rowCount As Integer = modDB.LoadToDGV(query, dgvInventory)
        modDB.Logs("View Donor History")
        If rowCount = 0 Then MessageBox.Show("No donor records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub DonationRecord_Click(sender As Object, e As EventArgs) Handles DonationRecord.Click
        UpdateConnectionString()
        DoubleBuffering.EnableDoubleBuffering(dgvInventory)
        currentTable = "donation"
        dbDateColumn = "DonationDate"
        Calendar = 1
        Dim query As String = $"SELECT * FROM {currentTable}"
        Dim rowCount As Integer = modDB.LoadToDGV(query, dgvInventory)
        modDB.Logs("View Donation History")
        If rowCount = 0 Then MessageBox.Show("No donation records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub EligibilityRecord_Click(sender As Object, e As EventArgs) Handles EligibilityRecord.Click
        UpdateConnectionString()
        DoubleBuffering.EnableDoubleBuffering(dgvInventory)
        currentTable = "eligibility"
        dbDateColumn = "EligibilityDate"
        Calendar = 1
        Dim query As String = $"SELECT * FROM {currentTable}"
        Dim rowCount As Integer = modDB.LoadToDGV(query, dgvInventory)
        modDB.Logs("View Eligibility History")
        If rowCount = 0 Then MessageBox.Show("No eligibility records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Health_Provider_Click(sender As Object, e As EventArgs) Handles Health_Provider.Click
        UpdateConnectionString()
        DoubleBuffering.EnableDoubleBuffering(dgvInventory)
        currentTable = "healthprovider"
        dbDateColumn = "RetrieveDate"
        Calendar = 1
        Dim query As String = $"SELECT * FROM {currentTable}"
        Dim rowCount As Integer = modDB.LoadToDGV(query, dgvInventory)
        modDB.Logs("View Health Provider")
        If rowCount = 0 Then MessageBox.Show("No history records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub History_Click(sender As Object, e As EventArgs) Handles History.Click
        UpdateConnectionString()
        DoubleBuffering.EnableDoubleBuffering(dgvInventory)
        currentTable = "history"
        dbDateColumn = "DonorRegDate"
        Calendar = 1
        Dim query As String = $"SELECT * FROM {currentTable}"
        Dim rowCount As Integer = modDB.LoadToDGV(query, dgvInventory)
        modDB.Logs("View Health Provider")
        If rowCount = 0 Then MessageBox.Show("No history records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        modDB.Logs("View History Data")
    End Sub

    Private Sub Logs_Click(sender As Object, e As EventArgs) Handles Logs.Click
        UpdateConnectionString()
        DoubleBuffering.EnableDoubleBuffering(dgvInventory)
        currentTable = "logs"
        dbDateColumn = "dt"
        Calendar = 1
        Dim query As String = $"SELECT * FROM {currentTable}"
        Dim rowCount As Integer = modDB.LoadToDGV(query, dgvInventory)
        modDB.Logs("View Health Provider")
        If rowCount = 0 Then MessageBox.Show("No history records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        modDB.Logs("View Logs Data")
    End Sub

    Private Sub Accounts_Click(sender As Object, e As EventArgs) Handles Accounts.Click
        UpdateConnectionString()
        DoubleBuffering.EnableDoubleBuffering(dgvInventory)
        currentTable = "accounts"
        dbDateColumn = "dt_created"
        Calendar = 1
        Dim query As String = $"SELECT * FROM {currentTable}"
        Dim rowCount As Integer = modDB.LoadToDGV(query, dgvInventory)
        modDB.Logs("View Health Provider")
        If rowCount = 0 Then MessageBox.Show("No history records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        modDB.Logs("View Accounts Data")
    End Sub

    Private Sub HP_Accounts_Click(sender As Object, e As EventArgs) Handles HP_Accounts.Click
        UpdateConnectionString()
        DoubleBuffering.EnableDoubleBuffering(dgvInventory)
        currentTable = "healthprovideraccounts"
        dbDateColumn = "CreatedDate"
        Calendar = 1
        Dim query As String = $"SELECT * FROM {currentTable}"
        Dim rowCount As Integer = modDB.LoadToDGV(query, dgvInventory)
        modDB.Logs("View Health Provider Accounts")
        If rowCount = 0 Then MessageBox.Show("No history records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        modDB.Logs("View Accounts Data")
    End Sub

    Private Sub dtpCalendar_DateChanged(sender As Object, e As DateRangeEventArgs) Handles dtpCalendar.DateSelected
        SelectedDate = dtpCalendar.SelectionStart
        Dim SelectedDateWeek As Date = SelectedDate.AddDays(DayOfWeek.Saturday - SelectedDate.DayOfWeek)
        Dim dataTable As DataTable
        If Calendar = 2 Then
            dataTable = GlobalModel.GetAll(currentTable, Calendar, dbDateColumn, SelectedDate, SelectedDateWeek)
        Else
            dataTable = GlobalModel.GetAll(currentTable, Calendar, dbDateColumn, SelectedDate)
        End If
        GlobalModel.UpdateDataGridView(dataTable, dgvInventory)
        dtpCalendar.Visible = False
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Daily.Enabled = False
        Weekly.Enabled = False
        Monthly.Enabled = False
        searchTimer.Stop()
        searchTimer.Interval = 500
        searchTimer.Start()
        modDB.Logs("Search Data")
    End Sub

    Private Sub PerformSearch(sender As Object, e As EventArgs)
        Try
            Dim searchText As String = txtSearch.Text
            If Not String.IsNullOrWhiteSpace(searchText) Then
                Dim results As DataTable = GlobalModel.Search(searchText, currentTable)
                If results IsNot Nothing AndAlso results.Rows.Count > 0 Then
                    GlobalModel.UpdateDataGridView(results, dgvInventory)
                Else
                    If txtSearch.Tag Is Nothing OrElse txtSearch.Tag.ToString() <> "No Results" Then
                        MessageBox.Show("No results found. Please try a different search term.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtSearch.Clear()
                        txtSearch.Tag = "No Results"
                    End If
                End If
            Else
                dgvInventory.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Error occurred while performing the search: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Daily.Enabled = True
            Weekly.Enabled = True
            Monthly.Enabled = True
            searchTimer.Stop()
            txtSearch.Tag = Nothing
        End Try
    End Sub

    Private Sub cmbBloodType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBloodType.SelectedIndexChanged
        If cmbBloodType.SelectedItem IsNot Nothing Then
            LoadBarChart(cmbBloodType.SelectedItem.ToString())
        End If
    End Sub

    Private Sub dtpDonutMonth_ValueChanged(sender As Object, e As EventArgs) Handles dtpDonutMonth.ValueChanged
        LoadDonutChart()
        If cmbBloodType.SelectedItem IsNot Nothing Then
            LoadBarChart(cmbBloodType.SelectedItem.ToString())
        End If
    End Sub

    'Reports
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Donor_Registration_Report.Show()
        modDB.Logs("View Donor Registration Report")
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Donation_History_Report.Show()
        modDB.Logs("View Donation Donationn Histroy Report")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Blood_Inventory_Report.Show()
        modDB.Logs("View Blood Inventory Report")
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Ineligibility_Report.Show()
        modDB.Logs("View Ineligibility Report")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Health_Provider_Report.Show()
        modDB.Logs("View Health Provider Report")
    End Sub

    Private Sub EnableEditingAndDeleting()
        dgvInventory.ReadOnly = False
        dgvInventory.AllowUserToDeleteRows = True
    End Sub

    Private Sub dgvInventory_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInventory.CellValueChanged
        Try
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                If dgvInventory.Rows(e.RowIndex).IsNewRow Then Exit Sub
                Dim editedCell = dgvInventory.Rows(e.RowIndex).Cells(e.ColumnIndex)
                Dim columnName = dgvInventory.Columns(e.ColumnIndex).Name
                Dim newValue As Object = If(editedCell.Value IsNot Nothing, editedCell.Value, DBNull.Value)
                Dim primaryKeyColumn As String = Nothing
                If tablePrimaryKeys.TryGetValue(currentTable, primaryKeyColumn) Then
                    Dim rowID = dgvInventory.Rows(e.RowIndex).Cells(primaryKeyColumn).Value
                    If rowID Is Nothing OrElse IsDBNull(rowID) Then
                        Throw New Exception("Primary key value is missing or invalid.")
                    End If
                    Dim query As String = $"UPDATE {currentTable} SET {columnName} = @newValue WHERE {primaryKeyColumn} = @rowID"
                    Using conn As New MySqlConnection(modDB.strConnection)
                        conn.Open()
                        Using cmd As New MySqlCommand(query, conn)
                            cmd.Parameters.AddWithValue("@newValue", newValue)
                            cmd.Parameters.AddWithValue("@rowID", rowID)
                            cmd.ExecuteNonQuery()
                            modDB.Logs($"Updated {columnName} in {currentTable} for ID {rowID}.")
                        End Using
                    End Using
                    modDB.Logs("Update Inventory Data")
                    MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Throw New Exception($"Primary key column not defined for table: {currentTable}")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show($"Error updating record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --- Chart Logic ---

    ' Donut chart: blood volume by blood type for selected month
    Private Sub LoadDonutChart()
        ChartDonut.Series.Clear()
        ChartDonut.ChartAreas.Clear()
        ChartDonut.Titles.Clear()
        ChartDonut.Legends.Clear()

        Dim area As New ChartArea("DonutArea")
        area.Area3DStyle.Enable3D = True
        area.Area3DStyle.Inclination = 30
        area.Area3DStyle.Rotation = 15
        ChartDonut.ChartAreas.Add(area)

        Dim series As New Series("BloodTypeVolume")
        series.ChartType = SeriesChartType.Doughnut
        series.IsValueShownAsLabel = True
        series.LabelForeColor = Color.Black
        series.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        ChartDonut.Series.Add(series)

        ChartDonut.Legends.Add(New Legend("Legend"))
        ChartDonut.Titles.Add("Blood Volume by Blood Type (" & dtpDonutMonth.Value.ToString("MMMM yyyy") & ")")

        Dim bloodTypes As String() = {"A-", "A+", "B-", "B+", "AB-", "AB+", "O-", "O+"}
        Dim bloodVolumes As New Dictionary(Of String, Double)
        For Each bt In bloodTypes
            bloodVolumes(bt) = 0
        Next

        Dim selectedMonth As Integer = dtpDonutMonth.Value.Month
        Dim selectedYear As Integer = dtpDonutMonth.Value.Year

        Dim query As String =
            "SELECT Blood_Group, RhesusFactor, SUM(BloodVolume) AS TotalVolume " &
            "FROM donation " &
            "WHERE MONTH(DonationDate) = @Month AND YEAR(DonationDate) = @Year " &
            "GROUP BY Blood_Group, RhesusFactor"

        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Month", selectedMonth)
                    cmd.Parameters.AddWithValue("@Year", selectedYear)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim groupPart As String = reader("Blood_Group").ToString()
                            Dim rhesusPart As String = reader("RhesusFactor").ToString()
                            Dim bt As String = groupPart & If(rhesusPart = "Rh+", "+", "-")
                            If bloodVolumes.ContainsKey(bt) Then
                                bloodVolumes(bt) = Convert.ToDouble(reader("TotalVolume"))
                            End If
                        End While
                    End Using
                End Using
                conn.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading donut chart: " & ex.Message)
        End Try

        Dim totalVolume As Double = bloodVolumes.Values.Sum()

        If totalVolume = 0 Then
            series.IsValueShownAsLabel = False
            For Each bt In bloodTypes
                Dim pointIndex = series.Points.AddXY(bt, 1)
                series.Points(pointIndex).Color = Color.LightGray
            Next
        Else
            Dim colors As New Dictionary(Of String, Color) From {
                {"A-", Color.Red},
                {"A+", Color.OrangeRed},
                {"B-", Color.Blue},
                {"B+", Color.LightBlue},
                {"AB-", Color.Purple},
                {"AB+", Color.MediumPurple},
                {"O-", Color.Green},
                {"O+", Color.YellowGreen}
            }
            For Each bt In bloodTypes
                Dim pointIndex = series.Points.AddXY(bt, bloodVolumes(bt))
                If colors.ContainsKey(bt) Then
                    series.Points(pointIndex).Color = colors(bt)
                End If
            Next
        End If
    End Sub

    ' Bar chart: donations by method for selected blood type and month
    Private Sub LoadBarChart(bloodType As String)
        ChartBar.Series.Clear()
        ChartBar.ChartAreas.Clear()
        ChartBar.Titles.Clear()
        ChartBar.Legends.Clear()

        ChartBar.BackColor = Color.White

        Dim area As New ChartArea("BarArea")
        area.BackColor = Color.White
        area.AxisX.Title = "Number of Donations"
        area.AxisY.Title = "Donation Method"
        area.AxisY.LabelStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        area.AxisX.LabelStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        area.AxisY.Interval = 1
        area.AxisX.MajorGrid.LineWidth = 0
        area.AxisY.MajorGrid.LineWidth = 0

        Dim donationMethods As New Dictionary(Of String, Integer) From {
            {"Whole Blood", 0},
            {"Plasma (A)", 0},
            {"Platelet (A)", 0},
            {"RBC (A)", 0},
            {"WBC (A)", 0}
        }

        Dim groupPart As String = ""
        Dim rhesusPart As String = ""
        ParseBloodType(bloodType, groupPart, rhesusPart)

        Dim selectedMonth As Integer = dtpDonutMonth.Value.Month
        Dim selectedYear As Integer = dtpDonutMonth.Value.Year

        Dim query As String =
            "SELECT DonationType, COUNT(*) AS DonationCount " &
            "FROM donation " &
            "WHERE Blood_Group = @Group AND RhesusFactor = @Rhesus " &
            "AND MONTH(DonationDate) = @Month AND YEAR(DonationDate) = @Year " &
            "GROUP BY DonationType ORDER BY DonationType"

        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Group", groupPart)
                    cmd.Parameters.AddWithValue("@Rhesus", rhesusPart)
                    cmd.Parameters.AddWithValue("@Month", selectedMonth)
                    cmd.Parameters.AddWithValue("@Year", selectedYear)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim methodFull As String = reader("DonationType").ToString()
                            Dim shortKey As String = Abbreviate(methodFull)
                            Dim count As Integer = Convert.ToInt32(reader("DonationCount"))
                            If donationMethods.ContainsKey(shortKey) Then
                                donationMethods(shortKey) = count
                            End If
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading bar chart: " & ex.Message)
        End Try

        ChartBar.ChartAreas.Add(area)

        Dim series As New Series("Donations per Method")
        series.ChartType = SeriesChartType.Bar
        series.IsValueShownAsLabel = True
        series.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        series.CustomProperties = "DrawingStyle=Cylinder"
        ChartBar.Series.Add(series)

        ChartBar.Legends.Add(New Legend("Legend"))
        ChartBar.Titles.Add("This Month's Donations by Method for " & bloodType)

        Dim colors As New Dictionary(Of String, Color) From {
            {"Whole Blood", Color.Green},
            {"Plasma (A)", Color.Yellow},
            {"Platelet (A)", Color.Orange},
            {"RBC (A)", Color.Red},
            {"WBC (A)", Color.White}
        }

        For Each kvp In donationMethods
            Dim pointIndex = series.Points.AddXY(kvp.Key, kvp.Value)
            series.Points(pointIndex).Color = colors(kvp.Key)
            series.Points(pointIndex).ToolTip = $"{kvp.Value} donation(s) of {FullName(kvp.Key)}"
            series.Points(pointIndex).Label = $"{kvp.Value} donation(s)"
        Next
    End Sub

    ' Helper to parse blood type (e.g., "O-" -> "O", "Rh-")
    Private Sub ParseBloodType(bloodType As String, ByRef groupPart As String, ByRef rhesusPart As String)
        groupPart = bloodType.Substring(0, bloodType.Length - 1)
        Dim sign = bloodType.Substring(bloodType.Length - 1)
        rhesusPart = If(sign = "+", "Rh+", "Rh-")
    End Sub

    Private Function Abbreviate(method As String) As String
        Select Case method
            Case "Whole Blood Donation" : Return "Whole Blood"
            Case "Plasma Donation (Apheresis)" : Return "Plasma (A)"
            Case "Platelet Donation(Apheresis)" : Return "Platelet (A)"
            Case "Red Blood Cell Donation(Apheresis)" : Return "RBC (A)"
            Case "White Blood Cell Donation(Apheresis)" : Return "WBC (A)"
            Case Else : Return method
        End Select
    End Function

    Private Function FullName(shortLabel As String) As String
        Select Case shortLabel
            Case "Whole Blood" : Return "Whole Blood Donation"
            Case "Plasma (A)" : Return "Plasma Donation (Apheresis)"
            Case "Platelet (A)" : Return "Platelet Donation (Apheresis)"
            Case "RBC (A)" : Return "Red Blood Cell Donation (Apheresis)"
            Case "WBC (A)" : Return "White Blood Cell Donation (Apheresis)"
            Case Else : Return shortLabel
        End Select
    End Function

    ' Navigation and config
    Private Sub Config_Click_1(sender As Object, e As EventArgs) Handles Config.Click
        OpenNewForm(Me, New SetConfig())
        modDB.Logs("Open Config")
    End Sub

    Private Sub New_Donor_Click(sender As Object, e As EventArgs) Handles New_Donor.Click
        OpenNewForm(Me, New User_Status())
        modDB.Logs("New Donor")
    End Sub

    Private Sub New_Donation_Click(sender As Object, e As EventArgs) Handles New_Donation.Click
        OpenNewForm(Me, New User_Status())
        modDB.Logs("New Donation")
    End Sub

    Private Sub back_Click(sender As Object, e As EventArgs) Handles back.Click
        Start.Show()
        Me.Hide()
    End Sub

    Private Sub ChartDonut_Click(sender As Object, e As EventArgs) Handles ChartDonut.Click

    End Sub
End Class
