Public Module DataExtensions
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function LastValue(Of T)(ByVal dt As DataTable, ByVal ColumnName As String) As T
        Return dt.Rows.Item(dt.Rows.Count - 1).Field(Of T)(dt.Columns(ColumnName))
    End Function
End Module
