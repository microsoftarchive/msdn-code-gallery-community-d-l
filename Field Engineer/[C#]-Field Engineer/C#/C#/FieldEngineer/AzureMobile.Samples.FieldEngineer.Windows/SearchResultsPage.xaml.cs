// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;﻿
using AzureMobile.Samples.FieldEngineer.DataModels;
using AzureMobile.Samples.FieldEngineer.DataSources;
using AzureMobile.Samples.FieldEngineer.Common;
using AzureMobile.Samples.FieldEngineer.Utilities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AzureMobile.Samples.FieldEngineer
{
    /// <summary>
    /// This page displays search results when a global search is directed to this application.
    /// </summary>
    public sealed partial class SearchResultsPage
    {
        #region Properties & Variables

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private List<Job> searchResults;

        #endregion

        #region Constructor

        public SearchResultsPage()
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

        #region Events

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
            //Set the query text
            var queryText = e.NavigationParameter as String;
            this.DefaultViewModel["QueryText"] = " " + '\u201c' + queryText + '\u201d';

            // Fetch the search results from ProductDataSource
            this.searchResults = await DataManager.JobDataSource.SearchJobsBySearchTextAsync(queryText);

            // Check if any search results are found, else show the no result found message 
            if (this.searchResults == null || this.searchResults.Count == 0)
            {
                VisualStateManager.GoToState(this, "NoResultsFound", true);
                return;
            }

            // Add the default filter as "All"
            var filterList = new List<Filter>();
            filterList.Add(new Filter("All", this.searchResults.Count, true));

            // Add the counts for various job status
            int countOnSite = this.searchResults.Count(item => item.Status == "On Site");
            int countNotStarted = this.searchResults.Count(item => item.Status == "Not Started");
            int countCompleted = this.searchResults.Count(item => item.Status == "Completed");

            // Add the filters based upon the job status
            if (countOnSite > 0)
            {
                filterList.Add(new Filter("On Site", countOnSite, false));
            }

            if (countNotStarted > 0)
            {
                filterList.Add(new Filter("Not Started", countNotStarted, false));
            }

            if (countCompleted > 0)
            {
                filterList.Add(new Filter("Completed", countCompleted, false));
            }

            // Communicate results through the view model
            this.DefaultViewModel["Filters"] = filterList;
            this.DefaultViewModel["ShowFilters"] = filterList.Count > 0;
            this.DefaultViewModel["Results"] = this.searchResults;

            // Check the window size and update the Visual State
            this.UpdateVisualState(Window.Current.Bounds.Width);
        }

        /// <summary>
        /// Invoked when a filter is selected using a RadioButton when not snapped.
        /// </summary>
        /// <param name="sender">The selected RadioButton instance.</param>
        /// <param name="e">Event data describing how the RadioButton was selected.</param>
        private void Filter_Checked(object sender, RoutedEventArgs e)
        {
            var filter = (sender as FrameworkElement).DataContext;

            // Mirror the change into the CollectionViewSource.
            if (filtersViewSource.View != null)
            {
                filtersViewSource.View.MoveCurrentTo(filter);
            }

            // Determine what filter was selected
            var selectedFilter = filter as Filter;
            if (selectedFilter != null)
            {
                // Mirror the results into the corresponding Filter object to allow the
                // RadioButton representation used when not snapped to reflect the change
                selectedFilter.Active = true;

                //Check for All filter
                if (selectedFilter.Name == "All")
                {
                    this.DefaultViewModel["Results"] = this.searchResults;
                    return;
                }

                //Set the filtered results
                this.DefaultViewModel["Results"] = this.searchResults.Where(item => item.Status == selectedFilter.Name).ToList();
            }
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
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);

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

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        #region Feature - Snapped View

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
            if (width < 950)
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

        /// <summary>
        /// View model describing one of the filters available for viewing search results.
        /// </summary>
        private sealed class Filter : INotifyPropertyChanged
        {
            private String name;
            private int count;
            private bool active;

            public Filter(String name, int count, bool active = false)
            {
                this.Name = name;
                this.Count = count;
                this.Active = active;
            }

            /// <summary>
            /// Multicast event for property change notifications.
            /// </summary>
            public event PropertyChangedEventHandler PropertyChanged;

            public String Name
            {
                get { return this.name; }
                set
                {
                    if (this.SetProperty(ref this.name, value))
                    {
                        this.OnPropertyChanged("Name");
                    }
                }
            }

            public int Count
            {
                get { return this.count; }
                set
                {
                    if (this.SetProperty(ref this.count, value))
                    {
                        this.OnPropertyChanged("Count");
                    }
                }
            }

            public bool Active
            {
                get { return this.active; }
                set { this.SetProperty(ref this.active, value); }
            }

            public String Description
            {
                get { return String.Format("{0} ({1})", this.name, this.count); }
            }

            public override String ToString()
            {
                return this.Description;
            }

            /// <summary>
            /// Checks if a property already matches a desired value.  Sets the property and
            /// notifies listeners only when necessary.
            /// </summary>
            /// <typeparam name="T">Type of the property.</typeparam>
            /// <param name="storage">Reference to a property with both getter and setter.</param>
            /// <param name="value">Desired value for the property.</param>
            /// <param name="propertyName">Name of the property used to notify listeners.  This
            /// value is optional and can be provided automatically when invoked from compilers that
            /// support CallerMemberName.</param>
            /// <returns>True if the value was changed, false if the existing value matched the
            /// desired value.</returns>
            private bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
            {
                if (object.Equals(storage, value))
                {
                    return false;
                }

                storage = value;
                this.OnPropertyChanged(propertyName);
                return true;
            }

            /// <summary>
            /// Notifies listeners that a property value has changed.
            /// </summary>
            /// <param name="propertyName">Name of the property used to notify listeners.  This
            /// value is optional and can be provided automatically when invoked from compilers
            /// that support <see cref="CallerMemberNameAttribute"/>.</param>
            private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                var eventHandler = this.PropertyChanged;
                if (eventHandler != null)
                {
                    eventHandler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
}
