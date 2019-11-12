using System.Collections.ObjectModel;
using System.Windows;

namespace MultibindingSample
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            /* Creiamo una ObservableCollection di tipo Customer 
             * andadno a valorizzare le sue proprietà*/
            var customerList = new ObservableCollection<Customer>
                                   {
                                       new Customer
                                           {
                                               Name = "Carmelo",
                                               Surname = "La Monica",
                                               Address = "Indirizzo",
                                               Email = "Email",
                                               PhoneNumber = "Telefono",
                                           }
                                   };

            /* Assegnamo alla proprietà ItemSource del controllo ListBox 
             * il contenuto di customerlist*/
            listbox1.ItemsSource = customerList;
        }

        // La classe Customer con le quattro proprietà
        private class Customer
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
        }
    }
}
