Imports System.Text
Public Module ExtensionMethods
    ''' <summary>
    ''' Get changes for a DataTable
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="PrimaryKeyIndex">Primary auto-incrementing key column index</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' DO NOT Access Deleted table unless you first invoke AcceptChanges on the DataTable.
    ''' Generally we only need to know a) are there any deleted rows and/or the primary key
    ''' of the deleted record(s)
    ''' </remarks>
    <System.Runtime.CompilerServices.Extension>
    Public Function AllChanges(ByVal sender As DataTable, ByVal PrimaryKeyIndex As Integer) As TableChanges
        Dim results = New TableChanges()

        results.Deleted = sender.GetChanges(DataRowState.Deleted)
        results.HasDeleted = results.Deleted IsNot Nothing

        For index = 0 To sender.Rows.Count - 1
            If sender.Rows(index).RowState = DataRowState.Deleted Then
                results.DeletedPrimaryKeys.Add(Convert.ToInt32(sender.Rows(index)(PrimaryKeyIndex, DataRowVersion.Original)))
            End If
        Next index

        results.Modified = sender.GetChanges(DataRowState.Modified)
        results.HasModified = results.Modified IsNot Nothing

        results.Added = sender.GetChanges(DataRowState.Added)
        results.HasNew = results.Added IsNot Nothing

        results.UnChanged = sender.GetChanges(DataRowState.Unchanged)
        results.HasUnchanged = results.UnChanged IsNot Nothing

        results.Any = results.HasDeleted OrElse results.HasModified OrElse results.HasNew

        Return results

    End Function
    ''' <summary>
    ''' Get changes by primary name
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="PrimaryKeyColumnName"></param>
    ''' <returns></returns>
    <System.Runtime.CompilerServices.Extension>
    Public Function AllChanges(ByVal sender As DataTable, ByVal PrimaryKeyColumnName As String) As TableChanges
        Dim PrimaryKeyIndex As Integer = sender.Columns(PrimaryKeyColumnName).Ordinal
        Dim results = sender.AllChanges(PrimaryKeyIndex)

        Return results

    End Function
    ''' <summary>
    ''' Returns a comma delimited string representing all 
    ''' data rows in the table.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    <System.Runtime.CompilerServices.Extension>
    Public Function Flatten(ByVal sender As DataTable) As String
        Dim sb = New StringBuilder()
        For Each row As DataRow In sender.Rows
            sb.AppendLine(String.Join(",", row.ItemArray))
        Next row

        Return sb.ToString()

    End Function
End Module
