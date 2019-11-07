namespace EyeOpen.MvvmSample.ViewModel
{
	using System.Collections.ObjectModel;
	using System.Windows.Input;
	using EyeOpen.Mvvm;
	using EyeOpen.MvvmSample.Domain;

	public class CustomerViewModel 
		: ViewModelBase<CustomerViewModel>
	{
		private readonly IDialogService dialogService;
		private Customer currentCustomer;
		private int i;

		public CustomerViewModel()
		{
			CustomerList = new ObservableCollection<Customer>();
			AddNewCustomer = new RelayCommand(PerformAddNewCustomer);
		}

		public CustomerViewModel(IDialogService dialogService)
			: this()
		{
			this.dialogService = dialogService;
		}

		public Customer CurrentCustomer
		{
			get { return currentCustomer; }

			set { SetProperty(ref currentCustomer, value, x => x.CurrentCustomer); }
		}

		public ObservableCollection<Customer> CustomerList
		{
			get;
			private set;
		}

		public ICommand AddNewCustomer { get; private set; }

		private void PerformAddNewCustomer()
		{
			CustomerList.Add(new Customer { Name = "Name" + i });
			i++;

			if (dialogService != null)
			{
				dialogService.Show("Customed added");
			}
		}
	}
}