Imports System.ComponentModel
Imports System.Runtime.InteropServices
Public Class CueTextBox
    Inherits TextBox

    <Category("WaterMark"), Description("Text to display for cue text"), Localizable(True)>
    Public Property Cue() As String
        Get
            Return mCue
        End Get
        Set(ByVal value As String)
            mCue = value
            updateCue()
        End Set
    End Property
    <Category("WaterMark"), Description("Cue text behavior")>
    Public Property WaterMarkOption() As WaterMark
        Get
            Return mWaterMark
        End Get
        Set(ByVal value As WaterMark)
            mWaterMark = value
            updateCue()
        End Set
    End Property
    Private Sub updateCue()
        If IsHandleCreated AndAlso mCue IsNot Nothing Then
            SendMessage(Me.Handle, &H1501, CType(WaterMarkOption, IntPtr), mCue)
        End If
    End Sub
    Protected Overrides Sub OnHandleCreated(ByVal e As EventArgs)
        MyBase.OnHandleCreated(e)
        updateCue()
    End Sub
    Private mCue As String = "Enter text"
    Private mWaterMark As WaterMark = WaterMark.Hide

    <DllImport("user32.dll", CharSet:=CharSet.Unicode)>
    Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wp As IntPtr, ByVal lp As String) As IntPtr
    End Function
End Class
Public Module Enumerations
    Public Enum WaterMark
        ' Hide cue text when entering control
        Hide = 0
        ' Show cue text when entering control until user begins to type
        Show = 1
    End Enum
End Module
