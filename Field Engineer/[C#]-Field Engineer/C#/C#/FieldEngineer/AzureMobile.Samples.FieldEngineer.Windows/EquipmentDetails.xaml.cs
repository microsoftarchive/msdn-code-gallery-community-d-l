// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using AzureMobile.Samples.FieldEngineer.Common;
using AzureMobile.Samples.FieldEngineer.DataSources;
using AzureMobile.Samples.FieldEngineer.Utilities;
using Capptain.Agent;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Hub Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=286574

namespace AzureMobile.Samples.FieldEngineer
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class EquipmentDetails : CapptainPage
    {
        #region Properties & Variables

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        #endregion

        #region Constructor

        public EquipmentDetails()
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

                        return;
                    }
                }
            }
            //Get the details for selected equipment
            var selectedEquipment = await DataManager.EquipmentDataSource.GetDetailsAsync(e.NavigationParameter.ToString());

            //Get the Equipment Specification for the selected equipment
            if (selectedEquipment.EquipmentSpecifications == null)
            {
                var equipmentSpecification = await DataManager.EquipmentSpecificationDataSource.GetDetailsAsync(e.NavigationParameter.ToString());

                selectedEquipment.EquipmentSpecifications = equipmentSpecification;
            }

            //Place necessary elemnts on DefaultViewModel.
            this.defaultViewModel["EquipmentDetail"] = selectedEquipment;
            this.defaultViewModel["EquipmentName"] = selectedEquipment.Name;

            // Check the window size and update the Visual State
            this.UpdateVisualState(Window.Current.Bounds.Width);
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

        #region Top App Bar Events

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

        #endregion
    }
}
