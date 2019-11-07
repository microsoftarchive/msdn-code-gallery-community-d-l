using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Maps.MapControl.WPF;

namespace DrawRectangleOnMapWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDrawing = false;
        private Location center;
        private MapPolygon currentShape;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartDrawing(object sender, RoutedEventArgs e)
        {
            (sender as ToggleButton).Content = "Stop Drawing";

            //Capture the current center of the map. We will use this to lock the map view.
            center = MyMap.Center;

            //Add map events
            MyMap.MouseLeftButtonDown += MouseTouchStartHandler;
            MyMap.TouchDown += MouseTouchStartHandler;
            MyMap.MouseMove += MouseTouchMoveHandler;
            MyMap.TouchMove += MouseTouchMoveHandler;
            MyMap.MouseLeftButtonUp += MouseTouchEndHandler;
            MyMap.TouchUp += MouseTouchEndHandler;
            MyMap.ViewChangeOnFrame += MyMap_ViewChangeOnFrame;            
        }

        private void StopDrawing(object sender, RoutedEventArgs e)
        {
            (sender as ToggleButton).Content = "Start Drawing";

            //Remove map events
            MyMap.MouseLeftButtonDown -= MouseTouchStartHandler;
            MyMap.TouchDown += MouseTouchStartHandler;
            MyMap.MouseMove -= MouseTouchMoveHandler;
            MyMap.TouchMove -= MouseTouchMoveHandler;
            MyMap.MouseLeftButtonUp -= MouseTouchEndHandler;
            MyMap.TouchUp += MouseTouchEndHandler;
            MyMap.ViewChangeOnFrame -= MyMap_ViewChangeOnFrame;
        }

        private void MouseTouchStartHandler(object sender, object e)
        {
            //Optional: Remove any already drawn polygons.
            //MyMap.Children.Clear();

            Location startLoc = GetMouseTouchLocation(e);

            //Get the initial location where the user pressed the mouse down.
            if (startLoc != null)
            {

                //Create a polygon that has four corners, all of which are the starting location.
                currentShape = new MapPolygon()
                {
                    Locations = new LocationCollection()
                    {
                        startLoc,
                        startLoc,
                        startLoc,
                        startLoc
                    },
                    Fill = new SolidColorBrush(Colors.Transparent),
                    Stroke = new SolidColorBrush(Colors.Red),
                    StrokeThickness = 2
                };

                MyMap.Children.Add(currentShape);

                isDrawing = true;
            }
        }

        private void MyMap_ViewChangeOnFrame(object sender, Microsoft.Maps.MapControl.WPF.MapEventArgs e)
        {
            //If drawing keep reseting the center to the original center value when we entered drawing mode. 
            //This will disable panning of the map when we click and drag. 
            MyMap.Center = center;

            //Optional: Disable rotation of map, useful when using touch.
            MyMap.Heading = 0;
        }

        private void MouseTouchMoveHandler(object sender, object e)
        {          
            if (isDrawing)
            {
                Location currentLoc = GetMouseTouchLocation(e);

                //Get the location where muse is.
                if (currentLoc != null)
                {
                    var firstLoc = currentShape.Locations[0];

                    //Update locations 1 - 3 of polygon so as to create a rectangle.
                    currentShape.Locations[1] = new Location(firstLoc.Latitude, currentLoc.Longitude);
                    currentShape.Locations[2] = currentLoc;
                    currentShape.Locations[3] = new Location(currentLoc.Latitude, firstLoc.Longitude);
                }
            }
        }

        private void MouseTouchEndHandler(object sender, object e)
        {
            //Update drawing flag so that polygon isn't updated when mouse is moved.
            isDrawing = false;

            //The rectangle is drawn, grab it's locations and do something with them.
        }

        private Location GetMouseTouchLocation(object e)
        {
            Location loc = null;

            if (e is MouseEventArgs)
            {
                MyMap.TryViewportPointToLocation((e as MouseEventArgs).GetPosition(MyMap), out loc);
            }
            else if (e is TouchEventArgs)
            {
                MyMap.TryViewportPointToLocation((e as TouchEventArgs).GetTouchPoint(MyMap).Position, out loc);
            }

            return loc;
        }

    }
}
