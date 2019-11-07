Imports System.Data.OleDb

Public Class Utility
    Public Sub New()
    End Sub
    Public Function TableExists(ByVal ConnectionString As String, ByVal TableName As String) As Boolean
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
    ''' <summary>
    ''' Returns a list of sheet names from Excel or table names from Access
    ''' </summary>
    ''' <param name="ConnectionString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SheetNames(ByVal ConnectionString As String) As List(Of SheetNameData)
        Dim Names As New List(Of SheetNameData)

        Using cn As New OleDbConnection(ConnectionString)
            cn.Open()
            Dim dt As DataTable = New DataTable With {.TableName = "AvailableSheetsTables"}
            dt = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
            cn.Close()

            Names =
                (
                    From F In dt.Rows.Cast(Of DataRow)()
                    Select New SheetNameData With
                           {
                               .DisplayName = F.Field(Of String)("TABLE_NAME").Replace("$", ""),
                               .ActualName = F.Field(Of String)("TABLE_NAME")
                           }
                ).ToList

        End Using

        Return Names
    End Function
    ''' <summary>
    ''' Get column names for a connection that has HDR = Yes
    ''' </summary>
    ''' <param name="ConnectionString"></param>
    ''' <param name="SheetName"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' You could use this with HDR = No but here we are
    ''' using it with HDR = Yes
    ''' 
    ''' Also, we can get column schema from the connection and 
    ''' order column names by Ordinal_Position so that Column_Name
    ''' column will not be ordered.
    ''' </remarks>
    Public Function GetColumnNames(ByVal ConnectionString As String, ByVal SheetName As String) As List(Of String)
        Dim ColumnNames As New List(Of String)
        Using cn As New OleDbConnection(ConnectionString)
            cn.Open()
            Using cmd As New OleDbCommand(String.Format("select * from [{0}]", SheetName), cn)
                Using reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly)
                    Dim dt As DataTable = reader.GetSchemaTable()
                    Dim nameCol = dt.Columns("ColumnName")
                    For Each row As DataRow In dt.Rows
                        ColumnNames.Add(row(nameCol).ToString)
                    Next
                End Using
            End Using
        End Using
        Return ColumnNames
    End Function
End Class
Public Class SheetNameData
    Public Sub New()

    End Sub
    Public Property DisplayName As String
    Public Property ActualName As String

End Class