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
        {"logs", "user_accounts_id"}, ' Assuming user_accounts_id is the primary key for logs
        {"accounts", "adminID"},
        {"healthprovideraccounts", "HCPid"}
    }

    Public Sub ExitFormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Are you sure you want to Log out?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            modDB.Logs("Exit SuperAdmin Dashboard")
            Start.Show()
        Else
            e.Cancel = True ' Cancel the closing event
        End If
    End Sub

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
                ' Only show the message box if a specific date was selected (not default or today)
                If SelectedDate <> Date.MinValue AndAlso SelectedDate.Date <> DateTime.Now.Date Then
                    MessageBox.Show("No records found for the selected date.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
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
        If rowCount = 0 Then MessageBox.Show("No health provider records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub History_Click(sender As Object, e As EventArgs) Handles History.Click
        UpdateConnectionString()
        DoubleBuffering.EnableDoubleBuffering(dgvInventory)
        currentTable = "history"
        dbDateColumn = "DonorRegDate"
        Calendar = 1
        Dim query As String = $"SELECT * FROM {currentTable}"
        Dim rowCount As Integer = modDB.LoadToDGV(query, dgvInventory)
        modDB.Logs("View History Data")
        If rowCount = 0 Then MessageBox.Show("No history records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Logs_Click(sender As Object, e As EventArgs) Handles Logs.Click
        UpdateConnectionString()
        DoubleBuffering.EnableDoubleBuffering(dgvInventory)
        currentTable = "logs"
        dbDateColumn = "dt"
        Calendar = 1
        Dim query As String = $"SELECT * FROM {currentTable}"
        Dim rowCount As Integer = modDB.LoadToDGV(query, dgvInventory)
        modDB.Logs("View Logs Data")
        If rowCount = 0 Then MessageBox.Show("No logs records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Accounts_Click(sender As Object, e As EventArgs) Handles Accounts.Click
        UpdateConnectionString()
        DoubleBuffering.EnableDoubleBuffering(dgvInventory)
        currentTable = "accounts"
        dbDateColumn = "dt_created"
        Calendar = 1
        Dim query As String = $"SELECT * FROM {currentTable}"
        Dim rowCount As Integer = modDB.LoadToDGV(query, dgvInventory)
        modDB.Logs("View Accounts Data")
        If rowCount = 0 Then MessageBox.Show("No accounts records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If rowCount = 0 Then MessageBox.Show("No health provider accounts found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private searchTimer As New Timer()

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        searchTimer.Stop()

        searchTimer.Interval = 500
        RemoveHandler searchTimer.Tick, AddressOf PerformSearch
        AddHandler searchTimer.Tick, AddressOf PerformSearch
        searchTimer.Start()
    End Sub

    Private Sub PerformSearch(sender As Object, e As EventArgs)
        searchTimer.Stop()

        Try
            Dim searchText As String = txtSearch.Text.Trim()

            If Not String.IsNullOrWhiteSpace(searchText) Then
                If searchText.Length < 2 Then
                    txtSearch.Tag = Nothing
                    Return
                End If

                If Not IsValidSearchInput(searchText) Then
                    Return
                End If

                Me.Cursor = Cursors.WaitCursor

                Dim results As DataTable = GlobalModel.Search(searchText, currentTable)

                If results IsNot Nothing AndAlso results.Rows.Count > 0 Then
                    GlobalModel.UpdateDataGridView(results, dgvInventory)
                    Me.Text = $"SuperAdmin Dashboard - {results.Rows.Count} results found"
                    txtSearch.Tag = Nothing
                Else
                    If Not Equals(txtSearch.Tag, "NoResultsShownFor_" & searchText.ToLower()) Then
                        MessageBox.Show($"No results found for '{searchText}'.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtSearch.Tag = "NoResultsShownFor_" & searchText.ToLower()
                    End If
                    dgvInventory.DataSource = New DataTable()
                End If
            Else
                ReloadCurrentTableData()
                txtSearch.Tag = Nothing
                Me.Text = "SuperAdmin Dashboard"
            End If

        Catch ex As Exception
            MessageBox.Show($"Search error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            modDB.Logs($"Search Error: {ex.Message}")
            ReloadCurrentTableData()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ReloadCurrentTableData()
        Try
            UpdateConnectionString()
            Dim query As String = $"SELECT * FROM {currentTable}"
            modDB.LoadToDGV(query, dgvInventory)
        Catch ex As Exception
            MessageBox.Show($"Error reloading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            modDB.Logs($"Reload Error: {ex.Message}")
        End Try
    End Sub

    Private Function IsValidSearchInput(searchText As String) As Boolean
        ' Check minimum length
        If searchText.Length < 2 Then
            Return False
        End If

        ' Check for potentially harmful SQL characters
        Dim dangerousChars As String() = {"'", """", ";", "--", "/*", "*/", "DROP", "DELETE", "UPDATE", "INSERT"}
        Dim upperSearch As String = searchText.ToUpper()

        For Each dangerousChar In dangerousChars
            If upperSearch.Contains(dangerousChar.ToUpper()) Then
                MessageBox.Show("Search contains invalid characters or keywords.", "Invalid Search", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        Next

        Return True
    End Function

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
        dgvInventory.AllowUserToDeleteRows = True ' This setting enables the built-in delete row functionality, often used with a "delete" key press.
    End Sub

    Private changedRows As New Dictionary(Of Integer, Boolean)

    Private Sub dgvInventory_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInventory.CellValueChanged
        Try
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                If dgvInventory.Rows(e.RowIndex).IsNewRow Then Exit Sub

                If Not changedRows.ContainsKey(e.RowIndex) Then
                    changedRows.Add(e.RowIndex, True)
                End If


                modDB.Logs($"Cell in row {e.RowIndex}, column {dgvInventory.Columns(e.ColumnIndex).Name} changed.")
            End If
        Catch ex As Exception
            modDB.Logs($"Error in CellValueChanged: {ex.Message}")
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
        ChartDonut.Titles.Add("Total Donation By Blood Type (" & dtpDonutMonth.Value.ToString("MMMM yyyy") & ")")

        Dim bloodTypes As String() = {"A-", "A+", "B-", "B+", "AB-", "AB+", "O-", "O+"}
        Dim bloodVolumes As New Dictionary(Of String, Double)
        For Each bt In bloodTypes
            bloodVolumes(bt) = 0
        Next

        Dim selectedMonth As Integer = dtpDonutMonth.Value.Month
        Dim selectedYear As Integer = dtpDonutMonth.Value.Year

        Dim query As String =
            "SELECT Blood_Group, RhesusFactor, COUNT(*) AS TotalDonations " &
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
                                bloodVolumes(bt) = Convert.ToDouble(reader("TotalDonations"))
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
                series.Points(pointIndex).ToolTip = "No donations for this blood type."
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
                Dim volume As Double = bloodVolumes(bt)
                series.Points(pointIndex).ToolTip = $"{volume:N0} donations collected for {bt}"
            Next
        End If
    End Sub

    ' Bar chart: blood volume by donation method for selected blood type
    Private Sub LoadBarChart(bloodType As String)
        ' Clear and setup chart
        ChartBar.Series.Clear()
        ChartBar.ChartAreas.Clear()
        ChartBar.Titles.Clear()
        ChartBar.Legends.Clear()
        ChartBar.BackColor = Color.White

        Dim area As New ChartArea("BarArea")
        area.BackColor = Color.White
        area.AxisX.Title = "Donation Method"
        area.AxisY.Title = "Blood Volume (mL)"
        area.AxisX.LabelStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        area.AxisY.LabelStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        area.AxisX.Interval = 1
        area.AxisY.MajorGrid.LineWidth = 0
        area.AxisX.MajorGrid.LineWidth = 0
        ChartBar.ChartAreas.Add(area)

        ' Initialize donation methods with 0 volume
        Dim donationVolumes As New Dictionary(Of String, Double) From {
            {"Whole Blood", 0},
            {"Plasma (A)", 0},
            {"Platelet (A)", 0},
            {"RBC (A)", 0},
            {"WBC (A)", 0}
        }

        ' Parse Blood Type
        Dim groupPart As String = ""
        Dim rhesusPart As String = ""
        ParseBloodType(bloodType, groupPart, rhesusPart)

        ' Selected date
        Dim selectedMonth As Integer = dtpDonutMonth.Value.Month
        Dim selectedYear As Integer = dtpDonutMonth.Value.Year

        ' Query to get blood volumes by donation type
        Dim query As String =
            "SELECT DonationType, SUM(BloodVolume) AS TotalVolume " &
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
                        Dim foundData As Boolean = False
                        While reader.Read()
                            foundData = True
                            Dim methodFull As String = reader("DonationType").ToString()
                            Dim volume As Double = 0
                            If Not IsDBNull(reader("TotalVolume")) Then
                                volume = Convert.ToDouble(reader("TotalVolume"))
                            End If
                            ' Map full method names to short labels if needed
                            Dim methodShort As String = Abbreviate(methodFull)
                            If donationVolumes.ContainsKey(methodShort) Then
                                donationVolumes(methodShort) += volume
                            End If
                        End While

                        If Not foundData Then
                            MessageBox.Show("No donation records found for this blood type and month.")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading bar chart: " & ex.Message)
            Exit Sub
        End Try

        ' Setup series
        Dim series As New Series("Total Volume (mL)")
        series.ChartType = SeriesChartType.Bar
        series.IsValueShownAsLabel = True
        series.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        series.LabelForeColor = Color.Black
        series.CustomProperties = "DrawingStyle=Cylinder, BarLabelStyle=Center"
        ChartBar.Series.Add(series)



        ChartBar.Legends.Add(New Legend("Legend"))
        ChartBar.Titles.Add("This Month's Blood Volume by Donation Type for " & bloodType)

        ' Define colors for each method
        Dim colors As New Dictionary(Of String, Color) From {
            {"Whole Blood", Color.Green},
            {"Plasma (A)", Color.Yellow},
            {"Platelet (A)", Color.Orange},
            {"RBC (A)", Color.Red},
            {"WBC (A)", Color.Blue}
        }

        ' Add chart points with volume label
        For Each kvp In donationVolumes
            Dim method As String = kvp.Key
            Dim volume As Double = kvp.Value
            Dim pointIndex = series.Points.AddXY(method, volume)

            If colors.ContainsKey(method) Then
                series.Points(pointIndex).Color = colors(method)
            End If

            ' Right-align label by padding on the left
            Dim labelText As String = volume.ToString("N0") & " mL"
            series.Points(pointIndex).Label = labelText.PadLeft(10 + labelText.Length)

            series.Points(pointIndex).ToolTip = $"{volume:N0} mL collected via {method}"
        Next
    End Sub

    ' Helper to parse blood type: e.g., "O-" → "O", "Rh-"
    Private Sub ParseBloodType(bloodType As String, ByRef groupPart As String, ByRef rhesusPart As String)
        groupPart = bloodType.Substring(0, bloodType.Length - 1)
        Dim sign = bloodType.Substring(bloodType.Length - 1)
        rhesusPart = If(sign = "+", "Rh+", "Rh-")
    End Sub


    Private Function Abbreviate(method As String) As String
        Select Case method
            Case "Whole Blood Donation" : Return "Whole Blood"
            Case "Plasma Donation (Apheresis)" : Return "Plasma (A)"
            Case "Platelet Donation (Apheresis)" : Return "Platelet (A)"
            Case "Red Blood Cell Donation (Apheresis)" : Return "RBC (A)"
            Case "White Blood Cell Donation (Apheresis)" : Return "WBC (A)"
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

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ' This method now handles updating all changed rows to the database.
        If changedRows.Count = 0 Then
            MessageBox.Show("No changes to update.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim updatesSuccessful As Integer = 0
        Dim updatesFailed As Integer = 0

        Using conn As New MySqlConnection(modDB.strConnection)
            Try
                conn.Open()
                Dim primaryKeyColumn As String = Nothing

                If Not tablePrimaryKeys.TryGetValue(currentTable, primaryKeyColumn) Then
                    Throw New Exception($"Primary key column not defined for table: {currentTable}")
                End If

                For Each rowIndex As Integer In changedRows.Keys
                    Dim row As DataGridViewRow = dgvInventory.Rows(rowIndex)

                    ' Skip new rows that haven't been committed or fully entered yet
                    If row.IsNewRow Then
                        Continue For
                    End If

                    Dim rowID As Object = row.Cells(primaryKeyColumn).Value
                    If rowID Is Nothing OrElse IsDBNull(rowID) Then
                        modDB.Logs($"Skipping row {rowIndex}: Primary key value is missing or invalid.")
                        updatesFailed += 1
                        Continue For
                    End If

                    ' Construct the UPDATE query dynamically for each changed cell in the row
                    Dim updateClauses As New List(Of String)
                    Dim cmd As New MySqlCommand("", conn) ' Command created once per row for parameters

                    For Each cell As DataGridViewCell In row.Cells
                        ' Only update cells that are part of a bound column and not the primary key itself
                        If cell.OwningColumn.DataPropertyName IsNot Nothing AndAlso
                       cell.OwningColumn.Name <> primaryKeyColumn Then

                            Dim originalValue As Object = If(cell.Value IsNot Nothing, cell.Value, DBNull.Value)
                            Dim columnName As String = cell.OwningColumn.Name

                            ' Check if the cell's value has actually changed from its original loaded state
                            ' This requires storing original values, which isn't in your current code.
                            ' For simplicity, this example updates all cells in a flagged row.
                            ' A more robust solution would involve tracking individual cell changes.

                            updateClauses.Add($"{columnName} = @{columnName}Value")
                            cmd.Parameters.AddWithValue($"@{columnName}Value", originalValue)
                        End If
                    Next

                    If updateClauses.Count > 0 Then
                        Dim query As String = $"UPDATE {currentTable} SET {String.Join(", ", updateClauses)} WHERE {primaryKeyColumn} = @rowID"
                        cmd.CommandText = query
                        cmd.Parameters.AddWithValue("@rowID", rowID)

                        Try
                            cmd.ExecuteNonQuery()
                            modDB.Logs($"Updated row in {currentTable} for ID {rowID}.")
                            updatesSuccessful += 1
                            ' Optionally, reset the row's background color if you changed it
                            ' row.DefaultCellStyle.BackColor = dgvInventory.DefaultCellStyle.BackColor
                        Catch ex As Exception
                            modDB.Logs($"Error updating row ID {rowID}: {ex.Message}")
                            updatesFailed += 1
                        End Try
                    Else
                        modDB.Logs($"No updatable columns found for row ID {rowID}.")
                    End If
                Next

                If updatesSuccessful > 0 Then
                    MessageBox.Show($"{updatesSuccessful} record(s) updated successfully! {updatesFailed} failed.", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf updatesFailed > 0 Then
                    MessageBox.Show($"All updates failed. Please check logs for details.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("No records were actually updated.", "No Updates", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                ' Clear the list of changed rows after attempting to save them
                changedRows.Clear()

            Catch ex As Exception
                MessageBox.Show($"Error during batch update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                modDB.Logs($"Error during batch update: {ex.Message}")
            Finally
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Try
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvInventory.SelectedRows.Count > 0 Then
            ' More specific confirmation message for donor deletion
            Dim confirmMessage As String = "Are you sure you want to delete the selected row(s)? This action cannot be undone."
            If currentTable = "donors" Then
                confirmMessage &= Environment.NewLine & Environment.NewLine & "WARNING: Deleting a donor will also delete all associated history, eligibility, and donation records for that donor."
            End If

            If MessageBox.Show(confirmMessage, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Try
                    Dim primaryKeyColumn As String = Nothing
                    If tablePrimaryKeys.TryGetValue(currentTable, primaryKeyColumn) Then
                        Using conn As New MySqlConnection(modDB.strConnection)
                            conn.Open()
                            Using transaction As MySqlTransaction = conn.BeginTransaction()
                                Try
                                    For Each row As DataGridViewRow In dgvInventory.SelectedRows
                                        If Not row.IsNewRow Then
                                            Dim rowID As Object = row.Cells(primaryKeyColumn).Value
                                            If rowID Is Nothing OrElse IsDBNull(rowID) Then
                                                MessageBox.Show("Cannot delete: Primary key value is missing for a selected row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                Continue For
                                            End If

                                            If currentTable = "donors" Then
                                                Dim donorIDToDelete As Integer = CType(rowID, Integer)

                                                ' Delete from 'history' table
                                                Dim deleteHistoryQuery As String = "DELETE FROM history WHERE DonorID = @DonorID"
                                                Using cmdHistory As New MySqlCommand(deleteHistoryQuery, conn, transaction)
                                                    cmdHistory.Parameters.AddWithValue("@DonorID", donorIDToDelete)
                                                    cmdHistory.ExecuteNonQuery()
                                                    modDB.Logs($"Deleted history records for DonorID {donorIDToDelete}.")
                                                End Using

                                                ' Delete from 'eligibility' table
                                                Dim deleteEligibilityQuery As String = "DELETE FROM eligibility WHERE DonorID = @DonorID"
                                                Using cmdEligibility As New MySqlCommand(deleteEligibilityQuery, conn, transaction)
                                                    cmdEligibility.Parameters.AddWithValue("@DonorID", donorIDToDelete)
                                                    cmdEligibility.ExecuteNonQuery()
                                                    modDB.Logs($"Deleted eligibility records for DonorID {donorIDToDelete}.")
                                                End Using

                                                ' Delete from 'donation' table
                                                Dim deleteDonationQuery As String = "DELETE FROM donation WHERE DonorID = @DonorID"
                                                Using cmdDonation As New MySqlCommand(deleteDonationQuery, conn, transaction)
                                                    cmdDonation.Parameters.AddWithValue("@DonorID", donorIDToDelete)
                                                    cmdDonation.ExecuteNonQuery()
                                                    modDB.Logs($"Deleted donation records for DonorID {donorIDToDelete}.")
                                                End Using
                                            ElseIf currentTable = "accounts" Then
                                                Dim adminIDToDelete As Integer = CType(rowID, Integer)
                                                Dim deleteLogsQuery As String = "DELETE FROM logs WHERE user_accounts_id = @AdminID"
                                                Using cmdLogs As New MySqlCommand(deleteLogsQuery, conn, transaction)
                                                    cmdLogs.Parameters.AddWithValue("@AdminID", adminIDToDelete)
                                                    cmdLogs.ExecuteNonQuery()
                                                    modDB.Logs($"Deleted logs records for adminID {adminIDToDelete}.")
                                                End Using
                                            ElseIf currentTable = "healthprovideraccounts" Then
                                                Dim hcpIDToDelete As Integer = CType(rowID, Integer)
                                                Dim deleteHPQuery As String = "DELETE FROM healthprovider WHERE HCPid = @HCPid" ' Assuming HCPid is the FK in healthprovider
                                                Using cmdHP As New MySqlCommand(deleteHPQuery, conn, transaction)
                                                    cmdHP.Parameters.AddWithValue("@HCPid", hcpIDToDelete)
                                                    cmdHP.ExecuteNonQuery()
                                                    modDB.Logs($"Deleted healthprovider records for HCPid {hcpIDToDelete}.")
                                                End Using
                                            End If
                                            Dim query As String = $"DELETE FROM {currentTable} WHERE {primaryKeyColumn} = @rowID"
                                            Using cmd As New MySqlCommand(query, conn, transaction)
                                                cmd.Parameters.AddWithValue("@rowID", rowID)
                                                cmd.ExecuteNonQuery()
                                                modDB.Logs($"Deleted record from {currentTable} with ID {rowID}.")
                                            End Using
                                        End If
                                    Next
                                    transaction.Commit()
                                    MessageBox.Show("Selected row(s) and related records deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Catch ex As Exception
                                    transaction.Rollback()
                                    Throw New Exception("Transaction failed. " & ex.Message, ex) ' Re-throw to be caught by outer catch
                                End Try
                            End Using
                        End Using

                        ReloadCurrentTableData()
                    Else
                        MessageBox.Show($"Deletion failed: Primary key column not defined for table: {currentTable}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show($"Error deleting record(s): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    modDB.Logs($"Deletion Error: {ex.Message}")
                End Try
            End If
        Else
            MessageBox.Show("Please select at least one row to delete.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class