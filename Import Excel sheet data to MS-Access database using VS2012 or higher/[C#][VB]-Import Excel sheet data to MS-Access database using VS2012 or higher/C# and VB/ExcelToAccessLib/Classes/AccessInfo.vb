Imports System.Data.OleDb

Public Class AccessInfo
    Public Sub New()
        FieldNames = "*"
    End Sub

    ''' <summary>
    ''' Full path and file name of file to import data
    ''' </summary>
    Public Property FileName As String
    Public Property FieldNames As String

    ''' <summary>
    ''' Name of new table to place Excel sheet data
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TableName As String
    ''' <summary>
    ''' Returns a valid connection string for Access 2007 or higher
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConnectionString() As String
        Dim Builder As New OleDbConnectionStringBuilder With
        {
            .Provider = "Microsoft.ACE.OLEDB.12.0",
            .DataSource = Me.FileName
        }

        Return Builder.ConnectionString

    End Function
End Class