Namespace ClientSample
	Public Delegate Sub SaveConfigDelegate(ByVal settings As SettingInfoBase)
	Public Delegate Sub LoadConfigDelegate(ByVal settings As SettingInfoBase)

	Public Class SettingInfoBase
		Private _values As Dictionary(Of String, Object)

		Public Function [Get](Of T)(ByVal key As String) As T
			Return CType(_values(key), T)
		End Function

		Public Sub [Set](ByVal key As String, ByVal value As Object)
			_values(key) = value
		End Sub

		#Region "Methods"

		Public Sub SaveProperty(ByVal name As String)
			Util.SaveProperty(name, _values(name))
		End Sub

		Public Sub LoadProperty(ByVal name As String, ByVal defaultValue As Integer)
			_values(name) = Util.GetIntProperty(name, defaultValue)
		End Sub

		Public Sub LoadProperty(ByVal name As String, ByVal defaultValue As Boolean)
			_values(name) = Util.GetProperty(name, defaultValue.ToString()).ToString() = "True"
		End Sub

		Public Sub LoadProperty(ByVal name As String, ByVal defaultValue As Object)
			_values(name) = Util.GetProperty(name, defaultValue)
		End Sub

		Public Overridable Sub SaveConfig(ParamArray ByVal saveDelegates() As SaveConfigDelegate)
			For i As Integer = 0 To saveDelegates.Length - 1
				saveDelegates(i)(Me)
			Next i
		End Sub

		Public Overridable Sub LoadConfig(ParamArray ByVal loadDelegates() As LoadConfigDelegate)
			_values = New Dictionary(Of String, Object)()
			For i As Integer = 0 To loadDelegates.Length - 1
				loadDelegates(i)(Me)
			Next i
		End Sub

		#End Region
	End Class

	Public Class SettingInfo
		Public Const KeepAlive As String = "KeepAlive"
		Public Const Throttle As String = "Throttle"
		Public Const Timeout As String = "Timeout"
		Public Const AsciiTransfer As String = "AsciiTransfer"
		Public Const ProgressUpdateInterval As String = "ProgressUpdateInterval"
		Public Const ShowProgressWhileDeleting As String = "ShowProgressWhileDeleting"
		Public Const ShowProgressWhileTransferring As String = "ShowProgressWhileTransferring"
		Public Const RestoreFileProperties As String = "RestoreFileProperties"

		Public Shared Sub SaveConfig(ByVal settings As SettingInfoBase)
			' Save settings.
			settings.SaveProperty(Throttle)
			settings.SaveProperty(Timeout)
			settings.SaveProperty(KeepAlive)
			settings.SaveProperty(AsciiTransfer)
			settings.SaveProperty(ProgressUpdateInterval)
			settings.SaveProperty(ShowProgressWhileDeleting)
			settings.SaveProperty(ShowProgressWhileTransferring)
			settings.SaveProperty(RestoreFileProperties)
		End Sub

		Public Shared Sub LoadConfig(ByVal settings As SettingInfoBase)
			settings.LoadProperty(Throttle, 0)
			settings.LoadProperty(Timeout, 30)
			settings.LoadProperty(KeepAlive, 60)
			settings.LoadProperty(AsciiTransfer, False)
			settings.LoadProperty(ProgressUpdateInterval, 500)
			settings.LoadProperty(ShowProgressWhileDeleting, False)
			settings.LoadProperty(ShowProgressWhileTransferring, True)
			settings.LoadProperty(RestoreFileProperties, False)
		End Sub
	End Class
End Namespace
