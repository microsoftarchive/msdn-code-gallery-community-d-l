using System.Windows;
using MvvmExample.ViewModel;

namespace MvvmExample.View
{
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            DataContext = new ViewModelWindow2();
        }
    }
}
