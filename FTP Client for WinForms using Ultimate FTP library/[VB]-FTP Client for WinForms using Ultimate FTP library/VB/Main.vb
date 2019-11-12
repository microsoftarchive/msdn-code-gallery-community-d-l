Imports System.Collections
Imports System.IO
Imports System.Text.RegularExpressions
Imports ClientSample.Ftp
Imports ComponentPro.IO
Imports ComponentPro.Net

Namespace ClientSample
	Partial Public Class Main
		Inherits Form
		Implements IClientView
		Private _exception As Boolean
		Private _controller As ClientController
		Private _loginSettings As SettingInfoBase
		Private _settings As SettingInfoBase
		Private _folderIconIndex As Integer ' Image index of the folder icon.
		Private _iconManager As FileIconManager ' Icon manager.
		Private Const UpFolderImageIndex As Integer = 0
		Private Const FolderLinkImageIndex As Integer = 1
		Private Const SymlinkImageIndex As Integer = 2
		Private _mask As String = "*.*"

		Private _fileOpForm As FileOperation

		Public Sub New()
			' This try catch block is not needed if you have a production license.
			Try
				InitializeComponent()
			Catch exc As Exception
				MessageBox.Show(exc.Message, "Error")
				_exception = True
			End Try

#If (Not FTP) AndAlso SFTP Then
			mnuPopExecuteCommand.Visible = False
			executeCommandToolStripMenuItem.Visible = False
			lcmUploadUnique.Visible = False
			uploadUniqueFileToolStripMenuItem.Visible = False
#End If
		End Sub

		#Region "Load and Save Settings"

		''' <summary>
		''' Handles the form's Load event.
		''' </summary>
		''' <param name="e">The event arguments.</param>
		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad(e)
			If _exception Then
				Close()
				Return
			End If

			' Load settings from the Registry.
			_loginSettings = New SettingInfoBase()
			_settings = New SettingInfoBase()

#If FTP AndAlso SFTP Then
			_loginSettings.LoadConfig(AddressOf LoginInfo.LoadConfig, AddressOf FtpLoginInfo.LoadConfig, SftpLoginInfo.LoadConfig)
			_settings.LoadConfig(AddressOf SettingInfo.LoadConfig, AddressOf FtpSettingInfo.LoadConfig, SftpSettingInfo.LoadConfig)
#ElseIf FTP Then
			_loginSettings.LoadConfig(AddressOf LoginInfo.LoadConfig, AddressOf FtpLoginInfo.LoadConfig)
			_settings.LoadConfig(AddressOf SettingInfo.LoadConfig, AddressOf FtpSettingInfo.LoadConfig)
#ElseIf SFTP Then
			_loginSettings.LoadConfig(AddressOf LoginInfo.LoadConfig, SftpLoginInfo.LoadConfig)
			_settings.LoadConfig(AddressOf SettingInfo.LoadConfig, SftpSettingInfo.LoadConfig)
#End If

			txtLocalDir.Text = _loginSettings.Get(Of String)(LoginInfo.LocalDir)

			' Create a new icon manager object.
			_iconManager = New FileIconManager(imglist, IconSize.Small)
			' Get folder image index.
			_folderIconIndex = _iconManager.AddFolderIcon(FolderType.Closed)

			_controller = New ClientController(Me, _loginSettings, _settings)

			' Show local files.
			_controller.RefreshLocalList()

			_fileOpForm = New FileOperation()
		End Sub

		''' <summary>
		''' Handles the form's Close event.
		''' </summary>
		''' <param name="e">The event arguments.</param>
		Protected Overrides Sub OnClosed(ByVal e As EventArgs)
			' Logged in?
			If loginToolStripMenuItem.Enabled AndAlso loginToolStripMenuItem.Text = "&Disconnect" Then
				' Disconnect.
				_controller.Disconnect()

				' and wait for the completion.
				Do While _controller.State <> ConnectionState.NotConnected
					System.Threading.Thread.Sleep(50)
					Application.DoEvents()
				Loop
			End If

			Try
				' Try to delete temporary folder that was used to download files for viewing.
				Util.DeleteTempFolder()
			Catch
			End Try

			' Save settings to the Registry.
#If FTP AndAlso SFTP Then
			_loginSettings.SaveConfig(AddressOf LoginInfo.SaveConfig, AddressOf FtpLoginInfo.SaveConfig, SftpLoginInfo.SaveConfig)
			_settings.SaveConfig(AddressOf SettingInfo.SaveConfig, AddressOf FtpSettingInfo.SaveConfig, SftpSettingInfo.SaveConfig)
#ElseIf FTP Then
			_loginSettings.SaveConfig(AddressOf LoginInfo.SaveConfig, AddressOf FtpLoginInfo.SaveConfig)
			_settings.SaveConfig(AddressOf SettingInfo.SaveConfig, AddressOf FtpSettingInfo.SaveConfig)
#ElseIf SFTP Then
			_loginSettings.SaveConfig(AddressOf LoginInfo.SaveConfig, SftpLoginInfo.SaveConfig)
			_settings.SaveConfig(AddressOf SettingInfo.SaveConfig, SftpSettingInfo.SaveConfig)
#End If

			MyBase.OnClosed(e)
		End Sub

		#End Region

		#Region "Main Menu"

		Private Sub settingsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles settingsToolStripMenuItem.Click
			' Show general settings dialog.
			Dim dlg As New Setting(_settings)
			If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK AndAlso _controller.State = ConnectionState.Ready Then
				_controller.ApplySettings(_settings)
			End If
		End Sub

		Private Sub loginToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loginToolStripMenuItem.Click
			' Not logged in?
			If loginToolStripMenuItem.Text = "&Connect..." Then
				' Show the Login form.
				Dim form As New Login(_loginSettings)
				If form.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
					Return
				End If

				' Clear log text box.
				txtLog.Clear()

				' Connect to the server.
				_controller.DoConnect()
			Else
				' Log out.
				_controller.Disconnect()
			End If
		End Sub

		Private Sub moveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles moveToolStripMenuItem.Click
			If lvwRemote.Focused AndAlso _controller.State = ConnectionState.Ready Then
				DoRemoteMove()
			ElseIf lvwLocal.Focused Then
				DoLocalMove()
			End If
		End Sub

		Private Sub renameToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles renameToolStripMenuItem.Click
			If lvwRemote.Focused AndAlso _controller.State = ConnectionState.Ready Then
				lvwRemote.SelectedItems(0).BeginEdit()
			ElseIf lvwLocal.Focused Then
				lvwLocal.SelectedItems(0).BeginEdit()
			End If
		End Sub

		Private Sub makeDirectoryToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles makeDirectoryToolStripMenuItem.Click
			If lvwRemote.Focused AndAlso _controller.State = ConnectionState.Ready Then
				DoRemoteMakeDir()
			ElseIf lvwLocal.Focused Then
				DoLocalMakeDir()
			End If
		End Sub

		Private Sub downloadToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles downloadToolStripMenuItem.Click
			If Not progressBar.Enabled Then
				' When the File menu item is clicked, enable/disable its child menu items.
				DoRemoteDownload()
			End If
		End Sub

		Private Sub uploadFileToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles uploadFileToolStripMenuItem.Click
			DoLocalUpload()
		End Sub

		Private Sub uploadUniqueFileToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles uploadUniqueFileToolStripMenuItem.Click
#If FTP Then
			DoLocalUploadUnique(lvwLocal.SelectedItems(0))
#End If
		End Sub

		Private Sub propertiesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles propertiesToolStripMenuItem.Click
			If lvwRemote.Focused AndAlso _controller.State = ConnectionState.Ready Then
				If lvwRemote.SelectedItems.Count > 0 Then
					DoRemoteProperties()
				End If
			Else
				If lvwLocal.SelectedItems.Count > 0 Then
					DoLocalProperties(lvwLocal.SelectedItems(0))
				End If
			End If
		End Sub

		Private Sub viewToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles viewToolStripMenuItem.Click
			If lvwRemote.Focused AndAlso _controller.State = ConnectionState.Ready Then
				DoRemoteView(lvwRemote.SelectedItems(0))
			Else
				DoLocalView(lvwLocal.SelectedItems(0))
			End If
		End Sub

		Private Sub refreshToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles refreshToolStripMenuItem.Click
			If lvwRemote.Focused AndAlso _controller.State = ConnectionState.Ready Then
				_controller.RefreshRemoteList()
			Else
				_controller.RefreshLocalList()
			End If
		End Sub

		Private Sub deleteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles deleteToolStripMenuItem.Click
			If lvwRemote.Focused AndAlso _controller.State = ConnectionState.Ready AndAlso lvwRemote.SelectedItems.Count > 0 Then
				DoRemoteDelete()
			ElseIf lvwLocal.Focused AndAlso lvwLocal.SelectedItems.Count > 0 Then
				DoLocalDelete()
			End If
		End Sub

		Private Sub synchronizeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles synchronizeToolStripMenuItem.Click
			DoSynchronize()
		End Sub

		Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
			Close()
		End Sub

		Private Sub executeCommandToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles executeCommandToolStripMenuItem.Click
#If FTP Then
			mnuPopExecuteCommand_Click(Nothing, Nothing)
#End If
		End Sub

		Private Sub getTimeDifferenceToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles getTimeDifferenceToolStripMenuItem.Click
			mnuPopGetTimeDiff_Click(Nothing, Nothing)
		End Sub

		Private Sub resumeDownloadToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles resumeDownloadToolStripMenuItem.Click
			mnuPopResumeDownload_Click(Nothing, Nothing)
		End Sub

		Private Sub resumeUploadToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles resumeUploadToolStripMenuItem.Click
			lcmResumeUpload_Click(Nothing, Nothing)
		End Sub

		Private Sub calculateTotalSizeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles calculateTotalSizeToolStripMenuItem.Click
			mnuPopCalcTotalSize_Click(Nothing, Nothing)
		End Sub

		Private Sub deleteMultipleFilesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles deleteMultipleFilesToolStripMenuItem.Click
			mnuPopDeleteMultipleFiles_Click(Nothing, Nothing)
		End Sub

		#End Region

		#Region "Common"

		''' <summary>
		''' Gets a boolean value indicating whether the client object is ready to send a command.
		''' </summary>
		Private ReadOnly Property Ready() As Boolean
			Get
				Return _enabled = 0
			End Get
		End Property

		Private Shared Function GetItemFullName(ByVal item As ListViewItem) As String
			Dim info As ListItemInfo = CType(item.Tag, ListItemInfo)
			If info.LinkedFile Is Nothing Then
				Return info.FileInfo.FullName
			Else
				Return info.LinkedFile.FullName
			End If
		End Function

		Private Shared Sub SetItemFullName(ByVal item As ListViewItem, ByVal newFullName As String)
			Dim info As ListItemInfo = CType(item.Tag, ListItemInfo)
			info.FileInfo.UpdateFullName(newFullName)
		End Sub

		''' <summary>
		''' Loads the icon system resource for the given extension.
		''' </summary>
		''' <param name="name">The file name.</param>
		''' <returns>The image index for the given file name.</returns>
		Private Function SetFileIcon(ByVal name As String) As Integer
			Return _iconManager.AddFileIcon(name)
		End Function

		''' <summary>
		''' Returns fully qualified remote path.
		''' </summary>
		''' <param name="fileName">The file path.</param>
		''' <returns>A fully qualified remote path.</returns>
		Private Function GetRemoteFullPath(ByVal fileName As String) As String
			Return _controller.Client.CombinePath(_controller.CurrentRemoteDirectory, fileName)
		End Function

		#End Region

		#Region "Log"

		''' <summary>
		''' Writes a string with the specified color to the log text box.
		''' </summary>
		''' <param name="str">The string to write.</param>
		''' <param name="color">The text color.</param>
		Public Sub WriteLine(ByVal str As String, ByVal color As Color) Implements IClientView.WriteLine
			Dim log As String = str & vbCrLf
			txtLog.SelectionColor = color
			txtLog.SelectionStart = txtLog.Text.Length
			txtLog.SelectedText = log
			txtLog.ScrollToCaret()
		End Sub

		#End Region

		#Region "Enable and Disable Progress Bars"

		Private _lastFocus As Control

		''' <summary>
		''' Enables/disables progress bar and abort button.
		''' </summary>
		''' <param name="enable"></param>
		Public Sub EnableProgress(ByVal enable As Boolean) Implements IClientView.EnableProgress
			If enable Then
				' Save the last focused control.
				If lvwLocal.Focused Then
					_lastFocus = lvwLocal
				Else
					If lvwRemote.Focused Then
						_lastFocus = lvwRemote
					Else
						_lastFocus = Nothing
					End If
				End If
			Else
				status.Text = "Ready"
			End If

			menuStrip.Enabled = Not enable

			txtLocalDir.Enabled = Not enable
			btnLocalDirBrowse.Enabled = Not enable
			txtRemoteDir.Enabled = Not enable

			lvwRemote.Enabled = Not enable
			lvwLocal.Enabled = Not enable

			progressBar.Enabled = enable
			progressBar.Value = 0
			progressBarTotal.Enabled = enable
			progressBarTotal.Value = 0

'			#Region "Toolbar"

			tsbLogout.Enabled = Not enable
			tsbRefresh.Enabled = Not enable
			tsbSettings.Enabled = Not enable
			tsbUpload.Enabled = Not enable
			tsbDownload.Enabled = Not enable
			tsbDelete.Enabled = Not enable
			tsbMove.Enabled = Not enable
			tsbCreateDir.Enabled = Not enable
			tsbView.Enabled = Not enable
			tsbSynchronize.Enabled = Not enable

			btnAbort.Enabled = enable

'			#End Region

			keepAliveTimer.Enabled = Not enable

			' Disable/Enable the Close button as well.
			Util.EnableCloseButton(Me, (Not enable))

			If Not enable Then
				If _lastFocus IsNot Nothing Then
					' Enable the last focused control.
					_lastFocus.Focus()
					EnableButtons()
				End If
			End If

			If enable Then
				_fileOpForm.Init()
			End If
		End Sub

		''' <summary>
		''' Enables/disables control buttons (of menu and toolbar).
		''' </summary>
		Private Sub EnableButtons()
			Dim connected As Boolean = _controller.State = ConnectionState.Ready AndAlso Ready
			Dim selected As Boolean
			Dim selectedItem As ListViewItem
			Dim isFile As Boolean

			If lvwRemote.Focused AndAlso _controller.State = ConnectionState.Ready Then
				If connected AndAlso lvwRemote.SelectedItems.Count > 0 AndAlso lvwRemote.SelectedItems(0).ImageIndex <> UpFolderImageIndex Then
					selectedItem = lvwRemote.SelectedItems(0)
				Else
					selectedItem = Nothing
				End If

				selected = connected AndAlso (lvwRemote.SelectedItems.Count > 1 OrElse selectedItem IsNot Nothing)
				isFile = selectedItem IsNot Nothing AndAlso selectedItem.ImageIndex <> _folderIconIndex AndAlso selectedItem.ImageIndex <> FolderLinkImageIndex

				renameToolStripMenuItem.Enabled = selectedItem IsNot Nothing
				deleteToolStripMenuItem.Enabled = selected
				deleteMultipleFilesToolStripMenuItem.Enabled = selected
				moveToolStripMenuItem.Enabled = selected
				makeDirectoryToolStripMenuItem.Enabled = connected
				uploadFileToolStripMenuItem.Enabled = False
				uploadUniqueFileToolStripMenuItem.Enabled = False
				downloadToolStripMenuItem.Enabled = selected
				viewToolStripMenuItem.Enabled = isFile
				refreshToolStripMenuItem.Enabled = connected
				synchronizeToolStripMenuItem.Enabled = connected
				propertiesToolStripMenuItem.Enabled = selected

				resumeUploadToolStripMenuItem.Enabled = False
				resumeDownloadToolStripMenuItem.Enabled = isFile OrElse lvwRemote.SelectedItems.Count > 1
				executeCommandToolStripMenuItem.Enabled = connected
				calculateTotalSizeToolStripMenuItem.Enabled = selected
				getTimeDifferenceToolStripMenuItem.Enabled = connected
			ElseIf lvwLocal.Focused Then
				If lvwLocal.SelectedItems.Count > 0 AndAlso lvwLocal.SelectedItems(0).ImageIndex <> UpFolderImageIndex Then
					selectedItem = lvwLocal.SelectedItems(0)
				Else
					selectedItem = Nothing
				End If
				selected = lvwLocal.SelectedItems.Count > 1 OrElse selectedItem IsNot Nothing
				isFile = selectedItem IsNot Nothing AndAlso selectedItem.ImageIndex <> _folderIconIndex

				renameToolStripMenuItem.Enabled = selectedItem IsNot Nothing
				deleteToolStripMenuItem.Enabled = selected
				deleteMultipleFilesToolStripMenuItem.Enabled = False
				moveToolStripMenuItem.Enabled = selected
				makeDirectoryToolStripMenuItem.Enabled = True
				uploadFileToolStripMenuItem.Enabled = connected AndAlso selected
#If FTP Then
				uploadUniqueFileToolStripMenuItem.Enabled = connected AndAlso isFile AndAlso _controller.ServerType = ServerProtocol.Ftp
#End If
				downloadToolStripMenuItem.Enabled = False
				viewToolStripMenuItem.Enabled = isFile
				refreshToolStripMenuItem.Enabled = True
				synchronizeToolStripMenuItem.Enabled = connected
				propertiesToolStripMenuItem.Enabled = selected

				resumeUploadToolStripMenuItem.Enabled = connected AndAlso (isFile OrElse lvwLocal.SelectedItems.Count > 1)
				resumeDownloadToolStripMenuItem.Enabled = False
				executeCommandToolStripMenuItem.Enabled = connected
				calculateTotalSizeToolStripMenuItem.Enabled = False
				getTimeDifferenceToolStripMenuItem.Enabled = connected
			Else
				renameToolStripMenuItem.Enabled = False
				deleteToolStripMenuItem.Enabled = False
				deleteMultipleFilesToolStripMenuItem.Enabled = False
				moveToolStripMenuItem.Enabled = False
				makeDirectoryToolStripMenuItem.Enabled = False
				uploadFileToolStripMenuItem.Enabled = False
				uploadUniqueFileToolStripMenuItem.Enabled = False
				downloadToolStripMenuItem.Enabled = False
				viewToolStripMenuItem.Enabled = False
				refreshToolStripMenuItem.Enabled = False
				synchronizeToolStripMenuItem.Enabled = connected
				propertiesToolStripMenuItem.Enabled = False

				resumeUploadToolStripMenuItem.Enabled = False
				resumeDownloadToolStripMenuItem.Enabled = False
				executeCommandToolStripMenuItem.Enabled = False
				calculateTotalSizeToolStripMenuItem.Enabled = False
				getTimeDifferenceToolStripMenuItem.Enabled = connected
			End If

			tsbDelete.Enabled = deleteToolStripMenuItem.Enabled
			tsbMove.Enabled = moveToolStripMenuItem.Enabled
			tsbCreateDir.Enabled = makeDirectoryToolStripMenuItem.Enabled
			tsbUpload.Enabled = uploadFileToolStripMenuItem.Enabled
			tsbDownload.Enabled = downloadToolStripMenuItem.Enabled
			tsbView.Enabled = viewToolStripMenuItem.Enabled
			tsbRefresh.Enabled = refreshToolStripMenuItem.Enabled
			tsbSynchronize.Enabled = synchronizeToolStripMenuItem.Enabled
		End Sub

		#End Region

		#Region "Context Menus"

		Private Sub lvwLocal_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lvwLocal.SelectedIndexChanged
			' Enable/disable control buttons when the selected item on the local view control is changed.
			EnableButtons()
		End Sub

		Private Sub lvwRemote_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lvwRemote.SelectedIndexChanged
			' Enable/disable control buttons when the selected item on the remote view control is changed.
			EnableButtons()
		End Sub

		#End Region

		#Region "Toolbar Buttons"

		Private Sub tsbLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbLogin.Click
			loginToolStripMenuItem_Click(sender, Nothing)
		End Sub

		Private Sub tsbLogout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbLogout.Click
			loginToolStripMenuItem_Click(sender, Nothing)
		End Sub

		Private Sub tsbRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbRefresh.Click
			refreshToolStripMenuItem_Click(sender, Nothing)
		End Sub

		Private Sub tsbSettings_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbSettings.Click
			settingsToolStripMenuItem_Click(sender, Nothing)
		End Sub

		Private Sub tsbCreateDir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbCreateDir.Click
			makeDirectoryToolStripMenuItem_Click(sender, Nothing)
		End Sub

		Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbDelete.Click
			deleteToolStripMenuItem_Click(sender, Nothing)
		End Sub

		Private Sub tsbMove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbMove.Click
			moveToolStripMenuItem_Click(sender, Nothing)
		End Sub

		Private Sub tsbDownload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbDownload.Click
			downloadToolStripMenuItem_Click(sender, Nothing)
		End Sub

		Private Sub tsbUpload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbUpload.Click
			uploadFileToolStripMenuItem_Click(sender, Nothing)
		End Sub

		Private Sub tsbView_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbView.Click
			viewToolStripMenuItem_Click(sender, Nothing)
		End Sub

		Private Sub tsbSynchronize_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbSynchronize.Click
			synchronizeToolStripMenuItem_Click(sender, Nothing)
		End Sub

		#End Region

		#Region "Client"

		Private Sub btnAbort_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAbort.Click
			' Abort transferring.
			_controller.Cancel()
		End Sub

		Private Function IsListItemSelected(ByVal lv As ListView) As Boolean
			If lv.SelectedItems.Count = 0 Then
				Return False
			End If

			Return lv.SelectedItems(0) IsNot Nothing
		End Function

		Private Function IsRemoteItemSelected() As Boolean
			Return IsListItemSelected(lvwRemote)
		End Function

		''' <summary>
		''' Renames the selected item.
		''' </summary>
		''' <param name="newname">The new remote path name.</param>
		''' <returns>true if successful; otherwise is false.</returns>
		Private Function DoRemoteRename(ByVal newname As String) As Boolean
			If (Not IsRemoteItemSelected()) OrElse newname Is Nothing Then
				Return False
			End If

			' Attempts to rename the currently selected item to the new name.
			Dim item As ListViewItem = lvwRemote.SelectedItems(0)

			' Call the controller's Rename method. This is not an asynchronous method.
			If Not _controller.DoRemoteRename(item.Text, newname) Then
				Return False
			End If

			' Change the image index of the selected item if the selected item not a folder or symlink.
			If item.ImageIndex <> _folderIconIndex AndAlso item.ImageIndex <> FolderLinkImageIndex AndAlso item.ImageIndex <> SymlinkImageIndex Then
				item.ImageIndex = _iconManager.AddFileIcon(newname)
			End If

			SetItemFullName(item, GetRemoteFullPath(newname))

			Return True
		End Function

		#Region "Remove Files/Directories"

		Private _deleteFilesMask As String = "*.*"

		''' <summary>
		''' Deletes selected items.
		''' </summary>
		Private Sub DoRemoteDeleteMultipleFiles()
			Dim dlg As New FileMask(_deleteFilesMask, "Delete files that match")
			If dlg.ShowDialog(Me) <> System.Windows.Forms.DialogResult.OK Then
				Return
			End If

			_deleteFilesMask = dlg.Mask
			Dim files As New List(Of AbstractFileInfo)()
			Dim condition As SearchCondition = New NameSearchCondition(dlg.Mask)

			For Each item As ListViewItem In lvwRemote.Items
				Dim i As ListItemInfo = CType(item.Tag, ListItemInfo)

				If i.FileInfo.Name <> ".." AndAlso (i.FileInfo.IsDirectory OrElse condition.Matches(i.FileInfo)) Then
					files.Add(i.FileInfo)
				End If
			Next item

			_controller.DoRemoteDelete(files.ToArray(), condition)
		End Sub

		''' <summary>
		''' Deletes selected items.
		''' </summary>
		Private Sub DoRemoteDelete()
			Dim list() As AbstractFileInfo = BuildFileList(lvwRemote.SelectedItems)
			_controller.DoRemoteDelete(list, Nothing)
		End Sub

		#End Region

		#Region "View"

		''' <summary>
		''' Downloads the selected item and open notepad.exe for viewing the newly downloaded file.
		''' </summary>
		''' <param name="item">The selected item.</param>
		Private Sub DoRemoteView(ByVal item As ListViewItem)
			If item.ImageIndex <> UpFolderImageIndex AndAlso item.ImageIndex <> FolderLinkImageIndex AndAlso item.ImageIndex <> _folderIconIndex Then ' Not a folder or a symlink
				_controller.DoRemoteView(item.Text)
			End If
		End Sub

		#End Region

		Private Function BuildFileList(ByVal items As IList) As AbstractFileInfo()
			Dim files As New List(Of AbstractFileInfo)()
			For Each item As ListViewItem In items
				If item.ImageIndex <> UpFolderImageIndex AndAlso item.Text <> ".." Then
					files.Add(CType(item.Tag, ListItemInfo).FileInfo)
				End If
			Next item
			If files.Count = 0 Then
				Return Nothing
			End If

			Return files.ToArray()
		End Function

		#Region "Move"

		Private _moveToFolder As String
		''' <summary>
		''' Moves one or more items to another remote folder.
		''' </summary>
		Private Sub DoRemoteMove()
			Dim fileList() As AbstractFileInfo = BuildFileList(lvwRemote.SelectedItems)
			If _moveToFolder Is Nothing Then
				_moveToFolder = _controller.CurrentRemoteDirectory
			End If

			Dim dlg As New MoveToRemoteFolder(_moveToFolder)
			If dlg.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then
				Return
			End If

			If dlg.RemoteDir = _controller.CurrentRemoteDirectory Then
				MessageBox.Show(Messages.InvalidSourceDestDir, Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
				Return
			End If

			_moveToFolder = dlg.RemoteDir

			_controller.DoRemoteMove(fileList, _moveToFolder, dlg.FileMasks)
		End Sub

		#End Region

		#Region "Make Dir"

		''' <summary>
		''' Makes a new remote directory.
		''' </summary>
		Private Sub DoRemoteMakeDir()
			Dim dlg As New FolderNamePrompt()
			If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				If _controller.DoRemoteMakeDir(dlg.FolderName) Then
					lvwRemote.Items.Add(dlg.FolderName, _folderIconIndex)
				End If
			End If
		End Sub

		#End Region

		#Region "Remote Property"

		''' <summary>
		''' Shows the properties dialog to change file's permissions.
		''' </summary>
		Private Sub DoRemoteProperties()
			Dim fileList() As AbstractFileInfo = BuildFileList(lvwRemote.SelectedItems)
			If fileList Is Nothing Then
				Return
			End If

			Dim item As ListViewItem = lvwRemote.SelectedItems(0)
			If item.Text = ".." Then
				item = lvwRemote.SelectedItems(1)
			End If

			Dim permissions As String = CType(item.Tag, ListItemInfo).Permissions
			If permissions.Length < 3 Then
				MessageBox.Show("Remote file system does not support this operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				Return
			End If

#If FTP Then
			If _controller.ServerType = ServerProtocol.Ftp Then
				Dim info As FtpFileInfo = CType(item.Tag, FtpFileInfo)

				Dim dlg As New FtpPropertiesForm()
				dlg.FileName = GetItemFullName(item)
				dlg.Directory = item.ImageIndex = _folderIconIndex
				dlg.Permissions = info.Permissions
				If dlg.ShowDialog(Me) <> System.Windows.Forms.DialogResult.OK Then
					Return
				End If

				_controller.DoRemoteSetFilePermissions(fileList, dlg.PermissionsString, dlg.Recursive = RecursionMode.RecurseIntoAllSubFolders)
			End If
#End If
#If SFTP Then
			If _controller.ServerType = ServerProtocol.Sftp Then
				Dim dlg As New SftpPropertiesForm()
				dlg.FileName = GetItemFullName(item)
				dlg.Directory = item.ImageIndex = _folderIconIndex
				dlg.Permissions = CType(Convert.ToUInt32(item.SubItems(3).Text.Substring(0, 3), 16), SftpFilePermissions)
				If dlg.ShowDialog(Me) <> System.Windows.Forms.DialogResult.OK Then
					Return
				End If

				Dim attrs As New SftpFileAttributes()
				attrs.Permissions = dlg.Permissions

				_controller.DoRemoteSetFileAttributes(fileList, attrs, dlg.Recursive)
			End If
#End If
		End Sub

		#End Region

		#Region "Synchronize"

		''' <summary>
		''' Synchronizes local and remote folders.
		''' </summary>
		Private Sub DoSynchronize()
			Dim dlg As New MirrorFolders(lvwLocal.Focused, _loginSettings.Get(Of RecursionMode)(LoginInfo.SyncRecursive), _loginSettings.Get(Of Boolean)(LoginInfo.SyncDateTime), _loginSettings.Get(Of Integer)(LoginInfo.SyncMethod), _loginSettings.Get(Of Boolean)(LoginInfo.SyncResumability), _loginSettings.Get(Of String)(LoginInfo.SyncSearchPattern))

			If dlg.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then
				Return
			End If
			If MessageBox.Show(String.Format(Messages.SyncConfirm,IIf(dlg.RemoteIsMaster, txtLocalDir.Text, txtRemoteDir.Text),IIf(dlg.RemoteIsMaster, txtRemoteDir.Text, txtLocalDir.Text)), Messages.MessageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
				Return
			End If

			_loginSettings.Set(LoginInfo.SyncRecursive, dlg.Recursive)
			_loginSettings.Set(LoginInfo.SyncSearchPattern, dlg.SearchPattern)
			_loginSettings.Set(LoginInfo.SyncDateTime, dlg.SyncDateTime)
			_loginSettings.Set(LoginInfo.SyncMethod, dlg.ComparisonMethod)
			_loginSettings.Set(LoginInfo.SyncResumability, dlg.CheckForResumability)

			_controller.DoMirror(dlg.RemoteIsMaster)
		End Sub

		#End Region

		Private Sub IClientView_AskOverwrite(ByVal e As TransferConfirmEventArgs) Implements IClientView.AskOverwrite
			_fileOpForm.Show(Me, e)
		End Sub

		#End Region

		#Region "Local List"

		Private _lastLocalColumnToSort As Integer ' last sort action on this column.
		Private _lastLocalSortOrder As SortOrder = SortOrder.Ascending ' last sort order.

		#Region "Local File List        "

		''' <summary>
		''' Starts notepad.exe for viewing the selected file.
		''' </summary>
		''' <param name="item">The selected item.</param>
		Private Sub DoLocalView(ByVal item As ListViewItem)
			Try
				' If the selected item is not a folder or a symlink?
				If item.ImageIndex <> UpFolderImageIndex AndAlso item.ImageIndex <> _folderIconIndex Then
					' Start notepad.exe.
					Process.Start("Notepad.exe", GetItemFullName(item))
				End If
			Catch exc As Exception
				Util.ShowError(exc)
			End Try
		End Sub

		''' <summary>
		''' Deletes local files and/or folders.
		''' </summary>
		''' <returns>true if success; otherwise is false.</returns>
		Public Sub DoLocalDelete()
			Dim list() As AbstractFileInfo = BuildFileList(lvwLocal.SelectedItems)
			_controller.DoLocalDelete(list)
		End Sub

		''' <summary>
		''' Resumes upload the selected item.
		''' </summary>
		Private Sub DoLocalResumeUpload()
			DoLocalResumeUpload(lvwLocal.SelectedItems)
		End Sub

		''' <summary>
		''' Resumes upload a list of list view item.
		''' </summary>
		''' <param name="items">The list of list view item.</param>
		Private Sub DoLocalResumeUpload(ByVal items As IList)
			Dim files() As AbstractFileInfo = BuildFileList(items)
			_controller.DoLocalResumeUpload(files)
		End Sub

		''' <summary>
		''' Uploads a list of list view item.
		''' </summary>
		''' <param name="items">The list of list view item.</param>
		Private Sub DoLocalUpload(ByVal items As IList)
			Dim list() As AbstractFileInfo = BuildFileList(items)
			_controller.DoLocalUpload(list)
		End Sub

		''' <summary>
		''' Uploads selected items in the local list view.
		''' </summary>
		Private Sub DoLocalUpload()
			DoLocalUpload(lvwLocal.SelectedItems)
		End Sub

#If FTP Then
		''' <summary>
		''' Uploads unique the selected item in the local list view.
		''' </summary>
		''' <param name="item">The selected item.</param>
		Private Sub DoLocalUploadUnique(ByVal item As ListViewItem)
			Dim localFile As String = GetItemFullName(item)

			_controller.DoLocalUploadUnique(localFile)
		End Sub
#End If

		''' <summary>
		''' Shows System Properties dialog.
		''' </summary>
		''' <param name="item">The selected item.</param>
		Private Sub DoLocalProperties(ByVal item As ListViewItem)
			Dim localFile As String = GetItemFullName(item)
			' Call Shell API Show File Properties method.
			ShellAPI.ShowFileProperties(localFile, Handle)
		End Sub

		''' <summary>
		''' Renames the selected local file.
		''' </summary>
		''' <param name="newName">The new file name.</param>
		''' <returns>true if successful; otherwise is false.</returns>
		Public Function DoLocalRenameFile(ByVal newName As String) As Boolean
			If Not String.IsNullOrEmpty(newName) Then
				Dim item As ListViewItem = lvwLocal.SelectedItems(0)

				Try
					Dim newPath As String = Path.Combine(txtLocalDir.Text, newName)
					If item.ImageIndex = _folderIconIndex Then
						Directory.Move(GetItemFullName(item), newPath)
					ElseIf item.ImageIndex <> UpFolderImageIndex Then ' Not up dir.
						File.Move(GetItemFullName(item), newPath)
						item.ImageIndex = _iconManager.AddFileIcon(newName)
					End If
					SetItemFullName(item, newPath)

					Return True
				Catch exc As Exception
					Util.ShowError(exc)
				End Try
			End If

			Return False
		End Function

		''' <summary>
		''' Creates a new directory and update the local list view.
		''' </summary>
		Private Sub DoLocalMakeDir()
			Const common As String = "New Folder"
			Dim dirname As String = common
			Dim n As Integer = 0
			Dim fullPath As String = Path.Combine(txtLocalDir.Text, dirname)

			Try
				Do While Directory.Exists(fullPath) ' While folder with unique name exists.
					n = n + 1
					Dim unique As String = "(" & n & ")"
					dirname = common & unique
					fullPath = Path.Combine(txtLocalDir.Text, dirname)
				Loop

				' Try to create a new folder with unique identifier.
				Directory.CreateDirectory(fullPath)

				Dim item As ListViewItem = lvwLocal.Items.Add(dirname, _folderIconIndex)

				item.Tag = New ListItemInfo(DiskFileSystem.Default.CreateFileInfo(fullPath, FileAttributes.Directory, 0, Date.Now))

				item.BeginEdit()
			Catch exc As Exception
				Util.ShowError(exc)
			End Try
		End Sub

		''' <summary>
		''' Moves local files.
		''' </summary>
		Private Sub DoLocalMove()
			EnableProgress(True)
			Try
				Dim dlg As New FolderBrowserDialog()
				dlg.SelectedPath = txtLocalDir.Text
				dlg.Description = "Select destination folder"
				If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
					For Each item As ListViewItem In lvwLocal.SelectedItems
						If _controller.IsAborting Then
							Exit For
						End If

						If item.ImageIndex = _folderIconIndex Then ' Folder
							Directory.Move(GetItemFullName(item), dlg.SelectedPath & "\" & item.SubItems(0).Text)
						ElseIf item.ImageIndex > UpFolderImageIndex Then
							File.Move(GetItemFullName(item), dlg.SelectedPath & "\" & item.SubItems(0).Text)
						End If

						lvwLocal.Items.Remove(item)
					Next item

					_controller.RefreshLocalList()
				End If
			Catch exc As Exception
				Util.ShowError(exc)
			Finally
				EnableProgress(False)
			End Try
		End Sub

		Private Sub DoLocalExpandSelection(ByVal expand As Boolean)
			Dim dlg As New FileMask(_mask, expand)
			If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				_mask = dlg.Mask
				Dim rg As Regex = FileSystemPath.MaskToRegex(_mask, False)

				For Each item As ListViewItem In lvwLocal.Items
					If rg.Match(item.Text).Success Then
						item.Selected = expand
					End If
				Next item
			End If
		End Sub

		#Region "Event Handlers"

		''' <summary>
		''' Handles the LocalDirBrowse's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnLocalDirBrowse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLocalDirBrowse.Click
			Try
				Dim dlg As New FolderBrowserDialog()
				dlg.Description = "Select local folder"
				dlg.SelectedPath = txtLocalDir.Text
				If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
					_controller.DoLocalChangeDirectory(dlg.SelectedPath)
				End If
			Catch exc As Exception
				Util.ShowError(exc)
			End Try
		End Sub

		Private Sub txtLocalDir_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtLocalDir.KeyDown
			If e.KeyCode = Keys.Enter Then ' Enter
				_controller.DoLocalChangeDirectory(txtLocalDir.Text)
			End If
		End Sub

		Private Sub lvwLocal_AfterLabelEdit(ByVal sender As Object, ByVal e As LabelEditEventArgs) Handles lvwLocal.AfterLabelEdit
			e.CancelEdit = Not DoLocalRenameFile(e.Label)
		End Sub

		Private Sub lvwLocal_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles lvwLocal.DoubleClick
			If lvwLocal.SelectedItems.Count = 0 Then
				Return
			End If

			If lvwLocal.SelectedItems(0).ImageIndex = UpFolderImageIndex Then ' Arrow up
				' Move one level.
				_controller.DoLocalChangeDirectory("..")
			ElseIf lvwLocal.SelectedItems(0).ImageIndex = _folderIconIndex Then ' Folder
				' Change directory.
				_controller.DoLocalChangeDirectory(lvwLocal.SelectedItems(0).Text)
			Else
				' Upload a single file.
				DoLocalUpload()
			End If
		End Sub

		Private Sub UpdateLocalListViewSorter()
			Select Case _lastLocalColumnToSort
				Case 0
					lvwLocal.ListViewItemSorter = New ListViewItemNameComparer(_lastLocalSortOrder, _folderIconIndex, FolderLinkImageIndex)
				Case 1
					lvwLocal.ListViewItemSorter = New ListViewItemSizeComparer(_lastLocalSortOrder, _folderIconIndex, FolderLinkImageIndex)
				Case 2
					lvwLocal.ListViewItemSorter = New ListViewItemDateComparer(_lastLocalSortOrder, _folderIconIndex, FolderLinkImageIndex)
			End Select

			lvwLocal.ListViewItemSorter = Nothing
		End Sub

		Private Sub lvwLocal_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs) Handles lvwLocal.ColumnClick
			If lvwLocal.Items.Count = 0 Then
				Return
			End If

			Dim cdup As ListViewItem
			If lvwLocal.Items(0).ImageIndex = UpFolderImageIndex Then
				cdup = lvwLocal.Items(0)
			Else
				cdup = Nothing
			End If
			If cdup IsNot Nothing Then
				lvwLocal.Items.Remove(cdup)
			End If

			Dim sortOrder As SortOrder
			If _lastLocalColumnToSort = e.Column Then
				If _lastLocalSortOrder = SortOrder.Ascending Then
					sortOrder = SortOrder.Descending
				Else
					sortOrder = SortOrder.Ascending
				End If
			Else
				sortOrder = SortOrder.Ascending
			End If

			_lastLocalColumnToSort = e.Column
			_lastLocalSortOrder = sortOrder

			UpdateLocalListViewSorter()

			lvwLocal.ListViewItemSorter = Nothing
			If cdup IsNot Nothing Then
				lvwLocal.Items.Insert(0, cdup)
			End If
		End Sub

		''' <summary>
		''' Handles the local list view's DragDrop event.
		''' </summary>
		''' <param name="sender">The list view object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub lvwLocal_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles lvwLocal.DragDrop
			If DragAndDropListView.IsValidDragItem(e) Then
				Dim data As DragItemData = CType(e.Data.GetData(GetType(DragItemData)), DragItemData)
				If data.ListView Is lvwRemote Then
					' Download dropped items from the remote list view.
					DoRemoteDownload(data.DragItems)
				End If
			End If
		End Sub

		Private Sub lvwLocal_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles lvwLocal.KeyDown
			If lvwLocal.SelectedItems.Count = 0 Then
				Return
			End If

			Dim lvi As ListViewItem

			Select Case e.KeyCode
				Case System.Windows.Forms.Keys.Back
					_controller.DoLocalChangeDirectory("..")

				Case System.Windows.Forms.Keys.Delete
					' Delete files/folders
					DoLocalDelete()

				Case Keys.F2
					If lvwLocal.SelectedItems.Count > 0 AndAlso lvwLocal.SelectedItems(0).ImageIndex > UpFolderImageIndex Then ' Not Up dir
						lvwLocal.SelectedItems(0).BeginEdit()
					End If

				Case Keys.Enter
					If lvwLocal.SelectedItems.Count > 0 Then
						lvi = lvwLocal.SelectedItems(0)
						If lvi.ImageIndex = _folderIconIndex OrElse lvi.ImageIndex = UpFolderImageIndex Then ' Is selected item a directory
							_controller.DoLocalChangeDirectory(lvwLocal.SelectedItems(0).Text)
						Else
							DoLocalUpload()
						End If
					End If
			End Select
		End Sub

		Private Sub lcmRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lcmRefresh.Click
			_controller.RefreshLocalList()
		End Sub

		Private Sub lcmView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lcmView.Click
			DoLocalView(lvwLocal.SelectedItems(0))
		End Sub

		Private Sub lcmMove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lcmMove.Click
			DoLocalMove()
		End Sub

		Private Sub lcmDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lcmDelete.Click
			DoLocalDelete()
		End Sub

		Private Sub lcmMakeDir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lcmMakeDir.Click
			DoLocalMakeDir()
		End Sub

		Private Sub lcmRename_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lcmRename.Click
			lvwLocal.SelectedItems(0).BeginEdit()
		End Sub

		Private Sub lcmUploadUnique_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lcmUploadUnique.Click
#If FTP Then
			DoLocalUploadUnique(lvwLocal.SelectedItems(0))
#End If
		End Sub

		Private Sub lcmUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lcmUpload.Click
			DoLocalUpload()
		End Sub

		Private Sub lcmSynchronize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lcmSynchronize.Click
			DoSynchronize()
		End Sub

		Private Sub lcmProperties_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lcmProperties.Click
			DoLocalProperties(lvwLocal.SelectedItems(0))
		End Sub

		Private Sub lcmResumeUpload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lcmResumeUpload.Click
			DoLocalResumeUpload()
		End Sub

		Private Sub lcmSelectGroup_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lcmSelectGroup.Click
			DoLocalExpandSelection(True)
		End Sub

		Private Sub lcmUnselectGroup_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lcmUnselectGroup.Click
			DoLocalExpandSelection(False)
		End Sub

		Private Sub localContextMenu_Popup(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles localContextMenu.Opening
			' Enable/disable controls.
			Dim connected As Boolean = _controller.State = ConnectionState.Ready AndAlso Ready

			Dim selectedItem As ListViewItem

			If lvwLocal.SelectedItems.Count > 0 AndAlso lvwLocal.SelectedItems(0).ImageIndex <> UpFolderImageIndex Then
				selectedItem = lvwLocal.SelectedItems(0)
			Else
				selectedItem = Nothing
			End If

			Dim selected As Boolean = lvwLocal.SelectedItems.Count > 1 OrElse selectedItem IsNot Nothing
			Dim isFile As Boolean = selectedItem IsNot Nothing AndAlso selectedItem.ImageIndex <> _folderIconIndex

			lcmRename.Enabled = selectedItem IsNot Nothing
			lcmDelete.Enabled = selected
			lcmMove.Enabled = selected
			lcmMakeDir.Enabled = True
			lcmUpload.Enabled = connected AndAlso selected
#If FTP Then
			lcmUploadUnique.Enabled = connected AndAlso isFile AndAlso _controller.ServerType = ServerProtocol.Ftp
#End If
			lcmView.Enabled = isFile
			lcmRefresh.Enabled = True
			lcmSynchronize.Enabled = connected
			lcmProperties.Enabled = selected
			lcmResumeUpload.Enabled = connected AndAlso (isFile OrElse lvwLocal.SelectedItems.Count > 1)
			lcmSelectGroup.Enabled = True
			lcmUnselectGroup.Enabled = True
		End Sub

		Private Sub lvwLocal_BeforeLabelEdit(ByVal sender As Object, ByVal e As LabelEditEventArgs) Handles lvwLocal.BeforeLabelEdit
			If lvwLocal.Items(e.Item).ImageIndex = UpFolderImageIndex Then
				e.CancelEdit = True
			End If
		End Sub

		#End Region

		#End Region

		#End Region

		#Region "Remote List"

		Private _lastRemoteColumnToSort As Integer ' last sort action on this column.
		Private _lastRemoteSortOrder As SortOrder = SortOrder.Ascending ' last sort order.

		#Region "Remote List File"

		''' <summary>
		''' Resume download remote files.
		''' </summary>
		''' <param name="items">The list of ListViewItem.</param>
		Public Sub DoRemoteResumeDownload(ByVal items As IList)
			Dim files() As AbstractFileInfo = BuildFileList(items)
			_controller.DoRemoteResumeDownload(files)
		End Sub

		Private Sub DoRemoteExpandSelection(ByVal expand As Boolean)
			Dim dlg As New FileMask(_mask, expand)
			If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				_mask = dlg.Mask
				Dim rg As System.Text.RegularExpressions.Regex = FileSystemPath.MaskToRegex(_mask, False)

				For Each item As ListViewItem In lvwRemote.Items
					If rg.Match(item.Text).Success Then
						item.Selected = expand
					End If
				Next item
			End If
		End Sub

		#Region "Download"

		''' <summary>
		''' Downloads remote files.
		''' </summary>
		''' <param name="items">The list of ListViewItem.</param>
		Public Sub DoRemoteDownload(ByVal items As IList)
			Dim fileList() As AbstractFileInfo = BuildFileList(items)
			If fileList Is Nothing Then
				Return
			End If

			_controller.DoRemoteDownload(fileList)
		End Sub

		Private Sub DoRemoteDownload()
			DoRemoteDownload(lvwRemote.SelectedItems)
		End Sub

		#End Region

		#Region "List View Event Handlers"

		Private Sub lvwRemote_AfterLabelEdit(ByVal sender As Object, ByVal e As LabelEditEventArgs) Handles lvwRemote.AfterLabelEdit
			e.CancelEdit = Not(DoRemoteRename(e.Label))
		End Sub

		Private Sub UpdateRemoteListViewSorter()
			Select Case _lastRemoteColumnToSort
				Case 0
					lvwRemote.ListViewItemSorter = New ListViewItemNameComparer(_lastRemoteSortOrder, _folderIconIndex, FolderLinkImageIndex)
				Case 1
					lvwRemote.ListViewItemSorter = New ListViewItemSizeComparer(_lastRemoteSortOrder, _folderIconIndex, FolderLinkImageIndex)
				Case 2
					lvwRemote.ListViewItemSorter = New ListViewItemDateComparer(_lastRemoteSortOrder, _folderIconIndex, FolderLinkImageIndex)
				Case 3
					lvwRemote.ListViewItemSorter = New ListViewItemPermissionsComparer(_lastRemoteSortOrder, _folderIconIndex, FolderLinkImageIndex)
			End Select

			lvwRemote.ListViewItemSorter = Nothing
		End Sub

		Private Sub lvwRemote_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs) Handles lvwRemote.ColumnClick
			If lvwRemote.Items.Count = 0 Then
				Return
			End If

			Dim cdup As ListViewItem
			If lvwRemote.Items(0).ImageIndex = UpFolderImageIndex Then
				cdup = lvwRemote.Items(0)
			Else
				cdup = Nothing
			End If
			If cdup IsNot Nothing Then
				lvwRemote.Items.Remove(cdup)
			End If

			Dim sortOrder As SortOrder
			If _lastRemoteColumnToSort = e.Column Then
				If _lastRemoteSortOrder = SortOrder.Ascending Then
					sortOrder = SortOrder.Descending
				Else
					sortOrder = SortOrder.Ascending
				End If
			Else
				sortOrder = SortOrder.Ascending
			End If

			_lastRemoteColumnToSort = e.Column
			_lastRemoteSortOrder = sortOrder

			UpdateRemoteListViewSorter()

			lvwRemote.ListViewItemSorter = Nothing
			If cdup IsNot Nothing Then
				lvwRemote.Items.Insert(0, cdup)
			End If
		End Sub

		Private Sub lvwRemote_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles lvwRemote.DoubleClick
			If lvwRemote.SelectedItems.Count = 0 Then
				Return
			End If

			If lvwRemote.SelectedItems(0).ImageIndex = UpFolderImageIndex Then ' Arrow up
				_controller.DoRemoteChangeDirectory("..")
			ElseIf lvwRemote.SelectedItems(0).ImageIndex = _folderIconIndex Then ' Folder
				_controller.DoRemoteChangeDirectory(lvwRemote.SelectedItems(0).Text)
			ElseIf lvwRemote.SelectedItems(0).ImageIndex = FolderLinkImageIndex Then ' Folder Link
				_controller.DoRemoteChangeDirectory(GetItemFullName(lvwRemote.SelectedItems(0)))
			Else
				DoRemoteDownload()
			End If
		End Sub

		Private Sub lvwRemote_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles lvwRemote.KeyDown
			If lvwRemote.SelectedItems.Count = 0 Then
				Return
			End If

			Dim lvi As ListViewItem

			Select Case e.KeyCode
				Case System.Windows.Forms.Keys.Back
					_controller.DoRemoteChangeDirectory("..")

				Case System.Windows.Forms.Keys.Delete
					DoRemoteDelete()

				Case Keys.F2
					If lvwRemote.SelectedItems.Count > 0 AndAlso lvwRemote.SelectedItems(0).ImageIndex > UpFolderImageIndex Then
						lvwRemote.SelectedItems(0).BeginEdit()
					End If

#If FTP Then
				Case Keys.F9
					Dim ftp As ComponentPro.Net.Ftp = TryCast(_controller.Client, ComponentPro.Net.Ftp)
					If e.Alt AndAlso e.Control AndAlso ftp IsNot Nothing Then
						If ftp.TransferMode = FtpTransferMode.ZlibCompressed Then
							ftp.TransferMode = FtpTransferMode.Stream
							MessageBox.Show("ModeZ deactivated", Messages.MessageTitle)
						Else
							ftp.TransferMode = FtpTransferMode.ZlibCompressed
							MessageBox.Show("ModeZ activated", Messages.MessageTitle)
						End If
					End If
#End If

				Case Keys.Enter
					If lvwRemote.SelectedItems.Count > 0 Then
						lvi = lvwRemote.SelectedItems(0)
						If lvi.ImageIndex = _folderIconIndex OrElse lvi.ImageIndex = UpFolderImageIndex OrElse lvi.ImageIndex = FolderLinkImageIndex Then
							Dim dir As String = lvwRemote.SelectedItems(0).Text
							_controller.DoRemoteChangeDirectory(dir)
						Else
							DoRemoteDownload(lvwRemote.SelectedItems)
						End If
					End If
			End Select
		End Sub

		Private Sub txtRemoteDir_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtRemoteDir.KeyDown
			If e.KeyCode = Keys.Enter Then ' Enter
				_controller.DoRemoteChangeDirectory(txtRemoteDir.Text)
			End If
		End Sub

		Private Sub lvwRemote_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles lvwRemote.DragDrop
			If DragAndDropListView.IsValidDragItem(e) Then
				Dim data As DragItemData = CType(e.Data.GetData(GetType(DragItemData)), DragItemData)
				If data.ListView Is lvwLocal Then
					Dim list() As AbstractFileInfo = BuildFileList(data.DragItems)

					_controller.DoLocalUpload(list)
				End If
			End If
		End Sub

		#End Region

		#Region "Context Menu Event handlers"

		Private Sub mnuPopRename_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuPopRename.Click
			lvwRemote.SelectedItems(0).BeginEdit()
		End Sub

		Private Sub mnuPopMkdir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuPopMkdir.Click
			DoRemoteMakeDir()
		End Sub

		Private Sub mnuPopDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuPopDelete.Click
			DoRemoteDelete()
		End Sub

		Private Sub mnuPopRetrieve_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuPopRetrieve.Click
			DoRemoteDownload()
		End Sub

		Private Sub mnuPopMove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuPopMove.Click
			DoRemoteMove()
		End Sub

		Private Sub mnuPopView_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuPopView.Click
			DoRemoteView(lvwRemote.SelectedItems(0))
		End Sub

		Private Sub mnuPopRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuPopRefresh.Click
			_controller.RefreshRemoteList()
		End Sub

		Private Sub mnuSynchronize_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuPopSynchronize.Click
			DoSynchronize()
		End Sub

		Private _lastCommand As String = String.Empty ' Save the last command.
		Private Sub mnuPopExecuteCommand_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuPopExecuteCommand.Click
#If FTP Then
			Dim dlg As New ExecCommand()
			dlg.Command = _lastCommand
			' Show the command prompt dialog.
			If dlg.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then
				Return
			End If

			_controller.ExecCommand(dlg.Command)
#End If
		End Sub

		Private Sub mnuPopGetTimeDiff_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuPopGetTimeDiff.Click
			_controller.GetTimeDiff()
		End Sub

		Private Sub mnuPopResumeDownload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuPopResumeDownload.Click
			DoRemoteResumeDownload(lvwRemote.SelectedItems)
		End Sub

		Private Sub mnuPopCalcTotalSize_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuPopCalcTotalSize.Click
			Dim files() As AbstractFileInfo = BuildFileList(lvwRemote.SelectedItems)

			_controller.GetItemsSize(files)
		End Sub

		Private Sub mnuPopDeleteMultipleFiles_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuPopDeleteMultipleFiles.Click
			DoRemoteDeleteMultipleFiles()
		End Sub

		Private Sub remoteContextMenu_Popup(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles remoteContextMenu.Opening
			Dim connected As Boolean = _controller.State = ConnectionState.Ready AndAlso Ready

			Dim selectedItem As ListViewItem
			If connected AndAlso lvwRemote.SelectedItems.Count > 0 AndAlso lvwRemote.SelectedItems(0).ImageIndex <> UpFolderImageIndex Then
				selectedItem = lvwRemote.SelectedItems(0)
			Else
				selectedItem = Nothing
			End If

			Dim selected As Boolean = connected AndAlso (lvwRemote.SelectedItems.Count > 1 OrElse selectedItem IsNot Nothing)
			Dim isFile As Boolean = selectedItem IsNot Nothing AndAlso selectedItem.ImageIndex <> _folderIconIndex AndAlso selectedItem.ImageIndex <> FolderLinkImageIndex

			mnuPopRename.Enabled = selectedItem IsNot Nothing
			mnuPopDelete.Enabled = selected
			mnuPopDeleteMultipleFiles.Enabled = selected
			mnuPopMove.Enabled = selected
			mnuPopMkdir.Enabled = connected
			mnuPopRetrieve.Enabled = selected
			mnuPopView.Enabled = isFile
			mnuPopRefresh.Enabled = connected
			mnuPopSynchronize.Enabled = connected
			mnuPopProperties.Enabled = selectedItem IsNot Nothing
			mnuPopCalcTotalSize.Enabled = selected
			mnuPopExecuteCommand.Enabled = connected
			mnuPopGetTimeDiff.Enabled = connected
			mnuPopResumeDownload.Enabled = isFile OrElse lvwRemote.SelectedItems.Count > 1
			mnuPopSelectGroup.Enabled = connected
			mnuPopUnselectGroup.Enabled = connected
		End Sub

		Private Sub mnuPopProperties_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuPopProperties.Click
			propertiesToolStripMenuItem_Click(Nothing, Nothing)
		End Sub

		Private Sub mnuPopSelectGroup_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuPopSelectGroup.Click
			DoRemoteExpandSelection(True)
		End Sub

		Private Sub mnuPopUnselectGroup_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuPopUnselectGroup.Click
			DoRemoteExpandSelection(False)
		End Sub

		Private Sub lvwRemote_BeforeLabelEdit(ByVal sender As Object, ByVal e As LabelEditEventArgs) Handles lvwRemote.BeforeLabelEdit
			If lvwRemote.Items(e.Item).ImageIndex = UpFolderImageIndex Then
				e.CancelEdit = True
			End If
		End Sub

		#End Region

		#End Region

		#End Region
	End Class
End Namespace