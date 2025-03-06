Imports System.Windows.Forms.DataVisualization.Charting
Imports MySql.Data.MySqlClient

Public Class HealthCare_Dashboard
    Private sampleData As DataTable
    Private isDailyView As Boolean ' Flag to determine the current view
    Public Doublebuffer As New DoubleBuffering
    Private WithEvents searchTimer As New Timer()
    Private hospitalName As String
    Private personnelName As String
    Private HealthProviderID As Integer ' To store the fixed HealthProviderID
    Private PersonnelID As Integer ' To store the fixed PersonnelID
    Dim chartConnection As New MySqlConnection("server=localhost;user id=root;password=;database=redcrossdb")

    ' Constructor to receive data from HealthCare_Access form
    Public Sub New(hospitalName As String, personnelName As String)
        InitializeComponent()
        Me.hospitalName = hospitalName
        Me.personnelName = personnelName
        ' Fetch IDs for the hospital and personnel
        FetchIDs()
    End Sub

    Private Sub HealthCare_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        MonthCalendar1.Visible = False
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
        If chartConnection.State = ConnectionState.Open Then
            chartConnection.Close()
        End If
    End Sub
    ' Load event handler for the dashboard
    Private Sub Admin_HealthCare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Doublebuffer.EnableDoubleBuffering(DataGridView1)
        ShowDataForDate(DateTime.Today) ' Initially show all data for today
        ' Set timer interval to 500 milliseconds
        searchTimer.Interval = 500
        ' Set the timer to stop automatically after each tick
        searchTimer.Stop()
    End Sub

    ' Populate ComboBox with month names
    Private Sub PopulateMonths()
        ComboBox1.Items.Clear()
        For month As Integer = 1 To 12
            ComboBox1.Items.Add(Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month))
        Next
        If ComboBox1.Items.Count > 0 Then ComboBox1.SelectedIndex = 0
    End Sub

    ' Show MonthCalendar when Daily button is clicked
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Daily.Click
        MonthCalendar1.Visible = True
        ComboBox1.Visible = False
        isDailyView = True
    End Sub

    ' Show MonthCalendar when Weekly button is clicked
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Weekly.Click
        MonthCalendar1.Visible = True
        ComboBox1.Visible = False
        isDailyView = False
    End Sub

    ' Load data based on selected date from the MonthCalendar
    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        PopulateMonths()
        If MonthCalendar1.SelectionStart = DateTime.MinValue Then
            MessageBox.Show("Please select a valid date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim selectedDate As Date = MonthCalendar1.SelectionStart
        Dim filteredData As DataTable
        If isDailyView Then
            filteredData = GetFilteredDataForDate(selectedDate)
        Else
            filteredData = GetFilteredDataForWeek(selectedDate)
        End If
        UpdateDataGridView(filteredData)
        MonthCalendar1.Visible = False
    End Sub

    ' Get filtered data for the selected date
    Private Function GetFilteredDataForDate(selectedDate As Date) As DataTable
        Dim query As String = "SELECT donation.BloodID, donation.DonationDate, donors.BloodType, donation.RhesusFactor, " &
                          "donation.DonationType, donation.BloodVolume, donation.CollectionMethod, donors.LastName, donors.MiddleName, donors.FirstName, " &
                          "donors.Baranggay, donors.City, donors.Province, donors.Sex, donors.Age " &
                          "FROM donation " &
                          "JOIN donors ON donation.DonorID = donors.DonorID " &
                          "WHERE DATE(donation.DonationDate) = @param0"
        Return FilterData(query, selectedDate)
    End Function

    ' Get filtered data for the selected week
    Private Function GetFilteredDataForWeek(selectedDate As Date) As DataTable
        Dim endOfWeek As Date = selectedDate.AddDays(DayOfWeek.Saturday - selectedDate.DayOfWeek)
        Dim query As String = "SELECT donation.BloodID, donation.DonationDate, donors.BloodType, donation.RhesusFactor, " &
                          "donation.DonationType, donation.BloodVolume, donation.CollectionMethod, donors.LastName, donors.MiddleName, donors.FirstName, " &
                          "donors.Baranggay, donors.City, donors.Province, donors.Sex, donors.Age " &
                          "FROM donation " &
                          "JOIN donors ON donation.DonorID = donors.DonorID " &
                          "WHERE DATE(donation.DonationDate) BETWEEN @param0 AND @param1"
        Return FilterData(query, selectedDate, endOfWeek)
    End Function

    ' Show data for the selected month
    Private Sub ShowDataForMonth(selectedMonth As Integer)
        Dim query As String = "SELECT donation.BloodID, donation.DonationDate, donors.BloodType, donation.RhesusFactor, " &
                          "donation.DonationType, donation.BloodVolume, donation.CollectionMethod, donors.LastName, donors.MiddleName, donors.FirstName, " &
                          "donors.Baranggay, donors.City, donors.Province, donors.Sex, donors.Age " &
                          "FROM donation " &
                          "JOIN donors ON donation.DonorID = donors.DonorID " &
                          "WHERE MONTH(donation.DonationDate) = @param0"
        Dim filteredData As DataTable = FilterData(query, selectedMonth)
        UpdateDataGridView(filteredData)
    End Sub

    ' Show data for the selected date
    Private Sub ShowDataForDate(selectedDate As Date)
        Dim filteredData As DataTable = GetFilteredDataForDate(selectedDate)
        UpdateDataGridView(filteredData)
    End Sub

    ' Filter data based on SQL query and parameters
    Private Function FilterData(query As String, ParamArray parameters As Object()) As DataTable
        Dim table As New DataTable()
        Dim connection As MySqlConnection = modDB.conn
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

    ' Update DataGridView with filtered data (date filter + search filter)
    Private Sub UpdateDataGridView(filteredData As DataTable, Optional searchText As String = "")
        ' If filtered data is null or empty, return early
        If filteredData.Rows.Count = 0 Then
            MessageBox.Show("No data available for the selected date/week/month or matching the search criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' If searchText is provided, apply the search filter
        If Not String.IsNullOrEmpty(searchText) Then
            filteredData = FilterDataBySearch("SELECT donation.BloodID, donation.DonationDate, donors.BloodType, donation.RhesusFactor, " &
                                            "donation.DonationType, donation.BloodVolume, donation.CollectionMethod, donors.LastName, " &
                                            "donors.FirstName, donors.MiddleName, donors.Baranggay, donors.City, donors.Province, " &
                                            "donors.Sex, donors.Age " &
                                            "FROM donation " &
                                            "JOIN donors ON donation.DonorID = donors.DonorID " &
                                            "WHERE (donors.LastName LIKE @searchText OR donors.MiddleName LIKE @searchText OR " &
                                            "donors.FirstName LIKE @searchText OR donors.Baranggay LIKE @searchText OR " &
                                            "donors.City LIKE @searchText OR donors.Province LIKE @searchText OR " &
                                            "donors.Sex LIKE @searchText OR donors.Age LIKE @searchText OR " &
                                            "donation.BloodID LIKE @searchText OR donation.DonationDate LIKE @searchText OR " &
                                            "donors.BloodType LIKE @searchText OR donation.RhesusFactor LIKE @searchText OR " &
                                            "donation.DonationType LIKE @searchText OR donation.BloodVolume LIKE @searchText OR " &
                                            "donation.CollectionMethod LIKE @searchText)", searchText)

        End If

        ' Create a new BindingSource if needed
        Dim bindingSource As New BindingSource()
        bindingSource.DataSource = filteredData

        ' Set the DataSource of the DataGridView to the BindingSource
        DataGridView1.DataSource = bindingSource
    End Sub

    ' Show the ComboBox for month selection
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Monthly.Click
        PopulateMonths()
        MonthCalendar1.Visible = False
        ComboBox1.Visible = True
    End Sub

    ' Load data for the selected month
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim selectedMonth As Integer = ComboBox1.SelectedIndex + 1
        ShowDataForMonth(selectedMonth)
        ComboBox1.Visible = False
    End Sub

    ' Search text changed event handler (independent of date)
    Private Sub SearchTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchTextBox.TextChanged
        ' Stop the timer each time the text changes, to reset the interval
        searchTimer.Stop()

        ' Restart the timer
        searchTimer.Start()
    End Sub

    Private Sub searchTimer_Tick(sender As Object, e As EventArgs) Handles searchTimer.Tick
        searchTimer.Stop()
        Dim searchText As String = SearchTextBox.Text.Trim()
        Dim selectedDate As Date = MonthCalendar1.SelectionStart
        Dim filteredData As DataTable

        ' Apply search-based filtering with the selected date filter
        If Not String.IsNullOrEmpty(searchText) Then
            Dim searchQuery As String = "SELECT donation.BloodID, donation.DonationDate, donors.BloodType, donation.RhesusFactor, " &
                                            "donation.DonationType, donation.BloodVolume, donation.CollectionMethod, donors.LastName, " &
                                            "donors.FirstName, donors.MiddleName, donors.Baranggay, donors.City, donors.Province, " &
                                            "donors.Sex, donors.Age " &
                                            "FROM donation " &
                                            "JOIN donors ON donation.DonorID = donors.DonorID " &
                                            "WHERE (donors.LastName LIKE @searchText OR donors.MiddleName LIKE @searchText OR " &
                                            "donors.FirstName LIKE @searchText OR donors.Baranggay LIKE @searchText OR " &
                                            "donors.City LIKE @searchText OR donors.Province LIKE @searchText OR " &
                                            "donors.Sex LIKE @searchText OR donors.Age LIKE @searchText OR " &
                                            "donation.BloodID LIKE @searchText OR donation.DonationDate LIKE @searchText OR " &
                                            "donors.BloodType LIKE @searchText OR donation.RhesusFactor LIKE @searchText OR " &
                                            "donation.DonationType LIKE @searchText OR donation.BloodVolume LIKE @searchText OR " &
                                            "donation.CollectionMethod LIKE @searchText)"
            filteredData = FilterDataBySearch(searchQuery, searchText)
        Else
            ' If no search text, apply date-based filtering
            If isDailyView Then
                filteredData = GetFilteredDataForDate(selectedDate)
            Else
                filteredData = GetFilteredDataForWeek(selectedDate)
            End If
        End If

        ' Update DataGridView with the filtered data
        UpdateDataGridView(filteredData)
    End Sub

    ' Filter data based on the search text
    Private Function FilterDataBySearch(query As String, searchText As String) As DataTable
        Dim table As New DataTable()
        Dim connection As MySqlConnection = modDB.conn
        Try
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@searchText", "%" & searchText & "%")
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    table.Load(reader)
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show($"An error occurred: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return table
    End Function


    Private Sub FetchIDs()
        Dim connection As MySqlConnection = modDB.conn
        Try
            ' Fetch HealthProviderID based on hospitalName
            Dim healthProviderQuery As String = "SELECT HealthProviderID FROM healthprovider WHERE CompanyHospitalName = @hospitalName"
            Using cmd As New MySqlCommand(healthProviderQuery, connection)
                cmd.Parameters.AddWithValue("@hospitalName", hospitalName)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    HealthProviderID = Convert.ToInt32(result)
                Else
                    ' If not found, generate a unique ID
                    HealthProviderID = GenerateUniqueID()
                End If
            End Using

            ' Fetch PersonnelID based on personnelName
            Dim personnelQuery As String = "SELECT PersonnelID FROM healthprovider WHERE PersonnelName = @personnelName"
            Using cmd As New MySqlCommand(personnelQuery, connection)
                cmd.Parameters.AddWithValue("@personnelName", personnelName)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    PersonnelID = Convert.ToInt32(result)
                Else
                    ' If not found, generate a unique ID
                    PersonnelID = GenerateUniqueID()
                End If
            End Using
        Catch ex As MySqlException
            MessageBox.Show($"An error occurred: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GenerateUniqueID() As Integer
        ' Get the current time in milliseconds
        Dim currentTimeMilliseconds As Long = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond

        ' Generate a random number between 1000 and 9999
        Dim random As New Random()
        Dim randomNumber As Integer = random.Next(1000, 9999)

        ' Combine the current time in milliseconds and the random number to form a unique ID
        Dim uniqueID As String = currentTimeMilliseconds.ToString() & randomNumber.ToString()

        ' Return the first 8 digits of the combined ID to ensure it's manageable as an Integer
        ' If you want a longer ID, you can adjust the length or change the data type
        Return Convert.ToInt32(uniqueID.Substring(0, 8))
    End Function



    Private Sub Retrieve_Data_Click(sender As Object, e As EventArgs) Handles Retrieve_Data.Click
        ' Check if a row is selected
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            ' Retrieve data from the selected row
            Dim bloodID As Integer = selectedRow.Cells("BloodID").Value
            Dim lastName As String = selectedRow.Cells("LastName").Value.ToString()
            Dim firstName As String = selectedRow.Cells("FirstName").Value.ToString()
            Dim middleName As String = selectedRow.Cells("MiddleName").Value.ToString()
            Dim bloodType As String = selectedRow.Cells("BloodType").Value.ToString()
            Dim rhesusFactor As String = selectedRow.Cells("RhesusFactor").Value.ToString()
            Dim donationDate As String = selectedRow.Cells("DonationDate").Value.ToString()
            Dim donationType As String = selectedRow.Cells("DonationType").Value.ToString()
            Dim bloodVolume As String = selectedRow.Cells("BloodVolume").Value.ToString()

            ' Fetch HealthProviderID and PersonnelID based on HospitalName and PersonnelName
            FetchIDs()

            ' If no valid IDs found, generate new ones
            If HealthProviderID = 0 Then
                HealthProviderID = GenerateUniqueID()
            End If
            If PersonnelID = 0 Then
                PersonnelID = GenerateUniqueID()
            End If

            ' Use the new IDs
            Dim RetrieveID As Integer = HealthProviderID
            HealthProviderID = RetrieveID
            PersonnelID = RetrieveID

            ' Prompt user for additional details
            Dim purposeOfRetrieval As String = InputBox("Enter the Purpose of Retrieval:", "Purpose of Retrieval")
            Dim contactNo As String = InputBox("Enter the Contact Number:", "Contact Number")
            Dim emailAdd As String = InputBox("Enter the Email Address:", "Email Address")

            ' Confirm retrieval with the user
            Dim confirmationMessage As String = $"You are about to retrieve the following data:" & vbCrLf &
                                            $"Blood ID: {bloodID}" & vbCrLf &
                                            $"Name: {lastName}, {firstName} {middleName}" & vbCrLf &
                                            $"Blood Type: {bloodType} {rhesusFactor}" & vbCrLf &
                                            $"Donation Type: {donationType}" & vbCrLf &
                                            $"Blood Volume: {bloodVolume}" & vbCrLf &
                                            $"Donation Date: {donationDate}" & vbCrLf &
                                            $"Purpose of Retrieval: {purposeOfRetrieval}" & vbCrLf &
                                            $"Contact Number: {contactNo}" & vbCrLf &
                                            $"Email Address: {emailAdd}" & vbCrLf &
                                            "Do you want to continue?"

            Dim result As DialogResult = MessageBox.Show(confirmationMessage, "Confirm Retrieval", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                Try
                    Dim retrieveDate As Date = DateTime.Now

                    ' Insert data into HealthProvider table
                    Using connection As New MySqlConnection(strConnection)
                        connection.Open()
                        Using transaction As MySqlTransaction = connection.BeginTransaction()
                            Try
                                Dim insertQuery As String = "INSERT INTO HealthProvider (HealthProviderID, CompanyHospitalName, PersonnelID, PersonnelName, BloodID, LastName, FirstName, MiddleName, BloodType, RhesusFactor, DonationType, BloodVolume, RetrieveDate, PurposeOfRetrieval, ContactNo, EmailAdd) " &
                                                        "VALUES (@HealthProviderID, @HospitalName, @PersonnelID, @PersonnelName, @BloodID, @LastName, @FirstName, @MiddleName, @BloodType, @RhesusFactor, @DonationType, @BloodVolume, @RetrieveDate, @PurposeOfRetrieval, @ContactNo, @EmailAdd)"

                                Using cmd As New MySqlCommand(insertQuery, connection, transaction)
                                    cmd.Parameters.AddWithValue("@HealthProviderID", HealthProviderID)
                                    cmd.Parameters.AddWithValue("@HospitalName", hospitalName) ' Assuming hospitalName is a variable defined elsewhere
                                    cmd.Parameters.AddWithValue("@PersonnelID", PersonnelID)
                                    cmd.Parameters.AddWithValue("@PersonnelName", personnelName) ' Assuming personnelName is defined elsewhere
                                    cmd.Parameters.AddWithValue("@BloodID", bloodID)
                                    cmd.Parameters.AddWithValue("@LastName", lastName)
                                    cmd.Parameters.AddWithValue("@FirstName", firstName)
                                    cmd.Parameters.AddWithValue("@MiddleName", middleName)
                                    cmd.Parameters.AddWithValue("@BloodType", bloodType)
                                    cmd.Parameters.AddWithValue("@RhesusFactor", rhesusFactor)
                                    cmd.Parameters.AddWithValue("@DonationType", donationType)
                                    cmd.Parameters.AddWithValue("@BloodVolume", bloodVolume)
                                    cmd.Parameters.AddWithValue("@RetrieveDate", retrieveDate)
                                    cmd.Parameters.AddWithValue("@PurposeOfRetrieval", purposeOfRetrieval)
                                    cmd.Parameters.AddWithValue("@ContactNo", contactNo)
                                    cmd.Parameters.AddWithValue("@EmailAdd", emailAdd)
                                    cmd.ExecuteNonQuery()
                                End Using

                                ' Delete the selected row from the donation table
                                Dim deleteQuery As String = "DELETE FROM donation WHERE BloodID = @BloodID"
                                Using cmd As New MySqlCommand(deleteQuery, connection, transaction)
                                    cmd.Parameters.AddWithValue("@BloodID", bloodID)
                                    cmd.ExecuteNonQuery()
                                End Using

                                transaction.Commit()
                                MessageBox.Show("Data retrieved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Catch ex As Exception
                                transaction.Rollback()
                                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try
                        End Using
                    End Using

                    RefreshDataGridView()
                Catch ex As Exception
                    MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Please select a row to retrieve.")
        End If
    End Sub


    Private Sub RefreshDataGridView()
        ' Refresh data in the DataGridView
        Dim query As String = "SELECT d.BloodID, d.DonationDate, p.BloodType, d.RhesusFactor, " &
                              "d.DonationType, d.BloodVolume, d.CollectionMethod, p.LastName, p.FirstName, p.MiddleName, p.Baranggay, p.City, p.Province, p.Age, p.Sex " &
                              "FROM donation d JOIN donors p ON d.DonorID = p.DonorID"

        Dim dt As New DataTable()

        Try
            Using connection As New MySqlConnection(strConnection)
                connection.Open()
                Using cmd As New MySqlCommand(query, connection)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            DataGridView1.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error refreshing data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Me.Hide()
        Start.Show()
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

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