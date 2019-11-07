Imports System.Data.SqlClient

Public Class DataOperations
    Private CustomerDataTable As DataTable
    Public Function GetCustomers() As DataTable
        Return CustomerDataTable
    End Function
    ''' <summary>
    ''' Load data, rather than use DataTable.Load we cycle through rows else the Load method 
    ''' will mark the primary key as read-only which means no way to set the primary key and
    ''' would cause us to reload the data and set the current record.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        Me.CustomerDataTable = New DataTable
        Me.CustomerDataTable.Columns.Add(New DataColumn With {.ColumnName = "Identifier", .DataType = GetType(Integer)})
        Me.CustomerDataTable.Columns.Add(New DataColumn With {.ColumnName = "CompanyName", .DataType = GetType(String)})
        Me.CustomerDataTable.Columns.Add(New DataColumn With {.ColumnName = "ContactName", .DataType = GetType(String)})
        Me.CustomerDataTable.Columns.Add(New DataColumn With {.ColumnName = "ContactTitle", .DataType = GetType(String)})

        Using cn As New SqlConnection With {.ConnectionString = My.Settings.ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = "SELECT Identifier, CompanyName, ContactName, ContactTitle FROM [Customer] ORDER BY Identifier"
                cn.Open()
                Dim Reader = cmd.ExecuteReader
                If Reader.HasRows Then
                    While Reader.Read
                        Me.CustomerDataTable.Rows.Add(New Object() {Reader.GetInt32(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3)})
                    End While
                End If
            End Using
        End Using

        Me.CustomerDataTable.AcceptChanges()

    End Sub
    ''' <summary>
    ''' Remove a single row from Customer table
    ''' </summary>
    ''' <param name="Identifier"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RemoveRow(ByVal Identifier As Integer) As Boolean
        Dim Result As Boolean = False
        Using cn As New SqlConnection With {.ConnectionString = My.Settings.ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn, .CommandText = "DELETE FROM Customer WHERE Identifier = " & Identifier.ToString}
                cn.Open()
                Result = (cmd.ExecuteNonQuery = 1)
            End Using
        End Using
        Return Result
    End Function
    ''' <summary>
    ''' Responsible for removing more than one row.
    ''' 
    ''' Options
    '''  - pass in selected rows from the DataGridView, get identifier and do delete
    '''  - add a checkbox column, pass in rows selected and use identifier to delete
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' Rather than present one method of the above none are done as it shouldf be
    ''' easy enough for you the reader to implement
    ''' </remarks>
    Public Function RemoveRows() As Boolean
        Throw New NotImplementedException("TODO")
    End Function
    Private UpdateStatement As String = "UPDATE Customer SET CompanyName = @CompanyName, ContactName = @ContactName,ContactTitle = @ContactTitle WHERE Identifier = @Identifier"
    ''' <summary>
    ''' Responsible for updating rows that have 
    ''' Row.RowState = Modified
    ''' 
    ''' Use the same logic as done in the add method below.
    ''' </summary>
    ''' <param name="row"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Once you understand the logic in add rows you will be capable
    ''' to implement this method
    ''' </remarks>
    Public Function UpdateRow(ByVal row As DataRow) As Boolean
        Dim Result As Boolean = False
        Using cn As New SqlConnection With {.ConnectionString = My.Settings.ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = UpdateStatement
                cmd.Parameters.AddWithValue("@CompanyName", row.Field(Of String)("CompanyName"))
                cmd.Parameters.AddWithValue("@ContactName", row.Field(Of String)("ContactTitle"))
                cmd.Parameters.AddWithValue("@ContactTitle", row.Field(Of String)("ContactTitle"))
                cmd.Parameters.AddWithValue("@Identifier", row.Field(Of Integer)("Identifier"))
                cn.Open()
                Try
                    If CInt(cmd.ExecuteNonQuery) = 1 Then
                        Result = True
                    End If
                Catch ex As Exception
                    Return False
                End Try
            End Using
        End Using
        Return Result
    End Function
    Public Function UpdateRows(ByVal table As DataTable) As Boolean
        Throw New NotImplementedException("TODO")
    End Function
    ''' <summary>
    ''' Add new rows from the DataTable passed to us
    ''' </summary>
    ''' <param name="table"></param>
    ''' <remarks></remarks>
    Public Sub AddCustomers(ByVal table As DataTable)
        For Each row As DataRow In table.Rows
            If row.RowState = DataRowState.Added Then
                If Not String.IsNullOrWhiteSpace(row.Field(Of String)("CompanyName")) Then
                    Dim NewIdentifier As Integer = 0
                    If AddNewCustomer(row.Field(Of String)("CompanyName"), row.Field(Of String)("ContactName"), row.Field(Of String)("ContactTitle"), NewIdentifier) Then
                        row.SetField(Of Integer)("Identifier", NewIdentifier)
                    End If
                End If

            End If
        Next
        table.AcceptChanges()
    End Sub
    Private InsertStatement As String = "INSERT INTO [Customer] (CompanyName,ContactName,ContactTitle) VALUES (@CompanyName,@ContactName,@ContactTitle); SELECT CAST(scope_identity() AS int);"
    ''' <summary>
    ''' Called from AddCustomers to add a single new record
    ''' </summary>
    ''' <param name="CompanyName"></param>
    ''' <param name="ContactName"></param>
    ''' <param name="ContactTitle"></param>
    ''' <param name="NewIdentifier"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddNewCustomer(ByVal CompanyName As String, ByVal ContactName As String, ByVal ContactTitle As String, ByRef NewIdentifier As Integer) As Boolean
        Using cn As New SqlConnection With {.ConnectionString = My.Settings.ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = InsertStatement
                cmd.Parameters.AddWithValue("@CompanyName", CompanyName)
                cmd.Parameters.AddWithValue("@ContactName", ContactTitle)
                cmd.Parameters.AddWithValue("@ContactTitle", ContactTitle)
                cn.Open()
                Try
                    NewIdentifier = CInt(cmd.ExecuteScalar)
                    Return True
                Catch ex As Exception
                    Return False
                End Try
            End Using
        End Using
    End Function
    Public Function ReadSingleField(ByVal CompanyName As String) As Integer
        Dim Identifier As Integer = 0
        Using cn As New SqlConnection With {.ConnectionString = My.Settings.ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = "SELECT Identifier FROM [Customer] WHERE CompanyName=@CompanyName"
                cmd.Parameters.AddWithValue("@CompanyName", CompanyName)
                cn.Open()
                Identifier = CInt(cmd.ExecuteScalar)
            End Using
        End Using

        Return Identifier

    End Function
End Class
