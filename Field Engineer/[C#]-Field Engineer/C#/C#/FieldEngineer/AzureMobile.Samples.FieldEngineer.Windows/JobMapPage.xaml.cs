// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using AzureMobile.Samples.FieldEngineer.Common;
using AzureMobile.Samples.FieldEngineer.CustomControls;
using AzureMobile.Samples.FieldEngineer.DataModels;
using AzureMobile.Samples.FieldEngineer.DataSources;
using AzureMobile.Samples.FieldEngineer.Utilities;
using Bing.Maps;
using Capptain.Agent;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace AzureMobile.Samples.FieldEngineer
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class JobMapPage : CapptainPage
    {
        #region Properties & Variables

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        #endregion

        #region Constructor
        public JobMapPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        #endregion

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        #region Page Events

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            //Checking for internet connection in online mode. 
            //If not available then showing pop-up and switching to offline mode.
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

                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        /// <summary>
        /// Handles top navigation bar item click events. 
        /// Based on context, the user will either be taken to job list page or map page.
        /// </summary>
        private void NavigationGridView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            string tag = null;
            var item = e.ClickedItem as Border;
            if (item != null)
            {
                tag = item.Tag as string;
            }

            CapptainAgent.Instance.SendSessionEvent("NavigationGridView_OnItemClick", new Dictionary<object, object> { { "tag", tag } });

            switch (tag as string)
            {
                case "0":
                    this.Frame.Navigate(typeof(JobListPage));
                    break;
                case "1":
                    TopAppBar.IsOpen = false;
                    break;
                case "3":
                    this.Frame.Navigate(typeof(JobListPage));
                    this.Frame.BackStack.Clear();
                    break;
            }
        }

        #endregion

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        #region Bing Map Integration

        /// <summary>
        /// Handles the Loaded event for the map.
        /// </summary>
        private async void Map_Loaded(object sender, RoutedEventArgs e)
        {
            MapView.Credentials = Secrets.BingMapsCredentials;
            //Step1: Fetch all the jobs to be shown on the map
            List<Job> jobs = await DataManager.JobDataSource.GetAllJobs();

            //Step2: Create pushpin for each job and add it to the map
            foreach (var job in jobs)
            {
                Pushpin pushpin = null;
                switch (job.Status)
                {
                    case Constants.CurrentStatus:
                        pushpin = this.CreatePushpin(job, "MapPushpinCurrentJobTemplate");
                        break;
                    case Constants.PendingStatus:
                        pushpin = this.CreatePushpin(job, "MapPushpinPendingJobsTemplate");
                        break;
                    case Constants.CompletedStatus:
                        pushpin = this.CreatePushpin(job, "MapPushpinCompletedJobsTemplate");
                        break;
                }

                //Add it to map
                MapView.Children.Add(pushpin);
            }

            //Step3: Set the default map focus to the current job i.e. with status as "on site"
            var currentJob = jobs.First(x => x.Status == "On Site");
            MapView.SetView(new Location(currentJob.Customer.Latitude, currentJob.Customer.Longitude), 11);
        }

        /// <summary>
        /// Represents a method to create a new instance of a PushPin
        /// </summary>
        private Pushpin CreatePushpin(Job job, string mapPushPinTemplate)
        {
            //Create a new instance of Pushpin
            Pushpin pushpin = new Pushpin();
            pushpin.DataContext = job;

            //Set the location for the push pin
            MapLayer.SetPosition(pushpin, new Location(job.Customer.Latitude, job.Customer.Longitude));

            //Set the content template for the push pin
            var dataTemplate = Application.Current.Resources[mapPushPinTemplate];
            pushpin.Template = dataTemplate as ControlTemplate;

            //Setup the event handler for tapped event
            pushpin.Tapped += this.Pushpin_Tapped;

            return pushpin;
        }

        private void Pushpin_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Pushpin pushpin = sender as Pushpin;
            Job jobModel = null;
            if (pushpin != null)
            {
                jobModel = pushpin.DataContext as Job;
            }

            CapptainAgent.Instance.SendSessionEvent("Pushpin_Tapped", new Dictionary<object, object> { { "jobModelId", jobModel.Id } });

            if (jobModel == null)
            {
                return;
            }

            //Create an instance of the field engineer info controls to be shown within popup
            var userControl = new FieldEngineerInfoControl(jobModel);

            //Create a instance of the Flyout
            var tooltipPopup = new Windows.UI.Xaml.Controls.Flyout();
            tooltipPopup.Content = userControl;

            //Show the tooltip
            tooltipPopup.ShowAt(pushpin);
        }

        #endregion
    }
}
