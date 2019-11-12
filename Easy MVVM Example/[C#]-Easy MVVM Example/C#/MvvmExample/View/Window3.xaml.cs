using System.Windows;
using MvvmExample.Model;
using MvvmExample.ViewModel;

namespace MvvmExample.View
{
    public partial class Window3 : Window
    {
        public Window3(Person person)
        {
            InitializeComponent();
            var vm = new ViewModelWindow3(person);
            DataContext = vm;
            vm.CloseWindowEvent += new System.EventHandler(vm_CloseWindowEvent);
        }

        void vm_CloseWindowEvent(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
