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
        UpdateConnectionString()
        DoubleBuffering.EnableDoubleBuffering(dgvInventory)
        currentTable = "donors"
        dbDateColumn = "RegDate"
        Calendar = 1
        SelectedDate = dtpCalendar.SelectionStart.ToString("yyyy-MM-dd")
        Dim Data = GlobalModel.GetAll(currentTable, Calendar, dbDateColumn, SelectedDate)
        GlobalModel.UpdateDataGridView(Data, dgvInventory)
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
        Dim Data = GlobalModel.GetAll(currentTable, Calendar, dbDateColumn, SelectedDate)
        GlobalModel.UpdateDataGridView(Data, dgvInventory)
    End Sub

    Private Sub DonationRecord_Click(sender As Object, e As EventArgs) Handles DonationRecord.Click
        currentTable = "donation"
        dbDateColumn = "DonationDate"
        Calendar = 1
        SelectedDate = dtpCalendar.SelectionStart.ToString("yyyy-MM-dd")
        Dim Data = GlobalModel.GetAll(currentTable, Calendar, dbDateColumn, SelectedDate)
        GlobalModel.UpdateDataGridView(Data, dgvInventory)
    End Sub

    Private Sub EligibilityRecord_Click(sender As Object, e As EventArgs) Handles EligibilityRecord.Click
        currentTable = "eligibility"
        dbDateColumn = "EligibilityDate"
        Calendar = 1
        SelectedDate = dtpCalendar.SelectionStart.ToString("yyyy-MM-dd")
        Dim Data = GlobalModel.GetAll(currentTable, Calendar, dbDateColumn, SelectedDate)
        GlobalModel.UpdateDataGridView(Data, dgvInventory)
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
            Dim results As DataTable = GlobalModel.Search(searchText, currentTable)

            ' Check if results were found
            If results IsNot Nothing AndAlso results.Rows.Count > 0 Then
                ' Update the DataGridView with the results
                GlobalModel.UpdateDataGridView(results, dgvInventory)
            Else
                ' If no results found, clear the textbox
                txtSearch.Clear()

                ' Optionally, show a message informing the user
                MessageBox.Show("No results found. Please try a different search term.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ' Re-enable the buttons after search is complete
            Daily.Enabled = True
            Weekly.Enabled = True
            Monthly.Enabled = True

        Catch ex As Exception
            ' Show error message and clear the search textbox
            MessageBox.Show("Error occurred while performing the search: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' Clear the textbox after the error
            txtSearch.Clear()

            ' Re-enable the buttons in case of an error
            Daily.Enabled = True
            Weekly.Enabled = True
            Monthly.Enabled = True
        Finally
            ' Stop the timer to prevent further ticks
            searchTimer.Stop()
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
