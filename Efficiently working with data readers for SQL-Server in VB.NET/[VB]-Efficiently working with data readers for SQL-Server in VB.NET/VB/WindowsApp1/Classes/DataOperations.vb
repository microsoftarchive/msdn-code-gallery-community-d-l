Imports System.Data.SqlClient
Public Class DataOperations
    Inherits BaseSqlServerConnections
    Public Sub SetConnectionString(ByVal pDatabaseServer As String, ByVal pDefaultCatalog As String)
        DatabaseServer = pDatabaseServer
        DefaultCatalog = pDefaultCatalog
    End Sub
    Public Function CustomerView() As DataTable
        mHasException = False
        mHasSqlException = False

        Dim dt As New DataTable
        Dim selectStatement As String = "SELECT LastName FROM CustomerLastNameView"
        Try
            Using cn = New SqlConnection(ConnectionString)
                Using cmd = New SqlCommand() With {.Connection = cn, .CommandText = selectStatement}
                    cmd.CommandText = selectStatement
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                End Using
            End Using
        Catch sex As SqlException
            mHasSqlException = True
            mSqlException = sex
        Catch ex As Exception
            mHasException = True
            mLastException = ex
        End Try

        Return dt

    End Function
End Class
