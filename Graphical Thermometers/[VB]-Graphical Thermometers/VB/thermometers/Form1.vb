Public Class Form1

    'class level bitmaps
    Dim img As Bitmap
    Dim bar As Bitmap

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown3.ValueChanged, NumericUpDown2.ValueChanged, NumericUpDown1.ValueChanged
        'if still loading exit sub
        If NumericUpDown1.Value = Nothing Or _
            NumericUpDown2.Value = Nothing Or _
            NumericUpDown3.Value = Nothing Or _
            img Is Nothing Or _
            bar Is Nothing Then Return

        'create new background image for thermometers
        Dim newImg As Bitmap = DirectCast(img.Clone, Bitmap)
        Dim gr As Graphics = Graphics.FromImage(newImg)

        'calculate height of bar1
        Dim barTop As Integer = If(NumericUpDown1.Value > 290, 2, 0) + CInt(257 - (((250 - NumericUpDown1.Value) / 10) * -20))
        'create a new bitmap for this thermometer bar
        Dim bar1 As New Bitmap(12, 264 - barTop)
        Dim gr1 As Graphics = Graphics.FromImage(bar1)
        'draw part of original bar image into new bitmap
        gr1.DrawImage(bar, New Rectangle(Point.Empty, bar1.Size), New Rectangle(0, My.Resources.bar.Height - bar1.Height, 12, bar1.Height), GraphicsUnit.Pixel)
        'draw new bar image onto new background image
        gr.DrawImage(bar1, New Point(61, barTop))

        'calculate height of bar2
        barTop = If(NumericUpDown2.Value > 0, 9, 7) + CInt(((100 - NumericUpDown2.Value) / 10) * 20)
        'create a new bitmap for this thermometer bar
        Dim bar2 As New Bitmap(12, 264 - barTop)
        Dim gr2 As Graphics = Graphics.FromImage(bar2)
        'draw part of original bar image into new bitmap
        gr2.DrawImage(bar, New Rectangle(Point.Empty, bar2.Size), New Rectangle(0, My.Resources.bar.Height - bar2.Height, 12, bar2.Height), GraphicsUnit.Pixel)
        'draw new bar image onto new background image
        gr.DrawImage(bar2, New Point(162, barTop))

        'calculate height of bar3
        barTop = 15 + CInt(((210 - NumericUpDown3.Value) / 10) * 11)
        'create a new bitmap for this thermometer bar
        Dim bar3 As New Bitmap(12, 264 - barTop)
        Dim gr3 As Graphics = Graphics.FromImage(bar3)
        'draw part of original bar image into new bitmap
        gr3.DrawImage(bar, New Rectangle(Point.Empty, bar3.Size), New Rectangle(0, My.Resources.bar.Height - bar3.Height, 12, bar3.Height), GraphicsUnit.Pixel)
        'draw new bar image onto new background image
        gr.DrawImage(bar3, New Point(266, barTop))

        'set PictureBox1.Image = new background image
        PictureBox1.Image = newImg
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'initialize class level bitmaps
        img = My.Resources.tempscalessmall
        bar = My.Resources.bar
        'make Color.White transparent in bar image
        bar.MakeTransparent(Color.White)
        'trigger NumericUpDowns.ValueChanged
        NumericUpDown1.Value += 1
        NumericUpDown1.Value -= 1
    End Sub

End Class
