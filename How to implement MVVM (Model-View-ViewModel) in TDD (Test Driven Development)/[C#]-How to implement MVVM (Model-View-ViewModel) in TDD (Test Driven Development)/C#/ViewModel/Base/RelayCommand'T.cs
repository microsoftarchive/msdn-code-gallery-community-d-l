namespace EyeOpen.MvvmSample.ViewModel
{
	using System;
	using System.Diagnostics;
	using System.Windows.Input;

	public class RelayCommand<T> : ICommand
	{
		private readonly Action<T> execute;
		private readonly Predicate<T> canExecute;

		public RelayCommand(Action<T> execute)
			: this(execute, null)
		{
		}

		/// <exception cref="ArgumentNullException"><paramref name="execute" /> is <c>null</c>.</exception>
		public RelayCommand(Action<T> execute, Predicate<T> canExecute)
		{
			if (execute == null)
			{
				throw new ArgumentNullException("execute");
			}

			this.execute = execute;
			this.canExecute = canExecute;
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		[DebuggerStepThrough]
		public bool CanExecute(object parameter)
		{
			return canExecute == null ? true : canExecute((T)parameter);
		}

		public void Execute(object parameter)
		{
			execute((T)parameter);
		}
	}
}