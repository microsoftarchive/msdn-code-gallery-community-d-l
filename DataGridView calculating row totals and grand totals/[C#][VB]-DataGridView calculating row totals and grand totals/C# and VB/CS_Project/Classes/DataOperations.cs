using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;

namespace CS_Example
{
    public class DataOperations
    {
        private string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DataBase1.accdb";

        public DataTable DataTable { get; set; }
        /// <summary>
        /// Utilized in the form to validate data as each field we are
        /// interested in is a month name
        /// </summary>
        private string[] MonthNames = { };

        public string[] ColumnNames { get { return MonthNames; } }

        /// <summary>
        /// Name of field that is our expression column
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string RowTotalFieldName { get { return "LineTotal"; } }

        public DataOperations()
        {
            MonthNames = (from month in CultureInfo.CurrentCulture.DateTimeFormat.MonthNames where !(string.IsNullOrWhiteSpace(month)) select month).ToArray();
        }

        public void LoadData()
        {
            DataTable = new DataTable { TableName = "Sales" };

            using (OleDbConnection cn = new OleDbConnection { ConnectionString = ConnectionString })
            {
                using (OleDbCommand cmd = new OleDbCommand { Connection = cn })
                {
                    cmd.CommandText = "SELECT Identifier,TheYear," + string.Join(",", MonthNames) + " FROM Sales";
                    cn.Open();

                    DataTable.Load(cmd.ExecuteReader());
                    DataTable.Columns["Identifier"].ColumnMapping = MappingType.Hidden;
                    DataTable.Columns["TheYear"].ReadOnly = true;

                    foreach (var mName in MonthNames)
                    {
                        if (DataTable.Columns.Contains(mName))
                        {
                            DataTable.Columns[mName].DefaultValue = 0;
                        }
                    }
                }
            }

            DataTable.Columns.Add(new DataColumn { ColumnName = RowTotalFieldName, DataType = typeof(int), Expression = string.Join(" + ", MonthNames) });
        }
    }
}