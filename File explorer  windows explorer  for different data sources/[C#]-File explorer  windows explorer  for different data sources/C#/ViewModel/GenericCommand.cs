using System;
using System.Windows.Input;

namespace FileExplorer.ViewModel
{
    public class GenericCommand : ICommand
    {
        public Func<object, bool> CanExecuteCallback { get; set; }
        public Action<object> ExecuteCallback { get; set; }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            if (CanExecuteCallback != null)
            {
                return CanExecuteCallback(parameter);
            }
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            if (ExecuteCallback != null)
            {
                ExecuteCallback(parameter);
            }
        }

        #endregion
    }
}
