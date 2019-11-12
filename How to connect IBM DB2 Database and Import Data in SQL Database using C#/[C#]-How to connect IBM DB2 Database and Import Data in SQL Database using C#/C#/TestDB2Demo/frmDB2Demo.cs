using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace TestDB2Demo
{
    public partial class frmDB2Demo : Form
    {
        public frmDB2Demo()
        {
            InitializeComponent();
        }

        private void btnPublishData_Click(object sender, EventArgs e)
        {
            string sQuery1 = string.Empty;
            string sQuery2 = string.Empty;
            string sQuery3 = string.Empty;
            string message = string.Empty;

            IBM.Data.DB2.DB2Connection conn = null;
            DataTable dt = new DataTable("Table1");
            try
            {
                conn = ConnectDb();
                switch (cmbTransactionType.SelectedIndex)
                {
                    case 0:
                        sQuery1 = "SELECT * FROM DEPOSIT FETCH FIRST 5 ROWS ONLY";
                        break;
                    case 1:
                        sQuery1 = "SELECT * FROM LOAN FETCH FIRST 5 ROWS ONLY";
                        break;
                }
                using (IBM.Data.DB2.DB2Command cmd = new IBM.Data.DB2.DB2Command(sQuery1, conn))
                {
                    IBM.Data.DB2.DB2DataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                }
                conn.Close();
                if (dt.Rows.Count <= 0)
                    message = "No Record Exist !!!";
                else
                {
                    SaveData(dt);
                    message = "Successfully Imported '" + cmbTransactionType.Text + "' Data !!!";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            MessageBox.Show(message, "Import from DB2 Utility", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Helper method: This method establishes a connection to a database
        private IBM.Data.DB2.DB2Connection ConnectDb()
        {
            String server = txtHostName.Text.Trim();
            String alias = txtDatabaseName.Text.Trim();
            String userId = txtUserId.Text.Trim();
            String password = txtPwd.Text.Trim();
            String portNumber = txtPortNumber.Text.Trim();
            String connectString;
            try
            {
                connectString = "Server=" + server + ":" + portNumber + ";Database=" + alias;
                if (userId != "")
                {
                    connectString += ";UID=" + userId + ";PWD=" + password;
                }

                IBM.Data.DB2.DB2Connection conn = new IBM.Data.DB2.DB2Connection(connectString);
                conn.Open();
                return conn;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private SqlConnection ConnectSQLDB()
        {
            String server = txtDataSource.Text.Trim();
            String alias = txtDBName.Text.Trim();
            String userId = txtUId.Text.Trim();
            String password = txtPassword.Text.Trim();
            String connectString;
            try
            {
                connectString = "Data Source=" + server + ";Initial Catalog=" + alias;
                if (userId != "")
                {
                    connectString += ";User id=" + userId + ";Password=" + password;
                }
                SqlConnection conn = new SqlConnection(connectString);
                conn.Open();
                return conn;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void SaveData(DataTable dt)
        {
            try
            {
                SqlConnection sqlconn = ConnectSQLDB();

                foreach (DataRow dritem in dt.Rows)
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = CreateSqlQuery(dritem, sqlconn);
                        cmd.Connection = sqlconn;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                }

                sqlconn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string CreateSqlQuery(DataRow dritem, SqlConnection conn)
        {
            string sQuery = string.Empty;
            Int64 recid = 1;

            switch (cmbTransactionType.SelectedIndex)
            {
                case 0:
                    recid = GenerateRecId("DEPOSITS", conn);

                    sQuery = "INSERT INTO [DEPOSITS] ([WK_ACCOUNT],[WK_ACCUM1],[WK_ACCUM1_DEC],[WK_ACCUM2],[WK_ACCUM2_DEC],[DATAAREAID],[RECVERSION],[RECID]) VALUES ";
                    sQuery += "('" + dritem["WK_ACCOUNT"] + "','" + dritem["WK_ACCUM1"] + "','" + dritem["WK_ACCUM1_DEC"] + "',";
                    sQuery += "'" + dritem["WK_ACCUM2"] + "', '" + dritem["WK_ACCUM2_DEC"] + "', 'CEU',1," + recid + ")";
                    break;
                case 1:
                    recid = GenerateRecId("LOANS", conn);

                    sQuery = "INSERT INTO LOANS ([ACCT_EFF_DATE],[ACCT_PROD],[ACCT_STAT],[ACCT_TYPE],[ALSEZRT_KEY],[DATAAREAID],[RECVERSION],[RECID]) VALUES ";
                    sQuery += "('" + dritem["ACCT_EFF_DATE"] + "','" + dritem["ACCT_PROD"] + "','" + dritem["ACCT_STAT"] + "',";
                    sQuery += "'" + dritem["ACCT_TYPE"] + "', '" + dritem["ALSEZRT_KEY"] + "', 'CEU',1," + recid + ")";
                    break;
            }

            return sQuery;
        }

        private void frmDB2Demo_Load(object sender, EventArgs e)
        {
            cmbTransactionType.SelectedIndex = 0;

            txtDatabaseName.Text = "S390LOC";
            txtHostName.Text = "66.243.3.120";
            txtPortNumber.Text = "446";
            txtUserId.Text = "TestUser";
            txtPwd.Text = "Pass123";

            txtDataSource.Text = "SQLDB";
            txtDBName.Text = "TESTDB";
            txtPassword.Text = "pass123";
            txtUId.Text = "sa";

        }

        private Int64 GenerateRecId(string sTableName, SqlConnection conn)
        {
            Int64 recid = 1;
            object objid = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "Select recid from " + sTableName + " ORDER BY recid DESC";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                objid = cmd.ExecuteScalar();
            }
            if (objid != null)
                recid = Convert.ToInt64(objid) + 1;
            return recid;
        }

        private void btnDB2Connection_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            try
            {
                IBM.Data.DB2.DB2Connection conn = ConnectDb();
                message = "DB2 Connection Successful !";
                conn.Close();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            MessageBox.Show(message, "Import from DB2 Utility", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSQLConnection_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            try
            {
                SqlConnection conn = ConnectSQLDB();
                message = "SQL Connection Successful !";
                conn.Close();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            MessageBox.Show(message, "Import from DB2 Utility", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
