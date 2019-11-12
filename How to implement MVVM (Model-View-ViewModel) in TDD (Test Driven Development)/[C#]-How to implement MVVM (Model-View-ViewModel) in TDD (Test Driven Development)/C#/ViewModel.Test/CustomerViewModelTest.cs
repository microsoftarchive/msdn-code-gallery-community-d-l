namespace EyeOpen.ViewModel.Test
{
	using System;
	using EyeOpen.Extensions;
	using EyeOpen.MvvmSample.Domain;
	using EyeOpen.MvvmSample.ViewModel;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class CustomerViewModelTest : ViewModelTest
	{
		private readonly string currentCustomerPropertyName =
			TypeExtensions<CustomerViewModel>
				.GetProperty(x => x.CurrentCustomer);
		
		[TestMethod]
		public void ChangePropertyOfTheViewModelAndCheckNotifyPropertyChangedWorks()
		{
			CheckPropertyChangedRaised(ChangeCurrentCustomer(), currentCustomerPropertyName);
		}

		[TestMethod]
		public void AddCustomerCheckCollectionIsChanged()
		{
			var dialogService = new FooDialogService();
			Assert.IsNull(dialogService.Message, "Message not correctly must be null.");

			var customerViewModel = new CustomerViewModel(dialogService);
			Assert.AreEqual(0, customerViewModel.CustomerList.Count);

			customerViewModel.AddNewCustomer.Execute(null);

			Assert.AreEqual(1, customerViewModel.CustomerList.Count, "The AddCustomer command is not working, Customer was not added to the collection.");

			Assert.IsNotNull(dialogService.Message, "Message not displayed.");
		}

		private Action<CustomerViewModel> ChangeCurrentCustomer()
		{
			return x => x.CurrentCustomer = new Customer();
		}
	}
}
