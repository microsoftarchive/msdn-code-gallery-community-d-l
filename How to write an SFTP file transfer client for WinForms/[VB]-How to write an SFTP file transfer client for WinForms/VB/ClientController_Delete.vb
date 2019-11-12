Imports ComponentPro.IO

Namespace ClientSample
	Partial Friend Class ClientController
		''' <summary>
		''' Deletes files.
		''' </summary>
		''' <param name="files">Files to delete.</param>
		''' <param name="local">Indicate whether the list contains local files.</param>
		''' <param name="searchCondition">The search condition.</param>
		Private Sub DeleteFiles(ByVal files() As AbstractFileInfo, ByVal local As Boolean, ByVal searchCondition As SearchCondition)
			If files Is Nothing Then
				Return
			End If

			If files.Length = 1 Then
				' User really wants to do that?
				If Not _view.AskYesNo(String.Format(Messages.MessageDeleteFolder, files(0).FullName)) Then
					Return
				End If
			Else
				' Delete multiple files/folders.
				If Not _view.AskYesNo(String.Format(Messages.MessageDeleteItems, files.Length)) Then
					Return
				End If
			End If

			EnableProgress(True)

			Dim showProgress As Boolean = _settings.Get(Of Boolean)(SettingInfo.ShowProgressWhileDeleting)

			If local Then
				Try
					DiskFileSystem.Default.DeleteFiles(_currentLocalDirectory, files, showProgress, RecursionMode.RecurseIntoAllSubFolders, True, searchCondition)
				Catch ex As Exception
					_view.ShowError(ex)
				End Try

				EnableProgress(False)
				RefreshLocalList()

				Return
			End If
#If Framework4_5 OrElse (Not ASYNC) Then
			Try
#If Framework4_5 Then
				Await _client.DeleteFilesAsync(_currentDirectory, files, _ftpSettings.ShowProgressWhileDeleting, RecursionMode.RecurseIntoAllSubFolders, True, searchCondition)
#Else
				_client.DeleteFiles(_currentDirectory, files, _ftpSettings.ShowProgressWhileDeleting, RecursionMode.RecurseIntoAllSubFolders, True, searchCondition)
#End If
			Catch ex As Exception
				If Not HandleException(ex) Then
					Return
				End If
			End Try

			EnableProgress(False)
			RefreshRemoteList()

#Else
			_client.DeleteFilesAsync(_currentDirectory, files, showProgress, RecursionMode.RecurseIntoAllSubFolders, True, searchCondition)
#End If
		End Sub

		#Region "Local"

		''' <summary>
		''' Deletes local files and/or folders.
		''' </summary>
		Public Sub DoLocalDelete(ByVal files() As AbstractFileInfo)
			DeleteFiles(files, True, Nothing)
		End Sub

		#End Region

		#Region "Remote"

		''' <summary>
		''' Deletes remote files and/or folders.
		''' </summary>
		Public Sub DoRemoteDelete(ByVal files() As AbstractFileInfo, ByVal searchCondition As SearchCondition)
			DeleteFiles(files, False, searchCondition)
		End Sub

		#End Region
	End Class
End Namespace
