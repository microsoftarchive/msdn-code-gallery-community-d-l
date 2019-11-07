// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using AzureMobile.Samples.FieldEngineer.Common;
using AzureMobile.Samples.FieldEngineer.DataModels;
using AzureMobile.Samples.FieldEngineer.DataSources;
using AzureMobile.Samples.FieldEngineer.Flyout;
using AzureMobile.Samples.FieldEngineer.Utilities;
using Capptain.Agent;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.System;
using Windows.UI.ApplicationSettings;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AzureMobile.Samples.FieldEngineer
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton Application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += this.OnSuspending;

            this.UnhandledException += this.App_UnhandledException;
        }

        private async void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //Handle network drop/access issues when app is running "Online" mode.
            if (e.Exception is System.Net.Http.HttpRequestException)
            {
                //Make the application not to crash
                e.Handled = true;

                //Show the dialog to user
                MessageDialog dialog = new MessageDialog(Constants.DataConnectionUnavailableWarning);

                dialog.Commands.Add(new UICommand("Ok", (uicommand) =>
                {
                    //Switch application offline
                    ApplicationData.Current.LocalSettings.Values[Constants.Settings.StorageMode] = Constants.Offline;
                }));

                await dialog.ShowAsync();
            }
            CapptainAgent.Instance.SendCrash(e.Exception, e.Exception.StackTrace, false);
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
            CapptainAgent.Instance.Init(e);
            Frame rootFrame = Window.Current.Content as Frame;

            ApplicationData.Current.LocalSettings.Values[Constants.Settings.MobileServiceUrl] = Secrets.MobileServiceUrl;
            ApplicationData.Current.LocalSettings.Values[Constants.Settings.MobileServiceAccessKey] = Secrets.MobileServiceAccessKey;
            ApplicationData.Current.LocalSettings.Values[Constants.Settings.ImageBlobLocationUrl] = Secrets.ImageBlobLocationUrl;
            ApplicationData.Current.LocalSettings.Values[Constants.Settings.AadAuthority] = Secrets.AadAuthority;
            ApplicationData.Current.LocalSettings.Values[Constants.Settings.AadResourceUri] = Secrets.AadResourceUri;
            ApplicationData.Current.LocalSettings.Values[Constants.Settings.AadClientId] = Secrets.AadNativeClientId;
            ApplicationData.Current.LocalSettings.Values[Constants.Settings.StorageMode] = Constants.Online;

            if (!ConnectionHelper.IsInternetConnectionAvailable())
            {
                ApplicationData.Current.LocalSettings.Values[Constants.Settings.StorageMode] = Constants.Offline;
            }

            AzureDataServices.InitializeMobileServiceClient();

            (Application.Current as App).DataManagerInitialize();

            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();
                //Associate the frame with a SuspensionManager key                                
                SuspensionManager.RegisterFrame(rootFrame, "AppFrame");

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null || !string.IsNullOrEmpty(e.Arguments))
            {
                //Checking for Online mode, If online mode then verifying whether internet is available or not.
                //If no internet then navigating to Internet Error Page.
                if (ApplicationData.Current.LocalSettings.Values.ContainsKey(Constants.Settings.StorageMode))
                {
                    if (ApplicationData.Current.LocalSettings.Values[Constants.Settings.StorageMode].ToString() == Constants.Online)
                    {
                        if (!ConnectionHelper.IsInternetConnectionAvailable())
                        {
                            MessageDialog dialog = new MessageDialog(Constants.DataConnectionUnavailableWarning);

                            dialog.Commands.Add(new UICommand("Ok", (uicommand) =>
                            {
                                ApplicationData.Current.LocalSettings.Values[Constants.Settings.StorageMode] = Constants.Offline;
                            }));

                            await dialog.ShowAsync();
                        }
                    }
                }

                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (string.IsNullOrEmpty(e.Arguments))
                {
                    if (!rootFrame.Navigate(typeof(JobListPage), e.Arguments))
                    {
                        throw new Exception("Failed to create initial page");
                    }
                }
                else
                {
                    if (!rootFrame.Navigate(typeof(JobDetailPage), e.Arguments))
                    {
                        throw new Exception("Failed to create initial page");
                    }
                }
            }

            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// The on window created.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        protected override void OnWindowCreated(WindowCreatedEventArgs args)
        {
            SettingsPane.GetForCurrentView().CommandsRequested += this.OnCommandsRequested;
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            await SuspensionManager.SaveAsync();
            deferral.Complete();
        }

        /// <summary>
        /// Invoked when the application is activated to display search results.
        /// </summary>
        /// <param name="args">Details about the activation request.</param>
        protected async override void OnSearchActivated(Windows.ApplicationModel.Activation.SearchActivatedEventArgs args)
        {
            // TODO: Register the Windows.ApplicationModel.Search.SearchPane.GetForCurrentView().QuerySubmitted
            // event in OnWindowCreated to speed up searches once the application is already running

            // If the Window isn't already using Frame navigation, insert our own Frame
            var previousContent = Window.Current.Content;
            var frame = previousContent as Frame;

            // If the app does not contain a top-level frame, it is possible that this 
            // is the initial launch of the app. Typically this method and OnLaunched 
            // in App.xaml.cs can call a common method.
            if (frame == null)
            {
                // Create a Frame to act as the navigation context and associate it with
                // a SuspensionManager key
                frame = new Frame();
                SuspensionManager.RegisterFrame(frame, "AppFrame");

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // Restore the saved session state only when appropriate
                    try
                    {
                        await SuspensionManager.RestoreAsync();
                    }
                    catch (SuspensionManagerException)
                    {
                        //Something went wrong restoring state.
                        //Assume there is no state and continue
                    }
                }
            }

            frame.Navigate(typeof(SearchResultsPage), args.QueryText);
            Window.Current.Content = frame;

            // Ensure the current window is active
            Window.Current.Activate();
        }

        #region Feature - Live Tile

        /// <summary>
        /// This method takes a Job as its input and generates an XML Document which contains the actual values to
        /// be displayed in the live tile.
        /// </summary>
        /// <param name="job">An object of Job class for getting the actual content to be shown</param>
        /// <returns>An XML document which is used for generating the 310 x 150 wide live tile content</returns>
        private XmlDocument CreateWideTile(Job job)
        {
            // Create a live update for a wide tile
            XmlDocument wideTileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150Text01);

            // Assign text
            XmlNodeList wideTileTextAttributes = wideTileXml.GetElementsByTagName("text");
            wideTileTextAttributes[0].AppendChild(wideTileXml.CreateTextNode(job.JobNumber + " - " + job.Id));
            wideTileTextAttributes[1].AppendChild(wideTileXml.CreateTextNode(job.Title));

            return wideTileXml;
        }

        /// <summary>
        /// This method takes a Job as its input and generates an XML Document which contains the actual values to
        /// be displayed in the live tile.
        /// </summary>
        /// <param name="job">An object of Job class for getting the actual content to be shown</param>
        /// <returns>An XML document which is used for generating the 310 x 310 square live tile content</returns>
        private XmlDocument CreateSquareTile(Job job)
        {
            // Create a live update for a square tile
            XmlDocument wideTileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare310x310Text01);

            // Assign text
            XmlNodeList wideTileTextAttributes = wideTileXml.GetElementsByTagName("text");
            wideTileTextAttributes[0].AppendChild(wideTileXml.CreateTextNode(job.JobNumber + " - " + job.Id));
            wideTileTextAttributes[1].AppendChild(wideTileXml.CreateTextNode(job.Title));
            wideTileTextAttributes[2].AppendChild(wideTileXml.CreateTextNode(job.Status));
            wideTileTextAttributes[3].AppendChild(wideTileXml.CreateTextNode(string.Empty));
            wideTileTextAttributes[4].AppendChild(wideTileXml.CreateTextNode(job.Customer.FullName));
            wideTileTextAttributes[5].AppendChild(wideTileXml.CreateTextNode(job.Customer.HouseNumberOrName + ", " + job.Customer.Street));
            wideTileTextAttributes[6].AppendChild(wideTileXml.CreateTextNode(job.Customer.Town));
            wideTileTextAttributes[7].AppendChild(wideTileXml.CreateTextNode(job.Customer.Town));
            wideTileTextAttributes[8].AppendChild(wideTileXml.CreateTextNode(job.Customer.Postcode));

            return wideTileXml;
        }

        public void DataManagerInitialize()
        {
            string imageBlobLocationURL = ApplicationData.Current.LocalSettings.Values[Constants.Settings.ImageBlobLocationUrl].ToString();
            DataManager.Initialize(imageBlobLocationURL);
        }

        #endregion

        #region Feature - Settings

        /// <summary>
        /// The on commands requested.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        private void OnCommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            args.Request.ApplicationCommands.Add(new SettingsCommand("Preferences", "Preferences", (handler) => this.ShowPreferencesFlyout()));
            args.Request.ApplicationCommands.Add(new SettingsCommand("PrivacyStatement", "Privacy Statement", (handler) => this.LaunchPrivacyStatementUri()));
        }

        /// <summary>
        ///     The show role and region flyout.
        /// </summary>
        public void ShowPreferencesFlyout()
        {
            var preferencesFlyout = new PreferencesFlyout();
            preferencesFlyout.Show();
        }

        public async void LaunchPrivacyStatementUri()
        {
            Uri privacyStatementUrl = new Uri(Constants.PrivacyPolicyUrl);
            await Launcher.LaunchUriAsync(privacyStatementUrl);
        }
        #endregion
    }
}
