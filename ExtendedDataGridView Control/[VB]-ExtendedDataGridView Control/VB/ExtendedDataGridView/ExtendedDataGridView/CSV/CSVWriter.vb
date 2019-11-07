Imports System.Windows.Forms

Public Class CSVWriter

    Public Sub writeCSV(mainTable As ExtendedDataGridView, includeRowHeaders As Boolean, includeColumnHeaders As Boolean, includeHiddenColumns As Boolean)
        Dim output As String = ""

        Dim sfd As New SaveFileDialog
        sfd.AddExtension = True
        sfd.Filter = "CSV Files *.csv|*.CSV"
        sfd.FilterIndex = 1
        If sfd.ShowDialog = DialogResult.OK Then
            mainTable.EndEdit()

            If includeColumnHeaders Then
                If includeRowHeaders Then
                    output &= ","
                End If
                For x As Integer = 0 To mainTable.ColumnCount - 1
                    If Not mainTable.Columns(x).Visible And Not includeHiddenColumns Then
                        Continue For
                    End If
                    If x < mainTable.ColumnCount - 1 Then
                        output &= mainTable.Columns(x).HeaderText & ","
                    Else
                        output &= mainTable.Columns(x).HeaderText & Environment.NewLine
                    End If
                Next
            End If

            For y As Integer = 0 To mainTable.RowCount - 1
                If y = mainTable.NewRowIndex Then Continue For
                For x As Integer = -1 To mainTable.ColumnCount - 1
                    If x = -1 Then
                        If includeRowHeaders Then
                            Dim o As Object = mainTable.Rows(y).HeaderCell.Value
                            If o Is Nothing Then
                                o = ""
                            End If
                            output &= o.ToString & ","
                        End If
                        Continue For
                    End If
                    If Not mainTable.Columns(x).Visible And Not includeHiddenColumns Then
                        Continue For
                    End If
                    Dim cellValue As String = ""
                    If TypeOf mainTable(x, y) Is DataGridViewCheckBoxCell Then
                        Dim b As Boolean = False
                        Boolean.TryParse(mainTable(x, y).FormattedValue.ToString, b)
                        cellValue = b.ToString
                    ElseIf TypeOf mainTable(x, y) Is DataGridViewImageCell Then
                        cellValue = "Bitmap"
                    Else
                        If mainTable(x, y).Value IsNot Nothing Then
                            cellValue = mainTable(x, y).Value.ToString
                        End If
                    End If
                    If x < mainTable.ColumnCount - 1 Then
                        output &= cellValue & ","
                    Else
                        output &= cellValue & Environment.NewLine
                    End If
                Next
            Next
            IO.File.WriteAllText(sfd.FileName, output)
        End If

    End Sub

End Class
