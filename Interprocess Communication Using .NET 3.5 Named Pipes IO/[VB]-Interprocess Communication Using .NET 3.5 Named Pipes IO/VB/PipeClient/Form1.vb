Imports System.IO
Imports System.IO.Pipes

Public Class Form1

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        Using pipeClient As NamedPipeClientStream = New NamedPipeClientStream(".", "testpipe", _
                                                                        PipeDirection.Out, _
                                                                 PipeOptions.Asynchronous)
            tbStatus.Text = "Attempting to connect to pipe..."
            Try
                pipeClient.Connect(2000)
            Catch ex As Exception
                MessageBox.Show("The Pipe server must be started in order to send data to it.")
                Return
            End Try
            tbStatus.Text = "Connected to pipe."
            Using sw As StreamWriter = New StreamWriter(pipeClient)
                sw.WriteLine(tbClientText.Text)
            End Using
        End Using
        tbStatus.Text = ""
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class
