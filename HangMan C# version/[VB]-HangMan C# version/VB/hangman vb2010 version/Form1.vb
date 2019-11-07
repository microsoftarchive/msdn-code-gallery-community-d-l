Public Class Form1

    Dim words() As String = {"active", "forum", "participation", "reward", "ratings"}
    Dim r As New Random

    Dim alphabetButtons() As Button
    Dim labels As New List(Of Label)

    Dim ignore As Boolean
    Dim stage As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        alphabetButtons = Me.Controls.OfType(Of Button).Except(New Button() {Button1}).ToArray
        Array.ForEach(alphabetButtons, Sub(b) AddHandler b.Click, AddressOf btn_click)
        Button1.PerformClick()
    End Sub

    Private Sub btn_click(sender As Object, e As EventArgs)
        If ignore Then Return
        Dim b As Button = DirectCast(sender, Button)
        b.Enabled = False

        Array.ForEach(labels.ToArray, Sub(lbl) lbl.Text = If(lbl.Tag.ToString = b.Text, b.Text, lbl.Text))
        For x As Integer = 1 To labels.Count - 1
            labels(x).Left = labels(x - 1).Right
        Next

        If labels(labels.Count - 1).Right > Me.ClientSize.Width - 14 Then
            Me.SetClientSizeCore(labels(labels.Count - 1).Right + 14, 381)
        End If

        stage += If(Not labels.Any(Function(lbl) lbl.Text = b.Text), 1, 0)
        ignore = labels.All(Function(lbl) lbl.Text <> " ") OrElse stage = 10

        Me.Invalidate()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.SetClientSizeCore(546, 381)
        Dim word As String = words(r.Next(0, words.Length)).ToUpper
        Array.ForEach(Me.Controls.OfType(Of Label).ToArray, Sub(lbl) lbl.Dispose())
        Array.ForEach(alphabetButtons, Sub(b) b.Enabled = True)
        labels = New List(Of Label)
        Dim startX As Integer = 14
        For Each c As Char In word
            Dim lbl As New Label
            lbl.Text = " "
            lbl.Font = New Font(Me.Font.Name, 35, FontStyle.Underline)
            lbl.Location = New Point(startX, 250)
            lbl.Tag = c.ToString
            lbl.AutoSize = True
            Me.Controls.Add(lbl)
            labels.Add(lbl)
            startX = lbl.Right
        Next
        ignore = False
        stage = 0
        Me.Invalidate()
    End Sub

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If stage >= 1 Then
            e.Graphics.DrawLine(New Pen(Color.Black, 2), 85, 190, 210, 190)
        End If
        If stage >= 2 Then
            e.Graphics.DrawLine(New Pen(Color.Black, 2), 148, 190, 148, 50)
        End If
        If stage >= 3 Then
            e.Graphics.DrawLine(New Pen(Color.Black, 2), 148, 50, 198, 50)
        End If
        If stage >= 4 Then
            e.Graphics.DrawLine(New Pen(Color.Black, 2), 198, 50, 198, 70)
        End If
        If stage >= 5 Then
            e.Graphics.DrawEllipse(New Pen(Color.Black, 2), New Rectangle(188, 70, 20, 20))
        End If
        If stage >= 6 Then
            e.Graphics.DrawLine(New Pen(Color.Black, 2), 198, 90, 198, 130)
        End If
        If stage >= 7 Then
            e.Graphics.DrawLine(New Pen(Color.Black, 2), 198, 95, 183, 115)
        End If
        If stage >= 8 Then
            e.Graphics.DrawLine(New Pen(Color.Black, 2), 198, 95, 213, 115)
        End If
        If stage >= 9 Then
            e.Graphics.DrawLine(New Pen(Color.Black, 2), 198, 130, 183, 170)
        End If
        If stage >= 10 Then
            e.Graphics.DrawLine(New Pen(Color.Black, 2), 198, 130, 213, 170)
        End If
    End Sub
End Class
