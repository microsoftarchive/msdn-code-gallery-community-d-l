Imports System.IO
Imports System.Text
Imports ComponentPro.IO
Imports ComponentPro.Net

Namespace ClientSample
	Partial Public Class Main
		Public Function GetLogger() As TraceListener Implements IClientView.GetLogger
			Return New RichTextBoxTraceListener(txtLog)
		End Function

		Private Sub IClientView_UpdateProgress(ByVal e As FileSystemProgressEventArgs, ByVal smallProgress As Boolean, ByVal totalProgress As Boolean) Implements IClientView.UpdateProgress
			If smallProgress Then
				progressBar.Value = CInt(Fix(e.Percentage))
			End If
			If totalProgress Then
				progressBarTotal.Value = CInt(Fix(e.TotalPercentage))
			End If

			Application.DoEvents()
		End Sub
		Private Sub IClientView_UpdateStatus(ByVal text As String) Implements IClientView.UpdateStatus
			status.Text = text
		End Sub

		Private _enabled As Integer
		''' <summary>
		''' Enables/Disables the dialog. In disabled state, cursor is WaitCursor (an hourglass shape), menus and toolbar are disabled.
		''' </summary>
		''' <param name="enable"></param>
		Public Sub EnableView(ByVal enable As Boolean) Implements IClientView.EnableView
			If enable Then
				If _enabled > 0 Then
					_enabled -= 1
				End If
			Else
				_enabled += 1
			End If

			If _enabled = 1 Then
				Cursor = Cursors.WaitCursor
				toolbarMain.Enabled = False
				menuStrip.Enabled = False
			ElseIf _enabled = 0 Then
				Cursor = Cursors.Default
				toolbarMain.Enabled = True
				menuStrip.Enabled = True
			End If
		End Sub

		Public Sub EnableLogin(ByVal enable As LoginEnableState) Implements IClientView.EnableLogin
			loginToolStripMenuItem.Enabled = enable = LoginEnableState.LoginEnabled
			tsbLogin.Enabled = loginToolStripMenuItem.Enabled
			tsbLogin.Visible = enable = LoginEnableState.LoginDisabled OrElse enable = LoginEnableState.LoginEnabled

			loginToolStripMenuItem.Enabled = enable = LoginEnableState.LogoutEnabled
			tsbLogout.Enabled = loginToolStripMenuItem.Enabled
			tsbLogout.Visible = enable = LoginEnableState.LogoutDisabled OrElse enable = LoginEnableState.LogoutEnabled

			tsbSettings.Enabled = enable = LoginEnableState.LoginEnabled OrElse enable = LoginEnableState.LogoutEnabled
			settingsToolStripMenuItem.Enabled = tsbSettings.Enabled

			If enable = LoginEnableState.LogoutDisabled OrElse enable = LoginEnableState.LogoutEnabled Then
				loginToolStripMenuItem.Text = "&Disconnect"
			Else
				loginToolStripMenuItem.Text = "&Connect..."
			End If
			loginToolStripMenuItem.Enabled = enable = LoginEnableState.LoginEnabled OrElse enable = LoginEnableState.LogoutEnabled

			If enable = LoginEnableState.LoginEnabled Then
				lvwRemote.Items.Clear()
			End If

			txtRemoteDir.Enabled = enable = LoginEnableState.LogoutEnabled

			exitToolStripMenuItem.Enabled = enable = LoginEnableState.LogoutEnabled OrElse enable = LoginEnableState.LoginEnabled
			' Enable/disable the Close button.
			Util.EnableCloseButton(Me, exitToolStripMenuItem.Enabled)

			If enable = LoginEnableState.LoginEnabled OrElse enable = LoginEnableState.LogoutEnabled Then
				EnableProgress(False)
				EnableButtons()
			End If

			_enabled = 0
		End Sub

		Public Function AskYesNo(ByVal message As String) As Boolean Implements IClientView.AskYesNo
			Return MessageBox.Show(message, Messages.MessageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes
		End Function

		Public Sub ShowError(ByVal message As String) Implements IClientView.ShowError
			MessageBox.Show(message, Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
		End Sub

		Public Sub ShowError(ByVal ex As Exception) Implements IClientView.ShowError
			Util.ShowError(ex)
		End Sub

		Public Sub ShowMessage(ByVal message As String) Implements IClientView.ShowMessage
			MessageBox.Show(message, Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
		End Sub

		Public Function AskForPassword(ByVal title As String) As String Implements IClientView.AskForPassword
			Dim dlg As New PasswordPrompt(title)
			If dlg.ShowDialog() = DialogResult.OK Then
				Return dlg.Password
			End If

			Return Nothing
		End Function

		Public Sub UpdateRemotePath(ByVal path As String) Implements IClientView.UpdateRemotePath
			txtRemoteDir.Text = path
		End Sub

		Public Sub UpdateLocalPath(ByVal path As String) Implements IClientView.UpdateLocalPath
			txtLocalDir.Text = path
		End Sub

		#Region "Remote list"

		Public Sub ListRemoteFiles(ByVal viewList As List(Of ListItemInfo)) Implements IClientView.ListRemoteFiles
			ListFiles(viewList, lvwRemote, False)
		End Sub

		#End Region

		Public Sub ListFiles(ByVal viewList As List(Of ListItemInfo), ByVal listView As ListView, ByVal local As Boolean)
			Dim item As ListViewItem
			' Clear the list.
			listView.Items.Clear()

			For i As Integer = 0 To viewList.Count - 1
				Dim listitem As ListItemInfo = viewList(i)
				Dim f As AbstractFileInfo = listitem.FileInfo

				If f.IsDirectory Then
					item = listView.Items.Add(f.Name, _folderIconIndex)

					item.SubItems.Add("")
				Else
					If listitem.LinkedFile IsNot Nothing Then
						If listitem.LinkedFile.IsDirectory Then
							item = listView.Items.Add(f.Name,FolderLinkImageIndex)
						Else
							item = listView.Items.Add(f.Name,SymlinkImageIndex)
						End If
					Else
						item = listView.Items.Add(f.Name, SetFileIcon(Path.Combine(txtLocalDir.Text, f.Name)))
					End If

					item.SubItems.Add(Util.FormatSize(f.Length))
				End If

				If f.LastWriteTime <> Date.MinValue Then
					item.SubItems.Add(f.LastWriteTime.ToString())
				End If
				item.SubItems.Add(listitem.Permissions)
				item.Tag = listitem
			Next i

			If local Then
				UpdateLocalListViewSorter()
			Else
				UpdateRemoteListViewSorter()
			End If

			If viewList.Count > 0 Then
				listView.Items(0).Selected = True
			End If
		End Sub

		#Region "Local List"

		Public Sub ListLocalFiles(ByVal viewList As List(Of ListItemInfo)) Implements IClientView.ListLocalFiles
			ListFiles(viewList, lvwLocal, True)
		End Sub

		#End Region
	End Class
End Namespace
