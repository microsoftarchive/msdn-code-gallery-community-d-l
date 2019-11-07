Public Class Form1
    Private FileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PeopleData.xlsx")
    Private Connection As OleDbHelper.Connections = New OleDbHelper.Connections
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Utils = New OleDbHelper.Utility
        Dim ColumnNames As List(Of String) = Utils.GetColumnNames(Connection.HeaderConnectionString(FileName), "People2$")
        For Each ColName In ColumnNames
            CheckedListBox1.Items.Add(ColName)
        Next
    End Sub
    ''' <summary>
    ''' Create a dynamic SELECT statement where if no items in the CheckedListBox are selected
    ''' we return all columns and if CheckedListBox has one or more items checked return only
    ''' these columns. I have hard coded the sheet name as this focuses on sheets with header has
    ''' column names
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdLoad_Click(sender As Object, e As EventArgs) Handles cmdLoad.Click
        Dim SelectStatement As String = "SELECT "

        If CheckedListBox1.CheckedItems.Count = 0 Then
            SelectStatement &= "* "
        Else
            SelectStatement &= String.Join(",", (From s In CheckedListBox1.CheckedItems.OfType(Of String)() Select s).ToArray)
        End If

        SelectStatement &= " FROM [People2$]"

        Using cn As New OleDb.OleDbConnection With {.ConnectionString = Connection.HeaderConnectionString(FileName)}
            Using cmd As New OleDb.OleDbCommand With {.Connection = cn, .CommandText = SelectStatement}
                cn.Open()
                Dim dt As New DataTable
                dt.Load(cmd.ExecuteReader)
                DataGridView1.DataSource = dt
            End Using
        End Using

    End Sub
    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Close()
    End Sub
End Class
