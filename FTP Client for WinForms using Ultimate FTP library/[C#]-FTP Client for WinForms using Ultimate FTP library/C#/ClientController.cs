using System;
using System.Collections.Generic;
using System.Text;
using ComponentPro.IO;

namespace ClientSample
{
    interface IClientPlugin
    {
        IRemoteFileSystem Create();

        void Connect();
        void Authenticate();
        void AuthenticatePost();

        bool CanBeReconnected(Exception ex);

        string GetPermissionsString(AbstractFileInfo f);

        void ApplySettings(SettingInfoBase settings);
        void ApplyLoginSettings(SettingInfoBase settings);
    }

    enum ServerProtocol
    {
        Ftp,
        Sftp
    }

    partial class ClientController
    {
        protected IClientView _view;
        protected IRemoteFileSystem _client;
        protected IClientPlugin _clientPlugin;
        protected SettingInfoBase _loginInfo;
        protected SettingInfoBase _settings;

        public ConnectionState State
        {
            get { return _state; }
        }

        public SettingInfoBase LoginSettings
        {
            get { return _loginInfo; }
        }

        public SettingInfoBase Settings
        {
            get { return _settings; }
        }

        public ServerProtocol ServerType
        {
            get
            {
                return _serverType;
            }
        }

        public bool IsAborting
        {
            get { return _aborting; }
        }

        public IRemoteFileSystem Client
        {
            get { return _client; }
        }

        public ClientController(IClientView view, SettingInfoBase loginSettings, SettingInfoBase settings)
        {
            _view = view;
            _loginInfo = loginSettings;
            _settings = settings;

            _currentLocalDirectory = loginSettings.Get<string>(LoginInfo.LocalDir);
        }

        public void ApplySettings(SettingInfoBase settings)
        {
            if (_clientPlugin != null)
                _clientPlugin.ApplySettings(settings);
        }

        string GetSpeedInfo(string operation, FileSystemProgressEventArgs e)
        {
            if (e.BytesPerSecond != 0)
                return string.Format("{3} file {0}... {1}/sec {2} remaining",
                                          e.SourceFileInfo.Name, Util.FormatSize(e.BytesPerSecond),
                                          e.RemainingTime, operation);

            return string.Format("{1} file {0}...",
                                          e.SourceFileInfo.Name, operation);
        }

        internal void EnableProgress(bool enable)
        {
            _aborting = false;
            _view.EnableProgress(enable);
        }

        private void client_Progress(object sender, FileSystemProgressEventArgs e)
        {
            switch (e.State)
            {
                case TransferState.DeletingDirectory:
                    // It's about to delete a directory. To skip deleting this directory, simply set e.Skip = true.
                    _view.UpdateStatus(string.Format("Deleting directory {0}...", e.SourceFileSystem.GetFileName(e.SourcePath)));
                    if (_settings.Get<bool>(SettingInfo.ShowProgressWhileDeleting))
                        //progressBarTotal.Value = (int)e.TotalPercentage;                    
                        _view.UpdateProgress(e, false, true);
                    return;

                case TransferState.DeletingFile:
                    // It's about to delete a file. To skip deleting this file, simply set e.Skip = true.
                    _view.UpdateStatus(string.Format("Deleting file {0}...", e.SourceFileSystem.GetFileName(e.SourcePath)));
                    if (_settings.Get<bool>(SettingInfo.ShowProgressWhileDeleting))
                        //progressBarTotal.Value = (int)e.TotalPercentage;                    
                        _view.UpdateProgress(e, false, true);
                    return;

                case TransferState.SettingFileAttribute:
                    // It's about to setting attributes of a file. To skip this file, simply set e.Skip = true.
                    _view.UpdateStatus(string.Format("Setting attributes file {0}...", e.SourceFileSystem.GetFileName(e.SourcePath)));
                    if (_settings.Get<bool>(SettingInfo.ShowProgressWhileDeleting))
                        //progressBarTotal.Value = (int)e.TotalPercentage;
                        _view.UpdateProgress(e, false, true);
                    return;

                case TransferState.SettingFilePermission:
                    // It's about to setting attributes of a file. To skip this file, simply set e.Skip = true.
                    _view.UpdateStatus(string.Format("Setting permissions file {0}...", e.SourceFileSystem.GetFileName(e.SourcePath)));
                    if (_settings.Get<bool>(SettingInfo.ShowProgressWhileDeleting))
                        //progressBarTotal.Value = (int)e.TotalPercentage;
                        _view.UpdateProgress(e, false, true);
                    return;

                case TransferState.BuildingDirectoryStructure:
                    // It informs us that the directory structure has been prepared for the multiple file transfer.
                    _view.UpdateStatus("Building directory structure...");
                    break;

                #region Comparing File Events

                case TransferState.StartComparingFile:
                    // Source file and destination file are about to be compared.
                    // To skip comparing these files, simply set e.Skip = true.
                    // To override the comparison result, set the e.ComparionResult property.
                    _view.UpdateStatus(string.Format("Comparing file {0}...", System.IO.Path.GetFileName(e.SourcePath)));
                    _view.UpdateProgress(e, true, true);
                    break;

                case TransferState.Comparing:
                    // Source file and destination file are being compared.
                    _view.UpdateStatus(GetSpeedInfo("Comparing", e));
                    _view.UpdateProgress(e, true, true);
                    break;

                case TransferState.FileCompared:
                    // Source file and destination file have been compared.
                    // Comparison result is saved in the e.ComparisonResult property.
                    _view.UpdateProgress(e, true, true);
                    break;

                #endregion

                #region Uploading File Events

                case TransferState.StartUploadingFile:
                    // Source file (local file) is about to be uploaded. Destination file is the remote file.
                    // To skip uploading this file, simply set e.Skip = true.
                    _view.UpdateStatus(string.Format("Uploading file {0}...", System.IO.Path.GetFileName(e.SourcePath)));
                    _view.UpdateProgress(e, true, true);
                    break;

                case TransferState.Uploading:
                    // Source file is being uploaded to the remote server.
                    _view.UpdateStatus(GetSpeedInfo("Uploading", e));
                    _view.UpdateProgress(e, true, true);
                    break;

                case TransferState.FileUploaded:
                    // Source file has been uploaded.
                    _view.UpdateProgress(e, true, true);
                    break;

                #endregion

                #region Downloading File Events

                case TransferState.StartDownloadingFile:
                    // Source file (remote file) is about to be downloaded.
                    // To skip uploading this file, simply set e.Skip = true.
                    _view.UpdateStatus(string.Format("Downloading file {0}...", System.IO.Path.GetFileName(e.SourcePath)));
                    _view.UpdateProgress(e, true, true);
                    break;

                case TransferState.Downloading:
                    // Source file is being downloaded to the local disk.
                    _view.UpdateStatus(GetSpeedInfo("Downloading", e));
                    _view.UpdateProgress(e, true, true);
                    break;

                case TransferState.FileDownloaded:
                    // Remote file has been downloaded.
                    _view.UpdateProgress(e, true, true);
                    break;

                #endregion
            }
        }

#if FTP
        public bool ExecCommand(string command)
        {
            {
                try
                {
                    ((ComponentPro.Net.Ftp)_client).SendCommand(command);
                    ((ComponentPro.Net.Ftp)_client).ReadResponse();

                    if (command.StartsWith("cwd ", StringComparison.InvariantCultureIgnoreCase))
                    {
                        _currentDirectory = _client.GetCurrentDirectory();
                        _view.UpdateRemotePath(_currentDirectory);
                    }
                }
                catch (Exception exc)
                {
                    HandleException(exc);
                    return false;
                }
            }

            RefreshRemoteList();

            return true;
        }
#endif
    }
}
