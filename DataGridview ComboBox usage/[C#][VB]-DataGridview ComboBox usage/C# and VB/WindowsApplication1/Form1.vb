Public Class Form1
    Private dictTable As New Dictionary(Of String, String) From
        {
            {"Add", "+"},
            {"Subtract", "-"},
            {"Divide", "\"},
            {"Multiply", "*"}
        }
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim NewColumn As New DataGridViewComboBoxColumn With _
                    { _
                        .DataSource = New String() {"Add", "Subtract", "Divide", "Multiply"}, _
                        .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing, _
                        .Name = "Column1", _
                        .HeaderText = "Demo", _
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                    }

        DataGridView1.Columns.Add(NewColumn)

        DataGridView1.Rows.Add(New Object() {"Divide"})
        DataGridView1.Rows.Add(New Object() {"Add"})
        DataGridView1.Rows.Add(New Object() {"Subtract"})
        DataGridView1.Rows.Add(New Object() {"Add"})
        DataGridView1.Rows.Add(New Object() {"Multiply"})

    End Sub
    Private Sub DataGridView1_EditingControlShowing(
        sender As Object,
        e As DataGridViewEditingControlShowingEventArgs) _
    Handles DataGridView1.EditingControlShowing

        If DataGridView1.CurrentCell.IsComboBoxCell Then
            If DataGridView1.Columns(DataGridView1.CurrentCell.ColumnIndex).Name = "Column1" Then
                Dim cb As ComboBox = TryCast(e.Control, ComboBox)
                RemoveHandler cb.SelectionChangeCommitted, AddressOf _SelectionChangeCommitted
                AddHandler cb.SelectionChangeCommitted, AddressOf _SelectionChangeCommitted
            End If
        End If
    End Sub
    Private Sub _SelectionChangeCommitted(sender As Object, e As EventArgs)
        MessageBox.Show(dictTable(CType(sender, DataGridViewComboBoxEditingControl).Text))
    End Sub
End Class
