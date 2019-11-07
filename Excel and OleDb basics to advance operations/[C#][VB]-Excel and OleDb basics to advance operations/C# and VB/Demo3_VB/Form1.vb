Public Class Form1
    Private FileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PeopleData.xlsx")
    Private Connection As OleDbHelper.Connections = New OleDbHelper.Connections
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Utils = New OleDbHelper.Utility
        Dim ColumnNames As List(Of String) = Utils.GetColumnNames(Connection.NoHeaderConnectionString(FileName), "People2$")
        For Each ColName In ColumnNames
            dgvColumns.Rows.Add(New Object() {True, ColName, ColName})
        Next
    End Sub
    ''' <summary>
    ''' Get columns to show in the DataGridView where we are allowing the
    ''' default column names of Fn to be aliased with meaningful column names.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' For a real app you would most likely hard code aliased column names
    ''' but if you wanted to do this than here is how it can be done.
    ''' </remarks>
    Private Sub cmdLoad_Click(sender As Object, e As EventArgs) Handles cmdLoad.Click
        Dim CheckedRows As List(Of DataGridViewRow) = (From Rows In dgvColumns.Rows.Cast(Of DataGridViewRow)() Where CBool(Rows.Cells("ProcessColumn").Value) = True).ToList
        Dim SelectStatement As String = "SELECT "

        If CheckedRows.Count > 0 Then
            Dim AliasRowsHasMissingData = (From Rows In dgvColumns.Rows.Cast(Of DataGridViewRow)() Where IsNothing(Rows.Cells("AliasColumn").Value)).Any
            If AliasRowsHasMissingData Then
                MessageBox.Show("Missing one or more alias values")
            Else
                Dim DistinctRowCheck = (From Rows In dgvColumns.Rows.Cast(Of DataGridViewRow)() Select Rows.Cells("AliasColumn").Value Distinct).Count

                If DistinctRowCheck <> dgvColumns.Rows.Count Then
                    MessageBox.Show("Alias columns must have unique names")
                Else

                    For Each row As DataGridViewRow In CheckedRows

                        If row.Cells("RealNameColumn").Value.ToString = row.Cells("AliasColumn").Value.ToString Then
                            SelectStatement &= row.Cells("RealNameColumn").Value.ToString
                        Else
                            SelectStatement &= (row.Cells("RealNameColumn").Value.ToString & " As [" & row.Cells("AliasColumn").Value.ToString) & "]"
                        End If

                        SelectStatement &= ","
                    Next

                End If
            End If
        Else
            SelectStatement &= "*"
        End If

        ' Get rid of last comma
        SelectStatement = SelectStatement.Substring(0, SelectStatement.Length - 1)
        SelectStatement &= " FROM [People1$]"

        Using cn As New OleDb.OleDbConnection With {.ConnectionString = Connection.NoHeaderConnectionString(FileName)}
            Using cmd As New OleDb.OleDbCommand With {.Connection = cn, .CommandText = SelectStatement}
                cn.Open()
                Dim dt As New DataTable
                Try
                    dt.Load(cmd.ExecuteReader)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                DataGridView1.DataSource = dt
            End Using
        End Using
    End Sub
    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Close()
    End Sub
End Class
