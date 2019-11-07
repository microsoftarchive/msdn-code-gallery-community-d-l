Imports System.IO
Imports System.Text
Imports ComponentPro
Imports ComponentPro.IO
Imports ComponentPro.Net

Namespace ClientSample
	Partial Friend Class ClientController
		#Region "Remote"

		''' <summary>
		''' Refreshes the remote list view.
		''' </summary>
#If Framework4_5 Then
		Public Async Sub RefreshRemoteList()
#Else
		Public Sub RefreshRemoteList()
#End If
			' Disable the dialog.
			_view.EnableView(False)

#If Framework4_5 Then
			Try
				' Asynchronously retrieve a list of remote files.
#If Framework4_5 Then
				Dim files As FtpFileInfoCollection = Await client.ListDirectoryAsync()
#Else
				Dim files As FtpFileInfoCollection = client.ListDirectory()
#End If
				ShowRemoteList(files)
			Catch exc As Exception
				If Not HandleException(exc) Then
					Return
				End If
			Finally
				' Enable the dialog and handle the exception.
				EnableDialog(True)
			End Try
#Else
			_client.ListDirectoryAsync()
#End If
		End Sub

#If Not Framework4_5 Then
		''' <summary>
		''' Handles the client's GetFileListCompleted event.
		''' </summary>
		''' <param name="sender">The Ftp object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub client_ListDirectoryCompleted(ByVal sender As Object, ByVal e As ExtendedAsyncCompletedEventArgs(Of FileInfoCollection))
			_view.EnableView(True)

			If e.Error IsNot Nothing Then
				If Not HandleException(e.Error) Then
					Return
				End If
				Disconnect()
				Return
			End If

			DoListDirPost(e.Result)
		End Sub
#End If

		Private Sub DoListDirPost(ByVal files As FileInfoCollection)
			ListFiles(files, _currentDirectory.Length <= 1, False)
		End Sub

		Private Sub ListFiles(ByVal files As FileInfoCollection, ByVal rootDir As Boolean, ByVal local As Boolean)
			Dim viewList As New List(Of ListItemInfo)()
			Dim item As ListItemInfo

			' Add directories into the list first.
			For i As Integer = 0 To files.Count - 1
				Dim f As AbstractFileInfo = files(i)

				If f.IsDirectory Then
					If f.Name <> "." AndAlso f.Name <> ".." Then
						item = New ListItemInfo()
						item.FileInfo = f

						If Not local Then
							item.Permissions = _clientPlugin.GetPermissionsString(f)
						End If

						viewList.Add(item)
					End If
				ElseIf f.IsSymlink Then ' Add symlinks.
					item = New ListItemInfo()
					item.FileInfo = f
					item.LinkedFile = _client.GetFileInfo(f.SymlinkPath)
					item.Permissions = _clientPlugin.GetPermissionsString(f)

					viewList.Add(item)
				Else 'Add Files.
					item = New ListItemInfo()
					item.FileInfo = f
					If Not local Then
						item.Permissions = _clientPlugin.GetPermissionsString(f)
					End If

					viewList.Add(item)
				End If
			Next i

			If Not rootDir Then
				' Add Cdup list item.
				item = New ListItemInfo()
				If local Then
					item.FileInfo = DiskFileSystem.Default.CreateFileInfo("..", FileAttributes.Directory, -1, Date.MinValue)
				Else
					item.FileInfo = _client.CreateFileInfo("..", FileAttributes.Directory, -1, Date.MinValue)
				End If
				viewList.Add(item)
			End If

			If local Then
				_view.ListLocalFiles(viewList)
			Else
				_view.ListRemoteFiles(viewList)
			End If
		End Sub

		#End Region

		#Region "Local"

		''' <summary>
		''' Refreshes the local list view.
		''' </summary>
		Public Sub RefreshLocalList()
			Try
				Dim directory As New DirectoryInfo(_currentLocalDirectory)
				Dim list As FileInfoCollection = DiskFileSystem.Default.ListDirectory(directory.FullName)

				ListFiles(list, directory.FullName.Length <= 3, True)
			Catch exc As Exception
				_view.ShowError(exc)
				Return
			End Try
		End Sub

		#End Region

		''' <summary>
		''' Changes local directory.
		''' </summary>
		''' <param name="dir">The new target path.</param>
		Public Sub DoRemoteChangeDirectory(ByVal dir As String)
			If _state <> ConnectionState.Ready OrElse dir = "." Then
				Return
			End If

			If dir = ".." Then
				dir = _client.GetDirectoryName(_currentDirectory)
			Else
				dir = _client.CombinePath(_currentDirectory, dir)
			End If

			Try
				_client.SetCurrentDirectory(dir)
			Catch ex As Exception
				_view.ShowError(ex)
				Return
			End Try

			_view.UpdateRemotePath(dir)
			_currentDirectory = dir
			RefreshRemoteList()
		End Sub

		''' <summary>
		''' Changes local directory.
		''' </summary>
		''' <param name="dir">The new target path.</param>
		Public Sub DoLocalChangeDirectory(ByVal dir As String)
			dir = Path.GetFullPath(Path.Combine(_currentLocalDirectory, dir))
			_view.UpdateLocalPath(dir)
			_currentLocalDirectory = dir
			RefreshLocalList()
		End Sub
	End Class
End Namespace
