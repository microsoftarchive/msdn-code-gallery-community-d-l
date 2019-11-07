Public Class Form1

    Private Sub FileSystemTree1_FileSelected(sender As Object, e As Forms.Controls.FileInfoEventArgs) Handles FileSystemTree1.FileSelected
        txtSelected.Text = e.File.FullName
    End Sub

    Private Sub FileSystemTree1_DriveSelected(sender As Object, e As Forms.Controls.DriveInfoEventArgs) Handles FileSystemTree1.DriveSelected
        txtSelected.Text = e.Drive.Name
    End Sub

    Private Sub FileSystemTree1_DirectorySelected(sender As Object, e As Forms.Controls.DirectoryInfoEventArgs) Handles FileSystemTree1.DirectorySelected
        txtSelected.Text = e.Directory.FullName
    End Sub

    Private Sub btnShowSelectedFiles_Click(sender As Object, e As EventArgs) Handles btnShowSelectedFiles.Click
        ListBox1.Items.Clear()
        For Each file In FileSystemTree1.GetSelectedFiles()
            ListBox1.Items.Add(file.FullName)
        Next
    End Sub

    Private Sub btnShowSelectedFolders_Click(sender As Object, e As EventArgs) Handles btnShowSelectedFolders.Click
        ListBox1.Items.Clear()
        For Each directory In FileSystemTree1.GetSelectedDirectories()
            ListBox1.Items.Add(directory.FullName)
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnRoot_Click(sender As Object, e As EventArgs) Handles btnRoot.Click
        Dim strRoot As String = txtRoot.Text
        FileSystemTree1.RootDrive = strRoot
    End Sub

    Private Sub btnExpand_Click(sender As Object, e As EventArgs) Handles btnExpand.Click
        Dim path As String = txtPath.Text
        If (String.IsNullOrWhiteSpace(path) = False) Then
            FileSystemTree1.Expand(path)
        End If
    End Sub

    Private Sub btnCollapse_Click(sender As Object, e As EventArgs) Handles btnCollapse.Click
        Dim path As String = txtPath.Text
        If (String.IsNullOrWhiteSpace(path) = False) Then
            FileSystemTree1.Collapse(path)
        End If
    End Sub
End Class
