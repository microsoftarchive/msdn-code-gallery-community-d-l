using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace RoundedCornerViewDemo
{
    public partial class RoundedCornerViewPage : ContentPage
    {
        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

        public RoundedCornerViewPage()
        {
            InitializeComponent();

            employees.Add(new Employee { DisplayName = "Rob Finnerty" });
            employees.Add(new Employee { DisplayName = "Bill Wrestler" });
            employees.Add(new Employee { DisplayName = "Dr. Geri-Beth Hooper" });
            employees.Add(new Employee { DisplayName = "Dr. Keith Joyce-Purdy" });
            employees.Add(new Employee { DisplayName = "Sheri Spruce" });
            employees.Add(new Employee { DisplayName = "Burt Indybrick" });

            EmployeeView.ItemsSource = employees;
        }
    }

    public class Employee
    {
        public string DisplayName { get; set; }
    }
}
