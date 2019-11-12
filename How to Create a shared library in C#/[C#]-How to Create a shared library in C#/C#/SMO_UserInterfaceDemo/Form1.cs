using SMO_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopLibrary;
namespace SMO_UserInterfaceDemo
{
   
    public partial class Form1 : Form
    {
        private SmoOperations serverOperations;
        public Form1()
        {
            InitializeComponent();
            Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            try
            {

                serverOperations = new SmoOperations();
                var serverPath = serverOperations.SqlServerInstallPath();

                if (System.IO.Directory.Exists(serverPath))
                {
                    lblInstalledPath.Text = $"SQL Server install path:{serverOperations.SqlServerInstallPath()}";
                }                
            }
            catch (Exception ex)
            {
                Controls.OfType<Button>().ToList().ForEach(b => b.Enabled = false);
                Dialogs.ExceptionDialog(ex);
            }
        }
        /// <summary>
        /// Be forewarned this is slow so it's done in a Task.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void cmdAvailableServers_ClickAsync(object sender, EventArgs e)
        {
            var result = await serverOperations.AvailableServersAsync();
            listBoxServerNames.DataSource = result;
            listBoxServerNames.DisplayMember = "Name";
        }

        private void cmdDatabaseNames_Click(object sender, EventArgs e)
        {

            listBoxDatabaseNames.SelectedIndexChanged -= ListBoxDatabaseNames_SelectedIndexChanged;
            listBoxDatabaseNames.SelectedIndexChanged += ListBoxDatabaseNames_SelectedIndexChanged;
            
            listBoxDatabaseNames.DataSource = serverOperations.DatabaseNames();
        }

        private void ListBoxDatabaseNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDatabaseNames.DataSource != null)
            {
                var tableNames = serverOperations.TableNames(listBoxDatabaseNames.Text);

                if (tableNames.Count == 0)
                {
                    tableNames.Add("(none)");
                }
                listBoxTableNames.DataSource = tableNames;
            }
           
        }
        /// <summary>
        /// Get some details for a database table. When doing this
        /// we can really drill down into the table details but
        /// here I kept it simple.
        /// 
        /// When using this method and notice a table you believe 
        /// had a Identity column comes up false then we need to check
        /// the ForeignKeyDetails list which is rigged up below but is
        /// not displayed. If you place a break-point in the next line
        /// below testKeys, hover over testKeys you will see id column(s)
        /// that can be auto-incrementing yet not set as IDENTITY columns.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdColumnsForTable_Click(object sender, EventArgs e)
        {
            if (listBoxDatabaseNames.DataSource != null && listBoxTableNames.DataSource != null)
            {

                if ( listBoxTableNames.FindString("(none)") == -1 )
                {
                    var dbName = listBoxDatabaseNames.Text;
                    var tbName = listBoxTableNames.Text;

                    var columnDetails = serverOperations.GetColumnDetails(dbName, tbName);
                    List<ForeignKeysDetails> testKeys = serverOperations.TableKeys(dbName, tbName);

                    var schema = serverOperations.TableSchema(dbName, tbName);
                    var f = new TableColumnForm(columnDetails);

                    string title = $"{dbName}.{schema}.{tbName}";

                    try
                    {
                        f.Text = title;
                        f.ShowDialog();
                    }
                    finally
                    {
                        f.Dispose();
                    }
                }
            }
        }



    }



}
