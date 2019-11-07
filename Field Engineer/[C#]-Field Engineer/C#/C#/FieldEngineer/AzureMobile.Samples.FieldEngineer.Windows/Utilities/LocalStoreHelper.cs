// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureMobile.Samples.FieldEngineer.DataModels;
using AzureMobile.Samples.FieldEngineer.DataSources;
using Capptain.Agent;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AzureMobile.Samples.FieldEngineer.Utilities
{
    internal class LocalStoreHelper
    {
        public static async Task InitializeLocalStore(string userId)
        {
            CapptainAgent.Instance.StartJob("Local store initialization");
            var store = new MobileServiceSQLiteStore("FieldEnigneerLocalStore" + userId);
            store.DefineTable<Job>();
            store.DefineTable<Equipment>();
            store.DefineTable<EquipmentSpecification>();
            await AzureDataServices.MobileServiceClient.SyncContext.InitializeAsync(store, new SyncHandler(AzureDataServices.MobileServiceClient));
            CapptainAgent.Instance.EndJob("Local store initialization");
        }

        internal static async void SyncAndRefreshUI()
        {
            if (ConnectionHelper.IsInternetConnectionAvailable())
            {
                ApplicationData.Current.LocalSettings.Values[Constants.Settings.StorageMode] = Constants.Online;
            }
            string errorString = null;
            if (ApplicationData.Current.LocalSettings.Values[Constants.Settings.StorageMode].ToString() == Constants.Online)
            {
                CapptainAgent.Instance.SendEvent("SyncWithServer button clicked");
                await LoginHelper.MobileServiceAuthenticate();
                try
                {
                    await AzureDataServices.MobileServiceClient.SyncContext.PushAsync();
                    await DataManager.JobDataSource.GetAllJobs(true);
                    if (Window.Current != null)
                    {
                        //Re-load the app only if current page is job lists page
                        Frame mainFrame = Window.Current.Content as Frame;
                        if (mainFrame.SourcePageType.Name == "JobListPage")
                        {
                            //Navigating to landing page
                            mainFrame.Navigate(typeof(JobListPage), string.Empty);
                        }
                    }
                    else
                    {
                        AzureDataServices.RefreshJobsListPage = true;
                    }
                }
                catch (MobileServicePushFailedException ex)
                {
                    CapptainAgent.Instance.SendError("MobileServicePushFailedException.Error", new Dictionary<object, object>() { { "Push failed because of sync errors:", ex.Message } });
                    errorString = "Push failed because of sync errors:" + ex.Message;
                }
                catch (Exception ex)
                {
                    CapptainAgent.Instance.SendError("SyncAndRefreshUI Error:", new Dictionary<object, object>() { { "errorMessage:", ex.Message } });
                    throw;
                }
            }
            else
            {
                errorString = Constants.NoInternetMessageHeader;
            }

            if (errorString != null)
            {
                MessageDialog dialog = new MessageDialog(errorString);
                dialog.Commands.Add(new UICommand("Ok"));
                await dialog.ShowAsync();
            }
        }
    }
}
