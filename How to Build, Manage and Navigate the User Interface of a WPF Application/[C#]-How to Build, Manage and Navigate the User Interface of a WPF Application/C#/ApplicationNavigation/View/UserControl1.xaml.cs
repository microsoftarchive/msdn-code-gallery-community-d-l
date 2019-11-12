using System.Windows;
using System.Windows.Controls;

namespace ApplicationNavigation.View
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var parent = Parent as Border;
            if (parent != null)
                parent.Child = new UserControl2(parent);
        }
    }
}
