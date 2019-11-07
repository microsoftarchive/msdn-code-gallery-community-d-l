Public Class Customer
    Public Property Id As Integer
    Public Property FirstName As String
    Public Property LastName As String
    Public Property Address As String
    Public Property City As String
    Public Property State As String
    Public Property ZipCode As String
    Public Property JoinDate As DateTime
    Public Property Pin As Integer
    Public Property Balance As Double
    Public Overrides Function ToString() As String
        Return $"{FirstName} {LastName}"
    End Function
End Class
