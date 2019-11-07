Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports ClientSample.Ftp.Security
Imports ComponentPro
Imports ComponentPro.IO
Imports ComponentPro.Net
Imports ComponentPro.Security.Certificates

Namespace ClientSample.Ftp
	Friend Class FtpClientPlugin
		Implements IClientPlugin
		Private _controller As ClientController
		Private _client As ComponentPro.Net.Ftp
		Private _view As IClientView
		Private _loginSettings As SettingInfoBase

		Public Sub New(ByVal view As IClientView, ByVal clientController As ClientController, ByVal loginSettings As SettingInfoBase)
			_view = view
			_controller = clientController
			_loginSettings = loginSettings
		End Sub

		Public Function Create() As IRemoteFileSystem Implements IClientPlugin.Create
			Dim client As New ComponentPro.Net.Ftp()

#If Not Framework4_5 Then
			AddHandler client.SetMultipleFilesPermissionsCompleted, AddressOf client_SetMultipleFilesPermissionsCompleted
			AddHandler client.UploadUniqueFileCompleted, AddressOf client_UploadUniqueFileCompleted
			AddHandler client.CertificateRequired, AddressOf client_CertificateRequired
			AddHandler client.CertificateReceived, AddressOf client_CertificateReceived
#End If

			_client = client

			Return _client
		End Function

		''' <summary>
		''' Handles the client's SetMultipleFilesPermissionsCompleted event.
		''' </summary>
		''' <param name="sender">The Ftp object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub client_SetMultipleFilesPermissionsCompleted(ByVal sender As Object, ByVal e As ExtendedAsyncCompletedEventArgs(Of FileSystemTransferStatistics))
			If e.Error IsNot Nothing Then
				If Not _controller.HandleException(e.Error) Then
					Return
				End If
			End If

			_controller.RefreshRemoteList()
			_controller.EnableProgress(False)
		End Sub

		Public Function GetPermissionsString(ByVal f As AbstractFileInfo) As String Implements IClientPlugin.GetPermissionsString
			If CType(f, FtpFileInfo).System = FtpFileOs.Unix Then
				Return ToPermissions(CType(f, FtpFileInfo).Permissions)
			Else
				Return "-"
			End If
		End Function

		Private Sub IClientPlugin_AuthenticatePost() Implements IClientPlugin.AuthenticatePost
			If _loginSettings.Get(Of Boolean)(FtpLoginInfo.ClearCommandChannel) AndAlso _loginSettings.Get(Of FtpSecurityMode)(FtpLoginInfo.SecurityMode) <> FtpSecurityMode.None Then
				CType(_client, ComponentPro.Net.Ftp).ClearCommandChannel()
			End If
		End Sub

		Public Function CanBeReconnected(ByVal exc As Exception) As Boolean Implements IClientPlugin.CanBeReconnected
			Dim fe As FtpException = TryCast(exc, FtpException)
			Dim se As System.Net.Sockets.SocketException

			If fe IsNot Nothing Then
				If fe.Status = FtpExceptionStatus.ConnectionClosed Then
					Return True
				End If
			Else
				se = TryCast(exc, System.Net.Sockets.SocketException)
				If (se IsNot Nothing AndAlso se.ErrorCode = 10053) OrElse exc.Message = "Not connected to the server." Then ' Connection was aborted by the software
					Return True
				End If
			End If

			Return False
		End Function

		Public Sub ApplyLoginSettings(ByVal settings As SettingInfoBase) Implements IClientPlugin.ApplyLoginSettings
			Dim ftp As ComponentPro.Net.Ftp = CType(_client, ComponentPro.Net.Ftp)

			ftp.Passive = _loginSettings.Get(Of Boolean)(FtpLoginInfo.PasvMode)

			Dim proxyServer As String = _loginSettings.Get(Of String)(LoginInfo.ProxyServer)
			Dim proxyPort As Integer = _loginSettings.Get(Of Integer)(LoginInfo.ProxyPort)

			If (Not String.IsNullOrEmpty(proxyServer)) AndAlso proxyPort > 0 Then
				Dim proxy As New FtpProxy()
				ftp.Proxy = proxy

				proxy.Server = proxyServer
				proxy.Port = proxyPort
				proxy.UserName = _loginSettings.Get(Of String)(LoginInfo.ProxyUser)
				proxy.Password = _loginSettings.Get(Of String)(LoginInfo.ProxyPassword)
				proxy.Domain = _loginSettings.Get(Of String)(LoginInfo.ProxyDomain)
				proxy.ProxyType = _loginSettings.Get(Of FtpProxyType)(LoginInfo.ProxyType)
				proxy.AuthenticationMethod = _loginSettings.Get(Of FtpProxyHttpConnectAuthMethod)(LoginInfo.ProxyHttpAuthnMethod)
			End If
		End Sub

		Public Sub ApplySettings(ByVal settings As SettingInfoBase) Implements IClientPlugin.ApplySettings
			Dim client As ComponentPro.Net.Ftp = CType(_client, ComponentPro.Net.Ftp)

			client.Config.KeepAliveDuringIdleInterval = settings.Get(Of Integer)(SettingInfo.KeepAlive)
			If settings.Get(Of Boolean)(FtpSettingInfo.Compress) Then
				client.TransferMode = FtpTransferMode.ZlibCompressed
			Else
				client.TransferMode = FtpTransferMode.Stream
			End If
			client.Config.SendAbortCommand = settings.Get(Of OptionValue)(FtpSettingInfo.SendAborCommand)
			client.Config.SendTelnetInterruptSignal = settings.Get(Of Boolean)(FtpSettingInfo.SendAbortSignals)
			client.ChangeDirectoryBeforeFileOperation = settings.Get(Of Boolean)(FtpSettingInfo.ChangeDirBeforeTransfer)
			client.ChangeDirectoryBeforeListing = settings.Get(Of Boolean)(FtpSettingInfo.ChangeDirBeforeListing)
			client.Config.SmartPathResolving = settings.Get(Of Boolean)(FtpSettingInfo.SmartPath)
		End Sub

		''' <summary>
		''' Returns all issues of the given certificate.
		''' </summary>
		Private Shared Function GetCertProblem(ByVal status As CertificateVerificationStatus, ByVal code As Integer, ByRef showAddTrusted As Boolean) As String
			Select Case status
				Case CertificateVerificationStatus.TimeNotValid
					Return "Server's certificate has expired or is not valid yet."

				Case CertificateVerificationStatus.Revoked
					Return "Server's certificate has been revoked."

				Case CertificateVerificationStatus.UnknownCA
					Return "Server's certificate was issued by an unknown authority."

				Case CertificateVerificationStatus.RootNotTrusted
					showAddTrusted = True
					Return "Server's certificate was issued by an untrusted authority."

				Case CertificateVerificationStatus.IncompleteChain
					Return "Server's certificate does not chain up to a trusted root authority."

				Case CertificateVerificationStatus.Malformed
					Return "Server's certificate is malformed."

				Case CertificateVerificationStatus.CNNotMatch
					Return "Server hostname does not match the certificate."

				Case CertificateVerificationStatus.UnknownError
					Return String.Format("Error {0:x} encountered while validating server's certificate.", code)

				Case Else
					Return status.ToString()
			End Select
		End Function

		Private Sub client_CertificateReceived(ByVal sender As Object, ByVal e As ComponentPro.Security.CertificateReceivedEventArgs)
			Dim dlg As New CertValidator()

			Dim status As CertificateVerificationStatus = e.Status

			Dim values() As CertificateVerificationStatus = CType(System.Enum.GetValues(GetType(CertificateVerificationStatus)), CertificateVerificationStatus())

			Dim sbIssues As New StringBuilder()
			Dim showAddTrusted As Boolean = False
			For i As Integer = 0 To values.Length - 1
				' Matches the validation status?
				If (status And values(i)) = 0 Then
					Continue For
				End If

				' The issue is processed.
				status = status Xor values(i)

				sbIssues.AppendFormat("{0}" & vbCrLf, GetCertProblem(values(i), e.ErrorCode, showAddTrusted))
			Next i

			dlg.Certificate = e.ServerCertificates(0)
			dlg.Issues = sbIssues.ToString()
			dlg.ShowAddToTrustedList = showAddTrusted

			dlg.ShowDialog()

			e.AddToTrustedRoot = dlg.AddToTrustedList
			e.Accept = dlg.Accepted
		End Sub

		Private Sub client_CertificateRequired(ByVal sender As Object, ByVal e As ComponentPro.Security.CertificateRequiredEventArgs)
			Dim cert As String = _loginSettings.Get(Of String)(FtpLoginInfo.Certificate)

			' If the client cert file is specified.
			If Not String.IsNullOrEmpty(cert) Then
				' Load Certificate.
				Dim passdlg As New PasswordPrompt("Please provide password for certificate")
				' Ask for cert's passpharse
				If passdlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
					Dim clientCert As New X509Certificate2(cert, passdlg.Password)
					e.Certificates = New X509Certificate2Collection(clientCert)
					Return
				End If

				' Password has not been provided.
			End If
			Dim dlg As New CertProvider()
			dlg.ShowDialog()
			' Get the selected certificate.
			e.Certificates = New X509Certificate2Collection(dlg.SelectedCertificate)
		End Sub

		''' <summary>
		''' Parses permissions from the given permissions string.
		''' </summary>
		''' <param name="data">The permissions string.</param>
		Private Shared Function ToPermissions(ByVal data As FtpFilePermissions) As String
			Return Convert.ToString(CUInt(data), 8) & "  " & FtpFileInfo.GetPermissionsString(data)
		End Function

		Public Sub Connect() Implements IClientPlugin.Connect
			_client.ConnectAsync(_loginSettings.Get(Of String)(LoginInfo.ServerName), _loginSettings.Get(Of Integer)(LoginInfo.ServerPort), _loginSettings.Get(Of FtpSecurityMode)(FtpLoginInfo.SecurityMode))
		End Sub

		Public Sub Authenticate() Implements IClientPlugin.Authenticate
			' Asynchronously login.
			_client.AuthenticateAsync(_loginSettings.Get(Of String)(LoginInfo.UserName), _loginSettings.Get(Of String)(LoginInfo.Password))
		End Sub

		Public Sub DoSetFilePermissions(ByVal files() As AbstractFileInfo, ByVal permissions As String, ByVal recursive As Boolean)
			Dim showProgress As Boolean = _controller.Settings.Get(Of Boolean)(SettingInfo.ShowProgressWhileDeleting)

			_controller.EnableProgress(True)
#If Framework4_5 OrElse (Not ASYNC) Then
			Try
#If Framework4_5 Then
				' Asynchronously set permissions of multiple files.
				If recursive Then
					Await client.SetMultipleFilesPermissionsAsync(_currentDirectory, files, permissions, showProgress,RecursionMode.RecurseIntoAllSubFolders, Nothing)
				Else
					Await client.SetMultipleFilesPermissionsAsync(_currentDirectory, files, permissions, showProgress,RecursionMode.None, Nothing)
				End If
#Else
				If recursive Then
					client.SetMultipleFilesPermissions(_currentDirectory, files, permissions, showProgress,RecursionMode.RecurseIntoAllSubFolders, Nothing)
				Else
					client.SetMultipleFilesPermissions(_currentDirectory, files, permissions, showProgress,RecursionMode.None, Nothing)
				End If
#End If
			Catch ex As Exception
				If Not HandleException(exc) Then
					Return
				End If
			End Try

			RefreshRemoteList()
			EnableProgress(False)
#Else
			If recursive Then
				_client.SetMultipleFilesPermissionsAsync(_controller.CurrentRemoteDirectory, files, permissions, showProgress,RecursionMode.RecurseIntoAllSubFolders, Nothing)
			Else
				_client.SetMultipleFilesPermissionsAsync(_controller.CurrentRemoteDirectory, files, permissions, showProgress,RecursionMode.None, Nothing)
			End If
#End If
		End Sub

		Public Sub DoLocalUploadUnique(ByVal localFile As String)
			_controller.EnableProgress(True)

#If Framework4_5 Then
			Try
				' Asynchronously upload unique the selected file.
				Await client.UploadUniqueFileAsync(localFile)
			Catch ex As Exception
				If Not HandleException(e.Error) Then
					Return
				End If
			End Try
#Else
			' Asynchronously upload unique the selected file.
			_client.UploadUniqueFileAsync(localFile)
#End If
		End Sub

		''' <summary>
		''' Handles the client's UploadUniqueCompleted event.
		''' </summary>
		''' <param name="sender">The Ftp object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub client_UploadUniqueFileCompleted(ByVal sender As Object, ByVal e As ExtendedAsyncCompletedEventArgs(Of String))
			If e.Error IsNot Nothing Then
				If Not _controller.HandleException(e.Error) Then
					Return
				End If
			End If

			_controller.EnableProgress(False)
			_controller.RefreshRemoteList()
		End Sub
	End Class
End Namespace
