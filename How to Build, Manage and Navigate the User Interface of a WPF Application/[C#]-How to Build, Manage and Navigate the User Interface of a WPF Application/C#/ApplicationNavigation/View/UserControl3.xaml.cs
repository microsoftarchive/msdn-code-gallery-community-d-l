using System;
using System.Windows;
using System.Windows.Controls;
using ApplicationNavigation.Helpers;
using System.Windows.Navigation;

namespace ApplicationNavigation.View
{
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newControl = new UserControl4();
            newControl.NavigateEvent += new EventHandler(newControl_NavigateEvent);
            ApplicationController.LoadUserControl(newControl);
        }

        void newControl_NavigateEvent(object sender, EventArgs e)
        {
            ApplicationController.LoadUserControl(new UserControl5());
        }
    }
}
