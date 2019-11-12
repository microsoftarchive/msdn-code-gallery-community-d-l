// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;

using Microsoft.Synchronization.Data;
using Microsoft.Synchronization;

namespace SyncApplication
{
    /// <summary>
    /// Utilty form that shows Sync progress/statistics.
    /// </summary>
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
        }

        public void Report(DbSyncProgressEventArgs args)
        {
            string message = "Progress: ";
            
            switch(args.Stage)
            {
                case DbSyncStage.ApplyingInserts:
                    message += "Applying insert to table: " + args.TableProgress.TableName;
                    message += "[" + args.TableProgress.Inserts.ToString() + "|" + args.TableProgress.Updates.ToString() + "|" + args.TableProgress.Deletes.ToString() + "]";
                    message += "(Applied:" + args.TableProgress.ChangesApplied.ToString() + "/Pending:" + args.TableProgress.ChangesPending.ToString() + 
                       "/Failed:" + args.TableProgress.ChangesFailed.ToString() + "/Total:" + args.TableProgress.TotalChanges.ToString() + ")";
                break;

                case DbSyncStage.ApplyingUpdates:
                    message += "Applying update to table: " + args.TableProgress.TableName;
                    message += "[" + args.TableProgress.Inserts.ToString() + "|" + args.TableProgress.Updates.ToString() + "|" + args.TableProgress.Deletes.ToString() + "]";
                    message += "(Applied:" + args.TableProgress.ChangesApplied.ToString() + "/Pending:" + args.TableProgress.ChangesPending.ToString() +
                    "/Failed:" + args.TableProgress.ChangesFailed.ToString() + "/Total:" + args.TableProgress.TotalChanges.ToString() + ")";
                break;

                case DbSyncStage.ApplyingDeletes:
                    message += "Applying delete to table: " + args.TableProgress.TableName;
                    message += "[" + args.TableProgress.Inserts.ToString() + "|" + args.TableProgress.Updates.ToString() + "|" + args.TableProgress.Deletes.ToString() + "]";
                    message += "(Applied:" + args.TableProgress.ChangesApplied.ToString() + "/Pending:" + args.TableProgress.ChangesPending.ToString() +
                    "/Failed:" + args.TableProgress.ChangesFailed.ToString() + "/Total:" + args.TableProgress.TotalChanges.ToString() + ")";
                break;
                
                case DbSyncStage.SelectingChanges:
                    message += "Enumerating changes for table: " + args.TableProgress.TableName;
                    message += "[" + args.TableProgress.Inserts.ToString() + "|" + args.TableProgress.Updates.ToString() + "|" + args.TableProgress.Deletes.ToString() + "]";                    
                break;  
          

                default:
                    DbSyncStage stage = args.Stage;

                    break;
            }
            
            listSyncProgress.Items.Add(message);
            Application.DoEvents();
        }

        public void ProgressChanged(SyncStagedProgressEventArgs args)
        {
            string message = "";
            listSyncProgress.Items.Add(message);
            try
            {
                DbSyncSessionProgressEventArgs sessionProgress = (DbSyncSessionProgressEventArgs)args;
                DbSyncScopeProgress progress = sessionProgress.GroupProgress;
                switch (sessionProgress.DbSyncStage)
                {
                    case DbSyncStage.SelectingChanges:
                        message += "Sync Stage: Selecting Changes";
                        listSyncProgress.Items.Add(message);
                        foreach (DbSyncTableProgress tableProgress in progress.TablesProgress)
                        {
                            message = "Enumerated changes for table: " + tableProgress.TableName;
                            message += "[Inserts:" + tableProgress.Inserts.ToString() + "/Updates :" + tableProgress.Updates.ToString() + "/Deletes :" + tableProgress.Deletes.ToString() + "]";
                            listSyncProgress.Items.Add(message);
                        }
                        break;
                    case DbSyncStage.ApplyingChanges:
                        message += "Sync Stage: Applying Changes";
                        listSyncProgress.Items.Add(message);
                        foreach (DbSyncTableProgress tableProgress in progress.TablesProgress)
                        {
                            message = "Applied changes for table: " + tableProgress.TableName;
                            message += "[Inserts:" + tableProgress.Inserts.ToString() + "/Updates :" + tableProgress.Updates.ToString() + "/Deletes :" + tableProgress.Deletes.ToString() + "]";
                            listSyncProgress.Items.Add(message);
                        }
                        break;
                    default:
                        break;
                }

                message = "Total Changes : " + progress.TotalChanges.ToString() + "  Inserts :" + progress.TotalInserts.ToString();
                message += "  Updates :" + progress.TotalUpdates.ToString() + "  Deletes :" + progress.TotalDeletes.ToString();
                listSyncProgress.Items.Add(message);

            }
            catch (Exception e)
            {
                throw e;
            }

            message = "Completed : " + args.CompletedWork + "%";
            listSyncProgress.Items.Add(message);

            Application.DoEvents();
        }

        //Print SyncOperationStatistics object
        public void ShowStatistics(SyncOperationStatistics syncStats)
        {
            string message = "";
            listSyncProgress.Items.Add(message);
            message = "-----Sync Statistics -----";
            listSyncProgress.Items.Add(message);
            message = "Sync Start Time :" + syncStats.SyncStartTime.ToString();
            listSyncProgress.Items.Add(message);
            message = "Sync End Time   :" + syncStats.SyncEndTime.ToString();
            listSyncProgress.Items.Add(message);
            message = "Upload Changes Applied :" + syncStats.UploadChangesApplied.ToString();
            listSyncProgress.Items.Add(message);
            message = "Upload Changes Failed  :" + syncStats.UploadChangesFailed.ToString();
            listSyncProgress.Items.Add(message);
            message = "Upload Changes Total   :" + syncStats.UploadChangesTotal.ToString();
            listSyncProgress.Items.Add(message);
            message = "Download Changes Applied :" + syncStats.DownloadChangesApplied.ToString();
            listSyncProgress.Items.Add(message);
            message = "Download Changes Failed  :" + syncStats.DownloadChangesFailed.ToString();
            listSyncProgress.Items.Add(message);
            message = "Download Changes Total   :" + syncStats.DownloadChangesTotal.ToString();
            listSyncProgress.Items.Add(message);
            Application.DoEvents();
        }

        //Show DbSnapshotInitializationStatistics object
        public void ShowSnapshotInitializationStatistics(DbSnapshotInitializationStatistics snapshotStats, Dictionary<string, DbSnapshotInitializationTableStatistics> tableStats)
        {
            string message = "";
            listSyncProgress.Items.Add(message);
            message = "-----Snapshot Initialization Statistics -----";
            listSyncProgress.Items.Add(message);
            message = "Total # of tables: " + snapshotStats.TotalTables;
            listSyncProgress.Items.Add(message);
            message = "Tables Initialized: " + snapshotStats.TablesInitialized;
            listSyncProgress.Items.Add(message);
            message = "Start Time: " + snapshotStats.StartTime;
            listSyncProgress.Items.Add(message);
            message = "End Time: " + snapshotStats.EndTime;
            listSyncProgress.Items.Add(message);
            
            message = "\t-----Individual Snapshot Table Statistics-----";
            listSyncProgress.Items.Add(message);
            foreach (string tableName in tableStats.Keys)
            {
                DbSnapshotInitializationTableStatistics ts = tableStats[tableName];
                message = "\tTable Name: " + tableName;
                listSyncProgress.Items.Add(message);
                message = "\tTotal Rows: " + ts.TotalRows;
                listSyncProgress.Items.Add(message);
                message = "\tRows Intialized: " + ts.RowsInitialized;
                listSyncProgress.Items.Add(message);
                message = "\tStart Time: " + ts.StartTime;
                listSyncProgress.Items.Add(message);
                message = "\tEnd Time: " + ts.EndTime;
                listSyncProgress.Items.Add(message);
            }
            Application.DoEvents();
        }

        public void EnableClose()
        {
            buttonClose.Enabled = true;
            Application.DoEvents();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
