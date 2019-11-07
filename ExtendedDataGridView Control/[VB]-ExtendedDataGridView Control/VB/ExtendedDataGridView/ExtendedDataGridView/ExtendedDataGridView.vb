Imports System.ComponentModel
Imports System.Windows.Forms

Public Class ExtendedDataGridView
    Inherits DataGridView

    Public Event cellSelectedIndexChanged(ByVal sender As System.Object, ByVal e As ComboIndexChangedEventArgs)
    Public Event cellCheckedChanged(ByVal sender As System.Object, ByVal e As CheckBoxChangedEventArgs)

    Dim sc As showColumns
    Private WithEvents cms As New ContextMenuStrip

    Dim printer As New Printer
    Dim writer As New CSVWriter

    Public Sub New()
        Me.DoubleBuffered = True
        cms.Items.Add("&Print", Nothing, AddressOf Print1)
        cms.Items.Add("Print pre&view", Nothing, AddressOf PreviewPrint1)
        cms.Items.Add("-")
        cms.Items.Add("&Save as CSV", Nothing, AddressOf SaveasCSV1)
        cms.Items.Add("-")
        cms.Items.Add("&Reveal")
        Me.ContextMenuStrip = cms
        AddHandler Me.CellPainting, AddressOf Me_CellPainting
    End Sub

    Private Sub Me_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then
            e.Handled = True
            e.PaintBackground(e.ClipBounds, True)
            e.Graphics.FillRectangle(New SolidBrush(MyBase.ColumnHeadersDefaultCellStyle.BackColor), e.CellBounds)
            Dim r As Rectangle = e.CellBounds
            If e.RowIndex = -1 Then
                r.X -= 1
            Else
                r.Width -= 1
            End If
            r.Height -= 1
            e.Graphics.DrawRectangle(Pens.DarkGray, r)
            e.PaintContent(e.ClipBounds)
        End If
    End Sub

    Private Sub Print1(sender As Object, e As EventArgs)
        Print()
    End Sub

    Private Sub PreviewPrint1(sender As Object, e As EventArgs)
        PreviewPrint()
    End Sub

    Private Sub SaveasCSV1(sender As Object, e As EventArgs)
        SaveasCSV()
    End Sub

    Public Sub Print()
        Dim frm As New frmOptions(True)
        If frm.ShowDialog = DialogResult.OK Then
            printer.startPrint(Me, frm.rows, frm.columns, frm.hidden, False)
        End If
    End Sub

    Public Sub PreviewPrint()
        Dim frm As New frmOptions(True)
        If frm.ShowDialog = DialogResult.OK Then
            printer.startPrint(Me, frm.rows, frm.columns, frm.hidden, True)
        End If
    End Sub

    Public Sub SaveasCSV()
        Dim frm As New frmOptions(False)
        If frm.ShowDialog = DialogResult.OK Then
            writer.writeCSV(Me, frm.rows, frm.columns, frm.hidden)
        End If
    End Sub

    Public Overrides Function AdjustColumnHeaderBorderStyle(
        ByVal dataGridViewAdvancedBorderStyleInput As DataGridViewAdvancedBorderStyle,
        ByVal dataGridViewAdvancedBorderStylePlaceHolder As DataGridViewAdvancedBorderStyle,
        ByVal firstDisplayedColumn As Boolean, ByVal lastVisibleColumn As Boolean) _
        As DataGridViewAdvancedBorderStyle

        ' Customize the left border of the first column header and the
        ' bottom border of all the column headers. Use the input style for 
        ' all other borders.
        If firstDisplayedColumn Then
            dataGridViewAdvancedBorderStylePlaceHolder.Left =
                DataGridViewAdvancedCellBorderStyle.OutsetDouble
        Else
            dataGridViewAdvancedBorderStylePlaceHolder.Left =
                DataGridViewAdvancedCellBorderStyle.None
        End If

        With dataGridViewAdvancedBorderStylePlaceHolder
            .Bottom = DataGridViewAdvancedCellBorderStyle.Single
            .Right = dataGridViewAdvancedBorderStyleInput.Right
            .Top = dataGridViewAdvancedBorderStyleInput.Top
        End With

        Return dataGridViewAdvancedBorderStylePlaceHolder
    End Function

    Protected Overrides Sub OnCellFormatting(e As DataGridViewCellFormattingEventArgs)
        If TypeOf Me(e.ColumnIndex, e.RowIndex) Is DataGridViewImageCell Then
            e.CellStyle.NullValue = My.Resources.errorimage
        End If
        MyBase.OnCellFormatting(e)
    End Sub

    Private Sub cms_Opening(sender As Object, e As CancelEventArgs) Handles cms.Opening
        Dim b As Boolean = Me.Columns.Cast(Of DataGridViewColumn).Where(Function(c) (Not c.Visible And TypeOf c.HeaderCell Is checkHideColumnHeaderCell)).Count > 0
        DirectCast(cms.Items(5), ToolStripMenuItem).DropDownItems.Add(New ToolStripControlHost(New showColumns(Me, cms)))
        cms.Items(5).Enabled = b
    End Sub

    Private Sub cms_Closed(sender As Object, e As ToolStripDropDownClosedEventArgs) Handles cms.Closed
        DirectCast(cms.Items(5), ToolStripMenuItem).DropDownItems.Clear()
    End Sub

    Private Sub ExtendedDataGridView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Me.DataError
        Return
    End Sub

    Protected Overrides Sub OnEditingControlShowing(ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        ' Attempt to cast the EditingControl to a ComboBox.
        'this will only work if CurrentCell is a combobox column
        Dim cb As ComboBox = TryCast(e.Control, ComboBox)
        'if it is a combobox column...
        If cb IsNot Nothing Then
            RemoveHandler cb.SelectedIndexChanged, AddressOf DGVComboIndexChanged
            AddHandler cb.SelectedIndexChanged, AddressOf DGVComboIndexChanged
        End If
        MyBase.OnEditingControlShowing(e)
    End Sub

    Private Sub DGVComboIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'this handles the datagridviewcombobox cell selectedindexchanged event
        Dim cb As ComboBox = DirectCast(sender, ComboBox)
        RaiseEvent cellSelectedIndexChanged(sender, New ComboIndexChangedEventArgs With {.columnIndex = MyBase.CurrentCell.ColumnIndex, .rowIndex = MyBase.CurrentCell.RowIndex, .selectedIndex = cb.SelectedIndex, .selectedItem = cb.SelectedItem, .selectedValue = cb.SelectedValue, .text = cb.Text})
    End Sub

    Protected Overrides Sub OnCurrentCellDirtyStateChanged(ByVal e As System.EventArgs)
        If TypeOf MyBase.CurrentCell Is DataGridViewCheckBoxCell Then
            MyBase.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
        MyBase.OnCurrentCellDirtyStateChanged(e)
    End Sub

    Protected Overrides Sub OnCellValueChanged(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If e.ColumnIndex = -1 OrElse e.RowIndex = -1 Then Return
        If TypeOf MyBase.Rows(e.RowIndex).Cells(e.ColumnIndex) Is DataGridViewCheckBoxCell Then
            RaiseEvent cellCheckedChanged(Me, New CheckBoxChangedEventArgs With {.columnIndex = e.ColumnIndex, .rowIndex = e.RowIndex, .newValue = If(MyBase.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is Nothing, False, CBool(MyBase.Rows(e.RowIndex).Cells(e.ColumnIndex).Value))})
        End If
        MyBase.OnCellValueChanged(e)
    End Sub

    Protected Overrides Sub OnColumnHeaderMouseClick(e As DataGridViewCellMouseEventArgs)
        If TypeOf Me.Columns(e.ColumnIndex).HeaderCell Is checkHideColumnHeaderCell Then
            Dim l = New Point(Me.Columns(e.ColumnIndex).Width - 18, 5)
            Dim s As New Size(12, 12)
            If New Rectangle(l, s).Contains(e.Location) Then
                Return
            End If
        End If
        MyBase.OnColumnHeaderMouseClick(e)
    End Sub

End Class
