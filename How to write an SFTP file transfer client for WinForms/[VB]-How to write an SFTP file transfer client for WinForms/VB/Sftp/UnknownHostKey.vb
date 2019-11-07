Namespace ClientSample.Sftp
	Partial Public Class UnknownHostKey
		Inherits Form
		''' <summary>
		''' Gets or sets a value indicating whether to always accept the fingerprint.
		''' </summary>
		''' <value>True to accept the fingerprint; false to reject it.</value>
		Public ReadOnly Property AlwaysAccept() As Boolean
			Get
				Return Me._accept
			End Get
		End Property
		Private _accept As Boolean

		''' <summary>
		''' Initializes a new instance of the <see cref="UnknownHostKey"/> class.
		''' </summary>
		''' <param name="server">The SFTP server name.</param>
		''' <param name="port">The SFTP port</param>
		''' <param name="fingerprint">The public key fingerprint.</param>
		Public Sub New(ByVal server As String, ByVal port As Integer, ByVal fingerprint As String)
			InitializeComponent()

			lblHost.Text = server
			lblPort.Text = port.ToString()
			lblFingerprint.Text = fingerprint
		End Sub

		Private Sub btnAlwaysAccept_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAlwaysAccept.Click
			_accept = True
			Me.Close()
		End Sub

		Private Sub btnAccept_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAccept.Click
			Me.Close()
		End Sub

		Private Sub btnReject_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReject.Click
			Me.Close()
		End Sub
	End Class
End Namespace