using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using ComponentPro;
using ComponentPro.Diagnostics;
using ComponentPro.IO;

namespace ClientSample
{
    /// <summary>
    /// Defines the connection state.
    /// </summary>
    enum ConnectionState
    {
        NotConnected,
        Connecting,
        Ready,
        Disconnecting,
        WrongServerType,
    }

    /// <summary>
    /// Represents the FTP or SFTP Client Controller
    /// </summary>
    partial class ClientController
    {
        #region ConnectionState

        #endregion

        /// <summary>
        /// Cancels the current operation.
        /// </summary>
        public void Cancel()
        {
            _client.Cancel();

            // Set aborting state = true.
            _aborting = true;
        }

        /// <summary>
        /// Changes the state.
        /// </summary>
        void SetState(ConnectionState state)
        {
            _state = state;
        }

        /// <summary>
        /// Initializes the client objects.
        /// </summary>
        /// <param name="serverType">0: Autodetect, 1: FTP, 2: SFTP</param>
        void InitClient(int serverType)
        {
            if (_client != null)
                _client.Disconnect();

#if FTP && SFTP
            if (serverType == 0)
            {
                int forcedServerType = _loginInfo.Get<int>(LoginInfo.ServerType);

                if (forcedServerType == 0)
                {
                    // Auto detect.
                    if (_loginInfo.Get<int>(LoginInfo.ServerPort) == 22)
                        serverType = 2;
                    else
                        serverType = 1;
                }
                else
                {
                    serverType = forcedServerType;
                }
            }

            if (serverType == 2)
            {
                _clientPlugin = new ClientSample.Sftp.SftpClientPlugin(_view, this, _loginInfo);
                _serverType = ServerProtocol.Sftp;
            }
            else
            {
                _clientPlugin = new ClientSample.Ftp.FtpClientPlugin(_view, this, _loginInfo);
                _serverType = ServerProtocol.Ftp;
            }
#elif FTP
            _clientPlugin = new ClientSample.Ftp.FtpClientPlugin(_view, this, _loginInfo);
            _serverType = ServerProtocol.Ftp;
#elif SFTP
            _clientPlugin = new ClientSample.Sftp.SftpClientPlugin(_view, this, _loginInfo);
            _serverType = ServerProtocol.Sftp;
#endif
            _client = _clientPlugin.Create();

#if !Framework4_5
            _client.ConnectCompleted += this.client_ConnectCompleted;
            _client.DisconnectCompleted += this.client_DisconnectCompleted;
            _client.TransferConfirm += this.client_TransferConfirm;
            _client.Progress += this.client_Progress;
            _client.AuthenticateCompleted += this.client_AuthenticateCompleted;
            _client.DownloadFilesCompleted += this.client_DownloadFilesCompleted;
            _client.SynchronizeCompleted += this.client_SynchronizeCompleted;
            _client.UploadFilesCompleted += this.client_UploadFilesCompleted;
            _client.ListDirectoryCompleted += this.client_ListDirectoryCompleted;
            _client.MoveFilesCompleted += this.client_MoveFilesCompleted;
            _client.DeleteFilesCompleted += client_DeleteFilesCompleted;
#endif
        }

        /// <summary>
        /// Determines whether the exception indicates that the connection should be reconnected.
        /// </summary>
        /// <param name="exc"></param>
        /// <returns>true if the caller can continue; otherwise is false.</returns>
        internal bool HandleException(Exception exc)
        {
            return HandleException(exc, true);
        }

        // returns true if the caller can continue; otherwise is false.
        internal bool HandleException(Exception exc, bool showError)
        {
            if (exc.InnerException != null)
                exc = exc.InnerException;

            FileSystemException foe = exc as FileSystemException;
            if (foe != null && foe.Status == FileSystemExceptionStatus.OperationCancelled)
            {
                return true;
            }

            if (_clientPlugin.ShouldReconnect(exc))
            {
                Reconnect();
                return false;
            }

            if (showError)
                _view.ShowError(exc);
            return true;
        }

        /// <summary>
        /// Reconnects after receiving an exception showing that the connection has been closed unexpectedly.
        /// </summary>
        private void Reconnect()
        {
            try
            {
                // Disconnect first.
                _client.Disconnect();
            }
            catch { }
            
            _reconnecting = true;

            DoConnect(0);
        }

        /// <summary>
        /// Connects to the server.
        /// </summary>
        public void DoConnect(int serverType)
        {
            InitClient(serverType);

            _client.Timeout = _settings.Get<int>(SettingInfo.Timeout) * 1000;
            _client.MaxDownloadSpeed = _settings.Get<int>(SettingInfo.Throttle);
            _client.MaxUploadSpeed = _settings.Get<int>(SettingInfo.Throttle);
            _client.TransferType = _settings.Get<bool>(SettingInfo.AsciiTransfer) ? FileTransferType.Ascii : FileTransferType.Binary;
            _client.ProgressInterval = _settings.Get<int>(SettingInfo.ProgressUpdateInterval);

            if (_loginInfo.Get<bool>(LoginInfo.Utf8Encoding))
                _client.Encoding = Encoding.UTF8;

            ApplySettings(_settings);
            ApplyLoginSettings(_loginInfo);

            // Disable login/connect view.
            _view.EnableLogin(LoginEnableState.LoginDisabled);

            SetState(ConnectionState.Connecting);

            if (XTrace.Listeners.Count == 0)
            {
                XTrace.Listeners.Add(_view.GetLogger());

#if LOGFILE
                // Add the UltimateConsoleTraceListener listener to write to Console.
                XTrace.Listeners.Add(new UltimateConsoleTraceListener());
                // Add the UltimateTextWriterTraceListener listener to write to a file.
                XTrace.Listeners.Add(new UltimateTextWriterTraceListener("log.log"));
#endif
            }

            // Set log level.
            XTrace.Level = _loginInfo.Get<TraceEventType>(LoginInfo.LogLevel);

            // Asynchronously connect to the server. ConnectCompleted event will be fired when the operation completes.
            _clientPlugin.Connect();
        }

        /// <summary>
        /// Closes the connection.
        /// </summary>
        public
#if Framework4_5 && ASYNC
        async
#endif
        void Disconnect()
        {
            if (_client == null)
                return;

            _state = ConnectionState.Disconnecting;

#if Framework4_5
            try
            {
#if !ASYNC
                client.Disconnect();
#else
                // Asynchronously disconnect.
                await client.DisconnectAsync();
#endif
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
            }

            ReEnableForm();
#else
            // Asynchronously disconnect.
            _client.DisconnectAsync();
#endif
        }

        void ReEnableForm()
        {
            _view.EnableLogin(LoginEnableState.LoginEnabled);
            _state = ConnectionState.NotConnected;
        }

        int _syncSavedRestoreState = -1;
        /// <summary>
        /// Synchronizes local and remote folders.
        /// </summary>
        public void DoSynchronize(bool remoteIsMaster)
        {
            EnableProgress(true);

            SyncOptions opt = new SyncOptions();
            opt.Recursive = _loginInfo.Get<RecursionMode>(LoginInfo.SyncRecursive);
            opt.SearchCondition = new NameSearchCondition(_loginInfo.Get<string>(LoginInfo.SyncSearchPattern));

            _syncSavedRestoreState = _client.RestoreFileProperties ? 1 : 0;
            _client.RestoreFileProperties = _loginInfo.Get<bool>(LoginInfo.SyncDateTime);

            switch (_loginInfo.Get<int>(LoginInfo.SyncMethod))
            {
                case 0:
                    opt.Comparer = FileComparers.FileLastWriteTimeComparer;
                    break;

                case 1:
                    opt.Comparer = _loginInfo.Get<bool>(LoginInfo.SyncResumability) ? FileComparers.FileContentComparerWithResumabilityCheck : FileComparers.FileContentComparer;
                    break;

                case 2:
                    opt.Comparer = FileComparers.FileNameComparer;
                    break;
            }

#if Framework4_5 || !ASYNC
            try
            {
#if !ASYNC
                // Asynchronously synchronize folders.
                client.SynchronizeAsync(txtRemoteDir.Text, txtLocalDir.Text, dlg.RemoteIsMaster, opt, dlg.RemoteIsMaster);
#else
                client.Synchronize(txtRemoteDir.Text, txtLocalDir.Text, dlg.RemoteIsMaster, opt);
#endif
            }
            catch (Exception ex)
            {
            }

            DoSynchronizePost(dlg.RemoteIsMaster);
#else
            // Asynchronously synchronize folders.
            _client.SynchronizeAsync(_currentDirectory, _currentLocalDirectory, remoteIsMaster, opt, remoteIsMaster);
#endif
        }

        void DoSynchronizePost(bool remoteIsMaster)
        {
            EnableProgress(false); 
            
            if (remoteIsMaster)
                RefreshLocalList();
            else
                RefreshRemoteList();

            if (_syncSavedRestoreState != -1)
            {
                _client.RestoreFileProperties = _syncSavedRestoreState == 1;
                _syncSavedRestoreState = -1;
            }
        }

#if !Framework4_5
        /// <summary>
        /// Handles the client's SynchronizeCompleted event.
        /// </summary>
        /// <param name="sender">The Ftp object.</param>
        /// <param name="e">The event arguments.</param>
        void client_SynchronizeCompleted(object sender, AsyncCompletedEventArgs e)
        {
            bool remoteIsMaster = (bool)e.UserState;

            if (e.Error != null)
            {
                if (!HandleException(e.Error))
                    return;
            }

            DoSynchronizePost(remoteIsMaster);
        }
        
        void client_MoveFilesCompleted(object sender, ExtendedAsyncCompletedEventArgs<FileSystemTransferStatistics> e)
        {
            if (e.Error != null)
            {
                if (!HandleException(e.Error))
                    return;
            }

            RefreshRemoteList();

            EnableProgress(false);
        }

        void client_DeleteFilesCompleted(object sender, ComponentPro.ExtendedAsyncCompletedEventArgs<FileSystemTransferStatistics> e)
        {
            if (e.Error != null)
            {
                if (!HandleException(e.Error))
                    return;
            }

            EnableProgress(false);
            RefreshRemoteList();
        }

        private void client_TransferConfirm(object sender, TransferConfirmEventArgs e)
        {
            _view.AskOverwrite(e);
        }

        /// <summary>
        /// Handles the client's DisconnectCompleted event.
        /// </summary>
        /// <param name="sender">The Ftp object.</param>
        /// <param name="e">The event arguments.</param>
        private void client_DisconnectCompleted(object sender, AsyncCompletedEventArgs e)
        {
            _client = null;
            _clientPlugin = null;

            if (e.Error != null)
            {
                _view.ShowError(e.Error);
            }

            ReEnableForm();
        }        

        /// <summary>
        /// Handles the client's ConnectCompleted event.
        /// </summary>
        /// <param name="sender">The Ftp object.</param>
        /// <param name="e">The event arguments.</param>
        private void client_ConnectCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
#if FTP && SFTP
                string msg = e.Error.InnerException != null ? e.Error.InnerException.Message : e.Error.Message;
                int serverKind = 0;

                if (msg.IndexOf("connect to an FTP or FTP/SSL") != -1)
                    serverKind = 1;
                else if (msg.IndexOf("connect to an SSH server") != -1)
                    serverKind = 2;
                
                if (serverKind != 0)
                {
                    // This might be an FTP or SFTP server.
                    // Indicate that the client need to connect using a different protocol.
                    DoConnect(serverKind);
                }
                else
                {
                    Util.ShowError(e.Error);
                    Disconnect();
                }
#else
                Util.ShowError(e.Error);
                Disconnect();
#endif
                return;
            }

            if (_state == ConnectionState.Disconnecting)
            {
                Disconnect();
                return;
            }

            DoLogin();
        }

        /// <summary>
        /// Handles the client's AuthenticateCompleted event.
        /// </summary>
        /// <param name="sender">The Ftp object.</param>
        /// <param name="e">The event arguments.</param>
        private void client_AuthenticateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Util.ShowError(e.Error);
                Disconnect();
                return;
            }

            if (_state == ConnectionState.Disconnecting)
            {
                Disconnect();
                return;
            }

            DoAuthenticatePost();
        }
#endif

        void DoLogin()
        {
            _clientPlugin.Authenticate();
        }

        protected virtual void DoAuthenticatePost()
        {
            // Notify the plugin that the user has been authenticated.
            _clientPlugin.OnAuthenticated();

            try
            {
                _state = ConnectionState.Ready;

                if (!_reconnecting)
                {
                    _currentDirectory = _loginInfo.Get<string>(LoginInfo.RemoteDir);
                }
                else
                    _reconnecting = false;

                if (_currentDirectory.Length == 0) // Empty means default user's folder.
                {
                    // Get current directory.
                    _currentDirectory = _client.GetCurrentDirectory();
                }
                else
                    _client.SetCurrentDirectory(_currentDirectory);
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
                Disconnect();
                return;
            }

            // Update the remote dir text box.
            _view.UpdateRemotePath(_currentDirectory);

            // Allow disconnect.
            _view.EnableLogin(LoginEnableState.LogoutEnabled);

            // Show remote files.
            RefreshRemoteList();
        }
    }
}