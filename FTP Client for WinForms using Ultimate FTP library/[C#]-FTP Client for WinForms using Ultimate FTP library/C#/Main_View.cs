using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using ComponentPro.IO;
using System.Windows.Forms;
using ComponentPro.Net;

namespace ClientSample
{
    partial class Main
    {
        public TraceListener GetLogger()
        {
            return new RichTextBoxTraceListener(txtLog);
        }

        void IClientView.UpdateProgress(FileSystemProgressEventArgs e, bool smallProgress, bool totalProgress)
        {
            if (smallProgress)
                progressBar.Value = (int) e.Percentage;
            if (totalProgress)
                progressBarTotal.Value = (int)e.TotalPercentage;

            Application.DoEvents();
        }
        void IClientView.UpdateStatus(string text)
        {
            status.Text = text;
        }

        int _enabled;
        /// <summary>
        /// Enables/Disables the dialog. In disabled state, cursor is WaitCursor (an hourglass shape), menus and toolbar are disabled.
        /// </summary>
        /// <param name="enable"></param>
        public void EnableView(bool enable)
        {
            if (enable)
            {
                if (_enabled > 0)
                    _enabled--;
            }
            else
                _enabled++;

            if (_enabled == 1)
            {
                Cursor = Cursors.WaitCursor;
                toolbarMain.Enabled = false;
                menuStrip.Enabled = false;
            }
            else if (_enabled == 0)
            {
                Cursor = Cursors.Default;
                toolbarMain.Enabled = true;
                menuStrip.Enabled = true;
            }   
        }

        public void EnableLogin(LoginEnableState enable)
        {
            tsbLogin.Enabled = loginToolStripMenuItem.Enabled = enable == LoginEnableState.LoginEnabled; 
            tsbLogin.Visible = enable == LoginEnableState.LoginDisabled || enable == LoginEnableState.LoginEnabled;

            tsbLogout.Enabled = loginToolStripMenuItem.Enabled = enable == LoginEnableState.LogoutEnabled;
            tsbLogout.Visible = enable == LoginEnableState.LogoutDisabled || enable == LoginEnableState.LogoutEnabled;

            settingsToolStripMenuItem.Enabled = tsbSettings.Enabled = enable == LoginEnableState.LoginEnabled ||
                                             enable == LoginEnableState.LogoutEnabled;

            loginToolStripMenuItem.Text = enable == LoginEnableState.LogoutDisabled || enable == LoginEnableState.LogoutEnabled ? "&Disconnect" : "&Connect...";
            loginToolStripMenuItem.Enabled = enable == LoginEnableState.LoginEnabled ||
                                             enable == LoginEnableState.LogoutEnabled;

            if (enable == LoginEnableState.LoginEnabled)
            {
                lvwRemote.Items.Clear();
            }

            txtRemoteDir.Enabled = enable == LoginEnableState.LogoutEnabled;

            exitToolStripMenuItem.Enabled = enable == LoginEnableState.LogoutEnabled || enable == LoginEnableState.LoginEnabled;
            // Enable/disable the Close button.
            Util.EnableCloseButton(this, exitToolStripMenuItem.Enabled);

            if (enable == LoginEnableState.LoginEnabled || enable == LoginEnableState.LogoutEnabled)
            {
                EnableProgress(false);
                EnableButtons();
            }

            _enabled = 0;
        }

        public bool AskYesNo(string message)
        {
            return MessageBox.Show(
                        message,
                        Messages.MessageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    System.Windows.Forms.DialogResult.Yes;
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        public void ShowError(Exception ex)
        {
            Util.ShowError(ex);
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public string AskForPassword(string title)
        {
            PasswordPrompt dlg = new PasswordPrompt(title);
            if (dlg.ShowDialog() == DialogResult.OK)
                return dlg.Password;

            return null;
        }

        public void UpdateRemotePath(string path)
        {
            txtRemoteDir.Text = path;
        }

        public void UpdateLocalPath(string path)
        {
            txtLocalDir.Text = path;
        }

        #region Remote list

        public void ListRemoteFiles(List<ListItemInfo> viewList)
        {
            ListFiles(viewList, lvwRemote, false);
        }

        #endregion

        public void ListFiles(List<ListItemInfo> viewList, ListView listView, bool local)
        {
            ListViewItem item;
            // Clear the list.
            listView.Items.Clear();

            for (int i = 0; i < viewList.Count; i++)
            {
                ListItemInfo listitem = viewList[i];
                AbstractFileInfo f = listitem.FileInfo;

                if (f.IsDirectory)
                {
                    item = listView.Items.Add(f.Name, _folderIconIndex);

                    item.SubItems.Add("");
                }
                else
                {
                    if (listitem.LinkedFile != null)
                        item = listView.Items.Add(f.Name, listitem.LinkedFile.IsDirectory ? FolderLinkImageIndex : SymlinkImageIndex);
                    else
                        item = listView.Items.Add(f.Name, SetFileIcon(Path.Combine(txtLocalDir.Text, f.Name)));

                    item.SubItems.Add(Util.FormatSize(f.Length));
                }

                if (f.LastWriteTime != DateTime.MinValue)
                    item.SubItems.Add(f.LastWriteTime.ToString());
                item.SubItems.Add(listitem.Permissions);
                item.Tag = listitem;
            }

            if (local)
                UpdateLocalListViewSorter();
            else
                UpdateRemoteListViewSorter();

            if (viewList.Count > 0)
                listView.Items[0].Selected = true;
        }

        #region Local List

        public void ListLocalFiles(List<ListItemInfo> viewList)
        {
            ListFiles(viewList, lvwLocal, true);
        }

        #endregion
    }
}
