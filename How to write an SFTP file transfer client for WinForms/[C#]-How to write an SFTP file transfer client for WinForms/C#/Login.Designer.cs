using System.Windows.Forms;

namespace ClientSample
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControlExt = new System.Windows.Forms.TabControl();
            this.loginPage = new System.Windows.Forms.TabPage();
            this.lblProtocol = new System.Windows.Forms.Label();
            this.cbxServerType = new System.Windows.Forms.ComboBox();
            this.sftp = new System.Windows.Forms.GroupBox();
            this.btnKeyBrowse = new System.Windows.Forms.Button();
            this.txtPrivateKey = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.chkCompress = new System.Windows.Forms.CheckBox();
            this.ftp = new System.Windows.Forms.GroupBox();
            this.chkClearCommandChannel = new System.Windows.Forms.CheckBox();
            this.lblCert = new System.Windows.Forms.Label();
            this.chkPasv = new System.Windows.Forms.CheckBox();
            this.btnCertBrowse = new System.Windows.Forms.Button();
            this.txtCertificate = new System.Windows.Forms.TextBox();
            this.cbxSites = new System.Windows.Forms.ComboBox();
            this.chkUtf8Encoding = new System.Windows.Forms.CheckBox();
            this.lblSites = new System.Windows.Forms.Label();
            this.btnLocalDirBrowse = new System.Windows.Forms.Button();
            this.txtLocalDir = new System.Windows.Forms.TextBox();
            this.lblLocalDir = new System.Windows.Forms.Label();
            this.txtRemoteDir = new System.Windows.Forms.TextBox();
            this.lblRemoteDir = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cbxSec = new System.Windows.Forms.ComboBox();
            this.lblFtpPassword = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblFtpUserName = new System.Windows.Forms.Label();
            this.proxyPage = new System.Windows.Forms.TabPage();
            this.txtProxyDomain = new System.Windows.Forms.TextBox();
            this.lblDomain = new System.Windows.Forms.Label();
            this.lblMethod = new System.Windows.Forms.Label();
            this.cbxProxyMethod = new System.Windows.Forms.ComboBox();
            this.txtProxyPort = new System.Windows.Forms.TextBox();
            this.lblProxyPort = new System.Windows.Forms.Label();
            this.txtProxyHost = new System.Windows.Forms.TextBox();
            this.lblProxyServer = new System.Windows.Forms.Label();
            this.cbxProxyType = new System.Windows.Forms.ComboBox();
            this.txtProxyPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtProxyUser = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.cbxLogLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlExt.SuspendLayout();
            this.loginPage.SuspendLayout();
            this.sftp.SuspendLayout();
            this.ftp.SuspendLayout();
            this.proxyPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(329, 268);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(81, 22);
            this.btnLogin.TabIndex = 115;
            this.btnLogin.Text = "Connect";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(416, 268);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 22);
            this.btnCancel.TabIndex = 116;
            this.btnCancel.Text = "Cancel";
            // 
            // tabControlExt
            // 
            this.tabControlExt.Controls.Add(this.loginPage);
            this.tabControlExt.Controls.Add(this.proxyPage);
            this.tabControlExt.Location = new System.Drawing.Point(7, 8);
            this.tabControlExt.Name = "tabControlExt";
            this.tabControlExt.SelectedIndex = 0;
            this.tabControlExt.Size = new System.Drawing.Size(490, 253);
            this.tabControlExt.TabIndex = 113;
            // 
            // loginPage
            // 
            this.loginPage.Controls.Add(this.lblProtocol);
            this.loginPage.Controls.Add(this.cbxServerType);
            this.loginPage.Controls.Add(this.sftp);
            this.loginPage.Controls.Add(this.ftp);
            this.loginPage.Controls.Add(this.cbxSites);
            this.loginPage.Controls.Add(this.chkUtf8Encoding);
            this.loginPage.Controls.Add(this.lblSites);
            this.loginPage.Controls.Add(this.btnLocalDirBrowse);
            this.loginPage.Controls.Add(this.txtLocalDir);
            this.loginPage.Controls.Add(this.lblLocalDir);
            this.loginPage.Controls.Add(this.txtRemoteDir);
            this.loginPage.Controls.Add(this.lblRemoteDir);
            this.loginPage.Controls.Add(this.lblSec);
            this.loginPage.Controls.Add(this.txtUserName);
            this.loginPage.Controls.Add(this.txtPassword);
            this.loginPage.Controls.Add(this.cbxSec);
            this.loginPage.Controls.Add(this.lblFtpPassword);
            this.loginPage.Controls.Add(this.txtPort);
            this.loginPage.Controls.Add(this.lblPort);
            this.loginPage.Controls.Add(this.txtServer);
            this.loginPage.Controls.Add(this.lblServer);
            this.loginPage.Controls.Add(this.lblFtpUserName);
            this.loginPage.Location = new System.Drawing.Point(4, 22);
            this.loginPage.Name = "loginPage";
            this.loginPage.Padding = new System.Windows.Forms.Padding(3);
            this.loginPage.Size = new System.Drawing.Size(482, 227);
            this.loginPage.TabIndex = 0;
            this.loginPage.Text = "Connection Settings";
            // 
            // lblProtocol
            // 
            this.lblProtocol.Location = new System.Drawing.Point(320, 60);
            this.lblProtocol.Name = "lblProtocol";
            this.lblProtocol.Size = new System.Drawing.Size(52, 13);
            this.lblProtocol.TabIndex = 121;
            this.lblProtocol.Text = "Protocol:";
            // 
            // cbxServerType
            // 
            this.cbxServerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServerType.FormattingEnabled = true;
            this.cbxServerType.Items.AddRange(new object[] {
            "Auto Detect",
            "FTP",
            "SFTP"});
            this.cbxServerType.Location = new System.Drawing.Point(376, 56);
            this.cbxServerType.Name = "cbxServerType";
            this.cbxServerType.Size = new System.Drawing.Size(99, 21);
            this.cbxServerType.TabIndex = 120;
            // 
            // sftp
            // 
            this.sftp.Controls.Add(this.btnKeyBrowse);
            this.sftp.Controls.Add(this.txtPrivateKey);
            this.sftp.Controls.Add(this.lblKey);
            this.sftp.Controls.Add(this.chkCompress);
            this.sftp.Location = new System.Drawing.Point(250, 152);
            this.sftp.Name = "sftp";
            this.sftp.Size = new System.Drawing.Size(226, 67);
            this.sftp.TabIndex = 119;
            this.sftp.TabStop = false;
            this.sftp.Text = "SFTP";
            // 
            // btnKeyBrowse
            // 
            this.btnKeyBrowse.Location = new System.Drawing.Point(193, 37);
            this.btnKeyBrowse.Name = "btnKeyBrowse";
            this.btnKeyBrowse.Size = new System.Drawing.Size(26, 21);
            this.btnKeyBrowse.TabIndex = 32;
            this.btnKeyBrowse.Text = "...";
            this.btnKeyBrowse.Click += new System.EventHandler(this.btnKeyBrowse_Click);
            // 
            // txtPrivateKey
            // 
            this.txtPrivateKey.Location = new System.Drawing.Point(73, 38);
            this.txtPrivateKey.Name = "txtPrivateKey";
            this.txtPrivateKey.Size = new System.Drawing.Size(119, 20);
            this.txtPrivateKey.TabIndex = 31;
            // 
            // lblKey
            // 
            this.lblKey.Location = new System.Drawing.Point(4, 40);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(64, 13);
            this.lblKey.TabIndex = 61;
            this.lblKey.Text = "Private Key:";
            // 
            // chkCompress
            // 
            this.chkCompress.BackColor = System.Drawing.SystemColors.Control;
            this.chkCompress.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkCompress.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCompress.Location = new System.Drawing.Point(11, 14);
            this.chkCompress.Name = "chkCompress";
            this.chkCompress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkCompress.Size = new System.Drawing.Size(127, 19);
            this.chkCompress.TabIndex = 30;
            this.chkCompress.Text = "Enable Compression";
            this.chkCompress.UseVisualStyleBackColor = false;
            // 
            // ftp
            // 
            this.ftp.Controls.Add(this.chkClearCommandChannel);
            this.ftp.Controls.Add(this.lblCert);
            this.ftp.Controls.Add(this.chkPasv);
            this.ftp.Controls.Add(this.btnCertBrowse);
            this.ftp.Controls.Add(this.txtCertificate);
            this.ftp.Location = new System.Drawing.Point(7, 152);
            this.ftp.Name = "ftp";
            this.ftp.Size = new System.Drawing.Size(239, 67);
            this.ftp.TabIndex = 118;
            this.ftp.TabStop = false;
            this.ftp.Text = "FTP";
            // 
            // chkClearCommandChannel
            // 
            this.chkClearCommandChannel.AutoSize = true;
            this.chkClearCommandChannel.Checked = true;
            this.chkClearCommandChannel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClearCommandChannel.Location = new System.Drawing.Point(9, 14);
            this.chkClearCommandChannel.Name = "chkClearCommandChannel";
            this.chkClearCommandChannel.Size = new System.Drawing.Size(142, 17);
            this.chkClearCommandChannel.TabIndex = 20;
            this.chkClearCommandChannel.Text = "Clear Command Channel";
            // 
            // lblCert
            // 
            this.lblCert.Location = new System.Drawing.Point(7, 41);
            this.lblCert.Name = "lblCert";
            this.lblCert.Size = new System.Drawing.Size(57, 13);
            this.lblCert.TabIndex = 51;
            this.lblCert.Text = "Certificate:";
            // 
            // chkPasv
            // 
            this.chkPasv.AutoSize = true;
            this.chkPasv.BackColor = System.Drawing.SystemColors.Control;
            this.chkPasv.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkPasv.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPasv.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkPasv.Location = new System.Drawing.Point(151, 14);
            this.chkPasv.Name = "chkPasv";
            this.chkPasv.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkPasv.Size = new System.Drawing.Size(84, 18);
            this.chkPasv.TabIndex = 21;
            this.chkPasv.Text = "PASV Mode";
            this.chkPasv.UseVisualStyleBackColor = false;
            // 
            // btnCertBrowse
            // 
            this.btnCertBrowse.Location = new System.Drawing.Point(203, 37);
            this.btnCertBrowse.Name = "btnCertBrowse";
            this.btnCertBrowse.Size = new System.Drawing.Size(26, 20);
            this.btnCertBrowse.TabIndex = 23;
            this.btnCertBrowse.Text = "...";
            this.btnCertBrowse.Click += new System.EventHandler(this.btnCertBrowse_Click);
            // 
            // txtCertificate
            // 
            this.txtCertificate.Location = new System.Drawing.Point(64, 38);
            this.txtCertificate.Name = "txtCertificate";
            this.txtCertificate.Size = new System.Drawing.Size(137, 20);
            this.txtCertificate.TabIndex = 22;
            // 
            // cbxSites
            // 
            this.cbxSites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSites.FormattingEnabled = true;
            this.cbxSites.Location = new System.Drawing.Point(74, 7);
            this.cbxSites.Name = "cbxSites";
            this.cbxSites.Size = new System.Drawing.Size(401, 21);
            this.cbxSites.TabIndex = 116;
            this.cbxSites.SelectedIndexChanged += new System.EventHandler(this.cbxSites_SelectedIndexChanged);
            // 
            // chkUtf8Encoding
            // 
            this.chkUtf8Encoding.AutoSize = true;
            this.chkUtf8Encoding.Location = new System.Drawing.Point(204, 59);
            this.chkUtf8Encoding.Name = "chkUtf8Encoding";
            this.chkUtf8Encoding.Size = new System.Drawing.Size(101, 17);
            this.chkUtf8Encoding.TabIndex = 6;
            this.chkUtf8Encoding.Text = "UTF8 Encoding";
            // 
            // lblSites
            // 
            this.lblSites.Location = new System.Drawing.Point(7, 10);
            this.lblSites.Name = "lblSites";
            this.lblSites.Size = new System.Drawing.Size(68, 13);
            this.lblSites.TabIndex = 117;
            this.lblSites.Text = "Sites:";
            // 
            // btnLocalDirBrowse
            // 
            this.btnLocalDirBrowse.Location = new System.Drawing.Point(449, 131);
            this.btnLocalDirBrowse.Name = "btnLocalDirBrowse";
            this.btnLocalDirBrowse.Size = new System.Drawing.Size(26, 21);
            this.btnLocalDirBrowse.TabIndex = 12;
            this.btnLocalDirBrowse.Text = "...";
            this.btnLocalDirBrowse.Click += new System.EventHandler(this.btnLocalDirBrowse_Click);
            // 
            // txtLocalDir
            // 
            this.txtLocalDir.Location = new System.Drawing.Point(74, 131);
            this.txtLocalDir.Name = "txtLocalDir";
            this.txtLocalDir.Size = new System.Drawing.Size(372, 20);
            this.txtLocalDir.TabIndex = 11;
            // 
            // lblLocalDir
            // 
            this.lblLocalDir.Location = new System.Drawing.Point(7, 135);
            this.lblLocalDir.Name = "lblLocalDir";
            this.lblLocalDir.Size = new System.Drawing.Size(52, 13);
            this.lblLocalDir.TabIndex = 52;
            this.lblLocalDir.Text = "Local Dir:";
            // 
            // txtRemoteDir
            // 
            this.txtRemoteDir.Location = new System.Drawing.Point(74, 106);
            this.txtRemoteDir.Name = "txtRemoteDir";
            this.txtRemoteDir.Size = new System.Drawing.Size(401, 20);
            this.txtRemoteDir.TabIndex = 10;
            // 
            // lblRemoteDir
            // 
            this.lblRemoteDir.Location = new System.Drawing.Point(7, 108);
            this.lblRemoteDir.Name = "lblRemoteDir";
            this.lblRemoteDir.Size = new System.Drawing.Size(63, 13);
            this.lblRemoteDir.TabIndex = 49;
            this.lblRemoteDir.Text = "Remote Dir:";
            // 
            // lblSec
            // 
            this.lblSec.Location = new System.Drawing.Point(320, 35);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(52, 13);
            this.lblSec.TabIndex = 20;
            this.lblSec.Text = "Security:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(74, 56);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(118, 20);
            this.txtUserName.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(74, 81);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(118, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // cbxSec
            // 
            this.cbxSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSec.FormattingEnabled = true;
            this.cbxSec.Items.AddRange(new object[] {
            "Unsecure",
            "Implicit",
            "Explicit"});
            this.cbxSec.Location = new System.Drawing.Point(376, 31);
            this.cbxSec.Name = "cbxSec";
            this.cbxSec.Size = new System.Drawing.Size(99, 21);
            this.cbxSec.TabIndex = 3;
            this.cbxSec.SelectedIndexChanged += new System.EventHandler(this.cbxSec_SelectedIndexChanged);
            // 
            // lblFtpPassword
            // 
            this.lblFtpPassword.Location = new System.Drawing.Point(7, 84);
            this.lblFtpPassword.Name = "lblFtpPassword";
            this.lblFtpPassword.Size = new System.Drawing.Size(56, 13);
            this.lblFtpPassword.TabIndex = 47;
            this.lblFtpPassword.Text = "Password:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(259, 31);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(56, 20);
            this.txtPort.TabIndex = 2;
            this.txtPort.Text = "21";
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(201, 33);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(47, 13);
            this.lblPort.TabIndex = 45;
            this.lblPort.Text = "Port:";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(74, 32);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(118, 20);
            this.txtServer.TabIndex = 1;
            // 
            // lblServer
            // 
            this.lblServer.Location = new System.Drawing.Point(7, 34);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(59, 13);
            this.lblServer.TabIndex = 44;
            this.lblServer.Text = "Server:";
            // 
            // lblFtpUserName
            // 
            this.lblFtpUserName.Location = new System.Drawing.Point(7, 58);
            this.lblFtpUserName.Name = "lblFtpUserName";
            this.lblFtpUserName.Size = new System.Drawing.Size(63, 13);
            this.lblFtpUserName.TabIndex = 46;
            this.lblFtpUserName.Text = "User Name:";
            // 
            // proxyPage
            // 
            this.proxyPage.Controls.Add(this.txtProxyDomain);
            this.proxyPage.Controls.Add(this.lblDomain);
            this.proxyPage.Controls.Add(this.lblMethod);
            this.proxyPage.Controls.Add(this.cbxProxyMethod);
            this.proxyPage.Controls.Add(this.txtProxyPort);
            this.proxyPage.Controls.Add(this.lblProxyPort);
            this.proxyPage.Controls.Add(this.txtProxyHost);
            this.proxyPage.Controls.Add(this.lblProxyServer);
            this.proxyPage.Controls.Add(this.cbxProxyType);
            this.proxyPage.Controls.Add(this.txtProxyPassword);
            this.proxyPage.Controls.Add(this.lblPassword);
            this.proxyPage.Controls.Add(this.txtProxyUser);
            this.proxyPage.Controls.Add(this.lblUserName);
            this.proxyPage.Controls.Add(this.lblType);
            this.proxyPage.Location = new System.Drawing.Point(4, 22);
            this.proxyPage.Name = "proxyPage";
            this.proxyPage.Padding = new System.Windows.Forms.Padding(3);
            this.proxyPage.Size = new System.Drawing.Size(482, 227);
            this.proxyPage.TabIndex = 1;
            this.proxyPage.Text = "Proxy Settings";
            // 
            // txtProxyDomain
            // 
            this.txtProxyDomain.Enabled = false;
            this.txtProxyDomain.Location = new System.Drawing.Point(74, 80);
            this.txtProxyDomain.Name = "txtProxyDomain";
            this.txtProxyDomain.Size = new System.Drawing.Size(126, 20);
            this.txtProxyDomain.TabIndex = 7;
            // 
            // lblDomain
            // 
            this.lblDomain.Location = new System.Drawing.Point(6, 82);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(46, 13);
            this.lblDomain.TabIndex = 31;
            this.lblDomain.Text = "Domain:";
            // 
            // lblMethod
            // 
            this.lblMethod.Location = new System.Drawing.Point(224, 58);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(46, 13);
            this.lblMethod.TabIndex = 29;
            this.lblMethod.Text = "Method:";
            // 
            // cbxProxyMethod
            // 
            this.cbxProxyMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProxyMethod.Enabled = false;
            this.cbxProxyMethod.FormattingEnabled = true;
            this.cbxProxyMethod.Items.AddRange(new object[] {
            "Basic",
            "Ntlm"});
            this.cbxProxyMethod.Location = new System.Drawing.Point(286, 56);
            this.cbxProxyMethod.Name = "cbxProxyMethod";
            this.cbxProxyMethod.Size = new System.Drawing.Size(104, 21);
            this.cbxProxyMethod.TabIndex = 6;
            this.cbxProxyMethod.SelectedIndexChanged += new System.EventHandler(this.cbxProxy_SelectedIndexChanged);
            // 
            // txtProxyPort
            // 
            this.txtProxyPort.Location = new System.Drawing.Point(286, 8);
            this.txtProxyPort.Name = "txtProxyPort";
            this.txtProxyPort.Size = new System.Drawing.Size(104, 20);
            this.txtProxyPort.TabIndex = 2;
            // 
            // lblProxyPort
            // 
            this.lblProxyPort.Location = new System.Drawing.Point(224, 10);
            this.lblProxyPort.Name = "lblProxyPort";
            this.lblProxyPort.Size = new System.Drawing.Size(58, 13);
            this.lblProxyPort.TabIndex = 27;
            this.lblProxyPort.Text = "Proxy Port:";
            // 
            // txtProxyHost
            // 
            this.txtProxyHost.Location = new System.Drawing.Point(74, 8);
            this.txtProxyHost.Name = "txtProxyHost";
            this.txtProxyHost.Size = new System.Drawing.Size(126, 20);
            this.txtProxyHost.TabIndex = 1;
            // 
            // lblProxyServer
            // 
            this.lblProxyServer.Location = new System.Drawing.Point(6, 10);
            this.lblProxyServer.Name = "lblProxyServer";
            this.lblProxyServer.Size = new System.Drawing.Size(70, 13);
            this.lblProxyServer.TabIndex = 26;
            this.lblProxyServer.Text = "Proxy Server:";
            // 
            // cbxProxyType
            // 
            this.cbxProxyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProxyType.FormattingEnabled = true;
            this.cbxProxyType.Items.AddRange(new object[] {
            "Never",
            "Socks4",
            "Socks4A",
            "Socks5",
            "HttpConnect",
            "SITE Site",
            "USER user@site",
            "OPEN site"});
            this.cbxProxyType.Location = new System.Drawing.Point(286, 32);
            this.cbxProxyType.Name = "cbxProxyType";
            this.cbxProxyType.Size = new System.Drawing.Size(104, 21);
            this.cbxProxyType.TabIndex = 4;
            this.cbxProxyType.SelectedIndexChanged += new System.EventHandler(this.cbxProxy_SelectedIndexChanged);
            // 
            // txtProxyPassword
            // 
            this.txtProxyPassword.Enabled = false;
            this.txtProxyPassword.Location = new System.Drawing.Point(74, 56);
            this.txtProxyPassword.Name = "txtProxyPassword";
            this.txtProxyPassword.PasswordChar = '*';
            this.txtProxyPassword.Size = new System.Drawing.Size(126, 20);
            this.txtProxyPassword.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(6, 58);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 23;
            this.lblPassword.Text = "Password:";
            // 
            // txtProxyUser
            // 
            this.txtProxyUser.Location = new System.Drawing.Point(74, 32);
            this.txtProxyUser.Name = "txtProxyUser";
            this.txtProxyUser.Size = new System.Drawing.Size(126, 20);
            this.txtProxyUser.TabIndex = 3;
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(6, 34);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(63, 13);
            this.lblUserName.TabIndex = 21;
            this.lblUserName.Text = "User Name:";
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(224, 34);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(63, 13);
            this.lblType.TabIndex = 28;
            this.lblType.Text = "Proxy Type:";
            // 
            // cbxLogLevel
            // 
            this.cbxLogLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLogLevel.FormattingEnabled = true;
            this.cbxLogLevel.Items.AddRange(new object[] {
            "None",
            "Error",
            "Info",
            "Verbose",
            "Transfer"});
            this.cbxLogLevel.Location = new System.Drawing.Point(77, 268);
            this.cbxLogLevel.Name = "cbxLogLevel";
            this.cbxLogLevel.Size = new System.Drawing.Size(118, 21);
            this.cbxLogLevel.TabIndex = 114;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 115;
            this.label1.Text = "Log Level:";
            // 
            // Login
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(503, 298);
            this.Controls.Add(this.cbxLogLevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControlExt);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect";
            this.tabControlExt.ResumeLayout(false);
            this.loginPage.ResumeLayout(false);
            this.loginPage.PerformLayout();
            this.sftp.ResumeLayout(false);
            this.sftp.PerformLayout();
            this.ftp.ResumeLayout(false);
            this.ftp.PerformLayout();
            this.proxyPage.ResumeLayout(false);
            this.proxyPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControlExt;
        private System.Windows.Forms.TabPage loginPage;
        private System.Windows.Forms.TabPage proxyPage;
        public System.Windows.Forms.CheckBox chkPasv;
        private System.Windows.Forms.TextBox txtRemoteDir;
        private System.Windows.Forms.Label lblRemoteDir;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblFtpPassword;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblFtpUserName;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.ComboBox cbxProxyMethod;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtProxyPort;
        private System.Windows.Forms.Label lblProxyPort;
        private System.Windows.Forms.TextBox txtProxyHost;
        private System.Windows.Forms.Label lblProxyServer;
        private System.Windows.Forms.ComboBox cbxProxyType;
        private System.Windows.Forms.TextBox txtProxyPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtProxyUser;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.CheckBox chkClearCommandChannel;
        private System.Windows.Forms.TextBox txtCertificate;
        private System.Windows.Forms.Label lblCert;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.ComboBox cbxSec;
        private System.Windows.Forms.Button btnCertBrowse;
        private System.Windows.Forms.Button btnLocalDirBrowse;
        private System.Windows.Forms.TextBox txtLocalDir;
        private System.Windows.Forms.Label lblLocalDir;
        private System.Windows.Forms.ComboBox cbxLogLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProxyDomain;
        private System.Windows.Forms.Label lblDomain;
        private System.Windows.Forms.ComboBox cbxSites;
        private System.Windows.Forms.Label lblSites;
        private CheckBox chkUtf8Encoding;
        private GroupBox ftp;
        private GroupBox sftp;
        public CheckBox chkCompress;
        private Button btnKeyBrowse;
        private TextBox txtPrivateKey;
        private Label lblKey;
        private ComboBox cbxServerType;
        private Label lblProtocol;
    }
}