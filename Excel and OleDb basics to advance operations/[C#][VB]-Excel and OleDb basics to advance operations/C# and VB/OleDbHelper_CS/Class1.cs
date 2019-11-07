using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace OleDbHelper_CS
{
    internal class Class1
    {
        public Class1()
        {
            DataTable dt = new DataTable();
            List<string> Names = new List<string>();

            Connections Connection = new Connections();
            using (OleDbConnection cn = new OleDbConnection 
                { 
                    ConnectionString = Connection.HeaderConnectionString(
                    Properties.Settings.Default.FileName, 0) 
                })
            {
                using (OleDbCommand cmd = new OleDbCommand 
                    { 
                        Connection = cn, 
                        CommandText = string.Format("SELECT * FROM [{0}]", 
                        Properties.Settings.Default.SheetName) })
                {
                    cn.Open();
                    dt.Load(cmd.ExecuteReader());
                    foreach (DataRow row in dt.Rows)
                    {
                        Names.Add(row.Field<string>("CompanyName"));
                    }
                }
            }
        }
    }
}