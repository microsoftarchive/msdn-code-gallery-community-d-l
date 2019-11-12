Module OtherExtensions
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToDataTable(Of T)(ByVal sender As IEnumerable(Of T)) As DataTable

        Dim dt As New DataTable
        Dim FieldNameRow = sender.First

        For Each pi In FieldNameRow.GetType.GetProperties
            dt.Columns.Add(pi.Name, pi.GetValue(FieldNameRow, Nothing).GetType)
        Next

        For Each result In sender
            Dim nr = dt.NewRow
            For Each pi In result.GetType.GetProperties
                nr(pi.Name) = pi.GetValue(result, Nothing)
            Next
            dt.Rows.Add(nr)
        Next

        Return dt

    End Function
End Module
