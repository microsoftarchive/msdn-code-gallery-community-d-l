Imports System.Data.OleDb

Public Class ExcelInfo
    ''' <summary>
    ''' Full path and file name of file to get information from
    ''' </summary>
    Public Property FileName As String
    ''' <summary>
    ''' Sheet name with no trailing dollar symbol
    ''' </summary>
    Public Property SheetName As String
    ''' <summary>
    ''' Indicates if SheetName first row is headers or data
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property HasHeaders As Boolean
    Public ReadOnly Property Header As String
        Get
            Return If(HasHeaders, "YES;", "NO;")
        End Get
    End Property
    Public Function ConnectionString() As String
        Dim Builder As New OleDbConnectionStringBuilder
        If IO.Path.GetExtension(FileName).ToUpper = ".XLS" Then
            Builder.Provider = "Microsoft.Jet.OLEDB.4.0"
            Builder.Add("Extended Properties", "Excel 8.0;IMEX=1;HDR=" & Me.Header)
        Else
            Builder.Provider = "Microsoft.ACE.OLEDB.12.0"
            Builder.Add("Extended Properties", "Excel 12.0;IMEX=1;HDR=" & Me.Header)
        End If

        Builder.DataSource = FileName

        Return Builder.ToString

    End Function
    Public Sub New()
    End Sub
End Class