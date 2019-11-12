Namespace ClientSample
	Partial Public Class PasswordPrompt
		Inherits Form
		Public Sub New(ByVal title As String)
			InitializeComponent()

			Me.Text = title
		End Sub

		''' <summary>
		''' Gets the password.
		''' </summary>
		Public ReadOnly Property Password() As String
			Get
				Return txtPassword.Text
			End Get
		End Property

		''' <summary>
		''' Handles the OK button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
			Me.DialogResult = System.Windows.Forms.DialogResult.OK
		End Sub
	End Class
End Namespace