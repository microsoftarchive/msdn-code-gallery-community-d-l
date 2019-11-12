using AccessConnections_cs;
using ExcelOleDbLibrary;
using ExportAccessToExcel;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleExports_cs
{
    public class ExportOperations
    {
        private string msAccessFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Biblio1.accdb");
        private string msExcelFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Biblio1.xlsx");
        public string ExeptionMessage { get; set; }
        public bool HasErrors { get; set; }

        private string TempTableName = "TempSample1";
        public int RecordsInserted { get; set; }
        public void ExportData()
        {
            if (MakeTempTableAccess())
            {
                Connections cons = new Connections();

                ExportToExcel ops = new ExportToExcel
                {
                    DatabaseName = msAccessFileName,
                    Headers = false,
                    ExcelFileName = msExcelFile,
                    TableName = TempTableName,
                    WorkSheetName = "Report1"
                };

                HasErrors = !ops.Execute();
                if (HasErrors)
                {
                    ExeptionMessage = ops.ExceptionMessage;
                }
                RecordsInserted = ops.RecordsInserted;
            }
        }
        /// <summary>
        /// Here we are selecting data from several tables and making a new table
        /// which is then used to export to Excel.
        /// </summary>
        /// <returns></returns>
        private bool MakeTempTableAccess()
        {
            bool success = false;

            AccessInformation info = new AccessInformation();

            info.TryDropTable(msAccessFileName, TempTableName);

            string MakeTableQuery = 
                "SELECT Titles.Title, " + 
                "Publishers.Name, Authors.Author, " + 
                "Titles.[Year Published], Titles.ISBN, " + 
                "Titles.Subject INTO TempSample1 " + 
                "FROM Publishers INNER JOIN (Authors INNER JOIN (Titles " + 
                "INNER JOIN TitleAuthor ON Titles.ISBN = TitleAuthor.ISBN) " + 
                "ON Authors.Au_ID = TitleAuthor.Au_ID) ON Publishers.PubID = Titles.PubID " + 
                "WHERE (((Publishers.Name) In ('ARTECH','CAMBRIDGE UNIV','WROX','DELMAR','IDG')) " + 
                "AND ((Titles.[Year Published])>=1995)) ORDER BY Publishers.Name;";

            using (OleDbConnection cn = new OleDbConnection { ConnectionString = msAccessFileName.BuildConnectionString() })
            {
                using (OleDbCommand cmd = new OleDbCommand { Connection = cn, CommandText = MakeTableQuery })
                {
                    cn.Open();
                    try
                    {
                        success = cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        HasErrors = true;
                        ExeptionMessage = ex.Message;
                    }

                }
            }

            return success;

        }

    }
}
