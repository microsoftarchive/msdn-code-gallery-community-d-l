Imports System.Data.OleDb

Public Class Form1
    Private FileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PeopleData.xlsx")
    Private Connection As OleDbHelper.Connections = New OleDbHelper.Connections
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.DataSource = GetRange("People2", "A965:D974")
        txtSingleCellValue.Text = GetSingleValueOleDb("People2", "F441")
    End Sub
    ''' <summary>
    ''' Get a single cell value
    ''' </summary>
    ''' <param name="SheetName"></param>
    ''' <param name="Cell"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSingleValueOleDb(ByVal SheetName As String, ByVal Cell As String) As String
        Dim Value As String = ""
        Using cn As New OleDbConnection With {.ConnectionString = Connection.NoHeaderConnectionString(FileName)}
            cn.Open()

            Dim cmd As OleDbCommand = New OleDbCommand(
                <Text>
                        SELECT * FROM [<%= SheetName %>$<%= Cell %>:<%= Cell %>]
                    </Text>.Value,
                cn
            )


            Dim Reader As OleDb.OleDbDataReader = cmd.ExecuteReader

            If Reader.HasRows Then
                Reader.Read()
                Dim Test As Object = Reader.GetValue(0)
                If IsDBNull(Test) Then
                    Value = "What do you want to do ???"
                Else
                    Value = CStr(Test)
                End If
            End If

            Reader.Close()

        End Using

        Return Value

    End Function
    ''' <summary>
    ''' Get a range of cells
    ''' </summary>
    ''' <param name="SheetName"></param>
    ''' <param name="Range"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetRange(ByVal SheetName As String, ByVal Range As String) As DataTable
        Dim dt As New DataTable

        Using cn As New OleDbConnection With {.ConnectionString = Connection.NoHeaderConnectionString(FileName)}
            cn.Open()

            Dim cmd As OleDbCommand = New OleDbCommand(
                <Text>
                        SELECT * FROM [<%= SheetName %>$<%= Range %>]
                    </Text>.Value,
                cn
            )

            dt.Load(cmd.ExecuteReader)


        End Using

        Return dt

    End Function

    Private MainTable As New DataTable

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim dt As DataTable = GetRange("Sheet1", "A1:C2")

        If MainTable.Columns.Count = 0 Then

            MainTable = dt.Clone

            MainTable.Columns.Add(
                New DataColumn With
                {
                    .ColumnName = "Total", .DataType = GetType(Double),
                    .Expression = "F1 + F2 + F3"
                }
            )

        End If

        For Each row As DataRow In dt.Rows
            MainTable.ImportRow(row)
        Next



    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MainTable.Columns.Count = 0 Then
            MessageBox.Show("No data yet")
            Exit Sub
        End If
        Dim BothRowTotals = (From T In MainTable Select T.Field(Of Double)("Total")).Sum
        Console.WriteLine("Total: {0}", BothRowTotals.ToString("c2"))
        Console.WriteLine()

        For Each row As DataRow In MainTable.Rows
            Console.WriteLine(String.Join(",", row.ItemArray))
        Next
    End Sub
End Class
