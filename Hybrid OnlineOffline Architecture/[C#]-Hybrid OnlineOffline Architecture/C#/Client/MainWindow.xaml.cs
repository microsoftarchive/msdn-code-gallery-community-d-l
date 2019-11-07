using System.Windows;
using System.Windows.Controls;

using Model;

namespace Client
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ordersDataGrid_InitializingNewItem(object sender, InitializingNewItemEventArgs e)
        {
            ViewModel.InitialiseOrder((Order)e.NewItem);
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            ((ViewModel)container.DataContext).Save();
        }
    }
}