// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureMobile.Samples.FieldEngineer.DataModels;
using AzureMobile.Samples.FieldEngineer.DataSources;
using AzureMobile.Samples.FieldEngineer.Utilities;
using Capptain.Agent;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Settings Flyout item template is documented at http://go.microsoft.com/fwlink/?LinkId=273769

namespace AzureMobile.Samples.FieldEngineer.Flyout
{
    public sealed partial class PreferencesFlyout : SettingsFlyout
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PreferencesFlyout()
        {
            this.InitializeComponent();
            this.AssignSettingsValue();
        }

        /// <summary>
        /// Assigns the setting value to the control
        /// </summary>
        private void AssignSettingsValue()
        {
            this.StorageModeToggleSwitch.IsOn = true;
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey(Constants.Settings.StorageMode))
            {
                this.StorageModeToggleSwitch.IsOn = ApplicationData.Current.LocalSettings.Values[Constants.Settings.StorageMode].ToString() == Constants.Online;
            }

            // sets the visibility of the online mode controls
            this.StorageModeToggleSwitch_Toggled(this.StorageModeToggleSwitch, new RoutedEventArgs());

            if (ApplicationData.Current.LocalSettings.Values.ContainsKey(Constants.Settings.MobileServiceUrl))
            {
                MobileServiceURL.Text = ApplicationData.Current.LocalSettings.Values[Constants.Settings.MobileServiceUrl].ToString();
            }

            if (ApplicationData.Current.LocalSettings.Values.ContainsKey(Constants.Settings.MobileServiceAccessKey))
            {
                MobileServiceAccessKey.Text = ApplicationData.Current.LocalSettings.Values[Constants.Settings.MobileServiceAccessKey].ToString();
            }

            if (ApplicationData.Current.LocalSettings.Values.ContainsKey(Constants.Settings.ImageBlobLocationUrl))
            {
                ImageBlobLocationURL.Text = ApplicationData.Current.LocalSettings.Values[Constants.Settings.ImageBlobLocationUrl].ToString();
            }
        }

        private async Task<string> Validate()
        {
            string errorMessage = string.Empty;

            if (String.IsNullOrEmpty(MobileServiceURL.Text.Trim()))
            {
                errorMessage = Constants.MobileServiceUrlError;
            }
            else if (String.IsNullOrEmpty(MobileServiceAccessKey.Text.Trim()))
            {
                errorMessage = Constants.MobileServiceAccessKeyError;
            }
            else if (String.IsNullOrEmpty(ImageBlobLocationURL.Text.Trim()))
            {
                errorMessage = Constants.ImageBlobLocationUrlError;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                CapptainAgent.Instance.SendError("PreferencesFlyout.Validate.Error", new Dictionary<object, object>() { { "errorMessage", errorMessage } });
                return errorMessage;
            }

            this.ShowStatusMessage(Constants.ValidatingMobileServiceDetails, true);

            bool status = await ValidateAzureCredentials.ValidateMobileServiceUrl<Job>(MobileServiceURL.Text.Trim(), MobileServiceAccessKey.Text.Trim());
            if (!status)
            {
                errorMessage = Constants.InvalidMobileServiceCredential;
            }

            this.ShowStatusMessage(string.Empty, false);

            return errorMessage;
        }

        /// <summary>
        /// Saves the selected preferences value into local storage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //Hide Error Messages
            this.ShowErrorMessage(string.Empty, false);

            this.ShowProgressBar(true);

            if (this.StorageModeToggleSwitch.IsOn)
            {
                string errorMessage = await this.Validate();
                ApplicationData.Current.LocalSettings.Values[Constants.Settings.StorageMode] = this.StorageModeToggleSwitch.OnContent;

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    this.ShowErrorMessage(errorMessage, true);
                    this.ShowProgressBar(false);
                    return;
                }

                var previousMobileServiceUrl = ApplicationData.Current.LocalSettings.Values[Constants.Settings.MobileServiceUrl].ToString();
                var previousMobileServiceKey = ApplicationData.Current.LocalSettings.Values[Constants.Settings.MobileServiceAccessKey].ToString();
                ApplicationData.Current.LocalSettings.Values[Constants.Settings.MobileServiceUrl] = this.MobileServiceURL.Text;
                ApplicationData.Current.LocalSettings.Values[Constants.Settings.MobileServiceAccessKey] = this.MobileServiceAccessKey.Text;
                ApplicationData.Current.LocalSettings.Values[Constants.Settings.ImageBlobLocationUrl] = this.ImageBlobLocationURL.Text;

                if (!previousMobileServiceUrl.Equals(this.MobileServiceURL.Text, StringComparison.OrdinalIgnoreCase) ||
                    !previousMobileServiceKey.Equals(this.MobileServiceAccessKey.Text, StringComparison.OrdinalIgnoreCase))
                {
                    // If we changed the mobile service, we need to refresh the data
                    LocalStoreHelper.SyncAndRefreshUI();
                }
            }
            else
            {
                ApplicationData.Current.LocalSettings.Values[Constants.Settings.StorageMode] = this.StorageModeToggleSwitch.OffContent;
            }

            this.ShowStatusMessage(string.Empty, false);
            this.ShowProgressBar(false);
            
            this.Hide();
        }

        /// <summary>
        /// Shows or hides the controls for online storage when online option is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StorageModeToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            //Clearing the error text and Hiding the error textblock
            ErrorTextBlock.Text = string.Empty;
            ErrorTextBlock.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            if (((ToggleSwitch)sender).IsOn)
            {
                CapptainAgent.Instance.SendEvent("Switched to online");
                OnlineMode.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                CapptainAgent.Instance.SendEvent("Switched to offline");
                OnlineMode.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        private void ShowStatusMessage(string message, bool isMessageVisible)
        {
            if (isMessageVisible)
            {
                StatusTextBlock.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                StatusTextBlock.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }

            StatusTextBlock.Text = message;
        }

        private void ShowErrorMessage(string errorMessage, bool isErrorMessageVisible)
        {
            ErrorTextBlock.Text = errorMessage;
            if (isErrorMessageVisible)
            {
                ErrorTextBlock.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                ErrorTextBlock.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        private void ShowProgressBar(bool isVisible)
        {
            ProgressBar.IsActive = isVisible;
            ProgressBar.Visibility = isVisible ? Windows.UI.Xaml.Visibility.Visible : Windows.UI.Xaml.Visibility.Collapsed;
        }
    }
}
