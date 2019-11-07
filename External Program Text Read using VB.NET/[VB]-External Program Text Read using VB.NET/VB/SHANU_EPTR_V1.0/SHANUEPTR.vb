Imports System.Data
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Collections.Generic
Public Class ApiWindow
    Public MainWindowTitle As String = ""
    Public ClassName As String = ""
    Public hWnd As Int32
End Class
Public Class SHANUEPTR
    Public Const WM_GETTEXT As Integer = &HD
    Public Const LB_GETCOUNT = &H18B
    Public Const LB_GETTEXT = &H189
    Public Const LB_GETTEXTLEN = &H18A

    Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal msg As Integer, _
    ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Public Shared Function FindWindowEx(ByVal parentHandle As IntPtr, _
                                     ByVal childAfter As IntPtr, _
                                     ByVal lclassName As String, _
                                     ByVal windowTitle As String) As IntPtr
    End Function
    Declare Auto Function UpdateWindow Lib "user32.dll" (ByVal hWnd As Int32) As Int32
    Declare Auto Function redrawwindow Lib "user32.dll" (ByVal hWnd As Int32) As Int32
    Declare Auto Function FindWindow Lib "user32.dll" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr


    Public Const WM_SETTEXT = &HC
    Public Declare Function SendMessageSTRING Lib "user32.dll" Alias "SendMessageA" (ByVal hwnd As Int32, _
   ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As String) As Int32

    '    Private Declare Function FindWindow Lib "user32.dll" Alias _
    '"FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Int32
    Private Declare Function FindWindowEx Lib "user32.dll" Alias _
  "FindWindowExA" (ByVal hWnd1 As Int32, ByVal hWnd2 As Int32, ByVal lpsz1 As String, _
  ByVal lpsz2 As String) As Int32


    Private Delegate Function EnumCallBackDelegate(ByVal hwnd As Integer, ByVal lParam As Integer) As Integer


    ' Top-level windows.
    Private Declare Function EnumWindows Lib "user32" _
     (ByVal lpEnumFunc As EnumCallBackDelegate, ByVal lParam As Integer) As Integer

    ' Child windows.
    Private Declare Function EnumChildWindows Lib "user32" _
     (ByVal hWndParent As Integer, ByVal lpEnumFunc As EnumCallBackDelegate, ByVal lParam As Integer) As Integer

    ' Get the window class.
    Private Declare Function GetClassName _
     Lib "user32" Alias "GetClassNameA" _
     (ByVal hwnd As Integer, ByVal lpClassName As StringBuilder, ByVal nMaxCount As Integer) As Integer

    ' Test if the window is visible--only get visible ones.
    Private Declare Function IsWindowVisible Lib "user32" _
     (ByVal hwnd As Integer) As Integer

    ' Test if the window's parent--only get the one's without parents.
    Private Declare Function GetParent Lib "user32" _
     (ByVal hwnd As Integer) As Integer

    ' Get window text length signature.
    Private Declare Function SendMessage _
     Lib "user32" Alias "SendMessageA" _
     (ByVal hwnd As Int32, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As Int32

    ' Get window text signature.
    Private Declare Function SendMessage _
     Lib "user32" Alias "SendMessageA" _
     (ByVal hwnd As Int32, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As StringBuilder) As Int32

    Private _listChildren As New List(Of ApiWindow)
    Private _listTopLevel As New List(Of ApiWindow)

    Private _topLevelClass As String = ""
    Private _childClass As String = ""


    Public Overloads Function GetTopLevelWindows() As List(Of ApiWindow)

        EnumWindows(AddressOf EnumWindowProc, &H0)

        Return _listTopLevel

    End Function
    Public Overloads Function GetTopLevelWindows(ByVal className As String) As List(Of ApiWindow)

        _topLevelClass = className

        Return Me.GetTopLevelWindows()

    End Function

    ''' <summary>
    ''' Get all child windows for the specific windows handle (hwnd).
    ''' </summary>
    ''' <returns>List of child windows for parent window</returns>
    Public Overloads Function GetChildWindows(ByVal hwnd As Int32) As List(Of ApiWindow)

        ' Clear the window list.
        _listChildren = New List(Of ApiWindow)

        ' Start the enumeration process.
        EnumChildWindows(hwnd, AddressOf EnumChildWindowProc, &H0)

        ' Return the children list when the process is completed.
        Return _listChildren

    End Function

    Public Overloads Function GetChildWindows(ByVal hwnd As Int32, ByVal childClass As String) As List(Of ApiWindow)

        ' Set the search
        _childClass = childClass

        Return Me.GetChildWindows(hwnd)

    End Function

    ''' <summary>
    ''' Callback function that does the work of enumerating top-level windows.
    ''' </summary>
    ''' <param name="hwnd">Discovered Window handle</param>
    ''' <returns>1=keep going, 0=stop</returns>
    Private Function EnumWindowProc(ByVal hwnd As Int32, ByVal lParam As Int32) As Int32

        ' Eliminate windows that are not top-level.
        If GetParent(hwnd) = 0 AndAlso CBool(IsWindowVisible(hwnd)) Then

            ' Get the window title / class name.
            Dim window As ApiWindow = GetWindowIdentification(hwnd)

            ' Match the class name if searching for a specific window class.
            If _topLevelClass.Length = 0 OrElse window.ClassName.ToLower() = _topLevelClass.ToLower() Then
                _listTopLevel.Add(window)
            End If

        End If

        ' To continue enumeration, return True (1), and to stop enumeration 
        ' return False (0).
        ' When 1 is returned, enumeration continues until there are no 
        ' more windows left.

        Return 1

    End Function

    ''' <summary>
    ''' Callback function that does the work of enumerating child windows.
    ''' </summary>
    ''' <param name="hwnd">Discovered Window handle</param>
    ''' <returns>1=keep going, 0=stop</returns>
    Private Function EnumChildWindowProc(ByVal hwnd As Int32, ByVal lParam As Int32) As Int32

        Dim window As ApiWindow = GetWindowIdentification(hwnd)

        ' Attempt to match the child class, if one was specified, otherwise
        ' enumerate all the child windows.
        If _childClass.Length = 0 OrElse window.ClassName.ToLower() = _childClass.ToLower() Then
            _listChildren.Add(window)
        End If

        Return 1
    End Function

    ''' <summary>
    ''' Build the ApiWindow object to hold information about the Window object.
    ''' </summary>
    Private Function GetWindowIdentification(ByVal hwnd As Integer) As ApiWindow

        Const WM_GETTEXT As Int32 = &HD
        Const WM_GETTEXTLENGTH As Int32 = &HE

        Dim window As New ApiWindow()

        Dim title As New StringBuilder()

        ' Get the size of the string required to hold the window title.
        Dim size As Int32 = SendMessage(hwnd, WM_GETTEXTLENGTH, 0, 0)

        ' If the return is 0, there is no title.
        If size > 0 Then
            title = New StringBuilder(size + 1)

            SendMessage(hwnd, WM_GETTEXT, title.Capacity, title)
        End If

        ' Get the class name for the window.
        Dim classBuilder As New StringBuilder(64)
        GetClassName(hwnd, classBuilder, 64)

        ' Set the properties for the ApiWindow object.
        window.ClassName = classBuilder.ToString()
        window.MainWindowTitle = title.ToString()
        window.hWnd = hwnd

        Return window

    End Function
End Class
