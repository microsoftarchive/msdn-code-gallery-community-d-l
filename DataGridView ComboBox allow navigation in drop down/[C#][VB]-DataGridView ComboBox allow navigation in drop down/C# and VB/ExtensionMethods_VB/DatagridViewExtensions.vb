Imports System.Windows.Forms
Public Module DatagridViewExtensions
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function IsComboBoxCell(ByVal sender As DataGridViewCell) As Boolean
        If sender.EditType IsNot Nothing Then
            Return (sender.EditType Is GetType(DataGridViewComboBoxEditingControl))
        Else
            Return False
        End If
    End Function
End Module
