Imports System.Data.OleDb
Public Class TableUtils
    Public Function AccessTableExists(ByVal ConnectionString As String, ByVal TableName As String) As Boolean
        Dim Result As Boolean = False

        Using cn As New OleDbConnection(ConnectionString)
            cn.Open()
            Dim dt As DataTable = New DataTable With {.TableName = "test"}
            dt = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
            cn.Close()

            Dim query = (From F In dt.Rows.Cast(Of DataRow)() Where F.Field(Of String)("TABLE_NAME").ToString = TableName).FirstOrDefault

            If query IsNot Nothing Then
                Result = True
            End If

        End Using

        Return Result

    End Function
    Public Function AccessTableNames(ByVal ConnectionString As String) As List(Of String)
        Dim Names As New List(Of String)

        Using cn As New OleDbConnection(ConnectionString)
            cn.Open()
            Dim dt As DataTable = New DataTable With {.TableName = "test"}
            dt = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
            cn.Close()
            Names = dt.AsEnumerable.Select(Function(d) d.Field(Of String)("TABLE_NAME")).ToList

        End Using

        Return Names

    End Function
    Public Function DropTable(ByVal ConnectionString As String, ByVal TableName As String) As Boolean
        Dim Result As Boolean = False
        If AccessTableExists(ConnectionString, TableName) Then
            Try
                Dim cn As New OleDbConnection(ConnectionString)
                Dim cmd As New OleDbCommand With {.CommandText = "DROP TABLE " & TableName, .Connection = cn}
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                Result = True

            Catch ex As OleDbException
                '
                ' As this is a demo this is fine but not for a real app
                ' 
                Result = False
            End Try
        Else
            Result = False
        End If

        Return Result

    End Function

End Class
