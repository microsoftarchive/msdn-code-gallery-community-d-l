Imports System.Data.OleDb
Public Class Importer
    Private Utils As New TableUtils
    Public Property OverWriteExisting As Boolean
    Public Property ExcelInformation As ExcelInfo
    Public Property AccessInformation As AccessInfo
    Public ReadOnly Property ExistsingTableNames As List(Of String)
        Get
            Dim Names As New List(Of String)
            Return Utils.AccessTableNames(AccessInformation.ConnectionString)
        End Get
    End Property
    Private mException As Exception
    Public ReadOnly Property Exception As Exception
        Get
            Return mException
        End Get
    End Property
    Public ReadOnly Property ExceptionWasThrown As Boolean
        Get
            Return mException IsNot Nothing
        End Get
    End Property
    Private mRecordCount As Integer = 0
    Public ReadOnly Property RecordCount As Integer
        Get
            Return mRecordCount
        End Get
    End Property
    Public Sub New()
    End Sub
    Public Sub New(ByVal ExcelData As ExcelInfo, ByVal AccessData As AccessInfo)
        Me.ExcelInformation = ExcelData
        Me.AccessInformation = AccessData
    End Sub
    ''' <summary>
    ''' Perform the import operation
    ''' </summary>
    Public Function Run() As Boolean
        If Not OverWriteExisting Then
            If Utils.AccessTableExists(AccessInformation.ConnectionString, AccessInformation.TableName) Then
                mRecordCount = 0
                mException = New Exception("Table '" & AccessInformation.TableName & "' exist already")
                Return False
            End If
        Else
            Utils.DropTable(AccessInformation.ConnectionString, AccessInformation.TableName)
        End If

        Using cn As New OleDbConnection With {.ConnectionString = ExcelInformation.ConnectionString}

            Using cmd As New OleDbCommand With {.Connection = cn}
                cmd.CommandText =
                    <SQL>
                        SELECT <%= AccessInformation.FieldNames %>  INTO [MS Access;Database=<%= AccessInformation.FileName %>].[<%= AccessInformation.TableName %>] 
                        FROM [<%= ExcelInformation.SheetName %>$]
                    </SQL>.Value

                Try
                    cn.Open()
                    mRecordCount = cmd.ExecuteNonQuery()
                    If mRecordCount > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                Catch ex As Exception
                    mException = ex
                    Return False
                End Try

            End Using
        End Using
    End Function
End Class

