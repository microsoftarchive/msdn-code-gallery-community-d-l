Public Module BindingSourceExtensions
    ''' <summary>
    ''' Used for selection of like condition in LikeFilter extension
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum LikeOptions
        ''' <summary>
        ''' Field starts with chars
        ''' </summary>
        ''' <remarks></remarks>
        StartsWith
        ''' <summary>
        ''' Field ends with chars
        ''' </summary>
        ''' <remarks></remarks>
        EndsWith
        ''' <summary>
        ''' File contains chars
        ''' </summary>
        ''' <remarks></remarks>
        Contains
    End Enum
    ''' <summary>
    ''' Used to filter a BindingSource via the data source
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="FieldName">name of field to filter</param>
    ''' <param name="Value">value to filter on or an empty string to remove filter</param>
    ''' <param name="Which">direction of filter</param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()>
    Public Sub LikeFilter(ByVal sender As BindingSource, ByVal FieldName As String, ByVal Value As String, ByVal Which As LikeOptions)

        Dim dt As DataTable = CType(sender.DataSource, DataTable)
        Dim dv As DataView = dt.DefaultView

        If Value.Length > 0 Then
            Dim Filter As String = FieldName & " like  '"
            Select Case Which
                Case LikeOptions.StartsWith
                    Filter = FieldName & " like  '" & Value & "%'"
                Case LikeOptions.EndsWith
                    Filter = FieldName & " like  '%" & Value & "'"
                Case LikeOptions.Contains
                    Filter = FieldName & " like  '%" & Value & "%'"
            End Select
            dv.RowFilter = Filter
            '
            ' If dv.Count is 0 you could change the behavior if so 
            ' desired as 0 means nothing met the current condition.
            '
        Else
            dv.RowFilter = ""
        End If
    End Sub

    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Function CurrentRow(ByVal sender As BindingSource) As DataRow
        Return CType((CType(sender.Current, DataRowView)).Row, DataRow)
    End Function
    <Runtime.CompilerServices.Extension()>
    Public Function DataTable(ByVal sender As BindingSource) As DataTable
        Return CType(sender.DataSource, DataTable)
    End Function
End Module
