Imports System.Reflection
Imports System.Windows.Forms
Public Class DoubleBuffering
    Public Sub EnableDoubleBuffering(dataGridView As DataGridView)
        Dim doubleBufferedProperty As PropertyInfo = GetType(DataGridView).GetProperty("DoubleBuffered", BindingFlags.NonPublic Or BindingFlags.Instance)
        If doubleBufferedProperty IsNot Nothing Then
            doubleBufferedProperty.SetValue(dataGridView, True, Nothing)
        End If
    End Sub

End Class
