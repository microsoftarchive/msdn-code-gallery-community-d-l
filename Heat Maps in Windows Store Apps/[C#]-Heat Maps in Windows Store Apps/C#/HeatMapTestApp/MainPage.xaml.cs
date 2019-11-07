using Bing.Maps;
using Bing.Maps.HeatMaps;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace HeatMapTestApp
{
    public sealed partial class MainPage : Page
    {
        #region Private Properties

        private HeatMapLayer layer;
        private LocationCollection testData;

        #endregion

        #region Constructor

        public MainPage()
        {
            this.InitializeComponent();

            this.Loaded += (s, e) =>
            {
                testData = new LocationCollection();

                layer = new HeatMapLayer()
                {
                    ParentMap = MyMap,
                    Locations = GetTestData(500),
                    Radius = 250000
                };

                MyMap.Children.Add(layer);
            };
        }

        #endregion

        #region Event Handlers

        private void TestDataSize_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (layer != null)
            {
                var cbx = sender as ComboBox;
                var item = cbx.SelectedItem as ComboBoxItem;
                layer.Locations = GetTestData(int.Parse(item.Content as string));
            }
        }

        private void Radius_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (layer != null)
            {
                var cbx = sender as ComboBox;
                var rKM = int.Parse((cbx.SelectedItem as ComboBoxItem).Content as string);
                layer.Radius = rKM * 1000;
            }
        }

        private void Opacity_Changed(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            if (layer != null)
            {
                var slider = sender as Slider;
                layer.Opacity = slider.Value;
            }
        }

        private void Intensity_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (layer != null)
            {
                var cbx = sender as ComboBox;

                layer.Intensity = double.Parse((cbx.SelectedItem as ComboBoxItem).Content as string);
            }
        }

        private void Gradient_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (layer != null)
            {
                var cbx = sender as ComboBox;
                var item = cbx.SelectedItem as ComboBoxItem;

                var bg = item.Background as LinearGradientBrush;
                layer.HeatGradient = bg.GradientStops;
            }
        }

        private void HardEdge_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            if (layer != null)
            {
                var cbx = sender as CheckBox;
                layer.EnableHardEdge = cbx.IsChecked.Value;
            }
        }

        private void Background_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (layer != null)
            {
                var cbx = sender as ComboBox;
                var item = cbx.SelectedItem as ComboBoxItem;
                layer.Background = item.Background;
            }
        }

        #endregion

        #region Private Methods

        private LocationCollection GetTestData(int size)
        {
            if (size <= testData.Count)
            {
                var locs = new LocationCollection();

                for (int i = 0; i < size; i++)
                {
                    locs.Add(testData[i]);
                }

                return locs;
            }
            else
            {
                var cnt = size - testData.Count;
                var rand = new Random();

                for (int i = 0; i < cnt; i++)
                {
                    testData.Add(new Location()
                    {
                        Latitude = rand.NextDouble() * 170 - 85,
                        Longitude = rand.NextDouble() * 360 - 180
                    });
                }

                return testData;
            }
        }

        #endregion
    }
}
