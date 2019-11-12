Public Class Customer
    Public Property Identifier As Integer
    Public Property CompanyName As String
    Public Property ContactName As String
    Public Property ContactTitle As String
    Public Property Address As String
    Public Property City As String
    Public Property PostalCode As String
    Public Property Exists As Boolean

    Public Sub New()
    End Sub
    Public ReadOnly Property AlreadyExistsData As String
        Get
            Return String.Format("Already exists:'{0}','{1}','{2}','{3}','{4}','{5}'", CompanyName, ContactName, ContactTitle, Address, City, PostalCode)
        End Get
    End Property
    Public ReadOnly Property DoesNotExistsData As String
        Get
            Return String.Format("Okay to add:'{0}','{1}','{2}','{3}','{4}','{5}'", CompanyName, ContactName, ContactTitle, Address, City, PostalCode)
        End Get
    End Property
    ''' <summary>
    ''' Used for demoing if a record exists
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Return String.Format("'{0}' '{1}' '{2}' '{3}' '{4}' '{5}'", CompanyName, ContactName, ContactTitle, Address, City, PostalCode)
    End Function
End Class
