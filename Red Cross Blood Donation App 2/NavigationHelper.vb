Module NavigationHelper
    Public FormHistory As New Stack(Of Form)

    ' Function to navigate back to the previous form
    Public Sub GoBack(currentForm As Form)
        If FormHistory.Count > 0 Then
            Dim previousForm As Form = FormHistory.Pop()
            previousForm.Show()
            'currentForm.Close() ' Close the current form instead of hiding it
        Else
            MessageBox.Show("No previous form found!", "Navigation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' Function to open a new form dynamically
    Public Sub OpenNewForm(currentForm As Form, newForm As Form)
        FormHistory.Push(currentForm) ' Store the current form before navigating
        newForm.Show()
        'currentForm.Hide()
    End Sub
End Module
