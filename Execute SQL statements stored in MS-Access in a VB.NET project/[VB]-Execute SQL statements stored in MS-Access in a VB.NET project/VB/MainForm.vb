Public Class frmMainForm
    ''' <summary>
    ''' Connection string for back end database stored in the application startup folder
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ConnectionString() As String
        Get
            Return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb"
        End Get
    End Property
    Private ReadOnly Property QueryNameColumn() As String
        Get
            Return "Table_Name"
        End Get
    End Property
    Private ReadOnly Property StatementColumn() As String
        Get
            Return "view_definition"
        End Get
    End Property
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cmdRunCommand.Enabled = False
        cmdRunCommand.Enabled = False

        Dim Views As New DataTable

        Using cn As New OleDbConnection(ConnectionString)

            Dim cmd As OleDbCommand = New OleDbCommand
            cmd.Connection = cn
            cn.Open()

            Views = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Views, New Object() {Nothing, Nothing, Nothing})
            If Views.Rows.Count > 0 Then
                cboItems.DisplayMember = QueryNameColumn
                cboItems.ValueMember = StatementColumn
                cboItems.DataSource = Views
                cboItems.SelectedIndex = cboItems.Items.Count - 1
            End If

            Dim CountriesStatement = (From C In Views.AsEnumerable _
                                      Where C.Item(QueryNameColumn).ToString = "qryCountries" _
                                      Select CStr(C.Item(StatementColumn))).FirstOrDefault

            If CountriesStatement IsNot Nothing Then
                ' Returns a distinct list of countries
                cmd.CommandText = CountriesStatement
                Dim dtCountries As New DataTable
                dtCountries.Load(cmd.ExecuteReader)

                cboCountries1.DisplayMember = "Country"
                cboCountries1.DataSource = dtCountries

                ' pick something other than the first item
                cboCountries1.SelectedIndex = GetRandom(0, cboCountries1.Items.Count - 1)

                cmdRunCommand.Enabled = True
                cmdRunCommand.Enabled = True

                ActiveControl = cmdRunCommand

            End If

        End Using

    End Sub
    Private Sub cmdRunCommand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRunCommand.Click

        Using cn As New OleDbConnection(ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand
            cmd.Connection = cn
            cn.Open()

            cmd.CommandText = cboItems.SelectedValue.ToString

            Dim dt As New DataTable
            dt.Load(cmd.ExecuteReader())
            DataGridView1.DataSource = dt

            txtExecutingQueryStatement.Text = cmd.CommandText

        End Using

    End Sub
    ''' <summary>
    ''' This code picks up a SQL statement from MS-Access called qryCustomer1 where I
    ''' know the query SQL thus can modify it once extracted. In cmdWhere2 the query
    ''' is the same but a parameter has been added in MS-Access so now we can not get
    ''' this query the same way as this one. See more under cmdWhere2 click event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdWhere1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWhere1.Click

        Dim Rows = DirectCast(cboItems.DataSource, DataTable).Select(QueryNameColumn & " = 'qryCustomer1'")

        If Rows.Count = 1 Then

            Dim SelectStatement = Rows(0).Item(StatementColumn).ToString.Replace(";", " ") & _
                "Where Country='" & cboCountries1.Text & "'"

            Dim dt As New DataTable

            Using cn As New OleDbConnection(ConnectionString)

                Dim cmd As OleDbCommand = New OleDbCommand(SelectStatement)
                cmd.Connection = cn
                cn.Open()

                dt.Load(cmd.ExecuteReader())
                dt.Columns("Country").ColumnMapping = MappingType.Hidden
                DataGridView1.DataSource = dt
                txtExecutingQueryStatement.Text = cmd.CommandText

            End Using

        End If

    End Sub
    ''' <summary>
    ''' In cmdWhere1 click event I extract a SQL query using GetOleDbSchemaTable with the first 
    ''' parameter OleDbSchemaGuid.Views which works great. Now if you do the same SQL and 
    ''' add a parameter in the query editor within MS-Access database the query will not show 
    ''' using GetOleDbSchemaTable with OleDbSchemaGuid.Views because it is now a procedure 
    ''' in MS-Access so to get the query we must use OleDbSchemaGuid.Procedures. Once the SQL 
    ''' string is extracted we must remove the first line which defines the parameter for the 
    ''' where condition as we have no need for it. From here the SQL string is manipulated for 
    ''' use in this project. The where condition feeds off cboCountries1 combo box text 
    ''' which is a country. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdWhere2_Click(sender As Object, e As EventArgs) Handles cmdWhere2.Click
        Dim sb As New System.Text.StringBuilder

        Using cn As New OleDbConnection(ConnectionString)
            Using cmd As New OleDbCommand With {.Connection = cn}

                cn.Open()

                Dim Query =
                    (
                        From T In cn.GetOleDbSchemaTable(OleDbSchemaGuid.Procedures, New Object() {Nothing, Nothing, Nothing}).AsEnumerable
                        Where T.Field(Of String)("Procedure_NAME") = "qryCustomer2"
                        Select T.Field(Of String)("Procedure_Definition")
                    ).FirstOrDefault

                If String.IsNullOrWhiteSpace(Query) Then
                    MessageBox.Show("qryCustomer2 procedure Not found.")
                    Exit Sub
                End If

                If Query.Contains(Environment.NewLine) Then

                    Dim Lines =
                        (
                            From T In Query.Split(CChar(Environment.NewLine))
                            Let SubItem = T.Trim Where Not String.IsNullOrEmpty(SubItem)
                            Select SubItem
                            Skip 1
                        ).ToArray


                    For Each line In Lines
                        If line.StartsWith("WHERE") Then
                            Dim Position As Integer = line.IndexOf("="c) + 1
                            Dim WhereString As String = line.Substring(0, Position) & "'" & cboCountries1.Text & "'"
                            sb.AppendLine(WhereString)
                        Else
                            sb.AppendLine(line)
                        End If
                    Next
                End If

                cmd.CommandText = sb.ToString
                Dim dt As New DataTable
                dt.Load(cmd.ExecuteReader)

                DataGridView1.DataSource = dt
                txtExecutingQueryStatement.Text = cmd.CommandText

            End Using
        End Using



    End Sub
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Dim Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function

End Class
