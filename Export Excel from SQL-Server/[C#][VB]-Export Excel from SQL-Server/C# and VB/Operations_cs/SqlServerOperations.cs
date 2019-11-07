using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace Operations_cs
{
    public class SqlServerOperations : BaseSqlServerConnections
    {
        /// <summary>
        /// Will contain error message on failure of an operation
        /// </summary>
        public string ExceptionMessage { get; set; }
        /// <summary>
        /// Setup connection
        /// </summary>
        public SqlServerOperations()
        {
            DatabaseServer = "KARENS-PC";
            DefaultCatalog = "ExcelExporting";
        }
        /// <summary>
        /// Copy template excel file to app folder
        /// </summary>
        /// <param name="pFileName"></param>
        /// <returns></returns>
        public bool CopyToApplicationFolder(string pFileName)
        {

            try
            {
                File.Copy(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Files\\{Path.GetFileName(pFileName)}"), 
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pFileName), true);

                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        /// <summary>
        /// Copy template file to app folder with a different name
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pTargetFile"></param>
        /// <returns></returns>
        public bool CopyToApplicationFolder(string pFileName, string pTargetFile)
        {

            try
            {
                File.Copy(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Files\\{Path.GetFileName(pFileName)}"), 
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pTargetFile), true);

                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        /// <summary>
        /// Create a list of countries that has names without spaces
        /// </summary>
        /// <returns></returns>
        public List<CountryItem> CountryList()
        {
            List<CountryItem> countrys = new List<CountryItem>();
            countrys.Add(new CountryItem { Name = "Select" });

            using (var cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (var cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "SELECT DISTINCT Country  FROM Customers";

                    cn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows) return countrys;

                    while (reader.Read())
                    {
                        countrys.Add(new CountryItem { Name = reader.GetString(0) });
                    }
                }

            }

            return countrys;

        }
        /// <summary>
        /// Get list of contact titles, not used
        /// </summary>
        /// <returns></returns>
        public List<string> ContactTitleList()
        {
            var titleList = new List<string>();
            titleList.Add("Select");

            using (var cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (var cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "SELECT DISTINCT ContactTitle  FROM Customers";

                    cn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            titleList.Add(reader.GetString(0));
                        }
                    }
                }

            }

            return titleList;

        }
        /// <summary>
        /// Read data from table, not used
        /// </summary>
        /// <returns></returns>
        public DataTable GetCustomers()
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (var cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "SELECT id,FirstName,LastName,Address,City,State,ZipCode FROM Customer";

                    cn.Open();

                    dt.Load(cmd.ExecuteReader());

                }

            }

            return dt;

        }
        /// <summary>
        /// Export data to Excel
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pRowsExported">If successful will have count of rows exported</param>
        /// <returns></returns>
        public bool ExportAllCustomersToExcel(string pFileName, ref int pRowsExported)
        {
            if (!(File.Exists(pFileName)))
            {
                ExceptionMessage = $"Not found{Environment.NewLine}{pFileName}";
                return false;
            }

            using (var cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (var cmd = new SqlCommand { Connection = cn })
                {

                    cmd.CommandText = $"INSERT INTO OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'Excel 12.0;Database={pFileName}'," + 
                                      "'SELECT * FROM [Customers$]') SELECT CustomerIdentifier,CompanyName,ContactName," + 
                                      "ContactTitle,[Address],City,Region,PostalCode,Country,Phone FROM Customers";

                    cn.Open();

                    try
                    {

                        pRowsExported = cmd.ExecuteNonQuery();

                        return pRowsExported > 0;

                    }
                    catch (Exception ex)
                    {

                        ExceptionMessage = ex.Message;
                        return false;

                    }
                }
            }
        }
        /// <summary>
        /// Export data to Excel
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="Country">Name of country for filter</param>
        /// <param name="RowsExported">If successful will have count of rows exported</param>
        /// <returns></returns>
        public bool ExportByCountryNameCustomersToExcel(string FileName, string Country, ref int RowsExported)
        {
            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = $"INSERT INTO OPENROWSET('Microsoft.ACE.OLEDB.12.0','Excel 12.0;Database={FileName}','select * from [Customers$]') SELECT CustomerIdentifier,CompanyName,ContactName,ContactTitle,[Address],City,Region,PostalCode,Country,Phone FROM Customers WHERE Country = @Country";

                    cmd.Parameters.AddWithValue("@Country", Country);
                    cn.Open();

                    try
                    {

                        RowsExported = cmd.ExecuteNonQuery();

                        return RowsExported > 0;

                    }
                    catch (Exception ex)
                    {
                        //
                        // Possible causes if all is setup right in SQL-Server Management Studio
                        //   - invalid characters in file name, SQL-Server rejected them.
                        //   - Permissions on the folder or file
                        //
                        ExceptionMessage = $"Note: The following error may not appear as it is{Environment.NewLine}" + ex.Message;
                        return false;
                    }
                }
            }
        }
    }
}
