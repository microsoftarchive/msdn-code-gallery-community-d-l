using System;
using System.Windows.Forms;
using ComponentPro.Net;
using ComponentPro.IO;

namespace ClientSample.Sftp
{
    /// <summary>
    /// The remote properties form.
    /// </summary>
    public partial class SftpPropertiesForm : Form
    {
        public SftpPropertiesForm()
        {
            InitializeComponent();
        }

        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        private bool _directory;
        public bool Directory
        {
            get { return _directory; }
            set { _directory = value; }
        }

        private bool _recursive;
        public bool Recursive
        {
            get { return _recursive; }
            set { _recursive = value; }
        }

        private SftpFilePermissions _permissions;
        public SftpFilePermissions Permissions
        {
            get { return _permissions; }
            set { _permissions = value; }
        }

        private bool _loaded;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            txtPermissions.Text = Convert.ToString((int) _permissions, 16);

            UpdateCheckboxes();

            chkRecursive.Checked = _recursive;
            chkRecursive.Enabled = _directory;

            if (_fileName == null)
                Text = "Multiple files - Properties";
            else
                Text = FileSystemPath.GetRemoteFileName(_fileName) + " - Properties";

            _loaded = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            UpdatePermissions();

            _recursive = chkRecursive.Checked;
        }

        void UpdateCheckboxes()
        {
            chkOwnerRead.Checked = (_permissions & SftpFilePermissions.OwnerRead) != 0;
            chkOwnerWrite.Checked = (_permissions & SftpFilePermissions.OwnerWrite) != 0;
            chkOwnerExecute.Checked = (_permissions & SftpFilePermissions.OwnerExecute) != 0;
            chkSetUID.Checked = (_permissions & SftpFilePermissions.SetUid) != 0;

            chkGroupRead.Checked = (_permissions & SftpFilePermissions.GroupRead) != 0;
            chkGroupWrite.Checked = (_permissions & SftpFilePermissions.GroupWrite) != 0;
            chkGroupExecute.Checked = (_permissions & SftpFilePermissions.GroupExecute) != 0;
            chkSetGID.Checked = (_permissions & SftpFilePermissions.SetGid) != 0;

            chkPublicRead.Checked = (_permissions & SftpFilePermissions.OthersRead) != 0;
            chkPublicWrite.Checked = (_permissions & SftpFilePermissions.OthersWrite) != 0;
            chkPublicExecute.Checked = (_permissions & SftpFilePermissions.OthersExecute) != 0;
            chkStickly.Checked = (_permissions & SftpFilePermissions.Sticky) != 0;
        }

        void UpdatePermissions()
        {
            _permissions = 0;

            if (chkOwnerRead.Checked) _permissions |= SftpFilePermissions.OwnerRead;
            if (chkOwnerWrite.Checked) _permissions |= SftpFilePermissions.OwnerWrite;
            if (chkOwnerExecute.Checked) _permissions |= SftpFilePermissions.OwnerExecute;
            if (chkSetUID.Checked) _permissions |= SftpFilePermissions.SetUid;

            if (chkGroupRead.Checked) _permissions |= SftpFilePermissions.GroupRead;
            if (chkGroupWrite.Checked) _permissions |= SftpFilePermissions.GroupWrite;
            if (chkGroupExecute.Checked) _permissions |= SftpFilePermissions.GroupExecute;
            if (chkSetGID.Checked) _permissions |= SftpFilePermissions.SetGid;

            if (chkPublicRead.Checked) _permissions |= SftpFilePermissions.OthersRead;
            if (chkPublicWrite.Checked) _permissions |= SftpFilePermissions.OthersWrite;
            if (chkPublicExecute.Checked) _permissions |= SftpFilePermissions.OthersExecute;
            if (chkStickly.Checked) _permissions |= SftpFilePermissions.Sticky;
        }

        private void txtPermissions_TextChanged(object sender, EventArgs e)
        {
            if (!_loaded || txtPermissions.Text.Length == 0) return;
            try
            {
                uint p = Convert.ToUInt32(txtPermissions.Text, 16);
                if (p < 0 || p > 0xFFF)
                    MessageBox.Show(Messages.InvalidPermissions, "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                _permissions = (SftpFilePermissions)p;
                UpdateCheckboxes();
            }
            catch (Exception)
            {
                MessageBox.Show(Messages.InvalidPermissions, "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
            }
        }

        private void checkBoxes_CheckedChanged(object sender, EventArgs e)
        {
            if (!_loaded || txtPermissions.Focused) return;
            UpdatePermissions();
            txtPermissions.Text = Convert.ToString((int) _permissions, 16);
        }
    }
}