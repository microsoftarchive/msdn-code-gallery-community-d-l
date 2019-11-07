using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Bing.Maps.HeatMaps
{
    /// <summary>
    /// http://blogs.msdn.com/b/wsdevsol/archive/2012/10/18/nine-things-you-need-to-know-about-webview.aspx
    /// </summary>
    public class HeatMapLayer : Grid, INotifyPropertyChanged
    {
        #region Private Properties

        private Uri pageUri = new Uri("ms-appx-web:///Bing.Maps.HeatMaps/Assets/HeatMap.html", UriKind.Absolute);

        private WebView _baseWebView;      
        
        private Map _map;
        private LocationCollection _locations;
        private GradientStopCollection _heatGradient;

        private int _viewChangeEndWaitTime = 100;

        private double _radius = 10000;
        private double _intensity = 0.5;
        private int _minRadius = 2;
        private bool _enableHardEdge;

        private bool _isLoaded, _isMoving, _skipStartEventOnce;
        private bool _zoomed, _panned;
        private Location _center = new Location(0,0);
        private double _zoom = 0;

        private DateTime _lastMovement;
        private Timer _updateTimer;

        private Image _img;

        #endregion

        #region Constructor

        public HeatMapLayer()
            : base()
        {
            this.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
            this.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Stretch;

            _baseWebView = new WebView()
            {
                Name = "BaseWebView",
                HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch,
                VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Stretch,
                DefaultBackgroundColor = Windows.UI.Colors.Transparent
            };

            _baseWebView.NavigationCompleted += (s,e) => {                
                _baseWebView.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                _isLoaded = true;
                LoadHeatMap();
                ResizeHeatMap();
                Render();
            };

            _baseWebView.ScriptNotify += _baseWebView_ScriptNotify;

            this.Children.Add(_baseWebView);

            _baseWebView.Navigate(pageUri);

            _img = new Image();
            this.Children.Add(_img);

            this.PropertyChanged += (s, e) => {
                switch (e.PropertyName)
                {
                    case "Radius":
                    case "Locations":
                        Render();
                        break;
                    case "EnableOptimizations":
                        AttachMapEvents();
                        Render();
                        break;
                    case "Maximum":
                    case "HeatGradient":
                    case "Background":
                    case "EnableHardEdge":
                        SetOptions();
                        break;
                    case "ParentMap":
                        AttachMapEvents();
                        break;
                }                
            };
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Heat gradient to use to render heat map.
        /// </summary>
        public GradientStopCollection HeatGradient
        {
            get { return _heatGradient; }
            set
            {
                _heatGradient = value;
                OnPropertyChanged("HeatGradient");
            }
        }

        /// <summary>
        /// Insenity of the heat map. A value between 0 and 1.
        /// </summary>
        public double Intensity
        {
            get { return _intensity; }
            set
            {
                _intensity = Math.Min(1,Math.Max(0,value));
                OnPropertyChanged("Maximum");
            }
        }
       
        /// <summary>
        /// Collection of locations to plot
        /// </summary>
        public LocationCollection Locations
        {
            get { return _locations; }
            set
            {
                _locations = value;
                OnPropertyChanged("Locations");
            }
        }

        /// <summary>
        /// Reference to Bing Maps control
        /// </summary>
        public Map ParentMap
        {
            get { return _map; }
            set
            {
                _map = value;
                OnPropertyChanged("ParentMap");
            }
        }

        /// <summary>
        /// Radius of data point in meters
        /// </summary>
        public double Radius
        {
            get { return _radius; }
            set
            {
                _radius = value;
                OnPropertyChanged("Radius");
            }
        }

        /// <summary>
        /// Gives all values the same opacity to create a hard edge on each data point. 
        /// When set to false (default) the data points will use a fading opacity towards the edges.
        /// </summary>
        public bool EnableHardEdge
        {
            get { return _enableHardEdge; }
            set
            {
                _enableHardEdge = value;
                OnPropertyChanged("EnableHardEdge");
            }
        }

        #endregion

        #region Private Methods

        #region Map Event Handlers

        private void DetachMapEvents()
        {
            _map.ViewChangeStarted -= _map_ViewChangeStarted;
            _map.ViewChangeEnded -= _map_ViewChangeEnded;
            _map.SizeChanged -= _map_SizeChanged;
        }

        private void AttachMapEvents()
        {
            this.Width = _map.ActualWidth;
            this.Height = _map.ActualHeight;

            //remove any old event handlers
            DetachMapEvents();

            //Add new map events
            _map.SizeChanged += _map_SizeChanged;
            _map.ViewChangeStarted += _map_ViewChangeStarted;
            _map.ViewChangeEnded += _map_ViewChangeEnded;

            if (_updateTimer != null)
            {
                _updateTimer.Dispose();
            }

            //Use a timer to throttle the updating due to moving the map
            _updateTimer = new Timer(async (s) =>
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Low, () =>
                {
                    if (_panned && _zoomed)
                    {
                        _skipStartEventOnce = true;
                    }

                    if ((_panned || _zoomed) && !_isMoving && (DateTime.Now - _lastMovement).Milliseconds < _viewChangeEndWaitTime)
                    {
                        //Update Heat Map
                        Render();

                        _panned = false;
                        _zoomed = false;
                    }
                    else if (!_panned && !_zoomed && !_isMoving)
                    {
                        _img.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    }
                });
            }, null, 0, 100);
        }

        private void _map_SizeChanged(object sender, Windows.UI.Xaml.SizeChangedEventArgs e)
        {
            this.Width = _map.ActualWidth;
            this.Height = _map.ActualHeight;
            ResizeHeatMap();
        }

        private void _map_ViewChangeEnded(object sender, ViewChangeEndedEventArgs e)
        {
            if (_zoom != _map.ZoomLevel)
            {
                _zoomed = true;
                _zoom = _map.ZoomLevel;
            }
            else
            {
                _zoomed = false;
            }

            if (_center.Latitude != _map.Center.Latitude || _center.Longitude != _map.Center.Longitude)
            {
                _panned = true;
                _center = _map.Center;
            }
            else
            {
                _panned = false;
            }

            _lastMovement = DateTime.Now;
            _isMoving = false;
        }

        private void _map_ViewChangeStarted(object sender, ViewChangeStartedEventArgs e)
        {
            //Stop any processing that might be going on
            InvokeJS("TerminateWorker", null);

            if (!_skipStartEventOnce)
            {
                //Clear Heat Map
                _img.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                _img.Source = null;
                _isMoving = true;
            }
            else
            {
                _skipStartEventOnce = false;
            }
        }

        #endregion

        private async void _baseWebView_ScriptNotify(object sender, NotifyEventArgs e)
        {
            var bmp = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
            var base64 = e.Value.Substring(e.Value.IndexOf(",") + 1);
            var imageBytes = Convert.FromBase64String(base64);
            using (var ms = new Windows.Storage.Streams.InMemoryRandomAccessStream())
            {
                using (var writer = new Windows.Storage.Streams.DataWriter(ms.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes(imageBytes);
                    await writer.StoreAsync();
                }

                bmp.SetSource(ms);
            }

            _img.Source = bmp;
            _img.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        #region Heat Map Methods

        private void LoadHeatMap()
        {
            InvokeJS("LoadHeatMap", new string[]{GenerateOptionJson()});
        }

        private void ResizeHeatMap()
        {
            InvokeJS("Resize", new string[] { this.Width + "", this.Height + "" });
        }

        private async void Render()
        {
            if (_isLoaded && _map != null)
            {
                StringBuilder sb = new StringBuilder();

                if (Locations != null)
                {
                    var px = new List<Windows.Foundation.Point>();
                    _map.TryLocationsToPixels(Locations, px);
                    foreach (var p in px)
                    {
                        sb.AppendFormat("{0},{1}|", Math.Round(p.X), Math.Round(p.Y));
                    }
                }

                if (sb.Length > 0)
                {
                    sb.Remove(sb.Length - 1, 1);
                }

                //Ground resolution at equator
                var groudResolution = (2 * Math.PI * 6378135) / Math.Round(256 * Math.Pow(2, _map.ZoomLevel));
                var radiusInPixels = _radius / groudResolution;

                if (radiusInPixels < _minRadius)
                {
                    radiusInPixels = _minRadius;
                }

                string[] args = { sb.ToString(), radiusInPixels.ToString(), _map.ZoomLevel.ToString() };

                await _baseWebView.InvokeScriptAsync("Render", args);
            }
        }

        private string GenerateOptionJson()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");

            if (_heatGradient != null && _heatGradient.Count > 0)
            {
                sb.Append("'colorgradient':{");
                foreach (var hg in _heatGradient)
                {
                    sb.AppendFormat("'{0}': 'rgba({1},{2},{3},{4})',", hg.Offset, hg.Color.R, hg.Color.G, hg.Color.B, hg.Color.A);
                }

                sb.Remove(sb.Length - 1, 1);

                sb.Append("},");
            }

            sb.AppendFormat("'enableHardEdge': {0},", (_enableHardEdge) ? "true" : "false");

            sb.AppendFormat("'intensity': {0}}}", _intensity);
            return sb.ToString();
        }

        private void SetOptions()
        {
            InvokeJS("SetOptions", new string[] { GenerateOptionJson(), "true" });
        }

        #endregion

        private async void InvokeJS(string methodName, string[] args)
        {
            if (_isLoaded)
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, async () =>
                {
                    await _baseWebView.InvokeScriptAsync(methodName, args);
                });
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
