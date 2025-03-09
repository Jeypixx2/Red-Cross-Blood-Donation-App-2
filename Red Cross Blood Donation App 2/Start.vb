' Start.vb (Main Form)
Imports MySql.Data.MySqlClient

Public Class Start
    Public frmhelper As New FormHelper


    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the database connection
        ' frmhelper.Seeders()
        UpdateConnectionString()
        openConn("redcrossdb")

        ' Fetch all donor details
        Dim donorList As List(Of DonorData) = GetAllDonorDetails()

        ' Loop through each donor and insert donation record
        For Each donor As DonorData In donorList
            InsertDonationAndUpdateHistory(donor.DonorID, donor.BloodComponent, donor.BloodVolume, Date.Now)
        Next

        MessageBox.Show("All donations inserted successfully.")
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        Me.Hide()
        Admin_Access.Show()
    End Sub

    Private Sub btnHealthcareprovider_Click(sender As Object, e As EventArgs) Handles btnHealthcareprovider.Click
        Me.Hide()
        HealthCare_Access.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        SuperAdmin_Access.Show()
    End Sub

    Public Sub InsertDonationAndUpdateHistory(donorID As Integer, bloodComponent As String, bloodVolume As Decimal, donationDate As Date)
        Dim connString As String = "Server=localhost;Database=redcrossdb;Uid=root;Pwd=;"

        Using conn As New MySqlConnection(connString)
            conn.Open()

            Dim transaction As MySqlTransaction = conn.BeginTransaction()

            Try
                ' Check if a record already exists in the history table for the donor
                Dim existingHistoryQuery As String = "SELECT COUNT(*) FROM history WHERE DonorID = @DonorID"
                Dim historyCount As Integer = 0

                Using cmd As New MySqlCommand(existingHistoryQuery, conn, transaction)
                    cmd.Parameters.AddWithValue("@DonorID", donorID)
                    historyCount = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                ' Get last eligibility check date and total checks
                Dim lastEligibilityDate As Object = Nothing
                Dim totalEligibilityChecks As Integer = 0
                Dim totalDonations As Integer = 0

                ' Get eligibility data for donor
                Dim eligibilityQuery As String = "SELECT COALESCE(MAX(EligibilityDate), NULL), COUNT(*) FROM eligibility WHERE DonorID = @DonorID"
                Using cmd As New MySqlCommand(eligibilityQuery, conn, transaction)
                    cmd.Parameters.AddWithValue("@DonorID", donorID)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            lastEligibilityDate = If(reader.IsDBNull(0), Nothing, reader.GetDateTime(0))
                            totalEligibilityChecks = reader.GetInt32(1)
                        End If
                    End Using
                End Using

                ' Get total donations count
                Dim donationQuery As String = "SELECT COUNT(*) FROM donation WHERE DonorID = @DonorID"
                Using cmd As New MySqlCommand(donationQuery, conn, transaction)
                    cmd.Parameters.AddWithValue("@DonorID", donorID)
                    totalDonations = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                ' If history record exists, update it
                If historyCount > 0 Then
                    ' Update the existing history record with new data
                    Dim updateHistoryQuery As String = "" &
                "UPDATE history SET " &
                "totalEligibilityCheck = @TotalEligibilityChecks, " &
                "totalDonation = @TotalDonations, " &
                "TotalBloodVolume_Wholeblood = IF(@BloodComponent = 'Whole Blood', @BloodVolume, 0), " &
                "TotalBloodVolume_Redblood = IF(@BloodComponent = 'Red Blood Cells', @BloodVolume, 0), " &
                "TotalBloodVolume_Platelets = IF(@BloodComponent = 'Platelets', @BloodVolume, 0), " &
                "TotalBloodVolume_Plasma = IF(@BloodComponent = 'Plasma', @BloodVolume, 0), " &
                "TotalBloodVolume_Whiteblood = IF(@BloodComponent = 'White Blood Cells', @BloodVolume, 0), " &
                "LastEligibilityCheckDate = @LastEligibilityDate, " &
                "LatestDonationDate = @DonationDate " &
                "WHERE DonorID = @DonorID"

                    Using cmd As New MySqlCommand(updateHistoryQuery, conn, transaction)
                        cmd.Parameters.AddWithValue("@DonorID", donorID)
                        cmd.Parameters.AddWithValue("@TotalEligibilityChecks", totalEligibilityChecks)
                        cmd.Parameters.AddWithValue("@TotalDonations", totalDonations)
                        cmd.Parameters.AddWithValue("@BloodComponent", bloodComponent)
                        cmd.Parameters.AddWithValue("@BloodVolume", bloodVolume)
                        cmd.Parameters.AddWithValue("@LastEligibilityDate", If(lastEligibilityDate Is Nothing, DBNull.Value, lastEligibilityDate))
                        cmd.Parameters.AddWithValue("@DonationDate", donationDate)
                        cmd.ExecuteNonQuery()
                    End Using
                Else
                    ' If history record does not exist, insert a new one
                    Dim historyInsertQuery As String = "" &
                "INSERT INTO history (DonorID, totalEligibilityCheck, totalDonation, " &
                "TotalBloodVolume_Wholeblood, TotalBloodVolume_Redblood, " &
                "TotalBloodVolume_Platelets, TotalBloodVolume_Plasma, " &
                "TotalBloodVolume_Whiteblood, LastName, FirstName, MiddleName, " &
                "TotalBloodVolume_all, DonorRegDate, LastEligibilityCheckDate, LatestDonationDate) " &
                "SELECT d.DonorID, @TotalEligibilityChecks, @TotalDonations, " &
                "IF(@BloodComponent = 'Whole Blood', @BloodVolume, 0), " &
                "IF(@BloodComponent = 'Red Blood Cells', @BloodVolume, 0), " &
                "IF(@BloodComponent = 'Platelets', @BloodVolume, 0), " &
                "IF(@BloodComponent = 'Plasma', @BloodVolume, 0), " &
                "IF(@BloodComponent = 'White Blood Cells', @BloodVolume, 0), " &
                "d.LastName, d.FirstName, d.MiddleName, @BloodVolume, d.RegDate, @LastEligibilityDate, @DonationDate " &
                "FROM donors d WHERE d.DonorID = @DonorID"

                    Using cmd As New MySqlCommand(historyInsertQuery, conn, transaction)
                        cmd.Parameters.AddWithValue("@DonorID", donorID)
                        cmd.Parameters.AddWithValue("@TotalEligibilityChecks", totalEligibilityChecks)
                        cmd.Parameters.AddWithValue("@TotalDonations", totalDonations)
                        cmd.Parameters.AddWithValue("@BloodComponent", bloodComponent)
                        cmd.Parameters.AddWithValue("@BloodVolume", bloodVolume)
                        cmd.Parameters.AddWithValue("@LastEligibilityDate", If(lastEligibilityDate Is Nothing, DBNull.Value, lastEligibilityDate))
                        cmd.Parameters.AddWithValue("@DonationDate", donationDate)
                        cmd.ExecuteNonQuery()
                    End Using
                End If

                transaction.Commit()
            Catch ex As Exception
                transaction.Rollback()
                Throw New Exception("Error inserting donation and updating history: " & ex.Message)
            End Try
        End Using
    End Sub


    Function GetAllDonorDetails() As List(Of DonorData)
        Dim donorList As New List(Of DonorData)()
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
                        donorList.Add(donor)
                    End While
                End Using
            End Using
        End Using

        Return donorList
    End Function


End Class

Public Class DonorData
    Public Property DonorID As Integer
    Public Property BloodComponent As String
    Public Property BloodVolume As Decimal
End Class

