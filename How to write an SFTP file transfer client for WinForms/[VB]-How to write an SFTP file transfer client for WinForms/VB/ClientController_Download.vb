Imports System.IO
Imports ComponentPro
Imports ComponentPro.IO

Namespace ClientSample
	Partial Friend Class ClientController
		''' <summary>
		''' Downloads remote files.
		''' </summary>
		''' <param name="files">Files to download.</param>
		Public Sub DoRemoteDownload(ByVal files() As AbstractFileInfo)
			If _state <> ConnectionState.Ready Then
				Return
			End If

			EnableProgress(True)

			Dim showProgress As Boolean = _settings.Get(Of Boolean)(SettingInfo.ShowProgressWhileTransferring)

			Dim opt As New TransferOptions(showProgress, RecursionMode.RecurseIntoAllSubFolders, True, CType(Nothing, SearchCondition), FileExistsResolveAction.Confirm, SymlinksResolveAction.Confirm)

#If Framework4_5 OrElse (Not ASYNC) Then
			Dim stat As FileSystemTransferStatistics
			Try
#If Framework4_5 Then
				stat = Await client.DownloadFilesAsync(_currentDirectory, fileList, _currentLocalDirectory, opt)
#Else
				stat = client.DownloadFiles(_currentDirectory, fileList, _currentLocalDirectory, opt)
#End If
				ShowStatistics(stat, "download")
			Catch ex As Exception
				If Not HandleException(ex) Then
					Return
				End If
			End Try

			EnableProgress(False)
			RefreshLocalList()
#Else
			_client.DownloadFilesAsync(_currentDirectory, files, _currentLocalDirectory, opt)
#End If
		End Sub

		''' <summary>
		''' Handles the client's DownloadFilesCompleted event.
		''' </summary>
		''' <param name="sender">The client object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub client_DownloadFilesCompleted(ByVal sender As Object, ByVal e As ExtendedAsyncCompletedEventArgs(Of FileSystemTransferStatistics))
			If e.Error IsNot Nothing Then
				If Not HandleException(e.Error) Then
					Return
				End If
			Else
				ShowStatistics(e.Result, "download")
			End If

			EnableProgress(False)
			RefreshLocalList()
		End Sub

		''' <summary>
		''' Resumes download the specified files.
		''' </summary>
		''' <param name="files">Files to resume download.</param>
		Public Sub DoRemoteResumeDownload(ByVal files() As AbstractFileInfo)
			If files Is Nothing Then
				Return
			End If

			EnableProgress(True)
			Try
				For i As Integer = 0 To files.Length - 1
					If _aborting Then
						Exit For
					End If

					Dim remoteFile As AbstractFileInfo = files(i)

					If remoteFile.IsFile Then
						' Download a single file.
						Dim result As Long = _client.ResumeDownloadFile(remoteFile.Name, Path.Combine(_currentLocalDirectory, remoteFile.Name))

						If files.Length = 1 Then
							If result = -1 Then
								_view.ShowMessage("Local file size is greater than the remote file size")
							ElseIf result = 0 Then
								_view.ShowMessage("Local file size is equal to the remote file size")
							End If
						End If
					End If
				Next i
			Catch exc As Exception
				If Not HandleException(exc) Then
					Return
				End If
			End Try

			EnableProgress(False)
			RefreshLocalList()
		End Sub

		''' <summary>
		''' Views the remote file.
		''' </summary>
		''' <param name="name">File to view.</param>
		Public Sub DoRemoteView(ByVal name As String)
			Dim tempFile As String = Util.GetTempFileName(name)
			Dim remoteFile As String = name ' GetRemoteFullPath(item.Text);

			EnableProgress(True)

			AddHandler _client.DownloadFileCompleted, AddressOf client_GetFileForViewingCompleted
			_client.DownloadFileAsync(remoteFile, tempFile, tempFile)
		End Sub

		''' <summary>
		''' Handles the client's DownloadFileCompleted event.
		''' </summary>
		''' <param name="sender">The Ftp object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub client_GetFileForViewingCompleted(ByVal sender As Object, ByVal e As ExtendedAsyncCompletedEventArgs(Of Long))
			' Detach the event handler.
			RemoveHandler _client.DownloadFileCompleted, AddressOf client_GetFileForViewingCompleted

			Dim aborted As Boolean = False

			If e.Error IsNot Nothing Then
				If Not HandleException(e.Error) Then
					Return
				End If

				aborted = Util.IsFileSystemOperationCancelled(e.Error)
			End If

			' temporary file name is saved in the Async state object.
			Dim tempFile As String = CStr(e.UserState)

			DoRemoteViewPost(aborted, tempFile)
		End Sub

		Private Sub DoRemoteViewPost(ByVal aborted As Boolean, ByVal tempFile As String)
			EnableProgress(False)

			If _state = ConnectionState.Disconnecting Then
				Disconnect()
				Return
			End If

			If Not aborted Then
				Try
					Process.Start("Notepad.exe", tempFile)
				Catch exc As Exception
					_view.ShowError("Error:" & exc.Message)
				End Try
			End If
		End Sub
	End Class
End Namespace
