Imports MySql.Data.MySqlClient

Public Class Process_Success
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Show Admin Dashboard and hide current form
        GoBack(Me)
        Me.Hide()

        ' Declare and populate donorList (fetch data from the database)
        Dim donorList As List(Of DonorData) = GetDonorList()

        ' Access the Start form without showing it
        Dim startForm As Start = New Start()

        ' Process each donor using the method from the Start form
        ProcessDonors(donorList, startForm)
    End Sub

    ' Method to process the list of donors
    Private Sub ProcessDonors(donors As List(Of DonorData), startForm As Start)
        ' Iterate over each donor and call InsertDonationAndUpdateHistory from Start form
        For Each donor As DonorData In donors
            ' Call the method from the Start form instance
            startForm.InsertDonationAndUpdateHistory(donor.DonorID, donor.BloodComponent, donor.BloodVolume, Date.Now)
        Next
    End Sub

    ' Method to get the donor list (you can adapt this to fetch from your database)
    Private Function GetDonorList() As List(Of DonorData)
        Dim donors As New List(Of DonorData)()

        ' Example: Fetching donor data from the database (customize as needed)
        Dim connString As String = "Server=localhost;Database=redcrossdb;Uid=root;Pwd=;"
        Using conn As New MySqlConnection(connString)
            conn.Open()

            Dim query As String = "SELECT d.DonorID, dn.BloodComponent, dn.BloodVolume " &
                                  "FROM donors d " &
                                  "INNER JOIN donation dn ON d.DonorID = dn.DonorID"

            Using cmd As New MySqlCommand(query, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim donor As New DonorData With {
                            .DonorID = reader.GetInt32(0),
                            .BloodComponent = reader.GetString(1),
                            .BloodVolume = reader.GetDecimal(2)
                        }
                        donors.Add(donor)
                    End While
                End Using
            End Using
        End Using

        Return donors
    End Function
End Class
