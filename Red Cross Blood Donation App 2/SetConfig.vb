Imports System.IO

Public Class SetConfig
    Private Sub SetConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Read the config file on form load
        ReadConfig()

        ' Display details in textboxes
        If ConfigSettings.ContainsKey("server") Then
            ServerTextBox.Text = ConfigSettings("server")
        End If
        If ConfigSettings.ContainsKey("uid") Then
            UIDTextBox.Text = ConfigSettings("uid")
        End If
        If ConfigSettings.ContainsKey("password") Then
            PasswordTextBox.Text = ConfigSettings("password")
        End If
        If ConfigSettings.ContainsKey("database") Then
            DatabaseTextBox.Text = ConfigSettings("database")
        End If
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        ' Get values from textboxes
        Dim newServer As String = ServerTextBox.Text.Trim()
        Dim newUID As String = UIDTextBox.Text.Trim()
        Dim newPassword As String = PasswordTextBox.Text.Trim()
        Dim newDatabase As String = DatabaseTextBox.Text.Trim()

        ' Get the path of config.txt
        Dim configPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt")

        ' Create or overwrite config.txt with new values
        Try
            Using writer As New StreamWriter(configPath)
                writer.WriteLine("server=" & newServer)
                writer.WriteLine("uid=" & newUID)
                writer.WriteLine("password=" & newPassword)
                writer.WriteLine("database=" & newDatabase)
            End Using

            ' Reload the new configuration
            ReadConfig()

            ' Notify user of success
            MessageBox.Show("Configuration updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error saving configuration: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Close()
    End Sub
End Class
