// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using AdventureWorks.Events;
using AdventureWorks.UILogic.Models;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.StoreApps.Interfaces;
using Windows.ApplicationModel.Search;
using Windows.System;
using Windows.UI.Xaml.Controls;

namespace AdventureWorks.Shopper.Views
{
    public sealed partial class SignInFlyout : SettingsFlyout
    {
        private readonly IEventAggregator _eventAggregator;
        public SignInFlyout(IEventAggregator eventAggregator)
        {
            this.InitializeComponent();
            _eventAggregator = eventAggregator;
            this.PasswordBox.KeyDown += PasswordBox_KeyDown;
            this.Unloaded +=SignInFlyout_Unloaded;
            _eventAggregator.GetEvent<FocusOnKeyboardInputChangedEvent>().Publish(false);
            var viewModel = this.DataContext as IFlyoutViewModel;
            viewModel.CloseFlyout = () => this.Hide();
        }

        void SignInFlyout_Unloaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            _eventAggregator.GetEvent<FocusOnKeyboardInputChangedEvent>().Publish(true);
        }

        void PasswordBox_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                SubmitButton.Command.Execute(null);
            }
        }
    }
}
