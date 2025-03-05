Imports MySql.Data.MySqlClient

Public Class CreateSuperAdminAccount
    ' Variable to track password visibility
    Private isPasswordVisible As Boolean = False

    Private Sub CreateAccountForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initially mask the password
        txtPassword.UseSystemPasswordChar = True
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Retrieve username and password from TextBox controls
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        ' Validate input
        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please fill in both Username and Password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Encrypt the password
        Dim encryptedPassword As String = Encrypt(password)

        ' Query to insert data into the admin_account table
        Dim query As String = "INSERT INTO accountssuperadmin (username, password, dt_created) VALUES (@username, @password, @dt_created)"
        Try
            Using cmd As New MySqlCommand(query, conn)
                ' Add parameters to the query
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", encryptedPassword) ' Store encrypted password
                cmd.Parameters.AddWithValue("@dt_created", DateTime.Now) ' Use current date and time

                ' Open connection
                openConn(db_name)

                ' Execute the query
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Show the Admin_Access form
                    SuperAdmin_Access.Show()

                    Me.Close() ' Close the CreateAccountForm
                Else
                    MessageBox.Show("Failed to create account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error creating account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn?.Close()
        End Try
    End Sub



    ' Event handler for the "Show Password" button
    Private Sub btnShowPassword_Click(sender As Object, e As EventArgs) Handles btnShowPassword.Click
        ' Toggle password visibility
        isPasswordVisible = Not isPasswordVisible
        txtPassword.UseSystemPasswordChar = Not isPasswordVisible

        ' Update button text or icon based on visibility
        btnShowPassword.Text = If(isPasswordVisible, "Hide", "Show")
    End Sub
End Class
