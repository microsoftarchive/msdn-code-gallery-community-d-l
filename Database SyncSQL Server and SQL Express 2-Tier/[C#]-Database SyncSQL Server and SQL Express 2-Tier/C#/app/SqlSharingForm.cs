using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Data.SqlServer;

namespace SyncApplication
{
    public partial class SqlSharingForm : Form
    {
        public NewSqlPeerCreationWizard sqlCreationWizard;
        public Dictionary<String, SqlDatabase> peersMapping = new Dictionary<string, SqlDatabase>();
        public Dictionary<string, SqlSyncProvider> providersCollection = new Dictionary<string, SqlSyncProvider>();
        public SynchronizationHelper synchronizationHelper;

        //By default batching is disabled.
        uint _batchSize = 0;

        public SqlSharingForm()
        {
            InitializeComponent();

            this.SetBatchingRelatedValues();
        }

        //Populate batching related fields in the UI
        private void SetBatchingRelatedValues()
        {
            this.batchSizeTooltip.SetToolTip(this.batchSizeTxtBox, "Set any value greater than 0 to enable batching.");
            this.batchLocationTooltip.SetToolTip(this.batchSpoolLocation, "Directory where sync session batch files are spooled.");


            //by default Batch spool location is set to the current_working_directory\Sync_BatchFiles
            this.SetBatchSpoolLocation(Path.Combine(Directory.GetCurrentDirectory(), "Sync_BatchFiles"));
        }

        private void SetBatchSpoolLocation(string directoryName)
        {
            this.batchSpoolLocation.Text = directoryName;
            DirectoryInfo locationInfo = null;
            try
            {
                locationInfo = new DirectoryInfo(directoryName);
                //Check and create the directory if it doesnt exist.
                if (!locationInfo.Exists)
                {
                    Directory.CreateDirectory(locationInfo.FullName);
                }
                this.batchSpoolLocation.Text = locationInfo.FullName;
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error in creating batch directory " + locationInfo.FullName + ". " + exp.Message);
            }
        }

        private void RefreshFirstProvider()
        {
            //Configure the SQL Server sync provider
            SqlSyncProvider firstSyncProvider = synchronizationHelper.ConfigureSqlSyncProvider(this.textPeer1Machine.Text);

            //Add the server provider to the collection
            providersCollection[SyncUtils.FirstPeerName] = firstSyncProvider;
        }


        private void addSqlBtn_Click(object sender, EventArgs e)
        {
            sqlCreationWizard = new NewSqlPeerCreationWizard();

            if (sqlCreationWizard.ShowDialog(this) == DialogResult.OK)
            {
                string existingPeerName;
                if (IsDatabaseUsedByExistingPeer(sqlCreationWizard.ServerName, sqlCreationWizard.DatabaseName, out existingPeerName))
                {
                    MessageBox.Show(string.Format("The database [{0}] in server [{1}] is already used by sync peer [{2}]. Please pick a different database name instead.",
                        sqlCreationWizard.DatabaseName, sqlCreationWizard.ServerName, existingPeerName),
                        "Error in creation SQL database", MessageBoxButtons.OK);
                    return;
                }

                SqlDatabase peer = new SqlDatabase();
                peer.ConnectionString = sqlCreationWizard.PeerDbConnectionString;
                peer.MasterConnectionString = sqlCreationWizard.MasterConnectionString;
                peer.ServerName = sqlCreationWizard.ServerName;
                peer.DBName = sqlCreationWizard.DatabaseName;

                try
                {
                    SynchronizationHelper.CheckAndCreateSQLDatabase(peer);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error in creating SQL database", MessageBoxButtons.OK);
                    return;
                }

                //Provide our client a unique name
                peer.Name = SyncUtils.PeerNamePrefix + (peersMapping.Keys.Count + 2);

                //Add this client info to our mapping so it can be retrieved 
                peersMapping.Add(peer.Name, peer);

                //Create a SqlCeSyncProvider for the new client that is being added
                SqlSyncProvider peerProvider = synchronizationHelper.ConfigureSqlSyncProvider(peer.Connection);

                providersCollection.Add(peer.Name, peerProvider);

                //Now add a new tab to the peer tabs
                TabPage tab = new TabPage(peer.Name);
                tab.Tag = peer;
                TablesViewControl control = new TablesViewControl(peer.Name);
                control.Name = "TablesViewCtrl";
                control.Dock = DockStyle.Fill;
                tab.Controls.Add(control);
                this.peerTabsControl.TabPages.Add(tab);

                //Add the client name to the list of providers available for synchronization
                this.srcProviderComboBox.Items.Add(peer.Name);
                this.destProviderComboBox.Items.Add(peer.Name);
                this.destProviderComboBox.SelectedIndex = destProviderComboBox.Items.Count - 1;

                this.synchronizeBtn.Enabled = this.providersCollection.Count > 1;
            }
        }

        /// <summary>
        ///  Check if a database is used by an existing sync peer.
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        private bool IsDatabaseUsedByExistingPeer(string serverName, string databaseName, out string existingPeerName)
        {
            bool inUse = false;
            existingPeerName = string.Empty;

            if (this.textPeer1Machine.Text.ToLowerInvariant() == serverName.ToLowerInvariant() &&
                SyncUtils.FirstPeerDBName.ToLowerInvariant() == databaseName.ToLowerInvariant())
            {
                // Is the same database of Peer1
                existingPeerName = SyncUtils.FirstPeerName;
                inUse = true;
            }
            else
            {
                // Check other existing sync peers.
                foreach (SqlDatabase database in peersMapping.Values)
                {
                    if (database.ServerName.ToLowerInvariant() == serverName.ToLowerInvariant() &&
                        database.DBName.ToLowerInvariant() == databaseName.ToLowerInvariant())
                    {
                        existingPeerName = database.Name;
                        inUse = true;
                        break;
                    }
                }
            }
            return inUse;
        }


        private void ReadTableValuesForSelectedTab()
        {
            TabPage tabPage = this.peerTabsControl.SelectedTab;
            SqlSyncProvider sqlProvider = providersCollection[tabPage.Text] as SqlSyncProvider;
            if (sqlProvider != null)
            {
                SqlConnection conn = (SqlConnection)sqlProvider.Connection;
                SqlSyncScopeProvisioning sqlConfig = new SqlSyncScopeProvisioning(conn);                
                string scopeName = sqlProvider.ScopeName;
                if (!sqlConfig.ScopeExists(scopeName))
                {
                    MessageBox.Show(string.Format("The database of '{0}' does not contain schema. Synchronize this peer with the Peer1 first to retrieve data.", tabPage.Text),
                        "UnInitialized Peer Database");
                    return;
                }
            }

            RefreshTables(providersCollection[tabPage.Text].Connection, (TablesViewControl)this.peerTabsControl.SelectedTab.Controls["TablesViewCtrl"]);
        }


        private void RefreshTables(IDbConnection connection, TablesViewControl tableViewCtrl)
        {
            try
            {
                foreach (string s in SyncUtils.SyncAdapterTables)
                {
                    tableViewCtrl.AsyncReadTableValueFromConnection(connection, s);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error in reading table values. Check Connection settings.");
            }
            Application.DoEvents();
        }

        private void peerTabsControl_Selected(object sender, TabControlEventArgs e)
        {
            //User switched tabs. Refresh the table value
            ReadTableValuesForSelectedTab();
        }

        private void synchronizeBtn_Click(object sender, EventArgs e)
        {
            //Before calling synchronize, save any changes made to any of the peer tables
            foreach (TabPage page in this.peerTabsControl.TabPages)
            {
                if (page != null)
                {
                    ((TablesViewControl)page.Controls["TablesViewCtrl"]).UpdateValues();
                }
            }

            SqlSyncProvider srcProvider = providersCollection[this.srcProviderComboBox.SelectedItem.ToString()];
            SqlSyncProvider destinationProvider = providersCollection[this.destProviderComboBox.SelectedItem.ToString()];

            //Set memory data cache size property. 0 represents non batched mode
            srcProvider.MemoryDataCacheSize = this._batchSize;
            destinationProvider.MemoryDataCacheSize = this._batchSize;

            //Set batch spool location. Default value if not set is %Temp% directory.
            if (!string.IsNullOrEmpty(this.batchSpoolLocation.Text))
            {
                srcProvider.BatchingDirectory = this.batchSpoolLocation.Text;
                destinationProvider.BatchingDirectory = this.batchSpoolLocation.Text;
            }

            SyncOperationStatistics stats = synchronizationHelper.SynchronizeProviders(srcProvider, destinationProvider);

            TimeSpan diff = stats.SyncEndTime.Subtract(stats.SyncStartTime);

            //Print Sync stats object
            this.syncStats.Text = string.Format("Batching: {4} - Total Time To Synchronize = {0}:{1}:{2}:{3}",
                diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds, (this._batchSize > 0) ? "Enabled" : "Disabled");

            this.ReadTableValuesForSelectedTab();
        }

        private void SqlSharingForm_Shown(object sender, EventArgs e)
        {
            this.textPeer1Machine.Text = Environment.MachineName;
           
            //Create a new helper class that we will use to configure our providers
            synchronizationHelper = new SynchronizationHelper(this, this.textPeer1Machine.Text);

            //Read Server host name and configure the Server side SqlSyncProvider
            RefreshFirstProvider();

            //Read and display values for current peer selected in the tab page
            ReadTableValuesForSelectedTab();

            //Disable the synchronize button till new SQL Server peers are added
            this.synchronizeBtn.Enabled = this.providersCollection.Count > 1;
        }

        private void textPeer1Machine_Leave(object sender, EventArgs e)
        {
            //If user changes the server host name then refresh the server provider.
            RefreshFirstProvider();
            ReadTableValuesForSelectedTab();
        }

        private void srcProviderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Make sure sync source and destination peers are never the same.
            if (srcProviderComboBox.SelectedIndex == destProviderComboBox.SelectedIndex)
            {
                destProviderComboBox.SelectedIndex = (destProviderComboBox.SelectedIndex + 1) % destProviderComboBox.Items.Count;
            }
        }

        private void destProviderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Make sure sync source and destination peers are never the same.
            if (srcProviderComboBox.SelectedIndex == destProviderComboBox.SelectedIndex)
            {
                srcProviderComboBox.SelectedIndex = (srcProviderComboBox.SelectedIndex + 1) % srcProviderComboBox.Items.Count;
            }
        }

        private void changeBatchLocationBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.SetBatchSpoolLocation(folderBrowserDialog.SelectedPath);
            }
        }

        private void batchSizeTxtBox_Leave(object sender, EventArgs e)
        {
            try
            {
                //Check to see the batch size is a valid number
                this._batchSize = uint.Parse(this.batchSizeTxtBox.Text);
            }
            catch (FormatException exp)
            {
                MessageBox.Show(this, exp.Message, "Invalid value set for BatchSize. Use only numbers");
            }
        }

        private void batchSpoolLocation_Leave(object sender, EventArgs e)
        {
            //Batching directory location was changed.
            this.SetBatchSpoolLocation(this.batchSpoolLocation.Text);
        }
    }
}
