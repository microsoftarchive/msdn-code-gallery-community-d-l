Public Class frmMainForm
    Private Filename As String = IO.Path.Combine(Application.StartupPath, "Text.txt")

    WithEvents bsPeople As New BindingSource
    WithEvents bsPositions As New BindingSource
    WithEvents bsBadges As New BindingSource


    Private Sub MainForm_Load() Handles MyBase.Load
        Populate(DataGridView1, bsPeople, bsPositions, bsBadges)

    End Sub

    Private Sub cmdPeekAtAllRows_Click(sender As System.Object, e As System.EventArgs) Handles cmdPeekAtAllRows.Click
        Dim Rows = (From row In DataGridView1.Rows
                Where Not DirectCast(row, DataGridViewRow).IsNewRow
                Let RowItem = String.Join(",", Array _
                  .ConvertAll(
                  DirectCast(row, DataGridViewRow).Cells.Cast(Of DataGridViewCell).ToArray,
                  Function(c As DataGridViewCell) _
                    If(c.Value Is Nothing, "(empty)", c.Value.ToString)))
                Select RowItem).ToArray

        IO.File.WriteAllLines(Filename, Rows)
        Process.Start(Filename)

    End Sub
    Private Sub _SelectionChangeCommitted(sender As Object, e As EventArgs)
        If CheckBox1.Checked Then
            MessageBox.Show(CType(sender, DataGridViewComboBoxEditingControl).Text)
        Else
            If bsPositions.Current IsNot Nothing Then

                Dim Index As Int32 = bsPositions.Find(
                    "ContactPosition",
                    CType(sender, DataGridViewComboBoxEditingControl).Text)

                If Index <> -1 Then
                    bsBadges.Position = Index
                    DataGridView1.CurrentRow.Cells(DataGridView1.Columns("BadgeColumn").Index).Value =
                        CType(bsBadges.Current, DataRowView).Row.Field(Of String)("Badge")


#If SHOW1 Then
                    ' for MSDN Question 
                    ' http://social.msdn.microsoft.com/Forums/en-US/313edff1-f776-462f-b2ac-80f55ee86ea8/datagridcombo-select-row-changed?forum=vbgeneral#f6b9d375-be5a-496e-b858-c2767417d426
                    Dim CurrentValue As String = CType(sender, DataGridViewComboBoxEditingControl).Text
                    Dim Position As Integer = bsPositions.Find("ContactPosition", CurrentValue)

                    Console.WriteLine("BindingSource Index: {0} DataRow values: [{1}]", Position, String.Join(",",
                                    CType(bsPositions.DataSource, DataTable) _
                                    .Select("ContactPosition ='" & CurrentValue & "'")(0).ItemArray))
#End If

                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_EditingControlShowing(
        sender As Object,
        e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing

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
    ''' <summary>
    ''' For Micrsoft Social Forumns post
    ''' http://social.msdn.microsoft.com/Forums/en-US/b61c1157-0412-45f8-aed1-80148cf6c86b/how-to-search-in-and-edit-table-by-using-datagridview?forum=vbgeneral
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdDemo_Click(sender As Object, e As EventArgs) Handles cmdDemo.Click
        Dim Index As Integer = bsPeople.Find("PersonName", "Heather Davis")
        If Index <> -1 Then
            bsPeople.Position = Index
            CType(bsPeople.Current, DataRowView).Row.SetField(Of String)("PersonName", "Mary Jones")
            CType(bsPeople.Current, DataRowView).Row.SetField(Of String)("ContactPosition", "Sales Manager")
            DataGridView1.CurrentRow.Cells(DataGridView1.Columns("BadgeColumn").Index).Value = "Orange"
        End If
    End Sub
    ''' <summary>
    ''' For Micrsoft Social Forumns post
    ''' http://social.msdn.microsoft.com/Forums/windows/en-US/78af20cd-4d98-4659-8524-74a10197fe73/how-to-stop-a-databound-combo-box-from-selecting-first-item-when-refreshing-the-bound-list-source?forum=winformsdatacontrols
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdQuickAdd_Click(sender As Object, e As EventArgs) Handles cmdQuickAdd.Click
        Dim f As New frmAddPositions
        Try
            If f.ShowDialog = Windows.Forms.DialogResult.OK Then
                If Not String.IsNullOrWhiteSpace(f.TextBox1.Text) Then
                    Dim CurrentValue As String = CType(bsPeople.Current, DataRowView).Row.Field(Of String)("ContactPosition")
                    Dim TestIndex As Integer = bsPositions.Find("ContactPosition", f.TextBox1.Text)
                    If TestIndex = -1 Then
                        Dim dt As DataTable = CType(bsPositions.DataSource, DataTable)
                        Dim NewIdentifier As Integer = dt.LastValue(Of Integer)("Identifier") + 1
                        dt.Rows.Add(New Object() {NewIdentifier, f.TextBox1.Text})
                    End If
                    CType(bsPeople.Current, DataRowView).Row.SetField(Of String)("ContactPosition", CurrentValue)
                End If
            End If
        Finally
            f.Dispose()
        End Try
    End Sub
End Class
