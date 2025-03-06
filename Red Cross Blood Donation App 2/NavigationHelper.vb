Module NavigationHelper
    Public FormHistory As New Stack(Of Form)

    ' Function to navigate back to the previous form
    Public Sub GoBack(currentForm As Form)
        If FormHistory.Count > 0 Then
            Dim previousForm As Form = FormHistory.Pop()
            previousForm.Show()
            currentForm.Close() ' Close the current form instead of hiding it
        Else
            MessageBox.Show("No previous form found!", "Navigation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Module
