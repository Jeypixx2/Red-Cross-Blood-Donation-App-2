Imports MySql.Data.MySqlClient

Public Class HealthCare_Access

    Private Sub HealthCare_Access_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txthealthcarepassword.PasswordChar = "*"
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Retrieve username and password from TextBox controls
        Dim username As String = txthealthcareaccount.Text.Trim()
        Dim password As String = txthealthcarepassword.Text

        ' Validate inputs
        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please enter both username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Encrypt the entered password
        Dim encryptedPassword As String = modDB.Encrypt(password)

        ' Query to check credentials and get user details
        Dim query As String = "SELECT * FROM healthprovideraccounts WHERE username = @username AND password = @password"

        Try
            Using cmd As New MySqlCommand(query, modDB.conn)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", encryptedPassword)
                modDB.openConn(modDB.db_name)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        ' Check if account is verified
                        Dim isVerified As Boolean = Convert.ToBoolean(reader("IsVerified"))
                        If Not isVerified Then
                            MessageBox.Show("Your account is pending verification. Please wait for administrator approval.",
                                  "Account Not Verified", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txthealthcarepassword.Clear()
                            Return
                        End If

                        ' Login successful - Read all needed values while reader is active
                        Dim providerId As Integer = reader.GetInt32("HCPid")
                        Dim firstName As String = reader.GetString("fname")
                        Dim lastName As String = reader.GetString("lname")
                        Dim affiliatedInstitution As String = reader("AffiliatedInstitutionName").ToString()
                        Dim userPosition As String = "Healthcare Provider"
                        Dim userType As Integer = 3 ' Type 3 for healthcare provider

                        ' Set the CurrentLoggedUser structure
                        modDB.CurrentLoggedUser = New modDB.LoggedUser With {
                        .id = providerId,
                        .name = $"{firstName} {lastName}",
                        .position = userPosition,
                        .username = username,
                        .password = encryptedPassword,
                        .type = userType
                    }

                        ' Close the reader before calling UpdateLastLoginDate
                        reader.Close()

                        ' Update LastLoginDate
                        UpdateLastLoginDate(providerId)

                        ' Log the login event
                        modDB.Logs("Healthcare Provider logged in")

                        MessageBox.Show("Login successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Clear the password field
                        txthealthcarepassword.Clear()

                        ' Show Healthcare Dashboard using the stored value
                        Dim dashboard As New HealthCare_Dashboard(affiliatedInstitution, $"{firstName} {lastName}")
                        dashboard.Show()
                        Me.Hide()
                    Else
                        ' Login failed
                        MessageBox.Show("Invalid username or password.", "Login Failed",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txthealthcarepassword.Clear()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error during login: {ex.Message}", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            modDB.conn?.Close()
        End Try
    End Sub

    Private Sub UpdateLastLoginDate(providerId As Integer)
        Try
            Dim updateQuery As String = "UPDATE healthprovideraccounts SET LastLoginDate = @lastLoginDate " &
                                  "WHERE HCPid = @providerId"

            Using cmd As New MySqlCommand(updateQuery, modDB.conn)
                cmd.Parameters.AddWithValue("@lastLoginDate", DateTime.Now)
                cmd.Parameters.AddWithValue("@providerId", providerId)

                If modDB.conn.State = ConnectionState.Closed Then
                    modDB.conn.Open()
                End If

                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            ' Log the error but don't stop the login process
            modDB.Logs($"Error updating last login date: {ex.Message}")
        End Try
    End Sub

    Private Sub btnAdmin_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        Me.Hide()
        Start.Show()
    End Sub

    Private Sub BtnCreateAccount_Click(sender As Object, e As EventArgs) Handles BtnCreateAccount.Click
        HealthCare_NewAccount.Show()
    End Sub

End Class
