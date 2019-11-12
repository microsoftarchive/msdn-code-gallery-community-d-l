Imports System.Text
Imports System.Threading

Namespace ClientSample
	Partial Friend Class ClientController
		Private _reconnecting As Boolean ' Indicates whether the connection is closed unexpectedly and the app is about to reconnect.

		Private _state As ConnectionState ' The connection state.
		Private _serverType As ServerProtocol

		Private _currentDirectory As String
		Private _currentLocalDirectory As String
		Private _aborting As Boolean

		Public ReadOnly Property CurrentLocalDirectory() As String
			Get
				Return _currentLocalDirectory
			End Get
		End Property

		Public ReadOnly Property CurrentRemoteDirectory() As String
			Get
				Return _currentDirectory
			End Get
		End Property
	End Class
End Namespace
