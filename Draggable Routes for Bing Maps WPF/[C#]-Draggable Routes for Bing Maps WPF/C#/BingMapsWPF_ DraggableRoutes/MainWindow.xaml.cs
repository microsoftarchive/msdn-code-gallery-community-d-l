using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BingMapsWPF__DraggableRoutes
{
    public partial class MainWindow : Window
    {
        private DragPin StartPin;
        private DragPin EndPin;
        private MapLayer RouteLayer;
        private string SessionKey;

        public MainWindow()
        {
            InitializeComponent();

            MyMap.Loaded += MyMap_Loaded;
        }

        private void MyMap_Loaded(object sender, RoutedEventArgs e)
        {
            //Get a session key from the Bing Maps WPF control.
            MyMap.CredentialsProvider.GetCredentials((c) =>
            {
                SessionKey = c.ApplicationId;

                //Create a layer for Route data.
                RouteLayer = new MapLayer();
                MyMap.Children.Add(RouteLayer);

                //Create two draggable pushpins to between.

                //Create the start pushpin.
                StartPin = new DragPin(this.MyMap)
                {
                    Location = new Location(47.614898, -122.193604),
                    ImageSource = GetImageSource("/Assets/green_pin.png")
                };
                
                //Add a drag event to the start pushpin.
                StartPin.DragEnd += UpdateRoute;

                //Add the start pushpin to the map.
                MyMap.Children.Add(StartPin);
                
                //Create the end pushpin.
                EndPin = new DragPin(this.MyMap)
                {
                    Location = new Location(47.619819, -122.348862),
                    ImageSource = GetImageSource("/Assets/red_pin.png")
                };

                //Add a drag event to the end pushpin.
                EndPin.DragEnd += UpdateRoute;

                //Add the end pushpin to the map.
                MyMap.Children.Add(EndPin);

                //Calculate the initial route between the two pins.
                UpdateRoute(null);
            });
        }

        private async void UpdateRoute(Location loc)
        {
            RouteLayer.Children.Clear();

            var startCoord = LocationToCoordinate(StartPin.Location);
            var endCoord = LocationToCoordinate(EndPin.Location);

            //Calculate a route between the start and end pushpin.
            var response = await BingMapsRESTToolkit.ServiceManager.GetResponseAsync(new BingMapsRESTToolkit.RouteRequest()
            {
                Waypoints = new List<BingMapsRESTToolkit.SimpleWaypoint>()
                {
                    new BingMapsRESTToolkit.SimpleWaypoint(startCoord),
                    new BingMapsRESTToolkit.SimpleWaypoint(endCoord)
                },
                BingMapsKey = SessionKey,
                RouteOptions = new BingMapsRESTToolkit.RouteOptions()
                {
                    RouteAttributes = new List<BingMapsRESTToolkit.RouteAttributeType>
                    {
                        //Be sure to return the route path information so that we can draw the route line.
                        BingMapsRESTToolkit.RouteAttributeType.RoutePath
                    }
                }
            });

            if (response != null && 
                response.ResourceSets != null && 
                response.ResourceSets.Length > 0 && 
                response.ResourceSets[0].Resources != null &&
                response.ResourceSets[0].Resources.Length > 0)
            {
                var route = response.ResourceSets[0].Resources[0] as BingMapsRESTToolkit.Route;

                //Generate a Polyline from the route path information.
                var locs = new LocationCollection();

                for(var i=0;i< route.RoutePath.Line.Coordinates.Length; i++)
                {
                    locs.Add(new Location(route.RoutePath.Line.Coordinates[i][0], route.RoutePath.Line.Coordinates[i][1]));
                }

                var routeLine = new MapPolyline()
                {
                    Locations = locs,
                    Stroke = new SolidColorBrush(Colors.Blue),
                    StrokeThickness = 3
                };

                RouteLayer.Children.Add(routeLine);
            }
        }

        private BingMapsRESTToolkit.Coordinate LocationToCoordinate(Location loc)
        {
            return new BingMapsRESTToolkit.Coordinate(loc.Latitude, loc.Longitude);
        }

        private BitmapImage GetImageSource(string imageSource)
        {
            var icon = new BitmapImage();
            icon.BeginInit();
            icon.UriSource = new Uri(imageSource, UriKind.Relative);
            icon.EndInit();
                        
            return icon;
        }
    }
}
