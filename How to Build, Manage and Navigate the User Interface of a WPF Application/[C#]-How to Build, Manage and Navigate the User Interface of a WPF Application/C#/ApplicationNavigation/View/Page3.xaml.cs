using System.Windows.Controls;
using ApplicationNavigation.Helpers;

namespace ApplicationNavigation.View
{
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
            ApplicationController.RootBorder = MyStage;
            Mediator.Register("NavigateMessage", GoNextUserControl);
        }

        void GoNextUserControl(object param)
        {
            MyStage.Child = param as UserControl6;
        }
    }
}
