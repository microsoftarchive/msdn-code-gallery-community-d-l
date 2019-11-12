Module extensions
    <System.Runtime.CompilerServices.Extension()> _
    Public Function NeedsItem(ByVal instance As Stack(Of Object()()), ByVal dgv As DataGridView) As Boolean
        If instance.Count = 0 Then Return True
        Dim rows()() As Object = instance.Peek
        Return Not ItemEquals(rows, dgv.Rows.Cast(Of DataGridViewRow).Where(Function(r) Not r.IsNewRow).ToArray)
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function ItemEquals(ByVal instance As Object()(), ByVal dgvRows() As DataGridViewRow) As Boolean
        If instance.Count <> dgvRows.Count Then Return False
        Return Not Enumerable.Range(0, instance.GetLength(0)).Any(Function(x) Not instance(x).SequenceEqual(dgvRows(x).Cells.Cast(Of DataGridViewCell).Select(Function(c) c.Value).ToArray))
    End Function

End Module
