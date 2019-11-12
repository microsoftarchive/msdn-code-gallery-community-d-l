// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;
using AdventureWorks.UILogic.Models;
using AdventureWorks.UILogic.Services;
using Microsoft.Practices.Prism.StoreApps;
using Microsoft.Practices.Prism.StoreApps.Interfaces;

namespace AdventureWorks.UILogic.ViewModels
{
    public class SignOutFlyoutViewModel : BindableBase, IFlyoutViewModel
    {
        private readonly IAccountService _accountService;
        private readonly INavigationService _navigationService;
        private readonly UserInfo _userInfo;
        private DelegateCommand _signOutCommand;
        private string _userName;
        private Action _closeFlyout;

        public SignOutFlyoutViewModel(IAccountService accountService, INavigationService navigationService)
        {
            _accountService = accountService;
            _navigationService = navigationService;
            if (_accountService != null)
                _userInfo = _accountService.SignedInUser;

            if (_userInfo != null)
            {
                UserName = _userInfo.UserName;
            }
            SignOutCommand = new DelegateCommand(SignOut, CanSignOut);
        }

        public Action CloseFlyout
        {
            get { return _closeFlyout; }
            set { SetProperty(ref _closeFlyout, value); }
        }

        public DelegateCommand SignOutCommand
        {
            get { return _signOutCommand; }
            private set { SetProperty(ref _signOutCommand, value); }
        }

        private bool CanSignOut()
        {
            return _userInfo != null;
        }

        private void SignOut()
        {
            _accountService.SignOut();
            _navigationService.ClearHistory();
            //Navigate to Hub page with time stamp to ensure a navigation even if user is currently on Hub page.
            //If user is currently on Hub page and navigation is attempted with same navigation parameter, 
            //nothing will be added to the navigation stack.
            _navigationService.Navigate("Hub", DateTime.Now);
            CloseFlyout();
        }

        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }
    }
}
