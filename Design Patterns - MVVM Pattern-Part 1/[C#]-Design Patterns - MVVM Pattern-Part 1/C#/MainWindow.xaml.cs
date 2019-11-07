using System.Windows;
//using MVVMDemo.ViewModels;

namespace MVVMDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MVVMDemo.ViewModels.CustomerViewModel CustomerViewModelObect = new MVVMDemo.ViewModels.CustomerViewModel();
            CustomerViewModelObect.LoadCustomers();

            // View created in XMAL CustomerHeaderView
            CustomerViewControl.DataContext = CustomerViewModelObect;
        }
    }
}
