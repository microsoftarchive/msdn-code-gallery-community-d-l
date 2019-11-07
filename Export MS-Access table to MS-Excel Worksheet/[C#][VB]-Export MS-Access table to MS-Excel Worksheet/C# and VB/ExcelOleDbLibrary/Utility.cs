using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace ExcelOleDbLibrary
{
    /// <summary>
    /// Taken from another MSDN code sample I wrote.
    /// </summary>
    public class Utility
    {
        public Utility()
        {
        }
        public bool TableExists(string ConnectionString, string TableName)
        {
            bool Result = false;

            using (OleDbConnection cn = new OleDbConnection(ConnectionString))
            {
                cn.Open();
                DataTable dt = new DataTable { TableName = "test" };
                dt = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                cn.Close();

                var query = (
                    from F in dt.Rows.Cast<DataRow>()
                    where F.Field<string>("TABLE_NAME").ToString() == TableName
                    select F).FirstOrDefault();

                if (query != null)
                {
                    Result = true;
                }

            }

            return Result;

        }
        /// <summary>
        /// Returns a list of sheet names from Excel or table names from Access
        /// </summary>
        /// <param name="ConnectionString"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<SheetNameData> SheetNames(string ConnectionString)
        {
            List<SheetNameData> Names = new List<SheetNameData>();

            using (OleDbConnection cn = new OleDbConnection(ConnectionString))
            {

                cn.Open();

                DataTable dt = new DataTable { TableName = "AvailableSheetsTables" };
                dt = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });


                Names = 
                    (
                        from F in dt.Rows.Cast<DataRow>()
                        select new SheetNameData
                            {
                                DisplayName = F.Field<string>("TABLE_NAME").Replace("$", ""),
                                ActualName = F.Field<string>("TABLE_NAME")
                            }
                    ).ToList();

            }

            return Names;

        }
        /// <summary>
        /// Get column names for a connection that has HDR = Yes
        /// </summary>
        /// <param name="ConnectionString"></param>
        /// <param name="SheetName"></param>
        /// <returns></returns>
        /// <remarks>
        /// You could use this with HDR = No but here we are
        /// using it with HDR = Yes
        /// 
        /// Also, we can get column schema from the connection and 
        /// order column names by Ordinal_Position so that Column_Name
        /// column will not be ordered.
        /// </remarks>
        public List<string> GetColumnNames(string ConnectionString, string SheetName)
        {
            List<string> ColumnNames = new List<string>();
            using (OleDbConnection cn = new OleDbConnection(ConnectionString))
            {
                cn.Open();
                using (OleDbCommand cmd = new OleDbCommand(string.Format("select * from [{0}]", SheetName), cn))
                {
                    using (var reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly))
                    {
                        DataTable dt = reader.GetSchemaTable();
                        var nameCol = dt.Columns["ColumnName"];
                        foreach (DataRow row in dt.Rows)
                        {
                            ColumnNames.Add(row[nameCol].ToString());
                        }
                    }
                }
            }

            return ColumnNames;

        }
    }
}
