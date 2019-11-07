Module Helpers
    Private Function ConnectionString(ByVal FileName As String) As String
        Dim Builder As New OleDb.OleDbConnectionStringBuilder

        If IO.Path.GetExtension(FileName).ToUpper = ".XLS" Then
            Builder.Provider = "Microsoft.Jet.OLEDB.4.0"
            Builder.Add("Extended Properties", "Excel 8.0;IMEX=0;HDR=No;")
        Else
            Builder.Provider = "Microsoft.ACE.OLEDB.12.0"
            Builder.Add("Extended Properties", "Excel 12.0;IMEX=0;HDR=No;")
        End If

        Builder.DataSource = FileName

        Return Builder.ToString

    End Function
    Public Function PersonExist(ByVal FileName As String, ByVal SheetName As String, ByVal FirstName As String, ByVal LastName As String) As Boolean

        Dim ExistResult As Boolean = False
        Using cn As New OleDb.OleDbConnection With {.ConnectionString = ConnectionString(FileName)}
            Using cmd As New OleDb.OleDbCommand With {.Connection = cn}
                cmd.CommandText =
                    <SQL>
                        SELECT * FROM [<%= SheetName %>$] WHERE FirstName='<%= FirstName %>' AND LastName='<%= LastName %>' 
                    </SQL>.Value
                cn.Open()
                Dim reader As OleDb.OleDbDataReader = cmd.ExecuteReader
                ExistResult = reader.HasRows
            End Using
        End Using
        Return ExistResult
    End Function
End Module
