Imports System.Windows.Forms.DataVisualization.Charting
Imports MySql.Data.MySqlClient
Public Class Admin_Dashboard
    ' Instance of SampleDataGenerator (for possible future use)
    Private sampleData As DataTable
    Private isDailyView As Boolean ' Flag to determine the current view
    Public Doublebuffer As New DoubleBuffering


    ' Load event handler for the dashboard
    Private Sub Admin_Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            modDB.openConn("redcrossdb")

            ' Set default date range (Last 30 days)
            dtpFrom.Value = DateTime.Today.AddDays(-30)
            dtpTo.Value = DateTime.Today

            ' Load charts with the default date range
            LoadChart1(dtpFrom.Value, dtpTo.Value)
            LoadChart2(dtpFrom.Value, dtpTo.Value)

            Doublebuffer.EnableDoubleBuffering(DataGridView1)
            ShowDataForDate(DateTime.Today)

        Catch ex As MySqlException
            MessageBox.Show($"Connection failed: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub LoadChart1(startDate As Date, endDate As Date)
        Try
            Bar_Graph.Series.Clear()
            Bar_Graph.ChartAreas.Clear()

            Dim chartArea As New ChartArea("BloodTypesArea")
            Bar_Graph.ChartAreas.Add(chartArea)

            ' Query to filter donors within the selected date range
            Dim query As String = "
            SELECT bloodtype, COUNT(*) AS donors_count 
            FROM donors 
            WHERE RegDate BETWEEN @startDate AND @endDate
            GROUP BY bloodtype"

            Dim ds As New DataSet()
            Dim da As New MySqlDataAdapter(query, modDB.conn)

            da.SelectCommand.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"))
            da.SelectCommand.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"))

            If modDB.conn.State = ConnectionState.Closed Then
                modDB.conn.Open()
            End If

            da.Fill(ds, "Blood Type")
            modDB.conn.Close()


            Dim series As New Series("Blood Type")
            series.ChartType = SeriesChartType.Bar
            series.XValueMember = "bloodtype"
            series.YValueMembers = "donors_count"
            series.IsValueShownAsLabel = True

            Bar_Graph.DataSource = ds.Tables("Blood Type")
            Bar_Graph.Series.Add(series)

        Catch ex As Exception
            MessageBox.Show($"Error loading Chart1: {ex.Message}", "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub LoadChart2(startDate As Date, endDate As Date)
        Try
            Line_Chart.Series.Clear()
            Line_Chart.ChartAreas.Clear()
            Line_Chart.Legends.Clear()

            Dim chartArea As New ChartArea("DonationsArea")
            chartArea.AxisX.Title = "Month"
            chartArea.AxisX.Interval = 1
            chartArea.AxisY.Title = "Total Donations"
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray
            Line_Chart.ChartAreas.Add(chartArea)

            ' Query to filter donation data based on date range
            Dim query As String = "
            SELECT 
                YEAR(DonationDate) AS DonationYear, 
                MONTHNAME(DonationDate) AS DonationMonth, 
                COUNT(*) AS TotalDonations
            FROM Donation
            WHERE DonationDate BETWEEN @startDate AND @endDate
            GROUP BY YEAR(DonationDate), MONTH(DonationDate)
            ORDER BY YEAR(DonationDate), MONTH(DonationDate);"

            Dim ds As New DataSet()
            Dim da As New MySqlDataAdapter(query, modDB.conn)

            da.SelectCommand.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"))
            da.SelectCommand.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"))

            If modDB.conn.State = ConnectionState.Closed Then
                modDB.conn.Open()
            End If

            da.Fill(ds, "Monthly Donations")
            modDB.conn.Close()



            Dim series As New Series("Monthly Donations")
            series.ChartType = SeriesChartType.Line
            series.XValueMember = "DonationMonth"
            series.YValueMembers = "TotalDonations"
            series.IsValueShownAsLabel = True
            series.Color = Color.DarkGreen

            Line_Chart.DataSource = ds.Tables("Monthly Donations")
            Line_Chart.Series.Add(series)

            Dim legend As New Legend("Monthly Donations Legend")
            legend.Docking = Docking.Top
            Line_Chart.Legends.Add(legend)

        Catch ex As Exception
            MessageBox.Show($"Error loading Chart2: {ex.Message}", "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




    Private Sub Admin_Dashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub
    ' Populate the ComboBox with month names
    Private Sub PopulateMonths()
        ComboBox1.Items.Clear()

        For month As Integer = 1 To 12
            ComboBox1.Items.Add(Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month))

        Next

        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 0
        End If
    End Sub

    ' Show MonthCalendar when Daily button is clicked
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Daily.Click
        MonthCalendar1.Visible = True
        ComboBox1.Visible = False
        isDailyView = True ' Set flag for Daily view
    End Sub

    ' Show MonthCalendar when Weekly button is clicked
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Weekly.Click
        MonthCalendar1.Visible = True
        ComboBox1.Visible = False
        isDailyView = False ' Set flag for Weekly view
    End Sub

    ' Filter data based on SQL query and parameters
    Private Function FilterData(query As String, ParamArray parameters As Object()) As DataTable
        Dim table As New DataTable()

        Try
            ' Ensure the connection is open
            If modDB.conn.State = ConnectionState.Closed Then
                modDB.UpdateConnectionString()
            End If

            ' Use the shared connection
            Using cmd As New MySqlCommand(query, modDB.conn)
                If modDB.conn.State = ConnectionState.Closed Then
                    modDB.conn.Open()
                End If

                ' Add parameters to the SQL command
                For i As Integer = 0 To parameters.Length - 1
                    cmd.Parameters.AddWithValue($"@param{i}", parameters(i))
                Next

                ' Execute the command
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
        ' Populate ComboBox with month names
        PopulateMonths()

        If MonthCalendar1.SelectionStart = DateTime.MinValue Then
            MessageBox.Show("Please select a valid date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim selectedDate As Date = MonthCalendar1.SelectionStart

        If isDailyView Then
            ShowDataForDate(selectedDate)  ' Show data only for the selected date
        Else
            ShowDataForWeek(selectedDate)   ' Show data for the selected week
        End If

        MonthCalendar1.Visible = False ' Hide calendar after selection
    End Sub

    ' Show data for the selected date (only date part, no time)
    Private Sub ShowDataForDate(selectedDate As Date)
        ' Create query to show data for the selected date (ignoring time)
        Dim query As String = "SELECT * FROM Donors WHERE DATE(RegDate) = @param0"

        ' Filter data using the function from modDB
        Dim parameters As Object() = {selectedDate.ToString("yyyy-MM-dd")}
        Dim filteredData As DataTable = FilterData(query, parameters)

        ' Update the DataGridView with the filtered data
        UpdateDataGridView(filteredData)
    End Sub

    Private Sub ShowDataForWeek(selectedDate As Date)
        ' Calculate the start and end of the week
        Dim startOfWeek As Date = selectedDate.AddDays(-CInt(selectedDate.DayOfWeek))
        Dim endOfWeek As Date = startOfWeek.AddDays(6)

        ' Create query to show data for the week
        Dim query As String = "SELECT * FROM Donors WHERE DATE(RegDate) BETWEEN @param0 AND @param1"

        ' Filter data using the function from modDB
        Dim parameters As Object() = {startOfWeek.ToString("yyyy-MM-dd"), endOfWeek.ToString("yyyy-MM-dd")}
        Dim filteredData As DataTable = FilterData(query, parameters)

        ' Update the DataGridView with the filtered data
        UpdateDataGridView(filteredData)
    End Sub

    Private Sub ShowDataForMonth(selectedMonth As Integer)
        ' Create query to show data for the selected month
        Dim query As String = "SELECT * FROM Donors WHERE MONTH(RegDate) = @param0"

        ' Filter data using the function from modDB
        Dim parameters As Object() = {selectedMonth}
        Dim filteredData As DataTable = FilterData(query, parameters)

        ' Update the DataGridView with the filtered data
        UpdateDataGridView(filteredData)
    End Sub


    ' Update DataGridView and handle no data found
    Private Sub UpdateDataGridView(filteredData As DataTable)
        DataGridView1.DataSource = filteredData

        If filteredData.Rows.Count = 0 Then
            MessageBox.Show("No data available for the selected date/week/month.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Monthly.Click
        PopulateMonths()
        MonthCalendar1.Visible = False
        ComboBox1.Visible = True
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim selectedMonth As Integer = ComboBox1.SelectedIndex + 1
        ShowDataForMonth(selectedMonth)
        ComboBox1.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Inventory.Click
        Admin_Inventory.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Donor.Click
        OpenNewForm(Me, New User_Status())
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles User.Click
        OpenNewForm(Me, New User_Status())
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


    Private Sub btnFilterCharts_Click(sender As Object, e As EventArgs) Handles btnFilterCharts.Click
        Dim startDate As Date = dtpFrom.Value
        Dim endDate As Date = dtpTo.Value

        If startDate > endDate Then
            MessageBox.Show("Start date cannot be later than end date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        LoadChart1(startDate, endDate)
        LoadChart2(startDate, endDate)
    End Sub

End Class
