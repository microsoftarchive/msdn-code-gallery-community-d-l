Public Class Form1
    WithEvents bsCustomers As New BindingSource
    ''' <summary>
    ''' Load data from backend database
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DataOps As New DataOperations
        bsCustomers.DataSource = DataOps.GetCustomers
        DataGridView1.DataSource = bsCustomers
        DataGridView1.ExpandColumns()
    End Sub
    ''' <summary>
    ''' Add all new rows from DataGridView.
    ''' DataOperations.UpDateRows is not implemented and if so we could
    ''' iterate the underlying DataTable as done for add new rows.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdAddNewRow_Click(sender As Object, e As EventArgs) Handles cmdAddNewRow.Click
        Dim dt As DataTable = CType(bsCustomers.DataSource, DataTable)
        Dim DataOps As New DataOperations
        DataOps.AddCustomers(dt)
    End Sub
    ''' <summary>
    ''' Save current row only in the DataGridView, no checks are made 
    ''' to detect if changes where made.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdEditCurrentRow_Click(sender As Object, e As EventArgs) Handles cmdEditCurrentRow.Click
        If My.Dialogs.Question("Save current row") Then
            Dim DataOps As New DataOperations
            If Not DataOps.UpdateRow(CType(bsCustomers.Current, DataRowView).Row) Then
                My.Dialogs.ExceptionDialog("Update failed")
            End If
        End If
    End Sub
    ''' <summary>
    ''' Delete current row if user replies yes. Note there is also
    ''' DataOperations.RemoveRows not implemented but by following the instructions
    ''' in RemoveRows you can implement this too.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdDeleteCurrentRow_Click(sender As Object, e As EventArgs) Handles cmdDeleteCurrentRow.Click
        Dim CustomerName As String = CType(bsCustomers.Current, DataRowView).Row.Field(Of String)("CompanyName")
        If My.Dialogs.Question("Remove '" & CustomerName & "' record") Then
            Dim DataOps As New DataOperations
            If DataOps.RemoveRow(CType(bsCustomers.Current, DataRowView).Row.Field(Of Integer)("Identifier")) Then
                bsCustomers.RemoveCurrent()
            Else
                My.Dialogs.ExceptionDialog("Failed to remove '" & CustomerName & "'")
            End If
        End If
    End Sub
    ''' <summary>
    ''' Ask user if they want to add a new row
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView1_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.RowEnter
        If e.RowIndex = DataGridView1.NewRowIndex Then
            If My.Dialogs.Question("Add new row?") = False Then
                bsCustomers.CancelEdit()
                bsCustomers.AllowNew = False
                bsCustomers.AllowNew = True
                SendKeys.Send("{UP}")
            End If
        End If
    End Sub
    ''' <summary>
    ''' Validate we have a complete record
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView1_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.RowValidating
        If DataGridView1("CompanyName", e.RowIndex).Value Is DBNull.Value OrElse DataGridView1("ContactName", e.RowIndex).Value Is DBNull.Value OrElse DataGridView1("ContactTitle", e.RowIndex).Value Is DBNull.Value Then
            MessageBox.Show("Must fill in all cells to have a valid entry. Please complete all entries or after this dialog closes press ESC.")
            bsCustomers.MoveLast()
            e.Cancel = True
        End If
    End Sub
End Class
