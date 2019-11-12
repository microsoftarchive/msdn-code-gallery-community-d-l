Imports System.Windows.Forms
Imports System.Drawing

Public Class checkHideColumnHeaderCell
    Inherits DataGridViewColumnHeaderCell

    Private WithEvents tmr As New Timer

    Dim l As Point
    Dim s As New Size(12, 12)

    Dim tt As New ToolTip()
    Dim lastPoint As Point = Point.Empty

    Private _isChecked As Boolean = True
    Public Property isChecked() As Boolean
        Get
            Return _isChecked
        End Get
        Set(ByVal value As Boolean)
            _isChecked = value
            tmr.Interval = If(_isChecked, 50, 250)
            tmr.Start()
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
            tt.SetToolTip(Me.OwningColumn.DataGridView, "Hide column")
        Else
            lastPoint = Point.Empty
            tt.Hide(Me.OwningColumn.DataGridView)
            tt.SetToolTip(Me.OwningColumn.DataGridView, "")
            Me.OwningColumn.DataGridView.ShowCellToolTips = True
        End If
        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnMouseClick(ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        If e.Button = MouseButtons.Left Then
            If New Rectangle(l, s).Contains(e.Location) Then
                isChecked = Not isChecked
            End If
        End If
        MyBase.OnMouseClick(e)
    End Sub

    Private Sub tmr_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmr.Tick
        Me.DataGridView.Columns(Me.OwningColumn.Index).Visible = isChecked
        tmr.Stop()
    End Sub

End Class
