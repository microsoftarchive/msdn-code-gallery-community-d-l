Public Class DataOperations
    Private Connection As OleDbHelper.Connections = New OleDbHelper.Connections
    Public Property ExcelFileName As String
    Public Property CsvFileName As String
    Public Property SheetName As String
    Public Property DataTable As DataTable

    Public Sub New()

    End Sub
    Public Function GetSheetData() As Boolean
        Dim dt As New DataTable

        Dim ConnectionString As String = Connection.HeaderConnectionString(ExcelFileName)

        Try
            Using cn As New OleDb.OleDbConnection With {.ConnectionString = ConnectionString}
                Using cmd As New OleDb.OleDbCommand With {.CommandText = "SELECT * FROM [" & SheetName & "$]", .Connection = cn}
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try

        Me.DataTable = dt

        Return True

    End Function
    Public Function ExportToCsv() As Boolean
        Dim sb As New System.Text.StringBuilder

        Try
            Dim headerText = String.Join(",", Me.DataTable.Columns.Cast(Of DataColumn).Select(Function(c) c.ColumnName).ToArray)
            sb.AppendLine(headerText)
            For Each row As DataRow In Me.DataTable.Rows
                sb.AppendLine(String.Join(",", row.ItemArray))
            Next
            IO.File.WriteAllText(Me.ExcelFileName, sb.ToString)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
