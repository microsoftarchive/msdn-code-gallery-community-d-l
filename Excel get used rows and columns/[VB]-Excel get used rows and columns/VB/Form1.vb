Imports ExcelUsedColumnsLib

Public Class Form1
    Dim FileName As String = IO.Path.Combine(Application.StartupPath, "W1.xlsx")

    ' Sheet4 does not exists, no blow ups as we assert if sheet exists
    Dim SheetNames As New List(Of String) From {"Sheet1", "Sheet2", "Sheet3", "Sheet4", "Howdy"}
    ''' <summary>
    ''' Get all sheets last used row/column. This example is just that, an example
    ''' and not good for live use as we open the file for each sheet. See the example
    ''' in Button2 which opens the file once and goes thru the SheetNames.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Poor_Click(sender As Object, e As EventArgs) Handles cmdPoor.Click

        DataGridView1.DataSource = Nothing

        Dim InfoList As New List(Of ExcelInfo)

        For Each sheet In SheetNames
            InfoList.Add(UsedInformation(FileName, sheet))
        Next

        DataGridView1.DataSource = InfoList
        Fixer()
    End Sub
    ''' <summary>
    ''' Uses one connection unlike the Poor example above
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Good_Click(sender As Object, e As EventArgs) Handles cmdGood.Click
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = UsedInformation(FileName, SheetNames)
        Fixer()
    End Sub
    Private Sub Fixer()
        DataGridView1.Columns("FileName").Visible = False
        DataGridView1.Columns("UsedRows").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns("UsedColumns").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub
    Private Sub cmdDump_Click(sender As Object, e As EventArgs) Handles cmdDump.Click
        If DataGridView1.DataSource Is Nothing Then
            Exit Sub
        End If

        If DataGridView1.Columns.Contains("key") Then
            MessageBox.Show("Press Good button then try again")
            Exit Sub
        End If

        Dim InfoList As List(Of ExcelInfo) = CType(DataGridView1.DataSource, List(Of ExcelInfo))

        For Each Item In InfoList
            Console.WriteLine(Item.ToString)
        Next

        If Environment.GetEnvironmentVariable("USERNAME") <> "gallaghe" Then
            MessageBox.Show("See IDE output window")
        End If

    End Sub
    ''' <summary>
    ''' Shows how to get individual last row by column rather by entire sheet.
    ''' Added 12/2013
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdEachColumnDemo_Click(sender As Object, e As EventArgs) Handles cmdEachColumnDemo.Click
        DataGridView1.DataSource = Nothing
        Dim Data As Dictionary(Of String, Integer) = UsedColumns(IO.Path.Combine(Application.StartupPath, "W2.xlsx"), "Sheet1", 12)

        DataGridView1.DataSource = Data.ToDataTable
        DataGridView1.Columns("Key").HeaderText = "Column"
    End Sub
End Class
