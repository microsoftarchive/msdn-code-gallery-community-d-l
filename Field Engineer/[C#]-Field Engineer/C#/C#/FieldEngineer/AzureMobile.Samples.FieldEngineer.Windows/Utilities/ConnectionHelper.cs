// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using AzureMobile.Samples.FieldEngineer.DataSources;
using Windows.Networking.Connectivity;
using Windows.Storage;
using Windows.UI.Popups;

namespace AzureMobile.Samples.FieldEngineer.Utilities
{
    public static class ConnectionHelper
    {
        public static bool IsServiceAtLocalhost()
        {
            return AzureDataServices.MobileServiceClient.ApplicationUri.Host == "localhost";
        }

        public static bool IsInternetConnectionAvailable()
        {
            bool isNetworkAvailable = false;

            ConnectionProfile internetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();

            if (internetConnectionProfile != null && internetConnectionProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess)
            {
                isNetworkAvailable = true;
            }

            return isNetworkAvailable;
        }

        public static async void InternetConnectvityMessageHelper()
        {
            var messageDialog = new MessageDialog(Constants.DataConnectionUnavailableWarning);
            messageDialog.Commands.Add(new UICommand("Ok",
                (uicommand) => { }));
            messageDialog.Commands.Add(new UICommand(Constants.DoNotAskAgainText,
                (uicommand) =>
                {
                    ApplicationData.Current.LocalSettings.Values[Constants.ShowInternetNotAvailableMessageKey] = false;
                }));
            messageDialog.Commands.Add(new UICommand("Cancel", (uicommand) => { }));

            if ((bool)ApplicationData.Current.LocalSettings.Values[Constants.ShowInternetNotAvailableMessageKey])
            {
                await messageDialog.ShowAsync();
            }
        }
    }
}
