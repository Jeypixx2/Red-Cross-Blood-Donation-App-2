Imports System.Windows.Forms.DataVisualization.Charting
Imports MySql.Data.MySqlClient
Public Class Admin_Dashboard
    ' Instance of SampleDataGenerator (for possible future use)
    Private sampleData As DataTable
    Private isDailyView As Boolean ' Flag to determine the current view
    Public Doublebuffer As New DoubleBuffering
    Dim chartConnection As New MySqlConnection("server=localhost;user id=root;password=;database=redcrossdb")

    ' Load event handler for the dashboard
    Private Sub Admin_Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If chartConnection.State = ConnectionState.Closed Then
                chartConnection.Open()
            End If

            LoadChart1()
            LoadChart2()

            ' Show data for the current date (default view)
            Doublebuffer.EnableDoubleBuffering(DataGridView1)
            ShowDataForDate(DateTime.Today)

        Catch ex As MySqlException
            MessageBox.Show($"Connection failed: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadChart1()
        Try
            Chart1.Series.Clear()
            Chart1.ChartAreas.Clear()

            Dim chartArea As New ChartArea("BloodTypesArea")
            Chart1.ChartAreas.Add(chartArea)

            Dim query As String = "SELECT bloodtype, COUNT(*) AS donors_count FROM donors GROUP BY bloodtype"
            Dim da As New MySqlDataAdapter(query, chartConnection)
            Dim ds As New DataSet
            da.Fill(ds, "Blood Type")

            If ds.Tables("Blood Type").Rows.Count = 0 Then
                MessageBox.Show("No data available for Chart1.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim series As New Series("Blood Type")
            series.ChartType = SeriesChartType.Bar
            series.XValueMember = "bloodtype"
            series.YValueMembers = "donors_count"
            series.IsValueShownAsLabel = True
            Chart1.DataSource = ds.Tables("Blood Type")
            Chart1.Series.Add(series)

           Catch ex As Exception
            MessageBox.Show($"Error loading Chart1: {ex.Message}", "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadChart2()
        Try
            Chart2.Series.Clear()
            Chart2.ChartAreas.Clear()
            Chart2.Legends.Clear()

            Dim chartArea As New ChartArea("DonationsArea")
            With chartArea
                .AxisX.Title = "Month"
                .AxisX.Interval = 1
                .AxisX.LabelStyle.Angle = 45
                .AxisY.Title = "Total Donations"
                .AxisY.MajorGrid.LineColor = Color.LightGray
            End With
            Chart2.ChartAreas.Add(chartArea)

            Dim query As String = "
                SELECT 
                    YEAR(DonationDate) AS DonationYear, 
                    MONTHNAME(DonationDate) AS DonationMonth, 
                    COUNT(*) AS TotalDonations
                FROM Donation
                GROUP BY YEAR(DonationDate), MONTH(DonationDate)
                ORDER BY YEAR(DonationDate), MONTH(DonationDate);"

            Dim da As New MySqlDataAdapter(query, chartConnection)
            Dim ds As New DataSet()
            da.Fill(ds, "Monthly Donations")

            If ds.Tables("Monthly Donations").Rows.Count = 0 Then
                MessageBox.Show("No data available for Chart2.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim series As New Series("Monthly Donations")
            With series
                .ChartType = SeriesChartType.Line
                .XValueMember = "DonationMonth"
                .YValueMembers = "TotalDonations"
                .IsValueShownAsLabel = True
                .LabelForeColor = Color.Black
                .BorderWidth = 2
                .Color = Color.DarkGreen
            End With
            Chart2.DataSource = ds.Tables("Monthly Donations")
            Chart2.Series.Add(series)

            Dim legend As New Legend("Monthly Donations Legend")
            legend.Docking = Docking.Top
            legend.Alignment = StringAlignment.Center
            Chart2.Legends.Add(legend)

        Catch ex As Exception
            MessageBox.Show($"Error loading Chart2: {ex.Message}", "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Admin_Dashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If chartConnection.State = ConnectionState.Open Then
            chartConnection.Close()
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

    ' Load data based on selected date from the MonthCalendar
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
        ' Use DATE() to extract only the date part (ignore time)
        Dim filteredData As DataTable = FilterData("SELECT * FROM Donors WHERE DATE(RegDate) = @param0", selectedDate)
        UpdateDataGridView(filteredData)
    End Sub

    ' Show data from the selected date to the upcoming Saturday (only date part, no time)
    Private Sub ShowDataForWeek(selectedDate As Date)
        Dim endOfWeek As Date = selectedDate.AddDays(DayOfWeek.Saturday - selectedDate.DayOfWeek)
        Dim filteredData As DataTable = FilterData("SELECT * FROM Donors WHERE DATE(RegDate) BETWEEN @param0 AND @param1", selectedDate, endOfWeek)
        UpdateDataGridView(filteredData)
    End Sub

    ' Show data for the selected month (only date part, no time)
    Private Sub ShowDataForMonth(selectedMonth As Integer)
        Dim filteredData As DataTable = FilterData("SELECT * FROM Donors WHERE MONTH(RegDate) = @param0", selectedMonth)
        UpdateDataGridView(filteredData)
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
                ' Add parameters to the SQL command
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

    ' Update DataGridView and handle no data found
    Private Sub UpdateDataGridView(filteredData As DataTable)
        DataGridView1.DataSource = filteredData

        If filteredData.Rows.Count = 0 Then
            MessageBox.Show("No data available for the selected date/week/month.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    ' Show the ComboBox for month selection
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Monthly.Click
        PopulateMonths()
        MonthCalendar1.Visible = False
        ComboBox1.Visible = True
    End Sub

    ' Load data for the selected month (only date part, no time)
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim selectedMonth As Integer = ComboBox1.SelectedIndex + 1
        ShowDataForMonth(selectedMonth)
        ComboBox1.Visible = False
    End Sub

    ' Button handlers for other actions (Inventory, Donor, User)
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Inventory.Click
        Admin_Inventory.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Donor.Click
        User_Status.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles User.Click
        User_Status.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Donor_Registration_Report.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Donation_History_Report.Show()
        Me.Hide()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Blood_Inventory_Report.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Ineligibility_Report.Show()
        Me.Hide()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Health_Provider_Report.Show()
        Me.Hide()
    End Sub

    Private Sub Chart2_Click(sender As Object, e As EventArgs) Handles Chart2.Click

    End Sub
End Class
