using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fileprocess
{
    /// <summary>
    /// Reading data from excel and process it.
    /// </summary>
    public class ExcelParser:BaseParser
    {
        public ExcelParser()
            : base()
        {
        }
        /// <summary>
        /// Read the data from excel and process it
        /// </summary>
        public override void Read()
        {
            OleDbCommand cmd = GetReader();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                   IEmployeeResult emp= ConvertToObject.Getobject(reader);
                   EmployeeValidation.Validate(emp);
                   Results.Add(emp);
                   
                }
            }
           
        }

        /// <summary>
        /// Getting the reader object from excel odbc driver based on excel version
        /// </summary>
        /// <returns></returns>
        private OleDbCommand GetReader()
        {
            string connString = "";
            string strFileType = Path.GetExtension(FileName).ToLower();
            string path = FileName;
            //Connection String to Excel Workbook
            if (strFileType.Trim() == ".xls")
            {
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            else if (strFileType.Trim() == ".xlsx")
            {
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }

            OleDbCommand cmd=null;
            string query = "SELECT [Name],[DOB],[Sal],[EmpNo] FROM [Sheet1$]";
            OleDbConnection conn = new OleDbConnection(connString);
            
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                 cmd = new OleDbCommand(query, conn);
            
            return cmd;
        }

        public override string ToString()
        {
            return ParserType.EXCEL.ToString();
        }
    }
}
