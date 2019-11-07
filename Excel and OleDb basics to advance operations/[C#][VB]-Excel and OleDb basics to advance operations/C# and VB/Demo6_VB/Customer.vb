
Public Class Customer
    Public Property FirstName As String
    Public Property LastName As String
    Public Property JoinedYear As Integer

    Public Sub New()

    End Sub

End Class
Public Class Customers
    Public Sub New()

    End Sub
    Public ReadOnly Property List As List(Of Customer)
        Get
            Dim CustomerList As New List(Of Customer) From
                {
                    New Customer With {.FirstName = "Karen", .LastName = "Payne", .JoinedYear = 2001},
                    New Customer With {.FirstName = "Sam", .LastName = "Davis", .JoinedYear = 1999},
                    New Customer With {.FirstName = "Ann", .LastName = "Smith", .JoinedYear = 2014},
                    New Customer With {.FirstName = "Jim", .LastName = "Jenkins", .JoinedYear = 2009}
                }


            Return CustomerList

        End Get
    End Property
End Class