using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM
{
    public class ViewModel
    {
        public ObservableCollection<Person> People;

        public ViewModel()
        {
            People = new ObservableCollection<Person>();
            Person person = new Person() { Name="Thiruveesan", Age=20 };
            People.Add(person);
            person = new Person() { Name = "Marutheesan", Age = 21 };
            People.Add(person);
            person = new Person() { Name = "Sharveshan", Age = 22 };
            People.Add(person);
            person = new Person() { Name = "Kailash", Age = 23 };
            People.Add(person);
             
        }

        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => MyAction(), true));
            }
        }

        public void MyAction()
        {
            Person person = new Person() { Name = "Magesh", Age = 24 };
            People.Add(person);
        }
    }

    public class CommandHandler : ICommand
    {
        private Action _action;
        private bool _canExecute;
        public CommandHandler(Action action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
