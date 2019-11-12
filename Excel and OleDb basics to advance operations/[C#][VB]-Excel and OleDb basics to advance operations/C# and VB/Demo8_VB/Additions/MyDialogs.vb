Imports System.Runtime.InteropServices
Namespace My
    <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never)> _
    Partial Friend Class _Dialogs
        Private Function CreateLineBreaks(ByVal Text As String) As String
            Return Text.Replace("~", Environment.NewLine)
        End Function
        Public Function Question(ByVal Text As String) As Boolean
            Return (MessageBox.Show(CreateLineBreaks(Text), My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes)
        End Function
        Public Function Question(ByVal Text As String, ByVal Title As String) As Boolean
            Return (MessageBox.Show(CreateLineBreaks(Text), Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes)
        End Function
        Public Function Question(ByVal Text As String, ByVal Title As String, ByVal DefaultButton As MsgBoxResult) As Boolean
            Dim db As MessageBoxDefaultButton
            If DefaultButton = MsgBoxResult.No Then
                db = MessageBoxDefaultButton.Button2
            End If
            Return (MessageBox.Show(CreateLineBreaks(Text), Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, db) = MsgBoxResult.Yes)
        End Function
        Public Sub InformationDialog(ByVal Text As String)
            MessageBox.Show(Text, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
        Public Sub InformationDialog(ByVal Text As String, ByVal Title As String)
            MessageBox.Show(Text, Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
        Public Sub ExceptionDialog(ByVal Text As String)
            MessageBox.Show(Text, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub
        Public Sub ExceptionDialog(ByVal Text As String, ByVal Title As String)
            MessageBox.Show(Text, Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub
        Public Sub ExceptionDialog(ByVal Text As String, ByVal Title As String, ByVal ex As Exception)
            Dim Message As String = String.Concat(Text, Environment.NewLine, ex.Message)
            MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub
    End Class
    <Global.Microsoft.VisualBasic.HideModuleName()> _
    Friend Module KSG_Dialogs
        Private instance As New ThreadSafeObjectProvider(Of _Dialogs)
        ReadOnly Property Dialogs() As _Dialogs
            Get
                Return instance.GetInstance()
            End Get
        End Property
    End Module
End Namespace
