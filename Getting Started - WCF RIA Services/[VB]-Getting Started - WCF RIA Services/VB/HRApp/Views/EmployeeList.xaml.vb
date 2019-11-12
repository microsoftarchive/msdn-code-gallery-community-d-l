Imports System.Windows.Controls
Imports System.ServiceModel.DomainServices.Client
Imports System.ServiceModel.DomainServices.Client.ApplicationServices

Partial Public Class EmployeeList
    Inherits Page

    'Dim _OrganizationContext As New OrganizationContext

    Public Sub New()
        InitializeComponent()
        'Me.dataGrid1.ItemsSource = _OrganizationContext.Employees
        '_OrganizationContext.Load(_OrganizationContext.GetSalariedEmployeesQuery())
    End Sub

    Private Sub submitButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        employeeDataSource.SubmitChanges()
    End Sub

    Private Sub approveSabbatical_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If WebContext.Current.User IsNot Nothing AndAlso WebContext.Current.User.IsAuthenticated Then
            Dim luckyEmployee As Employee = dataGrid1.SelectedItem
            luckyEmployee.ApproveSabbatical()
            employeeDataSource.SubmitChanges()
        Else
            AddHandler WebContext.Current.Authentication.LoggedIn, AddressOf Current_LoginCompleted
            Dim newWindow As New LoginRegistrationWindow
            newWindow.Show()
        End If
    End Sub

    Private Sub Current_LoginCompleted(ByVal sender As Object, ByVal e As AuthenticationEventArgs)
        Dim luckyEmployee As Employee = dataGrid1.SelectedItem
        luckyEmployee.ApproveSabbatical()
        employeeDataSource.SubmitChanges()
        RemoveHandler WebContext.Current.Authentication.LoggedIn, AddressOf Current_LoginCompleted
    End Sub


    Private Sub addNewEmployee_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim addEmp As New EmployeeRegistrationWindow()
        AddHandler addEmp.Closed, AddressOf addEmp_Closed
        addEmp.Show()
    End Sub

    Private Sub addEmp_Closed(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim emp As EmployeeRegistrationWindow = sender
        If Not emp.NewEmployee Is Nothing Then
            Dim _OrganizationContext As OrganizationContext = employeeDataSource.DomainContext
            _OrganizationContext.Employees.Add(emp.NewEmployee)
            employeeDataSource.SubmitChanges()
        End If
    End Sub

    'Executes when the user navigates to this page.
    Protected Overrides Sub OnNavigatedTo(ByVal e As System.Windows.Navigation.NavigationEventArgs)

    End Sub

End Class
