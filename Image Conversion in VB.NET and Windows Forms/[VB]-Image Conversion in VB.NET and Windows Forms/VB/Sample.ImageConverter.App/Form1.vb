Imports System.Drawing.Imaging

Public Class Form1

    Private Sub UpdateFolderList(sender As System.Object, e As EventArgs) Handles ctlDriveListBox.SelectedIndexChanged
        ctlFolderList.Path = ctlDriveListBox.Drive
    End Sub

    Private Sub UpdateFileList(sender As System.Object, e As EventArgs) Handles ctlFolderList.SelectedIndexChanged
        ctlFileList.Path = ctlFolderList.Path
        lblLocation.Text = ctlFileList.Path
    End Sub

    Private Sub ShowPicture(sender As System.Object, e As EventArgs) Handles ctlFileList.SelectedIndexChanged
        Dim imageLocation As String = ctlFileList.Path & "\" & ctlFileList.FileName

        ctlPicture.ImageLocation = imageLocation
        lblLocation.Text = imageLocation
    End Sub

    Private Sub ConvertImage(sender As System.Object, e As EventArgs) Handles btnConvert.Click

        Dim fileName As String = "c:\temp\image" & DateTime.Now.Ticks.ToString()

        Dim fileExtension As String

        If (String.IsNullOrEmpty(ComboBox1.SelectedItem)) Then
            fileExtension = ".jpg"
        Else
            fileExtension = "." & ComboBox1.SelectedItem
        End If

        fileName += fileExtension

        Dim imageFormat As ImageFormat = GetImageFormatForSelectedCombo()

        Dim image As Bitmap = Drawing.Image.FromFile(ctlFileList.Path & "\" & ctlFileList.FileName)
        Dim encoderParameters As New EncoderParameters(1)
        encoderParameters.Param(0) = New EncoderParameter(Encoder.Quality, 100L)
        image.Save(fileName, GetNewEncoder(imageFormat), encoderParameters)

    End Sub

    Private Function GetImageFormatForSelectedCombo() As ImageFormat
        Select Case ComboBox1.SelectedItem
            Case "JPEG"
                Return ImageFormat.Jpeg
            Case "PNG"
                Return ImageFormat.Png
            Case "GIF"
                Return ImageFormat.Gif
            Case Else
                Return ImageFormat.Jpeg
        End Select

    End Function

    Public Function GetNewEncoder(format As ImageFormat) As ImageCodecInfo

        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageDecoders()
        For Each imageCodecInfo As ImageCodecInfo In From imageCodecInfo1 In codecs Where (imageCodecInfo1.FormatID = format.Guid)
            Return imageCodecInfo
        Next
        Return Nothing
    End Function

End Class
