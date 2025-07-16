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
    Public Property AffiliatedInstitution As String
    Public Property ProviderName As String

    Public Sub ExitFormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Are you sure you want to Log out?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            modDB.Logs("Exit HealthCare Dashboard")
            Start.Show()
        Else
            e.Cancel = True ' Cancel the closing event
        End If
    End Sub

    Private Sub HealthCare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            modDB.openConn("redcrossdb")
            modDB.Logs("HealthCare Dashboard loaded")
            Doublebuffer.EnableDoubleBuffering(DataGridView1)
            ShowDataForDate(DateTime.Today)
            PopulateBloodTypes()
            ' Set DateTimePicker to show only month and year
            dtpDonutMonth.Format = DateTimePickerFormat.Custom
            dtpDonutMonth.CustomFormat = "MMMM yyyy"
            dtpDonutMonth.ShowUpDown = True
            LoadDonutChart()
            ' Optionally, set a default blood type for the bar chart
            If cmbBloodType IsNot Nothing AndAlso cmbBloodType.SelectedItem IsNot Nothing Then
                LoadBarChart(cmbBloodType.SelectedItem.ToString())
            End If
        Catch ex As MySqlException
            MessageBox.Show($"Connection failed: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            modDB.Logs($"Connection failed: {ex.Message}")
        End Try
        MonthCalendar1.Visible = False
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

    Private Sub PopulateBloodTypes()
        cmbBloodType.Items.Clear()
        Dim bloodTypes As String() = {"A-", "A+", "B-", "B+", "AB-", "AB+", "O-", "O+"}
        cmbBloodType.Items.AddRange(bloodTypes)
        If cmbBloodType.Items.Contains("O-") Then
            cmbBloodType.SelectedItem = "O-"
        ElseIf cmbBloodType.Items.Count > 0 Then
            cmbBloodType.SelectedIndex = 0
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
        modDB.Logs("Filter Monthly")
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
        DataGridView1.DataSource = filteredData
        ' Only show the message if the user has performed a filter action (not on initial load)
        If (MonthCalendar1.Visible = False AndAlso ComboBox1.Visible = False) AndAlso filteredData.Rows.Count = 0 Then
            MessageBox.Show("No data available for the selected date/week/month.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        modDB.Logs("Search Data")
    End Sub

    ' Filter data based on the search text
    Private Function FilterDataBySearch(query As String, searchText As String) As DataTable
        Dim table As New DataTable()
        Dim connection As MySqlConnection = modDB.conn

        Try
            ' Ensure the connection is open
            If connection.State = ConnectionState.Closed Then
                modDB.UpdateConnectionString() ' Ensure connection string is updated
                connection.Open()
            End If

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@searchText", "%" & searchText & "%")

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    table.Load(reader)
                End Using
            End Using

        Catch ex As MySqlException
            MessageBox.Show($"An error occurred: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            ' Ensure the connection is closed properly to prevent memory leaks
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try

        Return table
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

            ' Retrieve hospital and personnel information from database based on logged-in user
            Dim loggedInHospitalName As String = ""
            Dim loggedInPersonnelName As String = ""
            Dim loggedInUserID As Integer = 0 ' This should be set during login

            ' You need to store the logged-in user's HCPid somewhere accessible (like a module variable)
            ' For now, I'll assume you have a way to get the current user's ID
            loggedInUserID = GetCurrentLoggedInUserID() ' You need to implement this method

            If loggedInUserID > 0 Then
                Try
                    Using connection As New MySqlConnection(modDB.strConnection)
                        connection.Open()
                        Dim userQuery As String = "SELECT CONCAT(fname, ' ', IFNULL(mname, ''), ' ', lname) AS FullName, AffiliatedInstitutionName FROM healthprovideraccounts WHERE HCPid = @HCPid"
                        Using cmd As New MySqlCommand(userQuery, connection)
                            cmd.Parameters.AddWithValue("@HCPid", loggedInUserID)
                            Using reader As MySqlDataReader = cmd.ExecuteReader()
                                If reader.Read() Then
                                    loggedInPersonnelName = reader("FullName").ToString().Trim()
                                    loggedInHospitalName = reader("AffiliatedInstitutionName").ToString()
                                End If
                            End Using
                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error retrieving user information: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            Else
                MessageBox.Show("User not logged in or session expired.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Validate that we have the required information
            If String.IsNullOrWhiteSpace(loggedInHospitalName) Then
                MessageBox.Show("Hospital/Institution information not found for the logged-in user.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrWhiteSpace(loggedInPersonnelName) Then
                MessageBox.Show("Personnel information not found for the logged-in user.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Prompt user for additional details (excluding hospital and personnel info since we got them from DB)
            Dim purposeOfRetrieval As String = InputBox("Enter the Purpose of Retrieval:", "Purpose of Retrieval")
            Dim contactNo As String = InputBox("Enter the Contact Number:", "Contact Number")
            Dim emailAdd As String = InputBox("Enter the Email Address:", "Email Address")

            If PersonnelID = 0 Then
                PersonnelID = loggedInUserID ' Use the logged-in user's HCPid as PersonnelID
            End If

            ' Confirm retrieval with the user
            Dim confirmationMessage As String = $"You are about to retrieve the following data:" & vbCrLf &
                                    $"Blood ID: {bloodID}" & vbCrLf &
                                    $"Name: {lastName}, {firstName} {middleName}" & vbCrLf &
                                    $"Blood Type: {bloodType} {rhesusFactor}" & vbCrLf &
                                    $"Donation Type: {donationType}" & vbCrLf &
                                    $"Blood Volume: {bloodVolume}" & vbCrLf &
                                    $"Donation Date: {donationDate}" & vbCrLf &
                                    $"Hospital/Institution: {loggedInHospitalName}" & vbCrLf &
                                    $"Personnel: {loggedInPersonnelName}" & vbCrLf &
                                    $"Purpose of Retrieval: {purposeOfRetrieval}" & vbCrLf &
                                    $"Contact Number: {contactNo}" & vbCrLf &
                                    $"Email Address: {emailAdd}" & vbCrLf &
                                    "Do you want to continue?"

            Dim result As DialogResult = MessageBox.Show(confirmationMessage, "Confirm Retrieval", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                Try
                    Dim retrieveDate As Date = DateTime.Now

                    ' Insert data into HealthProvider table
                    Using connection As New MySqlConnection(modDB.strConnection)
                        connection.Open()
                        Using transaction As MySqlTransaction = connection.BeginTransaction()
                            Try
                                Dim insertQuery As String = "INSERT INTO HealthProvider (PersonnelID, CompanyHospitalName, PersonnelName, BloodID, LastName, FirstName, MiddleName, Blood_Group, RhesusFactor, DonationType, BloodVolume, RetrieveDate, PurposeOfRetrieval, ContactNo, EmailAdd) " &
                                                "VALUES (@PersonnelID, @HospitalName, @PersonnelName, @BloodID, @LastName, @FirstName, @MiddleName, @Blood_Group, @RhesusFactor, @DonationType, @BloodVolume, @RetrieveDate, @PurposeOfRetrieval, @ContactNo, @EmailAdd)"

                                Using cmd As New MySqlCommand(insertQuery, connection, transaction)
                                    cmd.Parameters.AddWithValue("@HospitalName", loggedInHospitalName) ' Use value from database
                                    cmd.Parameters.AddWithValue("@PersonnelID", PersonnelID)
                                    cmd.Parameters.AddWithValue("@PersonnelName", loggedInPersonnelName) ' Use value from database
                                    cmd.Parameters.AddWithValue("@BloodID", bloodID)
                                    cmd.Parameters.AddWithValue("@LastName", lastName)
                                    cmd.Parameters.AddWithValue("@FirstName", firstName)
                                    cmd.Parameters.AddWithValue("@MiddleName", middleName)
                                    cmd.Parameters.AddWithValue("@Blood_Group", bloodType)
                                    cmd.Parameters.AddWithValue("@RhesusFactor", rhesusFactor)
                                    cmd.Parameters.AddWithValue("@DonationType", donationType)
                                    cmd.Parameters.AddWithValue("@BloodVolume", bloodVolume)
                                    cmd.Parameters.AddWithValue("@RetrieveDate", retrieveDate)
                                    cmd.Parameters.AddWithValue("@PurposeOfRetrieval", purposeOfRetrieval)
                                    cmd.Parameters.AddWithValue("@ContactNo", contactNo)
                                    cmd.Parameters.AddWithValue("@EmailAdd", emailAdd)
                                    cmd.ExecuteNonQuery()
                                End Using



                                Dim deleteQuery As String = "DELETE FROM donation WHERE BloodID = @BloodID"
                                Using cmd As New MySqlCommand(deleteQuery, connection, transaction)
                                    cmd.Parameters.AddWithValue("@BloodID", bloodID)
                                    cmd.ExecuteNonQuery()
                                End Using

                                transaction.Commit()
                                MessageBox.Show("Data retrieved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                modDB.Logs("Data retrieved successfully by " & loggedInPersonnelName & " from " & loggedInHospitalName)
                            Catch ex As Exception
                                transaction.Rollback()
                                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                modDB.Logs("Error during data retrieval: " & ex.Message)
                            End Try
                        End Using
                    End Using

                    RefreshDataGridView()
                Catch ex As Exception
                    MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    modDB.Logs("Unexpected error during data retrieval: " & ex.Message)
                End Try
            End If
        Else
            MessageBox.Show("Please select a row to retrieve.")
        End If
    End Sub

    ' Get the current logged-in user's ID
    Private Function GetCurrentLoggedInUserID() As Integer
        If SessionManager.IsLoggedIn() Then
            Return SessionManager.GetCurrentUserID()
        Else
            Return 0 ' No user logged in
        End If
    End Function


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

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles back.Click
        Me.Hide()
        Start.Show()
    End Sub

    Private Sub back_Click_1(sender As Object, e As EventArgs) Handles back.Click
        Start.Show()
        Me.Hide()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Print.Show()
        Me.Hide()
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

    Private Sub dtpDonutMonth_ValueChanged(sender As Object, e As EventArgs) Handles dtpDonutMonth.ValueChanged
        LoadDonutChart()
        If cmbBloodType.SelectedItem IsNot Nothing Then
            LoadBarChart(cmbBloodType.SelectedItem.ToString())
        End If
    End Sub

    Private Sub cmbBloodType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBloodType.SelectedIndexChanged
        If cmbBloodType.SelectedItem IsNot Nothing Then
            LoadBarChart(cmbBloodType.SelectedItem.ToString())
        End If
    End Sub
End Class