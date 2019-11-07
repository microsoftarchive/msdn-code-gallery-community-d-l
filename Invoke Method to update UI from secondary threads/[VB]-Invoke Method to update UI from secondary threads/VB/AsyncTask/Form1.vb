Imports System.IO

Public Class Form1

    Dim wordList As New List(Of String)

    Public Sub AddWords(letter As Char, lbl As Label)
        Using sR As New StreamReader(Application.StartupPath & "\text\dizionario_" & letter & ".txt")
            While Not sR.EndOfStream
                Dim word As String = sR.ReadLine

                wordList.Add(word)

                lbl.Invoke(Sub()
                               lbl.Text = word
                               counter.Text = wordList.Count.ToString
                               Me.Refresh()
                           End Sub)


            End While
        End Using

        lbl.ForeColor = Color.Green
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True

        Dim _x As Integer = 8
        Dim _y As Integer = 40

        For ii As Integer = Asc("a") To Asc("z")

            Dim c As New Label
            c.Name = "Label" & ii.ToString("000")
            c.Text = "---"
            c.Top = _y
            c.Left = _x
            Me.Controls.Add(c)

            _y += 20
            If _y > 180 Then
                _y = 40
                _x += 120
            End If

            Dim j As Integer = ii
            Dim t As New Task(Sub()
                                  AddWords(Chr(j), CType(Me.Controls("Label" & j.ToString("000")), Label))
                              End Sub)

            t.Start()
        Next

    End Sub

End Class
