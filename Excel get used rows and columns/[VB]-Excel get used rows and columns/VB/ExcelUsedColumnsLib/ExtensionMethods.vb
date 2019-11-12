Public Module ExtensionMethods
    <System.Runtime.CompilerServices.Extension()> _
    Public Function ExcelColumnName(ByVal Index As Integer) As String
        Dim chars = New Char() _
            {
                "A"c, "B"c, "C"c, "D"c, "E"c, "F"c, "G"c, "H"c, "I"c,
                "J"c, "K"c, "L"c, "M"c, "N"c, "O"c, "P"c, "Q"c, "R"c,
                "S"c, "T"c, "U"c, "V"c, "W"c, "X"c, "Y"c, "Z"c
            }

        Index -= 1
        Dim columnName As String
        Dim quotient = Index \ 26
        If quotient > 0 Then
            columnName = ExcelColumnName(quotient) + chars(Index Mod 26)
        Else
            columnName = chars(Index Mod 26).ToString()
        End If
        Return columnName
    End Function
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToDataTable(Of T)(ByVal value As IEnumerable(Of T)) As DataTable

        Dim returnTable As New DataTable
        Dim firstRecord = value.First

        For Each pi In firstRecord.GetType.GetProperties
            returnTable.Columns.Add(pi.Name, pi.GetValue(firstRecord, Nothing).GetType)
        Next

        For Each result In value
            Dim nr = returnTable.NewRow
            For Each pi In result.GetType.GetProperties
                nr(pi.Name) = pi.GetValue(result, Nothing)
            Next
            returnTable.Rows.Add(nr)
        Next
        Return returnTable
    End Function

End Module
