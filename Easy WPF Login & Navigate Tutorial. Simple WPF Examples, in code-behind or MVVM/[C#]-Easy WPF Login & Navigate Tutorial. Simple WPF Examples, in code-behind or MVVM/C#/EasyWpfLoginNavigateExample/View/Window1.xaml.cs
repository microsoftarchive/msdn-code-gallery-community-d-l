using EasyWpfLoginNavigateExample.ViewModel;
using System.Windows;

namespace EasyWpfLoginNavigateExample.View
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            DataContext = new MainViewModel(Stage);
        }
    }
}
