Imports System.Drawing.Design

Public Class TypeEditor4
    Inherits UITypeEditor

    Public Overrides Function GetPaintValueSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function

    Public Overrides Sub PaintValue(ByVal e As System.Drawing.Design.PaintValueEventArgs)
        Dim img As New Bitmap(19, 12)
        Dim gr As Graphics = Graphics.FromImage(img)
        gr.Clear(Color.FromArgb(220, 240, 245))
        e.Graphics.DrawImage(img, New Point(2, 2))
        MyBase.PaintValue(e)
    End Sub

End Class
