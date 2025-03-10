Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Relational

Public Class Global_model

    Public Function GetAll(ByVal database As String, ByVal Calendar As Integer, ByVal DbDateColumn As String, ParamArray parameters As Object()) As DataTable
        Dim query As String = "SELECT * FROM `" & database & "`"
        Dim table As New DataTable()

        Select Case Calendar
            Case 1
                query &= " WHERE DATE(`" & DbDateColumn & "`) = @param0"
            Case 2
                query &= " WHERE DATE(`" & DbDateColumn & "`) BETWEEN @param0 AND @param1"
            Case 3
                query &= " WHERE MONTH(`" & DbDateColumn & "`) = @param0 AND YEAR(`" & DbDateColumn & "`) = @param1"
        End Select

        Try
            openConn(database) ' Assuming this method opens the database connection

            ' Log the query and parameters for debugging
            Console.WriteLine("SQL Query: " & query)
            For i As Integer = 0 To parameters.Length - 1
                Console.WriteLine($"Parameter {i}: {parameters(i)}")
            Next

            Using cmd As New MySqlCommand(query, conn)
                If parameters IsNot Nothing Then
                    For i As Integer = 0 To parameters.Length - 1
                        cmd.Parameters.AddWithValue($"@param{i}", parameters(i))
                    Next
                End If

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(table)
                End Using
            End Using
        Catch ex As MySqlException
            MsgBox("MySQL Error: " & ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        Return table
    End Function






    Sub UpdateDataGridView(filteredData As DataTable, ByVal DataGridView As DataGridView)

        DataGridView.DataSource = Nothing
        DataGridView.DataSource = filteredData

        If Admin_Inventory.currentTable = "healthprovider" Then
            If DataGridView.Columns.Contains("RetrieveID") Then
                DataGridView.Columns("RetrieveID").Visible = True
            End If

            If filteredData.Rows.Count = 0 Then
                MessageBox.Show("No data available for the selected date/week/month.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Else
            If DataGridView.Columns.Contains("DonorID") Then
                DataGridView.Columns("DonorID").Visible = True
            End If

            If filteredData.Rows.Count = 0 Then
                MessageBox.Show("No data available for the selected date/week/month.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        With Admin_Inventory
            .dtpCalendar.Visible = False
            .dtpCalendar.Refresh()
        End With
    End Sub


    ' Function to rename columns in the DataTable


    Public Function Search(searchText As String, ByVal currentTable As String) As DataTable
        searchText = searchText.Trim().ToLower() ' Trim spaces and convert to lowercase

        Dim query As String = "SELECT * FROM " & currentTable
        Dim table As New DataTable()

        Try
            ' Open the connection if not already open
            If conn.State = ConnectionState.Closed Then
                UpdateConnectionString()
            End If

            ' Retrieve all data from the selected table
            Using cmd As New MySqlCommand(query, conn)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(table)
                End Using
            End Using

            ' Filter rows based on the search text
            If Not String.IsNullOrEmpty(searchText) Then
                For Each row As DataRow In table.Rows.Cast(Of DataRow).ToList()
                    Dim match As Boolean = False

                    ' Check each relevant column based on the table
                    Select Case currentTable
                        Case "donors"
                            ' Check if any of the columns contain the search text
                            If ContainsText(row, "FirstName", searchText) Or
                               ContainsText(row, "LastName", searchText) Or
                               ContainsText(row, "MiddleName", searchText) Or
                               ContainsText(row, "Baranggay", searchText) Or
                               ContainsText(row, "City", searchText) Or
                               ContainsText(row, "Province", searchText) Then
                                match = True
                            End If

                        Case "donation"
                            If ContainsText(row, "BloodType", searchText) Or
                               ContainsText(row, "RhesusFactor", searchText) Or
                               ContainsText(row, "DonationType", searchText) Or
                               ContainsText(row, "BloodVolume", searchText) Or
                               ContainsText(row, "CollectionMethod", searchText) Then
                                match = True
                            End If

                        Case "eligibility"
                            If ContainsText(row, "Weight", searchText) Or
                               ContainsText(row, "BloodPressure", searchText) Or
                               ContainsText(row, "Hemoglobin", searchText) Then
                                match = True
                            End If
                    End Select

                    ' If no match, delete the row
                    If Not match Then
                        row.Delete()
                    End If
                Next

                ' Accept changes to apply the deletion
                table.AcceptChanges()
            End If

        Catch ex As MySqlException
            ' Show error message
            MessageBox.Show("Error: " & ex.Message)
            Return Nothing
        End Try

        ' Return the filtered table
        Return table
    End Function

    ' Helper function to check if a column contains the search text
    Private Function ContainsText(row As DataRow, columnName As String, searchText As String) As Boolean
        ' Ensure column exists and is not null
        If row.Table.Columns.Contains(columnName) Then
            Dim columnValue As String = row(columnName).ToString().ToLower()
            Return columnValue.Contains(searchText)
        End If
        Return False
    End Function

End Class
