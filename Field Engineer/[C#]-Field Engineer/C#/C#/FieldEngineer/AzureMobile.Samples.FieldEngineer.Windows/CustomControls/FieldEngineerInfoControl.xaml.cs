// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using AzureMobile.Samples.FieldEngineer.DataModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace AzureMobile.Samples.FieldEngineer.CustomControls
{
    public sealed partial class FieldEngineerInfoControl : UserControl
    {
        public FieldEngineerInfoControl(Job job)
        {
            this.InitializeComponent();
            this.DataContext = job;
        }

        /// <summary>
        /// Navigate to Job Details page on clicking on the popup
        /// </summary>
        private void JobDetails_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            //Close the Flyout Popup
            var flyoutPresenter = this.Parent as FlyoutPresenter;
            var popup = flyoutPresenter.Parent as Popup;
            popup.IsOpen = false;

            //Navigate to the Job Detail Page
            var currentFrame = Window.Current.Content as Frame;
            currentFrame.Navigate(typeof(JobDetailPage), (this.DataContext as Job).Id);
        }
    }
}
