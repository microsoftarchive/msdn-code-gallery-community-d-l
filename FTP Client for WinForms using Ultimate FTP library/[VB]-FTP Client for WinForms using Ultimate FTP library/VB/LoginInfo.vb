Imports ComponentPro.IO
Imports ComponentPro.Net

Namespace ClientSample
	Public Class LoginInfo
		Public Const LogLevel As String = "LogLevel"
		Public Const ServerName As String = "ServerName"
		Public Const ServerPort As String = "ServerPort"
		Public Const UserName As String = "Username"
		Public Const Password As String = "Password"
		Public Const RemoteDir As String = "RemoteDir"
		Public Const LocalDir As String = "LocalDir"

		Public Const Utf8Encoding As String = "Utf8Encoding"

		#Region "Proxy"

		Public Const ProxyServer As String = "ProxyServer"
		Public Const ProxyPort As String = "ProxyPort"
		Public Const ProxyUser As String = "ProxyUser"
		Public Const ProxyPassword As String = "ProxyPassword"
		Public Const ProxyDomain As String = "ProxyDomain"
		Public Const ProxyType As String = "ProxyType"
		Public Const ProxyHttpAuthnMethod As String = "ProxyHttpAuthnMethod"

		#End Region

		Public Const SyncMethod As String = "SyncMethod"
		Public Const SyncResumability As String = "SyncResumability"
		Public Const SyncDateTime As String = "SyncDateTime"
		Public Const SyncRecursive As String = "SyncRecursive"
		Public Const SyncSearchPattern As String = "SyncSearchPattern"

		#Region "Methods"

		Public Shared Sub SaveConfig(ByVal settings As SettingInfoBase)
			' Save Login information.
			settings.SaveProperty(ServerName)
			settings.SaveProperty(ServerPort)
			settings.SaveProperty(UserName)
			settings.SaveProperty(Password)
			settings.SaveProperty(RemoteDir)
			settings.SaveProperty(LocalDir)

			settings.SaveProperty(Utf8Encoding)

			' Proxy Info.
			settings.SaveProperty(ProxyServer)
			settings.SaveProperty(ProxyPort)
			settings.SaveProperty(ProxyUser)
			settings.SaveProperty(ProxyPassword)
			settings.SaveProperty(ProxyDomain)
			settings.SaveProperty(ProxyType)
			settings.SaveProperty(ProxyHttpAuthnMethod)

			settings.SaveProperty(SyncMethod)
			settings.SaveProperty(SyncResumability)
			settings.SaveProperty(SyncDateTime)
			settings.SaveProperty(SyncRecursive)
			settings.SaveProperty(SyncSearchPattern)

			settings.SaveProperty(LogLevel)
		End Sub

		Public Shared Sub LoadConfig(ByVal settings As SettingInfoBase)
			' Server and authentication info.
			settings.LoadProperty(ServerName, String.Empty)
			settings.LoadProperty(ServerPort, 21)
			settings.LoadProperty(UserName, String.Empty)
			settings.LoadProperty(Password, String.Empty)
			settings.LoadProperty(RemoteDir, String.Empty)
			settings.LoadProperty(LocalDir, AppDomain.CurrentDomain.BaseDirectory)

			settings.LoadProperty(Utf8Encoding, False)

			' Proxy info.
			settings.LoadProperty(ProxyServer, String.Empty)
			settings.LoadProperty(ProxyPort, 1080)
			settings.LoadProperty(ProxyUser, String.Empty)
			settings.LoadProperty(ProxyPassword, String.Empty)
			settings.LoadProperty(ProxyDomain, String.Empty)
			settings.LoadProperty(ProxyType, 0)
			settings.LoadProperty(ProxyHttpAuthnMethod, 0)

			settings.LoadProperty(SyncMethod, 0)
			settings.LoadProperty(SyncResumability, False)
			settings.LoadProperty(SyncDateTime, True)
			settings.LoadProperty(SyncRecursive, CInt(RecursionMode.RecurseIntoAllSubFolders))
			settings.LoadProperty(SyncSearchPattern, "*.*")

			settings.LoadProperty(LogLevel, CInt(TraceEventType.Information))
		End Sub

		#End Region
	End Class
End Namespace