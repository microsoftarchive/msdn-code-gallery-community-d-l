using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelUsedLibrary
{
    public class OleConnectionBuilder
    {
        /// <summary>
        /// Create a connection for OleDb to an Excel file
        /// </summary>
        /// <param name="FileName">Excel file to work with</param>
        /// <param name="Header">YES or NO</param>
        /// <returns></returns>
        public string ConnectionString(string FileName, string Header)
        {
            OleDbConnectionStringBuilder Builder = new OleDbConnectionStringBuilder();
            if (System.IO.Path.GetExtension(FileName).ToUpper() == ".XLS")
            {
                Builder.Provider = "Microsoft.Jet.OLEDB.4.0";
                Builder.Add("Extended Properties", string.Format("Excel 8.0;IMEX=1;HDR={0};", Header));
            }
            else
            {
                Builder.Provider = "Microsoft.ACE.OLEDB.12.0";
                Builder.Add("Extended Properties", string.Format("Excel 12.0;IMEX=1;HDR={0};", Header));
            }

            Builder.DataSource = FileName;

            return Builder.ConnectionString;
        }

    }
}
