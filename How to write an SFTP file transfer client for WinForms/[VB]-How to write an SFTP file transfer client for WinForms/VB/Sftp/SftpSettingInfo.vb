Imports System.Text

Namespace ClientSample.Sftp
	Friend Class SftpSettingInfo
		#Region "SFTP"

		Public Const ServerOs As String = "ServerOs"

		#End Region

		Public Shared Sub SaveConfig(ByVal settings As SettingInfoBase)
'			#Region "SFTP"
			settings.SaveProperty(ServerOs)
'			#End Region
		End Sub

		Public Shared Sub LoadConfig(ByVal settings As SettingInfoBase)
'			#Region "SFTP"
			settings.LoadProperty(ServerOs, 0)
'			#End Region
		End Sub
	End Class
End Namespace
