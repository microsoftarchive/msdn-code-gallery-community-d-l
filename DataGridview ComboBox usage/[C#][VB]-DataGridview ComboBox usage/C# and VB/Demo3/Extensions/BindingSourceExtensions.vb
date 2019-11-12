Module BindingSourceExtensions
   <System.Diagnostics.DebuggerStepThrough()> _
   <System.Runtime.CompilerServices.Extension()> _
   Public Function DataTable(ByVal sender As BindingSource) As DataTable
      Return DirectCast(sender.DataSource, DataTable)
   End Function
   <System.Diagnostics.DebuggerStepThrough()> _
   <System.Runtime.CompilerServices.Extension()> _
   Public Function ToCvs(ByVal sender As DataTable) As String
      Dim RowCount As Integer = sender.Rows.Count - 1
      Dim ColCount As Integer = sender.Columns.Count - 1
      Dim sb As New System.Text.StringBuilder

      For Row As Integer = 0 To RowCount
         Dim Line As String = ""
         For Col As Integer = 0 To ColCount
            Line &= sender.Rows(Row).Item(Col).ToString & ","
         Next
         If Line.EndsWith(",") Then
            Line = Line.Substring(0, Line.Length - 1)
         End If
         sb.AppendLine(Line)
      Next
      Return sb.ToString
   End Function
   ''' <summary>
   ''' Project specific extension to get current row contact position
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   <System.Diagnostics.DebuggerStepThrough()> _
   <System.Runtime.CompilerServices.Extension()> _
   Public Function CurrentRowContactPosition(ByVal sender As BindingSource) As String
      Return DirectCast(sender.Current, DataRowView).Row("ContactPosition").ToString
   End Function
   <System.Diagnostics.DebuggerStepThrough()> _
   <System.Runtime.CompilerServices.Extension()> _
   Public Function ColumnValue(ByVal sender As BindingSource, ByVal Row As Integer, ByVal ColumnName As String) As String
      Return DirectCast(sender.Item(Row), DataRowView).Item(ColumnName).ToString
   End Function
   <System.Diagnostics.DebuggerStepThrough()> _
   <System.Runtime.CompilerServices.Extension()> _
   Public Function CurrentRow(ByVal sender As BindingSource) As DataRow
      Return DirectCast(sender.Current, DataRowView).Row
   End Function
   <System.Diagnostics.DebuggerStepThrough()> _
   <System.Runtime.CompilerServices.Extension()> _
   Public Function CurrentRow(ByVal sender As BindingSource, ByVal Column As String) As String
      Return DirectCast(sender.Current, DataRowView).Row(Column).ToString
   End Function
End Module
