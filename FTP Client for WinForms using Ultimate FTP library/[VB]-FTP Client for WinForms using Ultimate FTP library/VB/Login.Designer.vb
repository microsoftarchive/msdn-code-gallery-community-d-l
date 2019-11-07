Namespace ClientSample
	Partial Public Class Login
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.btnLogin = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.tabControlExt = New System.Windows.Forms.TabControl()
			Me.loginPage = New System.Windows.Forms.TabPage()
			Me.sftp = New System.Windows.Forms.GroupBox()
			Me.btnKeyBrowse = New System.Windows.Forms.Button()
			Me.txtPrivateKey = New System.Windows.Forms.TextBox()
			Me.lblKey = New System.Windows.Forms.Label()
			Me.chkCompress = New System.Windows.Forms.CheckBox()
			Me.ftp = New System.Windows.Forms.GroupBox()
			Me.chkClearCommandChannel = New System.Windows.Forms.CheckBox()
			Me.lblCert = New System.Windows.Forms.Label()
			Me.chkPasv = New System.Windows.Forms.CheckBox()
			Me.btnCertBrowse = New System.Windows.Forms.Button()
			Me.txtCertificate = New System.Windows.Forms.TextBox()
			Me.cbxSites = New System.Windows.Forms.ComboBox()
			Me.chkUtf8Encoding = New System.Windows.Forms.CheckBox()
			Me.lblSites = New System.Windows.Forms.Label()
			Me.btnLocalDirBrowse = New System.Windows.Forms.Button()
			Me.txtLocalDir = New System.Windows.Forms.TextBox()
			Me.lblLocalDir = New System.Windows.Forms.Label()
			Me.txtRemoteDir = New System.Windows.Forms.TextBox()
			Me.lblRemoteDir = New System.Windows.Forms.Label()
			Me.lblSec = New System.Windows.Forms.Label()
			Me.txtUserName = New System.Windows.Forms.TextBox()
			Me.txtPassword = New System.Windows.Forms.TextBox()
			Me.cbxSec = New System.Windows.Forms.ComboBox()
			Me.lblFtpPassword = New System.Windows.Forms.Label()
			Me.txtPort = New System.Windows.Forms.TextBox()
			Me.lblPort = New System.Windows.Forms.Label()
			Me.txtServer = New System.Windows.Forms.TextBox()
			Me.lblServer = New System.Windows.Forms.Label()
			Me.lblFtpUserName = New System.Windows.Forms.Label()
			Me.proxyPage = New System.Windows.Forms.TabPage()
			Me.txtProxyDomain = New System.Windows.Forms.TextBox()
			Me.lblDomain = New System.Windows.Forms.Label()
			Me.lblMethod = New System.Windows.Forms.Label()
			Me.cbxProxyMethod = New System.Windows.Forms.ComboBox()
			Me.txtProxyPort = New System.Windows.Forms.TextBox()
			Me.lblProxyPort = New System.Windows.Forms.Label()
			Me.txtProxyHost = New System.Windows.Forms.TextBox()
			Me.lblProxyServer = New System.Windows.Forms.Label()
			Me.cbxProxyType = New System.Windows.Forms.ComboBox()
			Me.txtProxyPassword = New System.Windows.Forms.TextBox()
			Me.lblPassword = New System.Windows.Forms.Label()
			Me.txtProxyUser = New System.Windows.Forms.TextBox()
			Me.lblUserName = New System.Windows.Forms.Label()
			Me.lblType = New System.Windows.Forms.Label()
			Me.cbxLogLevel = New System.Windows.Forms.ComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.tabControlExt.SuspendLayout()
			Me.loginPage.SuspendLayout()
			Me.sftp.SuspendLayout()
			Me.ftp.SuspendLayout()
			Me.proxyPage.SuspendLayout()
			Me.SuspendLayout()
			' 
			' btnLogin
			' 
			Me.btnLogin.Location = New System.Drawing.Point(329, 268)
			Me.btnLogin.Name = "btnLogin"
			Me.btnLogin.Size = New System.Drawing.Size(81, 22)
			Me.btnLogin.TabIndex = 115
			Me.btnLogin.Text = "Connect"
'			Me.btnLogin.Click += New System.EventHandler(Me.btnLogin_Click)
			' 
			' btnCancel
			' 
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(416, 268)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(81, 22)
			Me.btnCancel.TabIndex = 116
			Me.btnCancel.Text = "Cancel"
			' 
			' tabControlExt
			' 
			Me.tabControlExt.Controls.Add(Me.loginPage)
			Me.tabControlExt.Controls.Add(Me.proxyPage)
			Me.tabControlExt.Location = New System.Drawing.Point(7, 8)
			Me.tabControlExt.Name = "tabControlExt"
			Me.tabControlExt.SelectedIndex = 0
			Me.tabControlExt.Size = New System.Drawing.Size(490, 253)
			Me.tabControlExt.TabIndex = 113
			' 
			' loginPage
			' 
			Me.loginPage.Controls.Add(Me.sftp)
			Me.loginPage.Controls.Add(Me.ftp)
			Me.loginPage.Controls.Add(Me.cbxSites)
			Me.loginPage.Controls.Add(Me.chkUtf8Encoding)
			Me.loginPage.Controls.Add(Me.lblSites)
			Me.loginPage.Controls.Add(Me.btnLocalDirBrowse)
			Me.loginPage.Controls.Add(Me.txtLocalDir)
			Me.loginPage.Controls.Add(Me.lblLocalDir)
			Me.loginPage.Controls.Add(Me.txtRemoteDir)
			Me.loginPage.Controls.Add(Me.lblRemoteDir)
			Me.loginPage.Controls.Add(Me.lblSec)
			Me.loginPage.Controls.Add(Me.txtUserName)
			Me.loginPage.Controls.Add(Me.txtPassword)
			Me.loginPage.Controls.Add(Me.cbxSec)
			Me.loginPage.Controls.Add(Me.lblFtpPassword)
			Me.loginPage.Controls.Add(Me.txtPort)
			Me.loginPage.Controls.Add(Me.lblPort)
			Me.loginPage.Controls.Add(Me.txtServer)
			Me.loginPage.Controls.Add(Me.lblServer)
			Me.loginPage.Controls.Add(Me.lblFtpUserName)
			Me.loginPage.Location = New System.Drawing.Point(4, 22)
			Me.loginPage.Name = "loginPage"
			Me.loginPage.Padding = New System.Windows.Forms.Padding(3)
			Me.loginPage.Size = New System.Drawing.Size(482, 227)
			Me.loginPage.TabIndex = 0
			Me.loginPage.Text = "Connection Settings"
			' 
			' sftp
			' 
			Me.sftp.Controls.Add(Me.btnKeyBrowse)
			Me.sftp.Controls.Add(Me.txtPrivateKey)
			Me.sftp.Controls.Add(Me.lblKey)
			Me.sftp.Controls.Add(Me.chkCompress)
			Me.sftp.Location = New System.Drawing.Point(250, 152)
			Me.sftp.Name = "sftp"
			Me.sftp.Size = New System.Drawing.Size(226, 67)
			Me.sftp.TabIndex = 119
			Me.sftp.TabStop = False
			Me.sftp.Text = "SFTP"
			' 
			' btnKeyBrowse
			' 
			Me.btnKeyBrowse.Location = New System.Drawing.Point(193, 37)
			Me.btnKeyBrowse.Name = "btnKeyBrowse"
			Me.btnKeyBrowse.Size = New System.Drawing.Size(26, 21)
			Me.btnKeyBrowse.TabIndex = 32
			Me.btnKeyBrowse.Text = "..."
'			Me.btnKeyBrowse.Click += New System.EventHandler(Me.btnKeyBrowse_Click)
			' 
			' txtPrivateKey
			' 
			Me.txtPrivateKey.Location = New System.Drawing.Point(73, 38)
			Me.txtPrivateKey.Name = "txtPrivateKey"
			Me.txtPrivateKey.Size = New System.Drawing.Size(119, 20)
			Me.txtPrivateKey.TabIndex = 31
			' 
			' lblKey
			' 
			Me.lblKey.Location = New System.Drawing.Point(4, 40)
			Me.lblKey.Name = "lblKey"
			Me.lblKey.Size = New System.Drawing.Size(64, 13)
			Me.lblKey.TabIndex = 61
			Me.lblKey.Text = "Private Key:"
			' 
			' chkCompress
			' 
			Me.chkCompress.BackColor = System.Drawing.SystemColors.Control
			Me.chkCompress.Cursor = System.Windows.Forms.Cursors.Default
			Me.chkCompress.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.chkCompress.ForeColor = System.Drawing.SystemColors.ControlText
			Me.chkCompress.Location = New System.Drawing.Point(11, 14)
			Me.chkCompress.Name = "chkCompress"
			Me.chkCompress.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.chkCompress.Size = New System.Drawing.Size(127, 19)
			Me.chkCompress.TabIndex = 30
			Me.chkCompress.Text = "Enable Compression"
			Me.chkCompress.UseVisualStyleBackColor = False
			' 
			' ftp
			' 
			Me.ftp.Controls.Add(Me.chkClearCommandChannel)
			Me.ftp.Controls.Add(Me.lblCert)
			Me.ftp.Controls.Add(Me.chkPasv)
			Me.ftp.Controls.Add(Me.btnCertBrowse)
			Me.ftp.Controls.Add(Me.txtCertificate)
			Me.ftp.Location = New System.Drawing.Point(7, 152)
			Me.ftp.Name = "ftp"
			Me.ftp.Size = New System.Drawing.Size(239, 67)
			Me.ftp.TabIndex = 118
			Me.ftp.TabStop = False
			Me.ftp.Text = "FTP"
			' 
			' chkClearCommandChannel
			' 
			Me.chkClearCommandChannel.AutoSize = True
			Me.chkClearCommandChannel.Checked = True
			Me.chkClearCommandChannel.CheckState = System.Windows.Forms.CheckState.Checked
			Me.chkClearCommandChannel.Location = New System.Drawing.Point(9, 14)
			Me.chkClearCommandChannel.Name = "chkClearCommandChannel"
			Me.chkClearCommandChannel.Size = New System.Drawing.Size(142, 17)
			Me.chkClearCommandChannel.TabIndex = 20
			Me.chkClearCommandChannel.Text = "Clear Command Channel"
			' 
			' lblCert
			' 
			Me.lblCert.Location = New System.Drawing.Point(7, 41)
			Me.lblCert.Name = "lblCert"
			Me.lblCert.Size = New System.Drawing.Size(57, 13)
			Me.lblCert.TabIndex = 51
			Me.lblCert.Text = "Certificate:"
			' 
			' chkPasv
			' 
			Me.chkPasv.AutoSize = True
			Me.chkPasv.BackColor = System.Drawing.SystemColors.Control
			Me.chkPasv.Cursor = System.Windows.Forms.Cursors.Default
			Me.chkPasv.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.chkPasv.ForeColor = System.Drawing.SystemColors.ControlText
			Me.chkPasv.Location = New System.Drawing.Point(151, 14)
			Me.chkPasv.Name = "chkPasv"
			Me.chkPasv.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.chkPasv.Size = New System.Drawing.Size(84, 18)
			Me.chkPasv.TabIndex = 21
			Me.chkPasv.Text = "PASV Mode"
			Me.chkPasv.UseVisualStyleBackColor = False
			' 
			' btnCertBrowse
			' 
			Me.btnCertBrowse.Location = New System.Drawing.Point(203, 37)
			Me.btnCertBrowse.Name = "btnCertBrowse"
			Me.btnCertBrowse.Size = New System.Drawing.Size(26, 20)
			Me.btnCertBrowse.TabIndex = 23
			Me.btnCertBrowse.Text = "..."
'			Me.btnCertBrowse.Click += New System.EventHandler(Me.btnCertBrowse_Click)
			' 
			' txtCertificate
			' 
			Me.txtCertificate.Location = New System.Drawing.Point(64, 38)
			Me.txtCertificate.Name = "txtCertificate"
			Me.txtCertificate.Size = New System.Drawing.Size(137, 20)
			Me.txtCertificate.TabIndex = 22
			' 
			' cbxSites
			' 
			Me.cbxSites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbxSites.FormattingEnabled = True
			Me.cbxSites.Location = New System.Drawing.Point(74, 7)
			Me.cbxSites.Name = "cbxSites"
			Me.cbxSites.Size = New System.Drawing.Size(401, 21)
			Me.cbxSites.TabIndex = 116
'			Me.cbxSites.SelectedIndexChanged += New System.EventHandler(Me.cbxSites_SelectedIndexChanged)
			' 
			' chkUtf8Encoding
			' 
			Me.chkUtf8Encoding.AutoSize = True
			Me.chkUtf8Encoding.Location = New System.Drawing.Point(204, 59)
			Me.chkUtf8Encoding.Name = "chkUtf8Encoding"
			Me.chkUtf8Encoding.Size = New System.Drawing.Size(101, 17)
			Me.chkUtf8Encoding.TabIndex = 6
			Me.chkUtf8Encoding.Text = "UTF8 Encoding"
			' 
			' lblSites
			' 
			Me.lblSites.Location = New System.Drawing.Point(7, 10)
			Me.lblSites.Name = "lblSites"
			Me.lblSites.Size = New System.Drawing.Size(68, 13)
			Me.lblSites.TabIndex = 117
			Me.lblSites.Text = "Sites:"
			' 
			' btnLocalDirBrowse
			' 
			Me.btnLocalDirBrowse.Location = New System.Drawing.Point(449, 131)
			Me.btnLocalDirBrowse.Name = "btnLocalDirBrowse"
			Me.btnLocalDirBrowse.Size = New System.Drawing.Size(26, 21)
			Me.btnLocalDirBrowse.TabIndex = 12
			Me.btnLocalDirBrowse.Text = "..."
'			Me.btnLocalDirBrowse.Click += New System.EventHandler(Me.btnLocalDirBrowse_Click)
			' 
			' txtLocalDir
			' 
			Me.txtLocalDir.Location = New System.Drawing.Point(74, 131)
			Me.txtLocalDir.Name = "txtLocalDir"
			Me.txtLocalDir.Size = New System.Drawing.Size(372, 20)
			Me.txtLocalDir.TabIndex = 11
			' 
			' lblLocalDir
			' 
			Me.lblLocalDir.Location = New System.Drawing.Point(7, 135)
			Me.lblLocalDir.Name = "lblLocalDir"
			Me.lblLocalDir.Size = New System.Drawing.Size(52, 13)
			Me.lblLocalDir.TabIndex = 52
			Me.lblLocalDir.Text = "Local Dir:"
			' 
			' txtRemoteDir
			' 
			Me.txtRemoteDir.Location = New System.Drawing.Point(74, 106)
			Me.txtRemoteDir.Name = "txtRemoteDir"
			Me.txtRemoteDir.Size = New System.Drawing.Size(401, 20)
			Me.txtRemoteDir.TabIndex = 10
			' 
			' lblRemoteDir
			' 
			Me.lblRemoteDir.Location = New System.Drawing.Point(7, 108)
			Me.lblRemoteDir.Name = "lblRemoteDir"
			Me.lblRemoteDir.Size = New System.Drawing.Size(63, 13)
			Me.lblRemoteDir.TabIndex = 49
			Me.lblRemoteDir.Text = "Remote Dir:"
			' 
			' lblSec
			' 
			Me.lblSec.Location = New System.Drawing.Point(320, 35)
			Me.lblSec.Name = "lblSec"
			Me.lblSec.Size = New System.Drawing.Size(52, 13)
			Me.lblSec.TabIndex = 20
			Me.lblSec.Text = "Security:"
			' 
			' txtUserName
			' 
			Me.txtUserName.Location = New System.Drawing.Point(74, 56)
			Me.txtUserName.Name = "txtUserName"
			Me.txtUserName.Size = New System.Drawing.Size(118, 20)
			Me.txtUserName.TabIndex = 4
			' 
			' txtPassword
			' 
			Me.txtPassword.Location = New System.Drawing.Point(74, 81)
			Me.txtPassword.Name = "txtPassword"
			Me.txtPassword.PasswordChar = "*"c
			Me.txtPassword.Size = New System.Drawing.Size(118, 20)
			Me.txtPassword.TabIndex = 5
			' 
			' cbxSec
			' 
			Me.cbxSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbxSec.FormattingEnabled = True
			Me.cbxSec.Items.AddRange(New Object() { "Unsecure", "Implicit", "Explicit"})
			Me.cbxSec.Location = New System.Drawing.Point(376, 31)
			Me.cbxSec.Name = "cbxSec"
			Me.cbxSec.Size = New System.Drawing.Size(99, 21)
			Me.cbxSec.TabIndex = 3
'			Me.cbxSec.SelectedIndexChanged += New System.EventHandler(Me.cbxSec_SelectedIndexChanged)
			' 
			' lblFtpPassword
			' 
			Me.lblFtpPassword.Location = New System.Drawing.Point(7, 84)
			Me.lblFtpPassword.Name = "lblFtpPassword"
			Me.lblFtpPassword.Size = New System.Drawing.Size(56, 13)
			Me.lblFtpPassword.TabIndex = 47
			Me.lblFtpPassword.Text = "Password:"
			' 
			' txtPort
			' 
			Me.txtPort.Location = New System.Drawing.Point(259, 31)
			Me.txtPort.Name = "txtPort"
			Me.txtPort.Size = New System.Drawing.Size(56, 20)
			Me.txtPort.TabIndex = 2
			Me.txtPort.Text = "21"
			' 
			' lblPort
			' 
			Me.lblPort.Location = New System.Drawing.Point(201, 33)
			Me.lblPort.Name = "lblPort"
			Me.lblPort.Size = New System.Drawing.Size(47, 13)
			Me.lblPort.TabIndex = 45
			Me.lblPort.Text = "Port:"
			' 
			' txtServer
			' 
			Me.txtServer.Location = New System.Drawing.Point(74, 32)
			Me.txtServer.Name = "txtServer"
			Me.txtServer.Size = New System.Drawing.Size(118, 20)
			Me.txtServer.TabIndex = 1
			' 
			' lblServer
			' 
			Me.lblServer.Location = New System.Drawing.Point(7, 34)
			Me.lblServer.Name = "lblServer"
			Me.lblServer.Size = New System.Drawing.Size(59, 13)
			Me.lblServer.TabIndex = 44
			Me.lblServer.Text = "Server:"
			' 
			' lblFtpUserName
			' 
			Me.lblFtpUserName.Location = New System.Drawing.Point(7, 58)
			Me.lblFtpUserName.Name = "lblFtpUserName"
			Me.lblFtpUserName.Size = New System.Drawing.Size(63, 13)
			Me.lblFtpUserName.TabIndex = 46
			Me.lblFtpUserName.Text = "User Name:"
			' 
			' proxyPage
			' 
			Me.proxyPage.Controls.Add(Me.txtProxyDomain)
			Me.proxyPage.Controls.Add(Me.lblDomain)
			Me.proxyPage.Controls.Add(Me.lblMethod)
			Me.proxyPage.Controls.Add(Me.cbxProxyMethod)
			Me.proxyPage.Controls.Add(Me.txtProxyPort)
			Me.proxyPage.Controls.Add(Me.lblProxyPort)
			Me.proxyPage.Controls.Add(Me.txtProxyHost)
			Me.proxyPage.Controls.Add(Me.lblProxyServer)
			Me.proxyPage.Controls.Add(Me.cbxProxyType)
			Me.proxyPage.Controls.Add(Me.txtProxyPassword)
			Me.proxyPage.Controls.Add(Me.lblPassword)
			Me.proxyPage.Controls.Add(Me.txtProxyUser)
			Me.proxyPage.Controls.Add(Me.lblUserName)
			Me.proxyPage.Controls.Add(Me.lblType)
			Me.proxyPage.Location = New System.Drawing.Point(4, 22)
			Me.proxyPage.Name = "proxyPage"
			Me.proxyPage.Padding = New System.Windows.Forms.Padding(3)
			Me.proxyPage.Size = New System.Drawing.Size(482, 227)
			Me.proxyPage.TabIndex = 1
			Me.proxyPage.Text = "Proxy Settings"
			' 
			' txtProxyDomain
			' 
			Me.txtProxyDomain.Enabled = False
			Me.txtProxyDomain.Location = New System.Drawing.Point(74, 80)
			Me.txtProxyDomain.Name = "txtProxyDomain"
			Me.txtProxyDomain.Size = New System.Drawing.Size(126, 20)
			Me.txtProxyDomain.TabIndex = 7
			' 
			' lblDomain
			' 
			Me.lblDomain.Location = New System.Drawing.Point(6, 82)
			Me.lblDomain.Name = "lblDomain"
			Me.lblDomain.Size = New System.Drawing.Size(46, 13)
			Me.lblDomain.TabIndex = 31
			Me.lblDomain.Text = "Domain:"
			' 
			' lblMethod
			' 
			Me.lblMethod.Location = New System.Drawing.Point(224, 58)
			Me.lblMethod.Name = "lblMethod"
			Me.lblMethod.Size = New System.Drawing.Size(46, 13)
			Me.lblMethod.TabIndex = 29
			Me.lblMethod.Text = "Method:"
			' 
			' cbxProxyMethod
			' 
			Me.cbxProxyMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbxProxyMethod.Enabled = False
			Me.cbxProxyMethod.FormattingEnabled = True
			Me.cbxProxyMethod.Items.AddRange(New Object() { "Basic", "Ntlm"})
			Me.cbxProxyMethod.Location = New System.Drawing.Point(286, 56)
			Me.cbxProxyMethod.Name = "cbxProxyMethod"
			Me.cbxProxyMethod.Size = New System.Drawing.Size(104, 21)
			Me.cbxProxyMethod.TabIndex = 6
'			Me.cbxProxyMethod.SelectedIndexChanged += New System.EventHandler(Me.cbxProxy_SelectedIndexChanged)
			' 
			' txtProxyPort
			' 
			Me.txtProxyPort.Location = New System.Drawing.Point(286, 8)
			Me.txtProxyPort.Name = "txtProxyPort"
			Me.txtProxyPort.Size = New System.Drawing.Size(104, 20)
			Me.txtProxyPort.TabIndex = 2
			' 
			' lblProxyPort
			' 
			Me.lblProxyPort.Location = New System.Drawing.Point(224, 10)
			Me.lblProxyPort.Name = "lblProxyPort"
			Me.lblProxyPort.Size = New System.Drawing.Size(58, 13)
			Me.lblProxyPort.TabIndex = 27
			Me.lblProxyPort.Text = "Proxy Port:"
			' 
			' txtProxyHost
			' 
			Me.txtProxyHost.Location = New System.Drawing.Point(74, 8)
			Me.txtProxyHost.Name = "txtProxyHost"
			Me.txtProxyHost.Size = New System.Drawing.Size(126, 20)
			Me.txtProxyHost.TabIndex = 1
			' 
			' lblProxyServer
			' 
			Me.lblProxyServer.Location = New System.Drawing.Point(6, 10)
			Me.lblProxyServer.Name = "lblProxyServer"
			Me.lblProxyServer.Size = New System.Drawing.Size(70, 13)
			Me.lblProxyServer.TabIndex = 26
			Me.lblProxyServer.Text = "Proxy Server:"
			' 
			' cbxProxyType
			' 
			Me.cbxProxyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbxProxyType.FormattingEnabled = True
			Me.cbxProxyType.Items.AddRange(New Object() { "Never", "Socks4", "Socks4A", "Socks5", "HttpConnect", "SITE Site", "USER user@site", "OPEN site"})
			Me.cbxProxyType.Location = New System.Drawing.Point(286, 32)
			Me.cbxProxyType.Name = "cbxProxyType"
			Me.cbxProxyType.Size = New System.Drawing.Size(104, 21)
			Me.cbxProxyType.TabIndex = 4
'			Me.cbxProxyType.SelectedIndexChanged += New System.EventHandler(Me.cbxProxy_SelectedIndexChanged)
			' 
			' txtProxyPassword
			' 
			Me.txtProxyPassword.Enabled = False
			Me.txtProxyPassword.Location = New System.Drawing.Point(74, 56)
			Me.txtProxyPassword.Name = "txtProxyPassword"
			Me.txtProxyPassword.PasswordChar = "*"c
			Me.txtProxyPassword.Size = New System.Drawing.Size(126, 20)
			Me.txtProxyPassword.TabIndex = 5
			' 
			' lblPassword
			' 
			Me.lblPassword.Location = New System.Drawing.Point(6, 58)
			Me.lblPassword.Name = "lblPassword"
			Me.lblPassword.Size = New System.Drawing.Size(56, 13)
			Me.lblPassword.TabIndex = 23
			Me.lblPassword.Text = "Password:"
			' 
			' txtProxyUser
			' 
			Me.txtProxyUser.Location = New System.Drawing.Point(74, 32)
			Me.txtProxyUser.Name = "txtProxyUser"
			Me.txtProxyUser.Size = New System.Drawing.Size(126, 20)
			Me.txtProxyUser.TabIndex = 3
			' 
			' lblUserName
			' 
			Me.lblUserName.Location = New System.Drawing.Point(6, 34)
			Me.lblUserName.Name = "lblUserName"
			Me.lblUserName.Size = New System.Drawing.Size(63, 13)
			Me.lblUserName.TabIndex = 21
			Me.lblUserName.Text = "User Name:"
			' 
			' lblType
			' 
			Me.lblType.Location = New System.Drawing.Point(224, 34)
			Me.lblType.Name = "lblType"
			Me.lblType.Size = New System.Drawing.Size(63, 13)
			Me.lblType.TabIndex = 28
			Me.lblType.Text = "Proxy Type:"
			' 
			' cbxLogLevel
			' 
			Me.cbxLogLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbxLogLevel.FormattingEnabled = True
			Me.cbxLogLevel.Items.AddRange(New Object() { "None", "Error", "Info", "Verbose", "Transfer"})
			Me.cbxLogLevel.Location = New System.Drawing.Point(77, 268)
			Me.cbxLogLevel.Name = "cbxLogLevel"
			Me.cbxLogLevel.Size = New System.Drawing.Size(118, 21)
			Me.cbxLogLevel.TabIndex = 114
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(10, 272)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(57, 13)
			Me.label1.TabIndex = 115
			Me.label1.Text = "Log Level:"
			' 
			' Login
			' 
			Me.AcceptButton = Me.btnLogin
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(503, 298)
			Me.Controls.Add(Me.cbxLogLevel)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.tabControlExt)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.btnLogin)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "Login"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Connect"
			Me.tabControlExt.ResumeLayout(False)
			Me.loginPage.ResumeLayout(False)
			Me.loginPage.PerformLayout()
			Me.sftp.ResumeLayout(False)
			Me.sftp.PerformLayout()
			Me.ftp.ResumeLayout(False)
			Me.ftp.PerformLayout()
			Me.proxyPage.ResumeLayout(False)
			Me.proxyPage.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents btnLogin As System.Windows.Forms.Button
		Private btnCancel As System.Windows.Forms.Button
		Private tabControlExt As System.Windows.Forms.TabControl
		Private loginPage As System.Windows.Forms.TabPage
		Private proxyPage As System.Windows.Forms.TabPage
		Public chkPasv As System.Windows.Forms.CheckBox
		Private txtRemoteDir As System.Windows.Forms.TextBox
		Private lblRemoteDir As System.Windows.Forms.Label
		Private txtUserName As System.Windows.Forms.TextBox
		Private txtPassword As System.Windows.Forms.TextBox
		Private lblFtpPassword As System.Windows.Forms.Label
		Private txtPort As System.Windows.Forms.TextBox
		Private lblPort As System.Windows.Forms.Label
		Private txtServer As System.Windows.Forms.TextBox
		Private lblServer As System.Windows.Forms.Label
		Private lblFtpUserName As System.Windows.Forms.Label
		Private lblMethod As System.Windows.Forms.Label
		Private WithEvents cbxProxyMethod As System.Windows.Forms.ComboBox
		Private lblType As System.Windows.Forms.Label
		Private txtProxyPort As System.Windows.Forms.TextBox
		Private lblProxyPort As System.Windows.Forms.Label
		Private txtProxyHost As System.Windows.Forms.TextBox
		Private lblProxyServer As System.Windows.Forms.Label
		Private WithEvents cbxProxyType As System.Windows.Forms.ComboBox
		Private txtProxyPassword As System.Windows.Forms.TextBox
		Private lblPassword As System.Windows.Forms.Label
		Private txtProxyUser As System.Windows.Forms.TextBox
		Private lblUserName As System.Windows.Forms.Label
		Private chkClearCommandChannel As System.Windows.Forms.CheckBox
		Private txtCertificate As System.Windows.Forms.TextBox
		Private lblCert As System.Windows.Forms.Label
		Private lblSec As System.Windows.Forms.Label
		Private WithEvents cbxSec As System.Windows.Forms.ComboBox
		Private WithEvents btnCertBrowse As System.Windows.Forms.Button
		Private WithEvents btnLocalDirBrowse As System.Windows.Forms.Button
		Private txtLocalDir As System.Windows.Forms.TextBox
		Private lblLocalDir As System.Windows.Forms.Label
		Private cbxLogLevel As System.Windows.Forms.ComboBox
		Private label1 As System.Windows.Forms.Label
		Private txtProxyDomain As System.Windows.Forms.TextBox
		Private lblDomain As System.Windows.Forms.Label
		Private WithEvents cbxSites As System.Windows.Forms.ComboBox
		Private lblSites As System.Windows.Forms.Label
		Private chkUtf8Encoding As CheckBox
		Private ftp As GroupBox
		Private sftp As GroupBox
		Public chkCompress As CheckBox
		Private WithEvents btnKeyBrowse As Button
		Private txtPrivateKey As TextBox
		Private lblKey As Label
	End Class
End Namespace