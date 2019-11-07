
Public Class GetFilteredCustomers

    Public Property FileName As String
    Public Property CompanyName As String
    Public Property ContactType As String
    Public Property Country As String

    Public Sub New()
    End Sub
    Public Overrides Function ToString() As String
        Return String.Format("Kevininstructor demo")
    End Function

    Public Sub New(ByVal FileName As String, ByVal CompanyName As String, ByVal ContactType As String, ByVal Country As String)
        Me.FileName = FileName
        Me.CompanyName = CompanyName
        Me.ContactType = ContactType
        Me.Country = Country
    End Sub
    Public Function RetrieveDataTable() As DataTable
        Dim Results As IEnumerable(Of Customer) =
            (
                From T In XDocument.Load(FileName)...<Customer>
                Select New Customer With
                       {
                           .Identifier = T.<CustomerID>.Value,
                           .CompanyName = T.<CompanyName>.Value,
                           .ContactType = T.<ContactTitle>.Value,
                           .Country = T.<Country>.Value
                       }
                   )

        If Not CompanyName.Equals("All") Then
            Results = Results.Where(Function(x) x.CompanyName = CompanyName)
        End If


        If Not ContactType.Equals("All") Then
            Results = Results.Where(Function(x) x.ContactType = ContactType)
        End If

        If Not Country.Equals("All") Then
            Results = Results.Where(Function(x) x.Country = Country)
        End If

        If Results.Count = 0 Then

            Dim dummy As List(Of Customer) = New List(Of Customer)() From
                {
                    New Customer With
                    {
                        .CompanyName = "",
                        .ContactType = "",
                        .Country = "",
                        .Identifier = ""
                    }
                }

            Return dummy.ToDataTable

        End If

        Return Results.ToDataTable

    End Function
    Public Function RetrieveList() As List(Of Customer)
        Dim Results As IEnumerable(Of Customer) =
            (
                From T In XDocument.Load(FileName)...<Customer>
                Select New Customer With
                       {
                           .Identifier = T.<CustomerID>.Value,
                           .CompanyName = T.<CompanyName>.Value,
                           .ContactType = T.<ContactTitle>.Value,
                           .Country = T.<Country>.Value
                       }
                   )

        If Not CompanyName.Equals("All") Then
            Results = Results.Where(Function(x) x.CompanyName = CompanyName)
        End If

        If Not ContactType.Equals("All") Then
            Results = Results.Where(Function(x) x.ContactType = ContactType)
        End If

        If Not Country.Equals("All") Then
            Results = Results.Where(Function(x) x.Country = Country)
        End If

        If Results.Count = 0 Then

            Dim dummy As List(Of Customer) = New List(Of Customer)() From
                {
                    New Customer With
                    {
                        .CompanyName = "",
                        .ContactType = "",
                        .Country = "",
                        .Identifier = ""
                    }
                }

            Return dummy

        End If

        Return Results.ToList


    End Function
End Class
