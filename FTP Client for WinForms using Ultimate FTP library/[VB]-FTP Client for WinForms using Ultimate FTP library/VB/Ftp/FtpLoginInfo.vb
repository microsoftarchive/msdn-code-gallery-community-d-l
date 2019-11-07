Imports System.Text

Namespace ClientSample.Ftp
	Friend Class FtpLoginInfo
		Public Const PasvMode As String = "PasvMode"
		Public Const SecurityMode As String = "SecMode"
		Public Const Certificate As String = "Cert"
		Public Const ClearCommandChannel As String = "ccc"

		Public Shared Sub SaveConfig(ByVal settings As SettingInfoBase)
			settings.SaveProperty(PasvMode)
			settings.SaveProperty(Certificate)
			settings.SaveProperty(SecurityMode)
			settings.SaveProperty(ClearCommandChannel)
		End Sub

		Public Shared Sub LoadConfig(ByVal settings As SettingInfoBase)
			settings.LoadProperty(PasvMode, True)
			settings.LoadProperty(Certificate, String.Empty)
			settings.LoadProperty(SecurityMode, 0)
			settings.LoadProperty(ClearCommandChannel, False)
		End Sub
	End Class
End Namespace
