Imports System.IO

Class MainWindow
	Private _IsClean As Boolean

	Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		_IsClean = True
	End Sub

	Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
		Dim strFilePath As String = FilePath.Text

		If File.Exists(strFilePath) Then
			_IsClean = False

			If ShortcutHelper.IsShortcut(strFilePath) Then
				IsShortcut.Text = "True"
				ResolvedFilePath.Text = ShortcutHelper.ResolveShortcut(strFilePath)
			Else
				IsShortcut.Text = "False"
			End If
		Else
			MessageBox.Show("File path does not exists")
		End If

	End Sub

	Private Sub FilePath_TextChanged(sender As Object, e As TextChangedEventArgs)
		If Not _IsClean Then
			IsShortcut.Text = String.Empty
			ResolvedFilePath.Text = String.Empty
			_IsClean = True
		End If
	End Sub

End Class
