Public Class Form1
    Private FileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PeopleData.xlsx")
    Private Connection As OleDbHelper.Connections = New OleDbHelper.Connections

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.Text = ""

        If Not String.IsNullOrWhiteSpace(TextBox1.Text) Then
            Dim ConnectionString As String = Connection.NoHeaderConnectionString(FileName)
            Using cn As New OleDb.OleDbConnection With {.ConnectionString = ConnectionString}
                Using cmd As New OleDb.OleDbCommand With
                    {
                        .CommandText = "SELECT F1,F2 FROM [People1$] WHERE F2=@F2",
                        .Connection = cn
                    }

                    cmd.Parameters.AddWithValue("@B2", TextBox1.Text)
                    cn.Open()
                    Dim Reader = cmd.ExecuteReader
                    If Reader.HasRows Then
                        Reader.Read()
                        TextBox2.Text = Reader.GetString(0)
                    Else
                        MessageBox.Show("Nothing found.")
                    End If
                End Using
            End Using

        End If
    End Sub
End Class
