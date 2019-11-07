Imports System.Data.SqlClient

Public Class DataOperations
    ''' <summary>
    ''' The connection is pointing to my SQL-Server instance, depending on your SQL-Server install you may need to change
    ''' Data Source=KARENS-PC to Data Source=SQLEXPRESS 
    ''' Here is a web page to assist with setting the connection up
    ''' https://www.connectionstrings.com/sql-server/
    ''' </summary>
    Private ConnectionString As String = "Data Source=KARENS-PC;Initial Catalog=ExampleDataGridViewComboBox_1;Integrated Security=True"
    Public Property PersonsTable As New DataTable
    Public Property ColorTable As New DataTable
    Public Property InformationTable As New DataTable
    Public Property ColorDictionary As New Dictionary(Of Integer, String)

    Public Property Exception As New ErrorInformation

    Public Sub GetData()
        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                Try
                    cn.Open()
                Catch ex As Exception
                    Exception.HasError = True
                    Exception.Message = ex.Message
                End Try


                cmd.CommandText = "SELECT ColorId,ColorText FROM Colors"
                ColorTable.Load(cmd.ExecuteReader)
                Try

                    For Each row As DataRow In ColorTable.Rows
                        ColorDictionary.Add(row.Field(Of Integer)("ColorId"), row.Field(Of String)("ColorText"))
                    Next
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try

                cmd.CommandText = "SELECT Id,[Text] FROM Information"
                InformationTable.Load(cmd.ExecuteReader)
                cmd.CommandText = "SELECT Id,ColorId ,FirstName FROM Person"
                PersonsTable.Load(cmd.ExecuteReader)
                Console.WriteLine()
            End Using
        End Using
    End Sub
    Public Function UpdatePerson(ByVal PersonId As Integer, ColorId As Integer) As Boolean
        Dim Result As Integer = 0
        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = "UPDATE Person SET ColorId = @ColorId WHERE Id = @PersonId"
                cmd.Parameters.AddWithValue("@ColorId", ColorId)
                cmd.Parameters.AddWithValue("@PersonId", PersonId)

                Try
                    cn.Open()
                Catch ex As Exception
                    Exception.HasError = True
                    Exception.Message = ex.Message
                End Try

                Try
                    Result = cmd.ExecuteNonQuery
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
            End Using
        End Using

        Return Result = 1

    End Function
End Class
Public Class ErrorInformation
    Public Property Message As String
    Public Property HasError As Boolean
End Class