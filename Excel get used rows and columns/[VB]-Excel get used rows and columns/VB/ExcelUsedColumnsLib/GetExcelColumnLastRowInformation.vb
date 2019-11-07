Option Strict On
Option Infer On

Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office
Imports System.Runtime.InteropServices
Public Module GetExcelColumnLastRowInformation
    ''' <summary>
    ''' Used to return the last used row for each column within the range of ColumnCount
    ''' </summary>
    ''' <param name="FileName">Existing Excel file</param>
    ''' <param name="SheetName">Name of sheet in FileName</param>
    ''' <param name="ColumnCount">How many columns to get data for</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' In regards to ColumnCount, passing 3 would populate the Dictionary with columns A thru C etc.
    ''' </remarks>
    Public Function UsedColumns(ByVal FileName As String, ByVal SheetName As String, ByVal ColumnCount As Integer) As Dictionary(Of String, Integer)
        Dim ColumnData As New Dictionary(Of String, Integer)


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

                Dim xlCells As Excel.Range = xlWorkSheet.Cells()
                Dim xlTempRange1 As Excel.Range = xlCells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell)
                Dim xlTempRange2 = xlWorkSheet.Rows



                For Col As Integer = 1 To ColumnCount

                    Dim xlTempRange3 = xlWorkSheet.Range(Col.ExcelColumnName & xlTempRange2.Count)
                    Dim xlTempRange4 = xlTempRange3.End(Excel.XlDirection.xlUp)

                    ColumnData.Add(Col.ExcelColumnName, xlTempRange4.Row)
                    Runtime.InteropServices.Marshal.FinalReleaseComObject(xlTempRange4)
                    xlTempRange4 = Nothing

                    Runtime.InteropServices.Marshal.FinalReleaseComObject(xlTempRange3)
                    xlTempRange3 = Nothing
                Next

                Runtime.InteropServices.Marshal.FinalReleaseComObject(xlTempRange2)
                xlTempRange2 = Nothing

                Runtime.InteropServices.Marshal.FinalReleaseComObject(xlTempRange1)
                xlTempRange1 = Nothing

                Runtime.InteropServices.Marshal.FinalReleaseComObject(xlCells)
                xlCells = Nothing

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


        Return ColumnData
    End Function
    Private Sub ReleaseComObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        End Try
    End Sub
End Module
