// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using AdventureWorks.Events;
using AdventureWorks.UILogic.ViewModels;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.StoreApps.Interfaces;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace AdventureWorks.Shopper.Views
{
    /// <summary>
    /// The SearchUserControl encapsulates the functionality and configuration related to the SearchBox control.
    /// http://go.microsoft.com/fwlink/?LinkID=386787
    /// </summary>
    public sealed partial class SearchUserControl : UserControl
    {
        private readonly IEventAggregator _eventAggregator;

        public static readonly DependencyProperty IsCompactProperty =
            DependencyProperty.RegisterAttached("IsCompact", typeof(bool), typeof(SearchUserControl),
            new PropertyMetadata(false, (o, e) => ((SearchUserControl)o).ChangeSearchBoxVisibility(!(bool)e.NewValue)));

        public SearchUserControl()
        {
            this.InitializeComponent();
            this.ChangeSearchBoxVisibility(!this.IsCompact);

            this.searchBox.LostFocus += searchBox_LostFocus;
            this.searchBox.PrepareForFocusOnKeyboardInput += searchBox_PrepareForFocusOnKeyboardInput;
            this.searchButton.Click += Button_Click;
            this.IsCompact = false;

            var currentApp = App.Current as App;

            if (currentApp != null)
            {
                _eventAggregator = currentApp.EventAggregator;
            }
        }

        /// <summary>
        /// The IsCompact property is a Dependency Property that provides the ability to hide 
        /// the SearchBox control and display a small search button.
        /// </summary>
        public bool IsCompact
        {
            get
            {
                return (bool)this.GetValue(IsCompactProperty);
            }
            set
            {
                if (this.IsCompact != value)
                {
                    this.SetValue(IsCompactProperty, value);
                    this.ChangeSearchBoxVisibility(!value);
                }
            }
        }

        /// <summary>
        /// The EnableFocusOnKeyboardInput method sets the SearchBox control's FocusOnKeyboardInput property
        /// to true and subscribes to the FocusOnKeyboardInputChangedEvent (EventAggregator event).
        /// There may be only one SearchBox control that has its FocusOnKeyboardInput property set to true, at a time.
        /// Therefore, it is important to call the DisableFocusOnKeyboardInput method on any SearchUserControl instances
        /// that were enabled prior to enabling a new instance.
        /// </summary>
        public void EnableFocusOnKeyboardInput()
        {
            this.searchBox.FocusOnKeyboardInput = true;
            
            if (_eventAggregator != null)
            {
                _eventAggregator.GetEvent<FocusOnKeyboardInputChangedEvent>().Subscribe(FocusOnKeyboardInputToggle);
            }
        }

        public void DisableFocusOnKeyboardInput()
        {
            this.searchBox.FocusOnKeyboardInput = false;

            if (_eventAggregator != null)
            {
                _eventAggregator.GetEvent<FocusOnKeyboardInputChangedEvent>().Unsubscribe(FocusOnKeyboardInputToggle);
            }
        }

        private void FocusOnKeyboardInputToggle(bool value)
        {
            this.searchBox.FocusOnKeyboardInput = value;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.ChangeSearchBoxVisibility(true);

            this.searchBox.Focus(FocusState.Programmatic);
        }

        void searchBox_PrepareForFocusOnKeyboardInput(SearchBox sender, RoutedEventArgs args)
        {
            this.ChangeSearchBoxVisibility(true);

            this.searchBox.Focus(FocusState.Programmatic);
        }

        void searchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.IsCompact)
            {
                this.ChangeSearchBoxVisibility(false);
                this.searchBox.QueryText = "";
            }
        }

        private void ChangeSearchBoxVisibility(bool showSearchBox)
        {
            if (showSearchBox)
            {
                this.searchBox.Visibility = Visibility.Visible;
                this.searchButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.searchBox.Visibility = Visibility.Collapsed;
                this.searchButton.Visibility = Visibility.Visible;
            }
        }

    }
}
