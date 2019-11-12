// ===================================================================================
//  Microsoft Developer Guidance
//  Application Guidance for Windows Phone 7 
// ===================================================================================
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//  OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//  LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//  FITNESS FOR A PARTICULAR PURPOSE.
// ===================================================================================
//  The example companies, organizations, products, domain names,
//  e-mail addresses, logos, people, places, and events depicted
//  herein are fictitious.  No association with any real company,
//  organization, product, domain name, email address, logo, person,
//  places, or events is intended or should be inferred.
// ===================================================================================

using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Navigation;
using FuelTracker.Model;
using Microsoft.Phone.Controls;

namespace FuelTracker.Views
{
    public partial class FillupPage : PhoneApplicationPage
    {
        private const string CURRENT_FILLUP_KEY = "CurrentFillup";
        private const string HAS_UNSAVED_CHANGES_KEY = "HasUnsavedChanges";
        private Fillup _currentFillup;
        private bool _hasUnsavedChanges;
        private TextBox _textboxWithFocus;

        /// <summary>
        /// Initializes a new instance of the FillupPage class.
        /// </summary>
        public FillupPage()
        {
            InitializeComponent();
            OdometerTextBox.KeyDown += delegate { _hasUnsavedChanges = true; };
            FuelQuantityTextBox.KeyDown += delegate { _hasUnsavedChanges = true; };
            PricePerUnitTextBox.KeyDown += delegate { _hasUnsavedChanges = true; };
            GotFocus += FillupPage_GotFocus;
        }

        void FillupPage_GotFocus(object sender, RoutedEventArgs e)
        {
            _textboxWithFocus = e.OriginalSource as TextBox;
        }

        /// <summary>
        /// Called when navigating to this page; loads the car data from storage 
        /// and then initializes the page state.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Initialize the page state only if it is not already initialized,
            // and not when the application was deactivated but not tombstoned (returning from being dormant).
            if (DataContext == null)
            {
                InitializePageState();
            }

            // Delete temporary storage to avoid unnecessary storage costs.
            State.Clear();
        }

        /// <summary>
        /// Called when navigating away from this page; stores the fill-up data
        /// values and a value that indicates whether there are unsaved changes. 
        /// </summary>
        /// <param name="e">The event data.</param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            // Do not cache the page state when navigating backward 
            // or when there are no unsaved changes.
            if (e.Uri.OriginalString.Equals("//Views/SummaryPage.xaml") ||
                !_hasUnsavedChanges) return;

            CommitTextBoxWithFocus();
            State[CURRENT_FILLUP_KEY] = _currentFillup;
            State[HAS_UNSAVED_CHANGES_KEY] = _hasUnsavedChanges;
        }

        /// <summary>
        /// Initializes the view and its data context. 
        /// </summary>
        private void InitializePageState()
        {
            CarHeader.DataContext = CarDataStore.Car;

            DataContext = _currentFillup =
                State.ContainsKey(CURRENT_FILLUP_KEY) ?
                (Fillup)State[CURRENT_FILLUP_KEY] :
                new Fillup { Date = DateTime.Now };

            _hasUnsavedChanges = State.ContainsKey(HAS_UNSAVED_CHANGES_KEY) && (bool)State[HAS_UNSAVED_CHANGES_KEY];

        }

        /// <summary>
        /// Displays a warning dialog box if the user presses the back button
        /// and there are unsaved changes. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnBackKeyPress(
            System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);

            // If there are no changes, do nothing.
            if (!_hasUnsavedChanges) return;

            var result = MessageBox.Show("You are about to discard your " +
                "changes. Continue?", "Warning", MessageBoxButton.OKCancel);
            e.Cancel = (result == MessageBoxResult.Cancel);
        }

        /// <summary>
        /// Validates the entered fill-up data and, if validation is successful, 
        /// saves the data and navigates back to the SummaryPage. 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Commit any uncommitted changes. Changes in a bound text box are 
            // normally committed to the data source only when the text box 
            // loses focus. However, application bar buttons do not receive or 
            // change focus because they are not Silverlight controls. 
            CommitTextBoxWithFocus();

            if (string.IsNullOrWhiteSpace(OdometerTextBox.Text))
            {
                MessageBox.Show("The odometer reading is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(FuelQuantityTextBox.Text))
            {
                MessageBox.Show("The gallons value is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(PricePerUnitTextBox.Text))
            {
                MessageBox.Show("The price per gallon value is required.");
                return;
            }

            float val;
            if (!float.TryParse(OdometerTextBox.Text, out val))
            {
                MessageBox.Show("The odometer reading could not be converted to a number.");
                return;
            };

            if (!float.TryParse(FuelQuantityTextBox.Text, out val))
            {
                MessageBox.Show("The gallons value could not be converted to a number.");
                return;
            };

            if (!float.TryParse(PricePerUnitTextBox.Text, out val))
            {
                MessageBox.Show("The price per gallon value could not be converted to a number.");
                return;
            };

           
            SaveResult result = CarDataStore.SaveFillup(_currentFillup,
                delegate
                {
                    MessageBox.Show("There is not enough space on your phone to " +
                    "save your fill-up data. Free some space and try again.");
                });

            if (result.SaveSuccessful)
            {
                Microsoft.Phone.Shell.PhoneApplicationService.Current
                    .State[Constants.FILLUP_SAVED_KEY] = true;
                NavigationService.GoBack();
            }
            else
            {
                string errorMessages = String.Join(
                    Environment.NewLine + Environment.NewLine,
                    result.ErrorMessages.ToArray());
                if (!String.IsNullOrEmpty(errorMessages))
                {
                    MessageBox.Show(errorMessages,
                        "Warning: Invalid Values", MessageBoxButton.OK);
                }
            }
        }

        /// <summary>
        /// Ensures that any changes to text box values are committed. 
        /// </summary>
        private void CommitTextBoxWithFocus()
        {
            if (_textboxWithFocus == null) return;

            BindingExpression expression =
                _textboxWithFocus.GetBindingExpression(TextBox.TextProperty);
            if (expression != null) expression.UpdateSource();
        }
    }
}
