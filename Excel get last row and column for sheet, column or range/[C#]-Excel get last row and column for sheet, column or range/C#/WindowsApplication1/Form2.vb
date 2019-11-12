Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MyFile.txt")

        Dim data As New List(Of String)

        If IO.File.Exists(fileName) Then
            data = IO.File.ReadAllLines(fileName).ToList
            data.AddRange(TextBox1.Lines)
        Else
            data = TextBox1.Lines.ToList
        End If
        IO.File.WriteAllLines(fileName, data.ToArray)
    End Sub
End Class