Namespace ClientSample.Sftp
	Friend Class SftpLoginInfo
		Public Const PrivateKey As String = "PrivateKey"
		Public Const EnableCompression As String = "EnableCompression"

		Public Shared Sub SaveConfig(ByVal settings As SettingInfoBase)
			settings.SaveProperty(PrivateKey)
			settings.SaveProperty(EnableCompression)
		End Sub

		Public Shared Sub LoadConfig(ByVal settings As SettingInfoBase)
			settings.LoadProperty(PrivateKey, String.Empty)
			settings.LoadProperty(EnableCompression, False)
		End Sub
	End Class
End Namespace