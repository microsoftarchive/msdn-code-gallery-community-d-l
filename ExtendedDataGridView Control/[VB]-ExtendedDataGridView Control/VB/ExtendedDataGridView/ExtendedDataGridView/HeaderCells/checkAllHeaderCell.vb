Imports System.Windows.Forms
Imports System.Drawing

Public Class checkAllHeaderCell
    Inherits DataGridViewColumnHeaderCell

    Dim l As Point
    Dim s As New Size(12, 12)

    Dim tt As New ToolTip()
    Dim lastPoint As Point = Point.Empty

    Public Sub New()

    End Sub

    Private _isChecked As Boolean
    Public Property isChecked() As Boolean
        Get
            Return _isChecked
        End Get
        Set(ByVal value As Boolean)
            _isChecked = value
            Me.DataGridView.EndEdit()
            For x As Integer = 0 To Me.DataGridView.Rows.Count - 1
                If Me.DataGridView.Rows(x).IsNewRow Then Continue For
                Me.DataGridView.Rows(x).Cells(Me.OwningColumn.Index).Value = value
            Next
        End Set
    End Property

    Protected Overrides Sub Paint(ByVal graphics As System.Drawing.Graphics, ByVal clipBounds As System.Drawing.Rectangle, ByVal cellBounds As System.Drawing.Rectangle, ByVal rowIndex As Integer, ByVal dataGridViewElementState As System.Windows.Forms.DataGridViewElementStates, ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As System.Windows.Forms.DataGridViewCellStyle, ByVal advancedBorderStyle As System.Windows.Forms.DataGridViewAdvancedBorderStyle, ByVal paintParts As System.Windows.Forms.DataGridViewPaintParts)
        Dim spaces As New String(" "c, 2)
        l = New Point(cellBounds.Width - 18, 5)
        MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, spaces & value.ToString.Trim, spaces & formattedValue.ToString.Trim, errorText, cellStyle, advancedBorderStyle, paintParts)
        CheckBoxRenderer.DrawCheckBox(graphics, New Point(cellBounds.X + l.X, l.Y), If(isChecked, VisualStyles.CheckBoxState.CheckedNormal, VisualStyles.CheckBoxState.UncheckedNormal))
    End Sub

    Protected Overrides Sub OnMouseMove(e As DataGridViewCellMouseEventArgs)
        If New Rectangle(l, s).Contains(e.Location) And Not e.Location = lastPoint Then
            lastPoint = e.Location
            Me.OwningColumn.DataGridView.ShowCellToolTips = False
            tt.SetToolTip(Me.OwningColumn.DataGridView, "Check/uncheck all cells")
        Else
            lastPoint = Point.Empty
            tt.Hide(Me.OwningColumn.DataGridView)
            tt.SetToolTip(Me.OwningColumn.DataGridView, "")
            Me.OwningColumn.DataGridView.ShowCellToolTips = True
        End If
        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnMouseClick(ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        If New Rectangle(l, s).Contains(e.Location) Then
            isChecked = Not isChecked
        End If
        MyBase.OnMouseClick(e)
    End Sub

End Class
