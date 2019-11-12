// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AzureMobile.Samples.FieldEngineer.Common;
using AzureMobile.Samples.FieldEngineer.DataModels;
using AzureMobile.Samples.FieldEngineer.DataSources;
using AzureMobile.Samples.FieldEngineer.Utilities;
using Capptain.Agent;
using Windows.Foundation;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace AzureMobile.Samples.FieldEngineer
{
    /// <summary>
    /// Represents a class for the Job Details Page. 
    /// This page is the default page for the application and displays a list 
    /// of job cards grouped by job status i.e. Current, Pending, Completed.
    /// </summary>
    public sealed partial class JobDetailPage : CapptainPage
    {
        #region Properties & Variables

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private Job job;

        #endregion

        #region Constructor

        public JobDetailPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;

            // Register a handler for the Window Size Changed event
            Window.Current.SizeChanged += this.Window_SizeChanged;
        }

        #endregion

        /// <summary>
        /// Represents the NavigationHelper instance for the page. It is used on 
        /// each page to aid in navigation and process lifetime management.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Represents the default View Model for the page. It is used for binding 
        /// data to XAML view and can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        #region Events

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
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
                    }
                }
            }

            this.ProgressBar.Visibility = Visibility.Visible;

            // Fetch the job object
            this.job = await DataManager.JobDataSource.GetDetailsAsync(e.NavigationParameter.ToString());

            //Check if the ob is already completed
            if (this.job.Status == Constants.CompletedStatus)
            {
                //Remove the SubmitJob Appbar Button
                CompleteJob.Visibility = Visibility.Collapsed;
            }

            // Assign the values to be bound to the various controls
            this.DefaultViewModel["JobStockItems"] = this.job.Equipments;
            this.DefaultViewModel["JobHistory"] = this.job.JobHistories;
            this.DefaultViewModel["JobSummaryItems"] = new ObservableCollection<Job>(new List<Job> { this.job });
            this.DefaultViewModel["Job"] = this.job;

            this.ProgressBar.Visibility = Visibility.Collapsed;

            // Check the window size and update the Visual State
            this.UpdateVisualState(Window.Current.Bounds.Width);
        }

        /// <summary>
        /// Invoked when an item within a section is clicked.
        /// </summary>
        /// <param name="sender">The GridView or ListView
        /// displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            var itemId = ((Equipment)e.ClickedItem).Id;
            this.Frame.Navigate(typeof(EquipmentDetails), itemId);
        }

        private async void CompleteJob_Click(object sender, RoutedEventArgs e)
        {
            if (this.job.Status.Equals(Constants.CompletedStatus))
            {
                var message = new MessageDialog("This job is already completed", "Field Engineer");
                await message.ShowAsync();
            }
        }

        /// <summary>
        /// Handles the back button click event. Takes the user to main job list page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
            else
            {
                this.Frame.Navigate(typeof(JobListPage), null);
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
            base.OnNavigatedTo(e);
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        #region Feature - Windowing Modes
        /// <summary>
        /// Represents the event handler for the window size changed event.
        /// This event is raised whenever the window is resized and helps 
        /// handle any changes to visual state of the page. 
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically the current window.
        /// </param>
        /// <param name="e">
        /// Event data that provides the changed size for the Window.
        /// </param>
        private void Window_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            // Check the window size and update the Visual State
            this.UpdateVisualState(e.Size.Width);
        }

        /// <summary>
        /// Check the window width and update the Visual State
        /// </summary>
        /// <param name="width">Width of current window</param>
        private void UpdateVisualState(double width)
        {
            if (width < 780)
            {
                VisualStateManager.GoToState(this, "NarrowLayout", true);
            }
            else
            {
                VisualStateManager.GoToState(this, "PrimaryLayout", true);
            }
        }

        #endregion

        private void NavigationGridView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as Border;
            if (item == null)
            {
                return;
            }

            switch (item.Tag as string)
            {
                case "3":
                    this.Frame.Navigate(typeof(JobListPage));
                    this.Frame.BackStack.Clear();
                    break;
            }
        }

        private void ShareJob_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
