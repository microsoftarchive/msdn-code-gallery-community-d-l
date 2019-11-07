Imports System.Net
Imports System.IO

Module Common
    ' Global variables
    Public AppRoot As String = Application.StartupPath
    Public docsDir As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Public stimImageLoc As String = AppRoot & "\Resources\pictures\stimuli\"
    Public rTimer As Stopwatch

    Enum CentreBy
        HorizontalAndVertical = 0
        HorizontalOnly = 1
        VerticalOnly = 2
    End Enum

    Public Sub CentreInParent(ByVal childCtl As Control, ByVal centre As CentreBy)
        ' Centre a control in its parent
        Dim parentWidth As Integer = childCtl.Parent.Bounds.Width
        Dim parentHeight As Integer = childCtl.Parent.Bounds.Height
        Select Case centre
            Case 0
                childCtl.Left = parentWidth / 2 - (childCtl.Width / 2)
                childCtl.Top = parentHeight / 2 - (childCtl.Height / 2)
            Case 1
                childCtl.Left = parentWidth / 2 - (childCtl.Width / 2)
            Case 2
                childCtl.Top = parentHeight / 2 - (childCtl.Height / 2)
        End Select
    End Sub

End Module
