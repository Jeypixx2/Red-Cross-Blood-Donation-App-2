' Start.vb (Main Form)
Imports System.Data.SqlClient

Public Class Start
    Public frmhelper As New FormHelper

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the connection (if needed)
        UpdateConnectionString()
        openConn("redcrossdb") ' Specify database name directly if db_name is undefined
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        Me.Hide()
        Admin_Access.Show()
    End Sub

    Private Sub btnHealthcareprovider_Click(sender As Object, e As EventArgs) Handles btnHealthcareprovider.Click
        Me.Hide()
        HealthCare_Access.Show()
    End Sub

End Class

' DonorSummary.vb (Separate Class File)
Public Class DonorSummary
    ' Define your connection string (use your actual connection string)
    Dim connectionString As String = "Server=localhost;Database=redcrossdb;Uid=root;Pwd=;"

    Public Sub GetDonorSummaryAndInsertToHistory(donorID As Integer)
        ' Create the SQL query to get the required data
        Dim query As String = "
        SELECT 
            d.DonorID,
            SUM(e.EligibilityCheck) AS TotalEligibilityCheck,
            COUNT(DISTINCT don.DonationID) AS TotalDonation,
            SUM(don.BloodVolume_Wholeblood) AS TotalBloodVolume_Wholeblood,
            SUM(don.BloodVolume_Redblood) AS TotalBloodVolume_Redblood,
            SUM(don.BloodVolume_Platelets) AS TotalBloodVolume_Platelets,
            SUM(don.BloodVolume_Plasma) AS TotalBloodVolume_Plasma,
            SUM(don.BloodVolume_Whiteblood) AS TotalBloodVolume_Whiteblood,
            d.LastName,
            d.FirstName,
            d.MiddleName,
            SUM(don.BloodVolume_Wholeblood + don.BloodVolume_Redblood + don.BloodVolume_Platelets + don.BloodVolume_Plasma + don.BloodVolume_Whiteblood) AS TotalBloodVolume_All,
            d.DonorRegDate,
            MAX(e.LastEligibilityCheckDate) AS LastEligibilityCheckDate,
            MAX(don.DonationDate) AS LatestDonationDate
        FROM Donors d
        LEFT JOIN Eligibility e ON d.DonorID = e.DonorID
        LEFT JOIN Donations don ON d.DonorID = don.DonorID
        WHERE d.DonorID = @DonorID
        GROUP BY d.DonorID, d.LastName, d.FirstName, d.MiddleName, d.DonorRegDate"

        ' Establish a connection to the database
        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()

                ' Create a command to execute the SQL query
                Using cmd As New SqlCommand(query, conn)
                    ' Add the parameter for DonorID to prevent SQL injection
                    cmd.Parameters.AddWithValue("@DonorID", donorID)

                    ' Execute the query and retrieve the data
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            While reader.Read()
                                ' Retrieve the data from the reader
                                Dim retrievedDonorId = reader("DonorID")
                                Dim totalEligibilityCheck = reader("TotalEligibilityCheck")
                                Dim totalDonation = reader("TotalDonation")
                                Dim totalBloodVolumeWholeblood = reader("TotalBloodVolume_Wholeblood")
                                Dim totalBloodVolumeRedblood = reader("TotalBloodVolume_Redblood")
                                Dim totalBloodVolumePlatelets = reader("TotalBloodVolume_Platelets")
                                Dim totalBloodVolumePlasma = reader("TotalBloodVolume_Plasma")
                                Dim totalBloodVolumeWhiteblood = reader("TotalBloodVolume_Whiteblood")
                                Dim lastName = reader("LastName")
                                Dim firstName = reader("FirstName")
                                Dim middleName = reader("MiddleName")
                                Dim totalBloodVolumeAll = reader("TotalBloodVolume_All")
                                Dim donorRegDate = reader("DonorRegDate")
                                Dim lastEligibilityCheckDate = reader("LastEligibilityCheckDate")
                                Dim latestDonationDate = reader("LatestDonationDate")

                                ' Prepare the SQL INSERT statement for the History table
                                Dim insertQuery As String = "
INSERT INTO History (
    DonorID,
    TotalEligibilityCheck,
    TotalDonation,
    TotalBloodVolume_Wholeblood,
    TotalBloodVolume_Redblood,
    TotalBloodVolume_Platelets,
    TotalBloodVolume_Plasma,
    TotalBloodVolume_Whiteblood,
    LastName,
    FirstName,
    MiddleName,
    TotalBloodVolume_All,
    DonorRegDate,
    LastEligibilityCheckDate,
    LatestDonationDate
) VALUES (
    @DonorID,
    @TotalEligibilityCheck,
    @TotalDonation,
    @TotalBloodVolume_Wholeblood,
    @TotalBloodVolume_Redblood,
    @TotalBloodVolume_Platelets,
    @TotalBloodVolume_Plasma,
    @TotalBloodVolume_Whiteblood,
    @LastName,
    @FirstName,
    @MiddleName,
    @TotalBloodVolume_All,
    @DonorRegDate,
    @LastEligibilityCheckDate,
    @LatestDonationDate
)"

                                ' Create the insert command
                                Using insertCmd As New SqlCommand(insertQuery, conn)
                                    ' Add parameters to the insert command
                                    insertCmd.Parameters.AddWithValue("@DonorID", retrievedDonorId)
                                    insertCmd.Parameters.AddWithValue("@TotalEligibilityCheck", totalEligibilityCheck)
                                    insertCmd.Parameters.AddWithValue("@TotalDonation", totalDonation)
                                    insertCmd.Parameters.AddWithValue("@TotalBloodVolume_Wholeblood", totalBloodVolumeWholeblood)
                                    insertCmd.Parameters.AddWithValue("@TotalBloodVolume_Redblood", totalBloodVolumeRedblood)
                                    insertCmd.Parameters.AddWithValue("@TotalBloodVolume_Platelets", totalBloodVolumePlatelets)
                                    insertCmd.Parameters.AddWithValue("@TotalBloodVolume_Plasma", totalBloodVolumePlasma)
                                    insertCmd.Parameters.AddWithValue("@TotalBloodVolume_Whiteblood", totalBloodVolumeWhiteblood)
                                    insertCmd.Parameters.AddWithValue("@LastName", lastName)
                                    insertCmd.Parameters.AddWithValue("@FirstName", firstName)
                                    insertCmd.Parameters.AddWithValue("@MiddleName", middleName)
                                    insertCmd.Parameters.AddWithValue("@TotalBloodVolume_All", totalBloodVolumeAll)
                                    insertCmd.Parameters.AddWithValue("@DonorRegDate", donorRegDate)
                                    insertCmd.Parameters.AddWithValue("@LastEligibilityCheckDate", lastEligibilityCheckDate)
                                    insertCmd.Parameters.AddWithValue("@LatestDonationDate", latestDonationDate)

                                    ' Execute the insert command and check for any errors
                                    Try
                                        insertCmd.ExecuteNonQuery()
                                        Console.WriteLine("Data inserted successfully!")
                                    Catch ex As Exception
                                        ' Output the error message if something goes wrong
                                        Console.WriteLine("Error inserting data: " & ex.Message)
                                    End Try
                                End Using

                            End While
                        Else
                            Console.WriteLine("No data found for the specified DonorID.")
                        End If
                    End Using
                End Using

            Catch ex As Exception
                ' Handle any errors that might occur
                Console.WriteLine($"Error: {ex.Message}")
            End Try
        End Using
    End Sub
End Class
