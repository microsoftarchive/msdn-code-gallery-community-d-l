Public Class Form1

    Dim undoStack As New Stack(Of Object()())
    Dim redoStack As New Stack(Of Object()())

    Dim ignore As Boolean = False

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For r As Integer = 1 To 10
            DataGridView1.Rows.Add(String.Format("R{0}C1", r), String.Format("R{0}C2", r), String.Format("R{0}C3", r))
        Next
    End Sub

    Private Sub DataGridView1_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValidated
        If ignore Then Return
        If undoStack.NeedsItem(DataGridView1) Then
            undoStack.Push(DataGridView1.Rows.Cast(Of DataGridViewRow).Where(Function(r) Not r.IsNewRow).Select(Function(r) r.Cells.Cast(Of DataGridViewCell).Select(Function(c) c.Value).ToArray).ToArray)
        End If
        UndoToolStripButton.Enabled = undoStack.Count > 1
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub

    Private Sub UndoToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripButton.Click
        If redoStack.Count = 0 OrElse redoStack.NeedsItem(DataGridView1) Then
            redoStack.Push(DataGridView1.Rows.Cast(Of DataGridViewRow).Where(Function(r) Not r.IsNewRow).Select(Function(r) r.Cells.Cast(Of DataGridViewCell).Select(Function(c) c.Value).ToArray).ToArray)
        End If
        Dim rows()() As Object = undoStack.Pop
        While rows.ItemEquals(DataGridView1.Rows.Cast(Of DataGridViewRow).Where(Function(r) Not r.IsNewRow).ToArray)
            rows = undoStack.Pop
        End While
        ignore = True
        DataGridView1.Rows.Clear()
        For x As Integer = 0 To rows.GetUpperBound(0)
            DataGridView1.Rows.Add(rows(x))
        Next
        ignore = False
        UndoToolStripButton.Enabled = undoStack.Count > 0
        RedoToolStripButton.Enabled = redoStack.Count > 0
    End Sub

    Private Sub RedoToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoToolStripButton.Click
        If undoStack.Count = 0 OrElse undoStack.NeedsItem(DataGridView1) Then
            undoStack.Push(DataGridView1.Rows.Cast(Of DataGridViewRow).Where(Function(r) Not r.IsNewRow).Select(Function(r) r.Cells.Cast(Of DataGridViewCell).Select(Function(c) c.Value).ToArray).ToArray)
        End If
        Dim rows()() As Object = redoStack.Pop
        While rows.ItemEquals(DataGridView1.Rows.Cast(Of DataGridViewRow).Where(Function(r) Not r.IsNewRow).ToArray)
            rows = redoStack.Pop
        End While
        ignore = True
        DataGridView1.Rows.Clear()
        For x As Integer = 0 To rows.GetUpperBound(0)
            DataGridView1.Rows.Add(rows(x))
        Next
        ignore = False
        RedoToolStripButton.Enabled = redoStack.Count > 0
        UndoToolStripButton.Enabled = undoStack.Count > 0
    End Sub

End Class
