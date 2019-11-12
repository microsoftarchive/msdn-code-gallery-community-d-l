Namespace ClientSample
	Partial Public Class NewNamePrompt
		Inherits Form
		Public Sub New(ByVal oldName As String)
			InitializeComponent()

			txtNewName.Text = oldName
		End Sub

		''' <summary>
		''' Gets the desired new name.
		''' </summary>
		Public ReadOnly Property NewName() As String
			Get
				Return txtNewName.Text
			End Get
		End Property

		''' <summary>
		''' Handles the OK button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
			' Check for invalid characters.
			If NewName.Contains("/") OrElse NewName.Contains("\") Then
				MessageBox.Show("Character '/' or '\' should not be entered", "New Name Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				Return
			End If

			Me.DialogResult = System.Windows.Forms.DialogResult.OK
		End Sub
	End Class
End Namespace