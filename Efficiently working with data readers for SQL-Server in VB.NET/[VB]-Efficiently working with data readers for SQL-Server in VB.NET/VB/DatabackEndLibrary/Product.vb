Public Class Product
    Public Property ProductId As Integer
    Public Property ProductName As String
    Public Property CategoryID As Integer
    Public Overrides Function ToString() As String
        Return ProductName
    End Function
End Class
