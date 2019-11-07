// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

namespace MyPlaces
{
    using System;
    using System.Threading.Tasks;
    using MyPlaces.DataModel;    
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class AddMyPlace : UserControl
    {
        private double latitude;
        private double longitude;     

        public AddMyPlace()
        {
            this.InitializeComponent();
        }

        public event EventHandler PlaceInserted;

        public void UpdateLocation(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.LatitudeText.Text = latitude.ToString();
            this.LongitudeText.Text = longitude.ToString();
        }

        public void Show()
        {
            this.TitleText.Text = string.Empty;
            this.DescriptionText.Text = string.Empty;
            this.TitleText.Focus(Windows.UI.Xaml.FocusState.Keyboard);
            this.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private async void OnAddClick(object sender, RoutedEventArgs e)
        {
            this.TitleText.IsEnabled = false;
            this.DescriptionText.IsEnabled = false;
            this.AddButton.IsEnabled = false;

            // Insert the place into a Windows Azure Mobile Services table
            await this.InsertPlace();

            this.TitleText.IsEnabled = true;
            this.DescriptionText.IsEnabled = true;
            this.AddButton.IsEnabled = true;
            this.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            if (this.PlaceInserted != null)
            {
                this.PlaceInserted(this, null);
            }
        }

        private async Task InsertPlace()
        {
            // TODO: Insert a new Place into Mobile Services
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
    }
}
