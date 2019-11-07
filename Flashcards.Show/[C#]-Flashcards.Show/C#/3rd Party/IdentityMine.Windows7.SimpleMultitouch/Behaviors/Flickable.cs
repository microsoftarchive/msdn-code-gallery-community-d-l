using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Interactivity;
using System.Windows.Documents;
using System.Windows.Controls;
using Windows7.Multitouch.Manipulation;
using System;
using System.Collections.Generic;
using System.Windows.Controls.Primitives;


namespace IdentityMine.Windows.SimpleMultitouch
{
    public class FlickEventArgs : EventArgs
    {
        Vector _direction;

        public FlickEventArgs(Vector direction) { _direction = direction; }

        public Vector Direction { get { return _direction; } }

        public Vector AlignedDirection
        {
            get
            {
                if (Math.Abs(_direction.X) > Math.Abs(_direction.Y))
                    return new Vector(Math.Sign(_direction.X), 0);
                else
                    return new Vector(0, Math.Sign(_direction.Y));
            }
        }
    }

    /// <summary>
    /// A behavior enabling flicks. 
    /// </summary>
    public class Flickable : Behavior<UIElement>
    {
        #region Data

        private class FlickData
        {
            public Point DownPoint;
            public int BeginTime;
        }
        private UIElement _attachedElement;
        private Dictionary<int, FlickData> _pts;
        #endregion

        public Flickable()
        {
            _pts = new Dictionary<int, FlickData>();
        }

        #region Events
        public event EventHandler<FlickEventArgs> Flick;
        public event EventHandler<FlickEventArgs> HorizontalFlick;
        public event EventHandler<FlickEventArgs> VerticalFlick;
        #endregion

        #region Behaviour Overrides

        protected override void OnAttached()
        {
            base.OnAttached();

            _attachedElement = (UIElement)this.AssociatedObject;

            _attachedElement.PreviewStylusDown += OnStylusStuff;
            _attachedElement.PreviewStylusMove += OnStylusStuff;
            _attachedElement.PreviewStylusUp += OnStylusStuff;
            _attachedElement.PreviewMouseDown += OnMouseStuff;
            _attachedElement.PreviewMouseMove += OnMouseStuff;
            _attachedElement.PreviewMouseUp += OnMouseStuff;
        }

        protected override void OnDetaching()
        {
            _attachedElement.PreviewStylusDown -= OnStylusStuff;
            _attachedElement.PreviewStylusMove -= OnStylusStuff;
            _attachedElement.PreviewStylusUp -= OnStylusStuff;
            _attachedElement.PreviewMouseDown -= OnMouseStuff;
            _attachedElement.PreviewMouseMove -= OnMouseStuff;
            _attachedElement.PreviewMouseUp -= OnMouseStuff;

            base.OnDetaching();
        }
        #endregion

        #region Dependency Properties

        #region BeginThreshold

        public static readonly DependencyProperty BeginThresholdProperty =
            DependencyProperty.Register("BeginThreshold", typeof(double), typeof(Flickable),
            new PropertyMetadata(20.0));

        public double BeginThreshold
        {
            get { return (double)GetValue(BeginThresholdProperty); }
            set { SetValue(BeginThresholdProperty, value); }
        }

        #endregion

        #region EndThreshold

        public static readonly DependencyProperty EndThresholdProperty =
            DependencyProperty.Register("EndThreshold", typeof(double), typeof(Flickable),
            new PropertyMetadata(60.0));

        public double EndThreshold
        {
            get { return (double)GetValue(EndThresholdProperty); }
            set { SetValue(EndThresholdProperty, value); }
        }

        #endregion

        #region RequiredFlickSpeed

        public static readonly DependencyProperty RequiredFlickSpeedProperty =
            DependencyProperty.Register("RequiredFlickSpeed", typeof(TimeSpan), typeof(Flickable),
            new PropertyMetadata(TimeSpan.FromMilliseconds(30)));

        /// <summary>
        /// Gets or sets the time limit that a flick must be performed in, from the moment movement crosses BeginThreshold to the moment it crosses EndThreshold.
        /// </summary>
        public TimeSpan RequiredFlickSpeed
        {
            get { return (TimeSpan)GetValue(RequiredFlickSpeedProperty); }
            set { SetValue(RequiredFlickSpeedProperty, value); }
        }

        #endregion

        #endregion

        #region Internal

        private void OnStylusStuff(object sender, StylusEventArgs args)
        {
            if (args.RoutedEvent == UIElement.PreviewStylusUpEvent || 
                (args.RoutedEvent == UIElement.PreviewStylusDownEvent && args.Source == null) ||
                (args.RoutedEvent == UIElement.PreviewStylusMoveEvent && args.Source == null && args.InAir))
            {
                MultitouchWindow.RemoveStylusListener(args.StylusDevice, _attachedElement, OnStylusStuff);
            }
            else if (args.RoutedEvent == UIElement.PreviewStylusDownEvent)
            {
                MultitouchWindow.AddStylusListener(args.StylusDevice, _attachedElement, OnStylusStuff);
                _pts[args.StylusDevice.Id] = new FlickData()
                {
                    DownPoint = args.GetPosition(_attachedElement)
                };
            }
            else if (args.RoutedEvent == UIElement.PreviewStylusMoveEvent)
            {
                if (!_pts.ContainsKey(args.StylusDevice.Id)) return;

                Point current = args.GetPosition(_attachedElement);
                
                FlickData data = _pts[args.StylusDevice.Id];
                Vector change = Point.Subtract(current, data.DownPoint);
                double delta = change.Length;

                if (data.BeginTime == 0 &&
                    delta > BeginThreshold)
                    data.BeginTime = args.Timestamp;
                
                if( data.BeginTime != 0 && 
                    delta > EndThreshold && 
                    (args.Timestamp - data.BeginTime) < RequiredFlickSpeed.TotalMilliseconds)
                {
                    MultitouchWindow.RemoveStylusListener(args.StylusDevice, _attachedElement, OnStylusStuff);

                    _pts.Remove(args.StylusDevice.Id);

                    FlickEventArgs fargs = new FlickEventArgs(change / delta);

                    if (Flick != null) Flick(_attachedElement, fargs);
                    if (fargs.AlignedDirection.X != 0 && HorizontalFlick != null) HorizontalFlick(_attachedElement, fargs);
                    if (fargs.AlignedDirection.Y != 0 && VerticalFlick != null) VerticalFlick(_attachedElement, fargs);
                }
            }
        }

        private void OnMouseStuff(object sender, MouseEventArgs args)
        {
            if (args.RoutedEvent == UIElement.PreviewMouseUpEvent ||
                (args.RoutedEvent == UIElement.PreviewMouseDownEvent && args.Source == null) ||
                (args.RoutedEvent == UIElement.PreviewMouseMoveEvent && args.Source == null && args.LeftButton == MouseButtonState.Released))
            {
                MultitouchWindow.RemoveMouseListener(_attachedElement, OnMouseStuff);
            }
            else if (args.RoutedEvent == UIElement.PreviewMouseDownEvent)
            {
                MultitouchWindow.AddMouseListener(_attachedElement, OnMouseStuff);
                _pts[-1] = new FlickData()
                {
                    DownPoint = args.GetPosition(_attachedElement)
                };
            }
            else if (args.RoutedEvent == UIElement.PreviewMouseMoveEvent)
            {
                if (!_pts.ContainsKey(-1)) return;

                Point current = args.GetPosition(_attachedElement);

                FlickData data = _pts[-1];
                Vector change = Point.Subtract(current, data.DownPoint);
                double delta = change.Length;

                if (data.BeginTime == 0 &&
                    delta > BeginThreshold)
                    data.BeginTime = args.Timestamp;

                if (data.BeginTime != 0 &&
                    delta > EndThreshold &&
                    (args.Timestamp - data.BeginTime) < RequiredFlickSpeed.TotalMilliseconds)
                {
                    MultitouchWindow.RemoveMouseListener(_attachedElement, OnMouseStuff);

                    _pts.Remove(-1);

                    FlickEventArgs fargs = new FlickEventArgs(change / delta);

                    if (Flick != null) Flick(_attachedElement, fargs);
                    if (fargs.AlignedDirection.X != 0 && HorizontalFlick != null) HorizontalFlick(_attachedElement, fargs);
                    if (fargs.AlignedDirection.Y != 0 && VerticalFlick != null) VerticalFlick(_attachedElement, fargs);
                }
            }
        }

        #endregion

    }
}
