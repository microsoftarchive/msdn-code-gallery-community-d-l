using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace IdentityMine.Avalon.Controls
{
    public class Chart : ItemsControl
    {
        private System.Windows.Threading.DispatcherTimer uiTimer;
        private Canvas _chartHost;
        private SeriesDataItems _seriesDataItems;
        private List<double> _chartPoints;
        private Canvas _chartCanvas;
        private Path chartSeriesPath;
        private Path chartShadowPath;
        private Path chartFillPath;
        private DoubleAnimation chartAnimation;
        private AnimationClock _chartClock;
        private TimeSpan _updateInterval;
        private double shadowOffsetX = 0.0;
        private double shadowOffsetY = 10.0;
        private double timerFrame = 0.0;
        private const double timerMaxLocation = 5.0;
        // private const double timerFrameRate = 125.0; // 1000 / 100 = 10 fps
        private const double timerFrameRate = 20.0; // 1000 / 200 = 5 fps
        //private const double timerFrameRate = 150.0; // 1000 / 150 = 6.66667 fps


        static Chart()
        {
            //This OverrideMetadata call tells the system that this element wants to provide a style that is different than its base class.
            //This style is defined in themes\generic.xaml
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Chart), new FrameworkPropertyMetadata(typeof(Chart)));
        }

        public Chart()
        {
            this.ApplyTemplate();

            ((INotifyCollectionChanged)this.Items).CollectionChanged += new NotifyCollectionChangedEventHandler(OnItemsCollectionChanged);
            this.Initialized += new EventHandler(OnInitialized);
            this.Loaded += new RoutedEventHandler(OnLoaded);
        }

        #region Component resources
        public static ComponentResourceKey DefaultGridBrush = new ComponentResourceKey(typeof(Chart), "DefaultGridBrush");
        public static ComponentResourceKey DefaultGridStyle = new ComponentResourceKey(typeof(Chart), "DefaultGridStyle");
        public static ComponentResourceKey DefaultSeriesBrush = new ComponentResourceKey(typeof(Chart), "DefaultSeriesBrush");
        public static ComponentResourceKey DefaultSeriesStyle = new ComponentResourceKey(typeof(Chart), "DefaultSeriesStyle");
        public static ComponentResourceKey DefaultShadowBrush = new ComponentResourceKey(typeof(Chart), "DefaultShadowBrush");
        public static ComponentResourceKey DefaultShadowStyle = new ComponentResourceKey(typeof(Chart), "DefaultShadowStyle");
        public static ComponentResourceKey DefaultFillBrush = new ComponentResourceKey(typeof(Chart), "DefaultFillBrush");
        public static ComponentResourceKey DefaultFillStyle = new ComponentResourceKey(typeof(Chart), "DefaultFillStyle");
        #endregion

        #region Event Handlers

        public delegate void UpdateIntervalEndedEventHandler(object sender, EventArgs e);

        public event UpdateIntervalEndedEventHandler UpdateIntervalEnded;
        protected virtual void OnUpdateIntervalEnded(object o, EventArgs e)
        {
            if (UpdateIntervalEnded != null)
                UpdateIntervalEnded(o, e);
        }

        #endregion Event Handlers

        #region Points property
        public static readonly DependencyProperty PointsProperty = DependencyProperty.Register("Points",
            typeof(int), typeof(Chart), new PropertyMetadata(40));

        public int Points
        {
            get { return (int)GetValue(PointsProperty); }
            set { SetValue(PointsProperty, value); }
        }
        #endregion

        #region GridStyle property
        public static readonly DependencyProperty GridStyleProperty = DependencyProperty.Register("GridStyle",
            typeof(Style), typeof(Chart), new PropertyMetadata(new Style(typeof(Canvas))));

        public Style GridStyle
        {
            get { return (Style)GetValue(GridStyleProperty); }
            set { SetValue(GridStyleProperty, value); }
        }
        #endregion

        #region SeriesStyle property
        public static readonly DependencyProperty SeriesStyleProperty = DependencyProperty.Register("SeriesStyle",
            typeof(Style), typeof(Chart), new PropertyMetadata(new Style(typeof(Path))));

        public Style SeriesStyle
        {
            get { return (Style)GetValue(SeriesStyleProperty); }
            set { SetValue(SeriesStyleProperty, value); }
        }
        #endregion

        #region ShadowStyle property
        public static readonly DependencyProperty ShadowStyleProperty = DependencyProperty.Register("ShadowStyle",
            typeof(Style), typeof(Chart), new PropertyMetadata(new Style(typeof(Path))));

        public Style ShadowStyle
        {
            get { return (Style)GetValue(ShadowStyleProperty); }
            set { SetValue(ShadowStyleProperty, value); }
        }
        #endregion

        #region FillStyle property
        public static readonly DependencyProperty FillStyleProperty = DependencyProperty.Register("FillStyle",
            typeof(Style), typeof(Chart), new PropertyMetadata(new Style(typeof(Path))));

        public Style FillStyle
        {
            get { return (Style)GetValue(FillStyleProperty); }
            set { SetValue(FillStyleProperty, value); }
        }
        #endregion

        #region SeriesBrush property
        public static readonly DependencyProperty SeriesBrushProperty = DependencyProperty.Register("SeriesBrush",
            typeof(Brush), typeof(Chart), new PropertyMetadata());

        public Brush SeriesBrush
        {
            get { return (Brush)GetValue(SeriesBrushProperty); }
            set { SetValue(SeriesBrushProperty, value); }
        }
        #endregion

        #region ShadowBrush property
        public static readonly DependencyProperty ShadowBrushProperty = DependencyProperty.Register("ShadowBrush",
            typeof(Brush), typeof(Chart), new PropertyMetadata());

        public Brush ShadowBrush
        {
            get { return (Brush)GetValue(ShadowBrushProperty); }
            set { SetValue(ShadowBrushProperty, value); }
        }
        #endregion

        #region IsChartHost attached property
        //public static readonly DependencyProperty IsChartHostProperty = DependencyProperty.RegisterAttached("IsChartHost",  typeof(bool), typeof(Chart), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(IsChartHostInvalidated)));
        public static readonly DependencyProperty IsChartHostProperty = 
            DependencyProperty.RegisterAttached("IsChartHost", typeof(bool), typeof(Chart), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(IsChartHostInvalidated), new CoerceValueCallback(IsChartHostCoerced)));

        public static bool GetIsChartHost(DependencyObject d)
        {
            return (bool)(d.GetValue(Chart.IsChartHostProperty));
        }

        public static void SetIsChartHost(DependencyObject d, bool value)
        {
            d.SetValue(Chart.IsChartHostProperty, value);
        }

        private Canvas ChartHost
        {
            get
            {
                if (this._chartHost == null)
                {
                    throw new InvalidOperationException("The visual tree of a ChartControl should have a Canvas with the attached property IsChartCanvas set to true");
                }
                return this._chartHost;
            }
        }

        private static object IsChartHostCoerced(DependencyObject target, object value)
        {
            return value;
        }

        private static void IsChartHostInvalidated(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            Canvas chart = target as Canvas;
            if ((chart != null) && Chart.GetIsChartHost(chart))
            {
                Chart parent = chart.TemplatedParent as Chart;
                if (parent != null)
                {
                    parent._chartHost = chart;
                    parent.CreateChart();
                }
            }

        }
        #endregion

        #region UpdateInterval property
        public static readonly DependencyProperty UpdateIntervalProperty = DependencyProperty.Register("UpdateInterval",
            typeof(double), typeof(Chart), new PropertyMetadata(1000.0));

        public double UpdateInterval
        {
            get { return (double)GetValue(UpdateIntervalProperty); }
            set { SetValue(UpdateIntervalProperty, value); }
        }
        #endregion

        #region Initialization
        private void OnInitialized(object sender, EventArgs e)
        {
            _updateInterval = TimeSpan.FromMilliseconds(this.UpdateInterval);

            //init the items collection
            _seriesDataItems = new SeriesDataItems();

            // initialize chart points buffer
            _chartPoints = new List<double>(this.Points + 2);

            // are there items provided inline
            if (this.ItemsSource == null && this.Items.Count > 0)
            {
                foreach (object item in this.Items)
                {
                    if (item.GetType() == typeof(SeriesDataItem))
                    {
                        SeriesDataItem dataItem = item as SeriesDataItem;

                        _chartPoints.Add(100.0 - dataItem.Value);
                    }
                }
            }
            else
            {
                for (int i = 0; i < _chartPoints.Capacity; i++)
                    _chartPoints.Add(100.0);
            }

            if (_updateInterval.Ticks > 0)
            {
                //start the uitimer
                uiTimer = new System.Windows.Threading.DispatcherTimer();
                uiTimer.Interval = TimeSpan.FromMilliseconds(timerFrameRate); 
                uiTimer.Tick += new EventHandler(uiTimer_Tick);
                uiTimer.Stop();
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (this.ItemsSource != null)
                _seriesDataItems = this.ItemsSource as SeriesDataItems;

            if (this.Items != null)
            {

            }
        }

        public void CreateChart()
        {
            _chartCanvas = CreateChart("chartGrid", this.Width, this.Height, _chartPoints);
            _chartHost.Children.Add(_chartCanvas = CreateChart("chartGrid", this.Width, this.Height, _chartPoints));
            _chartHost.Style = this.GridStyle;

            // PERF: desiredframerate property doesn't exist - using timer
            // CreateCanvasAnimationClock(_chartCanvas, 0.0, -5.0, new Duration(_updateInterval));
            //uiTimer.Stop();
            //timerFrame = 0.0;
            //timerStepLocation = 0.0;
            //uiTimer.Start();
        }

        #endregion

        #region Items collection support
        private void OnItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Add(sender, args);
                    break;

                //case NotifyCollectionChangedAction.Remove:
                //    Remove(sender, args);
                //    break;

                //case NotifyCollectionChangedAction.Reset:
                //    Reset(sender, args);
                //    break;
            }
        }

        private void Add(object sender, NotifyCollectionChangedEventArgs args)
        {
            if ((args.NewItems == null) || (args.NewItems.Count == 0))
                return;

            foreach (object item in args.NewItems)
            {
                SeriesDataItem dataItem = item as SeriesDataItem;

                if (dataItem.Value < 0)
                {
                    dataItem.Value = 50.0;
                }

                if (_chartPoints.Count < _chartPoints.Capacity)
                {
                    _chartPoints.Add(100.0 - dataItem.Value);

                    DrawSeries();
                }
                else
                {
                    // shift points in the array
                    for (int i = 1; i < _chartPoints.Count; i++)
                    {
                        _chartPoints[i - 1] = _chartPoints[i];
                    }

                    _chartPoints[_chartPoints.Count - 1] = 100.0 - dataItem.Value;

                    DrawSeries();
                    //_chartClock.Controller.Begin();

                    if (_updateInterval.Ticks > 0)
                    {
                        uiTimer.Stop();
                        _chartCanvas.SetValue(Canvas.LeftProperty, (double)0);
                        timerFrame = 0.0;
                        uiTimer.Start();
                    }
                }
            }
        }
        #endregion

        #region Chart rendering
        private Canvas CreateChart(string canvasName, double width, double height, List<double> chartPoints)
        {
            Canvas gridCanvas = new Canvas();
            gridCanvas.Name = canvasName;
            gridCanvas.Width = width + 5.0;
            gridCanvas.Height = height;

            chartSeriesPath = CreateSeriesPath("chartSeries", chartPoints, 0.0, 0.0, this.SeriesStyle);
            chartShadowPath = CreateSeriesPath("chartShadow", chartPoints, shadowOffsetX, shadowOffsetY, this.ShadowStyle);
            chartFillPath = CreateFillPath("chartSeriesFill", chartPoints, this.FillStyle);

            gridCanvas.Children.Add(chartShadowPath);
            gridCanvas.Children.Add(chartFillPath);
            gridCanvas.Children.Add(chartSeriesPath);

            return gridCanvas;
        }

        private Path CreateSeriesPath(string pathName, List<double> points, double offsetX, double offsetY, Style pathStyle)
        {
            // create a Path to contain the geometry.
            Path seriesPath = new Path();
            seriesPath.SetValue(StyleProperty, pathStyle);

            // Create a PathGeometry to contain the PathFigure.
            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(CreateSeriesFigure(points, offsetX, offsetY));
            seriesPath.Data = pathGeometry;

            return seriesPath;
        }

        private PathFigure CreateSeriesFigure(List<double> points, double offsetX, double offsetY)
        {
            PathFigure seriesFigure = new PathFigure();

            for (int i = 0; i < points.Count; i++)
            {
                double x = offsetX + (i * 5);
                double y = offsetY + points[i];

                if (i == 0)
                    seriesFigure.StartPoint = new Point(x, y);
                else
                    seriesFigure.Segments.Add(new LineSegment(new Point(x, y), true));
            }

            return seriesFigure;
        }

        private Path CreateFillPath(string pathName, List<double> points, Style pathStyle)
        {
            // create a Path to contain the geometry.
            Path fillPath = new Path();
            fillPath.Name = pathName;
            fillPath.Style = pathStyle;

            // Create a PathGeometry to contain the PathFigure.
            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures.Add(CreateFillFigure(points));
            fillPath.Data = myPathGeometry;

            return fillPath;
        }

        private PathFigure CreateFillFigure(List<double> points)
        {
            PathFigure myPathFigure = new PathFigure();

            myPathFigure.StartPoint=new Point(0, 100);
            for (int i = 0; i < points.Count; i++)
            {
                double x = i * 5;
                double y = points[i];

                myPathFigure.Segments.Add(new LineSegment(new Point(x, y),true));
                if (i == (points.Count - 1))
                    myPathFigure.Segments.Add(new LineSegment(new Point(x, 100),true));
            }
            myPathFigure.Segments.Add(new LineSegment(new Point(0, 100),true));

            return myPathFigure;
        }

        private void CreateCanvasAnimationClock(Canvas canvas, double fromValue, double toValue, Duration duration)
        {
            chartAnimation = new DoubleAnimation(fromValue, toValue, duration, FillBehavior.HoldEnd);
            chartAnimation.BeginTime = null;
            _chartClock = (AnimationClock)chartAnimation.CreateClock();

            canvas.ApplyAnimationClock(Canvas.LeftProperty, _chartClock, HandoffBehavior.SnapshotAndReplace);
        }

        private void DrawSeries()
        {
            if (chartSeriesPath == null)
                return;

            PathGeometry pathGeometry;
            pathGeometry = chartSeriesPath.Data as PathGeometry;
            pathGeometry.Figures[0] = CreateSeriesFigure(_chartPoints, 0.0, 0.0);
            pathGeometry = chartShadowPath.Data as PathGeometry;
            pathGeometry.Figures[0] = CreateSeriesFigure(_chartPoints, shadowOffsetX, shadowOffsetY);
            pathGeometry = chartFillPath.Data as PathGeometry;
            pathGeometry.Figures[0] = CreateFillFigure(_chartPoints);
        }

        private void ScrollPoints(double nextValue)
        {
            DrawSeries();

            if (_chartPoints.Count == _chartPoints.Capacity)
            {
                _chartClock.Controller.SkipToFill();
                _chartClock.Controller.Begin();
            }
        }

        void uiTimer_Tick(object sender, EventArgs e)
        {
            if (_chartCanvas == null)
                return;

            timerFrame++;
            double totalFrames = _updateInterval.TotalMilliseconds / uiTimer.Interval.TotalMilliseconds ;
            double framePercentage = timerFrame / totalFrames;
            double step = framePercentage * - 5.0; // the chart moves over by 5 pixels

            _chartCanvas.SetValue(Canvas.LeftProperty, (step));
            
            if (framePercentage >= 1.0)
            {
                uiTimer.Stop();
                OnUpdateIntervalEnded(null, new EventArgs());
            }

        }
        #endregion

        #region Static Methods

        public static FrameworkElement FindChart(Visual parent)
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                Visual visual = VisualTreeHelper.GetChild(parent, i) as Visual;

                if ((visual is FrameworkElement) && (visual is Chart))
                    return (visual as FrameworkElement);
                else
                {
                    FrameworkElement result = FindChart(visual);
                    if (result != null)
                        return result;
                }
            }

            return null;
        }

        #endregion
    }
}