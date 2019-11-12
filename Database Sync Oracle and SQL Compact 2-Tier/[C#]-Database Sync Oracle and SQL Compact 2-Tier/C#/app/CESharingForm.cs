using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServerCe;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Data.Common;
using Microsoft.Synchronization;

namespace SyncApplication
{
    public partial class CESharingForm : Form
    {
        public NewCEClientCreationWizard ceCreationWizard;
        public Dictionary<String, CEDatabase> clientsMapping = new Dictionary<string, CEDatabase>();
        public Dictionary<string, RelationalSyncProvider> providersCollection = new Dictionary<string, RelationalSyncProvider>();
        public SynchronizationHelper synchronizationHelper;
        public string oracleConnectionString;

        //By default batching is disabled.
        uint _batchSize = 0;

        public CESharingForm(string connectionString)
        {
            InitializeComponent();

            this.oracleConnectionString = connectionString;
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

        private void RefreshServerProvider()
        {
            //Configure the SQL Server sync provider
            OracleDbSyncProvider serverSyncProvider = synchronizationHelper.ConfigureDBSyncProvider(this.oracleConnectionString);

            //Add the server provider to the collection
            providersCollection["Server"] = serverSyncProvider;
        }

        private void addCEBtn_Click(object sender, EventArgs e)
        {
            ceCreationWizard = new NewCEClientCreationWizard();
            //Create a new client
            CEDatabase client = new CEDatabase();

            if (ceCreationWizard.ShowDialog(this) == DialogResult.OK)
            {

                //Creation mode is based on the option the user picked in the new ce creation wizard
                client.CreationMode = (ceCreationWizard.fullInitRadioBtn.Checked) ? CEDatabaseCreationMode.FullInitialization : CEDatabaseCreationMode.SnapshotInitialization;

                //Database location is based on mode.
                switch (client.CreationMode)
                {
                    case CEDatabaseCreationMode.FullInitialization:
                        client.Location = ceCreationWizard.fullInitDbLocation.Text;
                        try
                        {
                            SynchronizationHelper.CheckAndCreateCEDatabase(client);
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1.ToString(), "Error in creating CE database", MessageBoxButtons.OK);
                            return;
                        }
                        break;
                    case CEDatabaseCreationMode.SnapshotInitialization:
                        client.Location = ceCreationWizard.snapshotDestLocation.Text;
        
                        //Export the source SDF file first.
                        ExportClientDatabase(new SqlCeConnection("Data Source=\"" + ceCreationWizard.snapshotSrcLocation.Text + "\""), client.Location);
                        
                        break;
                }
                //Provide our client a unique name
                client.Name = "Client " + (clientsMapping.Keys.Count + 1);

                //Add this client info to our mapping so it can be retrieved 
                clientsMapping.Add(client.Name, client);

                //Create a SqlCeSyncProvider for the new client that is being added
                SqlCeSyncProvider clientProvider = synchronizationHelper.ConfigureCESyncProvider(client.Connection);

                providersCollection.Add(client.Name, clientProvider);

                //Now add a new tab to the peer tabs
                TabPage tab = new TabPage(client.Name);
                tab.Tag = client;
                TablesViewControl control = new TablesViewControl(client.Name);
                control.Name = "TablesViewCtrl";
                control.Dock = DockStyle.Fill;
                tab.Controls.Add(control);
                this.peerTabsControl.TabPages.Add(tab);

                //Add the client name to the list of providers available for synchronization
                this.srcProviderComboBox.Items.Add(client.Name);
                this.destProviderComboBox.Items.Add(client.Name);
                this.destProviderComboBox.SelectedIndex = destProviderComboBox.Items.Count - 1;

                this.synchronizeBtn.Enabled = this.providersCollection.Count > 1;
            }
        }

        private void ReadTableValuesForSelectedTab()
        {
            TabPage tabPage = this.peerTabsControl.SelectedTab;
            SqlCeSyncProvider ceProvider = providersCollection[tabPage.Text] as SqlCeSyncProvider;

            if (ceProvider != null)
            {
                SqlCeSyncScopeProvisioning ceConfig = new SqlCeSyncScopeProvisioning();
                SqlCeConnection ceConn = (SqlCeConnection)ceProvider.Connection;
                string scopeName = ceProvider.ScopeName;
                if (!ceConfig.ScopeExists(scopeName, ceConn))
                {
                    MessageBox.Show(string.Format("Client '{0}' does not contain schema. Synchronize this client with the server to retrieve data.", tabPage.Text),
                        "UnInitialized Client Database");
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
            //foreach (TabPage page in this.peerTabsControl.TabPages)
            //{
            //    if (page != null)
            //    {
            //        ((TablesViewControl)page.Controls["TablesViewCtrl"]).UpdateValues();
            //    }
            //}

            RelationalSyncProvider srcProvider = providersCollection[this.srcProviderComboBox.SelectedItem.ToString()];
            RelationalSyncProvider destinationProvider = providersCollection[this.destProviderComboBox.SelectedItem.ToString()];
            
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

        public void ExportClientDatabase(SqlCeConnection sourceConnection, string destFileName)
        {
            try
            {
                //Configure a CE provider for the source connection and then generate the snapshot from that file
                SqlCeSyncStoreSnapshotInitialization snapshotInit = new SqlCeSyncStoreSnapshotInitialization();
                snapshotInit.GenerateSnapshot(sourceConnection, destFileName);

                MessageBox.Show("Snapshot successfully generated to location " + destFileName, "Snapshot Generation Result", MessageBoxButtons.OK);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error in generating Snapshot", MessageBoxButtons.OK);
            }
        }

        private void CESharingForm_Shown(object sender, EventArgs e)
        {
            //Create a new helper class that we will use to configure our providers
            synchronizationHelper = new SynchronizationHelper(this);

            //Read Server host name and configure the Server side DbSyncProvider
            RefreshServerProvider();

            //Read and display values for current peer selected in the tab page
            ReadTableValuesForSelectedTab();

            //Disable the synchronize button till CE clients are added
            this.synchronizeBtn.Enabled = this.providersCollection.Count > 1;
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
