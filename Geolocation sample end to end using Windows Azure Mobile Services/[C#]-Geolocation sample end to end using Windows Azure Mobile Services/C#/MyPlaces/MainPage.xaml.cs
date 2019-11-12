// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

namespace MyPlaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Bing.Maps;
    using MyPlaces.DataModel;
    using Windows.UI;
    using Windows.UI.Popups;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;

    public sealed partial class MainPage : Page
    {
        private MapShapeLayer shapeLayer;
        private Location myLocation;        

        public MainPage()
        {
            this.InitializeComponent();
            this.AddMyPlaceDialog.PlaceInserted += this.AddMyPlaceDialog_PlaceInserted;            
            this.LoadMap();
        }

        private async void AddMyPlaceDialog_PlaceInserted(object sender, EventArgs e)
        {
            await this.SpatialQueryFilter();
        }

        private async void LoadMap()
        {
            this.BingMap.RightTapped += this.BingMap_RightTapped;
            this.BingMap.Credentials = "{enter-your-bing-maps-key-here}";
            this.BingMap.MapType = Bing.Maps.MapType.Road;

            // Add shape layer to the map
            this.shapeLayer = new MapShapeLayer();
            this.BingMap.ShapeLayers.Add(this.shapeLayer);
            await this.RefreshMap();
            this.DrawBuffer();
        }

        private async Task SetMyLocation()
        {
            var position = await this.GetCurrentPosition();
            this.DataContext = position;
            this.myLocation = new Location(position.Latitude, position.Longitude);
            this.BingMap.Center = this.myLocation;
            this.AddMyLocationPushpin();
        }

        private void AddMyLocationPushpin()
        {
            var pushPin = new Pushpin()
            {
                Text = "!"
            };

            pushPin.Background = new SolidColorBrush(Colors.Red);
            pushPin.Tapped += this.PushPin_Tapped;
            pushPin.DataContext = new Place { Latitude = this.myLocation.Latitude, Longitude = this.myLocation.Longitude, Title = "My Location" };
            MapLayer.SetPosition(pushPin, this.myLocation);
            this.BingMap.Children.Add(pushPin);
        }

        private async Task<Position> GetCurrentPosition()
        {
            // TODO: Retrieve Current Position from Geolocator
            return new Position();
        }

        private void BingMap_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            Location current = null;

            try
            {
                this.BingMap.TryPixelToLocation(e.GetPosition(this.BingMap), out current);
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot translate location pixels to coordinates.", ex);
            }

            this.AddMyPlaceDialog.UpdateLocation(current.Latitude, current.Longitude);
            this.AddMyPlaceDialog.Show();
        }

        private async void PushPin_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var place = (Place)((Pushpin)sender).DataContext;
            var dialog = new MessageDialog(string.Format("{0} \n Latitude {0} - Longitude {1}", place.Description, place.Latitude, place.Longitude), place.Title);
            await dialog.ShowAsync();
        }

        private async Task RefreshMap()
        {
            this.BingMap.Children.Clear();
            await this.SetMyLocation();
            await this.SpatialQueryFilter();
        }

        private async Task SpatialQueryFilter()
        {
            // TODO: Retrieve all places around your current location
        }

        private void AddPushPins(List<Place> results)
        {
            foreach (var place in results)
            {
                var pushPin = new Pushpin()
                {
                    Text = "P"
                };

                pushPin.Background = new SolidColorBrush(Colors.Blue);
                pushPin.Tapped += this.PushPin_Tapped;
                pushPin.DataContext = place;
                MapLayer.SetPosition(pushPin, new Location(place.Latitude, place.Longitude));
                this.BingMap.Children.Add(pushPin);
            }
        }

        private void AddCircleRadius(double meters)
        {
            if (this.myLocation != null)
            {
                this.shapeLayer.Shapes.Clear();
                var circlePoints = new LocationCollection();

                var earthRadius = 6371;
                var lat = (this.myLocation.Latitude * Math.PI) / 180.0; // radians
                var lon = (this.myLocation.Longitude * Math.PI) / 180.0; // radians
                var d = meters / 1000 / earthRadius; // d = angular distance covered on earths surface

                for (int x = 0; x <= 360; x++)
                {
                    var brng = (x * Math.PI) / 180.0; // radians
                    var latRadians = Math.Asin((Math.Sin(lat) * Math.Cos(d)) + ((Math.Cos(lat) * Math.Sin(d)) * Math.Cos(brng)));
                    var lngRadians = lon + Math.Atan2((Math.Sin(brng) * Math.Sin(d)) * Math.Cos(lat), Math.Cos(d) - (Math.Sin(lat) * Math.Sin(latRadians)));

                    var pt = new Location(180.0 * latRadians / Math.PI, 180.0 * lngRadians / Math.PI);
                    circlePoints.Add(pt);
                }

                MapPolygon circlePolygon = new MapPolygon();
                circlePolygon.FillColor = Color.FromArgb(80, 20, 20, 200);
                circlePolygon.Locations = circlePoints;
                this.shapeLayer.Shapes.Add(circlePolygon);
            }
        }

        private async void Radius_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.Radius != null)
            {
                await this.RefreshMap();
                this.DrawBuffer();                
            }
        }

        private void DrawBuffer()
        {
            switch (this.Radius.SelectedIndex)
            {
                case 0:
                    this.BingMap.Center = this.myLocation;
                    this.BingMap.ZoomLevel = 15;
                    this.AddCircleRadius(1000);
                    break;
                case 1:
                    this.BingMap.Center = this.myLocation;
                    this.BingMap.ZoomLevel = 14;
                    this.AddCircleRadius(2000);
                    break;
                case 2:
                    this.BingMap.Center = this.myLocation;
                    this.BingMap.ZoomLevel = 12.7;
                    this.AddCircleRadius(5000);
                    break;
                case 3:
                    this.BingMap.Center = this.myLocation;
                    this.BingMap.ZoomLevel = 11.7;
                    this.AddCircleRadius(10000);
                    break;
            }
        }
    }
}
