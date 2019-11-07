Imports System.IO
Imports System.Security

Partial Friend Class SelectFileWindow
    Inherits ConfirmDialog

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Property ExcelDocument As FileInfo

    Private Sub BrowseButton_Click(sender As Object, e As RoutedEventArgs)
        Dim dialog As New OpenFileDialog()
        ' Limit the dialog to only show ".csv" files, 
        ' modify this as necessary to allow other file types 
        dialog.Multiselect = False
        dialog.Filter = "CSV Documents(*.csv)|*.csv|All files (*.*)|*.*"
        dialog.FilterIndex = 1
        If dialog.ShowDialog() = True Then
            Me.FileTextBox.Text = dialog.File.Name
            Me.FileTextBox.IsReadOnly = True
            Me.ExcelDocument = dialog.File

            Dim mystream As System.IO.FileStream = dialog.File.OpenRead()
            mystream.Close()
        End If
    End Sub

End Class
