using System;
using ComponentPro.IO;

namespace ClientSample
{
    /// <summary>
    /// Defines client plugin.
    /// </summary>
    interface IClientPlugin
    {
        /// <summary>
        /// Create a new <see cref="IRemoteFileSystem"/> instance.
        /// </summary>
        IRemoteFileSystem Create();

        /// <summary>
        /// Connects to the server.
        /// </summary>
        void Connect();

        /// <summary>
        /// Authenticate the user.
        /// </summary>
        void Authenticate();

        /// <summary>
        /// This method is invoked when the user has been successfully authenticated.
        /// </summary>
        void OnAuthenticated();

        /// <summary>
        /// Checks to see if the specified exception indicates that the connection has been closed and the client should reconnect.
        /// </summary>
        /// <param name="ex">The recent exception.</param>
        /// <returns><c>true</c> to reconnect; otherwise <c>false</c>.</returns>
        bool ShouldReconnect(Exception ex);

        /// <summary>
        /// Gets platform-specific permission string.
        /// </summary>
        /// <param name="f">The remote file info.</param>
        /// <returns>The permission string</returns>
        string GetPermissionsString(AbstractFileInfo f);

        /// <summary>
        /// Applies the general settings.
        /// </summary>
        /// <param name="settings">The general settings.</param>
        void ApplySettings(SettingInfoBase settings);

        /// <summary>
        /// Applies the login settings.
        /// </summary>
        /// <param name="settings">The login settings.</param>
        void ApplyLoginSettings(SettingInfoBase settings);
    }

    /// <summary>
    /// Defines the server protocols
    /// </summary>
    enum ServerProtocol
    {
        /// <summary>
        /// FTP.
        /// </summary>
        Ftp,

        /// <summary>
        /// SFTP.
        /// </summary>
        Sftp
    }

    /// <summary>
    /// Represents the FTP or SFTP Client Controller
    /// </summary>
    partial class ClientController
    {
        protected IClientView _view;
        protected IRemoteFileSystem _client;
        protected IClientPlugin _clientPlugin;
        protected SettingInfoBase _loginInfo;
        protected SettingInfoBase _settings;

        /// <summary>
        /// Gets the current state.
        /// </summary>
        public ConnectionState State
        {
            get { return _state; }
        }

        /// <summary>
        /// Gets the login settings.
        /// </summary>
        public SettingInfoBase LoginSettings
        {
            get { return _loginInfo; }
        }

        /// <summary>
        /// Gets the general settings.
        /// </summary>
        public SettingInfoBase Settings
        {
            get { return _settings; }
        }

        /// <summary>
        /// Gets the protocol of the server.
        /// </summary>
        public ServerProtocol ServerType
        {
            get
            {
                return _serverType;
            }
        }

        /// <summary>
        /// Indicates whether the user has cancelled the current operation.
        /// </summary>
        public bool IsAborting
        {
            get { return _aborting; }
        }

        /// <summary>
        /// Gets the client object.
        /// </summary>
        public IRemoteFileSystem Client
        {
            get { return _client; }
        }

        /// <summary>
        /// Initializes the <see cref="ClientController"/>
        /// </summary>
        /// <param name="view">The <see cref="IClientView"/>.</param>
        /// <param name="loginSettings">The login settings.</param>
        /// <param name="settings">The general settings.</param>
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
            {
                _client.RestoreFileProperties = settings.Get<bool>(SettingInfo.RestoreFileProperties);
                _clientPlugin.ApplySettings(settings);
            }
        }

        public void ApplyLoginSettings(SettingInfoBase loginSettings)
        {
            if (_clientPlugin != null)
            {
                _clientPlugin.ApplyLoginSettings(loginSettings);
            }
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

        /// <summary>
        /// Displays progress information of the current operation.
        /// </summary>
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
        /// <summary>
        /// Executes a command on the server.
        /// </summary>
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
