Imports System.Runtime.InteropServices
Public Module CueBannerTextCode
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Function SendMessage(
            ByVal hWnd As IntPtr,
            ByVal msg As Integer,
            ByVal wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)>
            ByVal lParam As String) As Int32
    End Function
    Private Declare Function FindWindowEx Lib "user32" Alias "FindWindowExA" (
            ByVal hWnd1 As IntPtr,
            ByVal hWnd2 As IntPtr,
            ByVal lpsz1 As String,
            ByVal lpsz2 As String) As IntPtr

    Private Const EM_SETCUEBANNER As Integer = &H1501
    ''' <summary>
    ''' Used to place shadow text into a TextBox or ComboBox when control does not have focus
    ''' </summary>
    ''' <param name="control">Name of control</param>
    ''' <param name="text">Shadow text to show when control does not have focus</param>
    ''' <remarks>
    ''' Some might call this a watermark affect
    ''' </remarks>
    <System.Diagnostics.DebuggerStepThrough()>
    <System.Runtime.CompilerServices.Extension()>
    Public Sub SetCueText(ByVal control As Control, ByVal text As String)

        If TypeOf control Is ComboBox Then
            Dim Edit_hWnd As IntPtr = FindWindowEx(control.Handle, IntPtr.Zero, "Edit", Nothing)
            If Not Edit_hWnd = IntPtr.Zero Then
                SendMessage(Edit_hWnd, EM_SETCUEBANNER, 0, text)
            End If
        ElseIf TypeOf control Is TextBox Then
            SendMessage(control.Handle, EM_SETCUEBANNER, 0, text)
        End If
    End Sub


End Module
