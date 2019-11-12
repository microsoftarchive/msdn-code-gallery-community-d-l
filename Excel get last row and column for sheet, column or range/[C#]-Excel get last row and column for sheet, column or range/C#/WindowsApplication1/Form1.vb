Public Class Form1
    Private Sub Fixer()
        DataGridView1.Columns("FileName").Visible = False
        DataGridView1.Columns("UsedRows").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns("UsedColumns").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SheetNames As New List(Of String) From {"Sheet1", "Sheet2", "Sheet3", "Sheet4", "Howdy"}
        Dim InfoList As New List(Of ExcelInfo)
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = UsedInformation(IO.Path.Combine(Application.StartupPath, "W1.xlsx"), SheetNames)
        Fixer()
    End Sub
End Class
