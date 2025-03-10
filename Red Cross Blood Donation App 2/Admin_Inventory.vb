Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class Admin_Inventory
    Private sampleData As DataTable
    Private isDailyView As Boolean ' Flag to determine the current view
    Public currentTable As String ' Variable to track the active table (donors, donation, eligibility)
    Public GlobalModel As New Global_model
    Public DoubleBuffering As New DoubleBuffering
    Public SelectedDate As DateTime
    Public dbDateColumn As String
    Public Calendar As Integer

    Private Sub Admin_Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnableEditingAndDeleting()
        Try
            ' Initialize SelectedDate to today if it is not set
            If SelectedDate = DateTime.MinValue Then
                SelectedDate = DateTime.Now
            End If

            ' Debugging: Log the value of SelectedDate
            Debug.WriteLine("SelectedDate: " & SelectedDate.ToString("yyyy-MM-dd"))

            ' Use parameterized query to avoid SQL injection and ensure compatibility
            Dim query As String = $"SELECT * FROM {currentTable} WHERE CAST({dbDateColumn} AS DATE) = @SelectedDate"

            ' Create the database command
            Using cmd As New MySqlCommand(query, modDB.conn)
                ' Add parameter for the selected date
                cmd.Parameters.AddWithValue("@SelectedDate", SelectedDate.ToString("yyyy-MM-dd"))

                ' Execute the query
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.HasRows Then
                        Dim dt As New DataTable()
                        dt.Load(reader)
                        dgvInventory.DataSource = dt
                        dgvInventory.Refresh()
                    Else
                        MessageBox.Show("No records found for the selected date.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Log any exceptions for debugging
            MessageBox.Show("Error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Debug.WriteLine("Error: " & ex.Message)
        End Try
    End Sub
    Private Function GetPrimaryKey(tableName As String) As String
        Dim primaryKey As String = ""

        Select Case tableName.ToLower()
            Case "donors"
                primaryKey = "DonorID"
            Case "donation"
                primaryKey = "BloodID"
            Case "eligibility"
                primaryKey = "EligibilityID"
            Case "healthprovider"
                primaryKey = "RetrieveID"
            Case "history"
                primaryKey = "HistoryID"
            Case Else
                Throw New Exception("Unknown table: " & tableName)
        End Select

        Return primaryKey
    End Function


    Private Sub EnableEditingAndDeleting()
        dgvInventory.ReadOnly = False ' Allow editing
        dgvInventory.AllowUserToDeleteRows = True ' Allow row deletion
    End Sub
    Private Sub dgvInventory_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInventory.CellEndEdit
        Try
            ' Ensure the row and column indexes are valid
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                Dim updatedValue As Object = dgvInventory.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                Dim columnName As String = dgvInventory.Columns(e.ColumnIndex).Name
                Dim primaryKeyColumn As String = GetPrimaryKey(currentTable) ' Fetch primary key dynamically
                Dim primaryKeyValue As Object = dgvInventory.Rows(e.RowIndex).Cells(primaryKeyColumn).Value

                ' Ensure connection is open
                If modDB.conn.State = ConnectionState.Closed Then
                    modDB.conn.Open()
                End If

                ' Update the database
                Dim query As String = $"UPDATE {currentTable} SET `{columnName}` = @value WHERE {primaryKeyColumn} = @id"


                Using cmd As New MySqlCommand(query, modDB.conn)
                    cmd.Parameters.AddWithValue("@value", updatedValue)
                    cmd.Parameters.AddWithValue("@id", primaryKeyValue)
                    cmd.ExecuteNonQuery()
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Error updating database: " & ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub




    Private Sub HomeButton_Click(sender As Object, e As EventArgs) Handles Home_Button.Click
        Admin_Dashboard.Show()
        Me.Hide()
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

        ' Construct the query based on selected date
        Dim query As String = $"SELECT * FROM {currentTable} WHERE DATE({dbDateColumn}) = @SelectedDate"

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

        ' Construct the query based on selected date
        Dim query As String = $"SELECT * FROM {currentTable} WHERE DATE({dbDateColumn}) = @SelectedDate"

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

        ' Construct the query based on selected date
        Dim query As String = $"SELECT * FROM {currentTable} WHERE DATE({dbDateColumn}) = @SelectedDate"

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


        Dim query As String = $"SELECT * FROM {currentTable} WHERE DATE({dbDateColumn}) = @SelectedDate"


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
End Class
