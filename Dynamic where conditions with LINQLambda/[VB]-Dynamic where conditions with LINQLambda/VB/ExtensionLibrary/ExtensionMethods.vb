Imports System.Windows.Forms

Public Module ExtensionMethods
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToDataTable(Of T)(ByVal sender As IEnumerable(Of T)) As DataTable

        Dim Table As New DataTable
        Dim HeaderRecord = sender.First

        For Each pi In HeaderRecord.GetType.GetProperties
            Table.Columns.Add(pi.Name, pi.GetValue(HeaderRecord, Nothing).GetType)
        Next

        For Each result In sender
            Dim nr = Table.NewRow
            For Each pi In result.GetType.GetProperties
                nr(pi.Name) = pi.GetValue(result, Nothing)
            Next
            Table.Rows.Add(nr)
        Next
        Return Table
    End Function
    <System.Diagnostics.DebuggerHidden()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub ExpandColumns(ByVal sender As DataGridView)
        For Each col As DataGridViewColumn In sender.Columns
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
    End Sub

End Module
