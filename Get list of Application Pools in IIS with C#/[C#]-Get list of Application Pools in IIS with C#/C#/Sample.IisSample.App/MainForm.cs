using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Windows.Forms;
using Sample.IisSample.App.Properties;

namespace Sample.IisSample.App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ChangeCredentialState(object sender, EventArgs e)
        {
            txtPassword.Enabled = !(chkUseCurrentUser.Checked);
            txtUsername.Enabled = !(chkUseCurrentUser.Checked);
        }

        private void GetServicesClick(object sender, EventArgs e)
        {
            string computerName = txtComputerName.Enabled ? txtComputerName.Text : SystemInformation.ComputerName;
            if (!string.IsNullOrEmpty(computerName))
            {
                GetServicesForComputer(computerName);
            }
            else
            {
                lblErrors.Text = @"Computer Name cannot be empty";
                return;
            }
        }

        private void ChangeComputerState(object sender, EventArgs e)
        {
            txtComputerName.Enabled = !(chkUseCurrentComputer.Checked);
        }

        private void GetServicesForComputer(string computerName)
        {
            try
            {
                List<string> appPools = GetApplicationPools(computerName);

                lstAppPools.DataSource = appPools;
            }
            catch (Exception exception)
            {
                lstAppPools.DataSource = null;
                lstAppPools.Items.Clear();
                lblErrors.Text = exception.Message;
                Console.WriteLine(Resources.MainForm_GetServicesForComputer_Error___ + exception.Message);
            }
        }

        public List<string> GetApplicationPools(string computerName)
        {
            DirectoryEntry root = GetDirectoryEntry(@"IIS://" + computerName + "/W3SVC/AppPools");

            if (root == null) return null;
            List<string> items =
                (from DirectoryEntry entry in root.Children let properties = entry.Properties select entry.Name).ToList();
            return items;
        }

        private DirectoryEntry GetDirectoryEntry(string path)
        {
            DirectoryEntry root = null;

            try
            {
                root = chkUseCurrentUser.Checked ? new DirectoryEntry(path) : new DirectoryEntry(path, txtUsername.Text, txtPassword.Text, AuthenticationTypes.Secure);
            }

            catch(Exception e)
            {
                lblErrors.Text = e.Message;
            }

            return root;
        }
    }
}