Imports System.IO

Public Module ConfigReader
    Public ConfigSettings As New Dictionary(Of String, String)

    Public Sub ReadConfig()
        ' Get the path of config.txt located in the bin directory
        Dim configPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt")

        ' Check if the file exists
        If File.Exists(configPath) Then
            ' Read all lines from the file
            Dim lines() As String = File.ReadAllLines(configPath)

            ' Parse config file and store values in dictionary
            For Each line As String In lines
                If line.Contains("=") Then
                    Dim parts() As String = line.Split("="c)
                    If parts.Length = 2 Then
                        ConfigSettings(parts(0).Trim()) = parts(1).Trim()
                    End If
                End If
            Next
        Else
            MessageBox.Show("Error: config.txt not found in bin directory.", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Module
