Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO

Public Class image
    'Public Class main
    Public Shared Sub Main()
        _0cr.ProgressBar1.Value = 25
        Dim fnIn As String = _0cr.OpenFileDialog1.FileName
        Dim fn As String = System.IO.Path.GetFileName(_0cr.OpenFileDialog1.FileName)
        Dim path As String = System.IO.Path.GetDirectoryName(_0cr.OpenFileDialog1.FileName)
        If Not System.IO.Directory.Exists(path & "/" & "temp") Then 'folder create
            System.IO.Directory.CreateDirectory(path & "/" & "temp")
        End If
        If Not System.IO.File.Exists(path & "/" & "temp" & "/" & fn) Then
            System.IO.File.Delete(path & "/" & "temp" & "/" & fn)
        End If
        For Each f In Directory.GetFiles(path & "/" & "temp" & "/", "*.tif", SearchOption.AllDirectories)
            _0cr.SplitContainer5.Panel2.Refresh()
            If fn = f Then
                File.Delete(f)
            End If
        Next
        _0cr.ProgressBar1.Value = 50
        Dim fnOut As String = path & "/" & "temp" & "/" & fn
        Dim bmpIn As New Bitmap(fnIn)
        Dim sk As New gmseDeskew(bmpIn)
        _0cr.ProgressBar1.Value = 75
        Dim skewangle As Double = sk.GetSkewAngle
        Dim bmpOut As Bitmap = RotateImage(bmpIn, -skewangle)
        _0cr.ProgressBar1.Value = 100
        bmpOut.Save(fnOut, ImageFormat.Tiff)
        'MsgBox("Skewangle: " & skewangle)
        _0cr.OpenFileDialog1.FileName = fnOut
        'System.IO.File.Delete(fnOut)
        _0cr.ProgressBar1.Value = 0
    End Sub

    Private Shared Function RotateImage(ByVal bmp As Bitmap, ByVal angle As Double) As Bitmap
        Dim g As Graphics
        Dim tmp As New Bitmap(bmp.Width, bmp.Height, PixelFormat.Format32bppRgb)
        tmp.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution)
        g = Graphics.FromImage(tmp)
        Try
            g.FillRectangle(Brushes.White, 0, 0, bmp.Width, bmp.Height)
            g.RotateTransform(angle)
            g.DrawImage(bmp, 0, 0)
        Finally
            g.Dispose()
        End Try
        Return tmp
    End Function
End Class

Public Class gmseDeskew
    ' Representation of a line in the image.
    Public Class HougLine
        ' Count of points in the line.
        Public Count As Integer
        ' Index in Matrix.
        Public Index As Integer
        ' The line is represented as all x,y that solve y*cos(alpha)-x*sin(alpha)=d
        Public Alpha As Double
        Public d As Double
    End Class
    ' The Bitmap
    Dim cBmp As Bitmap
    ' The range of angles to search for lines
    Dim cAlphaStart As Double = -20
    Dim cAlphaStep As Double = 0.2
    Dim cSteps As Integer = 40 * 5
    ' Precalculation of sin and cos.
    Dim cSinA() As Double
    Dim cCosA() As Double
    ' Range of d
    Dim cDMin As Double
    Dim cDStep As Double = 1
    Dim cDCount As Integer
    ' Count of points that fit in a line.
    Dim cHMatrix() As Integer
    ' Calculate the skew angle of the image cBmp.
    Public Function GetSkewAngle() As Double
        Dim hl() As gmseDeskew.HougLine
        Dim i As Integer
        Dim sum As Double
        Dim count As Integer
        ' Hough Transformation
        Calc()
        ' Top 20 of the detected lines in the image.
        hl = GetTop(20)
        ' Average angle of the lines
        For i = 0 To 19
            sum += hl(i).Alpha
            count += 1
        Next
        Return sum / count
    End Function

    ' Calculate the Count lines in the image with most points.
    Private Function GetTop(ByVal Count As Integer) As HougLine()
        Dim hl() As HougLine
        Dim i As Integer
        Dim j As Integer
        Dim tmp As HougLine
        Dim AlphaIndex As Integer
        Dim dIndex As Integer

        ReDim hl(Count)
        For i = 0 To Count - 1
            hl(i) = New HougLine
        Next
        For i = 0 To cHMatrix.Length - 1
            If cHMatrix(i) > hl(Count - 1).Count Then
                hl(Count - 1).Count = cHMatrix(i)
                hl(Count - 1).Index = i
                j = Count - 1
                While j > 0 AndAlso hl(j).Count > hl(j - 1).Count
                    tmp = hl(j)
                    hl(j) = hl(j - 1)
                    hl(j - 1) = tmp
                    j -= 1
                End While
            End If
        Next
        For i = 0 To Count - 1
            dIndex = hl(i).Index \ cSteps
            AlphaIndex = hl(i).Index - dIndex * cSteps
            hl(i).Alpha = GetAlpha(AlphaIndex)
            hl(i).d = dIndex + cDMin
        Next
        Return hl
    End Function
    Public Sub New(ByVal bmp As Bitmap)
        cBmp = bmp
    End Sub
    ' Hough Transforamtion:
    Private Sub Calc()
        Dim x As Integer
        Dim y As Integer
        Dim hMin As Integer = cBmp.Height / 4
        Dim hMax As Integer = cBmp.Height * 3 / 4

        Init()
        For y = hMin To hMax
            For x = 1 To cBmp.Width - 2
                ' Only lower edges are considered.
                If IsBlack(x, y) Then
                    If Not IsBlack(x, y + 1) Then
                        Calc(x, y)
                    End If
                End If
            Next
        Next
    End Sub
    ' Calculate all lines through the point (x,y).
    Private Sub Calc(ByVal x As Integer, ByVal y As Integer)
        Dim alpha As Integer
        Dim d As Double
        Dim dIndex As Integer
        Dim Index As Integer

        For alpha = 0 To cSteps - 1
            d = y * cCosA(alpha) - x * cSinA(alpha)
            dIndex = CalcDIndex(d)
            Index = dIndex * cSteps + alpha
            Try
                cHMatrix(Index) += 1
            Catch ex As Exception
                Debug.WriteLine(ex.ToString)
            End Try
        Next
    End Sub
    Private Function CalcDIndex(ByVal d As Double) As Double
        Return Convert.ToInt32(d - cDMin)
    End Function
    Private Function IsBlack(ByVal x As Integer, ByVal y As Integer) As Boolean
        Dim c As Color
        Dim luminance As Double
        c = cBmp.GetPixel(x, y)
        luminance = (c.R * 0.299) + (c.G * 0.587) + (c.B * 0.114)
        Return luminance < 140
    End Function
    Private Sub Init()
        Dim i As Integer
        Dim angle As Double
        ' Precalculation of sin and cos.
        ReDim cSinA(cSteps - 1)
        ReDim cCosA(cSteps - 1)
        For i = 0 To cSteps - 1
            angle = GetAlpha(i) * Math.PI / 180.0#
            cSinA(i) = Math.Sin(angle)
            cCosA(i) = Math.Cos(angle)
        Next
        ' Range of d:
        cDMin = -cBmp.Width
        cDCount = 2 * (cBmp.Width + cBmp.Height) / cDStep
        ReDim cHMatrix(cDCount * cSteps)
    End Sub

    Public Function GetAlpha(ByVal Index As Integer) As Double
        Return cAlphaStart + Index * cAlphaStep
    End Function
End Class
'End Class
