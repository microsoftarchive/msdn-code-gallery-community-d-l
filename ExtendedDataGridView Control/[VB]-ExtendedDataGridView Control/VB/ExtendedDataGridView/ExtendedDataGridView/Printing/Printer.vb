Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class Printer

    Dim portraitPages As New List(Of Bitmap)
    Dim landScapePages As New List(Of Bitmap)
    Dim Pages As List(Of Bitmap)

    Private WithEvents document As New Printing.PrintDocument
    Dim pageIndex As Integer = 0
    Dim copyIndex As Integer = 1
    Dim Collate As Boolean
    Dim Copies As Integer
    Dim Landscape As Boolean
    Dim FromPage As Integer
    Dim ToPage As Integer

    '*
    '     * Creates a List of printed page images
    '     * both for use in the preview form and for printing
    '     
    Public Function getPages(mainTable As DataGridView, includeRowHeaders As Boolean, includeColumnHeaders As Boolean, includeHiddenColumns As Boolean, portrait As Boolean) As List(Of Bitmap)
        mainTable.EndEdit()

        Dim pageImages As New List(Of Bitmap)

        Dim startColumn As Integer = 0
        Dim startRow As Integer = 0
        Dim lastColumn As Integer = -1
        Dim lastRow As Integer = -1

        Dim ulFont As New Font(mainTable.Font, mainTable.Font.Style Or FontStyle.Underline)

        While True
            '612, 792
            Dim sumX As Double = (If(includeRowHeaders, mainTable.RowHeadersWidth, 0))
            Dim xCoordinates As New List(Of xC)

            For x As Integer = startColumn To mainTable.ColumnCount() - 1
                If Not mainTable.Columns(x).Visible And Not includeHiddenColumns Then
                    xCoordinates.Add(New xC(0, 0))
                    Continue For
                End If
                If (sumX + mainTable.Columns(x).Width) < (If(portrait, 765, 1060)) Then
                    xCoordinates.Add(New xC(CInt(sumX), mainTable.Columns(x).Width))
                    sumX += mainTable.Columns(x).Width
                    If x = mainTable.ColumnCount() - 1 Then
                        lastColumn = x
                    End If
                Else
                    lastColumn = x - 1
                    Exit For
                End If
            Next

            Dim sumY As Double = (If(includeColumnHeaders, mainTable.ColumnHeadersHeight, 0))
            Dim yCoordinates As New List(Of yC)

            For y As Integer = startRow To mainTable.RowCount() - 1
                If (sumY + mainTable.Rows(y).Height) < (If(portrait, 1015, 765)) Then
                    yCoordinates.Add(New yC(CInt(sumY), mainTable.Rows(y).Height))
                    sumY += mainTable.Rows(y).Height
                    If y = mainTable.RowCount() - 1 Then
                        lastRow = y
                    End If
                Else
                    lastRow = y - 1
                    Exit For
                End If
            Next

            Dim img As Bitmap
            If portrait Then
                img = New Bitmap(850, 1100)
            Else
                img = New Bitmap(1100, 850)
            End If
            Dim g As Graphics = Graphics.FromImage(img)

            g.Clear(Color.White)
            g.TranslateTransform(20, 20)

            ' get metrics from the graphics
            'Dim metrics As SizeF = g2d.getFontMetrics(mainTable.getFont())
            'Dim height As Integer = metrics.getHeight()
            Dim sf As New StringFormat
            sf.Alignment = StringAlignment.Near
            sf.LineAlignment = StringAlignment.Center

            Dim brush As New SolidBrush(mainTable.ColumnHeadersDefaultCellStyle.BackColor)

            If includeColumnHeaders Then
                For x As Integer = startColumn To lastColumn
                    If Not mainTable.Columns(x).Visible And Not includeHiddenColumns Then
                        Continue For
                    End If
                    Dim r As New Rectangle(xCoordinates(x - startColumn).X(), 0, xCoordinates(x - startColumn).Width(), mainTable.ColumnHeadersHeight)
                    g.FillRectangle(brush, r)
                    g.DrawRectangle(Pens.DarkGray, r)

                    Dim b As Boolean = False
                    If TypeOf mainTable.Columns(x).HeaderCell Is checkAllHeaderCell OrElse TypeOf mainTable.Columns(x).HeaderCell Is checkHideColumnHeaderCell Then
                        If TypeOf mainTable.Columns(x).HeaderCell Is checkAllHeaderCell Then
                            Dim hc As checkAllHeaderCell = DirectCast(mainTable.Columns(x).HeaderCell, checkAllHeaderCell)
                            b = hc.isChecked
                        ElseIf TypeOf mainTable.Columns(x).HeaderCell Is checkHideColumnHeaderCell Then
                            Dim hc As checkHideColumnHeaderCell = DirectCast(mainTable.Columns(x).HeaderCell, checkHideColumnHeaderCell)
                            b = hc.isChecked
                        End If
                        Dim l As New Point(r.Width - 18, 5)
                        CheckBoxRenderer.DrawCheckBox(g, New Point(r.X + l.X, l.Y), If(b, VisualStyles.CheckBoxState.CheckedNormal, VisualStyles.CheckBoxState.UncheckedNormal))
                    End If

                    r.Inflate(-2, -2)
                    g.DrawString(mainTable.Columns(x).HeaderText, mainTable.Font, Brushes.Black, r, sf)
                Next
            End If

            If includeRowHeaders Then
                For y As Integer = startRow - 1 To lastRow
                    If y = startRow - 1 Then
                        Dim r As New Rectangle(0, 0, mainTable.RowHeadersWidth, mainTable.ColumnHeadersHeight)
                        g.FillRectangle(brush, r)
                        g.DrawRectangle(Pens.DarkGray, r)
                    Else
                        Dim r As New Rectangle(0, yCoordinates(y - startRow).Y(), mainTable.RowHeadersWidth, yCoordinates(y - startRow).Height())
                        g.FillRectangle(brush, r)
                        g.DrawRectangle(Pens.DarkGray, r)
                        r.Inflate(-2, -2)
                        Dim o As Object = mainTable.Rows(y).HeaderCell.Value
                        g.DrawString(If(o IsNot Nothing, o.ToString, ""), mainTable.Font, Brushes.Black, r, sf)
                    End If
                Next
            End If

            For x As Integer = startColumn To lastColumn
                If Not mainTable.Columns(x).Visible And Not includeHiddenColumns Then
                    Continue For
                End If
                For y As Integer = startRow To lastRow
                    Dim r As New Rectangle(xCoordinates(x - startColumn).X(), yCoordinates(y - startRow).Y(), xCoordinates(x - startColumn).Width(), yCoordinates(y - startRow).Height())
                    Dim r2 As New Rectangle(r.Left, r.Top, r.Width, r.Height)
                    r2.Inflate(-2, -2)

                    'DataGridViewButtonColumn
                    'DataGridViewCheckBoxColumn
                    'DataGridViewComboBoxColumn
                    'DataGridViewImageColumn
                    'DataGridViewLinkColumn
                    'DataGridViewTextBoxColumn
                    If TypeOf mainTable(x, y) Is DataGridViewTextBoxCell Then
                        If Not mainTable(x, y).Style.BackColor.Equals(Color.Empty) Then
                            g.FillRectangle(New SolidBrush(mainTable(x, y).Style.BackColor), r)
                        Else
                            If Not mainTable(x, y).OwningColumn.DefaultCellStyle.BackColor.Equals(Color.Empty) Then
                                g.FillRectangle(New SolidBrush(mainTable(x, y).OwningColumn.DefaultCellStyle.BackColor), r)
                            End If
                            If Not mainTable(x, y).OwningRow.DefaultCellStyle.BackColor.Equals(Color.Empty) Then
                                g.FillRectangle(New SolidBrush(mainTable(x, y).OwningRow.DefaultCellStyle.BackColor), r)
                            End If
                            If Not mainTable.AlternatingRowsDefaultCellStyle.BackColor.Equals(Color.Empty) AndAlso y Mod 2 = 1 Then
                                g.FillRectangle(New SolidBrush(mainTable.AlternatingRowsDefaultCellStyle.BackColor), r)
                            End If
                        End If

                        Dim cellValue As String = ""
                        If mainTable(x, y).Value IsNot Nothing Then
                            cellValue = mainTable(x, y).Value.ToString
                            g.DrawString(cellValue, mainTable.Font, Brushes.Black, r2, sf)
                        End If
                    ElseIf TypeOf mainTable(x, y) Is DataGridViewLinkCell Then
                        If Not mainTable(x, y).Style.BackColor.Equals(Color.Empty) Then
                            g.FillRectangle(New SolidBrush(mainTable(x, y).Style.BackColor), r)
                        Else
                            If Not mainTable(x, y).OwningColumn.DefaultCellStyle.BackColor.Equals(Color.Empty) Then
                                g.FillRectangle(New SolidBrush(mainTable(x, y).OwningColumn.DefaultCellStyle.BackColor), r)
                            End If
                            If Not mainTable(x, y).OwningRow.DefaultCellStyle.BackColor.Equals(Color.Empty) Then
                                g.FillRectangle(New SolidBrush(mainTable(x, y).OwningRow.DefaultCellStyle.BackColor), r)
                            End If
                            If Not mainTable.AlternatingRowsDefaultCellStyle.BackColor.Equals(Color.Empty) AndAlso y Mod 2 = 1 Then
                                g.FillRectangle(New SolidBrush(mainTable.AlternatingRowsDefaultCellStyle.BackColor), r)
                            End If
                        End If

                        Dim cellValue As String = ""
                        If mainTable(x, y).Value IsNot Nothing Then
                            cellValue = mainTable(x, y).Value.ToString
                            Dim c As Color = If(DirectCast(mainTable(x, y), DataGridViewLinkCell).LinkVisited, Color.Purple, Color.Blue)
                            g.DrawString(cellValue, ulFont, New SolidBrush(c), r2, sf)
                        End If
                    ElseIf TypeOf mainTable(x, y) Is DataGridViewComboBoxCell Then
                        ComboBoxRenderer.DrawDropDownButton(g, New Rectangle(r.X + r.Width - 16, r.Top, 16, r.Height), VisualStyles.ComboBoxState.Normal)
                        Dim cellValue As String = ""
                        If mainTable(x, y).Value IsNot Nothing Then
                            cellValue = mainTable(x, y).Value.ToString
                            g.DrawString(cellValue, mainTable.Font, Brushes.Black, r2, sf)
                        End If
                    ElseIf TypeOf mainTable(x, y) Is DataGridViewCheckBoxCell Then
                        If Not mainTable(x, y).Style.BackColor.Equals(Color.Empty) Then
                            g.FillRectangle(New SolidBrush(mainTable(x, y).Style.BackColor), r)
                        Else
                            If Not mainTable(x, y).OwningColumn.DefaultCellStyle.BackColor.Equals(Color.Empty) Then
                                g.FillRectangle(New SolidBrush(mainTable(x, y).OwningColumn.DefaultCellStyle.BackColor), r)
                            End If
                            If Not mainTable(x, y).OwningRow.DefaultCellStyle.BackColor.Equals(Color.Empty) Then
                                g.FillRectangle(New SolidBrush(mainTable(x, y).OwningRow.DefaultCellStyle.BackColor), r)
                            End If
                            If Not mainTable.AlternatingRowsDefaultCellStyle.BackColor.Equals(Color.Empty) AndAlso y Mod 2 = 1 Then
                                g.FillRectangle(New SolidBrush(mainTable.AlternatingRowsDefaultCellStyle.BackColor), r)
                            End If
                        End If

                        Dim b As Boolean = False
                        If Boolean.TryParse(mainTable(x, y).FormattedValue.ToString, b) AndAlso b Then
                            CheckBoxRenderer.DrawCheckBox(g, New Point(r.Left + CInt((r.Width - 12) / 2), r.Top + CInt((r.Height - 12) / 2)), VisualStyles.CheckBoxState.CheckedNormal)
                        Else
                            CheckBoxRenderer.DrawCheckBox(g, New Point(r.Left + CInt((r.Width - 12) / 2), r.Top + CInt((r.Height - 12) / 2)), VisualStyles.CheckBoxState.UncheckedNormal)
                        End If
                    ElseIf TypeOf mainTable(x, y) Is DataGridViewButtonCell Then
                        ButtonRenderer.DrawButton(g, r2, VisualStyles.PushButtonState.Normal)
                        sf.Alignment = StringAlignment.Center
                        Dim o As Object = mainTable(x, y).Value
                        If o IsNot Nothing Then
                            g.DrawString(o.ToString, mainTable.Font, Brushes.Black, r2, sf)
                        End If
                    ElseIf TypeOf mainTable(x, y) Is DataGridViewImageCell Then
                        If y <> mainTable.NewRowIndex Then
                            If Not mainTable(x, y).Value Is Nothing Then
                                g.DrawImage(DirectCast(mainTable(x, y).FormattedValue, Bitmap), r)
                            End If
                        End If
                    End If
                    g.DrawRectangle(Pens.DarkGray, r)
                Next
            Next

            Dim footer As [String] = "Page " & (pageImages.Count() + 1).ToString
            Dim textWidth As Integer = TextRenderer.MeasureText(footer, mainTable.Font).Width
            g.DrawString(footer, mainTable.Font, Brushes.Black, CSng((img.Width() - textWidth) / 2) - 20, CSng(img.Height() - 85))

            pageImages.Add(img)

            If lastColumn < mainTable.ColumnCount() - 1 Then
                startColumn = lastColumn + 1
            Else
                If lastRow < mainTable.RowCount() - 1 Then
                    startColumn = 0
                    startRow = lastRow + 1
                Else
                    Exit While
                End If
            End If
        End While

        Return pageImages

    End Function

    Public Sub startPrint(mainTable As DataGridView, includeRowHeaders As Boolean, includeColumnHeaders As Boolean, includeHiddenColumns As Boolean, preview As Boolean)
        portraitPages = getPages(mainTable, includeRowHeaders, includeColumnHeaders, includeHiddenColumns, True)
        landScapePages = getPages(mainTable, includeRowHeaders, includeColumnHeaders, includeHiddenColumns, False)

        document.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)
        document.OriginAtMargins = True

        Dim frm As New altPrintDialog(document, portraitPages.Count, landScapePages.Count)
        If frm.ShowDialog = DialogResult.OK Then

            Collate = document.PrinterSettings.Collate
            Copies = document.PrinterSettings.Copies
            Landscape = document.DefaultPageSettings.Landscape
            FromPage = document.PrinterSettings.FromPage
            ToPage = document.PrinterSettings.ToPage
            document.PrinterSettings.PrintRange = PrintRange.SomePages

            pageIndex = FromPage - 1
            copyIndex = 1
            If Landscape Then
                Pages = landScapePages
            Else
                Pages = portraitPages
            End If
            '
            If preview Then
                Dim ppd As New PrintPreviewDialog
                ppd.Document = document
                ppd.WindowState = FormWindowState.Maximized
                ppd.ShowDialog()
            Else
                document.Print()
            End If
        End If

    End Sub

    Private Sub document_PrintPage(sender As Object, e As PrintPageEventArgs) Handles document.PrintPage

        e.Graphics.DrawImage(Pages(pageIndex), e.MarginBounds)

        If Not Collate Then
            copyIndex += 1
            If copyIndex > Copies Then
                pageIndex += 1
                If pageIndex < ToPage Then
                    copyIndex = 1
                    e.HasMorePages = True
                End If
            Else
                e.HasMorePages = True
            End If
        Else
            pageIndex += 1
            If pageIndex = ToPage Then
                copyIndex += 1
                pageIndex = FromPage - 1
                If copyIndex <= Copies Then
                    e.HasMorePages = True
                End If
            Else
                e.HasMorePages = True
            End If
        End If

    End Sub

End Class
