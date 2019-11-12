Imports BackendOperations
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
        Dim ops As New Operations
        '
        ' This provides our sorting capabilities
        '
        bsCustomers.DataSource = New SortableBindingList(Of CustomerDTO)(ops.LoadCustomersDTO)
        blCustomers = CType(bsCustomers.DataSource, SortableBindingList(Of CustomerDTO))

        '
        ' Here we set the BindingSource which we can think of as a List(Of CustomerDTO)
        '
        ' GetType reports
        ' CustomBindingListLibrary.SortableBindingList`1[BackendOperations.CustomerDTO]
        '
        DataGridView1.DataSource = bsCustomers

        DataGridView1.Columns("id").Visible = False

        BindingNavigator1.BindingSource = bsCustomers


    End Sub
    ''' <summary>
    ''' Cast the current DataGridView row which is our BindingSource to a CustomerDTO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CurrentCustomerButton_Click(sender As Object, e As EventArgs) Handles CurrentCustomerButton.Click
        Dim Customer As CustomerDTO = CType(bsCustomers.Current, CustomerDTO)
        MessageBox.Show($"First name: {Customer.FirstName}")
    End Sub
    ''' <summary>
    ''' Update the current row in the DataGridView
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub UpdateCurrentButton_Click(sender As Object, e As EventArgs) Handles UpdateCurrentButton.Click
        Dim ops As New Operations
        ops.UpdateCustomer(CType(bsCustomers.Current, CustomerDTO))
    End Sub
    ''' <summary>
    ''' Add a new Customer to the backend database then add it to the DataGridView via the BindingSource
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' No validation is done so we can focus on the actual add operation. Entity Framework if you
    ''' like can handle validation but is outside the scope of this code sample, see my code sample
    ''' below in C# for an idea how to do this, otherwise stick with conventional validation.
    ''' 
    ''' https://code.msdn.microsoft.com/Entity-Framework-in-764fa5ba (show EF validation) in CustomerPartial.cs
    ''' 
    ''' </remarks>
    Private Sub AddNewCustomerButton_Click(sender As Object, e As EventArgs) Handles AddNewCustomerButton.Click
        AddCustomer()
    End Sub
    Private Sub RemoveCurrentButton_Click(sender As Object, e As EventArgs) Handles RemoveCurrentButton.Click
        RemoveCustomer()
    End Sub
    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Delete Then
            RemoveCustomer()
        End If
    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorDeleteItem.Click
        RemoveCustomer()
    End Sub
    Private Sub RemoveCustomer()
        If My.Dialogs.Question("Remove current customer?") Then
            Dim ops As New Operations
            ops.RemoveCustomer(CType(bsCustomers.Current, CustomerDTO))
            bsCustomers.RemoveCurrent()
        End If
    End Sub
    Private Sub BindingNavigatorAddNewItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorAddNewItem.Click
        AddCustomer()
    End Sub
    Private Sub AddCustomer()
        Dim f As New EditorForm

        Try
            If f.ShowDialog = DialogResult.OK Then
                '
                ' Create a customer from the DTO, this could also
                ' be done with a Mapper library, outside the scope of this sample
                '
                Dim NewCustomer As New CustomerDTO With
                    {
                        .FirstName = f.FirstNameTextBox.Text,
                        .LastName = f.LastNameTextBox.Text,
                        .Address = f.AddressTextBox.Text,
                        .City = f.CityTextBox.Text,
                        .State = f.StateTextBox.Text,
                        .ZipCode = f.ZipCodeTextBox.Text
                    }

                Dim ops As New Operations
                Dim NewId As Integer = ops.AddCustomer(NewCustomer)

                ' if not using a DTO we would not need the next line
                NewCustomer.id = NewId
                bsCustomers.Add(NewCustomer)
            End If
        Finally
            f.Dispose()
        End Try

    End Sub
    ''' <summary>
    ''' This is the basics for locating a Custtomer in the DataGridView.
    ''' Here it's a complete match but by changing the logic in Customer variable
    ''' you can do like conditions too.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' We can get fairly complex in our search and kept this simple for that reason.
    ''' </remarks>
    Private Sub MockedFindButton_Click(sender As Object, e As EventArgs) Handles MockedFindButton.Click

        Dim LastName As String = "Nunez"
        Dim StateName As String = "New York"

        Dim CustomerDTO As CustomerDTO = blCustomers.FindByLastName(LastName)
        If CustomerDTO IsNot Nothing Then
            bsCustomers.Position = blCustomers.IndexOf(CustomerDTO)
        Else
            MessageBox.Show($"Failed to locate last name of {LastName}")
        End If

        Dim CustomersByStateList As List(Of CustomerDTO) = blCustomers.FindByStateList(StateName)

        If CustomersByStateList.Count > 0 Then
            Dim sb As New Text.StringBuilder
            sb.AppendLine($"Customers in {StateName}")
            For Each cust As CustomerDTO In CustomersByStateList
                sb.AppendLine($"{cust.FirstName}, {cust.LastName}")
            Next

            MessageBox.Show(sb.ToString)
        Else
            MessageBox.Show($"Nothing found for {StateName}")
        End If


    End Sub
End Class
