Imports MySql.Data.MySqlClient

Module MySQLModule
    Public myadocon, conn As New MySqlConnection
    Public cmd As New MySqlCommand
    Public cmdRead As MySqlDataReader

    Public db_server As String = "localhost"
    Public db_uid As String = "root"
    Public db_pwd As String = ""
    Public db_name As String = "redcrossdb"

    ' Initial connection string '
    Public strConnection As String = String.Format("server={0};uid={1};password={2};database={3};allowuservariables='True'", db_server, db_uid, db_pwd, db_name)

    ' Update connection string from external file '
    Public Sub UpdateConnectionString()
        Try
            Dim currentDir As String = System.IO.Directory.GetCurrentDirectory()

            ' Navigate up three directories '
            For i As Integer = 1 To 3
                currentDir = System.IO.Directory.GetParent(currentDir).FullName
            Next

            Dim config As String = System.IO.Path.Combine(currentDir, "dbconfig.txt")

            If System.IO.File.Exists(config) Then
                Using reader As New System.IO.StreamReader(config)
                    Dim text As String = reader.ReadToEnd()
                    Dim arr_text() As String = Split(text, vbCrLf)

                    db_server = Split(arr_text(0), "=")(1).Trim()
                    db_uid = Split(arr_text(1), "=")(1).Trim()
                    db_pwd = Split(arr_text(2), "=")(1).Trim()
                    db_name = Split(arr_text(3), "=")(1).Trim()

                    strConnection = String.Format("server={0};uid={1};password={2};database={3};allowuservariables='True'", db_server, db_uid, db_pwd, db_name)
                End Using
            Else
                MsgBox("Configuration file does not exist.", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("Error updating connection string: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' Establish connection to the database '
    Public Sub Connect()
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If

            ' Use updated connection string '
            conn.ConnectionString = strConnection
            conn.Open()
            MsgBox("Connected to the Database!")
        Catch ex As Exception
            MsgBox("Can't connect to database: " & ex.Message, MsgBoxStyle.Critical)
            conn.Close()
        End Try
    End Sub
End Module
