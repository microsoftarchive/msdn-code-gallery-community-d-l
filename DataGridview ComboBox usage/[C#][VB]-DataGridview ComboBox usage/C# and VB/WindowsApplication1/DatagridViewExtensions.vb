Module DatagridViewExtensions
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function IsComboBoxCell(ByVal sender As DataGridViewCell) As Boolean
        Dim Result As Boolean = False
        If sender.EditType IsNot Nothing Then
            If sender.EditType.ToString().Contains("DataGridViewComboBoxEditingControl") Then
                Result = True
            End If
        End If
        Return Result
    End Function
End Module
