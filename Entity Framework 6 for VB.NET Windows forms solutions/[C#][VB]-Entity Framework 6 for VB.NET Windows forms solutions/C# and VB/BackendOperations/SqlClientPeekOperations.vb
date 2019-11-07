Imports System.Data.SqlClient
''' <summary>
''' Do similar work in a conventional matter to Entity Framework.
''' </summary>
Public Class SqlClientPeekOperations

    Private Server As String = "KARENS-PC"
    Private Catalog As String = "CustomerEntityFrameworkSample"
    Private ConnectionString As String = ""
    Private pException As Exception = Nothing

    ''' <summary>
    ''' Exception thrown during reading of data, check HasException
    ''' before using.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Exception() As Exception
        Get
            Return pException
        End Get
    End Property
    ''' <summary>
    ''' Determine if an exception was raised during reading of data operations
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property HasException As Boolean
        Get
            Return pException IsNot Nothing
        End Get
    End Property

    Public Sub New()
        ConnectionString = $"Data Source={Server};Initial Catalog={Catalog};Integrated Security=True"
    End Sub
    Public Function CustomerTableColumnNames(ByVal Table As DataTable) As List(Of String)
        Dim Columns As New List(Of String)
        Return Table.Columns.OfType(Of DataColumn).Where(Function(col) col.DataType = GetType(String)).Select(Function(item) item.ColumnName).ToList
    End Function
    ''' <summary>
    ''' Load Customer table. If you misspell a column name or the column name does not exists,
    ''' we throw an exception unlike Entity Framework this is not possible but if someone
    ''' removes a column or renames a column at the DB level then of course we run into issues
    ''' but not from misspelling a column name
    ''' 
    ''' In Entity Framework we need one line of code to load the same data, one line of code to hide the id
    ''' </summary>
    ''' <returns></returns>
    Public Function LoadCustomers() As DataTable
        Dim CustomerDataTable As New DataTable

        Dim commandText As String = "SELECT id,FirstName,LastName,[Address],City,[State],ZipCode FROM Customer"
        Try
            Using cn As New SqlConnection(ConnectionString)
                Using cmd As New SqlCommand(commandText, cn)
                    cn.Open()
                    CustomerDataTable.Load(cmd.ExecuteReader)
                    CustomerDataTable.Columns("id").ColumnMapping = MappingType.Hidden
                End Using
            End Using
        Catch ex As Exception
            pException = ex
        End Try

        Return CustomerDataTable

    End Function
    ''' <summary>
    ''' Load a custom list for locating items, in Entity Framework this is one line of code
    ''' </summary>
    ''' <returns></returns>
    Public Function CustomerIdentifierList() As List(Of CustNameIdItem)
        Dim results As New List(Of CustNameIdItem)

        Dim commandText As String = "SELECT id,FirstName + ' ' + LastName AS Name, LastName FROM Customer ORDER BY LastName"

        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(commandText, cn)

                cn.Open()

                Dim reader As SqlDataReader = cmd.ExecuteReader
                If reader.HasRows Then
                    While reader.Read

                        results.Add(New CustNameIdItem With
                            {
                                .Id = CType(reader.GetInt32(0), String),
                                .LastName = reader.GetString(1),
                                .Name = reader.GetString(2)
                            }
                        )

                    End While
                End If
            End Using
        End Using

        Return results

    End Function
    ''' <summary>
    ''' Update a record, compare this to Entity Framework which used two methods
    ''' </summary>
    ''' <param name="Row"></param>
    ''' <returns></returns>
    Public Function UpdateCustomer(ByVal Row As DataRow) As Boolean
        Dim Success As Boolean = True

        Dim commandText As String =
            <SQL>
                UPDATE Customer 
                SET 
                    FirstName = @FirstName,
                    LastName = @LastName,
                    [Address] = @Address,
                    City = @City,
                    [State] = @State,
                    ZipCode = @ZipCode  
                WHERE id = @id
            </SQL>.Value

        Try

            Using cn As New SqlConnection(ConnectionString)
                Using cmd As New SqlCommand(commandText, cn)

                    cmd.Parameters.AddWithValue("@FirstName", Row.Field(Of String)("FirstName"))
                    cmd.Parameters.AddWithValue("@LastName", Row.Field(Of String)("LastName"))
                    cmd.Parameters.AddWithValue("@Address", Row.Field(Of String)("Address"))
                    cmd.Parameters.AddWithValue("@City", Row.Field(Of String)("City"))
                    cmd.Parameters.AddWithValue("@State", Row.Field(Of String)("State"))
                    cmd.Parameters.AddWithValue("@ZipCode", Row.Field(Of String)("ZipCode"))
                    cmd.Parameters.AddWithValue("@id", Row.Field(Of Integer)("id"))

                    cn.Open()

                    Success = (cmd.ExecuteNonQuery = 1)

                End Using
            End Using

        Catch ex As Exception
            pException = ex
            Success = False
        End Try

        Return Success

    End Function
End Class
