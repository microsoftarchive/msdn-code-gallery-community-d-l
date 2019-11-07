using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Synchronization.Data;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Synchronization.Data.SqlServerCe;
using System.Data.SqlServerCe;
using System.IO;
using System.Windows.Forms;
using Microsoft.Synchronization;
using System.Data.OracleClient;

namespace SyncApplication
{
    public class SynchronizationHelper
    {
        public const string current_timestamp = "sequence_timestamp.nextval";
        ProgressForm progressForm;
        CESharingForm ceSharingForm;

        public SynchronizationHelper(CESharingForm ceSharingForm)
        {
            this.ceSharingForm = ceSharingForm;
        }

        /// <summary>
        /// Utility function that will create a SyncOrchestrator and synchronize the two passed in providers
        /// </summary>
        /// <param name="localProvider">Local store provider</param>
        /// <param name="remoteProvider">Remote store provider</param>
        /// <returns></returns>
        public SyncOperationStatistics SynchronizeProviders(RelationalSyncProvider localProvider, RelationalSyncProvider remoteProvider)
        {
            SyncOrchestrator orchestrator = new SyncOrchestrator();
            orchestrator.LocalProvider = localProvider;
            orchestrator.RemoteProvider = remoteProvider;
            orchestrator.Direction = SyncDirectionOrder.UploadAndDownload;

            progressForm = new ProgressForm();
            progressForm.Show();

            //Check to see if any provider is a SqlCe provider and if it needs schema
            CheckIfProviderNeedsSchema(localProvider as SqlCeSyncProvider);
            CheckIfProviderNeedsSchema(remoteProvider as SqlCeSyncProvider);

            SyncOperationStatistics stats = orchestrator.Synchronize();
            progressForm.ShowStatistics(stats);
            progressForm.EnableClose();
            return stats;
        }

        /// <summary>
        /// Check to see if the passed in CE provider needs Schema from server.
        /// If it does, we'll need to do some extra manipulating of the DbSyncScopeDescription given from the Oracle provider, before
        /// we apply it to CE.
        /// </summary>
        /// <param name="localProvider"></param>
        private void CheckIfProviderNeedsSchema(SqlCeSyncProvider localProvider)
        {
            if (localProvider != null)
            {
                SqlCeSyncScopeProvisioning ceConfig = new SqlCeSyncScopeProvisioning();
                SqlCeConnection ceConn = (SqlCeConnection)localProvider.Connection;
                string scopeName = localProvider.ScopeName;
                if (!ceConfig.ScopeExists(scopeName, ceConn))
                {
                    DbSyncScopeDescription scopeDesc = ((DbSyncProvider)ceSharingForm.providersCollection["Server"]).GetScopeDescription();

                    // We have to manually fix up the Oracle types on the DbSyncColumnDescriptions. Alternatively we could just construct the DbScopeDescription
                    // from scratch.
                    for (int i = 0; i < scopeDesc.Tables.Count; i++)
                    {
                        for (int j = 0; j < scopeDesc.Tables[i].Columns.Count; j++)
                        {
                            // When grabbing the Oracle schema table the type field gets set to the index of that type in the OracleType enumeration.
                            // We will have to change it to the actual name instead of the index.
                            scopeDesc.Tables[i].Columns[j].Type = ((OracleType)Int32.Parse(scopeDesc.Tables[i].Columns[j].Type)).ToString().ToLower();
                            
                            // We also have to convert number to a decimal for CE
                            if (scopeDesc.Tables[i].Columns[j].Type == "number")
                            {
                                scopeDesc.Tables[i].Columns[j].Type = "decimal";
                            }

                            // Because the DbSyncColumnDescription only had a number for the Type (which it does not understand), it could not 
                            // auto-fill in the required attributes for that field type.  So in the case of a string field, we have to manually 
                            // set the length ourselves.  If we wanted to set scale and precision for the previous decimal field we need to do the same.
                            if (scopeDesc.Tables[i].Columns[j].Type == "nvarchar")
                            {
                                scopeDesc.Tables[i].Columns[j].Size = "100";
                            }
                        }
                    }

                    ceConfig.PopulateFromScopeDescription(scopeDesc);
                    ceConfig.Apply(ceConn);
                }
            }
        }

        /// <summary>
        /// Configure the Oracle DbSyncprovider. Usual configuration similar to OCS V2 samples.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public OracleDbSyncProvider ConfigureDBSyncProvider(string connectionString)
        {
            OracleDbSyncProvider provider = new OracleDbSyncProvider();
            provider.ScopeName = SyncUtils.ScopeName;
            provider.Connection = new OracleConnection();
            provider.Connection.ConnectionString = connectionString;

            for (int i = 0; i < SyncUtils.SyncAdapterTables.Length; i++)
            {
                //Add each table as a DbSyncAdapter to the provider
                DbSyncAdapter adapter = new DbSyncAdapter(SyncUtils.SyncAdapterTables[i]);
                adapter.RowIdColumns.Add(SyncUtils.SyncAdapterTablePrimaryKeys[i]);

                // select incremental changes command
                OracleCommand chgsOrdersCmd = new OracleCommand();
                chgsOrdersCmd.CommandType = CommandType.StoredProcedure;
                chgsOrdersCmd.CommandText = "sp_" + SyncUtils.SyncAdapterTables[i] + "_selectchanges";
                chgsOrdersCmd.Parameters.Add(DbSyncSession.SyncMetadataOnly, OracleType.Int32);
                chgsOrdersCmd.Parameters.Add(DbSyncSession.SyncMinTimestamp, OracleType.Number);
                chgsOrdersCmd.Parameters.Add(DbSyncSession.SyncScopeLocalId, OracleType.Int32);
                chgsOrdersCmd.Parameters.Add("sync_changes", OracleType.Cursor).Direction = ParameterDirection.Output;

                adapter.SelectIncrementalChangesCommand = chgsOrdersCmd;


                // insert row command
                OracleCommand insOrdersCmd = new OracleCommand();
                insOrdersCmd.CommandType = CommandType.StoredProcedure;
                insOrdersCmd.CommandText = "sp_" + SyncUtils.SyncAdapterTables[i] + "_applyinsert";
                insOrdersCmd.Parameters.Add(SyncUtils.SyncAdapterTablePrimaryKeys[i], OracleType.Int32);
                if (SyncUtils.SyncAdapterTables[i] == "orders")
                {
                    insOrdersCmd.Parameters.Add("order_date", OracleType.DateTime);
                }
                else
                {
                    insOrdersCmd.Parameters.Add("product", OracleType.NVarChar, 100);
                    insOrdersCmd.Parameters.Add("quantity", OracleType.Int32);
                    insOrdersCmd.Parameters.Add("order_id", OracleType.Int32);
                }
                insOrdersCmd.Parameters.Add(DbSyncSession.SyncRowCount, OracleType.Int32).Direction = ParameterDirection.Output;

                adapter.InsertCommand = insOrdersCmd;


                // update row command
                OracleCommand updOrdersCmd = new OracleCommand();
                updOrdersCmd.CommandType = CommandType.StoredProcedure;
                updOrdersCmd.CommandText = "sp_" + SyncUtils.SyncAdapterTables[i] + "_applyupdate";
                updOrdersCmd.Parameters.Add(SyncUtils.SyncAdapterTablePrimaryKeys[i], OracleType.Int32);
                if (SyncUtils.SyncAdapterTables[i] == "orders")
                {
                    updOrdersCmd.Parameters.Add("order_date", OracleType.DateTime);
                }
                else
                {
                    updOrdersCmd.Parameters.Add("product", OracleType.NVarChar, 100);
                    updOrdersCmd.Parameters.Add("quantity", OracleType.Int32);
                    updOrdersCmd.Parameters.Add("order_id", OracleType.Int32);
                }
                updOrdersCmd.Parameters.Add(DbSyncSession.SyncMinTimestamp, OracleType.Number);
                updOrdersCmd.Parameters.Add(DbSyncSession.SyncRowCount, OracleType.Int32).Direction = ParameterDirection.Output;
                updOrdersCmd.Parameters.Add(DbSyncSession.SyncForceWrite, OracleType.Int32);

                adapter.UpdateCommand = updOrdersCmd;


                // delete row command
                OracleCommand delOrdersCmd = new OracleCommand();
                delOrdersCmd.CommandType = CommandType.StoredProcedure;
                delOrdersCmd.CommandText = "sp_" + SyncUtils.SyncAdapterTables[i] + "_applydelete";
                delOrdersCmd.Parameters.Add(SyncUtils.SyncAdapterTablePrimaryKeys[i], OracleType.Int32);
                delOrdersCmd.Parameters.Add(DbSyncSession.SyncMinTimestamp, OracleType.Number);
                delOrdersCmd.Parameters.Add(DbSyncSession.SyncRowCount, OracleType.Int32).Direction = ParameterDirection.Output;
                delOrdersCmd.Parameters.Add(DbSyncSession.SyncForceWrite, OracleType.Int32);

                adapter.DeleteCommand = delOrdersCmd;

                // get row command
                OracleCommand selRowOrdersCmd = new OracleCommand();
                selRowOrdersCmd.CommandType = CommandType.StoredProcedure;
                selRowOrdersCmd.CommandText = "sp_" + SyncUtils.SyncAdapterTables[i] + "_selectrow";
                selRowOrdersCmd.Parameters.Add(SyncUtils.SyncAdapterTablePrimaryKeys[i], OracleType.Int32);
                selRowOrdersCmd.Parameters.Add(DbSyncSession.SyncScopeLocalId, OracleType.Int32);
                selRowOrdersCmd.Parameters.Add("selectedRow", OracleType.Cursor).Direction = ParameterDirection.Output;

                adapter.SelectRowCommand = selRowOrdersCmd;


                // insert row metadata command
                OracleCommand insMetadataOrdersCmd = new OracleCommand();
                insMetadataOrdersCmd.CommandType = CommandType.StoredProcedure;
                insMetadataOrdersCmd.CommandText = "sp_" + SyncUtils.SyncAdapterTables[i] + "_insert_md";
                insMetadataOrdersCmd.Parameters.Add(SyncUtils.SyncAdapterTablePrimaryKeys[i], OracleType.Int32);
                insMetadataOrdersCmd.Parameters.Add(DbSyncSession.SyncScopeLocalId, OracleType.Int32);
                insMetadataOrdersCmd.Parameters.Add(DbSyncSession.SyncRowTimestamp, OracleType.Number);
                insMetadataOrdersCmd.Parameters.Add(DbSyncSession.SyncCreatePeerKey, OracleType.Int32);
                insMetadataOrdersCmd.Parameters.Add(DbSyncSession.SyncCreatePeerTimestamp, OracleType.Number);
                insMetadataOrdersCmd.Parameters.Add(DbSyncSession.SyncUpdatePeerKey, OracleType.Int32);
                insMetadataOrdersCmd.Parameters.Add(DbSyncSession.SyncUpdatePeerTimestamp, OracleType.Number);
                insMetadataOrdersCmd.Parameters.Add(DbSyncSession.SyncRowIsTombstone, OracleType.Int32);
                insMetadataOrdersCmd.Parameters.Add(DbSyncSession.SyncCheckConcurrency, OracleType.Int32);
                insMetadataOrdersCmd.Parameters.Add(DbSyncSession.SyncRowCount, OracleType.Int32).Direction = ParameterDirection.Output;

                adapter.InsertMetadataCommand = insMetadataOrdersCmd;


                // update row metadata command       
                OracleCommand updMetadataOrdersCmd = new OracleCommand();
                updMetadataOrdersCmd.CommandType = CommandType.StoredProcedure;
                updMetadataOrdersCmd.CommandText = "sp_" + SyncUtils.SyncAdapterTables[i] + "_update_md";
                updMetadataOrdersCmd.Parameters.Add(SyncUtils.SyncAdapterTablePrimaryKeys[i], OracleType.Int32);
                updMetadataOrdersCmd.Parameters.Add(DbSyncSession.SyncScopeLocalId, OracleType.Int32);
                updMetadataOrdersCmd.Parameters.Add(DbSyncSession.SyncRowTimestamp, OracleType.Number);
                updMetadataOrdersCmd.Parameters.Add(DbSyncSession.SyncCreatePeerKey, OracleType.Int32);
                updMetadataOrdersCmd.Parameters.Add(DbSyncSession.SyncCreatePeerTimestamp, OracleType.Number);
                updMetadataOrdersCmd.Parameters.Add(DbSyncSession.SyncUpdatePeerKey, OracleType.Int32);
                updMetadataOrdersCmd.Parameters.Add(DbSyncSession.SyncUpdatePeerTimestamp, OracleType.Number);
                updMetadataOrdersCmd.Parameters.Add(DbSyncSession.SyncRowIsTombstone, OracleType.Int32);
                updMetadataOrdersCmd.Parameters.Add(DbSyncSession.SyncCheckConcurrency, OracleType.Int32);
                updMetadataOrdersCmd.Parameters.Add(DbSyncSession.SyncRowCount, OracleType.Int32).Direction = ParameterDirection.Output;

                adapter.UpdateMetadataCommand = (IDbCommand)updMetadataOrdersCmd.Clone();

                // delete row metadata command
                OracleCommand delMetadataOrdersCmd = new OracleCommand();
                delMetadataOrdersCmd.CommandType = CommandType.StoredProcedure;
                delMetadataOrdersCmd.CommandText = "sp_" + SyncUtils.SyncAdapterTables[i] + "_delete_md";
                delMetadataOrdersCmd.Parameters.Add(SyncUtils.SyncAdapterTablePrimaryKeys[i], OracleType.Int32);
                delMetadataOrdersCmd.Parameters.Add(DbSyncSession.SyncCheckConcurrency, OracleType.Int32);
                delMetadataOrdersCmd.Parameters.Add(DbSyncSession.SyncRowTimestamp, OracleType.Number);
                delMetadataOrdersCmd.Parameters.Add(DbSyncSession.SyncRowCount, OracleType.Int32).Direction = ParameterDirection.Output;

                adapter.DeleteMetadataCommand = delMetadataOrdersCmd;


                // get tombstones for cleanup
                OracleCommand selTombstonesOrdersCmd = new OracleCommand();
                selTombstonesOrdersCmd.CommandType = CommandType.StoredProcedure;
                selTombstonesOrdersCmd.CommandText = "sp_" + SyncUtils.SyncAdapterTables[i] + "_select_ts";
                selTombstonesOrdersCmd.Parameters.Add("tombstone_aging_in_hours", OracleType.Int32).Value = SyncUtils.TombstoneAgingInHours;
                selTombstonesOrdersCmd.Parameters.Add("sync_scope_local_id", OracleType.Int32);

                adapter.SelectMetadataForCleanupCommand = selTombstonesOrdersCmd;

                provider.SyncAdapters.Add(adapter);
            }

            // 2. Setup provider wide commands
            // There are few commands on the provider itself and not on a table sync adapter:
            // SelectNewTimestampCommand: Returns the new high watermark for current sync
            // SelectScopeInfoCommand: Returns sync knowledge, cleanup knowledge and scope version (timestamp)
            // UpdateScopeInfoCommand: Sets the new values for sync knowledge and cleanup knowledge             
            //

            OracleCommand anchorCmd = new OracleCommand();
            anchorCmd.CommandType = CommandType.StoredProcedure;
            anchorCmd.CommandText = "SP_GET_TIMESTAMP";  // for SQL Server 2005 SP2, use "min_active_rowversion() - 1"
            anchorCmd.Parameters.Add(DbSyncSession.SyncNewTimestamp, OracleType.UInt32).Direction = ParameterDirection.Output;

            provider.SelectNewTimestampCommand = anchorCmd;

            // 
            // Select local replica info
            //
            OracleCommand selReplicaInfoCmd = new OracleCommand();
 
            selReplicaInfoCmd.CommandType = CommandType.Text;
            selReplicaInfoCmd.CommandText = "select " +
                                            "scope_id, " +
                                            "scope_local_id, " +
                                            "scope_sync_knowledge, " +
                                            "scope_forgotten_knowledge, " +
                                            "scope_timestamp " +
                                            "from scope_info " +
                                            "where scope_name = :" + DbSyncSession.SyncScopeName;
            selReplicaInfoCmd.Parameters.Clear();
            selReplicaInfoCmd.Parameters.Add(DbSyncSession.SyncScopeName, OracleType.NVarChar).Direction = ParameterDirection.Input;
            provider.SelectScopeInfoCommand = selReplicaInfoCmd;

            // 
            // Update local replica info
            //
            OracleCommand updReplicaInfoCmd = new OracleCommand();
            updReplicaInfoCmd.CommandType = CommandType.Text;
            updReplicaInfoCmd.CommandText = "begin update scope_info set " +
                                            "scope_sync_knowledge = :" + DbSyncSession.SyncScopeKnowledge + ", " +
                                            "scope_id = :" + DbSyncSession.SyncScopeId + ", " +
                                            "scope_forgotten_knowledge = :" + DbSyncSession.SyncScopeCleanupKnowledge + " " +
                                            "where scope_name = :" + DbSyncSession.SyncScopeName + " and " +
                                            " ( :" + DbSyncSession.SyncCheckConcurrency + " = 0 or scope_timestamp = :" + DbSyncSession.SyncScopeTimestamp + "); " +
                                            ":" + DbSyncSession.SyncRowCount + " := sql%rowcount; End;";
            updReplicaInfoCmd.Parameters.Add(DbSyncSession.SyncScopeKnowledge, OracleType.Raw, 10000);
            updReplicaInfoCmd.Parameters.Add(DbSyncSession.SyncScopeCleanupKnowledge, OracleType.Raw, 10000);
            updReplicaInfoCmd.Parameters.Add(DbSyncSession.SyncScopeName, OracleType.NVarChar, 100);
            updReplicaInfoCmd.Parameters.Add(DbSyncSession.SyncCheckConcurrency, OracleType.Int32);
            updReplicaInfoCmd.Parameters.Add(DbSyncSession.SyncScopeId, OracleType.Raw);
            updReplicaInfoCmd.Parameters.Add(DbSyncSession.SyncScopeTimestamp, OracleType.Number);
            updReplicaInfoCmd.Parameters.Add(DbSyncSession.SyncRowCount, OracleType.Int32).Direction = ParameterDirection.Output;
            provider.UpdateScopeInfoCommand = updReplicaInfoCmd;
            
            // 
            // Select overlapping scopes 
            //
            // get tombstones for cleanup
            OracleCommand overlappingScopesCmd = new OracleCommand();
            overlappingScopesCmd.CommandType = CommandType.StoredProcedure;
            overlappingScopesCmd.CommandText = "sp_select_shared_scopes";
            overlappingScopesCmd.Parameters.Add(":" + DbSyncSession.SyncScopeName, OracleType.NVarChar, 100);
            provider.SelectOverlappingScopesCommand = overlappingScopesCmd;

            // 
            // Update table cleanup info
            //
            OracleCommand updScopeCleanupInfoCmd = new OracleCommand();
            updScopeCleanupInfoCmd.CommandType = CommandType.Text;
            updScopeCleanupInfoCmd.CommandText = "update  scope_info set " +
                                            "scope_cleanup_timestamp = :" + DbSyncSession.SyncScopeCleanupTimestamp + " " +
                                            "where scope_name = :" + DbSyncSession.SyncScopeName + " and " +
                                            "(scope_cleanup_timestamp is null or scope_cleanup_timestamp <  :" + DbSyncSession.SyncScopeCleanupTimestamp + ");" +
                                            "set :" + DbSyncSession.SyncRowCount + " = ::rowcount";
            updScopeCleanupInfoCmd.Parameters.Add(":" + DbSyncSession.SyncScopeCleanupTimestamp, OracleType.Number);
            updScopeCleanupInfoCmd.Parameters.Add(":" + DbSyncSession.SyncScopeName, OracleType.NVarChar, 100);
            updScopeCleanupInfoCmd.Parameters.Add(":" + DbSyncSession.SyncRowCount, OracleType.Int32).Direction = ParameterDirection.Output;
            provider.UpdateScopeCleanupTimestampCommand = updScopeCleanupInfoCmd;

            //Register the BatchSpooled and BatchApplied events. These are fired when a provider is either enumerating or applying changes in batches.
            provider.BatchApplied += new EventHandler<DbBatchAppliedEventArgs>(provider_BatchApplied);
            provider.BatchSpooled += new EventHandler<DbBatchSpooledEventArgs>(provider_BatchSpooled);

            return provider;
        }

        /// <summary>
        /// Utility function that configures a CE provider
        /// </summary>
        /// <param name="sqlCeConnection"></param>
        /// <returns></returns>
        public SqlCeSyncProvider ConfigureCESyncProvider(SqlCeConnection sqlCeConnection)
        {
            SqlCeSyncProvider provider = new SqlCeSyncProvider();
            //Set the scope name
            provider.ScopeName = SyncUtils.ScopeName;
            //Set the connection.
            provider.Connection = sqlCeConnection;

            //Register event handlers

            //1. Register the BeginSnapshotInitialization event handler. Called when a CE peer pointing to an uninitialized
            // snapshot database is about to being initialization.
            provider.BeginSnapshotInitialization += new EventHandler<DbBeginSnapshotInitializationEventArgs>(provider_BeginSnapshotInitialization);

            //2. Register the EndSnapshotInitialization event handler. Called when a CE peer pointing to an uninitialized
            // snapshot database has been initialized for the given scope.
            provider.EndSnapshotInitialization += new EventHandler<DbEndSnapshotInitializationEventArgs>(provider_EndSnapshotInitialization);

            //3. Register the BatchSpooled and BatchApplied events. These are fired when a provider is either enumerating or applying changes in batches.
            provider.BatchApplied += new EventHandler<DbBatchAppliedEventArgs>(provider_BatchApplied);
            provider.BatchSpooled += new EventHandler<DbBatchSpooledEventArgs>(provider_BatchSpooled);

            //Thats it. We are done configuring the CE provider.
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

        /// <summary>
        /// Snapshot intialization process completed. Database is now ready for sync with other existing peers in topology
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void provider_EndSnapshotInitialization(object sender, DbEndSnapshotInitializationEventArgs e)
        {
            this.progressForm.listSyncProgress.Items.Add("EndSnapshotInitialization Event fired.");
            this.progressForm.ShowSnapshotInitializationStatistics(e.InitializationStatistics, e.TableInitializationStatistics);
            this.progressForm.listSyncProgress.Items.Add("Snapshot Initialization Process Completed.....");
        }

        /// <summary>
        /// CE provider detected that the database was imported from a snapshot from another peer. Snapshot initialziation about to begin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void provider_BeginSnapshotInitialization(object sender, DbBeginSnapshotInitializationEventArgs e)
        {
            this.progressForm.listSyncProgress.Items.Add("Snapshot Initialization Process Started.....");
            this.progressForm.listSyncProgress.Items.Add(
                string.Format("BeginSnapshotInitialization Event fired for Scope {0}", e.ScopeName)
                );
        }

        /// <summary>
        /// User called CreateSchema on the CE provider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void provider_CreatingSchema(object sender, CreatingSchemaEventArgs e)
        {
            this.progressForm.listSyncProgress.Items.Add("Full Initialization Process Started.....");
            this.progressForm.listSyncProgress.Items.Add(
                string.Format("CreatingSchame Event fired for Database {0}", e.Connection.Database)
                );
        }

        #region Static Helper Functions
        /// <summary>
        /// Static helper function to create an empty CE database
        /// </summary>
        /// <param name="client"></param>
        public static void CheckAndCreateCEDatabase(CEDatabase client)
        {
            if (!File.Exists(client.Location))
            {
                SqlCeEngine engine = new SqlCeEngine(client.Connection.ConnectionString);
                engine.CreateDatabase();
                engine.Dispose();
            }
        }

        #endregion
    }
}
