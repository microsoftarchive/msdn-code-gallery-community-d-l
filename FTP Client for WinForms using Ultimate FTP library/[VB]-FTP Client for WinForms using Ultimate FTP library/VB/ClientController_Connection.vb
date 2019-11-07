Imports System.ComponentModel
Imports System.Text
Imports System.Threading
Imports ClientSample.Ftp
Imports ComponentPro
Imports ComponentPro.Diagnostics
Imports ComponentPro.IO
Imports ComponentPro.Net

Namespace ClientSample
	Friend Enum ConnectionState
		NotConnected
		Connecting
		Ready
		Disconnecting
		WrongServerType
	End Enum

	Partial Friend Class ClientController
		#Region "ConnectionState"

		#End Region

		Public Sub Cancel()
			_client.Cancel()

			' Set aborting state = true.
			_aborting = True
		End Sub

		Private Sub SetState(ByVal state As ConnectionState)
			_state = state
		End Sub

		''' <summary>
		''' Initializes the client objects.
		''' </summary>
		''' <param name="serverType">-1: Autodetect, 0: FTP, 1: SFTP</param>
		Private Sub InitClient(ByVal serverType As Integer)
			If _client IsNot Nothing Then
				_client.Disconnect()
			End If

#If FTP AndAlso SFTP Then
			If serverType = -1 Then
				' Auto detect.
				If _loginInfo.Get(Of Integer)(LoginInfo.ServerPort) = 22 Then
					serverType = 1
				Else
					serverType = 0
				End If
			End If

			If serverType = 1 Then
				_clientPlugin = New ClientSample.Sftp.SftpClientPlugin(_view, Me, _loginInfo)
				_serverType = ServerProtocol.Sftp
			Else
				_clientPlugin = New ClientSample.Ftp.FtpClientPlugin(_view, Me, _loginInfo)
				_serverType = ServerProtocol.Ftp
			End If
#ElseIf FTP Then
			_clientPlugin = New ClientSample.Ftp.FtpClientPlugin(_view, Me, _loginInfo)
			_serverType = ServerProtocol.Ftp
#ElseIf SFTP Then
			_clientPlugin = New ClientSample.Sftp.SftpClientPlugin(_view, Me, _loginInfo)
			_serverType = ServerProtocol.Sftp
#End If
			_client = _clientPlugin.Create()

#If Not Framework4_5 Then
			AddHandler _client.ConnectCompleted, AddressOf client_ConnectCompleted
			AddHandler _client.DisconnectCompleted, AddressOf client_DisconnectCompleted
			AddHandler _client.TransferConfirm, AddressOf client_TransferConfirm
			AddHandler _client.Progress, AddressOf client_Progress
			AddHandler _client.AuthenticateCompleted, AddressOf client_LoginCompleted
			AddHandler _client.DownloadFilesCompleted, AddressOf client_DownloadFilesCompleted
			AddHandler _client.MirrorCompleted, AddressOf client_MirrorCompleted
			AddHandler _client.UploadFilesCompleted, AddressOf client_UploadFilesCompleted
			AddHandler _client.ListDirectoryCompleted, AddressOf client_ListDirectoryCompleted
			AddHandler _client.MoveFilesCompleted, AddressOf client_MoveFilesCompleted
			AddHandler _client.DeleteFilesCompleted, AddressOf client_DeleteFilesCompleted
#End If
		End Sub

		''' <summary>
		''' Determines whether the exception indicates that the connection should be reconnected.
		''' </summary>
		''' <param name="exc"></param>
		''' <returns>true if the caller can continue; otherwise is false.</returns>
		Friend Function HandleException(ByVal exc As Exception) As Boolean
			Return HandleException(exc, True)
		End Function

		' returns true if the caller can continue; otherwise is false.
		Friend Function HandleException(ByVal exc As Exception, ByVal showError As Boolean) As Boolean
			If exc.InnerException IsNot Nothing Then
				exc = exc.InnerException
			End If

			Dim foe As FileSystemException = TryCast(exc, FileSystemException)
			If foe IsNot Nothing AndAlso foe.Status = FileSystemExceptionStatus.OperationCancelled Then
				Return True
			End If

			If _clientPlugin.CanBeReconnected(exc) Then
				Reconnect()
				Return False
			End If

			If showError Then
				_view.ShowError(exc)
			End If
			Return True
		End Function

		''' <summary>
		''' Reconnects after receiving an exception showing that the connection has been closed unexpectedly.
		''' </summary>
		Private Sub Reconnect()
			Try
				' Disconnect first.
				_client.Disconnect()
			Catch
			End Try

			_reconnecting = True
			_view.EnableLogin(LoginEnableState.LoginDisabled)
			_clientPlugin.Connect()
		End Sub

		''' <summary>
		''' Connects to the server.
		''' </summary>
		Public Sub DoConnect()
			InitClient(-1)

			_client.Timeout = _settings.Get(Of Integer)(SettingInfo.Timeout) * 1000
			_client.MaxDownloadSpeed = _settings.Get(Of Integer)(SettingInfo.Throttle)
			_client.MaxUploadSpeed = _settings.Get(Of Integer)(SettingInfo.Throttle)
			If _settings.Get(Of Boolean)(SettingInfo.AsciiTransfer) Then
				_client.TransferType = FileTransferType.Ascii
			Else
				_client.TransferType = FileTransferType.Binary
			End If
			_client.ProgressInterval = _settings.Get(Of Integer)(SettingInfo.ProgressUpdateInterval)

			If _loginInfo.Get(Of Boolean)(LoginInfo.Utf8Encoding) Then
				_client.Encoding = Encoding.UTF8
			End If

			_clientPlugin.ApplySettings(_settings)
			_clientPlugin.ApplyLoginSettings(_loginInfo)

			' Disable login/connect view.
			_view.EnableLogin(LoginEnableState.LoginDisabled)

			SetState(ConnectionState.Connecting)

			If XTrace.Listeners.Count = 0 Then
				XTrace.Listeners.Add(_view.GetLogger())

#If LOGFILE Then
				' Add the UltimateConsoleTraceListener listener to write to Console.
				XTrace.Listeners.Add(New UltimateConsoleTraceListener())
				' Add the UltimateTextWriterTraceListener listener to write to a file.
				XTrace.Listeners.Add(New UltimateTextWriterTraceListener("log.log"))
#End If
			End If

			' Set log level.
			XTrace.Level = _loginInfo.Get(Of TraceEventType)(LoginInfo.LogLevel)

			' Asynchronously connect to the server. ConnectCompleted event will be fired when the operation completes.
			_clientPlugin.Connect()
		End Sub

		''' <summary>
		''' Closes the connection.
		''' </summary>
#If Framework4_5 AndAlso ASYNC Then
		Public Async Sub Disconnect()
#Else
		Public Sub Disconnect()
#End If
			If _client Is Nothing Then
				Return
			End If

			_state = ConnectionState.Disconnecting

#If Framework4_5 Then
			Try
#If Not ASYNC Then
				client.Disconnect()
#Else
				' Asynchronously disconnect.
				Await client.DisconnectAsync()
#End If
			Catch exc As Exception
				Util.ShowError(exc)
			End Try

			ReEnableForm()
#Else
			' Asynchronously disconnect.
			_client.DisconnectAsync()
#End If
		End Sub

		Private Sub ReEnableForm()
			_view.EnableLogin(LoginEnableState.LoginEnabled)
			_state = ConnectionState.NotConnected
		End Sub

		Private _mirrorSavedRestoreState As Integer = -1
		''' <summary>
		''' Synchronizes local and remote folders.
		''' </summary>
		Public Sub DoMirror(ByVal remoteIsMaster As Boolean)
			EnableProgress(True)

			Dim opt As New MirrorOptions()
			opt.Recursive = _loginInfo.Get(Of RecursionMode)(LoginInfo.SyncRecursive)
			opt.SearchCondition = New NameSearchCondition(_loginInfo.Get(Of String)(LoginInfo.SyncSearchPattern))

			If _client.RestoreFileProperties Then
				_mirrorSavedRestoreState = 1
			Else
				_mirrorSavedRestoreState = 0
			End If
			_client.RestoreFileProperties = _loginInfo.Get(Of Boolean)(LoginInfo.SyncDateTime)

			Select Case _loginInfo.Get(Of Integer)(LoginInfo.SyncMethod)
				Case 0
					opt.Comparer = FileComparers.FileLastWriteTimeComparer

				Case 1
					If _loginInfo.Get(Of Boolean)(LoginInfo.SyncResumability) Then
						opt.Comparer = FileComparers.FileContentComparerWithResumabilityCheck
					Else
						opt.Comparer = FileComparers.FileContentComparer
					End If

				Case 2
					opt.Comparer = FileComparers.FileNameComparer
			End Select

#If Framework4_5 OrElse (Not ASYNC) Then
			Try
#If Not ASYNC Then
				' Asynchronously synchronize folders.
				client.MirrorAsync(txtRemoteDir.Text, txtLocalDir.Text, dlg.RemoteIsMaster, opt, dlg.RemoteIsMaster)
#Else
				client.Mirror(txtRemoteDir.Text, txtLocalDir.Text, dlg.RemoteIsMaster, opt)
#End If
			Catch ex As Exception
			End Try

			DoMirrorPost(dlg.RemoteIsMaster)
#Else
			' Asynchronously synchronize folders.
			_client.MirrorAsync(_currentDirectory, _currentLocalDirectory, remoteIsMaster, opt, remoteIsMaster)
#End If
		End Sub

		Private Sub DoMirrorPost(ByVal remoteIsMaster As Boolean)
			EnableProgress(False)

			If remoteIsMaster Then
				RefreshLocalList()
			Else
				RefreshRemoteList()
			End If

			If _mirrorSavedRestoreState <> -1 Then
				_client.RestoreFileProperties = _mirrorSavedRestoreState = 1
				_mirrorSavedRestoreState = -1
			End If
		End Sub

#If Not Framework4_5 Then
		''' <summary>
		''' Handles the client's MirrorCompleted event.
		''' </summary>
		''' <param name="sender">The Ftp object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub client_MirrorCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
			Dim remoteIsMaster As Boolean = CBool(e.UserState)

			If e.Error IsNot Nothing Then
				If Not HandleException(e.Error) Then
					Return
				End If
			End If

			DoMirrorPost(remoteIsMaster)
		End Sub

		Private Sub client_MoveFilesCompleted(ByVal sender As Object, ByVal e As ExtendedAsyncCompletedEventArgs(Of FileSystemTransferStatistics))
			If e.Error IsNot Nothing Then
				If Not HandleException(e.Error) Then
					Return
				End If
			End If

			RefreshRemoteList()

			EnableProgress(False)
		End Sub

		Private Sub client_DeleteFilesCompleted(ByVal sender As Object, ByVal e As ComponentPro.ExtendedAsyncCompletedEventArgs(Of FileSystemTransferStatistics))
			If e.Error IsNot Nothing Then
				If Not HandleException(e.Error) Then
					Return
				End If
			End If

			EnableProgress(False)
			RefreshRemoteList()
		End Sub

		Private Sub client_TransferConfirm(ByVal sender As Object, ByVal e As TransferConfirmEventArgs)
			_view.AskOverwrite(e)
		End Sub

		''' <summary>
		''' Handles the client's DisconnectCompleted event.
		''' </summary>
		''' <param name="sender">The Ftp object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub client_DisconnectCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
			_client = Nothing
			_clientPlugin = Nothing

			If e.Error IsNot Nothing Then
				_view.ShowError(e.Error)
			End If

			ReEnableForm()
		End Sub

		''' <summary>
		''' Handles the client's ConnectCompleted event.
		''' </summary>
		''' <param name="sender">The Ftp object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub client_ConnectCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
			If e.Error IsNot Nothing Then
#If FTP AndAlso SFTP Then
				Dim msg As String
				If e.Error.InnerException IsNot Nothing Then
					msg = e.Error.InnerException.Message
				Else
					msg = e.Error.Message
				End If
				Dim serverKind As Integer = -1

				If msg.IndexOf("connect to an FTP or FTP/SSL") <> -1 Then
					serverKind = 0
				ElseIf msg.IndexOf("connect to an SSH server") <> -1 Then
					serverKind = 1
				End If

				If serverKind <> -1 Then
					' This might be an FTP or SFTP server.
					' Indicate that the client need to connect using a different protocol.
					InitClient(serverKind)
					_clientPlugin.Connect()
				Else
					Util.ShowError(e.Error)
					Disconnect()
				End If
#Else
				Util.ShowError(e.Error)
				Disconnect()
#End If
				Return
			End If

			If _state = ConnectionState.Disconnecting Then
				Disconnect()
				Return
			End If

			DoLogin()
		End Sub

		''' <summary>
		''' Handles the client's AuthenticateCompleted event.
		''' </summary>
		''' <param name="sender">The Ftp object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub client_LoginCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
			If e.Error IsNot Nothing Then
				Util.ShowError(e.Error)
				Disconnect()
				Return
			End If

			If _state = ConnectionState.Disconnecting Then
				Disconnect()
				Return
			End If

			DoAuthenticatePost()
		End Sub
#End If

		Private Sub DoLogin()
			_clientPlugin.Authenticate()
		End Sub

		Protected Overridable Sub DoAuthenticatePost()
			Try
				_state = ConnectionState.Ready

				If Not _reconnecting Then
					_currentDirectory = _loginInfo.Get(Of String)(LoginInfo.RemoteDir)
				Else
					_reconnecting = False
				End If

				If _currentDirectory.Length = 0 Then ' Empty means default user's folder.
					' Get current directory.
					_currentDirectory = _client.GetCurrentDirectory()
				Else
					_client.SetCurrentDirectory(_currentDirectory)
				End If
			Catch exc As Exception
				Util.ShowError(exc)
				Disconnect()
				Return
			End Try

			' Update the remote dir text box.
			_view.UpdateRemotePath(_currentDirectory)

			' Allow disconnect.
			_view.EnableLogin(LoginEnableState.LogoutEnabled)

			' Show remote files.
			RefreshRemoteList()
		End Sub
	End Class
End Namespace