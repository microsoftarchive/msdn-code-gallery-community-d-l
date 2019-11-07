Imports System.Data
Imports System.Runtime.InteropServices
Imports System.Text
Public Class Form1

    Private Sub BTNReadTEXT_Click(sender As System.Object, e As System.EventArgs) Handles BTNReadTEXT.Click

        If rdoNotepad.Checked = True Then
            pnlNotepad.Visible = True
            pnlNotepad.BringToFront()

            pnlApplication.Visible = False
            pnlApplication.SendToBack()

            ReadtextfromNotepad()
        End If
        If rdoApp.Checked = True Then
            pnlNotepad.Visible = False
            pnlNotepad.SendToBack()

            pnlApplication.Visible = True
            pnlApplication.BringToFront()
            ReadtextfromApplication()
        End If
    End Sub
    Public Function ReadtextfromNotepad()
        'Find the running notepad window
        Dim Hwnd As IntPtr = SHANUEPTR.FindWindow(Nothing, txtTitle.Text)
        Dim NumText As Integer
        'Find the Edit control of the Running Notepad
        Dim ChildHandle As IntPtr = SHANUEPTR.FindWindowEx(Hwnd, IntPtr.Zero, "Edit", Nothing)

        'Alloc memory for the buffer that recieves the text
        Dim Hndl As IntPtr = Marshal.AllocHGlobal(10000)

        'Send The WM_GETTEXT Message
        NumText = SHANUEPTR.SendMessage(ChildHandle, SHANUEPTR.WM_GETTEXT, 10000, Hndl)

        'copy the characters from the unmanaged memory to a managed string
        Text = Marshal.PtrToStringUni(Hndl)
        If Text = "AutoCompleteProxy" Then
            MessageBox.Show("Enter the valid Notepad text file Name. Note :  the note pad text file name should be as full text as same as titile of note pad / The Note pad should be open if its closed the text can not be read.This sample will load only the active notepad text file text.")
            Exit Function

        End If
        'Display the string using a label
        txtNotepadread.Text = Text
        txtNotepadWrite.Text = Text
    End Function

    Public Function WritetextfromNotepad()
        Dim Hwnd As IntPtr = SHANUEPTR.FindWindow(Nothing, txtTitle.Text)

        Dim Handle As IntPtr = SHANUEPTR.FindWindowEx(Hwnd, IntPtr.Zero, "Edit", Nothing)
        Dim TexttoWritetoNotepad As String = txtNotepadWrite.Text.Trim()
        SHANUEPTR.SendMessageSTRING(Handle, SHANUEPTR.WM_SETTEXT, TexttoWritetoNotepad.Length, TexttoWritetoNotepad)
    End Function

    Private Sub btnNotepadTextWrite_Click(sender As System.Object, e As System.EventArgs) Handles btnNotepadTextWrite.Click
        WritetextfromNotepad()
    End Sub

    Private Sub btnNotepadTextread_Click(sender As System.Object, e As System.EventArgs) Handles btnNotepadTextread.Click
        ReadtextfromNotepad()
    End Sub

    Private Sub rdoApp_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoApp.CheckedChanged
        If rdoApp.Checked = True Then
            txtTitle.Text = "SHANU_SAMPLE_APPLICATION"
        End If
    End Sub

    Private Sub rdoNotepad_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoNotepad.CheckedChanged
        If rdoNotepad.Checked = True Then
            txtTitle.Text = "SHANUEPTR.txt - 메모장"
        End If
    End Sub


    Public Function ReadtextfromApplication()
        ListView1.Items.Clear()
        Dim Hndl As IntPtr = Marshal.AllocHGlobal(200)
        Dim NumText As Integer



        Static count As Integer = 0
        Dim enumerator As New SHANUEPTR()
        Dim sb As New StringBuilder()
        For Each top As ApiWindow In enumerator.GetTopLevelWindows
            count = 0

            'If top.MainWindowTitle = "E2Max-MTMS - [공지사항]" Then
            If top.MainWindowTitle = txtTitle.Text Then
                '  MessageBox.Show(top.MainWindowTitle)

                For Each child As ApiWindow In enumerator.GetChildWindows(top.hWnd)
                    '  Console.WriteLine(child.MainWindowTitle)

                    Dim lvi As ListViewItem

                    NumText = SHANUEPTR.SendMessage(child.hWnd, SHANUEPTR.WM_GETTEXT, 10000, Hndl)
                    Text = Marshal.PtrToStringUni(Hndl)
                    lvi = New ListViewItem(child.ClassName.ToString())
                    lvi.SubItems.Add(child.hWnd.ToString())
                    lvi.SubItems.Add(child.MainWindowTitle.ToString())
                    ListView1.Items.Add(lvi)
                 
                   
                Next child
            End If
        Next top
    End Function

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then


            lblControlID.Text = ListView1.SelectedItems(0).SubItems(1).Text.ToString()

            txtAppread.Text = ListView1.SelectedItems(0).SubItems(2).Text.ToString()
            txtAppWrite.Text = ListView1.SelectedItems(0).SubItems(2).Text.ToString()

        End If


    End Sub



    Private Sub btnAppRead_Click(sender As System.Object, e As System.EventArgs) Handles btnAppRead.Click
        ReadtextfromApplication()
    End Sub

    Private Sub btnAppWrite_Click(sender As System.Object, e As System.EventArgs) Handles btnAppWrite.Click
        Dim s As String = txtAppWrite.Text
        Dim hWnd_New As Int32
        hWnd_New = Convert.ToInt32(lblControlID.Text.Trim())

        Dim s32 As Int32 = SHANUEPTR.SendMessageSTRING(hWnd_New, SHANUEPTR.WM_SETTEXT, IntPtr.Zero, s)
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
