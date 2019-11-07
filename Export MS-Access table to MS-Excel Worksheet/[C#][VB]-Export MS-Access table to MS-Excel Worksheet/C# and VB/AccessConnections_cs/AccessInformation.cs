using System.Collections.Generic;
using System.Linq;
using System.Data.OleDb;
using System.Data;
using System;

namespace AccessConnections_cs
{
    /// <summary>
    /// Methods to obtain table names and columns for tables in a ms-access database.
    /// These are not optimized, did them for demo purposes only. They can be optimized :-)
    /// </summary>
    public class AccessInformation
    {
        /// <summary>
        /// Key is table name, values are columns for table
        /// </summary>
        public Dictionary<string, List<string>> ColumnDict { get; set; }
        /// <summary>
        /// Get user table names from database
        /// </summary>
        /// <param name="DatabaseName">Existing database path and name</param>
        /// <returns></returns>
        public List<string> TableNames(string DatabaseName)
        {
            List<string> Names = new List<string>();

            using (OleDbConnection cn = new OleDbConnection { ConnectionString = DatabaseName.BuildConnectionString() })
            {

                cn.Open();

                Names = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null)
                    .AsEnumerable()
                    .Where((col) => col.Field<string>("TABLE_TYPE") == "TABLE")
                    .Select((data) => data.Field<string>("TABLE_NAME"))
                    .ToList();

            }

            return Names;

        }
        public void TryDropTable(string DatabaseName, string TableName)
        {
            var Names = TableNames(DatabaseName);
            if (Names.Contains(TableName))
            {
                using (OleDbConnection cn = new OleDbConnection { ConnectionString = DatabaseName.BuildConnectionString() })
                {
                    using (OleDbCommand cmd = new OleDbCommand { Connection = cn, CommandText = $"DROP TABLE {TableName}" })
                    {
                        cn.Open();
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            //
                            // Discard exception for this sample but for a real app the exception should be delt with.
                            //
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Get column names for a specific table
        /// </summary>
        /// <param name="DatabaseName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public List<string> GetColumnNames(string DatabaseName, string TableName)
        {
            List<string> Names = new List<string>();
            using (OleDbConnection cn = new OleDbConnection { ConnectionString = DatabaseName.BuildConnectionString() })
            {
                string[] filterValues = { null, null, TableName, null };
                cn.Open();

                Names = cn.GetSchema("Columns", filterValues).AsEnumerable().Select((data) => $"[{data.Field<string>("COLUMN_NAME")}]").ToList();
            }

            return Names;

        }
        /// <summary>
        /// Get columns for each table in database
        /// </summary>
        /// <param name="DatabaseName"></param>
        public void GetTableColumnInformation(string DatabaseName)
        {
            ColumnDict = new Dictionary<string, List<string>>();

            var Names = TableNames(DatabaseName);
            foreach (string table in Names)
            {
                var ColNames = GetColumnNames(DatabaseName, table);

                ColumnDict.Add(table, ColNames);
            }
        }
    }
}
