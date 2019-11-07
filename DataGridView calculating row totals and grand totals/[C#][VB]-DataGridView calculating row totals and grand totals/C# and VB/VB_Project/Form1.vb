Public Class Form1
    WithEvents bsData As New BindingSource
    Private DataAccess As New DataOperations
    Private Identifier As String = ""

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataAccess.LoadData()
        bsData.DataSource = DataAccess.DataTable

        DataGridView1.DataSource = bsData

        DataGridView1.Columns(DataAccess.RowTotalFieldName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(DataAccess.RowTotalFieldName).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(DataAccess.RowTotalFieldName).SortMode = DataGridViewColumnSortMode.NotSortable

        For Each item In DataAccess.ColumnNames
            DataGridView1.Columns(item).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Next

        DataGridView1.Columns("TheYear").HeaderText = "Year"

        DataGridView1.ExpandColumns()
        DataGridView1.Columns(DataAccess.RowTotalFieldName).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        AddHandler DataAccess.DataTable.RowChanged, AddressOf _RowChanged
        AddHandler DataAccess.DataTable.ColumnChanged, AddressOf _ColumnChanged
        AddHandler DataAccess.DataTable.RowDeleted, AddressOf _RowDeleted

        UpDateTotal()

        Me.Width = 1250
        BindingNavigator1.BindingSource = bsData
    End Sub
    Private Sub _ColumnChanged(sender As Object, e As DataColumnChangeEventArgs)
        If Not e.Row.RowState = DataRowState.Deleted Then

            If DataAccess.ColumnNames.Contains(e.Column.ColumnName) Then

                If Not e.Row.RowState = DataRowState.Detached Then

                    If IsDBNull(e.Row.Item(e.Column.ColumnName)) Then
                        e.Row.Item(e.Column.ColumnName) = 0
                    End If

                    e.Row.AcceptChanges()

                End If

                UpDateTotal()

            End If
        End If
    End Sub
    Private Sub _RowChanged(sender As Object, e As DataRowChangeEventArgs)
        If e.Action = DataRowAction.Add Or e.Action = DataRowAction.Change Or e.Action = DataRowAction.Commit Or e.Action = DataRowAction.Change Then
            UpDateTotal()
        End If
    End Sub
    Private Sub _RowDeleted(sender As Object, e As DataRowChangeEventArgs)
        UpDateTotal()
    End Sub
    Private Sub UpDateTotal()

        Dim dt As DataTable = CType(bsData.DataSource, DataTable)

        If bsData.Position <> -1 Then

            If Not CType(bsData.Current, DataRowView).Row.RowState = DataRowState.Detached Then
                dt.Rows(bsData.Position).EndEdit()
            End If

        End If

        Dim dv As New DataView() With {.Table = dt, .RowStateFilter = DataViewRowState.CurrentRows, .AllowDelete = False}

        Try
            lblTotalSale.Text = "Grand Total: " & (From T In dv.ToTable.AsEnumerable Select T.Field(Of Integer)(DataAccess.RowTotalFieldName)).Sum.ToString

        Catch ex As Exception
            '
            ' If you land here most likely there is a value for a month that is null
            '
            MessageBox.Show("UpDateTotal throw an exception: " & ex.Message)
        End Try

    End Sub
    Sub DataGridView1_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) _
        Handles DataGridView1.CellValidating

        If DataGridView1.Item(e.ColumnIndex, e.RowIndex).IsInEditMode Then
            If DataGridView1.Item(e.ColumnIndex, e.RowIndex).ValueType Is GetType(Int32) Then
                Dim c As Control = DataGridView1.EditingControl
                If Not Integer.TryParse(c.Text, Nothing) Then
                    MessageBox.Show("Must be numeric")
                    e.Cancel = True
                    DataGridView1.CancelEdit()
                End If
            End If
        End If
    End Sub
    Private Sub bsData_PositionChanged(sender As Object, e As EventArgs) Handles bsData.PositionChanged
        Identifier = DirectCast(bsData.Current, DataRowView).Item("Identifier").ToString
    End Sub
    ''' <summary>
    ''' Keeps current row in DataGridView current after a sort operation in the DataGridView
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Sorted
        bsData.Position = bsData.Find("Identifier", Identifier)
    End Sub
End Class