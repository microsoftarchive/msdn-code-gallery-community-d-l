Namespace ClientSample
	''' <summary>
	''' A form that prompts for folder name.
	''' </summary>
	Partial Public Class FolderNamePrompt
		Inherits Form
		''' <summary>
		''' Initializes a new instance of the form.
		''' </summary>
		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary>
		''' Gets the desired folder name.
		''' </summary>
		Public ReadOnly Property FolderName() As String
			Get
				Return txtFolderName.Text
			End Get
		End Property

		''' <summary>
		''' Handles the OK button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
			' Show error if the folder name is empty.
			If FolderName.Length = 0 Then
				MessageBox.Show("Folder name cannot be empty", "Ftp Client Demo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				Return
			End If

			' Show error if the folder name contains one or more invalid characters.
			If FolderName.Contains("/") OrElse FolderName.Contains("\") Then
				MessageBox.Show("Character '/' or '\' should not be entered", "Ftp Client Demo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				Return
			End If

			DialogResult = System.Windows.Forms.DialogResult.OK
		End Sub
	End Class
End Namespace