Imports MySql.Data.MySqlClient

Public Class HealthCare_Access
    ' Temporary storage for the hospital and personnel names
    Private hospitalName As String
    Private personnelName As String

    Private Sub HealthCare_Access_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect() ' Calls Connect() from MySQLModule to establish a connection to the database
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Store the input data in variables
        hospitalName = txtHospitalName.Text
        personnelName = txtNameAquirer.Text

        ' Check if the Hospital and Personnel already exist
        Dim existingIDs = GetHealthProviderAndPersonnelID(hospitalName, personnelName)

        If existingIDs.Item1 <> -1 AndAlso existingIDs.Item2 <> -1 Then
            MessageBox.Show("Record already exists. Using existing HealthProviderID and PersonnelID.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("New record detected. Data will be passed to the next form.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        ' Pass the data to the dashboard without saving
        Dim dashboard As New HealthCare_Dashboard(hospitalName, personnelName)
        Me.Hide()
        dashboard.Show()
    End Sub

    ' Function to check if Hospital and Personnel exist, retrieve or increment IDs
    Public Function GetHealthProviderAndPersonnelID(hospitalName As String, personnelName As String) As Tuple(Of Integer, Integer)
        Dim healthProviderID As Integer = -1
        Dim personnelID As Integer = -1

        Try
            ' Get the HealthProviderID based on hospital name
            Dim sqlProviderID As String = "SELECT HealthProviderID FROM Healthprovider WHERE CompanyHospitalName = @CompanyHospitalName LIMIT 1"
            Using cmd As New MySqlCommand(sqlProviderID, conn)
                If conn.State = ConnectionState.Closed Then conn.Open()
                cmd.Parameters.AddWithValue("@CompanyHospitalName", hospitalName)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        healthProviderID = dr.GetInt32("HealthProviderID") ' Existing ID or 1 if not found
                    End If
                End Using
            End Using

            ' Get the PersonnelID for the given hospital and personnel name
            Dim sqlPersonnelID As String = "SELECT PersonnelID FROM Healthprovider WHERE CompanyHospitalName = @CompanyHospitalName AND PersonnelName = @PersonnelName LIMIT 1"
            Using cmd As New MySqlCommand(sqlPersonnelID, conn)
                cmd.Parameters.AddWithValue("@CompanyHospitalName", hospitalName)
                cmd.Parameters.AddWithValue("@PersonnelName", personnelName)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        personnelID = dr.GetInt32("PersonnelID") ' Existing ID or 1 if not found
                    End If
                End Using
            End Using

            ' If IDs are not found, you can let MySQL auto-increment when inserting new records.
            If healthProviderID = -1 Then
                healthProviderID = 1 ' Start with 1 if not found (you can let MySQL handle this when inserting)
            Else
                healthProviderID = +1
            End If

            If personnelID = -1 Then
                personnelID = 1 ' Start with 1 if not found (you can let MySQL handle this when inserting)
            Else
                personnelID = +1
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while checking IDs: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Tuple.Create(healthProviderID, personnelID)
    End Function


End Class