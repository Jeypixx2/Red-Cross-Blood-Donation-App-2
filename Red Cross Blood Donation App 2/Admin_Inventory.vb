Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Admin_Inventory
    Private sampleData As DataTable
    Private isDailyView As Boolean ' Flag to determine the current view
    Public currentTable As String ' Variable to track the active table (donors, donation, eligibility)
    Public GlobalModel As New Global_model
    Public DoubleBuffering As New DoubleBuffering
    Public SelectedDate As Date
    Public dbDateColumn As String
    Public Calendar As Integer

    Private Sub Admin_Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            ' Use SelectedDate to fetch data
            Dim query As String = $"SELECT * FROM {currentTable} WHERE CONVERT(DATE, {dbDateColumn}) = '{SelectedDate}'"

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
        currentTable = "donors"
        dbDateColumn = "RegDate"
        Calendar = 1
        SelectedDate = dtpCalendar.SelectionStart.ToString("yyyy-MM-dd")

        ' Log this action
        modDB.Logs("Viewed Donor Records")

        ' Fetch the data and update the DataGridView
        Dim query As String = $"SELECT * FROM {currentTable} WHERE {dbDateColumn} = '{SelectedDate}'"
        modDB.readQuery(query)

        If modDB.cmdRead.HasRows Then
            Dim dt As DataTable = New DataTable
            dt.Load(modDB.cmdRead)
            dgvInventory.DataSource = dt
            dgvInventory.Refresh()
        End If
    End Sub


    Private Sub DonationRecord_Click(sender As Object, e As EventArgs) Handles DonationRecord.Click
        currentTable = "donation"
        dbDateColumn = "DonationDate"
        Calendar = 1
        SelectedDate = dtpCalendar.SelectionStart.ToString("yyyy-MM-dd")
        ' Log this action
        modDB.Logs("Viewed Donor Records")

        ' Fetch the data and update the DataGridView
        Dim query As String = $"SELECT * FROM {currentTable} WHERE {dbDateColumn} = '{SelectedDate}'"
        modDB.readQuery(query)

        If modDB.cmdRead.HasRows Then
            Dim dt As DataTable = New DataTable
            dt.Load(modDB.cmdRead)
            dgvInventory.DataSource = dt
            dgvInventory.Refresh()
        End If
    End Sub

    Private Sub EligibilityRecord_Click(sender As Object, e As EventArgs) Handles EligibilityRecord.Click
        currentTable = "eligibility"
        dbDateColumn = "EligibilityDate"
        Calendar = 1
        SelectedDate = dtpCalendar.SelectionStart.ToString("yyyy-MM-dd")
        ' Log this action
        modDB.Logs("Viewed Donor Records")

        ' Fetch the data and update the DataGridView
        Dim query As String = $"SELECT * FROM {currentTable} WHERE {dbDateColumn} = '{SelectedDate}'"
        modDB.readQuery(query)

        If modDB.cmdRead.HasRows Then
            Dim dt As DataTable = New DataTable
            dt.Load(modDB.cmdRead)
            dgvInventory.DataSource = dt
            dgvInventory.Refresh()
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
        ' Disable the buttons during search
        Daily.Enabled = False
        Weekly.Enabled = False
        Monthly.Enabled = False

        ' Set or reset the timer
        searchTimer.Stop()
        searchTimer.Interval = 500 ' Set delay for 500ms after typing stops
        AddHandler searchTimer.Tick, AddressOf PerformSearch
        searchTimer.Start()
    End Sub

    Private Sub PerformSearch(sender As Object, e As EventArgs)
        Try
            ' Perform the search operation after delay
            Dim searchText As String = txtSearch.Text

            ' Only perform the search if the search text is not empty
            If Not String.IsNullOrWhiteSpace(searchText) Then
                Dim results As DataTable = GlobalModel.Search(searchText, currentTable)

                ' Check if results were found
                If results IsNot Nothing AndAlso results.Rows.Count > 0 Then
                    ' Update the DataGridView with the results
                    GlobalModel.UpdateDataGridView(results, dgvInventory)
                Else
                    ' If no results found, inform the user and clear the textbox
                    If Not txtSearch.Tag IsNot Nothing AndAlso txtSearch.Tag.ToString() = "No Results" Then
                        MessageBox.Show("No results found. Please try a different search term.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtSearch.Clear() ' Clear the search textbox
                        txtSearch.Tag = "No Results" ' Mark that message has been shown
                    End If
                End If
            Else
                ' Optionally clear the DataGridView if the search text is empty
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

            ' Stop the timer to prevent further ticks
            searchTimer.Stop()

            ' Reset the Tag for the next search
            txtSearch.Tag = Nothing
        End Try
    End Sub

    Private Sub HistoryRecord_Click(sender As Object, e As EventArgs) Handles HistoryRecord.Click
        UpdateConnectionString()
        DoubleBuffering.EnableDoubleBuffering(dgvInventory)
        currentTable = "healthprovider"
        dbDateColumn = "RetrieveDate"
        Calendar = 1
        SelectedDate = dtpCalendar.SelectionStart.ToString("yyyy-MM-dd")
        Dim Data = GlobalModel.GetAll(currentTable, Calendar, dbDateColumn, SelectedDate)
        GlobalModel.UpdateDataGridView(Data, dgvInventory)
    End Sub

    Private Sub dgvInventory_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInventory.CellContentClick

    End Sub
End Class
