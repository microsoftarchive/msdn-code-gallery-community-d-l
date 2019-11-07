Public Class Form1
    Private FileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PeopleData.xlsx")
    Private Connection As OleDbHelper.Connections = New OleDbHelper.Connections

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Utils = New OleDbHelper.Utility
        cboSheetNames.DisplayMember = "DisplayName"
        cboSheetNames.ValueMember = "ActualName"
        cboSheetNames.DataSource = Utils.SheetNames(Connection.NoHeaderConnectionString(IO.Path.GetFileName(FileName)))
    End Sub
    ''' <summary>
    ''' Select sheet data where if the CheckBox is checked we create a connection
    ''' string that the first row is column names, un-checked data is in the first row
    ''' 
    ''' All fields are selected
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdShowSheet_Click(sender As Object, e As EventArgs) Handles cmdShowSheet.Click
        Dim dt As New DataTable
        Dim ConnectionString As String =
            If(chkHasHeaders.Checked,
               Connection.HeaderConnectionString(FileName),
               Connection.NoHeaderConnectionString(FileName))

        Using cn As New OleDb.OleDbConnection With {.ConnectionString = ConnectionString}
            Using cmd As New OleDb.OleDbCommand With
                {
                    .CommandText = String.Format("SELECT * FROM [{0}]", cboSheetNames.SelectedValue.ToString),
                    .Connection = cn
                }

                cn.Open()
                dt.Load(cmd.ExecuteReader)
            End Using
        End Using

        DataGridView1.DataSource = dt

    End Sub
    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Close()
    End Sub
End Class
