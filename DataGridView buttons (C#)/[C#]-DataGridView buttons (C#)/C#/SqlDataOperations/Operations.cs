using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBaseLibrary;

namespace SqlDataOperations
{
    /// <summary>
    /// BaseSqlServerConnections handles connections which can be overridden
    /// along with implementing BaseExeptionhandler for implementing default 
    /// exception handling in try/catch statements
    /// </summary>
    public class Operations : BaseSqlServerConnections
    {
        public Operations()
        {
            DefaultCatalog = "NorthWindAzure";
        }

        public DataTable LoadCustomerData(bool pHidePrimaryKey = true)
        {
            mHasException = false;

            var dt = new DataTable();
            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    try
                    {
                        cmd.CommandText = 
                            "SELECT C.CustomerIdentifier, C.CompanyName, C.ContactName, ContactType.ContactTitle, " + 
                                   "C.City, C.Country, C.ContactTypeIdentifier " + 
                             "FROM dbo.Customers AS C " + 
                             "INNER JOIN ContactType ON C.ContactTypeIdentifier = ContactType.ContactTypeIdentifier;";

                        cn.Open();
                        dt.Load(cmd.ExecuteReader());

                        dt.Columns["ContactTypeIdentifier"].ColumnMapping = MappingType.Hidden;

                        if (pHidePrimaryKey)
                        {
                            dt.Columns["CustomerIdentifier"].ColumnMapping = MappingType.Hidden;
                        }
                    }
                    catch (Exception ex)
                    {
                        mHasException = true;
                        mLastException = ex;
                    }
                }
            }

            return dt;
        }
        public IEnumerable<Customer> GetCustomersLimitedViaIterator()
        {
            mHasException = false;
            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {

                    cmd.CommandText = "SELECT CustomerIdentifier, CompanyName, ContactName FROM dbo.Customers";
                    SqlDataReader reader = null;
                    try
                    {
                        cn.Open();
                        reader = cmd.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        mHasException = true;
                        mLastException = ex;
                    }

                    while (reader.Read())
                    {
                        yield return new Customer()
                        {
                            CustomerIdentifier = reader.GetInt32(0),
                            CompanyName = reader.GetString(1),
                            ContactName = reader.GetString(2)
                        };
                    }

                }
            }
        }
        public List<ContactType> LoadContactTypes()
        {
            mHasException = false;
            var contactList = new List<ContactType>();

            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    cmd.CommandText = "SELECT ContactTypeIdentifier,ContactTitle  FROM dbo.ContactType";
                    try
                    {
                        cn.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            contactList.Add(new ContactType() { ContactTypeIdentifier = reader.GetInt32(0), ContactTitle = reader.GetString(1) });
                        }
                    }
                    catch (Exception ex)
                    {
                        mHasException = true;
                        mLastException = ex;
                    }
                }
            }

            return contactList;
        }
        #region Stub methods for remove and update

        /// <summary>
        /// Here is where you would have a DELETE statement to remove
        /// the record by primary key
        /// </summary>
        /// <param name="pIdentifier"></param>
        /// <returns></returns>
        public bool FakeRemoveCustomer(int pIdentifier)
        {
            return true;
        }
        /// <summary>
        /// Here is where you would update the customer by the
        /// primary key in the DataRow followed by using field
        /// values to use in the SET part of the UPDATE statement.
        /// </summary>
        /// <param name="pRow"></param>
        /// <returns></returns>
        public bool FakeUpdateCustomer(DataRow pRow)
        {
            return true;
        }

        #endregion
    }
}
