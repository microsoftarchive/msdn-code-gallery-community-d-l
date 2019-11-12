Imports System
Imports System.Windows
Public Class MainWindow

    Private Sub btnLoad_Click(sender As System.Object, e As System.Windows.RoutedEventArgs)
        Dim Management = New DataBaseManagement()
        dgvDati.ItemsSource = Management.LoadData().DefaultView
    End Sub

    Private Sub btnInsert_Click(sender As System.Object, e As System.Windows.RoutedEventArgs)
        Dim NewContact = New Insert
        NewContact.InsertName = txtName.Text
        NewContact.InsertSurname = txtSurname.Text
        NewContact.InsertAddress = txtAddress.Text
        NewContact.InsertTelephone = txtTelephone.Text
        NewContact.InsertNationality = txtNationality.Text

        Dim management = New DataBaseManagement()
        management.InsertData(NewContact.InsertName, NewContact.InsertSurname, NewContact.InsertAddress, NewContact.InsertTelephone, NewContact.InsertNationality)
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.Windows.RoutedEventArgs)
        Dim DeleteContact = New Delete
        DeleteContact.DeleteName = txtName.Text
        DeleteContact.DeleteSurname = txtSurname.Text
        DeleteContact.DeleteAddress = txtAddress.Text
        DeleteContact.DeleteTelephone = txtTelephone.Text
        DeleteContact.DeleteNationality = txtNationality.Text

        Dim management = New DataBaseManagement()
        management.DeleteData(DeleteContact.DeleteName, DeleteContact.DeleteSurname, DeleteContact.DeleteAddress, DeleteContact.DeleteTelephone, DeleteContact.DeleteNationality)
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.Windows.RoutedEventArgs)
        Dim UpdateContact = New Update
        UpdateContact.UpdateId = txtId.Text
        UpdateContact.UpdateName = txtName.Text
        UpdateContact.UpdateSurname = txtSurname.Text
        UpdateContact.UpdateAddress = txtAddress.Text
        UpdateContact.UpdateTelephone = txtTelephone.Text
        UpdateContact.UpdateNationality = txtNationality.Text

        Dim Management = New DataBaseManagement()
        Management.UpdateData(UpdateContact.UpdateName, UpdateContact.UpdateSurname, UpdateContact.UpdateAddress, UpdateContact.UpdateTelephone, UpdateContact.UpdateNationality, UpdateContact.UpdateId)

        btnUpdate.IsEnabled = Not btnUpdate.IsEnabled
    End Sub

    Private Sub btnEsci_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles btnExit.Click
        Application.Current.Shutdown()
    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        btnUpdate.IsEnabled = False
        Dim Management = New DataBaseManagement()
        dgvDati.ItemsSource = Management.LoadData().DefaultView
    End Sub

    Private Sub txtId_TextChanged(sender As Object, e As System.Windows.Controls.TextChangedEventArgs) Handles txtId.TextChanged
        btnUpdate.IsEnabled = True
    End Sub
End Class

