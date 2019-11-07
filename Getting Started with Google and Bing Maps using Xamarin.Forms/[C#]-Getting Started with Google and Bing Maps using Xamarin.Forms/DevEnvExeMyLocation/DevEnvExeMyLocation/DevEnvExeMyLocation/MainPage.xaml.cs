using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace DevEnvExeMyLocation
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MyMap.MoveToRegion(
    MapSpan.FromCenterAndRadius(
        new Position(37, -122), Distance.FromMiles(1)));
        }
    }
}
