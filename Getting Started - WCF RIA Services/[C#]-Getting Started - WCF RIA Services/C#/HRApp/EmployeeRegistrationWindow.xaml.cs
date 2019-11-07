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
using HRApp.Web;

namespace HRApp
{
    public partial class EmployeeRegistrationWindow : ChildWindow
    {
        public EmployeeRegistrationWindow()
        {
            InitializeComponent();
            NewEmployee = new Employee();
            addEmployeeDataForm.CurrentItem = NewEmployee;
            addEmployeeDataForm.BeginEdit();    
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            addEmployeeDataForm.CommitEdit();
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NewEmployee = null;
            addEmployeeDataForm.CancelEdit();
            this.DialogResult = false;
        }

        public Employee NewEmployee { get; set; }
    }
}

