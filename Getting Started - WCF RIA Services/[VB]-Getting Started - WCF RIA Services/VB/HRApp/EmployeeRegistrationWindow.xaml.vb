Imports System.Windows.Controls
Imports System.Windows

Partial Public Class EmployeeRegistrationWindow
    Inherits ChildWindow

    Public Sub New()
        InitializeComponent()
        NewEmployee = New Employee
        addEmployeeDataForm.CurrentItem = NewEmployee
        addEmployeeDataForm.BeginEdit()
    End Sub

    Public Property NewEmployee As Employee

    Private Sub OKButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles OKButton.Click
        Me.addEmployeeDataForm.CommitEdit()
        Me.DialogResult = True
    End Sub

    Private Sub CancelButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles CancelButton.Click
        NewEmployee = Nothing
        addEmployeeDataForm.CancelEdit()
        Me.DialogResult = False
    End Sub

End Class
