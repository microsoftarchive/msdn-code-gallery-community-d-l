using System.Windows;
using System.Windows.Controls;
using ApplicationNavigation.Helpers;

namespace ApplicationNavigation.View
{
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new Page2());
        }
    }
}
