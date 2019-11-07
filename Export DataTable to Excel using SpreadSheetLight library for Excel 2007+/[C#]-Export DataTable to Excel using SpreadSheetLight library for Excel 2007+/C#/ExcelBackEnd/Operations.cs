using System;
using System.Data;
using System.Data.SqlClient;
using SpreadsheetLight;
using DocumentFormat.OpenXml.Spreadsheet;
using SysDraw = System.Drawing;

namespace ExcelBackEnd
{
    /// <summary>
    /// Note import method can be found here
    /// https://github.com/AmbaCloud/Amba.SpreadsheetLight/blob/master/Source/Amba.SpreadsheetLight/ImportFunctions.cs
    /// https://github.com/AmbaCloud/Amba.SpreadsheetLight/tree/master/Source/Amba.SpreadsheetLight
    /// 
    /// All methods include an optiona parameter pIncludeHeaders which I left to the reader to implment code for no header,
    /// as delivered each method does headers. The basic changes are to look at the code, inspect how row indexing is done
    /// and adjust. The third parameter to doc.ImportDataTable is to include or not include headers so keep to adjusting
    /// row indexing. Why didn't I do that, to keep the code easy to read and understand.
    /// </summary>
    public class Operations
    {
        /// <summary>
        /// Make sure to change 'Data Source' to your SQL-Server name
        /// </summary>
        string ConnectionString = "Data Source=KARENS-PC;Initial Catalog=ExcelExportingProject;Integrated Security=True";
        public bool HasErrors { get; set; }
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// Load data
        /// </summary>
        /// <param name="pRowCount">Over 0 loads that many rows, 0 loads all rows</param>
        /// <returns></returns>
        public DataTable LoadFromDatabase(int pRowCount)
        {
            var dt = new DataTable(); 
            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    if (pRowCount > 0)
                    {
                        cmd.CommandText = $"SELECT TOP {pRowCount} id,FirstName,LastName,Street,City,[State],Country,Phone,BirthDay," + 
                                           "AccountNumber,Active,Gender,PersonalEmail,CreditCard,CreditCardType  " + 
                                           "FROM ExcelExportingProject.dbo.Person";
                    }
                    else
                    {
                        cmd.CommandText = $"SELECT id,FirstName,LastName,Street,City,[State],Country,Phone,BirthDay," + 
                                           "AccountNumber,Active,Gender,PersonalEmail,CreditCard,CreditCardType " + 
                                           "FROM ExcelExportingProject.dbo.Person";
                    }

                    cn.Open();

                    dt.Load(cmd.ExecuteReader());

                    // no need to see this.
                    // it will show up in the import process except for demo 4 where the column is removed.
                    dt.Columns["id"].ColumnMapping = MappingType.Hidden;

                }
            }

            return dt;
        }
        /// <summary>
        /// Import DataTable, no formatting so the date and bool fields were appear unsatisfactory
        /// so in the method below this one we will format these columns.
        /// </summary>
        /// <param name="pFileName">Existing excel file</param>
        /// <param name="pStartReference">Row to start import</param>
        /// <param name="pDataTable">Data source</param>
        /// <param name="pIncludeHeaders">Should column headers be used (currently only does headers)</param>
        /// <returns></returns>
        public bool ImportDataTable1(string pFileName, string pStartReference, DataTable pDataTable, bool pIncludeHeaders = true)
        {
            bool success = false;

            try
            {
                using (SLDocument doc = new SLDocument(pFileName))
                {
                    doc.ClearCellContent();
                    doc.ImportDataTable(pStartReference, pDataTable, pIncludeHeaders);
                    doc.Save();
                    success = true;
                }
            }
            catch (Exception ex)
            {
                HasErrors = true;
                ExceptionMessage = ex.Message;
                success = false;
            }


            return success;

        }
        /// <summary>
        /// Import DataTable, 
        /// BirthDate is formatted
        /// Active field is set manually
        /// </summary>
        /// <param name="pFileName">Existing excel file</param>
        /// <param name="pStartReference">Row to start import</param>
        /// <param name="pDataTable">Data source</param>
        /// <param name="pIncludeHeaders">Should column headers be used (currently only does headers)</param>
        /// <returns></returns>
        /// <remarks>
        /// Unlike example above we will create Demo2 worksheet, import our DataTable
        /// and do some formatting. Each time we run this code I check to see if Demo2
        /// sheet exist, if so, remove and add it back in.
        /// </remarks>
        public bool ImportDataTable2(string pFileName, string pStartReference, DataTable pDataTable, bool pIncludeHeaders = true)
        {
            bool success = false;

            try
            {
                using (SLDocument doc = new SLDocument(pFileName,"Sheet1"))
                {

                    var helper = new LightHelpers();

                    if (helper.SheetExists(pFileName,"Demo2"))
                    {
                        doc.DeleteWorksheet("Demo2");
                    }

                    doc.AddWorksheet("Demo2");
                    doc.SelectWorksheet("Demo2");

                    // create a date style for birthday column
                    var birthdayColumnStyle = doc.CreateStyle();
                    birthdayColumnStyle.FormatCode = "mm-dd-yyyy";

                    // since we need these several times, set them up as variables
                    var activeCellIndex = pDataTable.Columns["Active"].Ordinal + 1;
                    var birthDayCellIndex = pDataTable.Columns["BirthDay"].Ordinal + 1;

                    // set birthday style to our data
                    doc.SetCellStyle(2, birthDayCellIndex, pDataTable.Rows.Count + 1, birthDayCellIndex, birthdayColumnStyle);

                    // do the Datatable import.
                    doc.ImportDataTable(pStartReference, pDataTable, pIncludeHeaders);

                    SLWorksheetStatistics stats = doc.GetWorksheetStatistics();

                    // there is no method to set all bool values from TRUE/FALSE to Yes/No so we do it manually
                    // we add +1 to EndRowIndex because of the header
                    for (int row = 1; row < stats.EndRowIndex +1; row++)
                    {
                        var value = doc.GetCellValueAsString(row, activeCellIndex);
                        if (value == "TRUE")
                        {
                            doc.SetCellValue(row, activeCellIndex, "Yes");
                        }
                        else if (value == "FALSE")
                        {
                            doc.SetCellValue(row, activeCellIndex, "No");
                        }
                    }

                    // set the column header stype
                    var headerSyle = doc.CreateStyle();
                    headerSyle.Font.FontColor = SysDraw.Color.White;
                    headerSyle.Font.Strike = false;
                    headerSyle.Fill.SetPattern(PatternValues.Solid, SysDraw.Color.Green, SysDraw.Color.White);
                    headerSyle.Font.Underline = UnderlineValues.None;
                    headerSyle.Font.Bold = true;
                    headerSyle.Font.Italic = false;
                    doc.SetCellStyle(1, 1, 1, pDataTable.Columns.Count, headerSyle);

                    // set one column to auto fit
                    //doc.AutoFitColumn(birthDayCellIndex, stats.EndRowIndex + 1);

                    // set all columns to auto fix beginning at data rather than column header
                    doc.AutoFitColumn(2, pDataTable.Columns.Count);

                    // save to the document we opened rather than a new document.
                    doc.Save();

                    success = true;
                }
            }
            catch (Exception ex)
            {
                HasErrors = true;
                ExceptionMessage = ex.Message;
                success = false;
            }


            return success;
        }
        /// <summary>
        /// Focus here is on removal of grid-lines while using code from 
        /// ImportDataTable2 method above. Also removed header formatting.
        /// </summary>
        /// <param name="pFileName">Existing excel file</param>
        /// <param name="pStartReference">Row to start import</param>
        /// <param name="pDataTable">Data source</param>
        /// <param name="pIncludeHeaders">Should column headers be used (currently only does headers)</param>
        /// <returns></returns>
        public bool ImportDataTable3(string pFileName, string pStartReference, DataTable pDataTable, bool pIncludeHeaders = true)
        {
            bool success = false;

            var sheetName = "Demo3";

            try
            {
                // open to Sheet1 (will always exists in this code sample)
                using (SLDocument doc = new SLDocument(pFileName, "Sheet1"))
                {

                    var helper = new LightHelpers();

                    if (helper.SheetExists(pFileName, sheetName))
                    {
                        doc.DeleteWorksheet(sheetName);
                    }

                    // add the sheet
                    doc.AddWorksheet(sheetName);

                    var isSet = doc.SelectWorksheet(sheetName);

                    // next three lines are responsible for removal of grid-lines in the current WorkSheet
                    SLPageSettings ps = new SLPageSettings();
                    ps.ShowGridLines = false;
                    doc.SetPageSettings(ps);

                    // setup a format for the date column
                    var birthdayColumnStyle = doc.CreateStyle();
                    birthdayColumnStyle.FormatCode = "mm-dd-yyyy";

                    // since we need these several times, set them up as variables
                    var activeCellIndex = pDataTable.Columns["Active"].Ordinal + 1;
                    var birthDayCellIndex = pDataTable.Columns["BirthDay"].Ordinal + 1;

                    // set birthday style to our data
                    doc.SetCellStyle(2, birthDayCellIndex, pDataTable.Rows.Count + 1, birthDayCellIndex, birthdayColumnStyle);

                    // do the Datatable import.
                    doc.ImportDataTable(pStartReference, pDataTable, pIncludeHeaders);

                    SLWorksheetStatistics stats = doc.GetWorksheetStatistics();

                    // change format of the bool column
                    for (int row = 1; row < stats.EndRowIndex + 1; row++)
                    {
                        var value = doc.GetCellValueAsString(row, activeCellIndex);
                        if (value == "TRUE")
                        {
                            doc.SetCellValue(row, activeCellIndex, "Yes");
                        }
                        else if (value == "FALSE")
                        {
                            doc.SetCellValue(row, activeCellIndex, "No");
                        }
                    }

                    // does what it says, auto-fit cell content
                    doc.AutoFitColumn(2, pDataTable.Columns.Count);

                    doc.Save();

                    success = true;
                }
            }
            catch (Exception ex)
            {
                HasErrors = true;
                ExceptionMessage = ex.Message;
                success = false;
            }


            return success;
        }

        /// <summary>
        /// Based on ImportDataTable2, added background color to odd rows,
        /// conditional formatting, in this case the State column.
        /// </summary>
        /// <param name="pFileName">Existing excel file</param>
        /// <param name="pStartReference">Row to start import</param>
        /// <param name="pDataTable">Data source</param>
        /// <param name="pIncludeHeaders">Should column headers be used (currently only does headers)</param>
        /// <returns></returns>
        public bool ImportDataTable4(string pFileName, string pStartReference, DataTable pDataTable, bool pIncludeHeaders = true) 
        {
            bool success = false;

            var sheetName = "Demo4";

            try
            {
                // open to Sheet1 (will always exists in this code sample)
                using (SLDocument doc = new SLDocument(pFileName, "Sheet1"))
                {
                    var helper = new LightHelpers();
                    if (helper.SheetExists(pFileName, sheetName))
                    {
                        doc.DeleteWorksheet(sheetName);
                    }

                    // add the sheet
                    doc.AddWorksheet(sheetName);

                    var isSet = doc.SelectWorksheet(sheetName);

                    // next three lines are responsible for removal of grid-lines in the current WorkSheet
                    SLPageSettings ps = new SLPageSettings();
                    ps.ShowGridLines = false;
                    doc.SetPageSettings(ps);

                    // setup a format for the date column
                    var birthdayColumnStyle = doc.CreateStyle();
                    birthdayColumnStyle.FormatCode = "mm-dd-yyyy";

                    // create style for odd rows (we skip the header row)
                    var oddRowStyle = doc.CreateStyle();
                    oddRowStyle.SetPatternFill(PatternValues.LightGray, SLThemeColorIndexValues.Accent3Color, SLThemeColorIndexValues.Accent3Color);
                    
                    var moCellStyle = doc.CreateStyle();
                    moCellStyle.Font.Bold = true;
                    moCellStyle.Font.FontColor = SysDraw.Color.Red;

                    // since we need these several times, set them up as variables
                    var activeCellIndex = pDataTable.Columns["Active"].Ordinal + 1;
                    var birthDayCellIndex = pDataTable.Columns["BirthDay"].Ordinal + 1;

                    // set birthday style to our data
                    doc.SetCellStyle(2, birthDayCellIndex, pDataTable.Rows.Count + 1, birthDayCellIndex, birthdayColumnStyle);

                    // do the Datatable import.
                    doc.ImportDataTable(pStartReference, pDataTable, pIncludeHeaders);

                    SLWorksheetStatistics stats = doc.GetWorksheetStatistics();

                    // change format of the bool column
                    for (int row = 1; row < stats.EndRowIndex + 1; row++)
                    {

                        var value = doc.GetCellValueAsString(row, activeCellIndex);
                        if (value == "TRUE")
                        {
                            doc.SetCellValue(row, activeCellIndex, "Yes");
                        }
                        else if (value == "FALSE")
                        {
                            doc.SetCellValue(row, activeCellIndex, "No");
                        }

                        // apply background color style to odd rows
                        if (row.IsOdd() && row >1)
                        {
                            doc.SetRowStyle(row, oddRowStyle);
                        }
                        else
                        {
                            var cellReference = SLConvert.ToCellReference(row, 6);
                            var stateValue = doc.GetCellValueAsString(cellReference);
                            if (stateValue == "MO")
                            {
                                doc.SetCellStyle(cellReference, moCellStyle);
                            }
                        }
                    }

                    // delete the primary key column
                    doc.DeleteColumn(1, 1);

                    // does what it says, auto-fit cell content
                    doc.AutoFitColumn(2, pDataTable.Columns.Count);

                    // de-select the current sheet and select sheet1
                    doc.SelectWorksheet("Sheet1");
                    doc.Save();

                    success = true;
                }
            }
            catch (Exception ex)
            {
                HasErrors = true;
                ExceptionMessage = ex.Message;
                success = false;
            }

            return success;

        }
    }
}
