''' <summary>
''' DataGridView - Bindingssoure - Datacolumn Filterexpression Demo
''' Ellen Ramcke 2012
''' </summary>
''' <remarks></remarks>
Public Class Form1

    Private binding As New BindingSource
    Private fullpath As String
    Private rowcount As Integer
    Private currentFilter As String

    ' load data 
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DataSet1.ReadXml("testData.xml")
        Me.rowcount = Me.DataSet1.Tables(0).Rows.Count
        binding.DataSource = Me.DataSet1.Tables(0)
        Me.DataGridView1.DataSource = binding
        DataGridView1.Focus()
    End Sub

    ' DataGridView columnheader click
    Private Sub DataGridView1_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        Dim headertext As String = DataGridView1.Columns(e.ColumnIndex).HeaderText
        Caption.Text = "header click: " & headertext
    End Sub
 
    'click on cell
    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex < 0 Then Exit Sub
        Dim cRow As Integer = e.RowIndex

        Dim cCol As Integer = e.ColumnIndex
        Dim mycell As DataGridViewCell = DataGridView1.Item(cCol, cRow)
        Dim item As String = mycell.Value.ToString
        Caption.Text = "cell click: item-" & item & " Rowindex-" & cRow & " Colindex-" & cCol
        DataGridView1.ClearSelection()
    End Sub

    ' right mousebutton click on DatagridView  
    Private Sub DataGridView1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseDown
        Dim item As String = String.Empty
        Dim item1 As String = String.Empty
        Dim item2 As String = String.Empty
        Dim colname As String = String.Empty

        'get datamember
        Dim dataMemberName As String = DataGridView1.DataMember
        Dim lMouseEventArgs As MouseEventArgs = DirectCast(e, MouseEventArgs)
        Dim hti As DataGridView.HitTestInfo = Me.DataGridView1.HitTest(e.X, e.Y)

        If lMouseEventArgs.Button = Windows.Forms.MouseButtons.Right Then

            If hti.Type = DataGridViewHitTestType.Cell Then
                colname = DataGridView1.Columns(hti.ColumnIndex).HeaderText
                If Not DataGridView1.Rows(hti.RowIndex).Selected Then
                    ' User right clicked a row that is not selected, so throw away all other selections and select this row
                    DataGridView1.ClearSelection()
                    DataGridView1.Rows(hti.RowIndex).Selected = True
                    Dim selectedRow As DataGridViewRow = DataGridView1.Rows(hti.RowIndex)
                    Dim cells As DataGridViewCellCollection = selectedRow.Cells
                    Dim cell As DataGridViewCell = cells.Item(colname)
                    item = CType(cells.Item(colname).Value, String)
                    Me.currentFilter = colname & " = '" & item & "'"
                    Me.menueItemFilter.Text = "Filter: " & Me.currentFilter
                    Caption.Text = "re click cell: item-" & item & " colname-" & colname
                End If
            End If

        End If
    End Sub

    'DataGridView Cell Formating
    Private Sub DataGridView1_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If Me.DataGridView1.Columns(e.ColumnIndex).Name.StartsWith("RESULT") Then
            If CType(e.Value, String) <> "0" Then
                e.CellStyle.BackColor = Color.IndianRed
            End If
        End If
    End Sub

    'clear filter expression
    Private Sub showAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles menueItemShowAll.Click, btnClearFilter.Click

        Me.binding.Filter = String.Empty
        Me.currentFilter = String.Empty
        Me.Caption.Text = "Filter = all"
        Dim count As Integer = Me.DataGridView1.Rows.Count
        Me.Caption.Text &= "  " & count.ToString & "  found/ total  " & Me.rowcount.ToString

    End Sub

    'set filter expression
    Private Sub FilterMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles menueItemFilter.Click

        Try
            Me.binding.Filter = Me.currentFilter
        Catch ex As Exception
            MsgBox("Filter: " & Me.currentFilter & " " & ex.Message)
            Exit Sub
        End Try

        Me.Caption.Text = "Filter = " & binding.Filter
        Dim count As Integer = Me.DataGridView1.Rows.Count
        Me.Caption.Text &= "  " & count.ToString & " found/ total " & Me.rowcount.ToString

    End Sub

    ' execute filter from Textbox
    '
    ' example: RESULT > '0' and TYPE like '7%' or PLACE = 'Rxx' and STATIONNR > '36'
    '
    '
    Private Sub btnExecuteFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecuteFilter.Click

        Me.currentFilter = tbxFilter.Text

        Try
            Me.binding.Filter = Me.currentFilter
        Catch ex As Exception
            MsgBox("Filter: " & Me.currentFilter & " " & ex.Message)
            Exit Sub
        End Try

        Me.Caption.Text = "Filter = " & binding.Filter
        Dim count As Integer = Me.DataGridView1.Rows.Count
        Me.Caption.Text &= "  " & count.ToString & " found/ total " & Me.rowcount.ToString

    End Sub
End Class