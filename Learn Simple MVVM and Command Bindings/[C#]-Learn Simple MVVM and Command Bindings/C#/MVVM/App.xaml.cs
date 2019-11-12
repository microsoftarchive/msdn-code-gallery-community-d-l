using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            ViewModel vm = new ViewModel();
            MainWindow mw = new MainWindow();
            mw.DataContext = vm;
            mw.ListViewPerson.DataContext = vm.People;
            mw.Show();
        }
    }
}
