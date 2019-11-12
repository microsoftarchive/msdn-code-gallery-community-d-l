Imports ComponentPro.IO

Namespace ClientSample
	Partial Public Class FileOperation
		Inherits Form
		Private _btns As Dictionary(Of System.Windows.Forms.Button, TransferConfirmNextActions)
		Private ReadOnly _skipTypes As New Dictionary(Of TransferConfirmReason, Object)()
		Private _oldEvt As TransferConfirmEventArgs

		Private _overwriteAll As Boolean
		Private _overwriteOlder As Boolean
		Private _overwriteDifferentSize As Boolean

		Private _resumeAll As Boolean
		Private _followAllLinks As Boolean

		Public Sub New()
			InitializeComponent()
		End Sub

		Public Sub Init()
			If _btns Is Nothing Then
				_btns = New Dictionary(Of System.Windows.Forms.Button, TransferConfirmNextActions)()
				_btns.Add(btnOverwrite, TransferConfirmNextActions.Overwrite)
				_btns.Add(btnOverwriteAll, TransferConfirmNextActions.Overwrite)
				_btns.Add(btnOverwriteDiffSize, TransferConfirmNextActions.CheckAndOverwriteFilesWithDifferentSizes)
				_btns.Add(btnOverwriteOlder, TransferConfirmNextActions.CheckAndOverwriteOlderFiles)
				_btns.Add(btnRename, TransferConfirmNextActions.Rename)
				_btns.Add(btnSkip, TransferConfirmNextActions.Skip)
				_btns.Add(btnSkipAll, TransferConfirmNextActions.Skip)
				_btns.Add(btnFollowLink, TransferConfirmNextActions.FollowLink)
				_btns.Add(btnFollowLinkAll, TransferConfirmNextActions.FollowLink)
				_btns.Add(btnRetry, TransferConfirmNextActions.Retry)
				_btns.Add(btnCancel, TransferConfirmNextActions.Cancel)
				_btns.Add(btnResume, TransferConfirmNextActions.ResumeFileTransfer)
				_btns.Add(btnResumeAll, TransferConfirmNextActions.ResumeFileTransfer)
			End If

			_skipTypes.Clear()
			_overwriteAll = False
			_overwriteOlder = False
			_overwriteDifferentSize = False

			_resumeAll = False

			_followAllLinks = False
		End Sub

		Public Overloads Sub Show(ByVal parent As Form, ByVal evt As TransferConfirmEventArgs)
			If _skipTypes.ContainsKey(evt.ConfirmReason) Then
				evt.NextAction = TransferConfirmNextActions.Skip
				Return
			End If

			If evt.ConfirmReason = TransferConfirmReason.FileAlreadyExists Then
				If _overwriteAll Then
					evt.NextAction = TransferConfirmNextActions.Overwrite
					Return
				End If

				If _overwriteDifferentSize Then
					evt.NextAction = TransferConfirmNextActions.CheckAndOverwriteFilesWithDifferentSizes
					Return
				End If

				If _overwriteOlder Then
					evt.NextAction = TransferConfirmNextActions.CheckAndOverwriteOlderFiles
					Return
				End If

				If _resumeAll AndAlso (evt.PossibleNextActions And TransferConfirmNextActions.ResumeFileTransfer) <> 0 Then
					evt.NextAction = TransferConfirmNextActions.ResumeFileTransfer
					Return
				End If

				' format the text according to TransferState (Downloading or Uploading)
				Const messageFormat As String = "Are you sure you want to overwrite file: {0}" & vbCrLf & "{1} Bytes, {2}" & vbCrLf & vbCrLf & "With file: {3}" & vbCrLf & "{4} Bytes, {5}"

				lblMessage.Text = String.Format(messageFormat, evt.DestinationFileInfo.FullName, evt.DestinationFileInfo.Length, evt.DestinationFileInfo.LastWriteTime, evt.SourceFileInfo.FullName, evt.SourceFileInfo.Length, evt.SourceFileInfo.LastWriteTime)

				Text = "File already exists"
			Else
				If evt.Exception IsNot Nothing Then
					lblMessage.Text = evt.Exception.Message

					If evt.Exception.InnerException IsNot Nothing Then
						lblMessage.Text &= vbCrLf & "Reason: " & evt.Exception.InnerException.Message
					End If
				Else
					If _followAllLinks AndAlso (evt.PossibleNextActions And TransferConfirmNextActions.FollowLink) <> 0 Then
						evt.NextAction = TransferConfirmNextActions.FollowLink
						Return
					End If

					lblMessage.Text = evt.Message
				End If

				Text = "An error occurred"
			End If

			_oldEvt = evt

			ArrangeButtons(evt)

			Me.ShowDialog(parent)
		End Sub

		Private Sub ArrangeButtons(ByVal evt As TransferConfirmEventArgs)
			Const buttonHeight As Integer = 24
			Const buttonWidth As Integer = 128
			Const gap As Integer = 3


			Dim buttons As Integer = 0
			For Each en As KeyValuePair(Of System.Windows.Forms.Button, TransferConfirmNextActions) In _btns
				Dim b As Boolean = evt.CanPerform(en.Value)
				en.Key.Visible = b
				If b Then
					buttons += 1
				End If
			Next en

			Dim count As Integer = Me.ClientSize.Width \ (buttonWidth + gap)
			Dim y As Integer
			If (buttons Mod count) = 0 Then
				y = Me.ClientSize.Height - (buttonHeight + gap) * ((buttons \ count) + (0)) - 4
			Else
				y = Me.ClientSize.Height - (buttonHeight + gap) * ((buttons \ count) + (1)) - 4
			End If
			Dim x As Integer = (Me.ClientSize.Width - count * buttonWidth - gap) \ 2

			Dim i As Integer = 0
			For Each en As KeyValuePair(Of System.Windows.Forms.Button, TransferConfirmNextActions) In _btns
				Dim b As Boolean = evt.CanPerform(en.Value)
				en.Key.Visible = b
				If b Then
					en.Key.Left = x + (buttonWidth + gap) * (i Mod count)
					en.Key.Top = y + (buttonHeight + gap) * (i \ count)
					i += 1
				End If
			Next en
		End Sub

		Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
			_oldEvt.NextAction = TransferConfirmNextActions.Cancel
			Close()
		End Sub

		Private Sub btnSkip_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSkip.Click
			_oldEvt.NextAction = TransferConfirmNextActions.Skip
			Close()
		End Sub

		Private Sub btnSkipAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSkipAll.Click
			_skipTypes.Add(_oldEvt.ConfirmReason, Nothing)

			_oldEvt.NextAction = TransferConfirmNextActions.Skip
			Close()
		End Sub

		Private Sub btnRetry_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRetry.Click
			_oldEvt.NextAction = TransferConfirmNextActions.Retry
			Close()
		End Sub

		Private Sub btnRename_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRename.Click
			Dim oldName As String = _oldEvt.DestinationFileSystem.GetFileName(_oldEvt.DestinationFileInfo.Name)
			Dim formNewName As New NewNamePrompt(oldName)

			Dim result As DialogResult = formNewName.ShowDialog(Me)

			Dim newName As String = formNewName.NewName

			If result <> System.Windows.Forms.DialogResult.OK OrElse newName.Length = 0 OrElse newName = oldName Then
				Return
			End If

			_oldEvt.NextAction = TransferConfirmNextActions.Rename
			_oldEvt.NewName = newName
			Close()
		End Sub

		Private Sub btnOverwrite_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOverwrite.Click
			_oldEvt.NextAction = TransferConfirmNextActions.Overwrite
			Close()
		End Sub

		Private Sub btnOverwriteAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOverwriteAll.Click
			_oldEvt.NextAction = TransferConfirmNextActions.Overwrite
			_overwriteAll = True
			Close()
		End Sub

		Private Sub btnOverwriteOlder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOverwriteOlder.Click
			_oldEvt.NextAction = TransferConfirmNextActions.CheckAndOverwriteOlderFiles
			_overwriteOlder = True
			Close()
		End Sub

		Private Sub btnOverwriteDiffSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOverwriteDiffSize.Click
			_oldEvt.NextAction = TransferConfirmNextActions.CheckAndOverwriteFilesWithDifferentSizes
			_overwriteDifferentSize = True
			Close()
		End Sub

		Private Sub btnFollowLink_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFollowLink.Click
			_oldEvt.NextAction = TransferConfirmNextActions.FollowLink
			Close()
		End Sub

		Private Sub btnResume_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResume.Click
			_oldEvt.NextAction = TransferConfirmNextActions.ResumeFileTransfer
			Close()
		End Sub

		Private Sub btnResumeAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResumeAll.Click
			_oldEvt.NextAction = TransferConfirmNextActions.ResumeFileTransfer
			_resumeAll = True
			Close()
		End Sub

		Private Sub btnFollowLinkAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFollowLinkAll.Click
			_oldEvt.NextAction = TransferConfirmNextActions.FollowLink
			_followAllLinks = True
			Close()
		End Sub
	End Class
End Namespace