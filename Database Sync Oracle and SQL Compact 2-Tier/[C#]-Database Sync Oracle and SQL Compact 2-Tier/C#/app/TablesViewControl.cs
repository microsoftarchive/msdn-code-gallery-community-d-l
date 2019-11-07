using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.Data.SqlClient;
using System.Data.OracleClient;

namespace SyncApplication
{
    /// <summary>
    /// Custom control class that has two tabs to view the Orders and Order_Details table. Each new CE client
    /// added to the form with have this dynamic control added to its Controls and hence will display data from
    /// these two tables.
    /// </summary>
    public partial class TablesViewControl : UserControl
    {
        //use a delegate to load a dataset asynchronously
        internal delegate void ReadTableValuesAsyncDelegate(IDbConnection connection, string tableName);

        internal ReadTableValuesAsyncDelegate readTableValues;

        static object lockObject = new object();

        public TablesViewControl()
        {
            InitializeComponent();
            this.readTableValues = AsyncReadTableValueFromConnection;
        }

        public TablesViewControl(string name) : this()
        {
            this.name = name;
        }

        public DbDataAdapter ordersDataAdapter;
        public DbDataAdapter orderDetailsDataAdapter;
        public string name = "Server";

        //TODO fix asynxc bugs and make sure table values are populated asynchronoulsy
        public void ReadTableValues(IDbConnection connection, string tableName)
        {
            this.readTableValues.BeginInvoke(connection, tableName, EndAsyncReadTableValueFromConnection, this);
        }

        void EndAsyncReadTableValueFromConnection(IAsyncResult ar)
        {
            TablesViewControl tvc = ar.AsyncState as TablesViewControl;
            try
            {
                tvc.readTableValues.EndInvoke(ar);
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Unable to read table values for '{0}'. Check you connection string and retry. Error: {1}", tvc.name, e.ToString()));
            }
        }

        /// <summary>
        /// Reads values for specified table name from specified connection
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="tableName"></param>
        public void AsyncReadTableValueFromConnection(IDbConnection connection, string tableName)
        {
            string commandString = string.Format("Select order_id, {0} from {1}", (tableName == "orders") ? "order_date" : "order_details_id, product, quantity"
                                                                    , tableName);
            DbDataAdapter dataAdapter = null;
            if (connection is SqlCeConnection)
            {
                dataAdapter = new SqlCeDataAdapter(commandString, (SqlCeConnection)connection);
            }
            else if (connection is SqlConnection)
            {
                dataAdapter = new SqlDataAdapter(commandString, ((ICloneable)(SqlConnection)connection).Clone() as SqlConnection);
            }
            else
            {
                dataAdapter = new OracleDataAdapter(commandString, (OracleConnection)connection);
            }


            DataTable dataTable = new DataTable();
            lock (lockObject)
            {
                dataAdapter.Fill(dataTable);
            }

            if (tableName == "orders")
            {
                ordersDataAdapter = dataAdapter;
                ordersDataGrid.DataSource = dataTable;
            }
            else
            {
                orderDetailsDataAdapter = dataAdapter;
                orderDetailsDataGrid.DataSource = dataTable;
            }
        }

        //Update table values
        public void UpdateValues()
        {
            try
            {
                if (this.ordersDataAdapter != null)
                {
                    this.ordersDataAdapter.Update((DataTable)ordersDataGrid.DataSource);
                }
                if (this.orderDetailsDataAdapter != null)
                {
                    this.orderDetailsDataAdapter.Update((DataTable)orderDetailsDataGrid.DataSource);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString(), string.Format("Error in updating Table changes in Client '{0}'", name), MessageBoxButtons.OK);
            }
        }
    }
}
