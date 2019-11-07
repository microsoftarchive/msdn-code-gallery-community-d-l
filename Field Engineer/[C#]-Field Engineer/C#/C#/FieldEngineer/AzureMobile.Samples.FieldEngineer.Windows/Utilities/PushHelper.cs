// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using AzureMobile.Samples.FieldEngineer.DataSources;
using Microsoft.WindowsAzure.MobileServices;
using Windows.Networking.PushNotifications;
using Windows.Storage;

namespace AzureMobile.Samples.FieldEngineer.Utilities
{
    public class PushHelper
    {
        public static async Task RegisterForPush()
        {
            if (ConnectionHelper.IsServiceAtLocalhost())
            {
                // F5-experience: talking to localhost, skip push registration
                return;
            }

            if (ApplicationData.Current.LocalSettings.Values[Constants.Settings.StorageMode].ToString() == Constants.Online && !AzureDataServices.MobileServiceUserPushRegistered)
            {
                var pushChannel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();
                pushChannel.PushNotificationReceived += PushChannel_PushNotificationReceived;
                var push = AzureDataServices.MobileServiceClient.GetPush();
                var toastTemplate = "<toast>"
                                        + "<visual>"
                                           + "<binding template=\"ToastText01\">"
                                               + " <text id=\"1\">$(message)</text>"
                                           + "</binding>"
                                         + "</visual>"
                                       + "</toast>";
                await push.RegisterTemplateAsync(pushChannel.Uri, toastTemplate.ToString(), "NewJobTemplate");
                AzureDataServices.MobileServiceUserPushRegistered = true;
            }
        }

        internal static void PushChannel_PushNotificationReceived(PushNotificationChannel sender, PushNotificationReceivedEventArgs args)
        {
            LocalStoreHelper.SyncAndRefreshUI();
        }
    }
}
