// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Globalization;
using Microsoft.Practices.Prism.StoreApps;
using Microsoft.Practices.Prism.StoreApps.Interfaces;

namespace AdventureWorks.UILogic.ViewModels
{
    public class OrderConfirmationPageViewModel : ViewModel
    {
        private readonly IResourceLoader _resourceLoader;

        public OrderConfirmationPageViewModel(IResourceLoader resourceLoader)
        {
            _resourceLoader = resourceLoader;
        }

        public string OrderConfirmationContent { get; set; }

        public override void OnNavigatedTo(object navigationParameter, Windows.UI.Xaml.Navigation.NavigationMode navigationMode, System.Collections.Generic.Dictionary<string, object> viewModelState)
        {
            OrderConfirmationContent = string.Format(CultureInfo.InvariantCulture, _resourceLoader.GetString("OrderConfirmationContent"), navigationParameter);
        }
    }
}