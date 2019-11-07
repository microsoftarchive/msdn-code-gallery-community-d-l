Public Class Images
    Public Property Items As New List(Of ListData)
    Public Sub New()
        Dim ops As New DatabaseImageOperations
        If ops.HasRecords Then




        Else
            Dim FolderName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images")
            Dim currentImage As Image = Nothing

            For Each file As String In IO.Directory.GetFiles(FolderName)
                Dim ms As IO.MemoryStream = New System.IO.MemoryStream(IO.File.ReadAllBytes(file))
                currentImage = Image.FromStream(ms)

                Items.Add(New ListData With
                          {
                            .Path = file,
                            .DisplayName = IO.Path.GetFileNameWithoutExtension(file),
                            .Image = currentImage,
                            .Description = IO.Path.GetFileName(file)
                          }
                )
            Next
        End If


    End Sub
End Class
Public Class ListData
    Public Property Id As Integer
    Public Property DisplayName As String
    Public Property Path As String
    Public Property Image As Image
    Public Property Description As String

End Class
