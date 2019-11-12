Namespace ClientSample
	Friend NotInheritable Class Messages

		Private Sub New()
		End Sub

		Public Const InvalidSourceDestDir As String = "Destination directory cannot be the current directory."
		Public Const OverwriteFileConfirm As String = "Are you sure you want to overwrite file: {0}" & vbCrLf & "{1} Bytes, {2}" & vbCrLf & vbCrLf & "With file: {3}" & vbCrLf & "{4} Bytes, {5}?"
		Public Const FileExists As String = "File or directory may already exist"
		Public Const MessageTitle As String = "SFTP Client Demo"
		Public Const InvalidTimeout As String = "Invalid timeout, it must be greater than or equal to 1"
		Public Const InvalidPermissions As String = "Invalid permission (must be between 0 -> 0x777)"
		Public Const TotalSize As String = "Total size: {0}"
		Public Const TimeDiff As String = "The time difference between the client and server: {0}"
		Public Const ConnectionHasNotBeenEstablished As String = "Connection has not been established"
		Public Const RemoteFileSizeIsEqualToLocalFileSize As String = "Remote file size is equal to the local file size"
		Public Const RemoteFileSizeIsGreaterThanLocalFileSize As String = "Remote file size is greater than the local file size"
		Public Const RemoteFileSizeIsLessThanLocalFileSize As String = "Remote file size is less than the local file size"
		Public Const InvalidDestDir As String = "Destination directory does not exist or no permission"
		Public Const MessageDeleteFile As String = "Are you sure you want to delete file '{0}'?"
		Public Const MessageDeleteItems As String = "Are you sure you want to delete {0} item(s)?"
		Public Const MessageDeleteFolder As String = "Are you sure you want to delete entire folder '{0}'?"
		Public Const NoPassword As String = "Password has not been provided" & vbCrLf & "The connection will be closed"
		Public Const PasswordCannotBeEmpty As String = "Password cannot be empty"
		Public Const UserNameCannotBeEmpty As String = "User name cannot be empty"
		Public Const HostNameCannotBeEmpty As String = "Host name cannot be empty"
		Public Const InvalidPort As String = "Invalid port number"
		Public Const SiteConfigFileNotFound As String = "FtpSites.xml not found"
		Public Const FolderNameCannotBeEmpty As String = "Folder name cannot be empty"
		Public Const InvalidCharacters As String = "Character '/' or '\' should not be entered"
		Public Const SyncConfirm As String = "Files and subfolders in folder '{0}' may be lost." & vbCrLf & "Are you sure you want to synchronize folder '{0}' with folder '{1}'?"
	End Class
End Namespace