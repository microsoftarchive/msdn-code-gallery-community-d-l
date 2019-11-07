using EasyWpfLoginNavigateExample.ViewModel;
using System.ComponentModel;
using System.Windows;

namespace EasyWpfLoginNavigateExample.View
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click1(object sender, RoutedEventArgs e)
        {
            LoginLayer.Visibility = Visibility.Visible;
        }

        private void MenuItem_Click2a(object sender, RoutedEventArgs e)
        {
            Stage.Child = new UserControl1();
        }

        private void MenuItem_Click2b(object sender, RoutedEventArgs e)
        {
            var win = new Window1();
            win.Show();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginLayer.Visibility = Model.Authentication.Authenticate1(txtName.Text, txtPassword.Text) ? Visibility.Collapsed : Visibility.Visible;
        }

        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
