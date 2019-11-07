Public Class MainForm
    Private bs As New BindingSource
    Private ops As New DatabaseImageOperations
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmdInsertImage.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim Identifier As Integer = 0
            Dim fileBytes As Byte() = IO.File.ReadAllBytes(OpenFileDialog1.FileName)
            If ops.InsertImage(fileBytes, Now.ToShortTimeString, Identifier) = Success.Okay Then
                CType(bs.DataSource, DataTable).Rows.Add(New Object() {Identifier, fileBytes, Now.ToShortTimeString})
            End If
        End If
    End Sub
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.AutoGenerateColumns = False
        bs.DataSource = ops.DataTable
        DataGridView1.DataSource = bs

        Dim ImageBinding As New Binding("Image", bs, "ImageData")
        AddHandler ImageBinding.Format, AddressOf BindImage
        PictureBox1.DataBindings.Add(ImageBinding)
    End Sub
    Private Sub BindImage(ByVal sender As Object, ByVal e As ConvertEventArgs)
        If e.DesiredType Is GetType(Image) Then
            Dim ms As New System.IO.MemoryStream(CType(e.Value, Byte()))
            Dim Logo As Image = Image.FromStream(ms)
            e.Value = Logo
        End If
    End Sub
End Class