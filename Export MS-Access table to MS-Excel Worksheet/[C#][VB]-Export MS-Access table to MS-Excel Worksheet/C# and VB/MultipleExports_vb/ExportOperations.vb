Imports AccessConnections_vb
Imports ExcelOleDbLibrary
Imports ExportAccessToExcel_vb

Public Class ExportOperations
    Private msAccessFileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Biblio1.accdb")
    Private msExcelFile As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Biblio1.xlsx")
    Public Property ExeptionMessage As String
    Public Property HasErrors As Boolean

    Private TempTableName As String = "TempSample1"
    Public Property RecordsInserted As Integer
    Public Sub ExportData()
        If MakeTempTableAccess() Then
            Dim cons As Connections = New Connections
            Dim ops As New ExportToExcel With
            {
                .DatabaseName = msAccessFileName,
                .Headers = False,
                .ExcelFileName = msExcelFile,
                .TableName = TempTableName,
                .WorkSheetName = "Report1"
            }
            HasErrors = Not ops.Execute
            If HasErrors Then
                ExeptionMessage = ops.ExceptionMessage
            End If
            RecordsInserted = ops.RecordsInserted
        End If
    End Sub
    ''' <summary>
    ''' Here we are selecting data from several tables and making a new table
    ''' which is then used to export to Excel.
    ''' </summary>
    ''' <returns></returns>
    Private Function MakeTempTableAccess() As Boolean
        Dim success As Boolean = False

        Dim info As New AccessInformation

        info.TryDropTable(msAccessFileName, TempTableName)

        Dim MakeTableQuery As String = "SELECT Titles.Title, Publishers.Name, Authors.Author, Titles.[Year Published], Titles.ISBN, Titles.Subject INTO TempSample1 FROM Publishers INNER JOIN (Authors INNER JOIN (Titles INNER JOIN TitleAuthor ON Titles.ISBN = TitleAuthor.ISBN) ON Authors.Au_ID = TitleAuthor.Au_ID) ON Publishers.PubID = Titles.PubID WHERE (((Publishers.Name) In ('ARTECH','CAMBRIDGE UNIV','WROX','DELMAR','IDG')) AND ((Titles.[Year Published])>=1995)) ORDER BY Publishers.Name;"
        Using cn As New OleDb.OleDbConnection With {.ConnectionString = msAccessFileName.BuildConnectionString}
            Using cmd As New OleDb.OleDbCommand With {.Connection = cn, .CommandText = MakeTableQuery}
                cn.Open()
                Try
                    success = cmd.ExecuteNonQuery > 0
                Catch ex As Exception
                    HasErrors = True
                    ExeptionMessage = ex.Message
                End Try

            End Using
        End Using

        Return success

    End Function

End Class
