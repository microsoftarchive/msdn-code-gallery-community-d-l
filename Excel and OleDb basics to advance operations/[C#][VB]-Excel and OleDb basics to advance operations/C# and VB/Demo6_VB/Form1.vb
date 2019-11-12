Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CopyFileToDebugFolder()
        ActiveControl = cmdClose

    End Sub
    ''' <summary>
    ''' Add sheet and data.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' There are no viable methods to drop a sheet using OleDb
    ''' </remarks>
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim FileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "File1.xlsx")
        Dim Connection As OleDbHelper.Connections = New OleDbHelper.Connections

        Using cn As New OleDb.OleDbConnection With {.ConnectionString = Connection.HeaderConnectionString(FileName, 0)}
            Using cmd As New OleDb.OleDbCommand With {.Connection = cn}
                cn.Open()
                cmd.CommandText = "CREATE TABLE Members(FirstName CHAR(255),LastName CHAR(255),JoinedYear INT)"
                cmd.ExecuteNonQuery()

                cmd.Parameters.AddRange(
                    New OleDb.OleDbParameter() _
                    {
                        New OleDb.OleDbParameter With {.ParameterName = "@FirstName", .DbType = DbType.String},
                        New OleDb.OleDbParameter With {.ParameterName = "@LastName", .DbType = DbType.String},
                        New OleDb.OleDbParameter With {.ParameterName = "@JoinedYear", .DbType = DbType.String}
                    }
                )


                Dim Result As Integer = 0
                Dim CustomersToAdd As New Customers
                Dim sb As New System.Text.StringBuilder

                cmd.CommandText =
                    <SQL>
                        INSERT INTO Members 
                        (
                            FirstName,
                            LastName,
                            JoinedYear
                        ) 
                        VALUES 
                        (
                            @FirstName,
                            @LastName,
                            @JoinedYear
                        )
                    </SQL>.Value

                For Each cust In CustomersToAdd.List

                    cmd.Parameters("@FirstName").Value = cust.FirstName
                    cmd.Parameters("@LastName").Value = cust.LastName
                    cmd.Parameters("@JoinedYear").Value = cust.JoinedYear

                    Result = cmd.ExecuteNonQuery()
                    If Result <> 1 Then
                        sb.AppendLine("Insert failed")
                    Else
                        sb.AppendLine("Success")
                    End If
                Next

                TextBox1.Text = sb.ToString
                TextBox1.Select(0, 0)

            End Using
        End Using
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class
