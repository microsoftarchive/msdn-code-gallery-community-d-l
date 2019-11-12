using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ClientSample.Sftp;
using ComponentPro.IO;
using ComponentPro.Net;
using System.Drawing;

namespace ClientSample
{
    public partial class Main : Form, IClientView
    {
        private bool _exception;
        private ClientController _controller;
        private SettingInfoBase _loginSettings;
        private SettingInfoBase _settings;
        private int _folderIconIndex; // Image index of the folder icon.
        private FileIconManager _iconManager; // Icon manager.
        private const int UpFolderImageIndex = 0;
        private const int FolderLinkImageIndex = 1;
        private const int SymlinkImageIndex = 2;
        private string _mask = "*.*";
        
        private FileOperation _fileOpForm;

        public Main()
        {
            // This try catch block is not needed if you have a production license.
            try
            {
                InitializeComponent();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error");
                _exception = true;
            }
            
#if !FTP && SFTP
            mnuPopExecuteCommand.Visible = false;
            executeCommandToolStripMenuItem.Visible = false;
            lcmUploadUnique.Visible = false;
            uploadUniqueFileToolStripMenuItem.Visible = false;
#endif
        }

        #region Load and Save Settings

        /// <summary>
        /// Handles the form's Load event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_exception)
            {
                Close();
                return;
            }

            // Load settings from the Registry.
            _loginSettings = new SettingInfoBase();
            _settings = new SettingInfoBase();

#if FTP && SFTP
            _loginSettings.LoadConfig(LoginInfo.LoadConfig, FtpLoginInfo.LoadConfig, SftpLoginInfo.LoadConfig);
            _settings.LoadConfig(SettingInfo.LoadConfig, FtpSettingInfo.LoadConfig, SftpSettingInfo.LoadConfig);
#elif FTP
            _loginSettings.LoadConfig(LoginInfo.LoadConfig, FtpLoginInfo.LoadConfig);
            _settings.LoadConfig(SettingInfo.LoadConfig, FtpSettingInfo.LoadConfig);
#elif SFTP
            _loginSettings.LoadConfig(LoginInfo.LoadConfig, SftpLoginInfo.LoadConfig);
            _settings.LoadConfig(SettingInfo.LoadConfig, SftpSettingInfo.LoadConfig);
#endif

            txtLocalDir.Text = _loginSettings.Get<string>(LoginInfo.LocalDir);

            // Create a new icon manager object.
            _iconManager = new FileIconManager(imglist, IconSize.Small);
            // Get folder image index.
            _folderIconIndex = _iconManager.AddFolderIcon(FolderType.Closed);

            _controller = new ClientController(this, _loginSettings, _settings);

            // Show local files.
            _controller.RefreshLocalList();

            _fileOpForm = new FileOperation();
        }

        /// <summary>
        /// Handles the form's Close event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnClosed(EventArgs e)
        {
            // Logged in?
            if (loginToolStripMenuItem.Enabled && loginToolStripMenuItem.Text == "&Disconnect")
            {
                // Disconnect.
                _controller.Disconnect();                

                // and wait for the completion.
                while (_controller.State != ConnectionState.NotConnected)
                {
                    System.Threading.Thread.Sleep(50);
                    Application.DoEvents();
                }
            }

            try
            {
                // Try to delete temporary folder that was used to download files for viewing.
                Util.DeleteTempFolder();
            }
            catch { }

            // Save settings to the Registry.
#if FTP && SFTP
            _loginSettings.SaveConfig(LoginInfo.SaveConfig, FtpLoginInfo.SaveConfig, SftpLoginInfo.SaveConfig);
            _settings.SaveConfig(SettingInfo.SaveConfig, FtpSettingInfo.SaveConfig, SftpSettingInfo.SaveConfig);
#elif FTP
            _loginSettings.SaveConfig(LoginInfo.SaveConfig, FtpLoginInfo.SaveConfig);
            _settings.SaveConfig(SettingInfo.SaveConfig, FtpSettingInfo.SaveConfig);
#elif SFTP
            _loginSettings.SaveConfig(LoginInfo.SaveConfig, SftpLoginInfo.SaveConfig);
            _settings.SaveConfig(SettingInfo.SaveConfig, SftpSettingInfo.SaveConfig);
#endif

            base.OnClosed(e);
        }

        #endregion

        #region Main Menu

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show general settings dialog.
            Setting dlg = new Setting(_settings);
            if (dlg.ShowDialog() == DialogResult.OK && _controller.State == ConnectionState.Ready)
            {
                _controller.ApplySettings(_settings);
            }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Not logged in?
            if (loginToolStripMenuItem.Text == "&Connect...")
            {
                // Show the Login form.
                Login form = new Login(_loginSettings);
                if (form.ShowDialog() == DialogResult.Cancel)
                    return;

                // Clear log text box.
                txtLog.Clear();

                // Connect to the server.
                _controller.DoConnect(0);
            }
            else
            {
                // Log out.
                _controller.Disconnect();
            }
        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwRemote.Focused && _controller.State == ConnectionState.Ready)
            {
                DoRemoteMove();
            }
            else if (lvwLocal.Focused)
            {
                DoLocalMove();
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwRemote.Focused && _controller.State == ConnectionState.Ready)
            {
                lvwRemote.SelectedItems[0].BeginEdit();
            }
            else if (lvwLocal.Focused)
            {
                lvwLocal.SelectedItems[0].BeginEdit();
            }
        }

        private void makeDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwRemote.Focused && _controller.State == ConnectionState.Ready)
            {
                DoRemoteMakeDir();
            }
            else if (lvwLocal.Focused)
            {
                DoLocalMakeDir();
            }
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!progressBar.Enabled)
                // When the File menu item is clicked, enable/disable its child menu items.
                DoRemoteDownload();
        }

        private void uploadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoLocalUpload();
        }

        private void uploadUniqueFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if FTP
            DoLocalUploadUnique(lvwLocal.SelectedItems[0]);
#endif
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwRemote.Focused && _controller.State == ConnectionState.Ready)
            {
                if (lvwRemote.SelectedItems.Count > 0)
                    DoRemoteProperties();
            }
            else
            {
                if (lvwLocal.SelectedItems.Count > 0)
                    DoLocalProperties(lvwLocal.SelectedItems[0]);
            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwRemote.Focused && _controller.State == ConnectionState.Ready)
            {
                DoRemoteView(lvwRemote.SelectedItems[0]);
            }
            else
            {
                DoLocalView(lvwLocal.SelectedItems[0]);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwRemote.Focused && _controller.State == ConnectionState.Ready)
                _controller.RefreshRemoteList();
            else
                _controller.RefreshLocalList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwRemote.Focused && _controller.State == ConnectionState.Ready && lvwRemote.SelectedItems.Count > 0)
            {
                DoRemoteDelete();
            }
            else if (lvwLocal.Focused && lvwLocal.SelectedItems.Count > 0)
            {
                DoLocalDelete();
            }
        }

        private void synchronizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoSynchronize();
        }

        void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void executeCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if FTP
            mnuPopExecuteCommand_Click(null, null);
#endif
        }

        private void getTimeDifferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnuPopGetTimeDiff_Click(null, null);
        }

        private void resumeDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnuPopResumeDownload_Click(null, null);
        }

        private void resumeUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lcmResumeUpload_Click(null, null);
        }

        private void calculateTotalSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnuPopCalcTotalSize_Click(null, null);
        }

        private void deleteMultipleFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnuPopDeleteMultipleFiles_Click(null, null);
        }

        #endregion

        #region Common

        /// <summary>
        /// Gets a boolean value indicating whether the client object is ready to send a command.
        /// </summary>
        bool Ready
        {
            get { return _enabled == 0; }
        }

        static string GetItemFullName(ListViewItem item)
        {
            ListItemInfo info = (ListItemInfo)item.Tag;
            return info.LinkedFile == null ? info.FileInfo.FullName : info.LinkedFile.FullName;
        }

        static void SetItemFullName(ListViewItem item, string newFullName)
        {
            ListItemInfo info = (ListItemInfo)item.Tag;
            info.FileInfo.UpdateFullName(newFullName);
        }        

        /// <summary>
        /// Loads the icon system resource for the given extension.
        /// </summary>
        /// <param name="name">The file name.</param>
        /// <returns>The image index for the given file name.</returns>
        private int SetFileIcon(string name)
        {
            return _iconManager.AddFileIcon(name);
        }

        /// <summary>
        /// Returns fully qualified remote path.
        /// </summary>
        /// <param name="fileName">The file path.</param>
        /// <returns>A fully qualified remote path.</returns>
        private string GetRemoteFullPath(string fileName)
        {
            return _controller.Client.CombinePath(_controller.CurrentRemoteDirectory, fileName);
        }

        #endregion

        #region Log

        /// <summary>
        /// Writes a string with the specified color to the log text box.
        /// </summary>
        /// <param name="str">The string to write.</param>
        /// <param name="color">The text color.</param>
        public void WriteLine(string str, Color color)
        {
            string log = str + "\r\n";
            txtLog.SelectionColor = color;
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.SelectedText = log;
            txtLog.ScrollToCaret();
        }

        #endregion

        #region Enable and Disable Progress Bars

        Control _lastFocus;

        /// <summary>
        /// Enables/disables progress bar and abort button.
        /// </summary>
        /// <param name="enable"></param>
        public void EnableProgress(bool enable)
        {
            if (enable)
            {
                // Save the last focused control.
                if (lvwLocal.Focused)
                    _lastFocus = lvwLocal;
                else _lastFocus = lvwRemote.Focused ? lvwRemote : null;
            }
            else
                status.Text = "Ready";

            menuStrip.Enabled = !enable;

            txtLocalDir.Enabled = !enable;
            btnLocalDirBrowse.Enabled = !enable;
            txtRemoteDir.Enabled = !enable;

            lvwRemote.Enabled = !enable;
            lvwLocal.Enabled = !enable;

            progressBar.Enabled = enable;
            progressBar.Value = 0;
            progressBarTotal.Enabled = enable;
            progressBarTotal.Value = 0;

            #region Toolbar

            tsbLogout.Enabled = !enable;
            tsbRefresh.Enabled = !enable;
            tsbSettings.Enabled = !enable;
            tsbUpload.Enabled = !enable;
            tsbDownload.Enabled = !enable;
            tsbDelete.Enabled = !enable;
            tsbMove.Enabled = !enable;
            tsbCreateDir.Enabled = !enable;
            tsbView.Enabled = !enable;
            tsbSynchronize.Enabled = !enable;

            btnAbort.Enabled = enable;

            #endregion

            keepAliveTimer.Enabled = !enable;

            // Disable/Enable the Close button as well.
            Util.EnableCloseButton(this, !enable);

            if (!enable)
            {
                if (_lastFocus != null)
                {
                    // Enable the last focused control.
                    _lastFocus.Focus();
                    EnableButtons();
                }
            }

            if (enable)
                _fileOpForm.Init();
        }

        /// <summary>
        /// Enables/disables control buttons (of menu and toolbar).
        /// </summary>
        private void EnableButtons()
        {
            bool connected = _controller.State == ConnectionState.Ready && Ready;
            bool selected;
            ListViewItem selectedItem;
            bool isFile;

            if (lvwRemote.Focused && _controller.State == ConnectionState.Ready)
            {
                if (connected && lvwRemote.SelectedItems.Count > 0 &&
                                            lvwRemote.SelectedItems[0].ImageIndex != UpFolderImageIndex)
                    selectedItem = lvwRemote.SelectedItems[0];
                else
                    selectedItem = null;

                selected = connected && (lvwRemote.SelectedItems.Count > 1 || selectedItem != null);
                isFile = selectedItem != null && selectedItem.ImageIndex != _folderIconIndex && selectedItem.ImageIndex != FolderLinkImageIndex;

                renameToolStripMenuItem.Enabled = selectedItem != null;
                deleteToolStripMenuItem.Enabled = selected;
                deleteMultipleFilesToolStripMenuItem.Enabled = selected;
                moveToolStripMenuItem.Enabled = selected;
                makeDirectoryToolStripMenuItem.Enabled = connected;
                uploadFileToolStripMenuItem.Enabled = false;
                uploadUniqueFileToolStripMenuItem.Enabled = false;
                downloadToolStripMenuItem.Enabled = selected;
                viewToolStripMenuItem.Enabled = isFile;
                refreshToolStripMenuItem.Enabled = connected;
                synchronizeToolStripMenuItem.Enabled = connected;
                propertiesToolStripMenuItem.Enabled = selected;

                resumeUploadToolStripMenuItem.Enabled = false;
                resumeDownloadToolStripMenuItem.Enabled = isFile || lvwRemote.SelectedItems.Count > 1;
                executeCommandToolStripMenuItem.Enabled = connected;
                calculateTotalSizeToolStripMenuItem.Enabled = selected;
                getTimeDifferenceToolStripMenuItem.Enabled = connected;
            }
            else if (lvwLocal.Focused)
            {
                selectedItem = (lvwLocal.SelectedItems.Count > 0 &&
                                        lvwLocal.SelectedItems[0].ImageIndex != UpFolderImageIndex) ? lvwLocal.SelectedItems[0] : null;
                selected = lvwLocal.SelectedItems.Count > 1 || selectedItem != null;
                isFile = selectedItem != null && selectedItem.ImageIndex != _folderIconIndex;

                renameToolStripMenuItem.Enabled = selectedItem != null;
                deleteToolStripMenuItem.Enabled = selected;
                deleteMultipleFilesToolStripMenuItem.Enabled = false;
                moveToolStripMenuItem.Enabled = selected;
                makeDirectoryToolStripMenuItem.Enabled = true;
                uploadFileToolStripMenuItem.Enabled = connected && selected;
#if FTP
                uploadUniqueFileToolStripMenuItem.Enabled = connected && isFile && _controller.ServerType == ServerProtocol.Ftp;
#endif
                downloadToolStripMenuItem.Enabled = false;
                viewToolStripMenuItem.Enabled = isFile;
                refreshToolStripMenuItem.Enabled = true;
                synchronizeToolStripMenuItem.Enabled = connected;
                propertiesToolStripMenuItem.Enabled = selected;

                resumeUploadToolStripMenuItem.Enabled = connected && (isFile || lvwLocal.SelectedItems.Count > 1);
                resumeDownloadToolStripMenuItem.Enabled = false;
                executeCommandToolStripMenuItem.Enabled = connected;
                calculateTotalSizeToolStripMenuItem.Enabled = false;
                getTimeDifferenceToolStripMenuItem.Enabled = connected;
            }
            else
            {
                renameToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                deleteMultipleFilesToolStripMenuItem.Enabled = false;
                moveToolStripMenuItem.Enabled = false;
                makeDirectoryToolStripMenuItem.Enabled = false;
                uploadFileToolStripMenuItem.Enabled = false;
                uploadUniqueFileToolStripMenuItem.Enabled = false;
                downloadToolStripMenuItem.Enabled = false;
                viewToolStripMenuItem.Enabled = false;
                refreshToolStripMenuItem.Enabled = false;
                synchronizeToolStripMenuItem.Enabled = connected;
                propertiesToolStripMenuItem.Enabled = false;

                resumeUploadToolStripMenuItem.Enabled = false;
                resumeDownloadToolStripMenuItem.Enabled = false;
                executeCommandToolStripMenuItem.Enabled = false;
                calculateTotalSizeToolStripMenuItem.Enabled = false;
                getTimeDifferenceToolStripMenuItem.Enabled = connected;
            }

            tsbDelete.Enabled = deleteToolStripMenuItem.Enabled;
            tsbMove.Enabled = moveToolStripMenuItem.Enabled;
            tsbCreateDir.Enabled = makeDirectoryToolStripMenuItem.Enabled;
            tsbUpload.Enabled = uploadFileToolStripMenuItem.Enabled;
            tsbDownload.Enabled = downloadToolStripMenuItem.Enabled;
            tsbView.Enabled = viewToolStripMenuItem.Enabled;
            tsbRefresh.Enabled = refreshToolStripMenuItem.Enabled;
            tsbSynchronize.Enabled = synchronizeToolStripMenuItem.Enabled;
        }

        #endregion

        #region Context Menus

        private void lvwLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable/disable control buttons when the selected item on the local view control is changed.
            EnableButtons();
        }

        private void lvwRemote_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable/disable control buttons when the selected item on the remote view control is changed.
            EnableButtons();
        }

        #endregion

        #region Toolbar Buttons

        private void tsbLogin_Click(object sender, EventArgs e)
        {
            loginToolStripMenuItem_Click(sender, null);
        }

        private void tsbLogout_Click(object sender, EventArgs e)
        {
            loginToolStripMenuItem_Click(sender, null);
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            refreshToolStripMenuItem_Click(sender, null);
        }

        private void tsbSettings_Click(object sender, EventArgs e)
        {
            settingsToolStripMenuItem_Click(sender, null);
        }

        private void tsbCreateDir_Click(object sender, EventArgs e)
        {
            makeDirectoryToolStripMenuItem_Click(sender, null);
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            deleteToolStripMenuItem_Click(sender, null);
        }

        private void tsbMove_Click(object sender, EventArgs e)
        {
            moveToolStripMenuItem_Click(sender, null);
        }

        private void tsbDownload_Click(object sender, EventArgs e)
        {
            downloadToolStripMenuItem_Click(sender, null);
        }

        private void tsbUpload_Click(object sender, EventArgs e)
        {
            uploadFileToolStripMenuItem_Click(sender, null);
        }

        private void tsbView_Click(object sender, EventArgs e)
        {
            viewToolStripMenuItem_Click(sender, null);
        }

        private void tsbSynchronize_Click(object sender, EventArgs e)
        {
            synchronizeToolStripMenuItem_Click(sender, null);
        }

        #endregion

        #region Client

        private void btnAbort_Click(object sender, EventArgs e)
        {
            // Abort transferring.
            _controller.Cancel();
        }

        bool IsListItemSelected(ListView lv)
        {
            if (lv.SelectedItems.Count == 0)
                return false;

            return lv.SelectedItems[0] != null;
        }

        bool IsRemoteItemSelected()
        {
            return IsListItemSelected(lvwRemote);
        }

        /// <summary>
        /// Renames the selected item.
        /// </summary>
        /// <param name="newname">The new remote path name.</param>
        /// <returns>true if successful; otherwise is false.</returns>
        private bool DoRemoteRename(string newname)
        {
            if (!IsRemoteItemSelected() || newname == null)
                return false;

            // Attempts to rename the currently selected item to the new name.
            ListViewItem item = lvwRemote.SelectedItems[0];

            // Call the controller's Rename method. This is not an asynchronous method.
            if (!_controller.DoRemoteRename(item.Text, newname))
                return false;

            // Change the image index of the selected item if the selected item not a folder or symlink.
            if (item.ImageIndex != _folderIconIndex && item.ImageIndex != FolderLinkImageIndex && item.ImageIndex != SymlinkImageIndex)
                item.ImageIndex = _iconManager.AddFileIcon(newname);

            SetItemFullName(item, GetRemoteFullPath(newname));

            return true;
        }

        #region Remove Files/Directories

        string _deleteFilesMask = "*.*";

        /// <summary>
        /// Deletes selected items.
        /// </summary>
        private void DoRemoteDeleteMultipleFiles()
        {
            FileMask dlg = new FileMask(_deleteFilesMask, "Delete files that match");
            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;

            _deleteFilesMask = dlg.Mask;
            List<AbstractFileInfo> files = new List<AbstractFileInfo>();
            SearchCondition condition = new NameSearchCondition(dlg.Mask);

            foreach (ListViewItem item in lvwRemote.Items)
            {
                ListItemInfo i = (ListItemInfo) item.Tag;

                if (i.FileInfo.Name != ".." && (i.FileInfo.IsDirectory || condition.Matches(i.FileInfo)))
                    files.Add(i.FileInfo);
            }

            _controller.DoRemoteDelete(files.ToArray(), condition);
        }

        /// <summary>
        /// Deletes selected items.
        /// </summary>
        private void DoRemoteDelete()
        {
            AbstractFileInfo[] list = BuildFileList(lvwRemote.SelectedItems);
            _controller.DoRemoteDelete(list, null);
        }

        #endregion

        #region View

        /// <summary>
        /// Downloads the selected item and open notepad.exe for viewing the newly downloaded file.
        /// </summary>
        /// <param name="item">The selected item.</param>
        private void DoRemoteView(ListViewItem item)
        {
            if (item.ImageIndex != UpFolderImageIndex && item.ImageIndex != FolderLinkImageIndex && item.ImageIndex != _folderIconIndex) // Not a folder or a symlink
            {
                _controller.DoRemoteView(item.Text);
            }
        }

        #endregion

        AbstractFileInfo[] BuildFileList(IList items)
        {
            List<AbstractFileInfo> files = new List<AbstractFileInfo>();
            foreach (ListViewItem item in items)
            {
                if (item.ImageIndex != UpFolderImageIndex && item.Text != "..")
                    files.Add(((ListItemInfo)item.Tag).FileInfo);
            }
            if (files.Count == 0)
                return null;

            return files.ToArray();
        }

        #region Move

        private string _moveToFolder;
        /// <summary>
        /// Moves one or more items to another remote folder.
        /// </summary>
        private void DoRemoteMove()
        {
            AbstractFileInfo[] fileList = BuildFileList(lvwRemote.SelectedItems);
            if (_moveToFolder == null)
                _moveToFolder = _controller.CurrentRemoteDirectory;

            MoveToRemoteFolder dlg = new MoveToRemoteFolder(_moveToFolder);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            if (dlg.RemoteDir == _controller.CurrentRemoteDirectory)
            {
                MessageBox.Show(Messages.InvalidSourceDestDir, Messages.MessageTitle,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                return;
            }

            _moveToFolder = dlg.RemoteDir;

            _controller.DoRemoteMove(fileList, _moveToFolder, dlg.FileMasks);
        }

        #endregion

        #region Make Dir

        /// <summary>
        /// Makes a new remote directory.
        /// </summary>
        private void DoRemoteMakeDir()
        {
            FolderNamePrompt dlg = new FolderNamePrompt();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (_controller.DoRemoteMakeDir(dlg.FolderName))
                    lvwRemote.Items.Add(dlg.FolderName, _folderIconIndex);
            }
        }

        #endregion

        #region Remote Property

        /// <summary>
        /// Shows the properties dialog to change file's permissions.
        /// </summary>
        private void DoRemoteProperties()
        {
            AbstractFileInfo[] fileList = BuildFileList(lvwRemote.SelectedItems);
            if (fileList == null)
                return;

            ListViewItem item = lvwRemote.SelectedItems[0];
            if (item.Text == "..")
                item = lvwRemote.SelectedItems[1];

            string permissions = ((ListItemInfo)item.Tag).Permissions;
            if (permissions.Length < 3)
            {
                MessageBox.Show("Remote file system does not support this operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

#if FTP
            if (_controller.ServerType == ServerProtocol.Ftp)
            {
                FtpFileInfo info = (FtpFileInfo) item.Tag;

                FtpPropertiesForm dlg = new FtpPropertiesForm();
                dlg.FileName = GetItemFullName(item);
                dlg.Directory = item.ImageIndex == _folderIconIndex;
                dlg.Permissions = info.Permissions;
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                _controller.DoRemoteSetFilePermissions(fileList, dlg.PermissionsString, dlg.Recursive == RecursionMode.RecurseIntoAllSubFolders);
            }
#endif
#if SFTP
            if (_controller.ServerType == ServerProtocol.Sftp)
            {
                SftpPropertiesForm dlg = new SftpPropertiesForm();
                dlg.FileName = GetItemFullName(item);
                dlg.Directory = item.ImageIndex == _folderIconIndex;
                dlg.Permissions = (SftpFilePermissions)Convert.ToUInt32(item.SubItems[3].Text.Substring(0, 3), 16);
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                SftpFileAttributes attrs = new SftpFileAttributes();
                attrs.Permissions = dlg.Permissions;

                _controller.DoRemoteSetFileAttributes(fileList, attrs, dlg.Recursive);
            }
#endif
        }

        #endregion

        #region Synchronize

        /// <summary>
        /// Synchronizes local and remote folders.
        /// </summary>
        private void DoSynchronize()
        {
            SynchronizeFolders dlg = new SynchronizeFolders(lvwLocal.Focused, 
                _loginSettings.Get<RecursionMode>(LoginInfo.SyncRecursive), 
                _loginSettings.Get<bool>(LoginInfo.SyncDateTime), 
                _loginSettings.Get<int>(LoginInfo.SyncMethod), 
                _loginSettings.Get<bool>(LoginInfo.SyncResumability), 
                _loginSettings.Get<string>(LoginInfo.SyncSearchPattern));

            if (dlg.ShowDialog() != DialogResult.OK) return;
            if (MessageBox.Show(
                    string.Format(
                            Messages.SyncConfirm,
                            dlg.RemoteIsMaster ? txtLocalDir.Text : txtRemoteDir.Text,
                            dlg.RemoteIsMaster ? txtRemoteDir.Text : txtLocalDir.Text
                            ),
                        Messages.MessageTitle,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            _loginSettings.Set(LoginInfo.SyncRecursive, dlg.Recursive);
            _loginSettings.Set(LoginInfo.SyncSearchPattern, dlg.SearchPattern);
            _loginSettings.Set(LoginInfo.SyncDateTime, dlg.SyncDateTime);
            _loginSettings.Set(LoginInfo.SyncMethod, dlg.ComparisonMethod);
            _loginSettings.Set(LoginInfo.SyncResumability, dlg.CheckForResumability);

            _controller.DoSynchronize(dlg.RemoteIsMaster);
        }

        #endregion

        void IClientView.AskOverwrite(TransferConfirmEventArgs e)
        {
            _fileOpForm.Show(this, e);   
        }

        #endregion

        #region Local List

        private int _lastLocalColumnToSort; // last sort action on this column.
        private SortOrder _lastLocalSortOrder = SortOrder.Ascending; // last sort order.

        #region Local File List        

        /// <summary>
        /// Starts notepad.exe for viewing the selected file.
        /// </summary>
        /// <param name="item">The selected item.</param>
        private void DoLocalView(ListViewItem item)
        {
            try
            {
                // If the selected item is not a folder or a symlink?
                if (item.ImageIndex != UpFolderImageIndex && item.ImageIndex != _folderIconIndex)
                {
                    // Start notepad.exe.
                    Process.Start("Notepad.exe", GetItemFullName(item));
                }
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
            }
        }

        /// <summary>
        /// Deletes local files and/or folders.
        /// </summary>
        /// <returns>true if success; otherwise is false.</returns>
        public void DoLocalDelete()
        {
            AbstractFileInfo[] list = BuildFileList(lvwLocal.SelectedItems);
            _controller.DoLocalDelete(list);
        }

        /// <summary>
        /// Resumes upload the selected item.
        /// </summary>
        private void DoLocalResumeUpload()
        {
            DoLocalResumeUpload(lvwLocal.SelectedItems);
        }

        /// <summary>
        /// Resumes upload a list of list view item.
        /// </summary>
        /// <param name="items">The list of list view item.</param>
        private void DoLocalResumeUpload(IList items)
        {
            AbstractFileInfo[] files = BuildFileList(items);
            _controller.DoLocalResumeUpload(files);
        }

        /// <summary>
        /// Uploads a list of list view item.
        /// </summary>
        /// <param name="items">The list of list view item.</param>
        private void DoLocalUpload(IList items)
        {
            AbstractFileInfo[] list = BuildFileList(items);
            _controller.DoLocalUpload(list);
        }

        /// <summary>
        /// Uploads selected items in the local list view.
        /// </summary>
        private void DoLocalUpload()
        {
            DoLocalUpload(lvwLocal.SelectedItems);
        }

#if FTP
        /// <summary>
        /// Uploads unique the selected item in the local list view.
        /// </summary>
        /// <param name="item">The selected item.</param>
        private void DoLocalUploadUnique(ListViewItem item)
        {
            string localFile = GetItemFullName(item);

            _controller.DoLocalUploadUnique(localFile);
        }
#endif

        /// <summary>
        /// Shows System Properties dialog.
        /// </summary>
        /// <param name="item">The selected item.</param>
        private void DoLocalProperties(ListViewItem item)
        {
            string localFile = GetItemFullName(item);
            // Call Shell API Show File Properties method.
            ShellAPI.ShowFileProperties(localFile, Handle);
        }

        /// <summary>
        /// Renames the selected local file.
        /// </summary>
        /// <param name="newName">The new file name.</param>
        /// <returns>true if successful; otherwise is false.</returns>
        public bool DoLocalRenameFile(string newName)
        {
            if (!string.IsNullOrEmpty(newName))
            {
                ListViewItem item = lvwLocal.SelectedItems[0];

                try
                {
                    string newPath = Path.Combine(txtLocalDir.Text, newName);
                    if (item.ImageIndex == _folderIconIndex)
                        Directory.Move(GetItemFullName(item), newPath);
                    else if (item.ImageIndex != UpFolderImageIndex) // Not up dir.
                    {
                        File.Move(GetItemFullName(item), newPath);
                        item.ImageIndex = _iconManager.AddFileIcon(newName);
                    }
                    SetItemFullName(item, newPath);

                    return true;
                }
                catch (Exception exc)
                {
                    Util.ShowError(exc);
                }
            }

            return false;
        }

        /// <summary>
        /// Creates a new directory and update the local list view.
        /// </summary>
        private void DoLocalMakeDir()
        {
            const string common = "New Folder";
            string dirname = common;
            int n = 0;
            string fullPath = Path.Combine(txtLocalDir.Text, dirname);

            try
            {
                while (Directory.Exists(fullPath)) // While folder with unique name exists.
                {
                    n = n + 1;
                    string unique = "(" + n + ")";
                    dirname = common + unique;
                    fullPath = Path.Combine(txtLocalDir.Text, dirname);
                }

                // Try to create a new folder with unique identifier.
                Directory.CreateDirectory(fullPath);

                ListViewItem item = lvwLocal.Items.Add(dirname, _folderIconIndex);

                item.Tag = new ListItemInfo(DiskFileSystem.Default.CreateFileInfo(fullPath, FileAttributes.Directory, 0, DateTime.Now));

                item.BeginEdit();
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
            }
        }

        /// <summary>
        /// Moves local files.
        /// </summary>
        private void DoLocalMove()
        {
            EnableProgress(true);
            try
            {
                FolderBrowserDialog dlg = new FolderBrowserDialog();
                dlg.SelectedPath = txtLocalDir.Text;
                dlg.Description = "Select destination folder";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    foreach (ListViewItem item in lvwLocal.SelectedItems)
                    {
                        if (_controller.IsAborting)
                            break;

                        if (item.ImageIndex == _folderIconIndex) // Folder
                            Directory.Move(GetItemFullName(item), dlg.SelectedPath + "\\" + item.SubItems[0].Text);
                        else if (item.ImageIndex > UpFolderImageIndex)
                            File.Move(GetItemFullName(item), dlg.SelectedPath + "\\" + item.SubItems[0].Text);

                        lvwLocal.Items.Remove(item);
                    }

                    _controller.RefreshLocalList();
                }
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
            }
            finally
            {
                EnableProgress(false);
            }
        }

        private void DoLocalExpandSelection(bool expand)
        {
            FileMask dlg = new FileMask(_mask, expand);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _mask = dlg.Mask;
                Regex rg = FileSystemPath.MaskToRegex(_mask, false);

                foreach (ListViewItem item in lvwLocal.Items)
                {
                    if (rg.Match(item.Text).Success)
                    {
                        item.Selected = expand;
                    }
                }
            }
        }

        #region Event Handlers

        /// <summary>
        /// Handles the LocalDirBrowse's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnLocalDirBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dlg = new FolderBrowserDialog();
                dlg.Description = "Select local folder";
                dlg.SelectedPath = txtLocalDir.Text;
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _controller.DoLocalChangeDirectory(dlg.SelectedPath);
                }
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
            }
        }

        private void txtLocalDir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter
            {
                _controller.DoLocalChangeDirectory(txtLocalDir.Text);
            }
        }

        private void lvwLocal_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            e.CancelEdit = !DoLocalRenameFile(e.Label);
        }

        private void lvwLocal_DoubleClick(object sender, EventArgs e)
        {
            if (lvwLocal.SelectedItems.Count == 0)
                return;

            if (lvwLocal.SelectedItems[0].ImageIndex == UpFolderImageIndex) // Arrow up
                // Move one level.
                _controller.DoLocalChangeDirectory("..");
            else if (lvwLocal.SelectedItems[0].ImageIndex == _folderIconIndex) // Folder
                // Change directory.
                _controller.DoLocalChangeDirectory(lvwLocal.SelectedItems[0].Text);
            else
            {
                // Upload a single file.
                DoLocalUpload();
            }
        }

        private void UpdateLocalListViewSorter()
        {
            switch (_lastLocalColumnToSort)
            {
                case 0:
                    lvwLocal.ListViewItemSorter = new ListViewItemNameComparer(_lastLocalSortOrder, _folderIconIndex, FolderLinkImageIndex);
                    break;
                case 1:
                    lvwLocal.ListViewItemSorter = new ListViewItemSizeComparer(_lastLocalSortOrder, _folderIconIndex, FolderLinkImageIndex);
                    break;
                case 2:
                    lvwLocal.ListViewItemSorter = new ListViewItemDateComparer(_lastLocalSortOrder, _folderIconIndex, FolderLinkImageIndex);
                    break;
            }

            lvwLocal.ListViewItemSorter = null;
        }

        private void lvwLocal_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvwLocal.Items.Count == 0)
                return;

            ListViewItem cdup = lvwLocal.Items[0].ImageIndex == UpFolderImageIndex ? lvwLocal.Items[0] : null;
            if (cdup != null)
                lvwLocal.Items.Remove(cdup);

            SortOrder sortOrder;
            if (_lastLocalColumnToSort == e.Column)
            {
                sortOrder = _lastLocalSortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
                sortOrder = SortOrder.Ascending;

            _lastLocalColumnToSort = e.Column;
            _lastLocalSortOrder = sortOrder;

            UpdateLocalListViewSorter();

            lvwLocal.ListViewItemSorter = null;
            if (cdup != null)
                lvwLocal.Items.Insert(0, cdup);
        }

        /// <summary>
        /// Handles the local list view's DragDrop event.
        /// </summary>
        /// <param name="sender">The list view object.</param>
        /// <param name="e">The event arguments.</param>
        private void lvwLocal_DragDrop(object sender, DragEventArgs e)
        {
            if (DragAndDropListView.IsValidDragItem(e))
            {
                DragItemData data = (DragItemData)e.Data.GetData(typeof(DragItemData));
                if (data.ListView == lvwRemote)
                    // Download dropped items from the remote list view.
                    DoRemoteDownload(data.DragItems);
            }
        }

        private void lvwLocal_KeyDown(object sender, KeyEventArgs e)
        {
            if (lvwLocal.SelectedItems.Count == 0)
                return;

            ListViewItem lvi;

            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.Back:
                    _controller.DoLocalChangeDirectory("..");
                    break;

                case System.Windows.Forms.Keys.Delete:
                    // Delete files/folders
                    DoLocalDelete();
                    break;

                case Keys.F2:
                    if (lvwLocal.SelectedItems.Count > 0 && lvwLocal.SelectedItems[0].ImageIndex > UpFolderImageIndex) // Not Up dir
                    {
                        lvwLocal.SelectedItems[0].BeginEdit();
                    }
                    break;

                case Keys.Enter:
                    if (lvwLocal.SelectedItems.Count > 0)
                    {
                        lvi = lvwLocal.SelectedItems[0];
                        if (lvi.ImageIndex == _folderIconIndex || lvi.ImageIndex == UpFolderImageIndex) // Is selected item a directory
                        {
                            _controller.DoLocalChangeDirectory(lvwLocal.SelectedItems[0].Text);
                        }
                        else
                        {
                            DoLocalUpload();
                        }
                    }
                    break;
            }
        }

        void lcmRefresh_Click(object sender, System.EventArgs e)
        {
            _controller.RefreshLocalList();
        }

        void lcmView_Click(object sender, System.EventArgs e)
        {
            DoLocalView(lvwLocal.SelectedItems[0]);
        }

        void lcmMove_Click(object sender, System.EventArgs e)
        {
            DoLocalMove();
        }

        void lcmDelete_Click(object sender, System.EventArgs e)
        {
            DoLocalDelete();
        }

        void lcmMakeDir_Click(object sender, System.EventArgs e)
        {
            DoLocalMakeDir();
        }

        void lcmRename_Click(object sender, System.EventArgs e)
        {
            lvwLocal.SelectedItems[0].BeginEdit();
        }

        void lcmUploadUnique_Click(object sender, System.EventArgs e)
        {
#if FTP
            DoLocalUploadUnique(lvwLocal.SelectedItems[0]);
#endif
        }

        void lcmUpload_Click(object sender, System.EventArgs e)
        {
            DoLocalUpload();
        }

        void lcmSynchronize_Click(object sender, System.EventArgs e)
        {
            DoSynchronize();
        }

        void lcmProperties_Click(object sender, EventArgs e)
        {
            DoLocalProperties(lvwLocal.SelectedItems[0]);
        }

        private void lcmResumeUpload_Click(object sender, EventArgs e)
        {
            DoLocalResumeUpload();
        }

        private void lcmSelectGroup_Click(object sender, EventArgs e)
        {
            DoLocalExpandSelection(true);
        }

        private void lcmUnselectGroup_Click(object sender, EventArgs e)
        {
            DoLocalExpandSelection(false);
        }

        private void localContextMenu_Popup(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Enable/disable controls.
            bool connected = _controller.State == ConnectionState.Ready && Ready;

            ListViewItem selectedItem;

            if (lvwLocal.SelectedItems.Count > 0 &&
                                         lvwLocal.SelectedItems[0].ImageIndex != UpFolderImageIndex)
                selectedItem = lvwLocal.SelectedItems[0];
            else
                selectedItem = null;

            bool selected = lvwLocal.SelectedItems.Count > 1 || selectedItem != null;
            bool isFile = selectedItem != null && selectedItem.ImageIndex != _folderIconIndex;

            lcmRename.Enabled = selectedItem != null;
            lcmDelete.Enabled = selected;
            lcmMove.Enabled = selected;
            lcmMakeDir.Enabled = true;
            lcmUpload.Enabled = connected && selected;
#if FTP
            lcmUploadUnique.Enabled = connected && isFile && _controller.ServerType == ServerProtocol.Ftp;
#endif
            lcmView.Enabled = isFile;
            lcmRefresh.Enabled = true;
            lcmSynchronize.Enabled = connected;
            lcmProperties.Enabled = selected;
            lcmResumeUpload.Enabled = connected && (isFile || lvwLocal.SelectedItems.Count > 1);
            lcmSelectGroup.Enabled = true;
            lcmUnselectGroup.Enabled = true;
        }

        private void lvwLocal_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (lvwLocal.Items[e.Item].ImageIndex == UpFolderImageIndex)
                e.CancelEdit = true;
        }

        #endregion

        #endregion

        #endregion

        #region Remote List

        private int _lastRemoteColumnToSort; // last sort action on this column.
        private SortOrder _lastRemoteSortOrder = SortOrder.Ascending; // last sort order.

        #region Remote List File

        /// <summary>
        /// Resume download remote files.
        /// </summary>
        /// <param name="items">The list of ListViewItem.</param>
        public void DoRemoteResumeDownload(IList items)
        {
            AbstractFileInfo[] files = BuildFileList(items);
            _controller.DoRemoteResumeDownload(files);
        }

        private void DoRemoteExpandSelection(bool expand)
        {
            FileMask dlg = new FileMask(_mask, expand);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _mask = dlg.Mask;
                System.Text.RegularExpressions.Regex rg = FileSystemPath.MaskToRegex(_mask, false);

                foreach (ListViewItem item in lvwRemote.Items)
                {
                    if (rg.Match(item.Text).Success)
                    {
                        item.Selected = expand;
                    }
                }
            }
        }

        #region Download

        /// <summary>
        /// Downloads remote files.
        /// </summary>
        /// <param name="items">The list of ListViewItem.</param>
        public void DoRemoteDownload(IList items)
        {
            AbstractFileInfo[] fileList = BuildFileList(items);
            if (fileList == null)
                return;

            _controller.DoRemoteDownload(fileList);
        }

        private void DoRemoteDownload()
        {
            DoRemoteDownload(lvwRemote.SelectedItems);
        }

        #endregion

        #region List View Event Handlers

        private void lvwRemote_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            e.CancelEdit = !(DoRemoteRename(e.Label));
        }

        private void UpdateRemoteListViewSorter()
        {
            switch (_lastRemoteColumnToSort)
            {
                case 0:
                    lvwRemote.ListViewItemSorter = new ListViewItemNameComparer(_lastRemoteSortOrder, _folderIconIndex, FolderLinkImageIndex);
                    break;
                case 1:
                    lvwRemote.ListViewItemSorter = new ListViewItemSizeComparer(_lastRemoteSortOrder, _folderIconIndex, FolderLinkImageIndex);
                    break;
                case 2:
                    lvwRemote.ListViewItemSorter = new ListViewItemDateComparer(_lastRemoteSortOrder, _folderIconIndex, FolderLinkImageIndex);
                    break;
                case 3:
                    lvwRemote.ListViewItemSorter = new ListViewItemPermissionsComparer(_lastRemoteSortOrder, _folderIconIndex, FolderLinkImageIndex);
                    break;
            }

            lvwRemote.ListViewItemSorter = null;
        }

        private void lvwRemote_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvwRemote.Items.Count == 0)
                return;

            ListViewItem cdup = lvwRemote.Items[0].ImageIndex == UpFolderImageIndex ? lvwRemote.Items[0] : null;
            if (cdup != null)
                lvwRemote.Items.Remove(cdup);

            SortOrder sortOrder;
            if (_lastRemoteColumnToSort == e.Column)
            {
                sortOrder = _lastRemoteSortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
                sortOrder = SortOrder.Ascending;

            _lastRemoteColumnToSort = e.Column;
            _lastRemoteSortOrder = sortOrder;

            UpdateRemoteListViewSorter();

            lvwRemote.ListViewItemSorter = null;
            if (cdup != null)
                lvwRemote.Items.Insert(0, cdup);
        }

        private void lvwRemote_DoubleClick(object sender, EventArgs e)
        {
            if (lvwRemote.SelectedItems.Count == 0)
                return;

            if (lvwRemote.SelectedItems[0].ImageIndex == UpFolderImageIndex) // Arrow up
                _controller.DoRemoteChangeDirectory("..");
            else if (lvwRemote.SelectedItems[0].ImageIndex == _folderIconIndex) // Folder
                _controller.DoRemoteChangeDirectory(lvwRemote.SelectedItems[0].Text);
            else if (lvwRemote.SelectedItems[0].ImageIndex == FolderLinkImageIndex) // Folder Link
                _controller.DoRemoteChangeDirectory(GetItemFullName(lvwRemote.SelectedItems[0]));
            else
            {
                DoRemoteDownload();
            }
        }

        private void lvwRemote_KeyDown(object sender, KeyEventArgs e)
        {
            if (lvwRemote.SelectedItems.Count == 0)
                return;

            ListViewItem lvi;

            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.Back:
                    _controller.DoRemoteChangeDirectory("..");
                    break;

                case System.Windows.Forms.Keys.Delete:
                    DoRemoteDelete();
                    break;

                case Keys.F2:
                    if (lvwRemote.SelectedItems.Count > 0 && lvwRemote.SelectedItems[0].ImageIndex > UpFolderImageIndex)
                    {
                        lvwRemote.SelectedItems[0].BeginEdit();
                    }
                    break;

#if FTP
                case Keys.F9:
                    ComponentPro.Net.Ftp ftp = _controller.Client as ComponentPro.Net.Ftp;
                    if (e.Alt && e.Control && ftp != null)
                    {
                        if (ftp.TransferMode == FtpTransferMode.ZlibCompressed)
                        {
                            ftp.TransferMode = FtpTransferMode.Stream;
                            MessageBox.Show("ModeZ deactivated", Messages.MessageTitle);
                        }
                        else
                        {
                            ftp.TransferMode = FtpTransferMode.ZlibCompressed;
                            MessageBox.Show("ModeZ activated", Messages.MessageTitle);
                        }
                    }
                    break;
#endif

                case Keys.Enter:
                    if (lvwRemote.SelectedItems.Count > 0)
                    {
                        lvi = lvwRemote.SelectedItems[0];
                        if (lvi.ImageIndex == _folderIconIndex || lvi.ImageIndex == UpFolderImageIndex || lvi.ImageIndex == FolderLinkImageIndex)
                        {
                            string dir = lvwRemote.SelectedItems[0].Text;
                            _controller.DoRemoteChangeDirectory(dir);
                        }
                        else
                        {
                            DoRemoteDownload(lvwRemote.SelectedItems);
                        }
                    }
                    break;
            }
        }

        private void txtRemoteDir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter
            {
                _controller.DoRemoteChangeDirectory(txtRemoteDir.Text);
            }
        }

        private void lvwRemote_DragDrop(object sender, DragEventArgs e)
        {
            if (DragAndDropListView.IsValidDragItem(e))
            {
                DragItemData data = (DragItemData)e.Data.GetData(typeof(DragItemData));
                if (data.ListView == lvwLocal)
                {
                    AbstractFileInfo[] list = BuildFileList(data.DragItems);

                    _controller.DoLocalUpload(list);
                }
            }
        }

        #endregion

        #region Context Menu Event handlers

        private void mnuPopRename_Click(object sender, EventArgs e)
        {
            lvwRemote.SelectedItems[0].BeginEdit();
        }

        private void mnuPopMkdir_Click(object sender, EventArgs e)
        {
            DoRemoteMakeDir();
        }

        private void mnuPopDelete_Click(object sender, EventArgs e)
        {
            DoRemoteDelete();
        }

        private void mnuPopRetrieve_Click(object sender, EventArgs e)
        {
            DoRemoteDownload();
        }

        void mnuPopMove_Click(object sender, System.EventArgs e)
        {
            DoRemoteMove();
        }

        private void mnuPopView_Click(object sender, EventArgs e)
        {
            DoRemoteView(lvwRemote.SelectedItems[0]);
        }

        private void mnuPopRefresh_Click(object sender, EventArgs e)
        {
            _controller.RefreshRemoteList();
        }

        private void mnuSynchronize_Click(object sender, EventArgs e)
        {
            DoSynchronize();
        }

        string _lastCommand = string.Empty; // Save the last command.
        private void mnuPopExecuteCommand_Click(object sender, EventArgs e)
        {
#if FTP
            ExecCommand dlg = new ExecCommand();
            dlg.Command = _lastCommand;
            // Show the command prompt dialog.
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            _controller.ExecCommand(dlg.Command);
#endif
        }

        private void mnuPopGetTimeDiff_Click(object sender, EventArgs e)
        {
            _controller.GetTimeDiff();
        }

        private void mnuPopResumeDownload_Click(object sender, EventArgs e)
        {
            DoRemoteResumeDownload(lvwRemote.SelectedItems);
        }

        private void mnuPopCalcTotalSize_Click(object sender, EventArgs e)
        {
            AbstractFileInfo[] files = BuildFileList(lvwRemote.SelectedItems);

            _controller.GetItemsSize(files);
        }

        private void mnuPopDeleteMultipleFiles_Click(object sender, EventArgs e)
        {
            DoRemoteDeleteMultipleFiles();
        }

        private void remoteContextMenu_Popup(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool connected = _controller.State == ConnectionState.Ready && Ready;

            ListViewItem selectedItem;
            if (connected && lvwRemote.SelectedItems.Count > 0 &&
                                         lvwRemote.SelectedItems[0].ImageIndex != UpFolderImageIndex)
                selectedItem = lvwRemote.SelectedItems[0];
            else
                selectedItem = null;

            bool selected = connected && (lvwRemote.SelectedItems.Count > 1 || selectedItem != null);
            bool isFile = selectedItem != null && selectedItem.ImageIndex != _folderIconIndex && selectedItem.ImageIndex != FolderLinkImageIndex;

            mnuPopRename.Enabled = selectedItem != null;
            mnuPopDelete.Enabled = selected;
            mnuPopDeleteMultipleFiles.Enabled = selected;
            mnuPopMove.Enabled = selected;
            mnuPopMkdir.Enabled = connected;
            mnuPopRetrieve.Enabled = selected;
            mnuPopView.Enabled = isFile;
            mnuPopRefresh.Enabled = connected;
            mnuPopSynchronize.Enabled = connected;
            mnuPopProperties.Enabled = selectedItem != null;
            mnuPopCalcTotalSize.Enabled = selected;
            mnuPopExecuteCommand.Enabled = connected;
            mnuPopGetTimeDiff.Enabled = connected;
            mnuPopResumeDownload.Enabled = isFile || lvwRemote.SelectedItems.Count > 1;
            mnuPopSelectGroup.Enabled = connected;
            mnuPopUnselectGroup.Enabled = connected;
        }

        private void mnuPopProperties_Click(object sender, EventArgs e)
        {
            propertiesToolStripMenuItem_Click(null, null);
        }

        private void mnuPopSelectGroup_Click(object sender, EventArgs e)
        {
            DoRemoteExpandSelection(true);
        }

        private void mnuPopUnselectGroup_Click(object sender, EventArgs e)
        {
            DoRemoteExpandSelection(false);
        }

        private void lvwRemote_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (lvwRemote.Items[e.Item].ImageIndex == UpFolderImageIndex)
                e.CancelEdit = true;
        }

        #endregion

        #endregion

        #endregion
    }
}