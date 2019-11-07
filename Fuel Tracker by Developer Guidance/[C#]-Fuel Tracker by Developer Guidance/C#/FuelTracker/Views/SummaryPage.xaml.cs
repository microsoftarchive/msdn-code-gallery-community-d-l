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
using System.Reflection;
using System.Windows;
using System.Windows.Navigation;
using FuelTracker.Model;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Controls;

namespace FuelTracker.Views
{
    public partial class SummaryPage : PhoneApplicationPage
    {
        private const string PIVOT_INDEX_KEY = "PivotIndex";

        /// <summary>
        /// Initializes a new instance of the SummaryPage class.
        /// </summary>
        public SummaryPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when navigating to this page; loads the car data from storage 
        /// on the first navigation (that is, at application launch and
        /// reactivation) and initializes the page state.
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

            // Determine whether the Car object is empty by checking for an 
            // initial odometer reading of zero (invalid for a non-empty car). 
            bool isCarObjectEmpty = CarDataStore.Car.InitialOdometerReading.Equals(0);

            // Display the instruction panel only if the Car object is empty.
            InstructionPanel.Visibility =
                isCarObjectEmpty ? Visibility.Visible : Visibility.Collapsed;

            // Display the pivot control only if the Car object is not empty.
            SummaryPivot.Visibility =
                isCarObjectEmpty ? Visibility.Collapsed : Visibility.Visible;

            // Enable the fill-up button only if the Car object is not empty. 
            (ApplicationBar.Buttons[0] as ApplicationBarIconButton).IsEnabled =
                !isCarObjectEmpty;
        }

        /// <summary>
        /// Called when navigating away from this page; stores the index of the 
        /// current pivot item.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            State[PIVOT_INDEX_KEY] = SummaryPivot.SelectedIndex;
        }

        /// <summary>
        /// Initializes the view. 
        /// </summary>
        private void InitializePageState()
        {

            CarDataStore.CarUpdated += CarDataStore_CarUpdated;
            DataContext = CarDataStore.Car;

            // If a fill-up has just been added, display the first pivot item
            // (index 0). If reactivation has just occurred, restore the pivot 
            // item showing at the time of deactivation. If neither condition
            // is true, then the application has just been launched, so the 
            // Pivot control will show the first item by default. 
            if (PhoneApplicationService.Current.State.ContainsKey(Constants.FILLUP_SAVED_KEY))
            {
                SummaryPivot.SelectedIndex = 0;
                PhoneApplicationService.Current.State.Remove(Constants.FILLUP_SAVED_KEY);
            }
            else if (State.ContainsKey(PIVOT_INDEX_KEY))
            {
                SummaryPivot.SelectedIndex = (int)State[PIVOT_INDEX_KEY];
            }
        }

        void CarDataStore_CarUpdated(object sender, EventArgs e)
        {
            DataContext = CarDataStore.Car;
        }

        /// <summary>
        /// Navigates to the fill-up page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void FillupButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(
                new Uri("//Views/FillupPage.xaml", UriKind.Relative));
        }

        /// <summary>
        /// Navigates to the car details page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void CarButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(
                new Uri("//Views/CarDetailsPage.xaml", UriKind.Relative));
        }

        /// <summary>
        /// Displays the Fuel Tracker version number and support URL.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            string fullName = Assembly.GetExecutingAssembly().FullName;
            AssemblyName assemblyName = new AssemblyName(fullName);
            string productTitle = null;

            object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);

            if ((customAttributes.Length > 0))
            {
                productTitle = ((AssemblyTitleAttribute)customAttributes[0]).Title;
            }

            MessageBox.Show(productTitle + " sample application" +
                Environment.NewLine + "version " + assemblyName.Version +
                Environment.NewLine + "http://dgwp7.codeplex.com",
                "About Fuel Tracker", MessageBoxButton.OK);
        }

    }
}
