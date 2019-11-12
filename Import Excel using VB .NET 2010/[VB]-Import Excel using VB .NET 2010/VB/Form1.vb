Imports Microsoft.Office.Interop

Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub KillExcelProcess()
        Try
            Dim Xcel() As Process = Process.GetProcessesByName("EXCEL")
            For Each Process As Process In Xcel
                Process.Kill()
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub getXlFile()
        Dim xlApp As Excel.Application
        Dim xlWorkbook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim xlRange As Excel.Range

        Dim xlCol As Integer
        Dim xlRow As Integer

        Dim strDestination As String
        Dim Data(0 To 100) As String


        With OpenFileDialog1
            .Filter = "Excel Office|*.xls;*.xlsx"
            .FileName = ""
            .ShowDialog()
            strDestination = .FileName

            TextBox1.Text = .FileName
        End With

        With ListView1
            .View = View.Details
            .FullRowSelect = True
            .GridLines = True
            .Columns.Clear()
            .Items.Clear()


            If strDestination <> "" And TextBox2.Text <> "" Then
                xlApp = New Excel.Application

                xlWorkbook = xlApp.Workbooks.Open(strDestination)
                xlWorkSheet = xlWorkbook.Worksheets(TextBox2.Text)
                xlRange = xlWorkSheet.UsedRange

                If xlRange.Columns.Count > 0 Then
                    If xlRange.Rows.Count > 0 Then

                        'Header
                        For xlCol = 1 To xlRange.Columns.Count
                            .Columns.Add("Column" & xlCol)
                        Next



                        'Detail
                        For xlRow = 1 To xlRange.Rows.Count
                            For xlCol = 1 To xlRange.Columns.Count
                                Data(xlCol) = xlRange.Cells(xlRow, xlCol).text

                                If xlCol = 1 Then
                                    .Items.Add(Data(xlCol).ToString)
                                Else
                                    .Items(xlRow - 1).SubItems.Add(Data(xlCol).ToString)
                                End If
                            Next
                        Next
                        xlWorkbook.Close()
                        xlApp.Quit()

                        KillExcelProcess()
                    End If
                End If
            Else
                MessageBox.Show("Pls. input correct attributes", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End With

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        getXlFile()
    End Sub

End Class
