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

    ' Constructor to receive data from HealthCare_Access form
    Public Sub New(hospitalName As String, personnelName As String)
        InitializeComponent()
        Me.hospitalName = hospitalName
        Me.personnelName = personnelName
        ' Fetch IDs for the hospital and personnel
        FetchIDs()
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
        Dim query As String = "SELECT donation.BloodID, donation.DonationDate, donation.BloodType, donation.RhesusFactor, " &
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
        Dim query As String = "SELECT donation.BloodID, donation.DonationDate, donation.BloodType, donation.RhesusFactor, " &
                          "donation.DonationType, donation.BloodVolume, donation.CollectionMethod, donors.LastName, donors.MiddleName, donors.FirstName, " &
                          "donors.Baranggay, donors.City, donors.Province, donors.Sex, donors.Age " &
                          "FROM donation " &
                          "JOIN donors ON donation.DonorID = donors.DonorID " &
                          "WHERE DATE(donation.DonationDate) BETWEEN @param0 AND @param1"
        Return FilterData(query, selectedDate, endOfWeek)
    End Function

    ' Show data for the selected month
    Private Sub ShowDataForMonth(selectedMonth As Integer)
        Dim query As String = "SELECT donation.BloodID, donation.DonationDate, donation.BloodType, donation.RhesusFactor, " &
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
            Using cmd As New MySqlCommand(query, connection)
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

    ' Update DataGridView with filtered data (date filter + search filter)
    Private Sub UpdateDataGridView(filteredData As DataTable, Optional searchText As String = "")
        ' If filtered data is null or empty, return early
        If filteredData.Rows.Count = 0 Then
            MessageBox.Show("No data available for the selected date/week/month or matching the search criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' If searchText is provided, apply the search filter
        If Not String.IsNullOrEmpty(searchText) Then
            filteredData = FilterDataBySearch("SELECT donation.BloodID, donation.DonationDate, donation.BloodType, donation.RhesusFactor, " &
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
                                            "donation.BloodType LIKE @searchText OR donation.RhesusFactor LIKE @searchText OR " &
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
            Dim searchQuery As String = "SELECT donation.BloodID, donation.DonationDate, donation.BloodType, donation.RhesusFactor, " &
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
                                            "donation.BloodType LIKE @searchText OR donation.RhesusFactor LIKE @searchText OR " &
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
                HealthProviderID = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

            ' Fetch PersonnelID based on personnelName
            Dim personnelQuery As String = "SELECT PersonnelID FROM healthprovider WHERE PersonnelName = @personnelName"
            Using cmd As New MySqlCommand(personnelQuery, connection)
                cmd.Parameters.AddWithValue("@personnelName", personnelName)
                PersonnelID = Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        Catch ex As MySqlException
            MessageBox.Show($"An error occurred: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Retrieve data when the button is clicked
    Private Sub Retrieve_Data_Click(sender As Object, e As EventArgs) Handles Retrieve_Data.Click
        ' Check if a row is selected
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Get the selected row
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            ' Retrieve the necessary data from the selected row in DataGridView
            Dim bloodID As Integer = selectedRow.Cells("BloodID").Value
            Dim lastName As String = selectedRow.Cells("LastName").Value.ToString()
            Dim firstName As String = selectedRow.Cells("FirstName").Value.ToString()
            Dim middleName As String = selectedRow.Cells("MiddleName").Value.ToString()
            Dim bloodType As String = selectedRow.Cells("BloodType").Value.ToString()
            Dim rhesusFactor As String = selectedRow.Cells("RhesusFactor").Value.ToString()
            Dim donationDate As String = selectedRow.Cells("DonationDate").Value.ToString()
            Dim donationType As String = selectedRow.Cells("DonationType").Value.ToString()
            Dim bloodVolume As String = selectedRow.Cells("BloodVolume").Value.ToString()

            ' Create a confirmation message displaying the data
            Dim confirmationMessage As String = $"You are about to retrieve the following data:" & vbCrLf &
                                            $"Blood ID: {bloodID}" & vbCrLf &
                                            $"Name: {lastName}, {firstName} {middleName}" & vbCrLf &
                                            $"Blood Type: {bloodType} {rhesusFactor}" & vbCrLf &
                                            $"Donation Type: {donationType}" & vbCrLf &
                                            $"Blood Volume: {bloodVolume}" & vbCrLf &
                                            $"Donation Date: {donationDate}" & vbCrLf &
                                            "Do you want to continue?"

            ' Display the confirmation dialog
            Dim result As DialogResult = MessageBox.Show(confirmationMessage, "Confirm Retrieval", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            ' If the user confirms, proceed with the retrieval
            If result = DialogResult.Yes Then
                Try
                    ' Set RetrieveDate to the current date and time
                    Dim retrieveDate As Date = DateTime.Now

                    ' Get or auto-increment HealthProviderID and PersonnelID
                    Dim ids = HealthCare_Access.GetHealthProviderAndPersonnelID(hospitalName, personnelName)
                    Dim healthProviderID As Integer = ids.Item1
                    Dim personnelID As Integer = ids.Item2

                    Dim connection As MySqlConnection = modDB.conn

                    ' Start a transaction to ensure both insert and delete are atomic
                    Using transaction As MySqlTransaction = conn.BeginTransaction()
                        Try
                            ' SQL command to insert the data into the HealthProvider table
                            Dim insertQuery As String = "INSERT INTO HealthProvider (HealthProviderID, CompanyHospitalName, PersonnelID, PersonnelName, BloodID, LastName, FirstName, MiddleName, BloodType, RhesusFactor, DonationType, BloodVolume, RetrieveDate) " &
                                                        "VALUES (@HealthProviderID, @HospitalName, @PersonnelID, @PersonnelName, @BloodID, @LastName, @FirstName, @MiddleName, @BloodType, @RhesusFactor, @DonationType, @BloodVolume, @RetrieveDate)"

                            Using cmd As New MySqlCommand(insertQuery, conn, transaction)
                                cmd.Parameters.AddWithValue("@HealthProviderID", healthProviderID)
                                cmd.Parameters.AddWithValue("@HospitalName", hospitalName)
                                cmd.Parameters.AddWithValue("@PersonnelID", personnelID)
                                cmd.Parameters.AddWithValue("@PersonnelName", personnelName)
                                cmd.Parameters.AddWithValue("@BloodID", bloodID)
                                cmd.Parameters.AddWithValue("@LastName", lastName)
                                cmd.Parameters.AddWithValue("@FirstName", firstName)
                                cmd.Parameters.AddWithValue("@MiddleName", middleName)
                                cmd.Parameters.AddWithValue("@BloodType", bloodType)
                                cmd.Parameters.AddWithValue("@RhesusFactor", rhesusFactor)
                                cmd.Parameters.AddWithValue("@DonationType", donationType)
                                cmd.Parameters.AddWithValue("@BloodVolume", bloodVolume)
                                cmd.Parameters.AddWithValue("@RetrieveDate", retrieveDate)

                                ' Execute the insert command
                                cmd.ExecuteNonQuery()
                            End Using

                            ' SQL command to delete the selected row from the donation table
                            Dim deleteQuery As String = "DELETE FROM donation WHERE BloodID = @BloodID"
                            Using cmd As New MySqlCommand(deleteQuery, conn, transaction)
                                cmd.Parameters.AddWithValue("@BloodID", bloodID)

                                ' Execute the delete command
                                cmd.ExecuteNonQuery()
                            End Using

                            ' Commit the transaction if both operations are successful
                            transaction.Commit()

                            ' Refresh the DataGridView to reflect the changes
                            RefreshDataGridView()

                        Catch ex As Exception
                            ' If an error occurs, roll back the transaction
                            transaction.Rollback()
                            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Using
                Catch ex As Exception
                    MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Please select a row to retrieve.")
        End If
    End Sub



    ' This method will reload the data and update the DataGridView
    Private Sub RefreshDataGridView()
        ' Create a connection and fetch the latest data
        Dim query As String = "SELECT d.BloodID, d.DonationDate, d.BloodType, d.RhesusFactor, " &
                      "d.DonationType, d.BloodVolume, d.CollectionMethod, p.LastName, p.FirstName, p.MiddleName, " &
                      "p.Baranggay, p.City, p.Province, p.Sex, p.Age " &
                      "FROM donation d " &
                      "JOIN donors p ON d.DonorID = p.DonorID "
        Dim connection As MySqlConnection = modDB.conn
        Using cmd As New MySqlCommand(query, conn)
            ' Open the connection
            conn.Open()
            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()

            ' Fill the DataTable with the updated data
            da.Fill(dt)

            ' Bind the DataGridView to the updated data source
            DataGridView1.DataSource = dt
        End Using
    End Sub
End Class