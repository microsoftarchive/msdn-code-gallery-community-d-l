using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using ComponentPro;
using ComponentPro.IO;

namespace ClientSample
{
    partial class ClientController
    {
        public void DoRemoteDownload(AbstractFileInfo[] files)
        {
            if (_state != ConnectionState.Ready)
                return;

            EnableProgress(true);

            bool showProgress = _settings.Get<bool>(SettingInfo.ShowProgressWhileTransferring);

            TransferOptions opt = new TransferOptions(showProgress, RecursionMode.RecurseIntoAllSubFolders, true,
                (SearchCondition)null, FileExistsResolveAction.Confirm, SymlinksResolveAction.Confirm);

#if Framework4_5 || !ASYNC
            FileSystemTransferStatistics stat;
            try
            {
#if Framework4_5
                stat = await client.DownloadFilesAsync(_currentDirectory, fileList, _currentLocalDirectory, opt);
#else
                stat = client.DownloadFiles(_currentDirectory, fileList, _currentLocalDirectory, opt);
#endif
                ShowStatistics(stat, "download");
            }
            catch (Exception ex)
            {
                if (!HandleException(ex))
                    return;
            }            
            
            EnableProgress(false);
            RefreshLocalList();
#else
            _client.DownloadFilesAsync(_currentDirectory, files, _currentLocalDirectory, opt);
#endif
        }

        /// <summary>
        /// Handles the client's DownloadFilesCompleted event.
        /// </summary>
        /// <param name="sender">The client object.</param>
        /// <param name="e">The event arguments.</param>
        void client_DownloadFilesCompleted(object sender, ExtendedAsyncCompletedEventArgs<FileSystemTransferStatistics> e)
        {
            if (e.Error != null)
            {
                if (!HandleException(e.Error))
                    return;
            }
            else
                ShowStatistics(e.Result, "download");

            EnableProgress(false);
            RefreshLocalList();
        }

        public void DoRemoteResumeDownload(AbstractFileInfo[] files)
        {
            if (files == null)
                return;

            EnableProgress(true);
            try
            {
                for (int i = 0; i < files.Length; i++)
                {
                    if (_aborting)
                        break;

                    AbstractFileInfo remoteFile = files[i];

                    if (remoteFile.IsFile)
                    {
                        // Download a single file.
                        long result = _client.ResumeDownloadFile(remoteFile.Name, Path.Combine(_currentLocalDirectory, remoteFile.Name));

                        if (files.Length == 1)
                        {
                            if (result == -1)
                                _view.ShowMessage("Local file size is greater than the remote file size");
                            else if (result == 0)
                                _view.ShowMessage("Local file size is equal to the remote file size");
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                if (!HandleException(exc))
                    return;
            }

            EnableProgress(false);
            RefreshLocalList();
        }

        public void DoRemoteView(string name)
        {
            string tempFile = Util.GetTempFileName(name);
            string remoteFile = name;// GetRemoteFullPath(item.Text);

            EnableProgress(true);

            _client.DownloadFileCompleted += client_GetFileForViewingCompleted;
            _client.DownloadFileAsync(remoteFile, tempFile, tempFile);
        }

        /// <summary>
        /// Handles the client's DownloadFileCompleted event.
        /// </summary>
        /// <param name="sender">The Ftp object.</param>
        /// <param name="e">The event arguments.</param>
        private void client_GetFileForViewingCompleted(object sender, ExtendedAsyncCompletedEventArgs<long> e)
        {
            // Detach the event handler.
            _client.DownloadFileCompleted -= client_GetFileForViewingCompleted;

            bool aborted = false;

            if (e.Error != null)
            {
                if (!HandleException(e.Error))
                    return;

                aborted = Util.IsFileSystemOperationCancelled(e.Error);
            }

            // temporary file name is saved in the async state object.
            string tempFile = (string)e.UserState;

            DoRemoteViewPost(aborted, tempFile);
        }

        void DoRemoteViewPost(bool aborted, string tempFile)
        {
            EnableProgress(false);

            if (_state == ConnectionState.Disconnecting)
            {
                Disconnect();
                return;
            }

            if (!aborted)
            {
                try
                {
                    Process.Start("Notepad.exe", tempFile);
                }
                catch (Exception exc)
                {
                    _view.ShowError("Error:" + exc.Message);
                }
            }
        }
    }
}
