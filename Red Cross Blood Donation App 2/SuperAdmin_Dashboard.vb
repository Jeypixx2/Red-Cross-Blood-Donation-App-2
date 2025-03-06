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
    End Sub

    ' Show MonthCalendar when Weekly button is clicked
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Weekly.Click
        Calendar = 2
        dtpCalendar.Visible = True
        cmbMonths.Visible = False
        isDailyView = False ' Set flag for Weekly view
    End Sub

    ' Show the ComboBox for month selection
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Monthly.Click
        PopulateMonths()
        dtpCalendar.Visible = False
        cmbMonths.Visible = True
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


        modDB.Logs("View History")


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
        modDB.Logs("ViewHealth Provider Report")
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
        modDB.Logs("View History Data")
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
        modDB.Logs("View History Data")
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


    ' Set config
    Private Sub Config_Click_1(sender As Object, e As EventArgs) Handles Config.Click
        SetConfig.Show()
    End Sub

    Private Sub New_Donor_Click(sender As Object, e As EventArgs) Handles New_Donor.Click
        User_Status.Show()
    End Sub

    Private Sub New_Donation_Click(sender As Object, e As EventArgs) Handles New_Donation.Click
        User_Status.Show()
    End Sub

    Private Sub back_Click(sender As Object, e As EventArgs) Handles back.Click
        Start.Show()
        Me.Hide()
    End Sub
End Class
