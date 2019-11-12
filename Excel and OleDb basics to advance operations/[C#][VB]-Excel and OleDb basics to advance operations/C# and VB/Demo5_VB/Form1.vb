''' <summary>
''' Exploring reading mixed types in a column, in this case column 2 focusing
''' on valid dates.
''' </summary>
''' <remarks></remarks>
Public Class Form1
    Private FileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MixedData.xlsx")
    ''' <summary>
    ''' A drop in connection builder
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConnectionString(ByVal FileName As String) As String
        Dim Builder As New OleDb.OleDbConnectionStringBuilder
        If IO.Path.GetExtension(FileName).ToUpper = ".XLS" Then
            Builder.Provider = "Microsoft.Jet.OLEDB.4.0"
            Builder.Add("Extended Properties", "Excel 8.0;IMEX=1;HDR=No;")
        Else
            Builder.Provider = "Microsoft.ACE.OLEDB.12.0"
            Builder.Add("Extended Properties", "Excel 12.0;IMEX=1;HDR=Yes;")
        End If

        Builder.DataSource = FileName

        Return Builder.ToString

    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = ReadInMixed()
        TextBox1.Select(0, 0)
    End Sub
    Public Function ReadInMixed() As String
        Dim RowIndex As Integer = 1
        Dim dt As New DataTable
        Dim sb As New System.Text.StringBuilder


        Using cn As New OleDb.OleDbConnection With {.ConnectionString = ConnectionString(FileName)}
            Using cmd As New OleDb.OleDbCommand With {.Connection = cn}
                cmd.CommandText = "SELECT [Column 1] As Column1,[Column 2] As Column2,[Column 3] As Column3  FROM [Sheet1$]"
                cn.Open()
                Try
                    dt.Load(cmd.ExecuteReader)
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
                Console.WriteLine()
            End Using
        End Using


        Dim TestDate As Date = Nothing
        Dim StringDate As String = ""

        For Each row As DataRow In dt.Rows

            StringDate = row.Field(Of String)("Column2")

            ' Can the value be converted ?
            If Date.TryParse(StringDate, TestDate) Then

                sb.AppendLine(String.Format("{0} {1}", RowIndex, TestDate))

            Else

                Try
                    '
                    ' 2nd try to convert, on failure an exception is thrown so we capture it
                    '
                    TestDate = DateTime.FromOADate(CInt(row.Field(Of String)("Column2")))
                    sb.AppendLine(String.Format("{0} {1} using FromOADate", RowIndex, TestDate))
                Catch ex As Exception
                    sb.AppendLine(String.Format("{0} column 2 [{1}] is not a valid date", RowIndex, StringDate))
                End Try

            End If

            RowIndex += 1

        Next

        Return sb.ToString

    End Function
    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Close()
    End Sub
End Class
