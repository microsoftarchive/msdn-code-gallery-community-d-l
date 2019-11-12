using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;
using MvvmExample.Model;
using MvvmExample.Helpers;
using MvvmExample.View;
using MvvmExample.Data;

namespace MvvmExample.ViewModel
{
    class ViewModelWindow2 : DependencyObject
    {
        //just type propdp in VisualStudio, below this line, then press Tab to get the DependencyProperty snippet

        public Person SelectedPerson
        {
            get { return (Person)GetValue(SelectedPersonProperty); }
            set { SetValue(SelectedPersonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedPerson.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedPersonProperty =
            DependencyProperty.Register("SelectedPerson", typeof(Person), typeof(ViewModelWindow2), new UIPropertyMetadata(null));

        public ObservableCollection<Person> People
        {
            get { return (ObservableCollection<Person>)GetValue(PeopleProperty); }
            set { SetValue(PeopleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for People.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PeopleProperty =
            DependencyProperty.Register("People", typeof(ObservableCollection<Person>), typeof(ViewModelWindow2), new UIPropertyMetadata(null));

        public bool? CloseWindowFlag
        {
            get { return (bool?)GetValue(CloseWindowFlagProperty); }
            set { SetValue(CloseWindowFlagProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CloseWindowFlag.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CloseWindowFlagProperty = 
            DependencyProperty.Register("CloseWindowFlag", typeof(bool?), typeof(ViewModelWindow2), new UIPropertyMetadata(null));

        public RelayCommand NextExampleCommand { get; set; }

        public ViewModelWindow2()
        {
            People = FakeDatabaseLayer.GetPeopleFromDatabase();
            NextExampleCommand = new RelayCommand(NextExample, NextExample_CanExecute);
        }

        bool NextExample_CanExecute(object parameter)
        {
            return SelectedPerson != null;
        }

        void NextExample(object parameter)
        {
            var win = new Window3(SelectedPerson);
            win.Show();
            CloseWindowFlag = true;
        }
    }
}
