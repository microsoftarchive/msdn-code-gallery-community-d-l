Imports System.Data.OleDb

''' <summary>
''' Methods to obtain table names and columns for tables in a ms-access database.
''' These are not optimized, did them for demo purposes only. They can be optimized :-)
''' </summary>
Public Class AccessInformation
    ''' <summary>
    ''' Key is table name, values are columns for table
    ''' </summary>
    ''' <returns></returns>
    Public Property ColumnDict As Dictionary(Of String, List(Of String))
    ''' <summary>
    ''' Get user table names from database
    ''' </summary>
    ''' <param name="DatabaseName">Existing database path and name</param>
    ''' <returns></returns>
    Public Function TableNames(ByVal DatabaseName As String) As List(Of String)
        Dim Names As New List(Of String)

        Using cn As New OleDbConnection With {.ConnectionString = DatabaseName.BuildConnectionString}

            cn.Open()

            Names = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing) _
                .AsEnumerable.Where(Function(col) col.Field(Of String)("TABLE_TYPE") = "TABLE") _
                .Select(Function(data) data.Field(Of String)("TABLE_NAME")).ToList

        End Using

        Return Names

    End Function
    Public Sub TryDropTable(ByVal DatabaseName As String, ByVal TableName As String)
        Dim Names = TableNames(DatabaseName)
        If Names.Contains(TableName) Then
            Using cn As New OleDbConnection With {.ConnectionString = DatabaseName.BuildConnectionString}
                Using cmd As New OleDbCommand With {.Connection = cn, .CommandText = $"DROP TABLE {TableName}"}
                    cn.Open()
                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        '
                        ' Discard exception for this sample but for a real app the exception should be delt with.
                        '
                    End Try
                End Using
            End Using
        End If
    End Sub
    ''' <summary>
    ''' Get column names for a specific table
    ''' </summary>
    ''' <param name="DatabaseName"></param>
    ''' <param name="TableName"></param>
    ''' <returns></returns>
    Public Function GetColumnNames(ByVal DatabaseName As String, ByVal TableName As String) As List(Of String)
        Dim Names As New List(Of String)
        Using cn As New OleDbConnection With {.ConnectionString = DatabaseName.BuildConnectionString}
            Dim filterValues As String() = {Nothing, Nothing, TableName, Nothing}
            cn.Open()

            Try
                Names = cn.GetSchema("Columns", filterValues).AsEnumerable.Select(Function(data) $"[{data.Field(Of String)("COLUMN_NAME")}]").ToList
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

        End Using

        Return Names

    End Function
    ''' <summary>
    ''' Get columns for each table in database
    ''' </summary>
    ''' <param name="DatabaseName"></param>
    Public Sub GetTableColumnInformation(ByVal DatabaseName As String)
        ColumnDict = New Dictionary(Of String, List(Of String))

        Dim Names = TableNames(DatabaseName)
        For Each table As String In Names
            Dim ColNames = GetColumnNames(DatabaseName, table)

            ColumnDict.Add(table, ColNames)
        Next

    End Sub
End Class
