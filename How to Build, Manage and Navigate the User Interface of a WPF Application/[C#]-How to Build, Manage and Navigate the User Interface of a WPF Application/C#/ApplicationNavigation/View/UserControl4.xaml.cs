using System;
using System.Windows;
using System.Windows.Controls;

namespace ApplicationNavigation.View
{
    public partial class UserControl4 : UserControl
    {
        public event EventHandler NavigateEvent;

        public UserControl4()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NavigateEvent != null) NavigateEvent(this, null);
        }
    }
}
