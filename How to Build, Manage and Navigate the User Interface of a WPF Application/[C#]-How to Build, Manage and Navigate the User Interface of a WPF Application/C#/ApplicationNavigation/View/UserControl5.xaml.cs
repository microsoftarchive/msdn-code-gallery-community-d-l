using System.Windows.Controls;
using ApplicationNavigation.Helpers;

namespace ApplicationNavigation.View
{
    public partial class UserControl5 : UserControl
    {
        public UserControl5()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Mediator.NotifyColleagues("NavigateMessage", new UserControl6());
        }
    }
}
