using System.Collections.Generic;
using WpfApplication88.Model;
using WpfApplication88.Helpers;

namespace WpfApplication88.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        public List<MyClass> MyList { get; set; }
        public RelayCommand DoStuffCommand { get; set; }

        public MainViewModel()
        {
            MyList = new List<MyClass>
            {
                new MyClass { Description="Blah blah 1" },
                new MyClass { Description="Blah blah 2" },
                new MyClass { Description="Blah blah 3" },
                new MyClass { Description="Blah blah 4" },
            };
            DoStuffCommand = new RelayCommand(DoStuff, DoStuffCanExecute);
        }

        bool DoStuffCanExecute(object param)
        {
            foreach (var obj in MyList)
                if (obj.IsSelected) return true;

            return false;
        }

        void DoStuff(object param)
        {

        }
    }
}
