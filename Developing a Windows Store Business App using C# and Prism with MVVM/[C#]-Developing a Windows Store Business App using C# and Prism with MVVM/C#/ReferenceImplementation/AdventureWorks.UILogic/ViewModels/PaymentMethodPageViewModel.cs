// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Windows.Input;
using AdventureWorks.UILogic.Services;
using Microsoft.Practices.Prism.StoreApps;
using Microsoft.Practices.Prism.StoreApps.Interfaces;
using System.Threading.Tasks;
using AdventureWorks.UILogic.Repositories;

namespace AdventureWorks.UILogic.ViewModels
{
    public class PaymentMethodPageViewModel : ViewModel
    {
        private readonly IPaymentMethodUserControlViewModel _paymentMethodViewModel;
        private readonly ICheckoutDataRepository _checkoutDataRepository;
        private readonly IResourceLoader _resourceLoader;
        private readonly IAccountService _accountService;
        private readonly INavigationService _navigationService;
        private string _headerLabel;

        public PaymentMethodPageViewModel(IPaymentMethodUserControlViewModel paymentMethodViewModel, ICheckoutDataRepository checkoutDataRepository,
                                            IResourceLoader resourceLoader, IAccountService accountService, INavigationService navigationService)
        {
            _paymentMethodViewModel = paymentMethodViewModel;
            _checkoutDataRepository = checkoutDataRepository;
            _resourceLoader = resourceLoader;
            _accountService = accountService;
            _navigationService = navigationService;

            SaveCommand = DelegateCommand.FromAsyncHandler(SaveAsync);
        }

        public IPaymentMethodUserControlViewModel PaymentMethodViewModel
        { 
            get { return _paymentMethodViewModel; } 
        }

        public string HeaderLabel
        {
            get { return _headerLabel; }
            private set { SetProperty(ref _headerLabel, value); }
        }

        public ICommand SaveCommand { get; private set; }

        public override async void OnNavigatedTo(object navigationParameter, Windows.UI.Xaml.Navigation.NavigationMode navigationMode, System.Collections.Generic.Dictionary<string, object> viewModelState)
        {
            if (await _accountService.VerifyUserAuthenticationAsync() == null) return;

            var paymentMethodId = navigationParameter as string;

            HeaderLabel = string.IsNullOrWhiteSpace(paymentMethodId)
                  ? _resourceLoader.GetString("AddPaymentMethodTitle")
                  : _resourceLoader.GetString("EditPaymentMethodTitle");

            if (!string.IsNullOrWhiteSpace(paymentMethodId))
            {
                // Update PaymentMethod information
                PaymentMethodViewModel.PaymentMethod = await _checkoutDataRepository.GetPaymentMethodAsync(paymentMethodId);
            }
            PaymentMethodViewModel.OnNavigatedTo(navigationParameter, navigationMode, viewModelState);
        }

        public override void OnNavigatedFrom(System.Collections.Generic.Dictionary<string, object> viewModelState, bool suspending)
        {
            PaymentMethodViewModel.OnNavigatedFrom(viewModelState, suspending);
        }

        private async Task SaveAsync()
        {
            if (PaymentMethodViewModel.ValidateForm())
            {
                await PaymentMethodViewModel.ProcessFormAsync();
                _navigationService.GoBack();
            }
        }
    }
}