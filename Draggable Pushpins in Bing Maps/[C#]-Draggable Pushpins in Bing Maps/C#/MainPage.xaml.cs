using Windows.UI.Xaml.Controls;

namespace DraggablePushpin
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            MyMap.Loaded += MyMap_Loaded;
        }

        private void MyMap_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            DraggablePin pin = new DraggablePin(MyMap);

            //Set the location of the pin to the center of the map.
            Bing.Maps.MapLayer.SetPosition(pin, MyMap.Center);

            //Set the pin as draggable.
            pin.Draggable = true;

            //Attach to the drag event of the pin.
            pin.Drag += Pin_Dragged;

            //Add the pin to the map.
            MyMap.Children.Add(pin);
        }

        private void Pin_Dragged(Bing.Maps.Location location)
        {
            CoordinatesTbx.Text = string.Format("{0:N5},{1:N5}", location.Latitude, location.Longitude);
        }
    }
}
