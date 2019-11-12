using System.Collections.ObjectModel;
using MVVMDemo.Model;

namespace MVVMDemo.ViewModels
{
    class CustomerViewModel
    {
        public ObservableCollection<Customer> Customers 
        { 
            get; 
            set; 
        }

        public void LoadCustomers()
        {
            ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

            customers.Add(new Customer { FirstName = "Sai", LastName = "Sri" });
            customers.Add(new Customer { FirstName = "Srigopal", LastName = "Chitrapu" });
            customers.Add(new Customer { FirstName = "Sri", LastName = "Mahi"});
            Customers = customers;
        }
    }
}