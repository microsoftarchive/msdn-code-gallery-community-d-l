using System.Windows;
using MvvmExample.ViewModel;

namespace MvvmExample.ViewModel
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win = new Window1 { DataContext = new ViewModelWindow1(tb1.Text) };
            win.Show();
            this.Close();
        }
    }
}
