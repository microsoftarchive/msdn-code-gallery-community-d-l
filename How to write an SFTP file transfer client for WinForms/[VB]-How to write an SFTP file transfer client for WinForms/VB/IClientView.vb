Imports System.Text
Imports ComponentPro.IO

Namespace ClientSample
	''' <summary>
	''' Login state.
	''' </summary>
	Public Enum LoginEnableState
		LoginEnabled
		LoginDisabled
		LogoutEnabled
		LogoutDisabled
	End Enum

	Public Class ListItemInfo
		Public FileInfo As AbstractFileInfo
		Public Permissions As String
		Public LinkedFile As AbstractFileInfo

		Public Sub New()

		End Sub

		Public Sub New(ByVal info As AbstractFileInfo)
			FileInfo = info
		End Sub
	End Class

	Friend Interface IClientView
		Function GetLogger() As TraceListener
		Sub EnableView(ByVal enable As Boolean)
		Sub EnableProgress(ByVal enable As Boolean)
		Sub EnableLogin(ByVal enable As LoginEnableState)
		Sub ShowError(ByVal message As String)
		Sub ShowError(ByVal ex As Exception)
		Sub ShowMessage(ByVal message As String)
		Function AskForPassword(ByVal title As String) As String
		Sub AskOverwrite(ByVal e As TransferConfirmEventArgs)

		Sub WriteLine(ByVal str As String, ByVal color As Color)

		Function AskYesNo(ByVal message As String) As Boolean

		Sub UpdateRemotePath(ByVal path As String)
		Sub UpdateLocalPath(ByVal path As String)

		Sub ListRemoteFiles(ByVal viewList As List(Of ListItemInfo))
		Sub ListLocalFiles(ByVal viewList As List(Of ListItemInfo))

		Sub UpdateProgress(ByVal e As FileSystemProgressEventArgs, ByVal smallProgress As Boolean, ByVal totalProgress As Boolean)
		Sub UpdateStatus(ByVal text As String)
	End Interface
End Namespace
