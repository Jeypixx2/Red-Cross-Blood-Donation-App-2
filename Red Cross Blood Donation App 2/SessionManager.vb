Public Module SessionManager
    ' Store the currently logged-in user's information
    Public CurrentUserID As Integer = 0
    Public CurrentUserName As String = ""
    Public CurrentUserHospital As String = ""
    Public IsUserLoggedIn As Boolean = False

    ' Call this method when user successfully logs in
    Public Sub SetCurrentUser(userID As Integer, userName As String, hospitalName As String)
        CurrentUserID = userID
        CurrentUserName = userName
        CurrentUserHospital = hospitalName
        IsUserLoggedIn = True
    End Sub

    ' Call this method when user logs out
    Public Sub ClearCurrentUser()
        CurrentUserID = 0
        CurrentUserName = ""
        CurrentUserHospital = ""
        IsUserLoggedIn = False
    End Sub

    ' Get current user ID
    Public Function GetCurrentUserID() As Integer
        Return CurrentUserID
    End Function

    ' Check if user is logged in
    Public Function IsLoggedIn() As Boolean
        Return IsUserLoggedIn AndAlso CurrentUserID > 0
    End Function
End Module