using System.Windows.Controls;
using System.Windows;
using ApplicationNavigation.View;
using ApplicationNavigation.ViewModel;

namespace ApplicationNavigation.Helpers
{
    public class ApplicationController
    {
        public static Border RootBorder { get; set; }

        public static void LoadUserControl(UserControl nextControl)
        {
            RootBorder.Child = nextControl;
        }

        public static UIElement MakePersonAdminControl(int id)
        {
            var view = new PersonAdminControl(); // Note: No parameters, just a dumb skin
            view.DataContext = new PersonViewModel(id);
            return view;
        }
    }
}
