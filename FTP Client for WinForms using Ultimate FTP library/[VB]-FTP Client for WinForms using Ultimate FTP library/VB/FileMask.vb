Namespace ClientSample
	Partial Public Class FileMask
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Public Sub New(ByVal mask As String, ByVal expand As Boolean)
			InitializeComponent()

			txtFileType.Text = mask

			If expand Then
				Me.Text = "Expand selection"
			Else
				Me.Text = "Shrink selection"
			End If
		End Sub

		Public Sub New(ByVal mask As String, ByVal title As String)
			InitializeComponent()

			txtFileType.Text = mask

			Me.Text = title
		End Sub

		Public ReadOnly Property Mask() As String
			Get
				Return txtFileType.Text
			End Get
		End Property

		''' <summary>
		''' Handles the OK button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
			' Check for invalid characters.
			If Mask.Contains("/") OrElse Mask.Contains("\") Then
				MessageBox.Show("Character '/' or '\' should not be entered", "New Name Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				Return
			End If

			Me.DialogResult = System.Windows.Forms.DialogResult.OK
		End Sub
	End Class
End Namespace