Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CopyFileToDebugFolder()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim FileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "File1.xlsx")
        Dim Connection As OleDbHelper.Connections = New OleDbHelper.Connections

        Using cn As New OleDb.OleDbConnection With {.ConnectionString = Connection.HeaderConnectionString(FileName, 0)}
            Using cmd As New OleDb.OleDbCommand With {.Connection = cn}
                cn.Open()

                cmd.Parameters.AddRange(
                    New OleDb.OleDbParameter() _
                    {
                        New OleDb.OleDbParameter With
                            {
                                .ParameterName = "@ContactTitle",
                                .DbType = DbType.String,
                                .Value = "Owner"
                            },
                        New OleDb.OleDbParameter With
                            {
                                .ParameterName = "@CompanyName",
                                .DbType = DbType.String,
                                .Value = "Around the Horn"
                            }
                    }
                )

                cmd.CommandText =
                    <SQL>
                        UPDATE [Customers$] SET ContactTitle = @ContactTitle
                        WHERE CompanyName = @CompanyName
                    </SQL>.Value


                Dim RowsAffected As Integer = cmd.ExecuteNonQuery
                Label1.Text = "Rows updated: " & If(RowsAffected = 0, "None", RowsAffected.ToString)
            End Using
        End Using
    End Sub
End Class
