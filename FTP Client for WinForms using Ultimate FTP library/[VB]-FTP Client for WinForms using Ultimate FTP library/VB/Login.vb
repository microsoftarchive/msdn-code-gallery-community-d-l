Imports ClientSample.Ftp
Imports ComponentPro.Net

#If Not FTP Then
Imports FtpProxyType = ComponentPro.Net.ProxyType
Imports FtpProxyHttpConnectAuthMethod = ComponentPro.Net.ProxyHttpConnectAuthMethod
#End If

Namespace ClientSample
	''' <summary>
	''' Represents the Login form.
	''' </summary>
	Partial Public Class Login
		Inherits Form
		Private ReadOnly _info As SettingInfoBase
		Private ReadOnly _sites() As SiteInfo

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary>
		''' Initializes the form base on the provided LoginInfo that is loaded from the Registry.
		''' </summary>
		''' <param name="s">The LoginInfo object.</param>
		Public Sub New(ByVal s As SettingInfoBase)
			InitializeComponent()

			_info = s

			txtServer.Text = s.Get(Of String)(LoginInfo.ServerName)
			txtPort.Text = s.Get(Of Integer)(LoginInfo.ServerPort).ToString()
			txtUserName.Text = s.Get(Of String)(LoginInfo.UserName)
			txtPassword.Text = s.Get(Of String)(LoginInfo.Password)
			txtRemoteDir.Text = s.Get(Of String)(LoginInfo.RemoteDir)
			txtLocalDir.Text = s.Get(Of String)(LoginInfo.LocalDir)

			chkUtf8Encoding.Checked = s.Get(Of Boolean)(LoginInfo.Utf8Encoding)

			txtProxyHost.Text = s.Get(Of String)(LoginInfo.ProxyServer)
			txtProxyPort.Text = s.Get(Of Integer)(LoginInfo.ProxyPort).ToString()
			txtProxyUser.Text = s.Get(Of String)(LoginInfo.ProxyUser)
			txtProxyPassword.Text = s.Get(Of String)(LoginInfo.ProxyPassword)
			txtProxyDomain.Text = s.Get(Of String)(LoginInfo.ProxyDomain)
			cbxProxyType.SelectedIndex = s.Get(Of Integer)(LoginInfo.ProxyType)
			cbxProxyMethod.SelectedIndex = s.Get(Of Integer)(LoginInfo.ProxyHttpAuthnMethod)

#If FTP Then
#If Not SFTP Then
			sftp.Visible = False
#End If
'			#Region "FTP"
			chkPasv.Checked = s.Get(Of Boolean)(FtpLoginInfo.PasvMode)
			txtCertificate.Text = s.Get(Of String)(FtpLoginInfo.Certificate)
			cbxSec.SelectedIndex = s.Get(Of Integer)(FtpLoginInfo.SecurityMode)
			chkClearCommandChannel.Checked = s.Get(Of Boolean)(FtpLoginInfo.ClearCommandChannel)
'			#End Region
#End If

#If SFTP Then
#If Not FTP Then
			ftp.Visible = False
			cbxSec.Visible = False

			' Remove FTP Proxy items.
			cbxProxyType.Items.RemoveAt(cbxProxyType.Items.Count - 1)
			cbxProxyType.Items.RemoveAt(cbxProxyType.Items.Count - 1)
			cbxProxyType.Items.RemoveAt(cbxProxyType.Items.Count - 1)
#End If
'			#Region "SFTP"
			chkCompress.Checked = s.Get(Of Boolean)(SftpLoginInfo.EnableCompression)
			txtPrivateKey.Text = s.Get(Of String)(SftpLoginInfo.PrivateKey)
'			#End Region
#End If

			Select Case s.Get(Of TraceEventType)(LoginInfo.LogLevel)
				Case TraceEventType.Error
					cbxLogLevel.SelectedIndex = 1

				Case TraceEventType.Information
					cbxLogLevel.SelectedIndex = 2

				Case TraceEventType.Verbose
					cbxLogLevel.SelectedIndex = 3

				Case TraceEventType.Transfer
					cbxLogLevel.SelectedIndex = 4

				Case Else ' None
					cbxLogLevel.SelectedIndex = 0
			End Select

			_sites = SiteLoader.GetSites()

			If _sites Is Nothing Then
				MessageBox.Show("FtpSites.xml not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				Return
			End If

			For Each info As SiteInfo In _sites
				cbxSites.Items.Add(info.Description)
			Next info
		End Sub

		''' <summary>
		''' Handles the Login button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin.Click
			Dim port As Integer
			' Check port number.
			Try
				port = Integer.Parse(txtPort.Text)
			Catch exc As Exception
				Util.ShowError(exc, "Invalid Port")
				Return
			End Try
			If port < 0 OrElse port > 65535 Then
				MessageBox.Show("Invalid port number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Return
			End If

			' Check server name.
			If txtServer.Text.Length = 0 Then
				MessageBox.Show("Host name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Return
			End If

			' Check proxy port.
			Dim proxyport As Integer
			Try
				proxyport = Integer.Parse(txtProxyPort.Text)
			Catch exc As Exception
				Util.ShowError(exc, "Invalid Proxy Port")
				Return
			End Try
			If proxyport < 0 OrElse proxyport > 65535 Then
				MessageBox.Show("Invalid port number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Return
			End If

			_info.Set(LoginInfo.ServerName, txtServer.Text)
			_info.Set(LoginInfo.ServerPort, Integer.Parse(txtPort.Text))
			_info.Set(LoginInfo.UserName, txtUserName.Text)
			_info.Set(LoginInfo.Password, txtPassword.Text)
			_info.Set(LoginInfo.RemoteDir, txtRemoteDir.Text)
			_info.Set(LoginInfo.LocalDir, txtLocalDir.Text)

			_info.Set(LoginInfo.Utf8Encoding, chkUtf8Encoding.Checked)

			_info.Set(LoginInfo.ProxyServer, txtProxyHost.Text)
			_info.Set(LoginInfo.ProxyPort, Integer.Parse(txtProxyPort.Text))
			_info.Set(LoginInfo.ProxyUser, txtProxyUser.Text)
			_info.Set(LoginInfo.ProxyPassword, txtProxyPassword.Text)
			_info.Set(LoginInfo.ProxyDomain, txtProxyDomain.Text)
			_info.Set(LoginInfo.ProxyType, cbxProxyType.SelectedIndex)
			_info.Set(LoginInfo.ProxyHttpAuthnMethod, cbxProxyMethod.SelectedIndex)

#If FTP Then
'			#Region "FTP"
			_info.Set(FtpLoginInfo.PasvMode, chkPasv.Checked)
			_info.Set(FtpLoginInfo.Certificate, txtCertificate.Text)
			_info.Set(FtpLoginInfo.SecurityMode, CType(cbxSec.SelectedIndex, SecurityMode))
			_info.Set(FtpLoginInfo.ClearCommandChannel, chkClearCommandChannel.Checked)
'			#End Region
#End If

#If SFTP Then
'			#Region "SFTP"
			_info.Set(SftpLoginInfo.EnableCompression, chkCompress.Checked)
			_info.Set(SftpLoginInfo.PrivateKey, txtPrivateKey.Text)
'			#End Region
#End If

			Select Case cbxLogLevel.SelectedIndex
				Case 0
					_info.Set(LoginInfo.LogLevel, 0)

				Case 1
					_info.Set(LoginInfo.LogLevel, CInt(TraceEventType.Error))

				Case 2
					_info.Set(LoginInfo.LogLevel, CInt(TraceEventType.Information))

				Case 3
					_info.Set(LoginInfo.LogLevel, CInt(TraceEventType.Verbose))

				Case 4
					_info.Set(LoginInfo.LogLevel, CInt(TraceEventType.Transfer))
			End Select

			DialogResult = System.Windows.Forms.DialogResult.OK
			Close()
		End Sub

		''' <summary>
		''' Handles the LocalDirBrowse button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnLocalDirBrowse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLocalDirBrowse.Click
			Try
				Dim dlg As New FolderBrowserDialog()
				dlg.Description = "Select local folder"
				dlg.SelectedPath = txtLocalDir.Text
				If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
					txtLocalDir.Text = dlg.SelectedPath
				End If
			Catch exc As Exception
				Util.ShowError(exc)
			End Try
		End Sub

		''' <summary>
		''' Handles the proxy type combobox's SelectedIndexChanged event.
		''' </summary>
		''' <param name="sender">The combobox</param>
		''' <param name="e">The event arguments.</param>
		Private Sub cbxProxy_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbxProxyMethod.SelectedIndexChanged, cbxProxyType.SelectedIndexChanged
			Dim enable As Boolean = cbxProxyType.SelectedIndex > 0
#If FTP Then
			Dim enableAuth As Boolean = cbxProxyType.SelectedIndex <> CInt(FtpProxyType.Site) AndAlso cbxProxyType.SelectedIndex <> CInt(FtpProxyType.Open) ' User name and password are ignored with Site and FtpOpen proxy types.
#Else
			Dim enableAuth As Boolean = True
#End If

			cbxProxyMethod.Enabled = cbxProxyType.SelectedIndex = CInt(FtpProxyType.HttpConnect) ' Authentication method is available for HTTP Connect only.
			txtProxyDomain.Enabled = cbxProxyMethod.Enabled AndAlso cbxProxyMethod.SelectedIndex = CInt(FtpProxyHttpConnectAuthMethod.Ntlm) ' Domain is available for NTLM authentication method only.
			txtProxyUser.Enabled = enable AndAlso enableAuth
			txtProxyPassword.Enabled = enable AndAlso enableAuth
			txtProxyHost.Enabled = enable ' Proxy host and port are not available in NoProxy type.
			txtProxyPort.Enabled = enable
		End Sub

		''' <summary>
		''' Handles the CertBrowse button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnCertBrowse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCertBrowse.Click
			Try
				Dim dlg As New OpenFileDialog()
				dlg.Title = "Select a certificate file"
				dlg.FileName = txtCertificate.Text
				dlg.Filter = "All files|*.*"
				dlg.FilterIndex = 1
				If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
					txtCertificate.Text = dlg.FileName
				End If
			Catch exc As Exception
				Util.ShowError(exc)
			End Try
		End Sub

		Private Sub cbxSec_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbxSec.SelectedIndexChanged
			Dim enable As Boolean = cbxSec.SelectedIndex > 0
			chkClearCommandChannel.Enabled = enable
			txtCertificate.Enabled = enable
			btnCertBrowse.Enabled = enable
		End Sub

		Private Sub cbxSites_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbxSites.SelectedIndexChanged
			If _sites IsNot Nothing Then
				Dim info As SiteInfo = _sites(cbxSites.SelectedIndex)

				txtServer.Text = info.Address
				If info.Port > 0 Then
					txtPort.Text = info.Port.ToString()
				Else
					txtPort.Text = String.Empty
				End If
				txtUserName.Text = info.UserName
				txtPassword.Text = info.Password
				cbxSec.SelectedIndex = info.Security
			End If
		End Sub

		Private Sub btnKeyBrowse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnKeyBrowse.Click
			Try
				Dim dlg As New OpenFileDialog()
				dlg.Title = "Select a private key file"
				dlg.FileName = txtPrivateKey.Text
				dlg.Filter = "All files|*.*"
				dlg.FilterIndex = 1
				If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
					txtPrivateKey.Text = dlg.FileName
				End If
			Catch exc As Exception
				Util.ShowError(exc)
			End Try
		End Sub
	End Class
End Namespace