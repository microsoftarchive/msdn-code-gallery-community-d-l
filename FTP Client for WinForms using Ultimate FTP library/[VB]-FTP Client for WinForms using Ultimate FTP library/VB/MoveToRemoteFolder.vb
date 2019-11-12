Namespace ClientSample
	Partial Public Class MoveToRemoteFolder
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Public Sub New(ByVal remoteDir As String)
			InitializeComponent()

			txtRemoteDir.Text = remoteDir
		End Sub

		''' <summary>
		''' Gets the path to the desired destination remote folder.
		''' </summary>
		Public ReadOnly Property RemoteDir() As String
			Get
				Return txtRemoteDir.Text
			End Get
		End Property

		''' <summary>
		''' Gets the search file masks.
		''' </summary>
		Public ReadOnly Property FileMasks() As String
			Get
				Return txtMasks.Text
			End Get
		End Property
	End Class
End Namespace