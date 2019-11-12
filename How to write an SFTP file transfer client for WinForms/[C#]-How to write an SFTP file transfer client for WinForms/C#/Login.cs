using System;
using System.Diagnostics;
using System.Windows.Forms;
using ClientSample.Sftp;
using ComponentPro.Net;

#if !FTP
using FtpProxyType = ComponentPro.Net.ProxyType;
using FtpProxyHttpConnectAuthMethod = ComponentPro.Net.ProxyHttpConnectAuthMethod;
#endif

namespace ClientSample
{
    /// <summary>
    /// Represents the Login form.
    /// </summary>
    public partial class Login : Form
    {
        private readonly SettingInfoBase _info;
        private readonly SiteInfo[] _sites;

        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the form base on the provided LoginInfo that is loaded from the Registry.
        /// </summary>
        /// <param name="s">The LoginInfo object.</param>
        public Login(SettingInfoBase s)
        {
            InitializeComponent();

            _info = s;

            txtServer.Text = s.Get<string>(LoginInfo.ServerName);
            txtPort.Text = s.Get<int>(LoginInfo.ServerPort).ToString();
            txtUserName.Text = s.Get<string>(LoginInfo.UserName);
            txtPassword.Text = s.Get<string>(LoginInfo.Password);
            txtRemoteDir.Text = s.Get<string>(LoginInfo.RemoteDir);
            txtLocalDir.Text = s.Get<string>(LoginInfo.LocalDir);
            
            chkUtf8Encoding.Checked = s.Get<bool>(LoginInfo.Utf8Encoding);

            txtProxyHost.Text = s.Get<string>(LoginInfo.ProxyServer);
            txtProxyPort.Text = s.Get<int>(LoginInfo.ProxyPort).ToString();
            txtProxyUser.Text = s.Get<string>(LoginInfo.ProxyUser);
            txtProxyPassword.Text = s.Get<string>(LoginInfo.ProxyPassword);
            txtProxyDomain.Text = s.Get<string>(LoginInfo.ProxyDomain);
            cbxProxyType.SelectedIndex = s.Get<int>(LoginInfo.ProxyType);
            cbxProxyMethod.SelectedIndex = s.Get<int>(LoginInfo.ProxyHttpAuthnMethod);

            cbxServerType.SelectedIndex = s.Get<int>(LoginInfo.ServerType);
#if !(FTP && SFTP)
            cbxServerType.Visible = false;
            lblProtocol.Visible = false;
#endif

#if FTP
#if !SFTP
            sftp.Visible = false;
#endif
            #region FTP
            chkPasv.Checked = s.Get<bool>(FtpLoginInfo.PasvMode);
            txtCertificate.Text = s.Get<string>(FtpLoginInfo.Certificate);
            cbxSec.SelectedIndex = s.Get<int>(FtpLoginInfo.SecurityMode);
            chkClearCommandChannel.Checked = s.Get<bool>(FtpLoginInfo.ClearCommandChannel);
            #endregion
#endif

#if SFTP
#if !FTP
            ftp.Visible = false;
            lblSec.Visible = false;
            cbxSec.Visible = false;
			
			// Remove FTP Proxy items.
			cbxProxyType.Items.RemoveAt(cbxProxyType.Items.Count - 1);
			cbxProxyType.Items.RemoveAt(cbxProxyType.Items.Count - 1);
			cbxProxyType.Items.RemoveAt(cbxProxyType.Items.Count - 1);
#endif
            #region SFTP
            chkCompress.Checked = s.Get<bool>(SftpLoginInfo.EnableCompression);
            txtPrivateKey.Text = s.Get<string>(SftpLoginInfo.PrivateKey);
            #endregion
#endif

            switch (s.Get<TraceEventType>(LoginInfo.LogLevel))
            {
                case TraceEventType.Error:
                    cbxLogLevel.SelectedIndex = 1;
                    break;

                case TraceEventType.Information:
                    cbxLogLevel.SelectedIndex = 2;
                    break;

                case TraceEventType.Verbose:
                    cbxLogLevel.SelectedIndex = 3;
                    break;

                case TraceEventType.Transfer:
                    cbxLogLevel.SelectedIndex = 4;
                    break;

                default: // None
                    cbxLogLevel.SelectedIndex = 0;
                    break;
            }

            _sites = SiteLoader.GetSites();

            if (_sites == null)
            {
                MessageBox.Show("FtpSites.xml not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            foreach (SiteInfo info in _sites)
            {
                cbxSites.Items.Add(info.Description);
            }
        }

        /// <summary>
        /// Handles the Login button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            int port;
            // Check port number.
            try
            {
                port = int.Parse(txtPort.Text);
            }
            catch (Exception exc)
            {
                Util.ShowError(exc, "Invalid Port");
                return;
            }
            if (port < 0 || port > 65535)
            {
                MessageBox.Show("Invalid port number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check server name.
            if (txtServer.Text.Length == 0)
            {
                MessageBox.Show("Host name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check proxy port.
            int proxyport;
            try
            {
                proxyport = int.Parse(txtProxyPort.Text);
            }
            catch (Exception exc)
            {
                Util.ShowError(exc, "Invalid Proxy Port");
                return;
            }
            if (proxyport < 0 || proxyport > 65535)
            {
                MessageBox.Show("Invalid port number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _info.Set(LoginInfo.ServerName, txtServer.Text);
            _info.Set(LoginInfo.ServerPort, int.Parse(txtPort.Text));
            _info.Set(LoginInfo.UserName, txtUserName.Text);
            _info.Set(LoginInfo.Password, txtPassword.Text);
            _info.Set(LoginInfo.RemoteDir, txtRemoteDir.Text);
            _info.Set(LoginInfo.LocalDir, txtLocalDir.Text);
            
            _info.Set(LoginInfo.Utf8Encoding, chkUtf8Encoding.Checked);

            _info.Set(LoginInfo.ProxyServer, txtProxyHost.Text);
            _info.Set(LoginInfo.ProxyPort, int.Parse(txtProxyPort.Text));
            _info.Set(LoginInfo.ProxyUser, txtProxyUser.Text);
            _info.Set(LoginInfo.ProxyPassword, txtProxyPassword.Text);
            _info.Set(LoginInfo.ProxyDomain, txtProxyDomain.Text);
            _info.Set(LoginInfo.ProxyType, cbxProxyType.SelectedIndex);
            _info.Set(LoginInfo.ProxyHttpAuthnMethod, cbxProxyMethod.SelectedIndex);

#if FTP
            #region FTP
            _info.Set(FtpLoginInfo.PasvMode, chkPasv.Checked);
            _info.Set(FtpLoginInfo.Certificate, txtCertificate.Text);
            _info.Set(FtpLoginInfo.SecurityMode, (SecurityMode) cbxSec.SelectedIndex);
            _info.Set(FtpLoginInfo.ClearCommandChannel, chkClearCommandChannel.Checked);
            #endregion
#endif

#if SFTP
            #region SFTP
            _info.Set(SftpLoginInfo.EnableCompression, chkCompress.Checked);
            _info.Set(SftpLoginInfo.PrivateKey, txtPrivateKey.Text);
            #endregion
#endif

            switch (cbxLogLevel.SelectedIndex)
            {
                case 0:
                    _info.Set(LoginInfo.LogLevel, 0);
                    break;

                case 1:
                    _info.Set(LoginInfo.LogLevel, (int)TraceEventType.Error);
                    break;

                case 2:
                    _info.Set(LoginInfo.LogLevel, (int)TraceEventType.Information);
                    break;

                case 3:
                    _info.Set(LoginInfo.LogLevel, (int)TraceEventType.Verbose);
                    break;

                case 4:
                    _info.Set(LoginInfo.LogLevel, (int)TraceEventType.Transfer);
                    break;
            }

            _info.Set(LoginInfo.ServerType, cbxServerType.SelectedIndex);

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Handles the LocalDirBrowse button's Click event.
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
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtLocalDir.Text = dlg.SelectedPath;
                }
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
            }
        }

        /// <summary>
        /// Handles the proxy type combobox's SelectedIndexChanged event.
        /// </summary>
        /// <param name="sender">The combobox</param>
        /// <param name="e">The event arguments.</param>
        private void cbxProxy_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool enable = cbxProxyType.SelectedIndex > 0;
#if FTP
            bool enableAuth = cbxProxyType.SelectedIndex != (int)FtpProxyType.Site && cbxProxyType.SelectedIndex != (int)FtpProxyType.Open; // User name and password are ignored with Site and FtpOpen proxy types.
#else
            bool enableAuth = true;
#endif

            cbxProxyMethod.Enabled = cbxProxyType.SelectedIndex == (int)FtpProxyType.HttpConnect; // Authentication method is available for HTTP Connect only.
            txtProxyDomain.Enabled = cbxProxyMethod.Enabled && cbxProxyMethod.SelectedIndex == (int)FtpProxyHttpConnectAuthMethod.Ntlm; // Domain is available for NTLM authentication method only.
            txtProxyUser.Enabled = enable && enableAuth;
            txtProxyPassword.Enabled = enable && enableAuth;
            txtProxyHost.Enabled = enable; // Proxy host and port are not available in NoProxy type.
            txtProxyPort.Enabled = enable;
        }

        /// <summary>
        /// Handles the CertBrowse button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnCertBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Select a certificate file";
                dlg.FileName = txtCertificate.Text;
                dlg.Filter = "All files|*.*";
                dlg.FilterIndex = 1;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtCertificate.Text = dlg.FileName;
                }
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
            }
        }

        private void cbxSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool enable = cbxSec.SelectedIndex > 0;
            chkClearCommandChannel.Enabled = enable;
            txtCertificate.Enabled = enable;
            btnCertBrowse.Enabled = enable;
        }

        private void cbxSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_sites != null)
            {
                SiteInfo info = _sites[cbxSites.SelectedIndex];

                txtServer.Text = info.Address;
                txtPort.Text = info.Port > 0 ? info.Port.ToString() : string.Empty;
                txtUserName.Text = info.UserName;
                txtPassword.Text = info.Password;
                cbxSec.SelectedIndex = info.Security;
            }
        }

        private void btnKeyBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Select a private key file";
                dlg.FileName = txtPrivateKey.Text;
                dlg.Filter = "All files|*.*";
                dlg.FilterIndex = 1;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtPrivateKey.Text = dlg.FileName;
                }
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
            }
        }
    }
}