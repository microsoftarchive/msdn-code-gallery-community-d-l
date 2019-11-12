using System.Windows;
using System.Windows.Controls;

namespace ApplicationNavigation.View
{
    public partial class UserControl2 : UserControl
    {
        Border _parentBorder;
        public UserControl2(Border parentBorder)
        {
            _parentBorder = parentBorder;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_parentBorder != null)
                _parentBorder.Child = new UserControl3();
        }
    }
}
