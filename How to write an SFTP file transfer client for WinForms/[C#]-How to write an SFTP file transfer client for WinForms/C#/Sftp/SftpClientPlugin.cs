using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using ClientSample.Sftp;
using ComponentPro;
using ComponentPro.IO;
using ComponentPro.Net;

namespace ClientSample.Sftp
{
    class SftpClientPlugin : IClientPlugin
    {
        private ClientController _controller;
        private ComponentPro.Net.Sftp _client;
        private IClientView _view;
        private SettingInfoBase _loginSettings;

        public SftpClientPlugin(IClientView view, ClientController clientController, SettingInfoBase loginSettings)
        {
            _view = view;
            _controller = clientController;
            _loginSettings = loginSettings;
        }

        public IRemoteFileSystem Create()
        {
            ComponentPro.Net.Sftp client = new ComponentPro.Net.Sftp();

            client.SetMultipleFilesAttributesCompleted += client_SetMultipleFilesAttributesCompleted;
            client.HostKeyVerifying += client_CheckingFingerprint;

            _client = client;

            return client;
        }
        
        void client_SetMultipleFilesAttributesCompleted(object sender, ExtendedAsyncCompletedEventArgs<FileSystemTransferStatistics> e)
        {
            if (e.Error != null)
            {
                if (!_controller.HandleException(e.Error))
                    return;
            }

            _controller.RefreshRemoteList();
            _controller.EnableProgress(false);
        }

        public void Connect()
        {
            _client.ConnectAsync(_loginSettings.Get<string>(LoginInfo.ServerName), _loginSettings.Get<int>(LoginInfo.ServerPort));
        }

        public bool ShouldReconnect(Exception exc)
        {
            SftpException fe = exc as SftpException;
            SocketException se;

            if (fe != null)
            {
                if (fe.Status == SftpExceptionStatus.ConnectionClosed)
                {
                    return true;
                }
            }
            else
            {
                se = exc as SocketException;
                if (
                    (se != null && se.ErrorCode == 10053) || // Connection was aborted by the software
                    exc.Message == "Not connected to the server."
                    )
                {
                    return true;
                }
            }

            return false;
        }

        public string GetPermissionsString(AbstractFileInfo f)
        {
            return ToPermissions(((SftpFileInfo)f).Permissions);
        }

        void IClientPlugin.OnAuthenticated()
        {
            
        }

        readonly Hashtable _acceptedKeys = new Hashtable();

        void client_CheckingFingerprint(object sender, ComponentPro.Net.HostKeyVerifyingEventArgs e)
        {
            string key = e.HostKey;
            if (_acceptedKeys.ContainsKey(key))
            {
                e.Accept = true;
                return;
            }

            UnknownHostKey dlg = new UnknownHostKey(_loginSettings.Get<string>(LoginInfo.ServerName), _loginSettings.Get<int>(LoginInfo.ServerPort), "ssh-" + e.HostKeyAlgorithm + " " + key);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.AlwaysAccept)
                {
                    // Add to the cache.
                    _acceptedKeys.Add(key, true);
                }

                e.Accept = true;
            }
        }

        public void ApplyLoginSettings(SettingInfoBase settings)
        {
            ComponentPro.Net.Sftp sftp = (ComponentPro.Net.Sftp)_client;

            string proxyServer = _loginSettings.Get<string>(LoginInfo.ProxyServer);
            int proxyPort = _loginSettings.Get<int>(LoginInfo.ProxyPort);

            if (!string.IsNullOrEmpty(proxyServer) && proxyPort > 0)
            {
                WebProxyEx proxy = new WebProxyEx();
                sftp.Proxy = proxy;

                proxy.Server = proxyServer;
                proxy.Port = proxyPort;
                proxy.UserName = _loginSettings.Get<string>(LoginInfo.ProxyUser);
                proxy.Password = _loginSettings.Get<string>(LoginInfo.ProxyPassword);
                proxy.Domain = _loginSettings.Get<string>(LoginInfo.ProxyDomain);
                proxy.ProxyType = _loginSettings.Get<ProxyType>(LoginInfo.ProxyType);
                proxy.AuthenticationMethod = _loginSettings.Get<ProxyHttpConnectAuthMethod>(LoginInfo.ProxyHttpAuthnMethod);
            }

            sftp.Config.CompressionEnabled = _loginSettings.Get<bool>(SftpLoginInfo.EnableCompression);
        }

        public void ApplySettings(SettingInfoBase settings)
        {
            if (settings.Get<int>(SftpSettingInfo.ServerOs) != 0)
                _client.ServerOs = (RemoteServerOs)(settings.Get<int>(SftpSettingInfo.ServerOs) - 1);
        }

        private static char GetPermissionChar(SftpFilePermissions p, SftpFilePermissions mask, char ch)
        {
            return (p & mask) == mask ? ch : '-';
        }

        /// <summary>
        /// Parses permissions from the given permissions string.
        /// </summary>
        /// <param name="p">The permissions string.</param>
        private static string ToPermissions(SftpFilePermissions p)
        {
            string permissions = Convert.ToString((int)p, 16).PadLeft(3, '0') + " ";

            permissions += GetPermissionChar(p, SftpFilePermissions.GroupExecute, 'x');
            permissions += GetPermissionChar(p, SftpFilePermissions.GroupRead, 'r');
            permissions += GetPermissionChar(p, SftpFilePermissions.GroupWrite, 'w');
            permissions += GetPermissionChar(p, SftpFilePermissions.OthersExecute, 'x');
            permissions += GetPermissionChar(p, SftpFilePermissions.OthersRead, 'r');
            permissions += GetPermissionChar(p, SftpFilePermissions.OthersWrite, 'w');
            permissions += GetPermissionChar(p, SftpFilePermissions.OwnerExecute, 'x');
            permissions += GetPermissionChar(p, SftpFilePermissions.OwnerRead, 'r');
            permissions += GetPermissionChar(p, SftpFilePermissions.OwnerWrite, 'w');

            return permissions;
        }

        public void Authenticate()
        {
            string privateKey = _loginSettings.Get<string>(SftpLoginInfo.PrivateKey);
            string userName = _loginSettings.Get<string>(LoginInfo.UserName);
            string password = _loginSettings.Get<string>(LoginInfo.Password);

            SecureShellPrivateKey key;

            if (string.IsNullOrEmpty(privateKey))
            {
                key = null;
            }
            else
            {
                string keypassword = _view.AskForPassword("Please provide password for the key");
                if (string.IsNullOrEmpty(password))
                {
                    _view.ShowError(Messages.NoPassword);
                    _controller.Disconnect();
                    return;
                }
                
                // try to load the key.
                try
                {
                    key = new SecureShellPrivateKey(privateKey, keypassword);
                }
                catch (Exception exc)
                {
                    Util.ShowError(exc);
                    _controller.Disconnect();
                    return;
                }
            }

            _client.AuthenticateAsync(userName, password, key);
        }

        public void DoSetFileAttributes(AbstractFileInfo[] files, SftpFileAttributes attr, bool recursive)
        {
            bool showProgress = _controller.Settings.Get<bool>(SettingInfo.ShowProgressWhileDeleting);

            _controller.EnableProgress(true);
#if Framework4_5 || !ASYNC
            try
            {
#if Framework4_5
                // Asynchronously set permissions of multiple files.
                await sftp.SetMultipleFilesPermissionsAsync(_currentDirectory, files, permissions, showProgress, recursive ? RecursionMode.RecurseIntoAllSubFolders : RecursionMode.None, null);
#else
                sftp.SetMultipleFilesPermissions(_currentDirectory, files, permissions, showProgress, recursive ? RecursionMode.RecurseIntoAllSubFolders : RecursionMode.None, null);
#endif
            }
            catch (Exception ex)
            {
                if (!HandleException(exc))
                    return;
            }

            RefreshRemoteList();
            EnableProgress(false);
#else
            _client.SetMultipleFilesAttributesAsync(_controller.CurrentRemoteDirectory, files, attr, showProgress, recursive ? RecursionMode.RecurseIntoAllSubFolders : RecursionMode.None, null);
#endif
        }

    }
}
