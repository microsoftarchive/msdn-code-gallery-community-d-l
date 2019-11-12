using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ClientSample.Ftp.Security;
using ComponentPro;
using ComponentPro.IO;
using ComponentPro.Net;
using ComponentPro.Security.Certificates;

namespace ClientSample.Ftp
{
    class FtpClientPlugin : IClientPlugin
    {
        private ClientController _controller;
        private ComponentPro.Net.Ftp _client;
        private IClientView _view;
        private SettingInfoBase _loginSettings;

        public FtpClientPlugin(IClientView view, ClientController clientController, SettingInfoBase loginSettings)
        {
            _view = view;
            _controller = clientController;
            _loginSettings = loginSettings;
        }

        public IRemoteFileSystem Create()
        {
            ComponentPro.Net.Ftp client = new ComponentPro.Net.Ftp();

#if !Framework4_5
            client.SetMultipleFilesPermissionsCompleted += client_SetMultipleFilesPermissionsCompleted;
            client.UploadUniqueFileCompleted += client_UploadUniqueFileCompleted;
            client.CertificateRequired += client_CertificateRequired;
            client.CertificateReceived += client_CertificateReceived;
#endif

            _client = client;

            return _client;
        }
        
        /// <summary>
        /// Handles the client's SetMultipleFilesPermissionsCompleted event.
        /// </summary>
        /// <param name="sender">The Ftp object.</param>
        /// <param name="e">The event arguments.</param>
        void client_SetMultipleFilesPermissionsCompleted(object sender, ExtendedAsyncCompletedEventArgs<FileSystemTransferStatistics> e)
        {
            if (e.Error != null)
            {
                if (!_controller.HandleException(e.Error))
                    return;
            }

            _controller.RefreshRemoteList();
            _controller.EnableProgress(false);
        }

        public string GetPermissionsString(AbstractFileInfo f)
        {
            if (((FtpFileInfo)f).System == FtpFileOs.Unix)
                return ToPermissions(((FtpFileInfo)f).Permissions);
            else
                return "-";
        }

        void IClientPlugin.AuthenticatePost()
        {
            if (_loginSettings.Get<bool>(FtpLoginInfo.ClearCommandChannel) && _loginSettings.Get<FtpSecurityMode>(FtpLoginInfo.SecurityMode) != FtpSecurityMode.None)
            {
                ((ComponentPro.Net.Ftp)_client).ClearCommandChannel();
            }
        }

        public bool CanBeReconnected(Exception exc)
        {
            FtpException fe = exc as FtpException;
            System.Net.Sockets.SocketException se;

            if (fe != null)
            {
                if (fe.Status == FtpExceptionStatus.ConnectionClosed)
                {
                    return true;
                }
            }
            else
            {
                se = exc as System.Net.Sockets.SocketException;
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

        public void ApplyLoginSettings(SettingInfoBase settings)
        {
            ComponentPro.Net.Ftp ftp = (ComponentPro.Net.Ftp)_client;

            ftp.Passive = _loginSettings.Get<bool>(FtpLoginInfo.PasvMode);

            string proxyServer = _loginSettings.Get<string>(LoginInfo.ProxyServer);
            int proxyPort = _loginSettings.Get<int>(LoginInfo.ProxyPort);

            if (!string.IsNullOrEmpty(proxyServer) && proxyPort > 0)
            {
                FtpProxy proxy = new FtpProxy();
                ftp.Proxy = proxy;

                proxy.Server = proxyServer;
                proxy.Port = proxyPort;
                proxy.UserName = _loginSettings.Get<string>(LoginInfo.ProxyUser);
                proxy.Password = _loginSettings.Get<string>(LoginInfo.ProxyPassword);
                proxy.Domain = _loginSettings.Get<string>(LoginInfo.ProxyDomain);
                proxy.ProxyType = _loginSettings.Get<FtpProxyType>(LoginInfo.ProxyType);
                proxy.AuthenticationMethod = _loginSettings.Get<FtpProxyHttpConnectAuthMethod>(LoginInfo.ProxyHttpAuthnMethod);
            }
        }

        public void ApplySettings(SettingInfoBase settings)
        {
            ComponentPro.Net.Ftp client = (ComponentPro.Net.Ftp) _client;

            client.Config.KeepAliveDuringIdleInterval = settings.Get<int>(SettingInfo.KeepAlive);
            client.TransferMode = settings.Get<bool>(FtpSettingInfo.Compress) ? FtpTransferMode.ZlibCompressed : FtpTransferMode.Stream;
            client.Config.SendAbortCommand = settings.Get<OptionValue>(FtpSettingInfo.SendAborCommand);
            client.Config.SendTelnetInterruptSignal = settings.Get<bool>(FtpSettingInfo.SendAbortSignals);
            client.ChangeDirectoryBeforeFileOperation = settings.Get<bool>(FtpSettingInfo.ChangeDirBeforeTransfer);
            client.ChangeDirectoryBeforeListing = settings.Get<bool>(FtpSettingInfo.ChangeDirBeforeListing);
            client.Config.SmartPathResolving = settings.Get<bool>(FtpSettingInfo.SmartPath);
        }

        /// <summary>
        /// Returns all issues of the given certificate.
        /// </summary>
        private static string GetCertProblem(CertificateVerificationStatus status, int code, ref bool showAddTrusted)
        {
            switch (status)
            {
                case CertificateVerificationStatus.TimeNotValid:
                    return "Server's certificate has expired or is not valid yet.";

                case CertificateVerificationStatus.Revoked:
                    return "Server's certificate has been revoked.";

                case CertificateVerificationStatus.UnknownCA:
                    return "Server's certificate was issued by an unknown authority.";

                case CertificateVerificationStatus.RootNotTrusted:
                    showAddTrusted = true;
                    return "Server's certificate was issued by an untrusted authority.";

                case CertificateVerificationStatus.IncompleteChain:
                    return "Server's certificate does not chain up to a trusted root authority.";

                case CertificateVerificationStatus.Malformed:
                    return "Server's certificate is malformed.";

                case CertificateVerificationStatus.CNNotMatch:
                    return "Server hostname does not match the certificate.";

                case CertificateVerificationStatus.UnknownError:
                    return string.Format("Error {0:x} encountered while validating server's certificate.", code);

                default:
                    return status.ToString();
            }
        }

        void client_CertificateReceived(object sender, ComponentPro.Security.CertificateReceivedEventArgs e)
        {
            CertValidator dlg = new CertValidator();

            CertificateVerificationStatus status = e.Status;

            CertificateVerificationStatus[] values = (CertificateVerificationStatus[])Enum.GetValues(typeof(CertificateVerificationStatus));

            StringBuilder sbIssues = new StringBuilder();
            bool showAddTrusted = false;
            for (int i = 0; i < values.Length; i++)
            {
                // Matches the validation status?
                if ((status & values[i]) == 0)
                    continue;

                // The issue is processed.
                status ^= values[i];

                sbIssues.AppendFormat("{0}\r\n", GetCertProblem(values[i], e.ErrorCode, ref showAddTrusted));
            }

            dlg.Certificate = e.ServerCertificates[0];
            dlg.Issues = sbIssues.ToString();
            dlg.ShowAddToTrustedList = showAddTrusted;

            dlg.ShowDialog();

            e.AddToTrustedRoot = dlg.AddToTrustedList;
            e.Accept = dlg.Accepted;
        }

        private void client_CertificateRequired(object sender, ComponentPro.Security.CertificateRequiredEventArgs e)
        {
            string cert = _loginSettings.Get<string>(FtpLoginInfo.Certificate);
            
            // If the client cert file is specified.
            if (!string.IsNullOrEmpty(cert))
            {
                // Load Certificate.
                PasswordPrompt passdlg = new PasswordPrompt("Please provide password for certificate");
                // Ask for cert's passpharse
                if (passdlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    X509Certificate2 clientCert = new X509Certificate2(cert, passdlg.Password);
                    e.Certificates = new X509Certificate2Collection(clientCert);
                    return;
                }

                // Password has not been provided.
            }
            CertProvider dlg = new CertProvider();
            dlg.ShowDialog();
            // Get the selected certificate.
            e.Certificates = new X509Certificate2Collection(dlg.SelectedCertificate);
        }

        /// <summary>
        /// Parses permissions from the given permissions string.
        /// </summary>
        /// <param name="data">The permissions string.</param>
        private static string ToPermissions(FtpFilePermissions data)
        {
            return Convert.ToString((uint)data, 8) + "  " + FtpFileInfo.GetPermissionsString(data);
        }

        public void Connect()
        {
            _client.ConnectAsync(_loginSettings.Get<string>(LoginInfo.ServerName), _loginSettings.Get<int>(LoginInfo.ServerPort),
                                 _loginSettings.Get<FtpSecurityMode>(FtpLoginInfo.SecurityMode));
        }

        public void Authenticate()
        {
            // Asynchronously login.
            _client.AuthenticateAsync(_loginSettings.Get<string>(LoginInfo.UserName), _loginSettings.Get<string>(LoginInfo.Password));
        }

        public void DoSetFilePermissions(AbstractFileInfo[] files, string permissions, bool recursive)
        {
            bool showProgress = _controller.Settings.Get<bool>(SettingInfo.ShowProgressWhileDeleting);

            _controller.EnableProgress(true);
#if Framework4_5 || !ASYNC
            try
            {
#if Framework4_5
                // Asynchronously set permissions of multiple files.
                await client.SetMultipleFilesPermissionsAsync(_currentDirectory, files, permissions, showProgress, recursive ? RecursionMode.RecurseIntoAllSubFolders : RecursionMode.None, null);
#else
                client.SetMultipleFilesPermissions(_currentDirectory, files, permissions, showProgress, recursive ? RecursionMode.RecurseIntoAllSubFolders : RecursionMode.None, null);
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
            _client.SetMultipleFilesPermissionsAsync(_controller.CurrentRemoteDirectory, files, permissions, showProgress, recursive ? RecursionMode.RecurseIntoAllSubFolders : RecursionMode.None, null);
#endif
        }

        public void DoLocalUploadUnique(string localFile)
        {
            _controller.EnableProgress(true);

#if Framework4_5
            try
            {
                // Asynchronously upload unique the selected file.
                await client.UploadUniqueFileAsync(localFile);
            }
            catch (Exception ex)
            {
                if (!HandleException(e.Error))
                    return;
            }
#else
            // Asynchronously upload unique the selected file.
            _client.UploadUniqueFileAsync(localFile);
#endif
        }

        /// <summary>
        /// Handles the client's UploadUniqueCompleted event.
        /// </summary>
        /// <param name="sender">The Ftp object.</param>
        /// <param name="e">The event arguments.</param>
        private void client_UploadUniqueFileCompleted(object sender, ExtendedAsyncCompletedEventArgs<string> e)
        {
            if (e.Error != null)
            {
                if (!_controller.HandleException(e.Error))
                    return;
            }

            _controller.EnableProgress(false);
            _controller.RefreshRemoteList();
        }
    }
}
