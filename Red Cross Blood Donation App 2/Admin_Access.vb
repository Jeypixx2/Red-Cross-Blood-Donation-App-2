Public Class Admin_Access

    ' Login button click event
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        ' Check if Username and Password are correct
        If txtUsername.Text = "admin" And txtPassword.Text = "admin" Then
            MessageBox.Show("Login successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Try to show Form4
            Try
                Admin_Dashboard.Show() ' Show Form4
                Me.Hide() ' Hide Form2
            Catch ex As Exception
                MessageBox.Show("Error displaying Form4: " & ex.Message) ' Catch any error in loading Form4
            End Try
        Else
            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Reset password field
            txtPassword.Text = "Password"
            txtPassword.ForeColor = Color.Gray
            txtPassword.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub Admin_Access_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub pbLogo_Click(sender As Object, e As EventArgs) Handles pbLogo.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged

    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

    End Sub
End Class
