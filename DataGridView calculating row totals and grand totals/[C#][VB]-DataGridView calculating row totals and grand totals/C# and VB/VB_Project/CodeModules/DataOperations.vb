Public Class DataOperations
    Private ConnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DataBase1.accdb"
    Public Property DataTable As DataTable
    Private MonthNames As String() = {}
    Public ReadOnly Property ColumnNames As String()
        Get
            Return MonthNames
        End Get
    End Property
    Public Property ReportData As String

    ''' <summary>
    ''' Name of field that is our expression column
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property RowTotalFieldName As String
        Get
            Return "LineTotal"
        End Get
    End Property
    Public Sub New()
        MonthNames = (From M In System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames Where Not String.IsNullOrEmpty(M)).ToArray
    End Sub
    Public Sub LoadData()

        DataTable = New DataTable With {.TableName = "Sales"}

        Using cn As New OleDb.OleDbConnection With {.ConnectionString = ConnectionString}
            Using cmd As New OleDb.OleDbCommand With {.Connection = cn}
                cmd.CommandText = "SELECT Identifier,TheYear," & String.Join(",", MonthNames) & "FROM Sales"
                cn.Open()

                DataTable.Load(cmd.ExecuteReader)
                DataTable.Columns("Identifier").ColumnMapping = MappingType.Hidden
                DataTable.Columns("TheYear").ReadOnly = True

                For Each mName In MonthNames
                    If DataTable.Columns.Contains(mName) Then
                        DataTable.Columns(mName).DefaultValue = 0
                    End If
                Next

            End Using
        End Using

        DataTable.Columns.Add(New DataColumn With {.ColumnName = RowTotalFieldName, .DataType = GetType(Integer), .Expression = String.Join(" + ", MonthNames)})
    End Sub
End Class
