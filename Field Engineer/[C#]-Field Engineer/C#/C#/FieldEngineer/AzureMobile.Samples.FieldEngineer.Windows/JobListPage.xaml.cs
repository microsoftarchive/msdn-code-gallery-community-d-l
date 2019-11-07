// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AzureMobile.Samples.FieldEngineer.Common;
using AzureMobile.Samples.FieldEngineer.DataModels;
using AzureMobile.Samples.FieldEngineer.DataSources;
using AzureMobile.Samples.FieldEngineer.Flyout;
using AzureMobile.Samples.FieldEngineer.Utilities;
using Capptain.Agent;
using Capptain.Overlay;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using Windows.Networking.PushNotifications;

// The Hub Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=286574

namespace AzureMobile.Samples.FieldEngineer
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class JobListPage : CapptainPage
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private ManagerDetailsFlyout managerFlyout;
        private List<Job> suggestionList;

        #region Constructor

        public JobListPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;

            // Register a handler for the Window Size Changed event
            Window.Current.SizeChanged += this.Window_SizeChanged;
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
            this.ProgressBar.Visibility = Visibility.Visible;

            if (ApplicationData.Current.LocalSettings.Values[Constants.Settings.StorageMode].ToString() == Constants.Offline)
            {
                if (ConnectionHelper.IsInternetConnectionAvailable())
                {
                    ApplicationData.Current.LocalSettings.Values[Constants.Settings.StorageMode] = Constants.Online;
                }
            }
            //Checking for internet connection in online mode. 
            //If not available then showing pop-up and switching to offline mode.
            else if (ApplicationData.Current.LocalSettings.Values[Constants.Settings.StorageMode].ToString() == Constants.Online)
            {
                if (!ConnectionHelper.IsInternetConnectionAvailable())
                {
                    await ShowSwitchingToOfflineDialog();
                }
            }
            await Utilities.LoginHelper.MobileServiceAuthenticate();
            if (!AzureDataServices.MobileServiceClient.SyncContext.IsInitialized)
            {
                if (ApplicationData.Current.LocalSettings.Values[Constants.Settings.LoggedInUserId] != null)
                {
                    await LocalStoreHelper.InitializeLocalStore(ApplicationData.Current.LocalSettings.Values[Constants.Settings.LoggedInUserId].ToString());
                }
                else
                {
                    await LocalStoreHelper.InitializeLocalStore("dummyUser");
                }
            }
            await Utilities.PushHelper.RegisterForPush();

            // Fetch the groups of Job Cards and assign them as the items source for the gridview displaying all Jobs
            App app = Application.Current as App;
            await DataManager.JobDataSource.GetAllJobs();
            if (AzureDataServices.RefreshJobsListPage)
            {
                await DataManager.JobDataSource.GetAllJobs(true);
                AzureDataServices.RefreshJobsListPage = false;
            }

            ObservableCollection<JobGroup> allGroups = new ObservableCollection<JobGroup>(await DataManager.JobDataSource.GetJobGroupsAsync());
            this.DefaultViewModel["PendingJobs"] = allGroups.Single(x => x.Title.Equals(Constants.PendingStatus)).Jobs;
            this.DefaultViewModel["PendingJobsCount"] = (this.DefaultViewModel["PendingJobs"] as List<Job>).Count;
            this.DefaultViewModel["CompletedJobs"] = allGroups.Single(x => x.Title.Equals(Constants.CompletedStatus)).Jobs;
            this.DefaultViewModel["CompletedJobsCount"] = (this.DefaultViewModel["CompletedJobs"] as List<Job>).Count;
            this.DefaultViewModel["CurrentJob"] = allGroups.Single(x => x.Title.Equals(Constants.CurrentStatus)).Jobs;
            this.DefaultViewModel["CurrentJobCount"] = (this.DefaultViewModel["CurrentJob"] as List<Job>).Count;
            this.DefaultViewModel["TotalJobsCount"] = allGroups.Sum(x => x.Jobs.Count);
            this.DefaultViewModel["CurrentUser"] = AzureDataServices.LoggedInUser;

            var zoomedOutItems = new List<Tuple<string, string>>
            {
                Tuple.Create("Quick Stats", string.Empty),
                Tuple.Create("In Progress",  this.DefaultViewModel["CurrentJobCount"].ToString()),
                Tuple.Create("Not Started", this.DefaultViewModel["PendingJobsCount"].ToString()),
                Tuple.Create("Completed", this.DefaultViewModel["CompletedJobsCount"].ToString())
            };
            this.DefaultViewModel["ZoomedOutItems"] = zoomedOutItems;

            this.ProgressBar.Visibility = Visibility.Collapsed;

            // Check the window size and update the Visual State
            this.UpdateVisualState(Window.Current.Bounds.Width);
        }

        /// <summary>
        /// This method handles the OnItemClick event of the ItemGridView control.
        /// On clicking on a Job card, the user is navigated to the details page for that job. 
        /// The Job ID is passed as a parameter.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemClickEventArgs"/> instance containing the event data.</param>
        private void ItemGridView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(JobDetailPage), (e.ClickedItem as Job).Id);
        }

        /// <summary>
        /// This methods handles contact button click of Quick Starts section. 
        /// This events bring the manager details settings flyout.
        /// </summary>
        private void ContactButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.managerFlyout = new ManagerDetailsFlyout();
            this.managerFlyout.ShowIndependent();

            CapptainAgent.Instance.SendEvent("\"Contact Manager\" button clicked");
        }

        /// <summary>
        /// Handles top navigation bar item click events. 
        /// Based on what clicked it, user will either be taken to job list page or map page.
        /// </summary>
        private void NavigationGridView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as Border;
            if (item == null)
            {
                return;
            }

            switch (item.Tag as string)
            {
                case "0":
                    TopAppBar.IsOpen = false;
                    break;
                case "1":
                    this.Frame.Navigate(typeof(JobMapPage));
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
            base.OnNavigatedTo(e);
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        #region Semantic Zoom

        /// <summary>
        /// This method is called after the Hub Control is loaded in order to create
        /// the data source for the zoomed out view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NormalHub_Loaded(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// This method is called on toggling between the Zoomed In/Out views.
        /// It helps to zoom to the correct section of the hub control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SemanticZoom_OnViewChangeStarted(object sender, SemanticZoomViewChangedEventArgs e)
        {
            //Only check for zoomed out view
            if (e.IsSourceZoomedInView == false)
            {
                //Get the index of the source item
                int index = ZoomedOutGrid.Items.IndexOf(e.SourceItem.Item);
                HubSection item = NormalHub.Sections[index];

                //Make the scroll destination to point selected hub section
                e.DestinationItem.Item = item;
            }
        }

        #endregion

        #region Search Box
        /// <summary>
        /// Populates SearchBox with Suggestions when user enters text
        /// </summary>
        /// <param name="sender">The Xaml SearchBox</param>
        /// <param name="args">Event when user changes text in SearchBox</param>
        private async void SearchBoxEventsSuggestionsRequested(SearchBox sender, SearchBoxSuggestionsRequestedEventArgs args)
        {
            string queryText = args.QueryText;
            if (string.IsNullOrEmpty(queryText))
            {
                return;
            }

            Windows.ApplicationModel.Search.SearchSuggestionCollection suggestionCollection = args.Request.SearchSuggestionCollection;
            if (this.suggestionList == null)
            {
                this.suggestionList = await DataManager.JobDataSource.GetAllJobs();
            }

            foreach (var suggestion in this.suggestionList)
            {
                if (suggestion.Title.ToUpper().Contains(queryText.ToUpper()))
                {
                    suggestionCollection.AppendQuerySuggestion(suggestion.Title);
                }

                if (suggestion.Id.Contains(queryText))
                {
                    suggestionCollection.AppendQuerySuggestion(suggestion.Id);
                }

                if (suggestion.Customer.FullName.ToUpper().Contains(queryText.ToUpper()))
                {
                    suggestionCollection.AppendQuerySuggestion(suggestion.Customer.FullName);
                }
            }
        }

        /// <summary>
        /// This method is called when query submitted in SearchBox
        /// </summary>
        /// <param name="sender">The Xaml SearchBox</param>
        /// <param name="args">Event when user submits query</param>
        private void SearchBoxEventsQuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            if (sender.ActualWidth == Convert.ToInt32(SearchUserControl.Tag))
            {
                // If just the button is visible, bring the complete textbox to visible
                VisualStateManager.GoToState(this, "NarrowLayout_SearchboxHeader", true);
                return;
            }
            else if (args.QueryText.Trim() == string.Empty)
            {
                // In the normal view, if submitted query is empty, dont proceed further.
                return;
            }

            var currentFrame = Window.Current.Content as Frame;
            currentFrame.Navigate(typeof(SearchResultsPage), args.QueryText.Trim());
        }

        private void SearchUserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchUserControl.Width == Convert.ToInt32(SearchUserControl.Tag))
            {
                // If just the button is visible, bring the complete textbox to visible
                VisualStateManager.GoToState(this, "NarrowLayout_SearchboxHeader", true);
                return;
            }
        }

        private void SearchUserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Window.Current.Bounds.Width < 780
                && SearchUserControl.ActualWidth > Convert.ToInt32(SearchUserControl.Tag))
            {
                // In narrow layout, when query submitted, and if it is empty, Hide the textboax and just show the search button
                VisualStateManager.GoToState(this, "NarrowLayout", true);
            }
        }

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.managerFlyout = new ManagerDetailsFlyout();
            this.managerFlyout.ShowIndependent();
        }

        private void PageRoot_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focus(FocusState.Programmatic);
        }

        private void RefreshJobs_Click(object sender, RoutedEventArgs e)
        {
            LocalStoreHelper.SyncAndRefreshUI();
        }

        private async void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginHelper.MobileServicesLogout();
            this.ClearUI();
            await LoginHelper.MobileServiceAuthenticate(true);
            this.ProgressBar.Visibility = Visibility.Visible;
            LocalStoreHelper.SyncAndRefreshUI();
        }

        private void ClearUI()
        {
            this.DefaultViewModel["PendingJobs"] = new List<Job>();
            this.DefaultViewModel["PendingJobsCount"] = string.Empty;
            this.DefaultViewModel["CompletedJobs"] = new List<Job>();
            this.DefaultViewModel["CompletedJobsCount"] = string.Empty;
            this.DefaultViewModel["CurrentJob"] = new List<Job>();
            this.DefaultViewModel["CurrentJobCount"] = string.Empty;
            this.DefaultViewModel["TotalJobsCount"] = string.Empty;
            this.DefaultViewModel["CurrentUser"] = string.Empty;
        }

        private async static Task ShowSwitchingToOfflineDialog()
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