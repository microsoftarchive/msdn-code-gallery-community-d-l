Imports System.Collections
Imports System.Net.Sockets
Imports System.Text
Imports ClientSample.Sftp
Imports ComponentPro
Imports ComponentPro.IO
Imports ComponentPro.Net

Namespace ClientSample.Sftp
	Friend Class SftpClientPlugin
		Implements IClientPlugin
		Private _controller As ClientController
		Private _client As ComponentPro.Net.Sftp
		Private _view As IClientView
		Private _loginSettings As SettingInfoBase

		Public Sub New(ByVal view As IClientView, ByVal clientController As ClientController, ByVal loginSettings As SettingInfoBase)
			_view = view
			_controller = clientController
			_loginSettings = loginSettings
		End Sub

		Public Function Create() As IRemoteFileSystem Implements IClientPlugin.Create
			Dim client As New ComponentPro.Net.Sftp()

			AddHandler client.SetMultipleFilesAttributesCompleted, AddressOf client_SetMultipleFilesAttributesCompleted
			AddHandler client.HostKeyVerifying, AddressOf client_CheckingFingerprint

			_client = client

			Return client
		End Function

		Private Sub client_SetMultipleFilesAttributesCompleted(ByVal sender As Object, ByVal e As ExtendedAsyncCompletedEventArgs(Of FileSystemTransferStatistics))
			If e.Error IsNot Nothing Then
				If Not _controller.HandleException(e.Error) Then
					Return
				End If
			End If

			_controller.RefreshRemoteList()
			_controller.EnableProgress(False)
		End Sub

		Public Sub Connect() Implements IClientPlugin.Connect
			_client.ConnectAsync(_loginSettings.Get(Of String)(LoginInfo.ServerName), _loginSettings.Get(Of Integer)(LoginInfo.ServerPort))
		End Sub

		Public Function ShouldReconnect(ByVal exc As Exception) As Boolean Implements IClientPlugin.ShouldReconnect
			Dim fe As SftpException = TryCast(exc, SftpException)
			Dim se As SocketException

			If fe IsNot Nothing Then
				If fe.Status = SftpExceptionStatus.ConnectionClosed Then
					Return True
				End If
			Else
				se = TryCast(exc, SocketException)
				If (se IsNot Nothing AndAlso se.ErrorCode = 10053) OrElse exc.Message = "Not connected to the server." Then ' Connection was aborted by the software
					Return True
				End If
			End If

			Return False
		End Function

		Public Function GetPermissionsString(ByVal f As AbstractFileInfo) As String Implements IClientPlugin.GetPermissionsString
			Return ToPermissions(CType(f, SftpFileInfo).Permissions)
		End Function

		Private Sub IClientPlugin_OnAuthenticated() Implements IClientPlugin.OnAuthenticated

		End Sub

		Private ReadOnly _acceptedKeys As New Hashtable()

		Private Sub client_CheckingFingerprint(ByVal sender As Object, ByVal e As ComponentPro.Net.HostKeyVerifyingEventArgs)
			Dim key As String = e.HostKey
			If _acceptedKeys.ContainsKey(key) Then
				e.Accept = True
				Return
			End If

			Dim dlg As New UnknownHostKey(_loginSettings.Get(Of String)(LoginInfo.ServerName), _loginSettings.Get(Of Integer)(LoginInfo.ServerPort), "ssh-" & e.HostKeyAlgorithm & " " & key)
			If dlg.ShowDialog() = DialogResult.OK Then
				If dlg.AlwaysAccept Then
					' Add to the cache.
					_acceptedKeys.Add(key, True)
				End If

				e.Accept = True
			End If
		End Sub

		Public Sub ApplyLoginSettings(ByVal settings As SettingInfoBase) Implements IClientPlugin.ApplyLoginSettings
			Dim sftp As ComponentPro.Net.Sftp = CType(_client, ComponentPro.Net.Sftp)

			Dim proxyServer As String = _loginSettings.Get(Of String)(LoginInfo.ProxyServer)
			Dim proxyPort As Integer = _loginSettings.Get(Of Integer)(LoginInfo.ProxyPort)

			If (Not String.IsNullOrEmpty(proxyServer)) AndAlso proxyPort > 0 Then
				Dim proxy As New WebProxyEx()
				sftp.Proxy = proxy

				proxy.Server = proxyServer
				proxy.Port = proxyPort
				proxy.UserName = _loginSettings.Get(Of String)(LoginInfo.ProxyUser)
				proxy.Password = _loginSettings.Get(Of String)(LoginInfo.ProxyPassword)
				proxy.Domain = _loginSettings.Get(Of String)(LoginInfo.ProxyDomain)
				proxy.ProxyType = _loginSettings.Get(Of ProxyType)(LoginInfo.ProxyType)
				proxy.AuthenticationMethod = _loginSettings.Get(Of ProxyHttpConnectAuthMethod)(LoginInfo.ProxyHttpAuthnMethod)
			End If

			sftp.Config.CompressionEnabled = _loginSettings.Get(Of Boolean)(SftpLoginInfo.EnableCompression)
		End Sub

		Public Sub ApplySettings(ByVal settings As SettingInfoBase) Implements IClientPlugin.ApplySettings
			If settings.Get(Of Integer)(SftpSettingInfo.ServerOs) <> 0 Then
				_client.ServerOs = CType(settings.Get(Of Integer)(SftpSettingInfo.ServerOs) - 1, RemoteServerOs)
			End If
		End Sub

		Private Shared Function GetPermissionChar(ByVal p As SftpFilePermissions, ByVal mask As SftpFilePermissions, ByVal ch As Char) As Char
			If (p And mask) = mask Then
				Return ch
			Else
				Return "-"c
			End If
		End Function

		''' <summary>
		''' Parses permissions from the given permissions string.
		''' </summary>
		''' <param name="p">The permissions string.</param>
		Private Shared Function ToPermissions(ByVal p As SftpFilePermissions) As String
			Dim permissions As String = Convert.ToString(CInt(Fix(p)), 16).PadLeft(3, "0"c) & " "

			permissions &= GetPermissionChar(p, SftpFilePermissions.GroupExecute, "x"c)
			permissions &= GetPermissionChar(p, SftpFilePermissions.GroupRead, "r"c)
			permissions &= GetPermissionChar(p, SftpFilePermissions.GroupWrite, "w"c)
			permissions &= GetPermissionChar(p, SftpFilePermissions.OthersExecute, "x"c)
			permissions &= GetPermissionChar(p, SftpFilePermissions.OthersRead, "r"c)
			permissions &= GetPermissionChar(p, SftpFilePermissions.OthersWrite, "w"c)
			permissions &= GetPermissionChar(p, SftpFilePermissions.OwnerExecute, "x"c)
			permissions &= GetPermissionChar(p, SftpFilePermissions.OwnerRead, "r"c)
			permissions &= GetPermissionChar(p, SftpFilePermissions.OwnerWrite, "w"c)

			Return permissions
		End Function

		Public Sub Authenticate() Implements IClientPlugin.Authenticate
			Dim privateKey As String = _loginSettings.Get(Of String)(SftpLoginInfo.PrivateKey)
			Dim userName As String = _loginSettings.Get(Of String)(LoginInfo.UserName)
			Dim password As String = _loginSettings.Get(Of String)(LoginInfo.Password)

			Dim key As SecureShellPrivateKey

			If String.IsNullOrEmpty(privateKey) Then
				key = Nothing
			Else
				Dim keypassword As String = _view.AskForPassword("Please provide password for the key")
				If String.IsNullOrEmpty(password) Then
					_view.ShowError(Messages.NoPassword)
					_controller.Disconnect()
					Return
				End If

				' try to load the key.
				Try
					key = New SecureShellPrivateKey(privateKey, keypassword)
				Catch exc As Exception
					Util.ShowError(exc)
					_controller.Disconnect()
					Return
				End Try
			End If

			_client.AuthenticateAsync(userName, password, key)
		End Sub

		Public Sub DoSetFileAttributes(ByVal files() As AbstractFileInfo, ByVal attr As SftpFileAttributes, ByVal recursive As Boolean)
			Dim showProgress As Boolean = _controller.Settings.Get(Of Boolean)(SettingInfo.ShowProgressWhileDeleting)

			_controller.EnableProgress(True)
#If Framework4_5 OrElse (Not ASYNC) Then
			Try
#If Framework4_5 Then
				' Asynchronously set permissions of multiple files.
				If recursive Then
					Await sftp.SetMultipleFilesPermissionsAsync(_currentDirectory, files, permissions, showProgress,RecursionMode.RecurseIntoAllSubFolders, Nothing)
				Else
					Await sftp.SetMultipleFilesPermissionsAsync(_currentDirectory, files, permissions, showProgress,RecursionMode.None, Nothing)
				End If
#Else
				If recursive Then
					sftp.SetMultipleFilesPermissions(_currentDirectory, files, permissions, showProgress,RecursionMode.RecurseIntoAllSubFolders, Nothing)
				Else
					sftp.SetMultipleFilesPermissions(_currentDirectory, files, permissions, showProgress,RecursionMode.None, Nothing)
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
				_client.SetMultipleFilesAttributesAsync(_controller.CurrentRemoteDirectory, files, attr, showProgress,RecursionMode.RecurseIntoAllSubFolders, Nothing)
			Else
				_client.SetMultipleFilesAttributesAsync(_controller.CurrentRemoteDirectory, files, attr, showProgress,RecursionMode.None, Nothing)
			End If
#End If
		End Sub

	End Class
End Namespace
