using System;
using System.Windows.Forms;
using ComponentPro.IO;
using ComponentPro.Net;

namespace ClientSample.Ftp
{
    /// <summary>
    /// The remote properties form.
    /// </summary>
    public partial class FtpPropertiesForm : Form
    {
        public FtpPropertiesForm()
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

        private RecursionMode _recursive;
        public RecursionMode Recursive
        {
            get { return _recursive; }
            set { _recursive = value; }
        }

        private FtpFilePermissions _permissions;
        public FtpFilePermissions Permissions
        {
            get { return _permissions; }
            set { _permissions = value; }
        }

        public string PermissionsString
        {
            get { return Convert.ToString((int)_permissions, 8); }
        }

        private bool _loaded;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            UpdateCheckboxes();

            chkRecursive.Checked = _recursive == RecursionMode.RecurseIntoAllSubFolders;
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

            _recursive = chkRecursive.Checked ? RecursionMode.RecurseIntoAllSubFolders : RecursionMode.None;
        }

        void UpdateCheckboxes()
        {
            chkOwnerRead.Checked = (_permissions & FtpFilePermissions.OwnerRead) != 0;
            chkOwnerWrite.Checked = (_permissions & FtpFilePermissions.OwnerWrite) != 0;
            chkOwnerExecute.Checked = (_permissions & FtpFilePermissions.OwnerExecute) != 0;

            chkGroupRead.Checked = (_permissions & FtpFilePermissions.GroupRead) != 0;
            chkGroupWrite.Checked = (_permissions & FtpFilePermissions.GroupWrite) != 0;
            chkGroupExecute.Checked = (_permissions & FtpFilePermissions.GroupExecute) != 0;

            chkPublicRead.Checked = (_permissions & FtpFilePermissions.PublicRead) != 0;
            chkPublicWrite.Checked = (_permissions & FtpFilePermissions.PublicWrite) != 0;
            chkPublicExecute.Checked = (_permissions & FtpFilePermissions.PublicExecute) != 0;
        }

        void UpdatePermissions()
        {
            _permissions = 0;

            if (chkOwnerRead.Checked) _permissions |= FtpFilePermissions.OwnerRead;
            if (chkOwnerWrite.Checked) _permissions |= FtpFilePermissions.OwnerWrite;
            if (chkOwnerExecute.Checked) _permissions |= FtpFilePermissions.OwnerExecute;

            if (chkGroupRead.Checked) _permissions |= FtpFilePermissions.GroupRead;
            if (chkGroupWrite.Checked) _permissions |= FtpFilePermissions.GroupWrite;
            if (chkGroupExecute.Checked) _permissions |= FtpFilePermissions.GroupExecute;

            if (chkPublicRead.Checked) _permissions |= FtpFilePermissions.PublicRead;
            if (chkPublicWrite.Checked) _permissions |= FtpFilePermissions.PublicWrite;
            if (chkPublicExecute.Checked) _permissions |= FtpFilePermissions.PublicExecute;
        }

        private void checkBoxes_CheckedChanged(object sender, EventArgs e)
        {
            if (!_loaded) return;
            UpdatePermissions();
        }
    }
}