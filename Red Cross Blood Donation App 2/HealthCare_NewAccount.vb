Imports MySql.Data.MySqlClient

Public Class HealthCare_NewAccount

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Try
            ' Validate required fields
            If String.IsNullOrEmpty(txtLname.Text.Trim()) OrElse
               String.IsNullOrEmpty(txtFname.Text.Trim()) OrElse
               String.IsNullOrEmpty(txtEmail.Text.Trim()) OrElse
               String.IsNullOrEmpty(txtProfession.Text.Trim()) OrElse
               String.IsNullOrEmpty(txtPRCLicenseNumber.Text.Trim()) OrElse
               String.IsNullOrEmpty(txtAffiliatedInstitutionName.Text.Trim()) Then
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Prompt for username and password
            Dim username As String = InputBox("Enter username:", "Create Account")
            If String.IsNullOrEmpty(username) Then
                MessageBox.Show("Username is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Check if username already exists
            Dim checkQuery As String = "SELECT COUNT(*) FROM healthprovideraccounts WHERE username = @username"
            Using cmd As New MySqlCommand(checkQuery, modDB.conn)
                cmd.Parameters.AddWithValue("@username", username)
                modDB.openConn(modDB.db_name)
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                If count > 0 Then
                    MessageBox.Show("Username already exists. Please choose a different username.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End Using

            Dim password As String = InputBox("Enter password:", "Create Account")
            If String.IsNullOrEmpty(password) Then
                MessageBox.Show("Password is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim confirmPassword As String = InputBox("Confirm password:", "Create Account")
            If password <> confirmPassword Then
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Insert the new account
            Dim insertQuery As String = "INSERT INTO healthprovideraccounts " &
                "(username, password, lname, fname, mname, suffix, birthdate, gender, " &
                "email, mobilenumber, profession, PRCLicenseNumber, PRCIssuanceDate, " &
                "PRCExpiryDate, AffiliatedInstitutionName, AffiliatedInstitutionDOHLTO, " &
                "Department, IsVerified, VerificationDate, CreatedDate) " &
                "VALUES (@username, @password, @lname, @fname, @mname, @suffix, @birthdate, " &
                "@gender, @email, @mobilenumber, @profession, @PRCLicenseNumber, " &
                "@PRCIssuanceDate, @PRCExpiryDate, @AffiliatedInstitutionName, " &
                "@AffiliatedInstitutionDOHLTO, @Department, @IsVerified, @VerificationDate, @CreatedDate)"

            Using cmd As New MySqlCommand(insertQuery, modDB.conn)
                ' Set parameters
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", modDB.Encrypt(password))
                cmd.Parameters.AddWithValue("@lname", txtLname.Text.Trim())
                cmd.Parameters.AddWithValue("@fname", txtFname.Text.Trim())
                cmd.Parameters.AddWithValue("@mname", If(String.IsNullOrEmpty(txtMname.Text), DBNull.Value, txtMname.Text.Trim()))
                cmd.Parameters.AddWithValue("@suffix", If(String.IsNullOrEmpty(txtSuffix.Text), DBNull.Value, txtSuffix.Text.Trim()))
                cmd.Parameters.AddWithValue("@birthdate", dtpBirthdate.Value)
                cmd.Parameters.AddWithValue("@gender", If(String.IsNullOrEmpty(txtGender.Text), DBNull.Value, txtGender.Text.Trim()))
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim())
                cmd.Parameters.AddWithValue("@mobilenumber", If(String.IsNullOrEmpty(txtMobileNumber.Text), DBNull.Value, txtMobileNumber.Text.Trim()))
                cmd.Parameters.AddWithValue("@profession", txtProfession.Text.Trim())
                cmd.Parameters.AddWithValue("@PRCLicenseNumber", txtPRCLicenseNumber.Text.Trim())
                cmd.Parameters.AddWithValue("@PRCIssuanceDate", dtpPRCIssuanceDate.Value)
                cmd.Parameters.AddWithValue("@PRCExpiryDate", dtpPRCExpiryDate.Value)
                cmd.Parameters.AddWithValue("@AffiliatedInstitutionName", txtAffiliatedInstitutionName.Text.Trim())
                cmd.Parameters.AddWithValue("@AffiliatedInstitutionDOHLTO", If(String.IsNullOrEmpty(txtAffiliatedInstitutionDOHLTO.Text), DBNull.Value, txtAffiliatedInstitutionDOHLTO.Text.Trim()))
                cmd.Parameters.AddWithValue("@Department", txtDepartment.Text.Trim())
                cmd.Parameters.AddWithValue("@IsVerified", 0) ' Default to not verified
                cmd.Parameters.AddWithValue("@VerificationDate", DBNull.Value)
                cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now)

                If modDB.conn.State = ConnectionState.Closed Then
                    modDB.conn.Open()
                End If

                cmd.ExecuteNonQuery()

                ' Log the account creation
                modDB.Logs("Created new healthcare provider account")

                MessageBox.Show("Account created successfully! Please wait for account verification.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Return to healthcare access form
                Me.Hide()
                HealthCare_Access.Show()
            End Using

        Catch ex As Exception
            MessageBox.Show("Error creating account: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If modDB.conn.State = ConnectionState.Open Then
                modDB.conn.Close()
            End If
        End Try
    End Sub
End Class