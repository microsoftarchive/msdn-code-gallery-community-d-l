Imports ConfigurationLibrary_vb

Public Class Form1
    Private operations As New ConnectionProtection(Application.ExecutablePath)
    Private Sub PeopleBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles PeopleBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.PeopleBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.PeopleDataSet)
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        ' This line need to be executed once before giving the app to your customer
        '
        operations.EncryptFile()


        operations.DecryptFile()
        'TODO: This line of code loads data into the 'PeopleDataSet.People' table. You can move, or remove it, as needed.
        Me.PeopleTableAdapter.Fill(Me.PeopleDataSet.People)
        operations.EncryptFile()

    End Sub
    Private Sub exitButton_Click(sender As Object, e As EventArgs) Handles exitButton.Click
        Close()
    End Sub
End Class
