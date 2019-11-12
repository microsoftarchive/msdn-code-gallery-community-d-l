Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'declare new SaveFileDialog + set it's initial properties
        Dim sfd As New SaveFileDialog With { _
        .Title = "Choose file to save to", _
        .FileName = "example.csv", _
        .Filter = "CSV (*.csv)|*.csv", _
        .FilterIndex = 0, _
        .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}

        'show the dialog + display the results in a msgbox unless cancelled

        If sfd.ShowDialog = DialogResult.OK Then

            Dim headers = (From ch In ListView1.Columns _
                     Let header = DirectCast(ch, ColumnHeader) _
                     Select header.Text).ToArray()

            Dim items() = (From item In ListView1.Items _
                  Let lvi = DirectCast(item, ListViewItem) _
                  Select (From subitem In lvi.SubItems _
                      Let si = DirectCast(subitem, ListViewItem.ListViewSubItem) _
                      Select si.Text).ToArray()).ToArray()

            Dim table As String = String.Join(",", headers) & Environment.NewLine
            For Each a In items
                table &= String.Join(",", a) & Environment.NewLine
            Next
            table = table.TrimEnd(CChar(vbCr), CChar(vbLf))
            IO.File.WriteAllText(sfd.FileName, table)

        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For x As Integer = 1 To 5
            ListView1.Items.Add(New ListViewItem(New String() {"r" & x.ToString & "c1", "r" & x.ToString & "c2", "r" & x.ToString & "c3", "r" & x.ToString & "c4", "r" & x.ToString & "c5"}))
        Next
    End Sub

End Class
