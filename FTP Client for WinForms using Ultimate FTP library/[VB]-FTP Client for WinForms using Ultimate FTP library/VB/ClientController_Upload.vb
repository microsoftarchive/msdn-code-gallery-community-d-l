Imports System.IO
Imports System.Text
Imports ComponentPro
Imports ComponentPro.IO

Namespace ClientSample
	Partial Friend Class ClientController
#If Framework4_5 AndAlso ASYNC Then
		Public Async Sub DoLocalUpload(ByVal files() As AbstractFileInfo)
#Else
		Public Sub DoLocalUpload(ByVal files() As AbstractFileInfo)
#End If
			If _state <> ConnectionState.Ready Then
				Return
			End If

			EnableProgress(True)

			Dim showProgress As Boolean = _settings.Get(Of Boolean)(SettingInfo.ShowProgressWhileTransferring)

			Dim opt As New TransferOptions(showProgress, RecursionMode.RecurseIntoAllSubFolders, True, CType(Nothing, SearchCondition), FileExistsResolveAction.Confirm, SymlinksResolveAction.Confirm)

#If Framework4_5 OrElse (Not ASYNC) Then
			Try
				Dim stat As FileSystemTransferStatistics
#If Framework4_5 Then
				stat = Await client.UploadFilesAsync(_currentLocalDirectory, files, _currentDirectory, opt)
#Else
				stat = client.UploadFiles(_currentLocalDirectory, files, _currentDirectory, opt)
#End If
				ShowStatistics(stat, "upload")
			Catch ex As Exception
				If Not HandleException(ex) Then
					Return
				End If
			End Try

			EnableProgress(False)
			RefreshRemoteList()

#Else
			_client.UploadFilesAsync(_currentLocalDirectory, files, _currentDirectory, opt)
#End If
		End Sub

		Private Sub ShowStatistics(ByVal s As FileSystemTransferStatistics, ByVal direction As String)
			If s Is Nothing Then
				Throw New ArgumentNullException("s", "Statistics parameter is null.")
			End If

			If s.FilesTransferred > 0 Then
				_view.WriteLine(String.Format("{0} file(s) {4}ed in {3} second(s) - total size: {1} - {2} / second", s.FilesTransferred, Util.FormatSize(s.TotalBytes), Util.FormatSize(s.BytesPerSecond), s.ElapsedTime.TotalSeconds, direction), RichTextBoxTraceListener.TextColorInfo)
				_view.WriteLine(String.Format("Started time: {0}, ended time: {1}", s.Started.ToLocalTime(), s.Ended.ToLocalTime()), RichTextBoxTraceListener.TextColorInfo)
			End If
		End Sub

		''' <summary>
		''' Handles the client's UploadFilesCompleted event.
		''' </summary>
		''' <param name="sender">The client object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub client_UploadFilesCompleted(ByVal sender As Object, ByVal e As ExtendedAsyncCompletedEventArgs(Of FileSystemTransferStatistics))
			If e.Error IsNot Nothing Then
				If Not HandleException(e.Error) Then
					Return
				End If
			Else
				ShowStatistics(e.Result, "upload")
			End If

			EnableProgress(False)
			RefreshRemoteList()
		End Sub

#If FTP Then
		Public Sub DoLocalUploadUnique(ByVal localFile As String)
			CType(_clientPlugin, ClientSample.Ftp.FtpClientPlugin).DoLocalUploadUnique(localFile)
		End Sub
#End If

		Public Sub DoLocalResumeUpload(ByVal files() As AbstractFileInfo)
			EnableProgress(True)
			Try
				For i As Integer = 0 To files.Length - 1
					If _aborting Then
						Exit For
					End If

					Dim localFile As AbstractFileInfo = files(i)

					If localFile.IsFile Then
						' Upload a single file.
						Dim result As Long = _client.ResumeUploadFile(localFile.FullName, localFile.Name)

						If files.Length = 1 Then
							If result = -1 Then
							   _view.ShowMessage("Remote file size is greater than the local file size")
							ElseIf result = 0 Then
							   _view.ShowMessage("Remote file size is equal to the local file size")
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
			RefreshRemoteList()
		End Sub

		Public Sub GetTimeDiff()
			EnableProgress(True)

			Try
				' Get the time difference.
				Dim ts As TimeSpan = _client.GetServerTimeDifference()

				_view.ShowMessage(String.Format("The time difference between the client and server: {0}", ts))
			Catch exc As Exception
				HandleException(exc)
			Finally
				EnableProgress(False)
			End Try
		End Sub
	End Class
End Namespace