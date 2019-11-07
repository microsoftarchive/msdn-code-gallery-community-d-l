Imports System.Text

Namespace ClientSample.Ftp
	Friend Class FtpSettingInfo
		Public Const SmartPath As String = "SmartPath"
		Public Const SendAbortSignals As String = "SendAbortSignals"
		Public Const SendAborCommand As String = "SendAborCommand"
		Public Const ChangeDirBeforeListing As String = "ChangeDirBeforeListing"
		Public Const ChangeDirBeforeTransfer As String = "ChangeDirBeforeTransfer"
		Public Const Compress As String = "Compress"

		Public Shared Sub SaveConfig(ByVal settings As SettingInfoBase)
'			#Region "Ftp"
			settings.SaveProperty(SendAbortSignals)
			settings.SaveProperty(SendAborCommand)
			settings.SaveProperty(ChangeDirBeforeListing)
			settings.SaveProperty(ChangeDirBeforeTransfer)
			settings.SaveProperty(SmartPath)
			settings.SaveProperty(Compress)
'			#End Region
		End Sub

		Public Shared Sub LoadConfig(ByVal settings As SettingInfoBase)
'			#Region "FTP"
			settings.LoadProperty(SendAbortSignals, True)
			settings.LoadProperty(SendAborCommand, 0)
			settings.LoadProperty(ChangeDirBeforeListing, True)
			settings.LoadProperty(ChangeDirBeforeTransfer, False)
			settings.LoadProperty(SmartPath, False)
			settings.LoadProperty(Compress, False)
'			#End Region
		End Sub
	End Class
End Namespace
