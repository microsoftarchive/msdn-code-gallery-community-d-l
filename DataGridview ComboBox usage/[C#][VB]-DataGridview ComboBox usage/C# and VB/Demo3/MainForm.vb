Public Class frmMainForm
    WithEvents bsPeople As New BindingSource
    Public Property People() As BindingSource
        Get
            Return bsPeople
        End Get
        Set(ByVal value As BindingSource)
            bsPeople = value
        End Set
    End Property
    Private Sub MainForm_Load() Handles MyBase.Load
        FillGridView(DataGridView1)
    End Sub
    Private Sub CloseButton_Click() Handles cmdClose.Click
        Close()
    End Sub
    ''' <summary>
    ''' Only doing one of the ComboBox columns for auto drop down
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        If chkAutoDropDown.Checked Then
            If DataGridView1.Columns(e.ColumnIndex).Name = "ContactsColumn" Then
                If DataGridView1(e.ColumnIndex, e.RowIndex).IsComboBoxCell Then
                    SendKeys.Send("{F4}")
                End If
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "ColorsColumn" Then
            If DataGridView1(e.ColumnIndex, e.RowIndex).Value Is Nothing Then
                CType(DataGridView1(e.ColumnIndex, e.RowIndex), DataGridViewComboBoxCell).Value = Color.Green
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If DataGridView1.Rows(e.RowIndex).IsNewRow Then
            Exit Sub
        End If
        If e.ColumnIndex = DataGridView1.Columns("ColorsColumn").Index Then
            If e.Value Is Nothing Then
                e.CellStyle.BackColor = Color.LightGray
            Else
                e.CellStyle.BackColor = CType(e.Value, Color)
            End If
        End If

    End Sub
    ''' <summary>
    ''' This is how you code if there are errors but only for developement
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        Console.WriteLine("Data Error '{0}'", e.Exception.Message)
        e.Cancel = True
    End Sub
    ''' <summary>
    ''' Only handle ColorsColumn
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dataGridView1_EditingControlShowing(
        ByVal sender As Object,
        ByVal e As DataGridViewEditingControlShowingEventArgs) _
    Handles DataGridView1.EditingControlShowing

        If DataGridView1.CurrentCell.IsComboBoxCell Then
            Dim cb As ComboBox = TryCast(e.Control, ComboBox)
            RemoveHandler cb.SelectionChangeCommitted, AddressOf _SelectionChangeCommitted
            If DataGridView1.Columns(DataGridView1.CurrentCell.ColumnIndex).Name = "ColorsColumn" Then
                AddHandler cb.SelectionChangeCommitted, AddressOf _SelectionChangeCommitted
            End If
        Else
            Console.WriteLine(DataGridView1.Columns(DataGridView1.CurrentCell.ColumnIndex).Name)
        End If

    End Sub
    Private Sub _SelectionChangeCommitted(sender As Object, e As EventArgs)
        Dim comboBox1 As ComboBox = CType(sender, ComboBox)
        comboBox1.BackColor = CType(comboBox1.SelectedItem, Color)
    End Sub
End Class
