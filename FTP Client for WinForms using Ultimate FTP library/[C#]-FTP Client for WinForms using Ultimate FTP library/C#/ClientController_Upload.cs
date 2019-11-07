using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ComponentPro;
using ComponentPro.IO;

namespace ClientSample
{
    partial class ClientController
    {
        public
#if Framework4_5 && ASYNC
        async
#endif
        void DoLocalUpload(AbstractFileInfo[] files)
        {
            if (_state != ConnectionState.Ready)
                return;

            EnableProgress(true);

            bool showProgress = _settings.Get<bool>(SettingInfo.ShowProgressWhileTransferring);

            TransferOptions opt = new TransferOptions(showProgress, RecursionMode.RecurseIntoAllSubFolders, true, (SearchCondition)null, FileExistsResolveAction.Confirm, SymlinksResolveAction.Confirm);

#if Framework4_5 || !ASYNC    
            try
            {
                FileSystemTransferStatistics stat;
#if Framework4_5
                stat = await client.UploadFilesAsync(_currentLocalDirectory, files, _currentDirectory, opt);
#else
                stat = client.UploadFiles(_currentLocalDirectory, files, _currentDirectory, opt);
#endif
                ShowStatistics(stat, "upload");
            }
            catch (Exception ex)
            {
                if (!HandleException(ex))
                    return;
            }

            EnableProgress(false);
            RefreshRemoteList();

#else
            _client.UploadFilesAsync(_currentLocalDirectory, files, _currentDirectory, opt);
#endif
        }

        void ShowStatistics(FileSystemTransferStatistics s, string direction)
        {
            if (s == null)
                throw new ArgumentNullException("s", "Statistics parameter is null.");

            if (s.FilesTransferred > 0)
            {
                _view.WriteLine(string.Format("{0} file(s) {4}ed in {3} second(s) - total size: {1} - {2} / second",
                s.FilesTransferred, Util.FormatSize(s.TotalBytes),
                Util.FormatSize(s.BytesPerSecond), s.ElapsedTime.TotalSeconds, direction),
                RichTextBoxTraceListener.TextColorInfo);
                _view.WriteLine(string.Format("Started time: {0}, ended time: {1}", s.Started.ToLocalTime(), s.Ended.ToLocalTime()), RichTextBoxTraceListener.TextColorInfo);
            }
        }

        /// <summary>
        /// Handles the client's UploadFilesCompleted event.
        /// </summary>
        /// <param name="sender">The client object.</param>
        /// <param name="e">The event arguments.</param>
        void client_UploadFilesCompleted(object sender, ExtendedAsyncCompletedEventArgs<FileSystemTransferStatistics> e)
        {
            if (e.Error != null)
            {
                if (!HandleException(e.Error))
                    return;
            }
            else
            {
                ShowStatistics(e.Result, "upload");
            }

            EnableProgress(false);
            RefreshRemoteList();
        }

#if FTP
        public void DoLocalUploadUnique(string localFile)
        {
            ((ClientSample.Ftp.FtpClientPlugin)_clientPlugin).DoLocalUploadUnique(localFile);
        }
#endif

        public void DoLocalResumeUpload(AbstractFileInfo[] files)
        {
            EnableProgress(true);
            try
            {
                for (int i = 0; i < files.Length; i++)
                {
                    if (_aborting)
                        break;

                    AbstractFileInfo localFile = files[i];

                    if (localFile.IsFile)
                    {
                        // Upload a single file.
                        long result = _client.ResumeUploadFile(localFile.FullName, localFile.Name);

                        if (files.Length == 1)
                        {
                            if (result == -1)
                               _view.ShowMessage("Remote file size is greater than the local file size");
                            else if (result == 0)
                               _view.ShowMessage("Remote file size is equal to the local file size");
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
            RefreshRemoteList();
        }

        public void GetTimeDiff()
        {
            EnableProgress(true);

            try
            {
                // Get the time difference.
                TimeSpan ts = _client.GetServerTimeDifference();

                _view.ShowMessage(string.Format("The time difference between the client and server: {0}", ts));
            }
            catch (Exception exc)
            {
                HandleException(exc);
            }
            finally
            {
                EnableProgress(false);
            }
        }
    }
}