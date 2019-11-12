using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ApplicationNavigation.View
{
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page3());
        }
    }
}
