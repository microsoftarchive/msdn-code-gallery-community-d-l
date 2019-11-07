using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmExample.Helpers;
using MvvmExample.Model;
using MvvmExample.View;

namespace MvvmExample.ViewModel
{
    class ViewModelWindow1 : ViewModelMain
    {
        public RelayCommand ChangeTextCommand { get; set; }
        public RelayCommand NextExampleCommand { get; set; }

        string _TestText;
        public string TestText
        {
            get
            {
                return _TestText;
            }
            set
            {
                if (_TestText != value)
                {
                    _TestText = value;
                    RaisePropertyChanged("TestText");
                }
            }
        }

        //This ViewModel is just to duplicate the last, but showing binding in code behind
        public ViewModelWindow1(string lastText)
        {
            _TestText = lastText; //Using internal variable is ok here because binding hasn't happened yet
            ChangeTextCommand = new RelayCommand(ChangeText);
            NextExampleCommand = new RelayCommand(NextExample);
        }

        void ChangeText(object selectedItem)
        {
            //Setting the PUBLIC property 'TestText', so PropertyChanged event is fired
            if (selectedItem == null)
                TestText = "Please select a person"; 
            else
            {
                var person = selectedItem as Person;
                TestText = person.FirstName + " " + person.LastName;
            }
        }

        void NextExample(object parameter)
        {
            var win = new Window2();
            win.Show();
            CloseWindow();
        }
    }
}
