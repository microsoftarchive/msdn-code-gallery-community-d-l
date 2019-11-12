Imports System.Data.OleDb
Imports System.Data.Common
Imports System.Data.SqlClient

Partial Class DefaultVB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub Import_Click(sender As Object, e As System.EventArgs) Handles Import.Click

        'if you have Excel 2007 uncomment this line of code  
        '  string excelConnectionString =string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0",path);
        'Define the content type
        Dim ExcelContentType As String = "application/vnd.ms-excel"
        Dim Excel2010ContentType As String = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        If FileUpload1.HasFile Then
            If FileUpload1.PostedFile.ContentType = ExcelContentType Or FileUpload1.PostedFile.ContentType = Excel2010ContentType Then
                Try
                    'Save file path
                    Dim path As String = String.Concat(Server.MapPath("~/TempFiles/"), FileUpload1.FileName)
                    'Save File as Temp then you can delete it if you want
                    FileUpload1.SaveAs(path)
                    'For Office Excel 2010  please take a look to the followng link  http://social.msdn.microsoft.com/Forums/en-US/exceldev/thread/0f03c2de-3ee2-475f-b6a2-f4efb97de302/#ae1e6748-297d-4c6e-8f1e-8108f438e62e
                    Dim excelConnectionString As String = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path)

                    ' Create Connection to Excel Workbook
                    Using connection As New OleDbConnection(excelConnectionString)

                        Dim Command As OleDbCommand = New OleDbCommand("Select * FROM [Sheet1$]", connection)

                        connection.Open()

                        'Create DbDataReader to Data Worksheet
                        Using reader As DbDataReader = Command.ExecuteReader()


                            ' SQL Server Connection String
                            Dim sqlConnectionString As String = "Data Source=.\sqlexpress;Initial Catalog=ExcelDB;Integrated Security=True"

                            ' Bulk Copy to SQL Server
                            Using bulkCopy As New SqlBulkCopy(sqlConnectionString)

                                bulkCopy.DestinationTableName = "Employee"
                                bulkCopy.WriteToServer(reader)
                                Label1.Text = "The data has been exported succefuly from Excel to SQL"
                            End Using
                        End Using
                    End Using
                Catch ex As Exception
                    Label1.Text = ex.Message
                End Try
            End If
        End If
    End Sub
End Class
