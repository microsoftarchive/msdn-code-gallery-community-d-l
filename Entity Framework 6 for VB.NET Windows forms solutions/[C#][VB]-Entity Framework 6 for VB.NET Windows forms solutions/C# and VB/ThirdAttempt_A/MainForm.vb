Imports BackendOperations
Imports BackendOperations.Operations
Imports CustomBindingListLibrary
Public Class MainForm
    Private bsCustomers As New BindingSource
    Private blCustomers As SortableBindingList(Of CustomerDTO)

    ''' <summary>
    ''' Load a List(Of CustomerDTO)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadData()

        FilterForFirstNameComboBox.Items.AddRange([Enum].GetNames(GetType(FilterOptions)))
        FilterForFirstNameComboBox.SelectedIndex = 0

        NameComboBox.Items.AddRange([Enum].GetNames(GetType(ColumnFilterName)))
        NameComboBox.SelectedIndex = 0

    End Sub
    Private Sub LoadData()
        Dim ops As New Operations

        If ForLocateComboBox.DataSource Is Nothing Then
            ' get data for use in finding a record
            Dim result As List(Of CustNameIdItem) = ops.CustomerIdentifierList

            ForLocateComboBox.DataSource = result
            ForLocateComboBox.DisplayMember = "Name"
            ForLocateComboBox.ValueMember = "id"
        End If

        bsCustomers.DataSource = New SortableBindingList(Of CustomerDTO)(ops.LoadCustomersDTO)
        blCustomers = CType(bsCustomers.DataSource, SortableBindingList(Of CustomerDTO))

        DataGridView1.DataSource = bsCustomers

        DataGridView1.Columns("id").Visible = False

        BindingNavigator1.BindingSource = bsCustomers

    End Sub
    Private Sub LoadFilteredData(sender As List(Of CustomerDTO))
        Dim ops As New Operations

        bsCustomers.DataSource = New SortableBindingList(Of CustomerDTO)(sender)
        blCustomers = CType(bsCustomers.DataSource, SortableBindingList(Of CustomerDTO))

        DataGridView1.DataSource = bsCustomers

        DataGridView1.Columns("id").Visible = False

        BindingNavigator1.BindingSource = bsCustomers

    End Sub
    ''' <summary>
    ''' Filter by first or last name case insensitive with options for
    ''' starts with, ends with, contains or equals.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MockedFilterDialogButton_Click(sender As Object, e As EventArgs) Handles MockedFilterDialogButton.Click
        If Not String.IsNullOrWhiteSpace(FilterFirstOrLastNameTextBox.Text) Then

            Dim ops As New Operations
            Dim Results = ops.NameFilter(NameComboBox.Text, FilterFirstOrLastNameTextBox.Text, FilterForFirstNameComboBox.Text)

            If Results.Count > 0 Then
                Dim f As New FilterNameForm
                Try
                    f.Text = $"Field {NameComboBox.Text} - {FilterForFirstNameComboBox.Text} '{FilterFirstOrLastNameTextBox.Text}'"
                    f.DataGridView1.DataSource = Results
                    f.DataGridView1.ExpandColumns
                    f.ShowDialog()
                Finally
                    f.Dispose()
                End Try
            Else
                MessageBox.Show($"No match for {Environment.NewLine}Field {NameComboBox.Text} - {FilterForFirstNameComboBox.Text} '{FilterFirstOrLastNameTextBox.Text}'")
            End If
        End If
    End Sub
    Private Sub MockedFilterButtonThisForm_Click(sender As Object, e As EventArgs) Handles MockedFilterButtonThisForm.Click
        If Not String.IsNullOrWhiteSpace(FilterFirstOrLastNameTextBox.Text) Then

            Dim ops As New Operations
            Dim Results = ops.NameFilter(NameComboBox.Text, FilterFirstOrLastNameTextBox.Text, FilterForFirstNameComboBox.Text)

            If Results.Count > 0 Then
                LoadFilteredData(Results)
            Else
                MessageBox.Show($"No match for {Environment.NewLine}Field {NameComboBox.Text} - {FilterForFirstNameComboBox.Text} '{FilterFirstOrLastNameTextBox.Text}'")
            End If
        End If
    End Sub
    Private Sub ReloadButton_Click(sender As Object, e As EventArgs) Handles ReloadButton.Click
        LoadData()
    End Sub
    ''' <summary>
    ''' A common operation to locate a item by it's primary key
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub LocateByIdButton_Click(sender As Object, e As EventArgs) Handles LocateByIdButton.Click
        Dim CustomerDTO As CustomerDTO = blCustomers.FindByCustomerIdentifier(CInt(ForLocateComboBox.SelectedValue))
        If CustomerDTO IsNot Nothing Then
            bsCustomers.Position = blCustomers.IndexOf(CustomerDTO)
        End If
    End Sub

End Class
