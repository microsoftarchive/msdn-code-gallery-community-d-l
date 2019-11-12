Imports System.Data.SqlClient

Public Class DataOperations
    ''' <summary>
    ''' The connection is pointing to my SQL-Server instance, depending on your SQL-Server install you may need to change
    ''' So for my personal computer it's KARENS-PC, at work I have a named server and also .\SQLEXPRESS so
    ''' taking this to work means I need to change it to .\SQLEXPRESS
    ''' Data Source=KARENS-PC to Data Source=SQLEXPRESS 
    ''' Here is a web page to assist with setting the connection up
    ''' 
    ''' https://www.connectionstrings.com/sql-server/
    ''' 
    ''' </summary>
    Private ConnectionString As String = "Data Source=.\SQLEXPRESS;Initial Catalog=People1;Integrated Security=True"

    Public PersonsTable As New DataTable()
    Public GenderTable As New DataTable()

    ''' <summary>
    ''' Read person table and gender reference table (used in a DataGridViewComboBox column)
    ''' </summary>
    Public Sub Read()
        Using cn As SqlConnection = New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As SqlCommand = New SqlCommand With {.Connection = cn}
                cn.Open()
                '
                ' Get top 10 records not marked for deletion.
                '
                cmd.CommandText = "SELECT TOP 10 id, FirstName, LastName, GenderIdentifier FROM Persons1 WHERE (IsDeleted = 0) ORDER BY id DESC"
                PersonsTable.Load(cmd.ExecuteReader())
                PersonsTable.Columns("id").ReadOnly = False

                cmd.CommandText = "SELECT GenderIdentifier,Gender FROM GenderTypes"
                GenderTable.Load(cmd.ExecuteReader())

            End Using
        End Using
    End Sub
    ''' <summary>
    ''' Given a DataTable with records is passed in this method will update each record in the
    ''' backend database. 
    ''' 
    ''' There is no exception handling so to keep things clear on the topic at hand. In a real application
    ''' you would validate the data against business rules to circumvent issues and also have exception handling
    ''' for things like server unavailable etc.
    ''' </summary>
    ''' <param name="pTable"></param>
    ''' <returns></returns>
    Public Function Update(ByVal pTable As DataTable) As Boolean
        Dim recordCount As Integer = pTable.Rows.Count
        Dim affectedCount As Integer = 0

        Using cn As SqlConnection = New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As SqlCommand = New SqlCommand With {.Connection = cn}

                cmd.CommandText = "UPDATE Persons1 SET FirstName = @FirstName,LastName = @LastName,GenderIdentifier = @GenderIdentifier WHERE id = @Id"

                '
                ' Setup parmeters (many are use to AddWithValue which does not work well here).
                '
                cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@FirstName", .DbType = DbType.String})
                cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@LastName", .DbType = DbType.String})
                cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@GenderIdentifier", .DbType = DbType.Int32})
                cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@Id", .DbType = DbType.Int32})

                cn.Open()

                For Each row As DataRow In pTable.Rows
                    cmd.Parameters("@FirstName").Value = row.Field(Of String)("FirstName")
                    cmd.Parameters("@LastName").Value = row.Field(Of String)("LastName")
                    cmd.Parameters("@GenderIdentifier").Value = row.Field(Of Integer)("GenderIdentifier")
                    cmd.Parameters("@Id").Value = row.Field(Of Integer)("Id")
                    If cmd.ExecuteNonQuery = 1 Then
                        affectedCount += 1
                    End If
                Next
            End Using
        End Using

        Return recordCount = affectedCount

    End Function
    ''' <summary>
    ''' May seem overboard but this takes into consideration that more than one user
    ''' is adding new records.
    ''' </summary>
    ''' <param name="pTable"></param>
    ''' <returns></returns>
    Public Iterator Function Add(ByVal pTable As DataTable) As IEnumerable(Of NewRecord)
        Dim NewIdentifier As Integer = 0

        Using cn As SqlConnection = New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As SqlCommand = New SqlCommand With {.Connection = cn}

                cmd.CommandText =
                <SQL>
                    INSERT INTO dbo.Persons1 
                    (
                        FirstName,
                        LastName,
                        GenderIdentifier,
                        IsDeleted
                    )  
                    VALUES 
                    (
                        @FirstName,
                        @LastName,
                        @GenderIdentifier,0
                    );
                    SELECT CAST(scope_identity() AS int);
                </SQL>.Value


                cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@FirstName", .DbType = DbType.String})
                cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@LastName", .DbType = DbType.String})
                cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@GenderIdentifier", .DbType = DbType.Int32})

                cn.Open()

                For Each row As DataRow In pTable.Rows

                    cmd.Parameters("@FirstName").Value = row.Field(Of String)("FirstName")
                    cmd.Parameters("@LastName").Value = row.Field(Of String)("LastName")
                    cmd.Parameters("@GenderIdentifier").Value = row.Field(Of Integer)("GenderIdentifier")

                    NewIdentifier = Convert.ToInt32(cmd.ExecuteScalar())
                    Yield New NewRecord With
                    {
                        .IncomingIdentifier = row.Field(Of Integer)("Id"), .OutGoingIdentifier = NewIdentifier
                    }

                Next
            End Using
        End Using

    End Function
    ''' <summary>
    ''' Mark records for delete where we simply mark IsDeleted field so it does
    ''' not appear in future queries (controlled via the app)
    ''' </summary>
    ''' <param name="pList"></param>
    ''' <returns></returns>
    Public Function Remove(ByVal pList As List(Of Integer)) As Boolean
        Dim recordCount As Integer = pList.Count
        Dim affectedCount As Integer = 0

        Using cn As SqlConnection = New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As SqlCommand = New SqlCommand With {.Connection = cn}

                cmd.CommandText = "UPDATE Persons1 SET IsDeleted = 1 WHERE id = @Id"

                cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@Id", .DbType = DbType.Int32})

                cn.Open()

                For Each id As Integer In pList

                    cmd.Parameters("@Id").Value = id
                    If cmd.ExecuteNonQuery = 1 Then
                        affectedCount += 1
                    End If
                Next
            End Using
        End Using

        Return recordCount = affectedCount

    End Function
End Class