using Microsoft.Maps.MapControl.WPF;
using System.Windows;

namespace LocalTileLayer.WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MyMap.Loaded += MyMap_Loaded;
        }

        private void MyMap_Loaded(object sender, RoutedEventArgs e)
        {
            var tileLayer = new MapTileLayer()
            {
                TileSource = new LocalTileSource(@"SouthEndUniversityHospital\{quadkey}.png")
            };
            MyMap.Children.Add(tileLayer);
        }
    }
}
