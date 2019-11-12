Imports System.Data.OleDb
Imports AccessConnections_vb

Public Class ExportToExcel

    ''' <summary>
    ''' MS-Access path and database name
    ''' </summary>
    ''' <returns></returns>
    Public Property DatabaseName As String
    ''' <summary>
    ''' SQL SELECT FROM MS-Access
    ''' </summary>
    ''' <returns></returns>
    Public Property SelectStatement As String
    ''' <summary>
    ''' Table name from MS-Access
    ''' </summary>
    ''' <returns></returns>
    Public Property TableName As String
    ''' <summary>
    ''' Excel file to place data into
    ''' </summary>
    ''' <returns></returns>
    Public Property ExcelFileName As String
    ''' <summary>
    ''' Sheet name to place MS-Access data
    ''' </summary>
    ''' <returns></returns>
    Public Property WorkSheetName As String
    ''' <summary>
    ''' Determine if colum names are the first row in the WorkSheet
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>Currently does not function</remarks>
    Public Property Headers As Boolean
    Public Property RecordsInserted As Integer
    ''' <summary>
    ''' Used for when a export fails, caller can examine the cause.
    ''' </summary>
    ''' <returns></returns>
    Public Property ExceptionMessage As String
    Public Function Execute(Optional ByVal SelectStatement As String = "*") As Boolean
        Dim Provider As String = ""
        Dim Success As Boolean = False

        Using cn As New OleDbConnection With {.ConnectionString = DatabaseName.BuildConnectionString}

            Using cmd As New OleDbCommand With {.Connection = cn}
                '
                ' Determine the proper provider for Excel
                '
                If IO.Path.GetExtension(DatabaseName).ToLower = ".mdb" AndAlso IO.Path.GetExtension(ExcelFileName).ToLower = ".xls" Then
                    Provider = "Excel 8.0;"
                ElseIf IO.Path.GetExtension(DatabaseName).ToLower = ".accdb" AndAlso IO.Path.GetExtension(ExcelFileName).ToLower = ".xlsx" Then
                    Provider = "Excel 12.0 xml;"
                End If

                cmd.CommandText = $"SELECT {SelectStatement} INTO [{Provider}DATABASE={ExcelFileName};HDR=No].[{WorkSheetName}] FROM [{TableName}]"

                cn.Open()
                Try
                    ' if you need, affected is the row count placed into the destination worksheet
                    RecordsInserted = cmd.ExecuteNonQuery()
                    Success = RecordsInserted > 0
                    Console.WriteLine()
                Catch ex As Exception
                    '
                    ' If we get here and the exception is -> Data type mismatch in criteria expression
                    ' the data type is not valid e.g. you attempted to place a binary field such as an image into the worksheet.
                    ' We could query each field's data type and make a decision to abort and if so that needs to happen before
                    ' cmd.ExecuteNonQuery() as after the fact the WorkSheet has already been created, the exception is raised
                    ' after the Worksheet has been created so now you need to clean up and remove the WorkSheet which is beyond
                    ' the scope of this code sample.
                    '                    '
                    ExceptionMessage = ex.Message
                End Try
            End Using

        End Using

        Return Success

    End Function
End Class
