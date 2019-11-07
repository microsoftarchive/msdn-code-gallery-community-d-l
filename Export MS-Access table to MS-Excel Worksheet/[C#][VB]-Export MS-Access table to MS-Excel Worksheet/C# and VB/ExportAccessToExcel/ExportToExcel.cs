using AccessConnections_cs;
using System;
using System.IO;
using System.Data.OleDb;

namespace ExportAccessToExcel
{
    public class ExportToExcel
    {
        /// <summary>
        /// MS-Access path and database name
        /// </summary>
        /// <returns></returns>
        public string DatabaseName { get; set; }
        /// <summary>
        /// SQL SELECT FROM MS-Access
        /// </summary>
        /// <returns></returns>
        public string SelectStatement { get; set; }
        /// <summary>
        /// Table name from MS-Access
        /// </summary>
        /// <returns></returns>
        public string TableName { get; set; }
        /// <summary>
        /// Excel file to place data into
        /// </summary>
        /// <returns></returns>
        public string ExcelFileName { get; set; }
        /// <summary>
        /// Sheet name to place MS-Access data
        /// </summary>
        /// <returns></returns>
        public string WorkSheetName { get; set; }
        /// <summary>
        /// Determine if colum names are the first row in the WorkSheet
        /// </summary>
        /// <returns></returns>
        /// <remarks>Currently does not function</remarks>
        public bool Headers { get; set; }
        public int RecordsInserted { get; set; }
        /// <summary>
        /// Used for when a export fails, caller can examine the cause.
        /// </summary>
        /// <returns></returns>
        public string ExceptionMessage { get; set; }
        public bool Execute(string SelectStatement = "*")
        {
            string Provider = "";
            bool Success = false;

            using (OleDbConnection cn = new OleDbConnection { ConnectionString = DatabaseName.BuildConnectionString() })
            {

                using (OleDbCommand cmd = new OleDbCommand { Connection = cn })
                {
                    //
                    // Determine the proper provider for Excel
                    //
                    if (Path.GetExtension(DatabaseName).ToLower() == ".mdb" && Path.GetExtension(ExcelFileName).ToLower() == ".xls")
                    {
                        Provider = "Excel 8.0;";
                    }
                    else if (Path.GetExtension(DatabaseName).ToLower() == ".accdb" && Path.GetExtension(ExcelFileName).ToLower() == ".xlsx")
                    {
                        Provider = "Excel 12.0 xml;";
                    }

                    cmd.CommandText = $"SELECT {SelectStatement} INTO [{Provider}DATABASE={ExcelFileName};HDR=No].[{WorkSheetName}] FROM [{TableName}]";

                    cn.Open();
                    try
                    {
                        // if you need, affected is the row count placed into the destination worksheet
                        RecordsInserted = cmd.ExecuteNonQuery();
                        Success = RecordsInserted > 0;
                    }
                    catch (Exception ex)
                    {
                        //
                        // If we get here and the exception is -> Data type mismatch in criteria expression
                        // the data type is not valid e.g. you attempted to place a binary field such as an image into the worksheet.
                        // We could query each field's data type and make a decision to abort and if so that needs to happen before
                        // cmd.ExecuteNonQuery() as after the fact the WorkSheet has already been created, the exception is raised
                        // after the Worksheet has been created so now you need to clean up and remove the WorkSheet which is beyond
                        // the scope of this code sample.
                        //                    '
                        ExceptionMessage = ex.Message;
                    }
                }

            }

            return Success;

        }
    }
}
