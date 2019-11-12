Imports System.Text
Imports ComponentPro.IO

Namespace ClientSample
	Partial Friend Class ClientController
		Public Function DoRemoteRename(ByVal name As String, ByVal newname As String) As Boolean
			_view.EnableView(False)
			Try
				_client.Rename(name, newname)
			Catch ex As Exception
				If Not HandleException(ex) Then
					Return False
				End If

				Return False
			Finally
				_view.EnableView(True)
			End Try

			Return True
		End Function

		Public Sub DoRemoteMove(ByVal fileList() As AbstractFileInfo, ByVal destDir As String, ByVal fileMasks As String)
			If fileList Is Nothing Then
				Return
			End If

			' Enable progress bar, Abort button, and disable other controls.
			EnableProgress(True)

			Dim opt As TransferOptions
			If String.IsNullOrEmpty(fileMasks) Then
				opt = New TransferOptions(True, RecursionMode.RecurseIntoAllSubFolders, True,CType(Nothing, SearchCondition), FileExistsResolveAction.Confirm, SymlinksResolveAction.Confirm)
			Else
				opt = New TransferOptions(True, RecursionMode.RecurseIntoAllSubFolders, True,New NameSearchCondition(fileMasks), FileExistsResolveAction.Confirm, SymlinksResolveAction.Confirm)
			End If

#If Framework4_5 OrElse (Not ASYNC) Then
			Try
#If Not ASYNC Then
				await client.MoveFilesAsync(_currentDirectory, fileList, _moveToFolder, opt)
#Else
				client.MoveFiles(_currentDirectory, fileList, _moveToFolder, opt)
#End If

			Catch exc As Exception
				If Not HandleException(exc) Then
					Return
				End If
			End Try

			EnableProgress(False)

			' Refresh the remote list view.
			RefreshRemoteList()
#Else
			_client.MoveFilesAsync(_currentDirectory, fileList, destDir, opt)
#End If
		End Sub
	End Class
End Namespace
