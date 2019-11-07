/****************** Copyright Notice *****************
 
This code is licensed under Microsoft Public License (Ms-PL). 
You are free to use, modify and distribute any portion of this code. 
The only requirement to do that, you need to keep the developer name, as provided below to recognize and encourage original work:

=======================================================
   
Architecture Designed and Implemented By:
Mohammad Ashraful Alam
Microsoft Most Valuable Professional, ASP.NET 2007 – 2011
Twitter: http://twitter.com/AshrafulAlam | Blog: http://blog.ashraful.net | Portfolio: http://www.ashraful.net
   
*******************************************************/
using System;
using System.Configuration;
using System.Data.EntityClient;
using System.Data.SqlClient;
using Eisk.DataAccessLayer;
using Eisk.Helpers;

namespace Eisk
{
    public partial class Install : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlUserCredential.Visible = !chkUseIntegratedSecurity.Checked;

            if (IsPostBack)
                txtPassword.Attributes.Add("value", txtPassword.Text);
        }

        protected void chkUseIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            pnlUserCredential.Visible = !chkUseIntegratedSecurity.Checked;
        }

        protected void buttonTestConnection_Click(object sender, EventArgs e)
        {
            string connectionStringErrorMessage = TestSqlClientConnectionString(ConnectionStringForMasterDatabase);

            if (connectionStringErrorMessage == string.Empty)
            {
                labelMessage.Text = MessageFormatter.GetFormattedSuccessMessage("Connection passed. Click the Create Database button to create database.");
                buttonCreateDatabase.Visible = true;
                pnlDbName.Visible = true;
                txtDbName.ReadOnly = false;
            }
            else
            {
                labelMessage.Text = MessageFormatter.GetFormattedErrorMessage(connectionStringErrorMessage);
                buttonCreateDatabase.Visible = false;
                buttonInstall.Visible = false;
                pnlDbName.Visible = false;
            }
        }

        protected void buttonCreateDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                string newConnectionString = BuildEntityFrameworkConnectionStringForSqlClient
                    (
                        txtServerAddress.Text,
                        txtDbName.Text,
                        chkUseIntegratedSecurity.Checked,
                        txtUsername.Text,
                        txtPassword.Text

                    );

                //create database 
                using (DatabaseContext _DatabaseContext = new DatabaseContext())
                {
                    ((EntityConnection)_DatabaseContext.Connection).StoreConnection.ConnectionString = BuildSqlClientConnectionString
                        (
                        txtServerAddress.Text,
                        txtDbName.Text,
                        chkUseIntegratedSecurity.Checked,
                        txtUsername.Text,
                        txtPassword.Text

                    );

                    if (!_DatabaseContext.DatabaseExists())
                    {
                        _DatabaseContext.CreateDatabase();
                    }
                }

                //save the new db connectionstring to config files

                SaveConnectionStringKey(Server.MapPath("~/web.config"), "DatabaseContext", newConnectionString);

                //show the proper message
                labelMessage.Text = MessageFormatter.GetFormattedNoticeMessage("Database created successfully. Click the Create 'Install Schema and Data' button to install database.");
                buttonInstall.Visible = true;
                txtDbName.ReadOnly = true;
            }
            catch (Exception ex)
            {
                labelMessage.Text = MessageFormatter.GetFormattedErrorMessage("Database creation failed: " + ex.Message);
                buttonInstall.Visible = false;
            }
        }

        protected void buttonInstall_Click(object sender, EventArgs e)
        {
            try
            {
                SqlScriptRunner.RunScript(Server.MapPath("~") + @"\App_Data\SQL\Schema\Create-Schema.sql");
                SqlScriptRunner.RunScript(Server.MapPath("~") + @"\App_Data\SQL\Data\Create-Data.sql");
                labelMessage.Text = MessageFormatter.GetFormattedSuccessMessage("Congratulations! Database installation successful. Click <a href=\"../../../default.aspx\">here </a>to start using Employee Info Starter Kit.");
            }
            catch (Exception ex)
            {
                labelMessage.Text = MessageFormatter.GetFormattedErrorMessage("Database installation failed. Please provide a appropriate creadential that has permission to install database. <br>" + ex.ToString() );
            }
        }

        #region Utility methods

        string ConnectionStringForMasterDatabase
        {
            get
            {
                if (chkUseIntegratedSecurity.Checked)
                    return BuildSqlClientConnectionString(txtServerAddress.Text);
                else
                    return BuildSqlClientConnectionString(txtServerAddress.Text, "", false, txtUsername.Text, txtPassword.Text);
            }
        }


        string BuildEntityFrameworkConnectionStringForSqlClient(string dataSource, string database = "", bool integratedSecurity = true, string userName = "", string password = "")
        {
            string providerName = "System.Data.SqlClient";

            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder =
                new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = providerName;

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = BuildSqlClientConnectionString(dataSource, database, integratedSecurity, userName, password);

            // Set the Metadata location.
            entityBuilder.Metadata = @"res://*/App_Logic.Entity Model.DatabaseContext.csdl|res://*/App_Logic.Entity Model.DatabaseContext.ssdl|res://*/App_Logic.Entity Model.DatabaseContext.msl";

            return entityBuilder.ConnectionString;

        }

        string BuildSqlClientConnectionString(string dataSource, string database = "", bool integratedSecurity = true, string userName = "", string password = "")
        {
            // Specify the provider name, server and database.
            string serverName = dataSource;
            string databaseName = database;

            // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder =
                new SqlConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;

            if (integratedSecurity)
                sqlBuilder.IntegratedSecurity = true;
            else
            {
                sqlBuilder.UserID = userName;
                sqlBuilder.Password = password;
            }

            // Build the SqlConnection connection string.
            string providerString = sqlBuilder.ToString();

            return providerString;

        }

        static void SaveConnectionStringKey(string configFilePhysicalPath, string key, string value)
        {
            ExeConfigurationFileMap m = new ExeConfigurationFileMap();
            m.ExeConfigFilename = configFilePhysicalPath;
            Configuration objConfig = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(m, ConfigurationUserLevel.None);
            ConnectionStringsSection objAppsettings = (ConnectionStringsSection)objConfig.GetSection("connectionStrings");
            if (objAppsettings != null)
            {
                objAppsettings.ConnectionStrings[key].ConnectionString = value;
                objConfig.Save();
            }
        }

        public static string TestSqlClientConnectionString()
        {
            string connStr = string.Empty;

            using (DatabaseContext _db = new DatabaseContext())
            {
                connStr = (_db.Connection as System.Data.EntityClient.EntityConnection).StoreConnection.ConnectionString;
            }

            return TestSqlClientConnectionString(connStr);
        }

        public static string TestSqlClientConnectionString(string sqlClientConnectionString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlClientConnectionString))
                {
                    conn.Open();
                    conn.Close();
                    return string.Empty;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        #endregion

    }
}