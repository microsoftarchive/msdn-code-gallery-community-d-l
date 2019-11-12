Public Class listViewPrinter

    Private lv As ListView
    Private location As Point
    Private border As Boolean
    Private hasGroups As Boolean
    Private title As String
    Private titleHeight As Integer
    Private hLines As Boolean
    Private vLines As Boolean

    Private WithEvents pd As New Printing.PrintDocument

    Public Sub New(ByVal lv As ListView, ByVal location As Point, ByVal border As Boolean, ByVal hasGroups As Boolean, ByVal _hLines As Boolean, ByVal _vLines As Boolean, Optional ByVal title As String = "")
        Me.lv = lv
        Me.location = location
        Me.border = border
        Me.hasGroups = hasGroups
        Me.title = title
        Me.hLines = _hLines
        Me.vLines = _vLines
        titleHeight = If(title <> "", lv.FindForm.CreateGraphics.MeasureString(title, New Font(lv.Font.Name, 25)).ToSize.Height, 0)
    End Sub

    Public Sub print()
        'pd.Print()
        Dim ppd As New PrintPreviewDialog
        ppd.Document = pd
        ppd.WindowState = FormWindowState.Maximized
        ppd.ShowDialog()
    End Sub

    ''' <summary>
    ''' structure to hold printed page details
    ''' </summary>
    ''' <remarks></remarks>
    Private Structure pageDetails
        Dim columns As Integer
        Dim rows As Integer
        Dim startCol As Integer
        Dim startRow As Integer
        Dim headerIndices As List(Of Integer)
    End Structure
    ''' <summary>
    ''' dictionary to hold printed page details, with index key
    ''' </summary>
    ''' <remarks></remarks>
    Private pages As Dictionary(Of Integer, pageDetails)

    Dim maxPagesWide As Integer
    Dim maxPagesTall As Integer

    Dim items() As ListViewItem


    ''' <summary>
    ''' the majority of this Sub is calculating printed page ranges
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pd_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pd.BeginPrint
        ''this removes the printed page margins
        pd.OriginAtMargins = True
        pd.DefaultPageSettings.Margins = New Drawing.Printing.Margins(location.X, location.X, location.Y, location.Y)

        pages = New Dictionary(Of Integer, pageDetails)

        Dim maxWidth As Integer = CInt(pd.DefaultPageSettings.PrintableArea.Width) - (pd.DefaultPageSettings.Margins.Left + pd.DefaultPageSettings.Margins.Right + 40)
        Dim maxHeight As Integer = CInt(pd.DefaultPageSettings.PrintableArea.Height - (titleHeight + 12)) - (pd.DefaultPageSettings.Margins.Top + pd.DefaultPageSettings.Margins.Bottom + 40)

        Dim pageCounter As Integer = 0
        pages.Add(pageCounter, New pageDetails With {.headerIndices = New List(Of Integer)})

        Dim columnCounter As Integer = 0

        Dim columnSum As Integer = 0

        For c As Integer = 0 To lv.Columns.Count - 1
            If columnSum + lv.Columns(c).Width < maxWidth Then
                columnSum += lv.Columns(c).Width
                columnCounter += 1
            Else
                pages(pageCounter) = New pageDetails With {.columns = columnCounter, .rows = 0, .startCol = pages(pageCounter).startCol, .headerIndices = pages(pageCounter).headerIndices}
                columnSum = lv.Columns(c).Width
                columnCounter = 1
                pageCounter += 1
                pages.Add(pageCounter, New pageDetails With {.startCol = c, .headerIndices = New List(Of Integer)})
            End If
            If c = lv.Columns.Count - 1 Then
                If pages(pageCounter).columns = 0 Then
                    pages(pageCounter) = New pageDetails With {.columns = columnCounter, .rows = 0, .startCol = pages(pageCounter).startCol, .headerIndices = pages(pageCounter).headerIndices}
                End If
            End If
        Next

        maxPagesWide = pages.Keys.Max + 1

        pageCounter = 0

        Dim rowCounter As Integer = 0
        Dim counter As Integer = 0

        Dim itemHeight As Integer = lv.GetItemRect(0).Height

        Dim rowSum As Integer = itemHeight

        If hasGroups Then
            For g As Integer = 0 To lv.Groups.Count - 1
                rowSum += itemHeight + 6
                pages(pageCounter).headerIndices.Add(counter)
                For r As Integer = 0 To lv.Groups(g).Items.Count - 1
                    counter += 1
                    If rowSum + itemHeight < maxHeight Then
                        rowSum += itemHeight
                        rowCounter += 1
                    Else
                        pages(pageCounter) = New pageDetails With {.columns = pages(pageCounter).columns, .rows = rowCounter, .startCol = pages(pageCounter).startCol, .startRow = pages(pageCounter).startRow, .headerIndices = pages(pageCounter).headerIndices}
                        For x As Integer = 1 To maxPagesWide - 1
                            pages(pageCounter + x) = New pageDetails With {.columns = pages(pageCounter + x).columns, .rows = rowCounter, .startCol = pages(pageCounter + x).startCol, .startRow = pages(pageCounter).startRow, .headerIndices = pages(pageCounter).headerIndices}
                        Next

                        pageCounter += maxPagesWide
                        For x As Integer = 0 To maxPagesWide - 1
                            pages.Add(pageCounter + x, New pageDetails With {.columns = pages(x).columns, .rows = 0, .startCol = pages(x).startCol, .startRow = counter - 1, .headerIndices = New List(Of Integer)})
                        Next

                        rowSum = itemHeight * 2 + itemHeight + 6
                        rowCounter = 1
                    End If
                    If counter = lv.Items.Count Then
                        For x As Integer = 0 To maxPagesWide - 1
                            If pages(pageCounter + x).rows = 0 Then
                                pages(pageCounter + x) = New pageDetails With {.columns = pages(pageCounter + x).columns, .rows = rowCounter, .startCol = pages(pageCounter + x).startCol, .startRow = pages(pageCounter + x).startRow, .headerIndices = pages(pageCounter + x).headerIndices}
                            End If
                        Next
                    End If
                Next
            Next

        Else
            For r As Integer = 0 To lv.Items.Count - 1
                counter += 1
                If rowSum + itemHeight < maxHeight Then
                    rowSum += itemHeight
                    rowCounter += 1
                Else
                    pages(pageCounter) = New pageDetails With {.columns = pages(pageCounter).columns, .rows = rowCounter, .startCol = pages(pageCounter).startCol, .startRow = pages(pageCounter).startRow}
                    For x As Integer = 1 To maxPagesWide - 1
                        pages(pageCounter + x) = New pageDetails With {.columns = pages(pageCounter + x).columns, .rows = rowCounter, .startCol = pages(pageCounter + x).startCol, .startRow = pages(pageCounter).startRow}
                    Next

                    pageCounter += maxPagesWide
                    For x As Integer = 0 To maxPagesWide - 1
                        pages.Add(pageCounter + x, New pageDetails With {.columns = pages(x).columns, .rows = 0, .startCol = pages(x).startCol, .startRow = counter - 1})
                    Next

                    rowSum = itemHeight * 2
                    rowCounter = 1
                End If
                If counter = lv.Items.Count Then
                    For x As Integer = 0 To maxPagesWide - 1
                        If pages(pageCounter + x).rows = 0 Then
                            pages(pageCounter + x) = New pageDetails With {.columns = pages(pageCounter + x).columns, .rows = rowCounter, .startCol = pages(pageCounter + x).startCol, .startRow = pages(pageCounter + x).startRow}
                        End If
                    Next
                End If
            Next
        End If

        maxPagesTall = pages.Count \ maxPagesWide

        If hasGroups Then
            items = New ListViewItem() {}
            For Each g As ListViewGroup In lv.Groups
                items = items.Concat(g.Items.Cast(Of ListViewItem).ToArray).ToArray
            Next
        Else
            items = lv.Items.Cast(Of ListViewItem).ToArray
        End If

    End Sub


    Private Sub pd_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pd.PrintPage
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center

        Dim r2 As New Rectangle(location, New Size(lv.Columns.Cast(Of ColumnHeader).Skip(pages(0).startCol).Take(pages(0).columns).Sum(Function(ch As ColumnHeader) ch.Width), titleHeight))

        e.Graphics.DrawString(title, New Font(lv.Font.Name, 25), Brushes.Black, r2, sf)

        sf.Alignment = StringAlignment.Near

        Dim startX As Integer = location.X
        Dim startY As Integer = location.Y + titleHeight + 12

        Static startPage As Integer = 0

        Dim itemHeight As Integer = lv.GetItemRect(0).Height

        Dim bottomRight As Point

        For p As Integer = startPage To pages.Count - 1

            startX = location.X
            startY = location.Y + titleHeight + 12

            Dim cell As Rectangle

            For c As Integer = pages(p).startCol To pages(p).startCol + pages(p).columns - 1
                cell = New Rectangle(startX, startY, lv.Columns(c).Width, itemHeight)
                e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
                e.Graphics.DrawRectangle(Pens.Black, cell)
                e.Graphics.DrawString(lv.Columns(c).Text, lv.Font, Brushes.Black, cell, sf)
                startX += lv.Columns(c).Width
            Next

            startY += itemHeight
            startX = location.X

            For r As Integer = pages(p).startRow To pages(p).startRow + pages(p).rows - 1
                startX = location.X
                If hasGroups Then
                    If r = pages(p).startRow Or pages(p).headerIndices.Contains(r) Then
                        cell = New Rectangle(startX + 20, startY + 6, lv.Columns.Cast(Of ColumnHeader).Skip(pages(p).startCol).Take(pages(p).columns).Sum(Function(ch As ColumnHeader) ch.Width), itemHeight)
                        e.Graphics.DrawString(items(r).Group.Header, New Font(lv.Font, FontStyle.Bold), Brushes.SteelBlue, cell, sf)
                        e.Graphics.DrawLine(New Pen(Color.SteelBlue, 2), startX + 20 + e.Graphics.MeasureString(items(r).Group.Header, New Font(lv.Font, FontStyle.Bold)).Width + 12, cell.Top + 3 + cell.Height \ 2, cell.Right - 20, cell.Top + 3 + cell.Height \ 2)
                        startY += itemHeight + 6
                    End If
                End If
                For c As Integer = pages(p).startCol To pages(p).startCol + pages(p).columns - 1
                    cell = New Rectangle(startX, startY, lv.Columns(c).Width, itemHeight)
                    e.Graphics.DrawString(items(r).SubItems(c).Text, lv.Font, Brushes.Black, cell, sf)
                    If vLines Then
                        e.Graphics.DrawLine(Pens.Black, cell.Left, cell.Top, cell.Left, cell.Bottom)
                        e.Graphics.DrawLine(Pens.Black, cell.Right, cell.Top, cell.Right, cell.Bottom)
                    End If
                    If hLines Then
                        e.Graphics.DrawLine(Pens.Black, cell.Left, cell.Top, cell.Right, cell.Top)
                        e.Graphics.DrawLine(Pens.Black, cell.Left, cell.Bottom, cell.Right, cell.Bottom)
                    End If
                    startX += lv.Columns(c).Width
                Next
                startY += itemHeight
                If r = pages(p).startRow + pages(p).rows - 1 Then
                    bottomRight = New Point(startX, startY)
                    If border Then e.Graphics.DrawRectangle(Pens.Black, New Rectangle(location, New Size(bottomRight.X - location.X, bottomRight.Y - location.Y)))
                End If
            Next

            If p <> pages.Count - 1 Then
                startPage = p + 1
                e.HasMorePages = True
                Return
            Else
                startPage = 0
            End If

        Next

    End Sub

End Class
