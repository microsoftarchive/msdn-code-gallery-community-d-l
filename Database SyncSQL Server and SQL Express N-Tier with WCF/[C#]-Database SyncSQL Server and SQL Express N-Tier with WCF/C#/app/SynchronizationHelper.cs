using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;
using CommonUtils;

using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using WebSyncContract;

namespace SyncApplication
{
    public class SynchronizationHelper
    {
        ProgressForm progressForm;
        SqlSharingForm sqlSharingForm;
        String serverHostName;

        public SynchronizationHelper(SqlSharingForm sqlSharingForm, String serverHostName)
        {
            this.sqlSharingForm = sqlSharingForm;
            this.serverHostName = serverHostName;
        }

        /// <summary>
        /// Utility function that will create a SyncOrchestrator and synchronize the two passed in providers
        /// </summary>
        /// <param name="localProvider">Local store provider</param>
        /// <param name="remoteProvider">Remote store provider</param>
        /// <returns></returns>
        public SyncOperationStatistics SynchronizeProviders(KnowledgeSyncProvider localProvider, KnowledgeSyncProvider remoteProvider)
        {
            SyncOrchestrator orchestrator = new SyncOrchestrator();
            orchestrator.LocalProvider = localProvider;
            orchestrator.RemoteProvider = remoteProvider;
            orchestrator.Direction = SyncDirectionOrder.UploadAndDownload;

            progressForm = new ProgressForm();
            progressForm.Show();

            //Check to see if any provider is a SqlCe provider and if it needs schema
            CheckIfProviderNeedsSchema(localProvider as SqlSyncProvider);
            CheckIfProviderNeedsSchema(remoteProvider as SqlSyncProviderProxy);

            SyncOperationStatistics stats = orchestrator.Synchronize();
            progressForm.ShowStatistics(stats);
            progressForm.EnableClose();
            return stats;
        }


        /// <summary>
        /// Check to see if the passed in  SqlSyncProvider needs Schema from server
        /// </summary>
        /// <param name="localProvider"></param>
        private void CheckIfProviderNeedsSchema(SqlSyncProvider localProvider)
        {

            if (localProvider != null)
            {
                SqlConnection conn = (SqlConnection)localProvider.Connection;
                SqlSyncScopeProvisioning sqlConfig = new SqlSyncScopeProvisioning(conn);                
                string scopeName = localProvider.ScopeName;

                //if the scope does not exist in this store
                if (!sqlConfig.ScopeExists(scopeName))
                {
                    //create a reference to the server proxy
                    SqlSyncProviderProxy serverProxy = new SqlSyncProviderProxy(SyncUtils.ScopeName,
                        SyncUtils.GenerateSqlConnectionString(this.serverHostName, SyncUtils.FirstPeerDBName, null, null, true));

                    //retrieve the scope description from the server
                    DbSyncScopeDescription scopeDesc = serverProxy.GetScopeDescription();

                    serverProxy.Dispose();

                    //use scope description from server to intitialize the client
                    sqlConfig.PopulateFromScopeDescription(scopeDesc);
                    sqlConfig.Apply();
                }
            }
        }

        /// <summary>
        /// Check to see if the passed in SQL provider needs Schema from server.
        /// This method assumes the provider is remote and uses a proxy instead
        /// of directly leveraging a provider.
        /// </summary>
        /// <param name="localProvider"></param>
        private void CheckIfProviderNeedsSchema(SqlSyncProviderProxy remoteProxy)
        {
            if (remoteProxy != null && remoteProxy.NeedsScope())
            {
                //create a reference to the server proxy
                SqlSyncProviderProxy serverProxy = new SqlSyncProviderProxy(SyncUtils.ScopeName,
                    SyncUtils.GenerateSqlConnectionString(this.serverHostName, SyncUtils.FirstPeerDBName, null, null, true));

                //retrieve the scope description from the server
                DbSyncScopeDescription scopeDesc = serverProxy.GetScopeDescription();

                serverProxy.Dispose();

                //intitialize remote store based on scope description from the server
                remoteProxy.CreateScopeDescription(scopeDesc);

            }
        }

        /// <summary>
        /// Configure the SqlSyncprovider.  Note that this method assumes you have a direct conection
        /// to the server as this is more of a design time use case vs. runtime use case.  We think
        /// of provisioning the server as something that occurs before an application is deployed whereas
        /// provisioning the client is somethng that happens during runtime (on intitial sync) after the 
        /// application is deployed.
        ///  
        /// </summary>
        /// <param name="hostName"></param>
        /// <returns></returns>
        public SqlSyncProvider ConfigureSqlSyncProvider(string hostName)
        {          
            SqlSyncProvider provider = new SqlSyncProvider();
            provider.ScopeName = SyncUtils.ScopeName;
            provider.Connection = new SqlConnection(SyncUtils.GenerateSqlConnectionString(hostName, 
                SyncUtils.FirstPeerDBName, null, null, true));

            //create a new scope description and add the appropriate tables to this scope
            DbSyncScopeDescription scopeDesc = new DbSyncScopeDescription(SyncUtils.ScopeName);

            //class to be used to provision the scope defined above
            SqlSyncScopeProvisioning serverConfig = new SqlSyncScopeProvisioning((System.Data.SqlClient.SqlConnection)provider.Connection);
            
            //determine if this scope already exists on the server and if not go ahead and provision
            //Note that provisioning of the server is oftentimes a design time scenario and not something
            //that would be exposed into a client side app as it requires DDL permissions on the server.
            //However, it is demonstrated here for purposes of completentess.
            //
            //Note the default assumption is that SQL Server is installed as localhost. If it's not, 
            //please replace Environment.MachineName with the correct instance name in 
            //SqlSharingForm.SqlSharingForm_Shown().
            if (!serverConfig.ScopeExists(SyncUtils.ScopeName))
            {
                //add the approrpiate tables to this scope
                scopeDesc.Tables.Add(SqlSyncDescriptionBuilder.GetDescriptionForTable("orders", (System.Data.SqlClient.SqlConnection)provider.Connection));
                scopeDesc.Tables.Add(SqlSyncDescriptionBuilder.GetDescriptionForTable("order_details", (System.Data.SqlClient.SqlConnection)provider.Connection));

                //note that it is important to call this after the tables have been added to the scope
                serverConfig.PopulateFromScopeDescription(scopeDesc);

                //indicate that the base table already exists and does not need to be created
                serverConfig.SetCreateTableDefault(DbSyncCreationOption.Skip);

                //provision the server
                serverConfig.Apply();
            }           

            
            //Register the BatchSpooled and BatchApplied events. These are fired when a provider is either enumerating or applying changes in batches.
            provider.BatchApplied += new EventHandler<DbBatchAppliedEventArgs>(provider_BatchApplied);
            provider.BatchSpooled += new EventHandler<DbBatchSpooledEventArgs>(provider_BatchSpooled);

            return provider;
        }

        /// <summary>
        ///  Create a SqlSyncProvider instance without provisioning its database. 
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        public SqlSyncProvider ConfigureSqlSyncProvider(SqlConnection sqlConnection)
        {
            SqlSyncProvider provider = new SqlSyncProvider();
            //Set the scope name
            provider.ScopeName = SyncUtils.ScopeName;

            //Set the connection.
            provider.Connection = sqlConnection;

            //Register event handlers

            //1. Register the BatchSpooled and BatchApplied events. These are fired when a provider is either enumerating or applying changes in batches.
            provider.BatchApplied += new EventHandler<DbBatchAppliedEventArgs>(provider_BatchApplied);
            provider.BatchSpooled += new EventHandler<DbBatchSpooledEventArgs>(provider_BatchSpooled);

            //Thats it. We are done configuring the SQL provider.
            return provider;         
        }               

        /// <summary>
        /// Called whenever an enumerating provider spools a batch file to the disk
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void provider_BatchSpooled(object sender, DbBatchSpooledEventArgs e)
        {
            this.progressForm.listSyncProgress.Items.Add("BatchSpooled event fired: Details");
            this.progressForm.listSyncProgress.Items.Add("\tSource Database :" + ((RelationalSyncProvider)sender).Connection.Database);
            this.progressForm.listSyncProgress.Items.Add("\tBatch Name      :" + e.BatchFileName);
            this.progressForm.listSyncProgress.Items.Add("\tBatch Size      :" + e.DataCacheSize);
            this.progressForm.listSyncProgress.Items.Add("\tBatch Number    :" + e.CurrentBatchNumber);
            this.progressForm.listSyncProgress.Items.Add("\tTotal Batches   :" + e.TotalBatchesSpooled);
            this.progressForm.listSyncProgress.Items.Add("\tBatch Watermark :" + ReadTableWatermarks(e.CurrentBatchTableWatermarks));
        }

        /// <summary>
        /// Calls when the destination provider successfully applies a batch file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void provider_BatchApplied(object sender, DbBatchAppliedEventArgs e)
        {
            this.progressForm.listSyncProgress.Items.Add("BatchApplied event fired: Details");
            this.progressForm.listSyncProgress.Items.Add("\tDestination Database   :" + ((RelationalSyncProvider)sender).Connection.Database);
            this.progressForm.listSyncProgress.Items.Add("\tBatch Number           :" + e.CurrentBatchNumber);
            this.progressForm.listSyncProgress.Items.Add("\tTotal Batches To Apply :" + e.TotalBatchesToApply);
        }

        /// <summary>
        /// Reads the watermarks for each table from the batch spooled event. Denotes the max tickcount for each table in each batch
        /// </summary>
        /// <param name="dictionary">Watermark dictionary retrieved from DbBatchSpooledEventArgs</param>
        /// <returns>String</returns>
        private string ReadTableWatermarks(Dictionary<string, ulong> dictionary)
        {
            StringBuilder builder = new StringBuilder();
            Dictionary<string, ulong> dictionaryClone = new Dictionary<string, ulong>(dictionary);
            foreach (KeyValuePair<string, ulong> kvp in dictionaryClone)
            {
                builder.Append(kvp.Key).Append(":").Append(kvp.Value).Append(",");
            }
            return builder.ToString();
        }        

        #region Static Helper Functions

        /// <summary>
        ///  Check if a database with the same name exists.
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        private static bool DatabaseExists(string dbName, SqlConnection conn)
        {
            SqlCommand command = new SqlCommand(
                string.Format("SELECT name FROM SYS.DATABASES WHERE name = N'{0}'", 
                dbName), conn);

            try
            {
                conn.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                sqlAdapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    // Database with the given name exists
                    //
                    return true;
                }
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return false;
        }

        /// <summary>
        ///  Drop a database.
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="conn"></param>
        public static void DropDatabase(string dbName, SqlConnection conn)
        {
            ExecuteNonQuery(string.Format("DROP DATABASE {0}", dbName), conn);
        }

        /// <summary>
        ///  Create a database.
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="conn"></param>
        public static void CreateDatabase(string dbName, SqlConnection conn)
        {
            ExecuteNonQuery(string.Format("CREATE DATABASE {0}", dbName), conn);            
        }

        /// <summary>
        ///  A utility method to execute TSQL query.
        /// </summary>
        /// <param name="sqlString"></param>
        /// <param name="conn"></param>
        private static void ExecuteNonQuery(string sqlString, SqlConnection conn)
        {
            SqlCommand sqlCommand = new SqlCommand(sqlString, conn);

            try
            {
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }
       
        /// <summary>
        ///  Drop existing database and create a new one.
        /// </summary>
        /// <param name="peer"></param>
        public static void CheckAndCreateSQLDatabase(SqlDatabase peer)
        {
            SqlConnection conn = peer.MasterConnection;            

            if (DatabaseExists(peer.DBName, conn))
            {
                DropDatabase(peer.DBName, conn);
            }
            CreateDatabase(peer.DBName, conn);            
        }

        #endregion
    }
}
