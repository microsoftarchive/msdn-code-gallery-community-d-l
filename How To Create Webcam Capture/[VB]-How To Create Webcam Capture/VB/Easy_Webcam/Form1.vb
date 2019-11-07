Option Explicit On
Option Compare Binary

Public Class Form1

    'Load Webcam Device List
    Private Sub LoadDeviceList()
        On Error Resume Next
        Dim strName As String = Space(100)
        Dim strVer As String = Space(100)
        Dim bReturn As Boolean
        Dim x As Integer = 0

        Do
            bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)
            If bReturn Then lst1.Items.Add(strName.Trim)
            x += 1
            Application.DoEvents()
        Loop Until bReturn = False

    End Sub

    'Open View
    Private Sub OpenPreviewWindow()
        On Error Resume Next

        Dim iHeight As Integer = pview.Height
        Dim iWidth As Integer = pview.Width

        '
        ' Open Preview window in picturebox
        '
        hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640, _
            480, pview.Handle.ToInt32, 0)

        '
        ' Connect to device
        '
        If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) Then
            '
            'Set the preview scale
            '
            SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)

            '
            'Set the preview rate in milliseconds
            '
            SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)

            '
            'Start previewing the image from the camera
            '
            SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)

            '
            ' Resize window to fit in picturebox
            '
            SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, pview.Width, pview.Height, _
                    SWP_NOMOVE Or SWP_NOZORDER)

            cmd1.Enabled = False
            cmd2.Enabled = True
            cmd3.Enabled = True
        Else
            '
            ' Error connecting to device close window
            ' 
            DestroyWindow(hHwnd)

            cmd1.Enabled = True
            cmd2.Enabled = False
            cmd3.Enabled = False

            pview.Image = Nothing
            pview.SizeMode = PictureBoxSizeMode.StretchImage
            pview.BackColor = Color.Black
            pview.BackgroundImage = Nothing
            pview.BackgroundImageLayout = ImageLayout.None
            pview.Refresh()

        End If
    End Sub

    Private Sub ClosePreviewWindow()
        On Error Resume Next
        '
        ' Disconnect from device
        '
        SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0)

        '
        ' close window
        '

        DestroyWindow(hHwnd)

        cmd1.Enabled = True
        cmd2.Enabled = False
        cmd3.Enabled = False

        pView.Image = Nothing
        pview.SizeMode = PictureBoxSizeMode.StretchImage
        pview.BackColor = Color.Black
        pview.BackgroundImage = Nothing
        pview.BackgroundImageLayout = ImageLayout.None
        pview.Refresh()
    End Sub

    'If Form Closed
    Private Sub Form1_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        On Error Resume Next
        'If Played the Stopped
        If cmd2.Enabled Then
            ClosePreviewWindow()
        End If
    End Sub

    'Set Object To Default Value
    Private Sub ClearAllObject()
        On Error Resume Next
        opt1.Checked = False
        opt2.Checked = True
        lst1.Items.Clear()
        lst1.Refresh()
        pView.BackColor = Color.Black
        pView.BackgroundImageLayout = ImageLayout.Stretch
        pView.Image = Nothing
        pView.SizeMode = PictureBoxSizeMode.StretchImage
        pView.Refresh()

        cmd1.Enabled = True
        cmd2.Enabled = False
        cmd3.Enabled = False
        'Load Device List
        Call LoadDeviceList()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        'Load Object Value TO Default
        ClearAllObject()
    End Sub

    Private Sub cmd1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd1.Click
        On Error Resume Next
        'Device
        iDevice = lst1.SelectedIndex
        'Load And Capture Device
        OpenPreviewWindow()
    End Sub

    Private Sub cmd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd2.Click
        On Error Resume Next
        'Stop Device Capture
        ClosePreviewWindow()
    End Sub

    Private Sub cmd3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd3.Click
        On Error Resume Next

        Dim data As IDataObject
        Dim bmap As Image

        '
        ' Copy image to clipboard
        '
        SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)

        '
        ' Get image from clipboard and convert it to a bitmap
        '
        data = Clipboard.GetDataObject()
        If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
            bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)
            pView.Image = bmap

            'Stop Device Capture
            ClosePreviewWindow()

            'Set Button
            cmd3.Enabled = False
            cmd2.Enabled = False
            cmd1.Enabled = True

            'Set Save Dialog
            sfdImages.FileName = ""
            sfdImages.Title = "Save Picture"
            sfdImages.Filter = "Bitmap|*.bmp|Jpeg|*.jpg|GIF|*.gif|PNG|*.png"

            'If File Name Not Equal "" then Save The File
            If sfdImages.ShowDialog = DialogResult.OK Then
                Select Case Microsoft.VisualBasic.Right$(sfdImages.FileName, 3)
                    Case Is = "bmp"
                        bmap.Save(sfdImages.FileName, Imaging.ImageFormat.Bmp)
                    Case Is = "jpg"
                        bmap.Save(sfdImages.FileName, Imaging.ImageFormat.Jpeg)
                    Case Is = "gif"
                        bmap.Save(sfdImages.FileName, Imaging.ImageFormat.Gif)
                    Case Is = "png"
                        bmap.Save(sfdImages.FileName, Imaging.ImageFormat.Png)
                End Select
            End If

        End If

        data = Nothing
    End Sub

    Private Sub opt1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles opt1.Click
        MsgBox("Opps... Sorry, please read next tutorial about Graphics Effect!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Deactivated")
    End Sub

    Private Sub opt3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles opt3.Click
        MsgBox("Opps... Sorry, please read next tutorial about Graphics Effect!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Deactivated")
    End Sub

    Private Sub opt4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles opt4.Click
        MsgBox("Opps... Sorry, please read next tutorial about Graphics Effect!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Deactivated")
    End Sub

End Class