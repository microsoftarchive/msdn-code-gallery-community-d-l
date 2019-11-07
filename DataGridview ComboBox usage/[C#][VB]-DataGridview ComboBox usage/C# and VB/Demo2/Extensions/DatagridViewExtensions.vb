Module DatagridViewExtensions
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function IsComboBoxCell(ByVal sender As DataGridViewCell) As Boolean
        Dim Result As Boolean = False
        If sender.EditType IsNot Nothing Then
            If sender.EditType Is GetType(DataGridViewComboBoxEditingControl) Then
                Result = True
            End If
        End If
        Return Result
    End Function
    <System.Diagnostics.DebuggerHidden()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub ExpandColumns(ByVal sender As DataGridView)
        For Each col As DataGridViewColumn In sender.Columns
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
    End Sub
End Module
