Imports MySql.Data.MySqlClient

Public Class HealthCare_Access
    ' Temporary storage for the hospital and personnel names
    Private hospitalName As String
    Private personnelName As String

    Private Sub HealthCare_Access_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateConnectionString()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Store the input data in variables
        hospitalName = txtHospitalName.Text.Trim() ' Trim input to avoid leading/trailing spaces
        personnelName = txtNameAquirer.Text.Trim()

        ' Ensure that both fields are filled before proceeding
        If String.IsNullOrEmpty(hospitalName) OrElse String.IsNullOrEmpty(personnelName) Then
            MessageBox.Show("Please enter both Hospital Name and Personnel Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Debugging: Show the captured values in a message box
        MessageBox.Show($"Hospital Name: {hospitalName}, Personnel Name: {personnelName}", "Debugging", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Check if the Hospital and Personnel already exist
        Dim existingIDs = GetHealthProviderAndPersonnelID(hospitalName, personnelName)

        If existingIDs.Item1 <> -1 AndAlso existingIDs.Item2 <> -1 Then
            MessageBox.Show("Record already exists. Using existing HealthProviderID and PersonnelID.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("New record detected. Data will be passed to the next form.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        ' Set the CurrentLoggedUser structure
        modDB.CurrentLoggedUser = New modDB.LoggedUser With {
            .id = existingIDs.Item1,
            .name = personnelName,
            .position = "Health Provider",
            .username = hospitalName,
            .password = String.Empty,
            .type = 3
        }

        ' Log the login event
        modDB.Logs("Health Provider logged in")

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
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' Get HealthProviderID first
            Dim sqlProviderID As String = "SELECT HealthProviderID FROM Healthprovider WHERE CompanyHospitalName = @CompanyHospitalName LIMIT 1"
            Using cmdProvider As New MySqlCommand(sqlProviderID, conn)
                cmdProvider.Parameters.AddWithValue("@CompanyHospitalName", hospitalName)
                Using drProvider As MySqlDataReader = cmdProvider.ExecuteReader()
                    If drProvider.Read() Then
                        healthProviderID = drProvider.GetInt32("HealthProviderID")
                    End If
                End Using ' Reader automatically closed here
            End Using

            ' Now get PersonnelID
            Dim sqlPersonnelID As String = "SELECT PersonnelID FROM Healthprovider WHERE CompanyHospitalName = @CompanyHospitalName AND PersonnelName = @PersonnelName LIMIT 1"
            Using cmdPersonnel As New MySqlCommand(sqlPersonnelID, conn)
                cmdPersonnel.Parameters.AddWithValue("@CompanyHospitalName", hospitalName)
                cmdPersonnel.Parameters.AddWithValue("@PersonnelName", personnelName)
                Using drPersonnel As MySqlDataReader = cmdPersonnel.ExecuteReader()
                    If drPersonnel.Read() Then
                        personnelID = drPersonnel.GetInt32("PersonnelID")
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("An error occurred while checking IDs: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try

        Return Tuple.Create(healthProviderID, personnelID)
    End Function



    Private Sub btnAdmin_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        Me.Hide()
        Start.Show()
    End Sub
End Class
