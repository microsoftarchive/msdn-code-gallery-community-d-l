using System;
using System.Data.SqlClient;
namespace WindowsFormsApplication1
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class DataOperations
    {
        private DataTable CustomerDataTable;
        public DataTable GetCustomers()
        {
            return CustomerDataTable;
        }
        /// <summary>
        /// Load data, rather than use DataTable.Load we cycle through rows else the Load method 
        /// will mark the primary key as read-only which means no way to set the primary key and
        /// would cause us to reload the data and set the current record.        /// </summary>
        /// <remarks></remarks>
        public DataOperations()
        {

            this.CustomerDataTable = new DataTable();
            this.CustomerDataTable.Columns.Add(new DataColumn { ColumnName = "Identifier", DataType = typeof(int) });
            this.CustomerDataTable.Columns.Add(new DataColumn { ColumnName = "CompanyName", DataType = typeof(string) });
            this.CustomerDataTable.Columns.Add(new DataColumn { ColumnName = "ContactName", DataType = typeof(string) });
            this.CustomerDataTable.Columns.Add(new DataColumn { ColumnName = "ContactTitle", DataType = typeof(string) });

            using (SqlConnection cn = new SqlConnection { ConnectionString = Properties.Settings.Default.ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "SELECT Identifier, CompanyName, ContactName, ContactTitle FROM Customer ORDER BY Identifier";
                    cn.Open();
                    var Reader = cmd.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        while (Reader.Read())
                        {
                            this.CustomerDataTable.Rows.Add(new object[] { Reader.GetInt32(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3) });
                        }
                    }
                }
            }

            this.CustomerDataTable.AcceptChanges();

        }
        /// <summary>
        /// Remove a single row from Customer table
        /// </summary>
        /// <param name="Identifier"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool RemoveRow(int Identifier)
        {
            bool Result = false;
            using (SqlConnection cn = new SqlConnection { ConnectionString = Properties.Settings.Default.ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = "DELETE FROM Customer WHERE Identifier = " + Identifier.ToString() })
                {
                    cn.Open();
                    Result = (cmd.ExecuteNonQuery() == 1);
                }
            }
            return Result;
        }
        /// <summary>
        /// Responsible for removing more than one row.
        /// 
        /// Options
        ///  - pass in selected rows from the DataGridView, get identifier and do delete
        ///  - add a checkbox column, pass in rows selected and use identifier to delete
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Rather than present one method of the above none are done as it shouldf be
        /// easy enough for you the reader to implement
        /// </remarks>
        public bool RemoveRows()
        {
            throw new NotImplementedException("TODO");
        }
        private string UpdateStatement = "UPDATE Customer SET CompanyName = @CompanyName, ContactName = @ContactName,ContactTitle = @ContactTitle WHERE Identifier = @Identifier";
        /// <summary>
        /// Responsible for updating rows that have 
        /// Row.RowState = Modified
        /// 
        /// Use the same logic as done in the add method below.
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        /// <remarks>
        /// Once you understand the logic in add rows you will be capable
        /// to implement this method
        /// </remarks>
        public bool UpdateRow(DataRow row)
        {
            bool Result = false;
            using (SqlConnection cn = new SqlConnection { ConnectionString = Properties.Settings.Default.ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = UpdateStatement;
                    cmd.Parameters.AddWithValue("@CompanyName", row.Field<string>("CompanyName"));
                    cmd.Parameters.AddWithValue("@ContactName", row.Field<string>("ContactName"));
                    cmd.Parameters.AddWithValue("@ContactTitle", row.Field<string>("ContactTitle"));
                    cmd.Parameters.AddWithValue("@Identifier", row.Field<int>("Identifier"));
                    cn.Open();
                    try
                    {
                        if (Convert.ToInt32(cmd.ExecuteNonQuery()) == 1)
                        {
                            Result = true;
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return Result;
        }
        public bool UpdateRows(DataTable table)
        {
            throw new NotImplementedException("TODO");
        }
        /// <summary>
        /// Add new rows from the DataTable passed to us
        /// </summary>
        /// <param name="table"></param>
        /// <remarks></remarks>
        public void AddCustomers(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                if (row.RowState == DataRowState.Added)
                {
                    if (!(string.IsNullOrWhiteSpace(row.Field<string>("CompanyName"))))
                    {
                        int NewIdentifier = 0;
                        if (AddNewCustomer(row.Field<string>("CompanyName"), row.Field<string>("ContactName"), row.Field<string>("ContactTitle"), ref NewIdentifier))
                        {
                            row.SetField<int>("Identifier", NewIdentifier);
                        }
                    }

                }
            }

            table.AcceptChanges();

        }
        private string InsertStatement = "INSERT INTO Customer (CompanyName,ContactName,ContactTitle) VALUES (@CompanyName,@ContactName,@ContactTitle); SELECT CAST(scope_identity() AS int);";
        /// <summary>
        /// Called from AddCustomers to add a single new record
        /// </summary>
        /// <param name="CompanyName"></param>
        /// <param name="ContactName"></param>
        /// <param name="ContactTitle"></param>
        /// <param name="NewIdentifier"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool AddNewCustomer(string CompanyName, string ContactName, string ContactTitle, ref int NewIdentifier)
        {
            using (SqlConnection cn = new SqlConnection { ConnectionString = Properties.Settings.Default.ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = InsertStatement;
                    cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                    cmd.Parameters.AddWithValue("@ContactName", ContactName);
                    cmd.Parameters.AddWithValue("@ContactTitle", ContactTitle);
                    cn.Open();
                    try
                    {
                        NewIdentifier = Convert.ToInt32(cmd.ExecuteScalar());
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }
    }
}
