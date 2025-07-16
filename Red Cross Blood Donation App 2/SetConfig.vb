Imports System.IO

Public Class SetConfig
    ' Dictionary to store configuration settings
    Private ConfigSettings As New Dictionary(Of String, String)

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

    Private Sub ReadConfig()
        Try
            ConfigSettings.Clear()
            Dim configPath As String = GetConfigFilePath()

            If File.Exists(configPath) Then
                Dim lines() As String = File.ReadAllLines(configPath)
                For Each line As String In lines
                    If line.Contains("=") Then
                        Dim parts() As String = line.Split({"="c}, 2)
                        If parts.Length = 2 Then
                            ConfigSettings(parts(0).Trim()) = parts(1).Trim()
                        End If
                    End If
                Next
            Else
                ' Create default config if it doesn't exist
                CreateDefaultConfig(configPath)
                ' Read the newly created config
                ReadConfig()
            End If
        Catch ex As Exception
            MessageBox.Show("Error reading configuration: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub CreateDefaultConfig(configPath As String)
        Try
            ' Ensure directory exists
            Dim configDirectory As String = Path.GetDirectoryName(configPath)
            If Not Directory.Exists(configDirectory) Then
                Directory.CreateDirectory(configDirectory)
            End If

            ' Create default config
            Using writer As New StreamWriter(configPath)
                writer.WriteLine("server=localhost")
                writer.WriteLine("uid=root")
                writer.WriteLine("password=")
                writer.WriteLine("database=redcrossdb")
            End Using

            MessageBox.Show("Default configuration file created at: " & configPath, "Config Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error creating default config: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        ' Get values from textboxes
        Dim newServer As String = ServerTextBox.Text.Trim()
        Dim newUID As String = UIDTextBox.Text.Trim()
        Dim newPassword As String = PasswordTextBox.Text.Trim()
        Dim newDatabase As String = DatabaseTextBox.Text.Trim()

        ' Get the path of config.txt
        Dim configPath As String = GetConfigFilePath()

        ' Create or overwrite config.txt with new values
        Try
            ' Ensure the directory exists
            Dim configDirectory As String = Path.GetDirectoryName(configPath)
            If Not Directory.Exists(configDirectory) Then
                Directory.CreateDirectory(configDirectory)
            End If

            Using writer As New StreamWriter(configPath)
                writer.WriteLine("server=" & newServer)
                writer.WriteLine("uid=" & newUID)
                writer.WriteLine("password=" & newPassword)
                writer.WriteLine("database=" & newDatabase)
            End Using

            ' Reload the new configuration
            ReadConfig()

            ' Notify user of success
            MessageBox.Show("Configuration updated successfully!" & Environment.NewLine & "Config saved to: " & configPath, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error saving configuration: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Close()
    End Sub

    Private Function GetConfigFilePath() As String
        ' For installed applications, use AppData folder
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim appConfigFolder As String = Path.Combine(appDataPath, "Red Cross Blood Donation App", "Config")
        Dim appDataConfigPath As String = Path.Combine(appConfigFolder, "config.txt")

        ' Check if config exists in AppData first (for installed apps)
        If File.Exists(appDataConfigPath) Then
            Return appDataConfigPath
        End If

        ' Check in application directory (for development/portable)
        Dim appDirConfigPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt")
        If File.Exists(appDirConfigPath) Then
            Return appDirConfigPath
        End If

        ' Check in Config subfolder of application directory
        Dim configSubfolderPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "config.txt")
        If File.Exists(configSubfolderPath) Then
            Return configSubfolderPath
        End If

        ' Default to AppData location for new config files (best for installed apps)
        Return appDataConfigPath
    End Function
End Class
