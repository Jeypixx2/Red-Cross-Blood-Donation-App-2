Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class SuperAdmin_Dashboard
    Private sampleData As DataTable
    Private isDailyView As Boolean ' Flag to determine the current view
    Public currentTable As String ' Variable to track the active table (donors, donation, eligibility)
    Public GlobalModel As New Global_model
    Public DoubleBuffering As New DoubleBuffering
    Public SelectedDate As Date
    Public dbDateColumn As String
    Public Calendar As Integer

    Private Sub SuperAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnableEditingAndDeleting()
        Try
            Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
            Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
            Me.Width = screenWidth * 0.8 ' 80% of screen width
            Me.Height = screenHeight * 0.8 ' 80% of screen height
            UpdateConnectionString() ' Optionally use this, or directly set the connection string in modDB
            DoubleBuffering.EnableDoubleBuffering(dgvInventory)
            currentTable = "donors"
            dbDateColumn = "RegDate"
            Calendar = 1
            modDB.Logs("Load SuperAdmin Dashboard Successfully!")

            ' Initialize SelectedDate to today if it is not set
            If String.IsNullOrEmpty(SelectedDate) OrElse SelectedDate = Date.MinValue.ToString("yyyy-MM-dd") Then
                SelectedDate = DateTime.Now.ToString("yyyy-MM-dd")
            End If

            ' Debugging: Log the value of SelectedDate
            Debug.WriteLine("SelectedDate: " & SelectedDate)

            Dim query As String = $"SELECT * FROM {currentTable} WHERE DATE({dbDateColumn}) = '{SelectedDate}'"


            ' Debugging: Log the query being executed
            Debug.WriteLine("Query: " & query)

            ' Ensure the query execution works as expected
            modDB.readQuery(query)

            ' Check if cmdRead is properly initialized and has rows
            If modDB.cmdRead IsNot Nothing AndAlso modDB.cmdRead.HasRows Then
                Dim dt As DataTable = New DataTable
                dt.Load(modDB.cmdRead)
                dgvInventory.DataSource = dt
                dgvInventory.Refresh()
            Else
                MessageBox.Show("No records found for the selected date.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            ' Log any exceptions for debugging
            MessageBox.Show("Error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Debug.WriteLine("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub PopulateMonths()
        cmbMonths.Items.Clear()
        For month As Integer = 1 To 12
            cmbMonths.Items.Add(Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month))
        Next

        If cmbMonths.Items.Count > 0 Then
            cmbMonths.SelectedIndex = 0
        End If
    End Sub

    ' Show MonthCalendar when Daily button is clicked
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Daily.Click
        dtpCalendar.Visible = True
        cmbMonths.Visible = False
        isDailyView = True ' Set flag for Daily view
        modDB.Logs("Filter Daily")
    End Sub

    ' Show MonthCalendar when Weekly button is clicked
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Weekly.Click
        Calendar = 2
        dtpCalendar.Visible = True
        cmbMonths.Visible = False
        isDailyView = False ' Set flag for Weekly view
        modDB.Logs("Filter Weekly")
    End Sub

    ' Show the ComboBox for month selection
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Monthly.Click
        PopulateMonths()
        dtpCalendar.Visible = False
        cmbMonths.Visible = True
        modDB.Logs("Filter Monthly")
    End Sub

    ' Load data for the selected month when a month is chosen from the ComboBox
    Private Sub cmbMonths_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMonths.SelectedIndexChanged
        Dim selectedMonth As Integer = cmbMonths.SelectedIndex + 1 ' Get the numeric month (1-12)
        Dim currentYear As Integer = DateTime.Now.Year ' Optionally, allow selecting other years if needed

        ' Fetch data for the selected month and year
        Dim Data = GlobalModel.GetAll(currentTable, 3, dbDateColumn, selectedMonth, currentYear)

        ' Update the DataGridView
        GlobalModel.UpdateDataGridView(Data, dgvInventory)

        ' Hide the ComboBox after selection
        cmbMonths.Visible = False

    End Sub


    Private Sub DonorRecord_Click(sender As Object, e As EventArgs) Handles DonorRecord.Click
        ' Update connection string and enable double buffering
        UpdateConnectionString()
        DoubleBuffering.EnableDoubleBuffering(dgvInventory)

        ' Set parameters for the current table and date column
        currentTable = "donors"
        dbDateColumn = "RegDate"
        Calendar = 1
        SelectedDate = dtpCalendar.SelectionStart.ToString("yyyy-MM-dd")

        Dim query As String = $"SELECT * FROM {currentTable} WHERE DATE({dbDateColumn}) = '{SelectedDate}'"


        ' Call the LoadDGV function from modDB to load the data into the DataGridView
        Dim rowCount As Integer = modDB.LoadToDGV(query, dgvInventory)

        ' Log the action
        modDB.Logs("View Donor History")

        ' Optionally, check row count or provide further feedback
        If rowCount = 0 Then
            MessageBox.Show("No donor records found for the selected date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub




    Private Sub DonationRecord_Click(sender As Object, e As EventArgs) Handles DonationRecord.Click
        ' Update connection string and enable double buffering
        UpdateConnectionString()
        DoubleBuffering.EnableDoubleBuffering(dgvInventory)

        ' Set parameters for the current table and date column
        currentTable = "donation"
        dbDateColumn = "DonationDate"
        Calendar = 1
        SelectedDate = dtpCalendar.SelectionStart.ToString("yyyy-MM-dd")

        Dim query As String = $"SELECT * FROM {currentTable} WHERE DATE({dbDateColumn}) = '{SelectedDate}'"


        ' Call the LoadDGV function from modDB to load the data into the DataGridView
        Dim rowCount As Integer = modDB.LoadToDGV(query, dgvInventory)

        ' Log the action
        modDB.Logs("View Donation History")

        ' Optionally, check row count or provide further feedback
        If rowCount = 0 Then
            MessageBox.Show("No donation records found for the selected date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub




    Private Sub EligibilityRecord_Click(sender As Object, e As EventArgs) Handles EligibilityRecord.Click
        ' Update connection string and enable double buffering
        UpdateConnectionString()
        DoubleBuffering.EnableDoubleBuffering(dgvInventory)

        ' Set parameters for the current table and date column
        currentTable = "eligibility"
        dbDateColumn = "EligibilityDate"
        Calendar = 1
        SelectedDate = dtpCalendar.SelectionStart.ToString("yyyy-MM-dd")

        Dim query As String = $"SELECT * FROM {currentTable} WHERE DATE({dbDateColumn}) = '{SelectedDate}'"


        ' Call the LoadDGV function from modDB to load the data into the DataGridView
        Dim rowCount As Integer = modDB.LoadToDGV(query, dgvInventory)

        ' Log the action
        modDB.Logs("View Eligibility History")

        ' Optionally, check row count or provide further feedback
        If rowCount = 0 Then
            MessageBox.Show("No eligibility records found for the selected date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Health_Provider_Click(sender As Object, e As EventArgs) Handles Health_Provider.Click


        UpdateConnectionString()
        DoubleBuffering.EnableDoubleBuffering(dgvInventory)


        currentTable = "healthprovider"
        dbDateColumn = "RetrieveDate"
        Calendar = 1
        SelectedDate = dtpCalendar.SelectionStart.ToString("yyyy-MM-dd")

        Dim query As String = $"SELECT * FROM {currentTable} WHERE DATE({dbDateColumn}) = '{SelectedDate}'"



        Dim rowCount As Integer = modDB.LoadToDGV(query, dgvInventory)


        modDB.Logs("View Health Provider")


        If rowCount = 0 Then
            MessageBox.Show("No history records found for the selected date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub



    Private Sub dtpCalendar_DateChanged(sender As Object, e As DateRangeEventArgs) Handles dtpCalendar.DateSelected
        SelectedDate = dtpCalendar.SelectionStart.ToString("yyyy-MM-dd")
        Dim SelectedDateWeek As Date = SelectedDate.AddDays(DayOfWeek.Saturday - SelectedDate.DayOfWeek).ToString("yyyy-MM-dd")
        Dim Data As DataTable
        If Calendar = 2 Then
            Data = GlobalModel.GetAll(currentTable, Calendar, dbDateColumn, SelectedDate, SelectedDateWeek)
        Else
            Data = GlobalModel.GetAll(currentTable, Calendar, dbDateColumn, SelectedDate)
        End If

        GlobalModel.UpdateDataGridView(Data, dgvInventory)
        dtpCalendar.Visible = False
    End Sub

    Private searchTimer As New Timer()

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        Daily.Enabled = False
        Weekly.Enabled = False
        Monthly.Enabled = False


        searchTimer.Stop()
        searchTimer.Interval = 500
        AddHandler searchTimer.Tick, AddressOf PerformSearch
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

                    If Not txtSearch.Tag IsNot Nothing AndAlso txtSearch.Tag.ToString() = "No Results" Then
                        MessageBox.Show("No results found. Please try a different search term.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtSearch.Clear()
                        txtSearch.Tag = "No Results"
                    End If
                End If
            Else

                dgvInventory.DataSource = Nothing
            End If

        Catch ex As Exception
            ' Show error message
            MessageBox.Show("Error occurred while performing the search: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            ' Re-enable the buttons after search is complete
            Daily.Enabled = True
            Weekly.Enabled = True
            Monthly.Enabled = True


            searchTimer.Stop()

            txtSearch.Tag = Nothing

        End Try
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

    Private Sub History_Click(sender As Object, e As EventArgs) Handles History.Click
        UpdateConnectionString()
        DoubleBuffering.EnableDoubleBuffering(dgvInventory)

        ' Set parameters for the current table and date column
        currentTable = "history"
        dbDateColumn = "DonorRegDate" ' Change this to the appropriate column for the history table
        Calendar = 1
        SelectedDate = dtpCalendar.SelectionStart.ToString("yyyy-MM-dd")

        ' Fetch the data and update the DataGridView
        Dim Data = GlobalModel.GetAll(currentTable, Calendar, dbDateColumn, SelectedDate)
        GlobalModel.UpdateDataGridView(Data, dgvInventory)

        ' Log the action
        modDB.Logs("View History Data")

    End Sub

    Private Sub Logs_Click(sender As Object, e As EventArgs) Handles Logs.Click
        UpdateConnectionString()
        DoubleBuffering.EnableDoubleBuffering(dgvInventory)

        ' Set parameters for the current table and date column
        currentTable = "logs"
        dbDateColumn = "dt" ' Change this to the appropriate column for the history table
        Calendar = 1
        SelectedDate = dtpCalendar.SelectionStart.ToString("yyyy-MM-dd")

        ' Fetch the data and update the DataGridView
        Dim Data = GlobalModel.GetAll(currentTable, Calendar, dbDateColumn, SelectedDate)
        GlobalModel.UpdateDataGridView(Data, dgvInventory)

        ' Log the action
        modDB.Logs("View Logs Data")
    End Sub

    Private Sub Accounts_Click(sender As Object, e As EventArgs) Handles Accounts.Click
        UpdateConnectionString()
        DoubleBuffering.EnableDoubleBuffering(dgvInventory)

        ' Set parameters for the current table and date column
        currentTable = "accounts"
        dbDateColumn = "dt_created" ' Change this to the appropriate column for the history table
        Calendar = 1
        SelectedDate = dtpCalendar.SelectionStart.ToString("yyyy-MM-dd")

        ' Fetch the data and update the DataGridView
        Dim Data = GlobalModel.GetAll(currentTable, Calendar, dbDateColumn, SelectedDate)
        GlobalModel.UpdateDataGridView(Data, dgvInventory)

        ' Log the action
        modDB.Logs("View Accounts Data")
    End Sub

    Private Sub EnableEditingAndDeleting()
        dgvInventory.ReadOnly = False ' Allow editing
        dgvInventory.AllowUserToDeleteRows = True ' Allow row deletion
    End Sub

    ' Define a mapping of table names to their primary key column names
    Dim tablePrimaryKeys As New Dictionary(Of String, String) From {
    {"donors", "DonorID"},
    {"eligibility", "EligibilityID"},
    {"donation", "bloodID"},
    {"healthprovider", "RetrieveID"},
    {"history", "HistoryID"},
    {"logs", "user_accounts_id"},
    {"accounts", "adminID"}}
    ' Add more table-to-ID mappings as needed

    Private Sub dgvInventory_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInventory.CellValueChanged
        Try
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                ' Skip new rows
                If dgvInventory.Rows(e.RowIndex).IsNewRow Then Exit Sub

                ' Get the edited cell's value, column name, and table's primary key column name
                Dim editedCell = dgvInventory.Rows(e.RowIndex).Cells(e.ColumnIndex)
                Dim columnName = dgvInventory.Columns(e.ColumnIndex).Name
                Dim newValue As Object = If(editedCell.Value IsNot Nothing, editedCell.Value, DBNull.Value)

                ' Determine the primary key column for the current table
                Dim primaryKeyColumn As String
                If tablePrimaryKeys.TryGetValue(currentTable, primaryKeyColumn) Then
                    Dim rowID = dgvInventory.Rows(e.RowIndex).Cells(primaryKeyColumn).Value ' Get the primary key value

                    If rowID Is Nothing OrElse IsDBNull(rowID) Then
                        Throw New Exception("Primary key value is missing or invalid.")
                    End If

                    ' Construct the UPDATE query
                    Dim query As String = $"UPDATE {currentTable} SET {columnName} = @newValue WHERE {primaryKeyColumn} = @rowID"

                    Using conn As New MySqlConnection(modDB.strConnection)
                        Using cmd As New MySqlCommand(query, conn)
                            ' Add parameters to avoid SQL injection
                            cmd.Parameters.AddWithValue("@newValue", newValue)
                            cmd.Parameters.AddWithValue("@rowID", rowID)

                            ' Open connection and execute query
                            conn.Open()
                            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                            ' Log the update
                            modDB.Logs($"Updated {columnName} in {currentTable} for ID {rowID}. Rows affected: {rowsAffected}.")
                        End Using
                    End Using

                    ' Notify success
                    modDB.Logs("Update Inventory Data")
                    MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Throw New Exception($"Primary key column not defined for table: {currentTable}")
                End If
            End If
        Catch ex As Exception
            ' Handle exceptions
            MessageBox.Show($"Error updating record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            modDB.Logs("Load Data on Chart2")

        Catch ex As Exception
            MessageBox.Show($"Error loading Chart2: {ex.Message}", "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            modDB.Logs("Load Data on Chart2")

        Catch ex As Exception
            MessageBox.Show($"Error loading Chart1: {ex.Message}", "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Set config
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

    Private Sub btnFilterCharts_Click(sender As Object, e As EventArgs) Handles btnFilterCharts.Click
        Dim startDate As Date = dtpFrom.Value
        Dim endDate As Date = dtpTo.Value

        If startDate > endDate Then
            MessageBox.Show("Start date cannot be later than end date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        modDB.Logs("Filtered Data on Charts")
        LoadChart1(startDate, endDate)
        LoadChart2(startDate, endDate)
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            ' Check if a cell is selected
            If dgvInventory.CurrentCell Is Nothing Then
                MessageBox.Show("Please select a cell to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim rowIndex As Integer = dgvInventory.CurrentCell.RowIndex
            Dim columnIndex As Integer = dgvInventory.CurrentCell.ColumnIndex

            ' Skip new rows
            If dgvInventory.Rows(rowIndex).IsNewRow Then
                MessageBox.Show("Cannot update a new row. Please complete the row first.", "New Row", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Get the edited cell's value, column name
            Dim editedCell = dgvInventory.Rows(rowIndex).Cells(columnIndex)
            Dim columnName = dgvInventory.Columns(columnIndex).Name
            Dim newValue As Object = If(editedCell.Value IsNot Nothing, editedCell.Value, DBNull.Value)

            ' Determine the primary key column for the current table
            Dim primaryKeyColumn As String = ""
            If tablePrimaryKeys.TryGetValue(currentTable, primaryKeyColumn) Then
                ' Find the index of the primary key column in the DataGridView
                Dim primaryKeyColumnIndex As Integer = -1
                For i As Integer = 0 To dgvInventory.Columns.Count - 1
                    If dgvInventory.Columns(i).Name.Equals(primaryKeyColumn, StringComparison.OrdinalIgnoreCase) Then
                        primaryKeyColumnIndex = i
                        Exit For
                    End If
                Next

                If primaryKeyColumnIndex = -1 Then
                    Throw New Exception($"Primary key column '{primaryKeyColumn}' not found in the DataGridView.")
                End If

                Dim rowID = dgvInventory.Rows(rowIndex).Cells(primaryKeyColumnIndex).Value ' Get the primary key value

                If rowID Is Nothing OrElse IsDBNull(rowID) Then
                    Throw New Exception("Primary key value is missing or invalid.")
                End If

                ' Construct the UPDATE query
                Dim query As String = $"UPDATE {currentTable} SET {columnName} = @newValue WHERE {primaryKeyColumn} = @rowID"

                Using conn As New MySqlConnection(modDB.strConnection)
                    Using cmd As New MySqlCommand(query, conn)
                        ' Add parameters to avoid SQL injection
                        cmd.Parameters.AddWithValue("@newValue", newValue)
                        cmd.Parameters.AddWithValue("@rowID", rowID)

                        ' Open connection and execute query
                        conn.Open()
                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                        ' Log the update
                        modDB.Logs($"Updated {columnName} in {currentTable} for ID {rowID}. Rows affected: {rowsAffected}.")
                    End Using
                End Using

                ' Notify success
                modDB.Logs("Update Inventory Data")
                MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Refresh the data to show the updated values
                Dim Data = GlobalModel.GetAll(currentTable, Calendar, dbDateColumn, SelectedDate)
                GlobalModel.UpdateDataGridView(Data, dgvInventory)
            Else
                Throw New Exception($"Primary key column not defined for table: {currentTable}")
            End If
        Catch ex As Exception
            ' Handle exceptions
            MessageBox.Show($"Error updating record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            ' Check if a row is selected
            If dgvInventory.CurrentRow Is Nothing OrElse dgvInventory.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Get the selected row index
            Dim rowIndex As Integer = dgvInventory.CurrentRow.Index

            ' Skip new rows
            If dgvInventory.Rows(rowIndex).IsNewRow Then
                MessageBox.Show("Cannot delete a new row.", "New Row", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Confirm deletion with the user
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this record? This action cannot be undone.",
                                                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.No Then
                Return
            End If

            ' Determine the primary key column for the current table
            Dim primaryKeyColumn As String = ""
            If tablePrimaryKeys.TryGetValue(currentTable, primaryKeyColumn) Then
                ' Find the index of the primary key column in the DataGridView
                Dim primaryKeyColumnIndex As Integer = -1
                For i As Integer = 0 To dgvInventory.Columns.Count - 1
                    If dgvInventory.Columns(i).Name.Equals(primaryKeyColumn, StringComparison.OrdinalIgnoreCase) Then
                        primaryKeyColumnIndex = i
                        Exit For
                    End If
                Next

                If primaryKeyColumnIndex = -1 Then
                    Throw New Exception($"Primary key column '{primaryKeyColumn}' not found in the DataGridView.")
                End If

                Dim rowID = dgvInventory.Rows(rowIndex).Cells(primaryKeyColumnIndex).Value ' Get the primary key value

                If rowID Is Nothing OrElse IsDBNull(rowID) Then
                    Throw New Exception("Primary key value is missing or invalid.")
                End If

                ' Construct the DELETE query
                Dim query As String = $"DELETE FROM {currentTable} WHERE {primaryKeyColumn} = @rowID"

                Using conn As New MySqlConnection(modDB.strConnection)
                    Using cmd As New MySqlCommand(query, conn)
                        ' Add parameter to avoid SQL injection
                        cmd.Parameters.AddWithValue("@rowID", rowID)

                        ' Open connection and execute query
                        conn.Open()
                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                        ' Log the deletion
                        modDB.Logs($"Deleted record from {currentTable} with ID {rowID}. Rows affected: {rowsAffected}.")
                    End Using
                End Using

                ' Notify success
                modDB.Logs("Delete Inventory Data")
                MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Refresh the data to show the updated grid without the deleted row
                Dim Data = GlobalModel.GetAll(currentTable, Calendar, dbDateColumn, SelectedDate)
                GlobalModel.UpdateDataGridView(Data, dgvInventory)
            Else
                Throw New Exception($"Primary key column not defined for table: {currentTable}")
            End If
        Catch ex As Exception
            ' Handle exceptions
            MessageBox.Show($"Error deleting record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class
