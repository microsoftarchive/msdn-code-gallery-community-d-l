using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonUtils;

namespace SyncApplication
{
    public partial class NewSqlPeerCreationWizard : Form
    {
        private string masterConnectionString = null;
        private string peerDbConnectionString = null;
        private string serverName = null;
        private string dbName = null;

        public NewSqlPeerCreationWizard()
        {
            InitializeComponent();
            serverNameTxtBox.Text = Environment.MachineName;
        }

        internal string MasterConnectionString
        {
            get { return masterConnectionString; }
        }

        internal string PeerDbConnectionString
        { 
            get { return peerDbConnectionString; } 
        }

        internal string ServerName
        {
            get { return serverName; }
        }

        internal string DatabaseName
        {
            get { return dbName; }
        }

        private string GenerateConnectionString(string dbName)
        {
            return SyncUtils.GenerateSqlConnectionString(
                serverNameTxtBox.Text, dbName, userNameTxtBox.Text, passwordTxtBox.Text, trustedConnChkBox.Checked);
        }

        private void testConnBtn_Click(object sender, EventArgs e)
        {
            masterConnectionString = GenerateConnectionString("master");

            using (SqlConnection conn = new SqlConnection(masterConnectionString))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Connection test succeeds!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Connection test failed!");
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            serverName = serverNameTxtBox.Text;
            dbName = dbNameTxtBox.Text;
            masterConnectionString = GenerateConnectionString("master");
            peerDbConnectionString = GenerateConnectionString(dbName);
            this.Close();
        }

        private void trustedConnChkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (trustedConnChkBox.Checked)
            {
                userNameLbl.Enabled = false;
                userNameTxtBox.Enabled = false;
                passwordLbl.Enabled = false;
                passwordTxtBox.Enabled = false;
            }
            else
            {
                userNameLbl.Enabled = true;
                userNameTxtBox.Enabled = true;
                passwordLbl.Enabled = true;
                passwordTxtBox.Enabled = true;
            }
        }
    }
}
