using System;
using System.Windows.Threading;
using System.Collections.Generic;
using MvvmExample.Model;
using MvvmExample.Helpers;
using MvvmExample.View;

namespace MvvmExample.ViewModel
{
    class ViewModelWindow3
    {
        public event EventHandler CloseWindowEvent;

        public List<PocoPerson> People { get; set; }

        string _TextProperty1;
        public string TextProperty1
        {
            get
            {
                return _TextProperty1;
            }
            set
            {
                if (_TextProperty1 != value)
                {
                    _TextProperty1 = value;
                }
            }
        }

        public object SelectedPerson { get; set; }

        public RelayCommand AddUserCommand { get; set; }
        public RelayCommand NextExampleCommand { get; set; }

        DispatcherTimer timer;

        public ViewModelWindow3(Person person)
        {
            People = new List<PocoPerson>
            {
                new PocoPerson{ FirstName=person.FirstName, LastName=person.LastName, Age=person.Age },
                new PocoPerson{ FirstName="Grace", LastName="Jones", Age=21 },
            };
            TextProperty1 = "Only this TextBox's changes are reflected in bindings";
            NextExampleCommand = new RelayCommand(NextExample);
            AddUserCommand = new RelayCommand(AddUser);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            //This simulates something happening in the background
            //These changes are NOT reflected in the UI
            //For these changes to show, you need INotifyPropertyChanged or DependencyProperty
            TextProperty1 = DateTime.Now.ToString();
        }

        void AddUser(object parameter)
        {
            if (parameter == null) return;
            People.Add(new PocoPerson { FirstName = parameter.ToString(), LastName = parameter.ToString(), Age = DateTime.Now.Second });
        }

        void NextExample(object parameter)
        {
            var win = new Window4 { DataContext = new ViewModelWindow4() };
            win.Show();

            if (CloseWindowEvent != null)
                CloseWindowEvent(this, null);
        }

    }
}
