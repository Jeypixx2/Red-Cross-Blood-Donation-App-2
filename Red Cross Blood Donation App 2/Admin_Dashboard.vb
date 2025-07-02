Imports System.Windows.Forms.DataVisualization.Charting
Imports MySql.Data.MySqlClient

Public Class Admin_Dashboard
    Private sampleData As DataTable
    Private isDailyView As Boolean
    Public Doublebuffer As New DoubleBuffering

    ' Chart integration variables
    Private bloodTypes As String() = {"A-", "A+", "B-", "B+", "AB-", "AB+", "O-", "O+"}

    Public Sub ExitFormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Are you sure you want to Log out?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            modDB.Logs("Exit Admin Dashboard")
            Start.Show()
        Else
            e.Cancel = True ' Cancel the closing event
        End If
    End Sub

    Private Sub Admin_Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnableEditingAndDeleting()
        Try
            modDB.openConn("redcrossdb")

            Doublebuffer.EnableDoubleBuffering(DataGridView1)
            ShowDataForDate(DateTime.Today)

            dtpDonutMonth.Format = DateTimePickerFormat.Custom
            dtpDonutMonth.CustomFormat = "MMMM yyyy"
            dtpDonutMonth.ShowUpDown = True
            dtpDonutMonth.Value = DateTime.Now

            ' Chart integration
            dtpDonutMonth.Value = DateTime.Today
            cmbBloodType.Items.Clear()
            cmbBloodType.Items.AddRange(bloodTypes)
            cmbBloodType.SelectedIndex = 0

            LoadDonutChart()
            LoadBarChart(bloodTypes(0))
        Catch ex As MySqlException
            MessageBox.Show($"Connection failed: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --- New Chart Logic ---

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
                conn.Close()
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

    ' --- End Chart Logic ---

    Private Sub Admin_Dashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

    Private Sub PopulateMonths()
        ComboBox1.Items.Clear()
        For month As Integer = 1 To 12
            ComboBox1.Items.Add(Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month))
        Next
        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 0
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Daily.Click
        MonthCalendar1.Visible = True
        ComboBox1.Visible = False
        isDailyView = True
        modDB.Logs("Filter Daily")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Weekly.Click
        MonthCalendar1.Visible = True
        ComboBox1.Visible = False
        isDailyView = False
        modDB.Logs("Filter Weekly")
    End Sub

    Private Function FilterData(query As String, ParamArray parameters As Object()) As DataTable
        Dim table As New DataTable()
        Try
            If modDB.conn.State = ConnectionState.Closed Then
                modDB.UpdateConnectionString()
            End If
            Using cmd As New MySqlCommand(query, modDB.conn)
                If modDB.conn.State = ConnectionState.Closed Then
                    modDB.conn.Open()
                End If
                For i As Integer = 0 To parameters.Length - 1
                    cmd.Parameters.AddWithValue($"@param{i}", parameters(i))
                Next
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    table.Load(reader)
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show($"An error occurred: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return table
    End Function

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        PopulateMonths()
        If MonthCalendar1.SelectionStart = DateTime.MinValue Then
            MessageBox.Show("Please select a valid date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim selectedDate As Date = MonthCalendar1.SelectionStart
        If isDailyView Then
            ShowDataForDate(selectedDate)
        Else
            ShowDataForWeek(selectedDate)
        End If
        MonthCalendar1.Visible = False
    End Sub

    Private Sub ShowDataForDate(selectedDate As Date)
        Dim query As String = "SELECT * FROM Donors WHERE DATE(RegDate) = @param0"
        Dim parameters As Object() = {selectedDate.ToString("yyyy-MM-dd")}
        Dim filteredData As DataTable = FilterData(query, parameters)
        UpdateDataGridView(filteredData)
    End Sub

    Private Sub ShowDataForWeek(selectedDate As Date)
        Dim startOfWeek As Date = selectedDate.AddDays(-CInt(selectedDate.DayOfWeek))
        Dim endOfWeek As Date = startOfWeek.AddDays(6)
        Dim query As String = "SELECT * FROM Donors WHERE DATE(RegDate) BETWEEN @param0 AND @param1"
        Dim parameters As Object() = {startOfWeek.ToString("yyyy-MM-dd"), endOfWeek.ToString("yyyy-MM-dd")}
        Dim filteredData As DataTable = FilterData(query, parameters)
        UpdateDataGridView(filteredData)
    End Sub

    Private Sub ShowDataForMonth(selectedMonth As Integer)
        Dim query As String = "SELECT * FROM Donors WHERE MONTH(RegDate) = @param0"
        Dim parameters As Object() = {selectedMonth}
        Dim filteredData As DataTable = FilterData(query, parameters)
        UpdateDataGridView(filteredData)
    End Sub

    Private Sub UpdateDataGridView(filteredData As DataTable)
        DataGridView1.DataSource = filteredData
        ' Only show the message if the user has performed a filter action (not on initial load)
        If (MonthCalendar1.Visible = False AndAlso ComboBox1.Visible = False) AndAlso filteredData.Rows.Count = 0 Then
            MessageBox.Show("No data available for the selected date/week/month.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Monthly.Click
        PopulateMonths()
        MonthCalendar1.Visible = False
        ComboBox1.Visible = True
        modDB.Logs("Filter Monthly")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim selectedMonth As Integer = ComboBox1.SelectedIndex + 1
        ShowDataForMonth(selectedMonth)
        ComboBox1.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Inventory.Click
        Admin_Inventory.Show()
        Me.Hide()
        modDB.Logs("Inventory")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Donor.Click
        OpenNewForm(Me, New User_Status())
        modDB.Logs("Donor")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles User.Click
        OpenNewForm(Me, New User_Status())
        modDB.Logs("Donation")
    End Sub

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
        modDB.Logs("ViewHealth Provider Report")
    End Sub

    Private Sub back_Click(sender As Object, e As EventArgs) Handles back.Click
        Start.Show()
        Me.Hide()
    End Sub

    Private Sub EnableEditingAndDeleting()
        DataGridView1.ReadOnly = False
        DataGridView1.AllowUserToDeleteRows = True
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub
        If DataGridView1.Rows(e.RowIndex).IsNewRow Then Exit Sub
        Try
            Dim newValue As Object = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            Dim columnName As String = DataGridView1.Columns(e.ColumnIndex).Name
            Dim primaryKeyColumn As String = "DonorID"
            Dim rowID As Object = DataGridView1.Rows(e.RowIndex).Cells(primaryKeyColumn).Value
            If rowID Is Nothing OrElse IsDBNull(rowID) Then
                MessageBox.Show("Primary key is missing. Cannot update record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If newValue Is Nothing OrElse IsDBNull(newValue) Then
                newValue = DBNull.Value
            End If
            If modDB.conn.State = ConnectionState.Open Then modDB.conn.Close()
            Dim query As String = $"UPDATE donors SET `{columnName}` = @newValue WHERE `{primaryKeyColumn}` = @rowID"
            Using cmd As New MySqlCommand(query, modDB.conn)
                cmd.Parameters.AddWithValue("@newValue", newValue)
                cmd.Parameters.AddWithValue("@rowID", rowID)
                modDB.conn.Open()
                cmd.ExecuteNonQuery()
                modDB.conn.Close()
            End Using
            modDB.Logs($"Updated `{columnName}` for DonorID {rowID} to {newValue}")
        Catch ex As Exception
            MessageBox.Show($"Error updating record: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            modDB.Logs($"Error updating record: {ex.Message}")
        Finally
            If modDB.conn.State = ConnectionState.Open Then modDB.conn.Close()
        End Try
    End Sub

    ' --- Chart UI Event Handlers ---

    Private Sub ComboBoxBloodType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBloodType.SelectedIndexChanged
        If cmbBloodType.SelectedIndex >= 0 Then
            LoadBarChart(cmbBloodType.SelectedItem.ToString())
        End If
    End Sub

    Private Sub dtpDonutMonth_ValueChanged(sender As Object, e As EventArgs) Handles dtpDonutMonth.ValueChanged
        LoadDonutChart()
        If cmbBloodType.SelectedIndex >= 0 Then
            LoadBarChart(cmbBloodType.SelectedItem.ToString())
        Else
            LoadBarChart(bloodTypes(0))
        End If
    End Sub

End Class