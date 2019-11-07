namespace EyeOpen.MvvmSample.ViewModel
{
	using System;
	using EyeOpen.MvvmSample.Domain;

	public class ViewModelLocator
	{
		private static CustomerViewModel customerViewModel;

		public CustomerViewModel CustomerViewModel
		{
			get
			{
				if (customerViewModel == null)
				{
					customerViewModel = new CustomerViewModel(new WpfDialogService());
					
					customerViewModel.CustomerList.Add(new Customer { Name = "Bill" });
					customerViewModel.CustomerList.Add(new Customer { Name = "Steve" });
				}

				return customerViewModel;
			}
		}
	}
}