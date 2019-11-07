Module DataGrideViewExtensions
    <System.Diagnostics.DebuggerHidden()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub ExpandColumns(ByVal sender As DataGridView)
        For Each col As DataGridViewColumn In sender.Columns
            col.HeaderText = String.Join(" ", System.Text.RegularExpressions.Regex.Split(col.HeaderText, "(?=[A-Z])"))
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
    End Sub
End Module
