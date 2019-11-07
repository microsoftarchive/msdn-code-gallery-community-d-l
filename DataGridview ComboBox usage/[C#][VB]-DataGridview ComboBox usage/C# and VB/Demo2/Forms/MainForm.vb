Public Class frmMainForm
    WithEvents bsPeople As New BindingSource
    WithEvents bsPositions As New BindingSource
    WithEvents bsOther As New BindingSource
    Private Sub MainForm_Load() Handles MyBase.Load
        Populate(DataGridView1, bsPeople, bsPositions)
        bsOther.DataSource = CType(bsPeople.DataSource, DataTable).Copy
        DataGridView2.DataSource = bsOther
        DataGridView2.ExpandColumns()
        bsOther.Filter = "ContactPosition =''"
    End Sub
    Private Sub _SelectionChangeCommitted(sender As Object, e As EventArgs)
        If bsPositions.Current IsNot Nothing Then
            Dim Value As String = CType(sender, DataGridViewComboBoxEditingControl).Text
            bsOther.Filter = "ContactPosition ='" & Value & "'"
            If bsOther.Count = 0 Then
                If Value = "All" Then

                Else
                    MessageBox.Show("Nothing to filter Contact Position for '" & Value & "'")
                End If

            End If
        End If
    End Sub
    Private Sub DataGridView1_EditingControlShowing(
        sender As Object,
        e As DataGridViewEditingControlShowingEventArgs) _
    Handles DataGridView1.EditingControlShowing

        If DataGridView1.CurrentCell.IsComboBoxCell Then
            If DataGridView1.Columns(DataGridView1.CurrentCell.ColumnIndex).Name = "ContactsColumn" Then
                Dim cb As ComboBox = TryCast(e.Control, ComboBox)
                If cb IsNot Nothing Then
                    RemoveHandler cb.SelectionChangeCommitted, AddressOf _SelectionChangeCommitted
                    AddHandler cb.SelectionChangeCommitted, AddressOf _SelectionChangeCommitted
                End If
            End If
        End If
    End Sub
    Private Sub cmdRemoveFilter_Click(sender As Object, e As EventArgs) Handles cmdRemoveFilter.Click
        bsOther.Filter = Nothing
    End Sub
End Class
