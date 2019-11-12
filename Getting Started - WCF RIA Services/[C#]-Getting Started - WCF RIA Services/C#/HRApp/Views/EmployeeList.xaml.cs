using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using HRApp.Web;
using System.ServiceModel.DomainServices.Client;
using System.ServiceModel.DomainServices.Client.ApplicationServices;
using HRApp.LoginUI;

namespace HRApp
{
    public partial class EmployeeList : Page
    {
        //OrganizationContext _OrganizationContext = new OrganizationContext();

        public EmployeeList()
        {
            InitializeComponent();
            //this.dataGrid1.ItemsSource = _OrganizationContext.Employees;
            //_OrganizationContext.Load(_OrganizationContext.GetSalariedEmployeesQuery());

        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            employeeDataSource.SubmitChanges();
        }

        private void approveSabbatical_Click(object sender, RoutedEventArgs e)
        {
            if (WebContext.Current.User.IsAuthenticated)
            {
                Employee luckyEmployee = (Employee)(dataGrid1.SelectedItem);
                luckyEmployee.ApproveSabbatical();
                employeeDataSource.SubmitChanges();
            }
            else
            {
                WebContext.Current.Authentication.LoggedIn += Authentication_LoggedIn;
                new LoginRegistrationWindow().Show();
            }
        }

        private void Authentication_LoggedIn(object sender, AuthenticationEventArgs e)
        {
            Employee luckyEmployee = (Employee)(dataGrid1.SelectedItem);
            luckyEmployee.ApproveSabbatical();
            employeeDataSource.SubmitChanges();

            WebContext.Current.Authentication.LoggedIn -= Authentication_LoggedIn;
        }

        private void addNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeRegistrationWindow addEmp = new EmployeeRegistrationWindow();
            addEmp.Closed += new EventHandler(addEmp_Closed);
            addEmp.Show();
        }

        void addEmp_Closed(object sender, EventArgs e)
        {
            EmployeeRegistrationWindow emp = (EmployeeRegistrationWindow)sender;
            if (emp.NewEmployee != null)
            {
                OrganizationContext _OrganizationContext = (OrganizationContext)(employeeDataSource.DomainContext);
                _OrganizationContext.Employees.Add(emp.NewEmployee);
                employeeDataSource.SubmitChanges();
            }
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}
