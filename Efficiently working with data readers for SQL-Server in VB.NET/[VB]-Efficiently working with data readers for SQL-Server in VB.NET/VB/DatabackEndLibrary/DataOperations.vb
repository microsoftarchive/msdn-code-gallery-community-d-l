Imports DataConnections
Imports System.Data.SqlClient
Public Class DataOperations
    Inherits BaseSqlServerConnections
    ''' <summary>
    ''' By default we have the catalog set to use
    ''' </summary>
    Public Sub New()
        DefaultCatalog = "TipsExample"
    End Sub
    ''' <summary>
    ''' Provides a way to override setting the server and default catalog
    ''' </summary>
    ''' <param name="pDatabaseServer"></param>
    ''' <param name="pDefaultCatalog"></param>
    Public Sub SetConnectionString(ByVal pDatabaseServer As String, ByVal pDefaultCatalog As String)
        DatabaseServer = pDatabaseServer
        DefaultCatalog = pDefaultCatalog
    End Sub
    Public Function CustomerView() As DataTable

        mHasException = False
        Dim dt As New DataTable

        Dim selectStatement As String = "SELECT LastName FROM CustomerLastNameView"
        Try
            Using cn = New SqlConnection(ConnectionString)
                Using cmd = New SqlCommand() With {.Connection = cn, .CommandText = selectStatement}
                    cmd.CommandText = selectStatement
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                End Using
            End Using
        Catch ex As Exception
            mHasException = True
            mLastException = ex
        End Try

        Return dt

    End Function
    ''' <summary>
    ''' Example to obtain values via a DataReader where there are no 
    ''' null values
    ''' </summary>
    ''' <returns></returns>
    Public Function GetCategories() As List(Of Category)

        mHasException = False

        Dim categories As New List(Of Category)

        Dim selectStatement As String = "SELECT CategoryID,CategoryName,Description " &
                                        "FROM dbo.Categories"

        Using cn = New SqlConnection(ConnectionString)
            Using cmd = New SqlCommand() With {.Connection = cn, .CommandText = selectStatement}

                Try
                    cn.Open()

                    Dim reader As SqlDataReader = cmd.ExecuteReader
                    '
                    ' For a reference table (as this one is) one would assume there are rows
                    ' but it can't hurt to be sure so we use HasRows to check. 
                    '
                    If reader.HasRows Then
                        While reader.Read

                            categories.Add(New Category With
                                {
                                    .CategoryID = reader.GetInt32(0),
                                    .CategoryName = reader.GetString(1),
                                    .Description = reader.GetString(2)
                                })

                        End While
                    End If

                Catch ex As Exception
                    Dim test = ex.GetType
                    mHasException = True
                    mLastException = ex
                End Try

            End Using
        End Using

        Return categories

    End Function
    ''' <summary>
    ''' Populate two list with two SELECT statements which are (must be) separated
    ''' by a semi-colon. There is no check for HasRows off the command because the data
    ''' will be there as these are reference tables. Reads are done assuming no null data
    ''' and if there were nulls this is not a code issues but a data issue.
    ''' </summary>
    ''' <returns></returns>
    Public Function GetReferenceTables() As SqlServerReferenceTables
        mHasException = False

        Dim selectStatement As String = "SELECT ProductID,ProductName,CategoryID  FROM dbo.Products;" &
            "SELECT CategoryID,CategoryName,Description  FROM dbo.Categories"

        Dim refTables As New SqlServerReferenceTables

        Try
            Using cn = New SqlConnection(ConnectionString)
                Using cmd = New SqlCommand() With {.Connection = cn, .CommandText = selectStatement}
                    cn.Open()

                    Dim reader As SqlDataReader = cmd.ExecuteReader
                    While reader.Read

                        refTables.Products.Add(New Product With
                            {
                                .ProductId = reader.GetInt32(0),
                                .ProductName = reader.GetString(1),
                                .CategoryID = reader.GetInt32(2)
                            })

                    End While

                    If reader.NextResult Then

                        While reader.Read

                            refTables.Catagories.Add(New Category With
                                {
                                    .CategoryID = reader.GetInt32(0),
                                    .CategoryName = reader.GetString(1),
                                    .Description = reader.GetString(2)
                                 })

                        End While
                    End If
                End Using
            End Using
        Catch ex As Exception
            mHasException = True
            mLastException = ex
        End Try

        Return refTables

    End Function
    ''' <summary>
    ''' Knowing that there may be records where State is null,
    ''' rather than check in a loop simply exclude them in the
    ''' SELECT statement with a null check
    ''' </summary>
    ''' <returns></returns>
    Public Function GetStates() As List(Of String)

        mHasException = False

        Dim states As New List(Of String)

        Dim selectStatement As String = "SELECT DISTINCT State " &
                                    "FROM dbo.Customer " &
                                    "WHERE [State] IS NOT NULL"

        Using cn = New SqlConnection(ConnectionString)
            Using cmd = New SqlCommand() With {.Connection = cn, .CommandText = selectStatement}

                Try
                    cn.Open()

                    Dim reader As SqlDataReader = cmd.ExecuteReader
                    '
                    ' For a reference table (as this one is) one would assume there are rows
                    ' but it can't hurt to be sure so we use HasRows to check. 
                    '
                    If reader.HasRows Then
                        While reader.Read

                            states.Add(reader.GetStringSafe("State"))

                        End While
                    End If

                Catch ex As Exception
                    Dim test = ex.GetType
                    mHasException = True
                    mLastException = ex
                End Try

            End Using
        End Using

        Return states

    End Function
    ''' <summary>
    ''' Usually this is how to read data but in this case fails because
    ''' there are many null values. It might be in a real app that perhaps
    ''' one field is prone to nulls and if that is the case you would
    ''' use a combination of this method and the method below using the
    ''' GetxxxSafe to obtain values.
    ''' </summary>
    ''' <returns></returns>
    Public Function TypicalGetCustomersWithNullsUnChecked() As List(Of Customer)
        mHasException = False

        Dim customerList = New List(Of Customer)

        Dim selectStatement As String = "SELECT Id,FirstName,LastName,Address" &
                                    ",City,State,ZipCode,JoinDate,Pin,Balance " &
                                    "FROM dbo.Customer"

        Try
            Using cn = New SqlConnection(ConnectionString)
                Using cmd = New SqlCommand() With {.Connection = cn, .CommandText = selectStatement}
                    cn.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader
                    While reader.Read
                        customerList.Add(New Customer With
                        {
                            .Id = reader.GetInt32(0),
                            .FirstName = reader.GetString(1),
                            .LastName = reader.GetString(2),
                            .Address = reader.GetString(3),
                            .City = reader.GetString(4),
                            .State = reader.GetString(5),
                            .ZipCode = reader.GetString(6),
                            .JoinDate = reader.GetDateTime(7),
                            .Pin = reader.GetInt32(8),
                            .Balance = reader.GetDouble(9)
                        })
                    End While
                End Using
            End Using
        Catch ex As Exception
            mHasException = True
            mLastException = ex
        End Try

        Return customerList

    End Function
    ''' <summary>
    ''' Shows how to read data when there may be null values
    ''' </summary>
    ''' <returns></returns>
    Public Function TypicalGetCustomersWithNullsChecks() As List(Of Customer)
        mHasException = False

        Dim customerList = New List(Of Customer)

        Dim selectStatement As String = "SELECT Id,FirstName,LastName,Address" &
                                    ",City,State,ZipCode,JoinDate,Pin,Balance " &
                                    "FROM dbo.Customer"

        Try
            Using cn = New SqlConnection(ConnectionString)
                Using cmd = New SqlCommand() With {.Connection = cn, .CommandText = selectStatement}
                    cn.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader
                    While reader.Read
                        customerList.Add(New Customer With
                        {
                            .Id = reader.GetInt32(0),
                            .FirstName = reader.GetStringSafe("FirstName"),
                            .LastName = reader.GetStringSafe("LastName"),
                            .Address = reader.GetStringSafe("Address"),
                            .City = reader.GetStringSafe("City"),
                            .State = reader.GetStringSafe("State"),
                            .ZipCode = reader.GetStringSafe("ZipCode"),
                            .JoinDate = reader.GetDateTimeSafe("JoinDate"),
                            .Pin = reader.GetInt32Safe("Pin"),
                            .Balance = reader.GetDoubleSafe("Balance")
                        })
                    End While
                End Using
            End Using
        Catch ex As Exception
            mHasException = True
            mLastException = ex
        End Try

        Return customerList

    End Function
    ''' <summary>
    ''' Normally the code below is fine when we are not dealing
    ''' with null values yet we need to expect nulls in real applications
    ''' so the method below this one shows one way to do so.
    ''' </summary>
    ''' <param name="pIdentifier"></param>
    ''' <returns></returns>
    Public Function GetCustomerDoneWrong(ByVal pIdentifier As Integer) As Customer
        mHasException = False

        Dim customer As Customer = Nothing

        Dim selectStatement As String = "SELECT FirstName,LastName,Address" &
                                        ",City,State,ZipCode,JoinDate,Pin,Balance " &
                                        "FROM dbo.Customer WHERE Id = @Id"
        Try
            Using cn = New SqlConnection(ConnectionString)
                Using cmd = New SqlCommand() With {.Connection = cn, .CommandText = selectStatement}
                    cmd.Parameters.AddWithValue("@Id", pIdentifier)
                    cn.Open()

                    Dim reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        reader.Read()
                        customer = New Customer

                        customer.Id = pIdentifier
                        customer.FirstName = reader.GetString(0)
                        customer.LastName = reader.GetString(1)
                        customer.Address = reader.GetString(2)
                        customer.City = reader.GetString(3)
                        customer.State = reader.GetString(4)
                        customer.ZipCode = reader.GetString(5)
                        customer.JoinDate = reader.GetDateTime(6)
                        customer.Pin = reader.GetInt32(7)
                        customer.Balance = reader.GetDouble(8)

                    End If
                End Using
            End Using
        Catch ex As Exception
            mHasException = True
            mLastException = ex
        End Try

        Return customer

    End Function
    ''' <summary>
    ''' Get a customer with a builder which checks for null values where
    ''' the builder method does not utilizes language extensions which
    ''' the method below this one uses extension methods
    ''' </summary>
    ''' <param name="pIdentifier"></param>
    ''' <returns></returns>
    Public Function GetCustomerWithNullCheckes(ByVal pIdentifier As Integer) As Customer
        mHasException = False

        Dim customer As Customer = Nothing

        Dim selectStatement As String = "SELECT FirstName,LastName,Address" &
                                        ",City,State,ZipCode,JoinDate,Pin,Balance " &
                                        "FROM dbo.Customer WHERE Id = @Id"

        Try
            Using cn = New SqlConnection(ConnectionString)
                Using cmd = New SqlCommand() With {.Connection = cn, .CommandText = selectStatement}
                    cmd.Parameters.AddWithValue("@Id", pIdentifier)
                    cn.Open()

                    Dim reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        reader.Read()

                        customer = CustomerBuilder(reader, pIdentifier)

                    End If
                End Using
            End Using
        Catch ex As Exception
            mHasException = True
            mLastException = ex
        End Try

        Return customer

    End Function
    ''' <summary>
    ''' Get a customer with a builder which checks for null values where
    ''' the builder method utilizes language extensions
    ''' </summary>
    ''' <param name="pIdentifier"></param>
    ''' <returns></returns>
    Public Function GetCustomerWithNullCheckesWithAlternateBuilder(ByVal pIdentifier As Integer) As Customer
        mHasException = False

        Dim customer As Customer = Nothing

        Dim selectStatement As String = "SELECT FirstName,LastName,Address" &
                                        ",City,State,ZipCode,JoinDate,Pin,Balance " &
                                        "FROM dbo.Customer WHERE Id = @Id"
        Try
            Using cn = New SqlConnection(ConnectionString)
                Using cmd = New SqlCommand() With {.Connection = cn, .CommandText = selectStatement}
                    cmd.Parameters.AddWithValue("@Id", pIdentifier)
                    cn.Open()

                    Dim reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        reader.Read()

                        customer = CustomerBuilder1(reader, pIdentifier)

                    End If
                End Using
            End Using
        Catch ex As Exception
            mHasException = True
            mLastException = ex
        End Try

        Return customer

    End Function
    ''' <summary>
    ''' Read one record with null checks
    ''' 
    ''' To see this in use for multiple records see my code sample below
    ''' https://code.msdn.microsoft.com/Working-smarter-with-base-29c09bb2
    ''' 
    ''' </summary>
    ''' <param name="pReader"></param>
    ''' <param name="pIdentifier"></param>
    ''' <returns></returns>
    Private Function CustomerBuilder(ByVal pReader As SqlDataReader, Optional ByVal pIdentifier As Integer = 0) As Customer
        Dim Identifier As Integer = 0

        If pIdentifier > 0 Then
            Identifier = pIdentifier
        Else
            Identifier = Integer.Parse(pReader("id").ToString())
        End If

        Return New Customer With
        {
            .Id = Identifier,
            .FirstName = If(TypeOf pReader("FirstName") Is DBNull, Nothing, pReader("FirstName").ToString()),
            .LastName = If(TypeOf pReader("Lastname") Is DBNull, Nothing, pReader("Lastname").ToString()),
            .Address = If(TypeOf pReader("Address") Is DBNull, Nothing, pReader("Address").ToString()),
            .City = If(TypeOf pReader("City") Is DBNull, Nothing, pReader("City").ToString()),
            .State = If(TypeOf pReader("State") Is DBNull, Nothing, pReader("State").ToString()),
            .ZipCode = If(TypeOf pReader("Zipcode") Is DBNull, Nothing, pReader("Zipcode").ToString()),
            .JoinDate = If(TypeOf pReader("JoinDate") Is DBNull, Nothing, CDate(pReader("JoinDate").ToString)),
            .Pin = If(TypeOf pReader("Pin") Is DBNull, Nothing, CInt(pReader("Pin").ToString)),
            .Balance = If(TypeOf pReader("Balance") Is DBNull, Nothing, CDbl(pReader("Balance").ToString))
        }

    End Function
    ''' <summary>
    ''' Performs same assignments as above but with language extension method.
    ''' Which one is better? Neither, the one above is perfectly fine if you have
    ''' but one place you are constructing a class instance while the method below
    ''' is utilizing extension methods which can be used any place
    ''' </summary>
    ''' <param name="pReader"></param>
    ''' <param name="pIdentifier"></param>
    ''' <returns></returns>
    Private Function CustomerBuilder1(ByVal pReader As SqlDataReader, Optional ByVal pIdentifier As Integer = 0) As Customer

        Dim Identifier As Integer = 0

        If pIdentifier > 0 Then
            Identifier = pIdentifier
        Else
            Identifier = Integer.Parse(pReader("id").ToString())
        End If

        Return New Customer With
        {
            .Id = Identifier,
            .FirstName = pReader.GetStringSafe("FirstName"),
            .LastName = pReader.GetStringSafe("LastName"),
            .Address = pReader.GetStringSafe("Address"),
            .City = pReader.GetStringSafe("City"),
            .State = pReader.GetStringSafe("State"),
            .ZipCode = pReader.GetStringSafe("ZipCode"),
            .JoinDate = pReader.GetDateTimeSafe("JoinDate", Now),
            .Pin = pReader.GetInt32Safe("Pin", 999),
            .Balance = pReader.GetDoubleSafe("Balance", -1)
        }

    End Function
End Class
