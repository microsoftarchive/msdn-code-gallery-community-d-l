Public Class ExcelInfo
    ''' <summary>
    ''' Physical filename (should include full path)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FileName As String
    ''' <summary>
    ''' Sheet name in filename to get information
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SheetName As String
    ''' <summary>
    ''' Last row used for sheetname
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UsedRows As Int32
    ''' <summary>
    ''' Last used column for sheetname
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UsedColumns As Int32
    Public Sub New()
    End Sub
    ''' <summary>
    ''' For debugging and demoing
    ''' Filename is last on purpose
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Return "'" & SheetName & "' Rows: " & UsedRows.ToString("d3") & " Cols: " & UsedColumns.ToString("d3") & " File: " & FileName
    End Function
End Class