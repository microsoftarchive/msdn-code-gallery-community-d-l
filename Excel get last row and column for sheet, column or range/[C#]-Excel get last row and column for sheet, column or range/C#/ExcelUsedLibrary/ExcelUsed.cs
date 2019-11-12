using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.IO;

namespace ExcelUsedLibrary
{
    public class ExcelUsed
    {
        /// <summary>
        /// Given a range of cells this function returns the last used row in the range.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        /// <param name="startCell"></param>
        /// <param name="endCell"></param>
        /// <returns></returns>
        public string LastRowInRange(string fileName, string sheetName, string startCell, string endCell)
        {
            string cellAddress = "";

            if (File.Exists(fileName))
            {
                Excel.Application xlApp = null;
                Excel.Workbooks xlWorkBooks = null;
                Excel.Workbook xlWorkBook = null;
                Excel.Worksheet xlWorkSheet = null;
                Excel.Sheets xlWorkSheets = null;

                xlApp = new Excel.Application();
                xlApp.DisplayAlerts = false;

                xlWorkBooks = xlApp.Workbooks;
                xlWorkBook = xlWorkBooks.Open(fileName);

                xlApp.Visible = false;

                xlWorkSheets = xlWorkBook.Sheets;

                for (int x = 1; x <= xlWorkSheets.Count; x++)
                {
                    xlWorkSheet = (Excel.Worksheet)xlWorkSheets[x];


                    if (xlWorkSheet.Name == sheetName)
                    {
                        
                        Excel.Range workRange = xlWorkSheet.get_Range(startCell,endCell);

                        Excel.Range resultRange = workRange
                            .Find("*", System.Type.Missing,
                                Excel.XlFindLookIn.xlValues,
                                Excel.XlLookAt.xlPart,
                                Excel.XlSearchOrder.xlByRows,
                                Excel.XlSearchDirection.xlPrevious,
                                Type.Missing,
                                Type.Missing,
                                Type.Missing
                            );

                        cellAddress = resultRange.Address;

                        Marshal.FinalReleaseComObject(workRange);
                        workRange = null;

                        Marshal.FinalReleaseComObject(resultRange);
                        resultRange = null;

                        break;
                    }

                    Marshal.FinalReleaseComObject(xlWorkSheet);
                    xlWorkSheet = null;

                }

                xlWorkBook.Close();
                xlApp.UserControl = true;
                xlApp.Quit();

                Release(xlWorkSheets);
                Release(xlWorkSheet);
                Release(xlWorkBook);
                Release(xlWorkBooks);
                Release(xlApp);

                return cellAddress;

            }
            else
            {
                throw new Exception("'" + fileName + "' not found.");
            }
          
        }
        /// <summary>
        /// Get last used column for a row
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public int LastColumnForRow(string fileName, string sheetName, int row)
        {
            int lastColumn = -1;

            if (File.Exists(fileName))
            {
                Excel.Application xlApp = null;
                Excel.Workbooks xlWorkBooks = null;
                Excel.Workbook xlWorkBook = null;
                Excel.Worksheet xlWorkSheet = null;
                Excel.Sheets xlWorkSheets = null;

                xlApp = new Excel.Application();
                xlApp.DisplayAlerts = false;

                xlWorkBooks = xlApp.Workbooks;
                xlWorkBook = xlWorkBooks.Open(fileName);

                xlApp.Visible = false;

                xlWorkSheets = xlWorkBook.Sheets;

                for (int x = 1; x <= xlWorkSheets.Count; x++)
                {
                    xlWorkSheet = (Excel.Worksheet)xlWorkSheets[x];
                    

                    if (xlWorkSheet.Name == sheetName)
                    {
                        Excel.Range xlCells = null;
                        xlCells = xlWorkSheet.Cells;

                        Excel.Range workRange = xlCells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);
                        Excel.Range xlColumns = xlWorkSheet.Columns;

                        int count = xlColumns.Count;

                        Marshal.FinalReleaseComObject(xlColumns);
                        xlColumns = null;

                        Excel.Range xlLastRange = (Excel.Range)xlWorkSheet.Cells[row, count];
                        Excel.Range xlDirRange = xlLastRange.End[Excel.XlDirection.xlToLeft];

                        Marshal.FinalReleaseComObject(xlLastRange);
                        xlLastRange = null;

                        lastColumn = xlDirRange.Column;
                        Marshal.FinalReleaseComObject(xlDirRange);
                        xlDirRange = null;

                        Marshal.FinalReleaseComObject(workRange);
                        workRange = null;

                        Marshal.FinalReleaseComObject(xlCells);
                        xlCells = null;

                        break;
                    }

                    Marshal.FinalReleaseComObject(xlWorkSheet);
                    xlWorkSheet = null;

                }

                xlWorkBook.Close();
                xlApp.UserControl = true;
                xlApp.Quit();

                Release(xlWorkSheets);
                Release(xlWorkSheet);
                Release(xlWorkBook);
                Release(xlWorkBooks);
                Release(xlApp);

                return lastColumn;

            }
            else
            {
                throw new Exception("'" + fileName + "' not found.");
            }

        }

        /// <summary>
        /// Return last used row and column for a worksheet.
        /// </summary>
        /// <param name="fileName">file to get information form</param>
        /// <param name="sheetName">valid sheet name to get last row and column</param>
        /// <returns>ExcelLast</returns>
        public ExcelLast UsedRowsColumns(string fileName, string sheetName)
        {

            int RowsUsed = -1;
            int ColsUsed = -1;

            if (File.Exists(fileName))
            {
                Excel.Application xlApp = null;
                Excel.Workbooks xlWorkBooks = null;
                Excel.Workbook xlWorkBook = null;
                Excel.Worksheet xlWorkSheet = null;
                Excel.Sheets xlWorkSheets = null;

                xlApp = new Excel.Application();
                xlApp.DisplayAlerts = false;

                xlWorkBooks = xlApp.Workbooks;
                xlWorkBook = xlWorkBooks.Open(fileName);

                xlApp.Visible = false;

                xlWorkSheets = xlWorkBook.Sheets;

                for (int x = 1; x <= xlWorkSheets.Count; x++)
                {
                    xlWorkSheet = (Excel.Worksheet)xlWorkSheets[x];

                    if (xlWorkSheet.Name == sheetName)
                    {
                        Excel.Range xlCells = null;
                        xlCells = xlWorkSheet.Cells;

                        Excel.Range workRange = xlCells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);

                        RowsUsed = workRange.Row;
                        ColsUsed = workRange.Column;

                        Marshal.FinalReleaseComObject(workRange);
                        workRange = null;

                        Marshal.FinalReleaseComObject(xlCells);
                        xlCells = null;

                        break;
                    }

                    Marshal.FinalReleaseComObject(xlWorkSheet);
                    xlWorkSheet = null;

                }

                xlWorkBook.Close();
                xlApp.UserControl = true;
                xlApp.Quit();

                Release(xlWorkSheets);
                Release(xlWorkSheet);
                Release(xlWorkBook);
                Release(xlWorkBooks);
                Release(xlApp);

                return new ExcelLast() { Row = RowsUsed, Column = ColsUsed };

            }
            else
            {
                throw new Exception($"'{fileName}' not found.");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void CallGarbageCollector()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        /// <summary>
        /// Method to release object used in Excel operations
        /// </summary>
        /// <param name="sender"></param>
        private void Release(object sender)
        {
            try
            {
                if (sender != null)
                {
                    Marshal.ReleaseComObject(sender);
                    sender = null;
                }
            }
            catch (Exception)
            {
                sender = null;
            }
        }
    }
    public class ExcelLast
    {
        /// <summary>
        /// Last used row in specific sheet
        /// </summary>
        public int Row { get; set; }
        /// <summary>
        /// Last used column in specific sheet
        /// </summary>
        public int Column { get; set; }
    }
}
