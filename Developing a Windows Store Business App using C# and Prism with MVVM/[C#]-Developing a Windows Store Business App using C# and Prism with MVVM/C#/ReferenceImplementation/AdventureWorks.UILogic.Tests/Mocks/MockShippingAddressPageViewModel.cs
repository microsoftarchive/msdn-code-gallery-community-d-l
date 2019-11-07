// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using AdventureWorks.UILogic.Models;
using AdventureWorks.UILogic.ViewModels;
using Microsoft.Practices.Prism.StoreApps;
using Windows.UI.Xaml.Navigation;

namespace AdventureWorks.UILogic.Tests.Mocks
{
    public class MockShippingAddressPageViewModel : IShippingAddressUserControlViewModel
    {
        public Address Address { get; set; }
        public IReadOnlyCollection<ComboBoxItemValue> States { get; set; }
        public bool SetAsDefault { get; set; }
        public string FirstError { get; set; }
        public BindableValidator Errors { get; private set; }
        public ICommand GoBackCommand { get; private set; }
        public ICommand GoNextCommand { get; private set; }
        public string EntityId { get; set; }
        public Func<bool> ValidateFormDelegate { get; set; }

        public Func<Task> ProcessFormAsyncDelegate { get; set; }

        public void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewState)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedFrom(Dictionary<string, object> viewState, bool suspending)
        {
            throw new NotImplementedException();
        }

        public void GoNext()
        {
            throw new NotImplementedException();
        }

        public Task ProcessFormAsync()
        {
            return ProcessFormAsyncDelegate();
        }

        public bool ValidateForm()
        {
            return ValidateFormDelegate();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        public void SetLoadDefault(bool loadDefault)
        {
            throw new NotImplementedException();
        }

        public Task PopulateStatesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
