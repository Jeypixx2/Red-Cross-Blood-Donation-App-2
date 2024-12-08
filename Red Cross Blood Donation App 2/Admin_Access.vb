Imports MySql.Data.MySqlClient

Public Class Admin_Access
    Private Sub Admin_Access_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Check if the admin_account table is empty
        Dim query As String = "SELECT COUNT(*) FROM accounts"
        Try
            readQuery(query)
            If cmdRead.Read() AndAlso cmdRead.GetInt32(0) = 0 Then
                createAcc.Visible = True ' Show "Create Account" label if table is empty
            Else
                createAcc.Visible = True ' Hide "Create Account" label if table has records
            End If
        Catch ex As Exception
            MessageBox.Show($"Error loading admin_account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cmdRead?.Close()
            conn?.Close()
        End Try
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Retrieve username and password from TextBox controls
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        ' Validate username and password
        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please enter both username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Hardcoded check for SuperAdmin
        If username = "admin" AndAlso password = "admin" Then
            MessageBox.Show("SuperAdmin login successful!", "Welcome SuperAdmin", MessageBoxButtons.OK, MessageBoxIcon.Information)
            SuperAdmin.Show() ' Show SuperAdmin Dashboard
            Me.Hide() ' Hide Login Form
            Exit Sub
        End If

        ' Encrypt the entered password
        Dim encryptedPassword As String = Encrypt(password)

        ' Query to check if username and password match a record in admin_account
        Dim query As String = "SELECT COUNT(*) FROM admin_account WHERE username = @username AND password = @password"
        Try
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", encryptedPassword) ' Use encrypted password
                openConn(db_name)

                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                If count > 0 Then
                    ' Login successful
                    MessageBox.Show("Login successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Admin_Dashboard.Show() ' Show Admin Dashboard
                    Me.Hide() ' Hide Login Form
                Else
                    ' Login failed
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtPassword.Text = String.Empty ' Clear the password field
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error during login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn?.Close()
        End Try
    End Sub


    Private Sub createAcc_Click(sender As Object, e As EventArgs) Handles createAcc.Click
        Dim createAccountForm As New CreateAccountForm()
        createAccountForm.Show()
        Me.Hide()
    End Sub
End Class
