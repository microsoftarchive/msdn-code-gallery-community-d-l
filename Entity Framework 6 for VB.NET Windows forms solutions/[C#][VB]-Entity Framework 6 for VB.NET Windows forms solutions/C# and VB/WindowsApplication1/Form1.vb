Imports BackendOperations
''' <summary>
''' The entire purpose of any code here is to compare an operation to
''' how we do it in Operations.vb via Entity Framework
''' </summary>
Public Class Form1
    Private bsCustomers As New BindingSource
    ''' <summary>
    ''' Update current row via SqlClient data provider
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' No validation done to ensure we have values for each field so
    ''' to keep focus only on the actual update
    ''' </remarks>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles updateCurrentButton.Click
        Dim currentRow As DataRow = bsCustomers.CurrentRow
        Dim ops As New SqlClientPeekOperations
        If Not ops.UpdateCustomer(currentRow) Then
            MessageBox.Show($"Upate failed for {currentRow.Field(Of String)("FirstName")} {currentRow.Field(Of String)("LastName")}")
            If ops.HasException Then
                ' perhaps write to a log file, user does not need to see this
                Console.WriteLine(ops.Exception.Message)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Load data via SqlClient data provider
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ops As New SqlClientPeekOperations
        Dim custTable As DataTable = ops.LoadCustomers
        bsCustomers.DataSource = custTable
        DataGridView1.DataSource = bsCustomers
        BindingNavigator1.BindingSource = bsCustomers
        ColumnNamesComboBox.DataSource = ops.CustomerTableColumnNames(custTable)

        FilterComboBox.Items.AddRange([Enum].GetNames(GetType(LikeOptions)))
        FilterComboBox.SelectedIndex = 0
        FilterTextBox.SetCueText("Leave empty to remove filter")

        If ForLocateComboBox.DataSource Is Nothing Then
            ' get data for use in finding a record
            Dim result As List(Of CustNameIdItem) = ops.CustomerIdentifierList

            ForLocateComboBox.DataSource = result
            ForLocateComboBox.DisplayMember = "Name"
            ForLocateComboBox.ValueMember = "id"
        End If

    End Sub
    Private Sub FilterButton_Click(sender As Object, e As EventArgs) Handles FilterButton.Click
        If Not String.IsNullOrWhiteSpace(FilterTextBox.Text) Then
            bsCustomers.LikeFilter(ColumnNamesComboBox.Text, FilterTextBox.Text, FilterComboBox.Text.ToEnum(Of LikeOptions))
        Else
            bsCustomers.Filter = ""
        End If
    End Sub
    Private Sub LocateByIdButton_Click(sender As Object, e As EventArgs) Handles LocateByIdButton.Click
        Dim postition As Integer = bsCustomers.Find("id", ForLocateComboBox.SelectedValue)
        If postition <> -1 Then
            bsCustomers.Position = postition
        End If
    End Sub
End Class
