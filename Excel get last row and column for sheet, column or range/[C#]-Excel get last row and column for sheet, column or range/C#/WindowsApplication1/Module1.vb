'https://onedrive.live.com/redir?resid=A3D5A9A9A28080D1!645&authkey=!ACCx10FUqM31yKc&ithint=file%2czip
Option Strict On
Option Infer On

Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office
Imports System.Runtime.InteropServices
''' <summary>
''' Basics for getting last row and column in a worksheet
''' SEE ALSO Readme.txt
''' </summary>
''' <remarks>
''' </remarks>
Module Module1
    ''' <summary>
    ''' Get last used row in sheetname
    ''' </summary>
    ''' <param name="FileName">path and filename to excel file to work with</param>
    ''' <param name="SheetName">Worksheet name to get information</param>
    ''' <returns>-1 if issues else lasted used row</returns>
    ''' <remarks></remarks>
    Public Function UsedRows(ByVal FileName As String, ByVal SheetName As String) As Integer

        Dim RowsUsed As Integer = -1

        If IO.File.Exists(FileName) Then
            Dim xlApp As Excel.Application = Nothing
            Dim xlWorkBooks As Excel.Workbooks = Nothing
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing
            Dim xlWorkSheets As Excel.Sheets = Nothing

            xlApp = New Excel.Application
            xlApp.DisplayAlerts = False
            xlWorkBooks = xlApp.Workbooks
            xlWorkBook = xlWorkBooks.Open(FileName)

            xlApp.Visible = False

            xlWorkSheets = xlWorkBook.Sheets

            For x As Integer = 1 To xlWorkSheets.Count

                xlWorkSheet = CType(xlWorkSheets(x), Excel.Worksheet)

                If xlWorkSheet.Name = SheetName Then
                    Dim xlCells As Excel.Range = Nothing
                    xlCells = xlWorkSheet.Cells

                    Dim TempRange As Excel.Range = xlCells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell)

                    RowsUsed = TempRange.Row
                    Runtime.InteropServices.Marshal.FinalReleaseComObject(TempRange)
                    TempRange = Nothing

                    Runtime.InteropServices.Marshal.FinalReleaseComObject(xlCells)
                    xlCells = Nothing

                    Exit For
                End If

                Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkSheet)
                xlWorkSheet = Nothing

            Next

            xlWorkBook.Close()
            xlApp.UserControl = True
            xlApp.Quit()

            ReleaseComObject(xlWorkSheets)
            ReleaseComObject(xlWorkSheet)
            ReleaseComObject(xlWorkBook)
            ReleaseComObject(xlWorkBooks)
            ReleaseComObject(xlApp)
        Else
            Throw New Exception("'" & FileName & "' not found.")
        End If

        Return RowsUsed

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <param name="SheetName"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Framework 4 and higher for Tuple
    ''' http://msdn.microsoft.com/en-us/library/system.tuple.aspx
    ''' http://visualstudiomagazine.com/articles/2009/12/01/types-and-tuples-in-net-4.aspx
    ''' </remarks>
    Public Function UsedRows_Columns(ByVal FileName As String, ByVal SheetName As String) As Tuple(Of Int32, Int32)

        Dim RowsUsed As Integer = -1
        Dim ColsUsed As Integer = -1

        If IO.File.Exists(FileName) Then
            Dim xlApp As Excel.Application = Nothing
            Dim xlWorkBooks As Excel.Workbooks = Nothing
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing
            Dim xlWorkSheets As Excel.Sheets = Nothing

            xlApp = New Excel.Application
            xlApp.DisplayAlerts = False
            xlWorkBooks = xlApp.Workbooks
            xlWorkBook = xlWorkBooks.Open(FileName)

            xlApp.Visible = False

            xlWorkSheets = xlWorkBook.Sheets

            For x As Integer = 1 To xlWorkSheets.Count
                xlWorkSheet = CType(xlWorkSheets(x), Excel.Worksheet)

                If xlWorkSheet.Name = SheetName Then
                    Dim xlCells As Excel.Range = Nothing
                    xlCells = xlWorkSheet.Cells

                    Dim TempRange As Excel.Range = xlCells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell)

                    RowsUsed = TempRange.Row
                    ColsUsed = TempRange.Column

                    Runtime.InteropServices.Marshal.FinalReleaseComObject(TempRange)
                    TempRange = Nothing

                    Runtime.InteropServices.Marshal.FinalReleaseComObject(xlCells)
                    xlCells = Nothing


                    Exit For
                End If

                Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkSheet)
                xlWorkSheet = Nothing
            Next

            xlWorkBook.Close()
            xlApp.UserControl = True
            xlApp.Quit()

            ReleaseComObject(xlWorkSheets)
            ReleaseComObject(xlWorkSheet)
            ReleaseComObject(xlWorkBook)
            ReleaseComObject(xlWorkBooks)
            ReleaseComObject(xlApp)

            Return New Tuple(Of Int32, Int32)(RowsUsed, ColsUsed)

        Else
            Throw New Exception("'" & FileName & "' not found.")
        End If

        Return New Tuple(Of Int32, Int32)(-1, -1)

    End Function
    Public Function UsedInformation(ByVal FileName As String, ByVal SheetName As String) As ExcelInfo


        Dim RowsUsed As Integer = -1
        Dim ColsUsed As Integer = -1

        If IO.File.Exists(FileName) Then
            Dim xlApp As Excel.Application = Nothing
            Dim xlWorkBooks As Excel.Workbooks = Nothing
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing
            Dim xlWorkSheets As Excel.Sheets = Nothing

            xlApp = New Excel.Application
            xlApp.DisplayAlerts = False
            xlWorkBooks = xlApp.Workbooks
            xlWorkBook = xlWorkBooks.Open(FileName)

            xlApp.Visible = False

            xlWorkSheets = xlWorkBook.Sheets

            For x As Integer = 1 To xlWorkSheets.Count
                xlWorkSheet = CType(xlWorkSheets(x), Excel.Worksheet)

                If xlWorkSheet.Name = SheetName Then
                    Dim xlCells As Excel.Range = Nothing
                    xlCells = xlWorkSheet.Cells

                    Dim TempRange As Excel.Range = xlCells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell)

                    RowsUsed = TempRange.Row
                    ColsUsed = TempRange.Column

                    Runtime.InteropServices.Marshal.FinalReleaseComObject(TempRange)
                    TempRange = Nothing

                    Runtime.InteropServices.Marshal.FinalReleaseComObject(xlCells)
                    xlCells = Nothing


                    Exit For
                End If

                Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkSheet)
                xlWorkSheet = Nothing
            Next

            xlWorkBook.Close()
            xlApp.UserControl = True
            xlApp.Quit()

            ReleaseComObject(xlWorkSheets)
            ReleaseComObject(xlWorkSheet)
            ReleaseComObject(xlWorkBook)
            ReleaseComObject(xlWorkBooks)
            ReleaseComObject(xlApp)

            Return New ExcelInfo With {.FileName = FileName, .SheetName = SheetName, .UsedRows = RowsUsed, .UsedColumns = ColsUsed}

        Else
            Throw New Exception("'" & FileName & "' not found.")
        End If

        Return New ExcelInfo With {.FileName = FileName, .SheetName = SheetName, .UsedRows = -1, .UsedColumns = -1}

    End Function


    '-----------------------------------------------------------
    Public Function UsedInformation(ByVal FileName As String, ByVal Sheets As List(Of String)) As List(Of ExcelInfo)
        Dim Results As New List(Of ExcelInfo)

        Dim RowsUsed As Integer = -1
        Dim ColsUsed As Integer = -1

        If IO.File.Exists(FileName) Then
            Dim xlApp As Excel.Application = Nothing
            Dim xlWorkBooks As Excel.Workbooks = Nothing
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing
            Dim xlWorkSheets As Excel.Sheets = Nothing

            xlApp = New Excel.Application
            xlApp.DisplayAlerts = False
            xlWorkBooks = xlApp.Workbooks
            xlWorkBook = xlWorkBooks.Open(FileName)

            xlApp.Visible = False

            xlWorkSheets = xlWorkBook.Sheets

            For x As Integer = 1 To xlWorkSheets.Count

                xlWorkSheet = CType(xlWorkSheets(x), Excel.Worksheet)

                For Each SheetName In Sheets

                    If xlWorkSheet.Name = SheetName Then

                        Dim xlCells As Excel.Range = xlWorkSheet.Cells
                        Dim xlTempRange As Excel.Range = xlCells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell)

                        RowsUsed = xlTempRange.Row
                        ColsUsed = xlTempRange.Column

                        Results.Add(
                            New ExcelInfo With
                            {
                                .FileName = FileName,
                                .SheetName = SheetName,
                                .UsedRows = RowsUsed,
                                .UsedColumns = ColsUsed
                            }
                        )

                        Runtime.InteropServices.Marshal.FinalReleaseComObject(xlTempRange)
                        xlTempRange = Nothing

                        Runtime.InteropServices.Marshal.FinalReleaseComObject(xlCells)
                        xlCells = Nothing

                    End If
                Next
                Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkSheet)
                xlWorkSheet = Nothing
            Next

            xlWorkBook.Close()
            xlApp.UserControl = True
            xlApp.Quit()

            ReleaseComObject(xlWorkSheets)
            ReleaseComObject(xlWorkSheet)
            ReleaseComObject(xlWorkBook)
            ReleaseComObject(xlWorkBooks)
            ReleaseComObject(xlApp)

            Return Results

        Else
            Throw New Exception("'" & FileName & "' not found.")
        End If

        Return Results

    End Function


    Public Sub ReleaseComObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        End Try
    End Sub
End Module