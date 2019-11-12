Imports DataTableLibrary
''' <summary>
''' This form shows off using TableChanges methods. 
''' For update and delete you can view or execute while
''' the add only permits viewing as there are many ways to do
''' this and can end up complicated
''' </summary>
Public Class Form1
    Private bsPeople As New BindingSource()
    Private bsGender As New BindingSource()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dataGridView1.AutoGenerateColumns = False
        Dim ops = New DataOperations()
        ops.Read()

        bsGender.DataSource = ops.GenderTable

        GenderColumn.DisplayMember = "Gender"
        GenderColumn.ValueMember = "GenderIdentifier"
        GenderColumn.DataSource = bsGender
        GenderColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

        bsPeople.DataSource = ops.PersonsTable
        dataGridView1.DataSource = bsPeople

    End Sub
    ''' <summary>
    ''' Provides a choice to view deleted or to mark them as deleted in the backend database
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub hasDeletedButton_Click(sender As Object, e As EventArgs) Handles hasDeletedButton.Click
        Dim originalTable As DataTable = CType(bsPeople.DataSource, DataTable)
        Dim results As TableChanges = originalTable.AllChanges("id")
        If results.HasDeleted Then
            If My.Dialogs.Question("Press Yes to set delete flag or no to show") Then
                Dim ops = New DataOperations()
                If ops.Remove(results.DeletedPrimaryKeys) Then
                    CType(bsPeople.DataSource, DataTable).AcceptChanges()
                    MessageBox.Show("Finished updates/deletes")
                End If
            Else
                My.Dialogs.InformationDialog($"Deleted primary keys: {Environment.NewLine}{String.Join(",", results.DeletedPrimaryKeys.ToArray())}")
            End If
        Else
            My.Dialogs.InformationDialog("No deleted records")
        End If
    End Sub
    ''' <summary>
    ''' Provides a choice to show updated records or physically remove from the backend database table
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub updatesButton_Click(sender As Object, e As EventArgs) Handles updatesButton.Click
        Dim originalTable As DataTable = CType(bsPeople.DataSource, DataTable)
        Dim results As TableChanges = originalTable.AllChanges("id")
        If results.HasModified Then
            If My.Dialogs.Question("Press Yes to update or no to show") Then
                Dim ops = New DataOperations()
                If ops.Update(results.Modified) Then
                    CType(bsPeople.DataSource, DataTable).AcceptChanges()
                    MessageBox.Show("Finished updates")
                End If
            Else
                Dim f As New ResultsForm
                Try
                    f.Text = "Modified"
                    f.DataGridView1.DataSource = results.Modified
                    f.ShowDialog()
                Finally
                    f.Dispose()
                End Try
            End If
        Else
            My.Dialogs.InformationDialog("No edits pending")
        End If
    End Sub
    ''' <summary>
    ''' If there were one or records added to the DataGridView they are passed to the
    ''' Add method which accepts the DataTable used to populate the BindingSource then
    ''' the DataGridView.
    ''' 
    ''' The Add method is an Iterator so that for each insert in the Add method the primary
    ''' key sent in comes back with that key plus the key generated from the database table.
    ''' 
    ''' NOTE: This may appear overly complex yet consider an environment where one than one
    ''' user is adding rows which means if the key created in the DataGridView is 1 in a single 
    ''' user environment the new (next) row id would be 2 yet let's say three other users add
    ''' records before you press the Add button, the new record key would be 5 not 2 hence the
    ''' reasoning for getting the new key, locating the original and set it.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub addedRowsButton_Click(sender As Object, e As EventArgs) Handles addedRowsButton.Click
        Dim originalTable As DataTable = CType(bsPeople.DataSource, DataTable)
        Dim results As TableChanges = originalTable.AllChanges("id")

        If results.HasNew Then
            Dim dt As DataTable = CType(bsPeople.DataSource, DataTable)
            Dim ops = New DataOperations()
            For Each item As NewRecord In ops.Add(results.Added)

                CType(bsPeople.DataSource, DataTable).AsEnumerable _
                    .FirstOrDefault(Function(row) row.Field(Of Integer)("id") = item.IncomingIdentifier) _
                    .SetField(Of Integer)("id", item.OutGoingIdentifier)

            Next
        Else
            My.Dialogs.InformationDialog("No new records")
        End If
    End Sub
    Private Sub CurrentButton_Click(sender As Object, e As EventArgs) Handles CurrentButton.Click
        My.Dialogs.InformationDialog(String.Join(",", (CType(bsPeople.Current, DataRowView).Row.ItemArray)))
    End Sub
    Private Sub acceptChangesButton_Click(sender As Object, e As EventArgs) Handles acceptChangesButton.Click
        If CType(bsPeople.DataSource, DataTable).AllChanges("id").Any Then
            If My.Dialogs.Question("Do you want to accept pending changes for the table?") Then
                CType(bsPeople.DataSource, DataTable).AcceptChanges()
            End If
        Else
            My.Dialogs.InformationDialog("There are no changes at this time")
        End If
    End Sub
End Class
