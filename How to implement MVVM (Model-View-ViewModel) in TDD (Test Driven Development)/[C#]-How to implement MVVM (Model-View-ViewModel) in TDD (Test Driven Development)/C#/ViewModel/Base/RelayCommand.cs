namespace EyeOpen.MvvmSample.ViewModel
{
	using System;
	using System.Diagnostics;
	using System.Windows.Input;

	public class RelayCommand : ICommand
	{
		private readonly Action execute;
		private readonly Func<bool> canExecute;

		public RelayCommand(Action execute)
			: this(execute, null)
		{
		}

		/// <exception cref="ArgumentNullException"><paramref name="execute" /> is <c>null</c>.</exception>
		public RelayCommand(Action execute, Func<bool> canExecute)
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
			return canExecute == null ? true : canExecute();
		}

		public void Execute(object parameter)
		{
			execute();
		}
	}
}