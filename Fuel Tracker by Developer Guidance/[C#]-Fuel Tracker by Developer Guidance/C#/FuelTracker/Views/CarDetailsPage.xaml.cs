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
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using FuelTracker.Model;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Controls;

namespace FuelTracker.Views
{
    public partial class CarDetailsPage : PhoneApplicationPage
    {
        private const string CAR_INFO_KEY = "CarInfo";
        private const string HAS_UNSAVED_CHANGES_KEY = "HasUnsavedChanges";
        private const string ODOMETER_READONLY_STATE = "OdometerReadOnlyState";
        private readonly PhotoChooserTask _photoTask = new PhotoChooserTask();
        private BitmapImage _carImage;
        private Car _car;
        private bool _hasUnsavedChanges;
        private TextBox _textboxWithFocus;

        /// <summary>
        /// Initializes a new instance of the CarDetailsPage class.
        /// </summary>
        public CarDetailsPage()
        {
            InitializeComponent();
            _photoTask.Completed += PhotoTask_Completed;
            NameTextBox.KeyDown += delegate { _hasUnsavedChanges = true; };
            OdometerTextBox.KeyDown += delegate { _hasUnsavedChanges = true; };
            GotFocus += CarDetailsPage_GotFocus;
        }

        

        void CarDetailsPage_GotFocus(object sender, RoutedEventArgs e)
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

            // Initialize the picture using the first available image from the 
            // PhotoChooserTask, the temporary photo, and the saved photo. 
            if (_carImage != null)
            {
                _car.Picture = _carImage;
            }
            else
            {
                if (CarDataStore.GetTempCarPhoto() != null)
                {
                    _car.Picture = CarDataStore.GetTempCarPhoto();
                }
                else
                {
                    _car.Picture = CarDataStore.Car.Picture;
                }
            }
        }

        /// <summary>
        /// Called when navigating away from this page; stores the car data
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
            State[CAR_INFO_KEY] = _car;
            State[ODOMETER_READONLY_STATE] = OdometerTextBox.IsReadOnly;
            State[HAS_UNSAVED_CHANGES_KEY] = _hasUnsavedChanges;
        }

        /// <summary>
        /// Initializes the view and its data context. 
        /// </summary>
        private void InitializePageState()
        {
            // Retrieve data from temporary storage if present; 
            // otherwise, copy data from CarDataStore.Car.
            if (State.ContainsKey(CAR_INFO_KEY))
            {
                _car = (Car)State[CAR_INFO_KEY];

                // Restore the read-only state of the odometer text box.
                OdometerTextBox.IsReadOnly = (bool)State[ODOMETER_READONLY_STATE];

                // Restore the change state except when the PhotoTask_Completed 
                // method has already set the change state.
                if (!_hasUnsavedChanges) _hasUnsavedChanges =
                    (bool)State[HAS_UNSAVED_CHANGES_KEY];

                // Delete temporary storage to avoid unnecessary storage costs.
                State.Clear();
            }
            else
            {
                _car = CarDataStore.Car;

                // Delete the temporary photo if it exists. This prevents an old
                // temporary photo selection from reappearing after tombstoning.
                CarDataStore.DeleteTempCarPhoto();

                // Disable the odometer text box when displaying a saved value.
                OdometerTextBox.IsReadOnly = _car.InitialOdometerReading > 0;

                // Disable the delete car button for new car
                if (_car.InitialOdometerReading.Equals(0))
                {
                    var deleteButton = (ApplicationBarIconButton)this.ApplicationBar.Buttons[1];
                    deleteButton.IsEnabled = false;
                }
            }

            // Set the page data context to the car.
            DataContext = _car;
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
            if (result == MessageBoxResult.OK)
            {
                CarDataStore.DeleteTempCarPhoto();
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Shows the photo chooser.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void PhotoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _photoTask.Show();
            }
            catch (InvalidOperationException)
            {
                // Button was tapped more than once. Do nothing.
            }
        }

        /// <summary>
        /// Displays the selected photo and saves it in temporary storage. 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void PhotoTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                _carImage = new BitmapImage();
                _carImage.SetSource(e.ChosenPhoto);
                CarDataStore.SaveTempCarPhoto(_carImage, delegate
                {
                    MessageBox.Show("There is not enough space on " +
                        "your phone to save your selection. Free some " +
                        "space and try again.", "Warning", MessageBoxButton.OK);
                });
                _hasUnsavedChanges = true;
            }
        }

        /// <summary>
        /// Validates the entered car data and, if validation is successful, 
        /// saves the data and navigates back to the SummaryPage. 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            CommitTextBoxWithFocus();

            if (string.IsNullOrWhiteSpace(_car.Name))
            {
                MessageBox.Show("The car name is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(OdometerTextBox.Text))
            {
                MessageBox.Show("The odometer reading is required.");
                return;
            }

            float val;
            if (!float.TryParse(OdometerTextBox.Text, out val))
            {
                MessageBox.Show("The odometer reading could not be converted to a number.");
                return;
            };

            if (_car.InitialOdometerReading < 1)
            {
                MessageBox.Show("The odometer reading must be greater than or equal to one.");
                return;
            }

            CarDataStore.Car.Name = _car.Name;
            CarDataStore.Car.InitialOdometerReading =
                _car.InitialOdometerReading;
            CarDataStore.Car.Picture = _car.Picture;
            CarDataStore.SaveCar(delegate
            {
                MessageBox.Show("There is not enough space on your phone to " +
                    "save your car data. Free some space and try again.");
            });

            NavigationService.GoBack();
        }

        /// <summary>
        /// Displays a warning dialog box to confirm deletion of the car data. 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // Commit any uncommitted changes. Changes in a bound text box are 
            // normally committed to the data source only when the text box 
            // loses focus. However, application bar buttons do not receive or 
            // change focus because they are not Silverlight controls. 
            CommitTextBoxWithFocus();

            var result = MessageBox.Show("You are about to delete the car " +
                "and its entire fill-up history. Continue?", "Warning",
                MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                // Reset the individual properties so that the bound
                // text boxes will update automatically.
                _car.Name = null;
                _car.Picture = null;
                _car.InitialOdometerReading = 0;
                _car.FillupHistory.Clear();
                _hasUnsavedChanges = false;
                OdometerTextBox.IsReadOnly = false;
                CarDataStore.DeleteCar();

                var deleteButton = (ApplicationBarIconButton)this.ApplicationBar.Buttons[1];
                deleteButton.IsEnabled = false;
            }
        }

        /// <summary>
        /// Ensures that any changes to text box values are committed. 
        /// </summary>
        private void CommitTextBoxWithFocus()
        {
            if (_textboxWithFocus == null) return;

            System.Windows.Data.BindingExpression expression =
                _textboxWithFocus.GetBindingExpression(TextBox.TextProperty);
            if (expression != null) expression.UpdateSource();

        }

    }
}