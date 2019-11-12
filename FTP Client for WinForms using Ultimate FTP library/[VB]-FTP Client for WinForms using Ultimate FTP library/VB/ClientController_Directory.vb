Imports System.Text
Imports ClientSample.Ftp
Imports ComponentPro.IO
Imports ComponentPro.Net

Namespace ClientSample
	Partial Friend Class ClientController
		Public Function DoRemoteMakeDir(ByVal name As String) As Boolean
			_view.EnableView(False)

			Try
				' Create a new directory.
				_client.CreateDirectory(name)
			Catch exc As Exception
				If Not HandleException(exc) Then
					Return False
				End If
			End Try

			' Refresh the remote list view.
			RefreshRemoteList()
			_view.EnableView(True)

			Return True
		End Function

		Public Sub GetItemsSize(ByVal files() As AbstractFileInfo)
			Dim total As Long = 0
			Try
				For i As Integer = 0 To files.Length - 1
					Dim f As AbstractFileInfo = files(i)
					If f.IsDirectory Then
						total += _client.GetDirectorySize(f.FullName, True)
					Else
						total += f.Length
					End If
				Next i

				_view.ShowMessage(String.Format("Total size: {0}", Util.FormatSize(total)))
			Catch exc As Exception
				HandleException(exc)
			End Try
		End Sub


#If FTP Then
		Public Sub DoRemoteSetFilePermissions(ByVal files() As AbstractFileInfo, ByVal permissions As String, ByVal recursive As Boolean)
			CType(_clientPlugin, ClientSample.Ftp.FtpClientPlugin).DoSetFilePermissions(files, permissions, recursive)
		End Sub
#End If


#If SFTP Then
		Public Sub DoRemoteSetFileAttributes(ByVal files() As AbstractFileInfo, ByVal attr As SftpFileAttributes, ByVal recursive As Boolean)
			CType(_clientPlugin, ClientSample.Sftp.SftpClientPlugin).DoSetFileAttributes(files, attr, recursive)
		End Sub
#End If
	End Class
End Namespace
