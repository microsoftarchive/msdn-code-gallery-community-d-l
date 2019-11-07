using System.Data.OleDb;
using System.IO;

namespace OleDbHelper_CS
{
    public class Connections
    {
        public Connections()
        {
        }

        /// <summary>
        /// Create a connection where first row contains column names
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="IMEX"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.Diagnostics.DebuggerStepThrough()]
        public string HeaderConnectionString(string FileName, int IMEX = 1)
        {
            OleDbConnectionStringBuilder Builder = new OleDbConnectionStringBuilder();
            if (Path.GetExtension(FileName).ToUpper() == ".XLS")
            {
                Builder.Provider = "Microsoft.Jet.OLEDB.4.0";
                Builder.Add("Extended Properties", string.Format("Excel 8.0;IMEX={0};HDR=Yes;", IMEX));
            }
            else
            {
                Builder.Provider = "Microsoft.ACE.OLEDB.12.0";
                Builder.Add("Extended Properties", string.Format("Excel 12.0;IMEX={0};HDR=Yes;", IMEX));
            }

            Builder.DataSource = FileName;

            return Builder.ToString();
        }

        /// <summary>
        /// Create a connection where first row contains data
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="IMEX"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.Diagnostics.DebuggerStepThrough()]
        public string NoHeaderConnectionString(string FileName, int IMEX = 1)
        {
            OleDbConnectionStringBuilder Builder = new OleDbConnectionStringBuilder();
            if (Path.GetExtension(FileName).ToUpper() == ".XLS")
            {
                Builder.Provider = "Microsoft.Jet.OLEDB.4.0";
                Builder.Add("Extended Properties", string.Format("Excel 8.0;IMEX={0};HDR=No;", IMEX));
            }
            else
            {
                Builder.Provider = "Microsoft.ACE.OLEDB.12.0";
                Builder.Add("Extended Properties", string.Format("Excel 12.0;IMEX={0};HDR=No;", IMEX));
            }

            Builder.DataSource = FileName;

            return Builder.ToString();
        }
    }
}