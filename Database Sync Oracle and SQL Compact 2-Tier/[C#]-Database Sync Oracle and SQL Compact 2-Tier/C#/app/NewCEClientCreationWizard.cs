using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SyncApplication
{
    /// <summary>
    /// Helper form that is used to add a new CE client database. Client database can be created in FullInitialization mode or SnapshotInitialization mode.
    /// For snapshot initialization the user needs to specify the source CE database that will be used to initialze from.
    /// </summary>
    public partial class NewCEClientCreationWizard : Form
    {
        public NewCEClientCreationWizard()
        {
            InitializeComponent();
        }

        private void NewCEClientCreationWizard_Load(object sender, EventArgs e)
        {
            EnableFullInit();
        }

        //Disable all buttons
        private void DisableAll()
        {
            this.okBtn.Enabled = false;
            this.fullInitDbLocation.Enabled = false;
            this.browseFullInitBtn.Enabled = false;
            this.snapshotDestBrowse.Enabled = false;
            this.snapshotSrcBrowse.Enabled = false;
            this.snapshotDestLocation.Enabled = false;
            this.snapshotSrcLocation.Enabled = false;
        }

        //Enable only GUI elements related to Full init
        private void EnableFullInit()
        {
            DisableAll();
            this.fullInitDbLocation.Enabled =  this.browseFullInitBtn.Enabled = true;
        }

        //Enable only GUI elements related to snapshot init
        private void EnableSnapshotInit()
        {
            DisableAll();
            this.snapshotDestBrowse.Enabled = this.snapshotSrcBrowse.Enabled = this.snapshotDestLocation.Enabled = this.snapshotSrcLocation.Enabled = true;
        }

        private void browseFullInitBtn_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.CheckFileExists = false;
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                this.fullInitDbLocation.Text = openFileDialog1.FileName;
            }
            this.okBtn.Enabled = true;
        }

        private void fullInitRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            EnableFullInit();
        }

        private void snapshotSrcBrowse_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.CheckFileExists = true;
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                this.snapshotSrcLocation.Text = openFileDialog1.FileName;
            }
        }

        private void snapshotDestBrowse_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.CheckFileExists = false;
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                this.snapshotDestLocation.Text = openFileDialog1.FileName;
            }
            this.okBtn.Enabled = true;
        }

        private void fastInitSnapshotBtn_CheckedChanged(object sender, EventArgs e)
        {
            EnableSnapshotInit();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
