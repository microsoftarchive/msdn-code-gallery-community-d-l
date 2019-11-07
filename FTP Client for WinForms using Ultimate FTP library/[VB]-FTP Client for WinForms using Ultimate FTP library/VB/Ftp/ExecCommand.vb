Namespace ClientSample.Ftp
	''' <summary>
	''' A form that prompts for FTP command.
	''' </summary>
	Partial Public Class ExecCommand
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
		Public Property Command() As String
			Get
				Return txtCommand.Text
			End Get
			Set(ByVal value As String)
				txtCommand.Text = value
			End Set
		End Property

		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad(e)

			txtCommand.SelectAll()
		End Sub

		''' <summary>
		''' Handles the OK button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
			' Show error if the command is empty.
			If Command.Trim().Length = 0 Then
				MessageBox.Show("Command cannot be empty", Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
				Return
			End If

			DialogResult = System.Windows.Forms.DialogResult.OK
		End Sub
	End Class
End Namespace