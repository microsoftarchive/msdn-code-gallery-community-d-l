using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Interactivity;
using System.Windows.Documents;
using System.Windows.Controls;
//using Windows7.Multitouch.Manipulation;
//using System.Drawing;
using Windows7.Multitouch.ManipulationInterop;
using System.Runtime.InteropServices;
using System;
using System.Runtime.InteropServices.ComTypes;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace IdentityMine.Windows.SimpleMultitouch
{
    #region Event Args

    /// <summary>
    /// Argument for manipulatiuon start event
    /// </summary>
    public class ManipulationStartedEventArgs : EventArgs
    {
        /// <summary>
        /// Argument for touch event location
        /// </summary>
        /// <param name="x">The x Axis</param>
        /// <param name="y">The y Axis</param>
        public ManipulationStartedEventArgs(float x, float y)
        {
            Location = new Point(x, y);
        }

        /// <summary>
        /// This location is usually the center point
        /// </summary>
        public Point Location { get; private set; }
    }

    /// <summary>
    /// The argument for manipulation complete event
    /// </summary>
    public class ManipulationCompletedEventArgs : ManipulationStartedEventArgs
    {
        /// <summary>
        /// Create new ManipulationCompletedEventArgs
        /// </summary>
        /// <param name="x">x Axis</param>
        /// <param name="y">y Axis</param>
        /// <param name="cumulativeTranslationX">Cumulative Translation in the X Axis since starting manipulation</param>
        /// <param name="cumulativeTranslationY">Cumulative Translation in the Y Axis since starting manipulation</param>
        /// <param name="cumulativeScale">Cumulative scaling since starting manipulation</param>
        /// <param name="cumulativeExpansion">Cumulative Expension since starting manipulation</param>
        /// <param name="cumulativeRotation">Cumulative rotation in radians since starting manipulation</param>
        public ManipulationCompletedEventArgs(float x, float y, float cumulativeTranslationX, float cumulativeTranslationY,
                                                    float cumulativeScale, float cumulativeExpansion, float cumulativeRotation)
            : base(x, y)
        {
            CumulativeTranslation = new Vector(cumulativeTranslationX, cumulativeTranslationY);
            CumulativeScale = cumulativeScale;
            CumulativeExpansion = cumulativeExpansion;
            CumulativeRotation = cumulativeRotation * 180 / Math.PI;
        }

        /// <summary>
        /// Total translation
        /// </summary>
        public Vector CumulativeTranslation { get; private set; }

        /// <summary>
        /// Total Scaling
        /// </summary>
        public double CumulativeScale { get; private set; }

        /// <summary>
        /// Total Extension
        /// </summary>
        public double CumulativeExpansion { get; private set; }

        /// <summary>
        /// Total Rotation
        /// </summary>
        public double CumulativeRotation { get; private set; }
    }

    /// <summary>
    /// The argument for manipulation delta
    /// </summary>
    public class ManipulationDeltaEventArgs : ManipulationCompletedEventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">x Axis</param>
        /// <param name="y">y Axis</param>
        /// <param name="translationDeltaX">The amount of translation since the last event</param>
        /// <param name="translationDeltaY">The amount of translation since the last event</param>
        /// <param name="scaleDelta">The amount of scaling since the last event</param>
        /// <param name="expansionDelta">The amount of expension since the last event</param>
        /// <param name="rotationDelta">The amount of rotation in radians since the last event</param>
        /// <param name="cumulativeTranslationX">Cumulative Translation in the X Axis since starting manipulation</param>
        /// <param name="cumulativeTranslationY">Cumulative Translation in the Y Axis since starting manipulation</param>
        /// <param name="cumulativeScale">Cumulative scaling since starting manipulation</param>
        /// <param name="cumulativeExpansion">Cumulative Expension since starting manipulation</param>
        /// <param name="cumulativeRotation">Cumulative rotation in radians since starting manipulation</param>
        public ManipulationDeltaEventArgs(float x, float y, float translationDeltaX, float translationDeltaY, float scaleDelta, float expansionDelta,
            float rotationDelta, float cumulativeTranslationX, float cumulativeTranslationY, float cumulativeScale, float cumulativeExpansion, float cumulativeRotation)
            : base(x, y, cumulativeTranslationX, cumulativeTranslationY, cumulativeScale, cumulativeExpansion, cumulativeRotation)
        {
            TranslationDelta = new Vector(translationDeltaX, translationDeltaY);
            ScaleDelta = scaleDelta;
            ExpansionDelta = expansionDelta;
            RotationDelta = rotationDelta * 180 / Math.PI;

        }

        /// <summary>
        /// The amount of translation since the last event
        /// </summary>
        public Vector TranslationDelta { get; private set; }

        /// <summary>
        /// The amount of scaling since the last event
        /// </summary>
        public double ScaleDelta { get; private set; }

        /// <summary>
        /// The amount of expension since the last event
        /// </summary>
        public double ExpansionDelta { get; private set; }

        /// <summary>
        /// The amount of rotation since the last event
        /// </summary>
        public double RotationDelta { get; private set; }
    }
    #endregion

    #region Enumerations
    /// <summary>
    /// Manipulation Flags.
    /// Enables Manipulation Support
    /// </summary>
    [Flags]
    public enum ManipulationTypes
    {
        /// <summary>
        /// Disable manipulation events
        /// </summary>
        None = 0,

        /// <summary>
        /// X axis translation events
        /// </summary>
        TranslateX = 0x1,

        /// <summary>
        /// Y Axis translation events
        /// </summary>
        TranslateY = 0x2,

        /// <summary>
        /// Scaling events
        /// </summary>
        Scale = 0x4,

        /// <summary>
        /// Rotation events
        /// </summary>
        Rotate = 0x8,

        /// <summary>
        /// Fire all manipulation events
        /// </summary>
        All = 0xf
    }

    #endregion

    /// <summary>
    /// A Inertia Enabled Scroll Behavior to apply to a scrollviewer
    /// </summary>
    public class Manipulable : Behavior<FrameworkElement>, IManipulationEvents
    {
        #region Data
        private IManipulationProcessor _mprocessor;
        private IInertiaProcessor _iprocessor;
        private IConnectionPoint _meventsconnectionpoint;
        private IConnectionPoint _ieventsconnectionpoint;
        private FrameworkElement _attachedElement;
        private int _cookie = -1;
        private TranslateTransform _mattranslate;
        private RotateTransform _matrotate;
        private ScaleTransform _matscale;
        private TransformGroup _mattransform;
        private Dictionary<int, Point> _pts;
        private bool _usinginertia;
        #endregion

        public Manipulable()
        {
            _iprocessor = new InertiaProcessor();
            _mprocessor = new ManipulationProcessor();
            _pts = new Dictionary<int, Point>();

            Guid manipulationEventsId = new Guid(IIDGuid.IManipulationEvents);
            _mprocessor.FindConnectionPoint(ref manipulationEventsId, out _meventsconnectionpoint);
            _meventsconnectionpoint.Advise(this, out _cookie);
            _iprocessor.FindConnectionPoint(ref manipulationEventsId, out _ieventsconnectionpoint);
            _ieventsconnectionpoint.Advise(this, out _cookie);

            OnPivotPointChanged(this, new DependencyPropertyChangedEventArgs());
            OnPivotRadiusChanged(this, new DependencyPropertyChangedEventArgs());
            OnSupportedManipulationsChanged(this, new DependencyPropertyChangedEventArgs());
            OnMinimumScaleRotateRadiusChanged(this, new DependencyPropertyChangedEventArgs());

            _matrotate = new RotateTransform();
            _matscale = new ScaleTransform();
            _mattranslate = new TranslateTransform();
            _mattransform = new TransformGroup();

            _mattransform.Children.Add(_matrotate);
            _mattransform.Children.Add(_matscale);
            _mattransform.Children.Add(_mattranslate);
        }

        #region Behavior Overrides

        protected override void OnAttached()
        {
            base.OnAttached();

            _attachedElement = this.AssociatedObject;

            _attachedElement.PreviewStylusDown += OnStylusStuff;
            _attachedElement.PreviewStylusUp += OnStylusStuff;
            _attachedElement.PreviewStylusMove += OnStylusStuff;

            _attachedElement.PreviewMouseLeftButtonDown += OnMouseStuff;
            _attachedElement.PreviewMouseLeftButtonUp += OnMouseStuff;
            _attachedElement.PreviewMouseMove += OnMouseStuff;
        }

        protected override void OnDetaching()
        {
            _attachedElement.PreviewStylusDown -= OnStylusStuff;
            _attachedElement.PreviewStylusUp -= OnStylusStuff;
            _attachedElement.PreviewStylusMove -= OnStylusStuff;

            _attachedElement.PreviewMouseDown -= OnMouseStuff;
            _attachedElement.PreviewMouseUp -= OnMouseStuff;
            _attachedElement.PreviewMouseMove -= OnMouseStuff;

            base.OnDetaching();
        }

        #endregion

        #region Events

        public event EventHandler<ManipulationStartedEventArgs> BeginManipulation;
        public event EventHandler<ManipulationDeltaEventArgs> Manipulate;
        public event EventHandler<ManipulationCompletedEventArgs> EndManipulation;
        public event EventHandler<ManipulationCompletedEventArgs> EndInertia;

        #endregion

        #region Methods

        void ForceComplete()
        {
            _mprocessor.CompleteManipulation();
        }

        public virtual void ProcessPointDown(int pid, Point pt)
        {
            _pts[pid] = pt;
            UpdatePivot();
            _mprocessor.ProcessDown((uint)pid, (float)pt.X, (float)pt.Y);
        }

        public virtual void ProcessPointMove(int pid, Point pt)
        {
            if (!_pts.ContainsKey(pid)) return;

            _pts[pid] = pt;
            UpdatePivot();
            _mprocessor.ProcessMove((uint)pid, (float)pt.X, (float)pt.Y);
        }

        public virtual void ProcessPointUp(int pid, Point pt)
        {
            _pts.Remove(pid);
            UpdatePivot();
            _mprocessor.ProcessUp((uint)pid, (float)pt.X, (float)pt.Y);
        }

        public bool IsProcessing(int pid)
        {
            return _pts.ContainsKey(pid);
        }

        #endregion

        #region Basic Properties

        public Vector Velocity
        {
            get { return new Vector(_mprocessor.GetVelocityX(), _mprocessor.GetVelocityY()); }
        }

        public double AngularVelocity
        {
            get { return (double)_mprocessor.GetAngularVelocity(); }
        }

        public double ExpansionVelocity
        {
            get { return (double)_mprocessor.GetExpansionVelocity(); }
        }

        #endregion

        #region Dependency Properties

        #region SupportedManipulations

        public static readonly DependencyProperty SupportedManipulationsProperty =
            DependencyProperty.Register("SupportedManipulations", typeof(ManipulationTypes), typeof(Manipulable),
            new PropertyMetadata(ManipulationTypes.All, OnSupportedManipulationsChanged));

        public ManipulationTypes SupportedManipulations
        {
            get { return (ManipulationTypes)GetValue(SupportedManipulationsProperty); }
            set { SetValue(SupportedManipulationsProperty, value); }
        }

        private static void OnSupportedManipulationsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            Manipulable man = (Manipulable)sender;

            man._mprocessor.SupportedManipulations = (MANIPULATION_PROCESSOR_MANIPULATIONS)man.SupportedManipulations;
        }

        #endregion

        #region PivotPoint

        public static readonly DependencyProperty PivotPointProperty =
            DependencyProperty.Register("PivotPoint", typeof(Point), typeof(Manipulable),
            new PropertyMetadata(OnPivotPointChanged));

        public Point PivotPoint
        {
            get { return (Point)GetValue(PivotPointProperty); }
            set { SetValue(PivotPointProperty, value); }
        }

        private static void OnPivotPointChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            Manipulable man = (Manipulable)sender;

            man._mprocessor.PivotPointX = (float)man.PivotPoint.X;
            man._mprocessor.PivotPointY = (float)man.PivotPoint.Y;
        }

        #endregion

        #region PivotRadius

        public static readonly DependencyProperty PivotRadiusProperty =
            DependencyProperty.Register("PivotRadius", typeof(double), typeof(Manipulable),
            new PropertyMetadata(1.0, OnPivotRadiusChanged));

        public double PivotRadius
        {
            get { return (double)GetValue(PivotRadiusProperty); }
            set { SetValue(PivotRadiusProperty, value); }
        }

        private static void OnPivotRadiusChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            Manipulable man = (Manipulable)sender;

            man._mprocessor.PivotRadius = (float)man.PivotRadius;
        }

        #endregion

        #region MinimumScaleRotateRadius

        public static readonly DependencyProperty MinimumScaleRotateRadiusProperty =
            DependencyProperty.Register("MinimumScaleRotateRadius", typeof(double), typeof(Manipulable),
            new PropertyMetadata(OnMinimumScaleRotateRadiusChanged));

        public double MinimumScaleRotateRadius
        {
            get { return (double)GetValue(MinimumScaleRotateRadiusProperty); }
            set { SetValue(MinimumScaleRotateRadiusProperty, value); }
        }

        private static void OnMinimumScaleRotateRadiusChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            Manipulable man = (Manipulable)sender;
            man._mprocessor.MinimumScaleRotateRadius = (float)man.MinimumScaleRotateRadius;
        }

        #endregion

        #region CumulativeTransform

        private static readonly DependencyPropertyKey CumulativeTransformPropertyKey =
            DependencyProperty.RegisterReadOnly("CumulativeTransform", typeof(MatrixTransform), typeof(Manipulable),
            new PropertyMetadata(MatrixTransform.Identity));

        public static readonly DependencyProperty CumulativeTransformProperty = CumulativeTransformPropertyKey.DependencyProperty;

        public MatrixTransform CumulativeTransform
        {
            get { return (MatrixTransform)GetValue(CumulativeTransformProperty); }
            private set { SetValue(CumulativeTransformPropertyKey, value); }
        }

        private void OnManipulationUpdated(ManipulationDeltaEventArgs args)
        {
            Matrix mat = CumulativeTransform.Matrix;

            mat.ScaleAt(args.ScaleDelta, args.ScaleDelta, args.Location.X, args.Location.Y);
            mat.RotateAt(args.RotationDelta, args.Location.X, args.Location.Y);
            mat.Translate(args.TranslationDelta.X, args.TranslationDelta.Y);

            CumulativeTransform = new MatrixTransform(mat);
        }

        #endregion

        #region Container

        public static readonly DependencyProperty ContainerProperty =
            DependencyProperty.Register("Container", typeof(UIElement), typeof(Manipulable));

        public UIElement Container
        {
            get { return (UIElement)GetValue(ContainerProperty); }
            set { SetValue(ContainerProperty, value); }
        }

        #endregion

        #region Deceleration

        public static readonly DependencyProperty DecelerationProperty =
            DependencyProperty.Register("Deceleration", typeof(double), typeof(Manipulable),
            new PropertyMetadata(OnDecelerationChanged));

        public double Deceleration
        {
            get { return (double)GetValue(DecelerationProperty); }
            set { SetValue(DecelerationProperty, value); }
        }

        private static void OnDecelerationChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            Manipulable man = (Manipulable)sender;
            man._iprocessor.DesiredDeceleration = (float)man.Deceleration;
        }

        #endregion

        #region AngularDeceleration

        public static readonly DependencyProperty AngularDecelerationProperty =
            DependencyProperty.Register("AngularDeceleration", typeof(double), typeof(Manipulable),
            new PropertyMetadata(OnAngularDecelerationChanged));

        public double AngularDeceleration
        {
            get { return (double)GetValue(AngularDecelerationProperty); }
            set { SetValue(AngularDecelerationProperty, value); }
        }

        private static void OnAngularDecelerationChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            Manipulable man = (Manipulable)sender;
            man._iprocessor.DesiredAngularDeceleration = (float)man.AngularDeceleration;
        }

        #endregion

        #region ExpansionDeceleration

        public static readonly DependencyProperty ExpansionDecelerationProperty =
            DependencyProperty.Register("ExpansionDeceleration", typeof(double), typeof(Manipulable),
            new PropertyMetadata(OnExpansionDecelerationChanged));

        public double ExpansionDeceleration
        {
            get { return (double)GetValue(ExpansionDecelerationProperty); }
            set { SetValue(ExpansionDecelerationProperty, value); }
        }

        private static void OnExpansionDecelerationChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            Manipulable man = (Manipulable)sender;
            man._iprocessor.DesiredExpansionDeceleration = (float)man.ExpansionDeceleration;
        }

        #endregion

        #region Boundary

        public static readonly DependencyProperty BoundaryProperty =
            DependencyProperty.Register("Boundary", typeof(Rect), typeof(Manipulable),
            new PropertyMetadata(new Rect(double.NegativeInfinity, double.NegativeInfinity, double.PositiveInfinity, double.PositiveInfinity),
                OnBoundaryChanged));

        public Rect Boundary
        {
            get { return (Rect)GetValue(BoundaryProperty); }
            set { SetValue(BoundaryProperty, value); }
        }

        private static void OnBoundaryChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            Manipulable man = (Manipulable)sender;
            man._iprocessor.BoundaryBottom = (float)man.Boundary.Bottom;
            man._iprocessor.BoundaryLeft = (float)man.Boundary.Left;
            man._iprocessor.BoundaryRight = (float)man.Boundary.Right;
            man._iprocessor.BoundaryTop = (float)man.Boundary.Top;
        }

        #endregion

        #region ElasticMargin

        public static readonly DependencyProperty ElasticMarginProperty =
            DependencyProperty.Register("ElasticMargin", typeof(Thickness), typeof(Manipulable),
            new PropertyMetadata(new Thickness(0), OnElasticMarginChanged));

        public Thickness ElasticMargin
        {
            get { return (Thickness)GetValue(ElasticMarginProperty); }
            set { SetValue(ElasticMarginProperty, value); }
        }

        private static void OnElasticMarginChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            Manipulable man = (Manipulable)sender;
            man._iprocessor.ElasticMarginBottom = (float)man.ElasticMargin.Bottom;
            man._iprocessor.ElasticMarginLeft = (float)man.ElasticMargin.Left;
            man._iprocessor.ElasticMarginRight = (float)man.ElasticMargin.Right;
            man._iprocessor.ElasticMarginTop = (float)man.ElasticMargin.Top;
        }

        #endregion

        #endregion

        #region IManipulationEvents Members

        public void ManipulationStarted(float x, float y)
        {
            if (BeginManipulation != null)
                BeginManipulation(this, new ManipulationStartedEventArgs(x, y));
        }

        public void ManipulationDelta(float x, float y, float translationDeltaX, float translationDeltaY, float scaleDelta, float expansionDelta, float rotationDelta, float cumulativeTranslationX, float cumulativeTranslationY, float cumulativeScale, float cumulativeExpansion, float cumulativeRotation)
        {
            ManipulationDeltaEventArgs args = new ManipulationDeltaEventArgs(
                x, y, translationDeltaX, translationDeltaY,
                scaleDelta, expansionDelta, rotationDelta,
                cumulativeTranslationX, cumulativeTranslationY,
                cumulativeScale, cumulativeExpansion, cumulativeRotation);
            if (Manipulate != null)
                Manipulate(this, args);

            OnManipulationUpdated(args);
        }

        public void ManipulationCompleted(float x, float y, float cumulativeTranslationX, float cumulativeTranslationY, float cumulativeScale, float cumulativeExpansion, float cumulativeRotation)
        {
            ManipulationCompletedEventArgs args = new ManipulationCompletedEventArgs(
                    x, y, cumulativeTranslationX, cumulativeTranslationY,
                    cumulativeScale, cumulativeExpansion, cumulativeRotation);

            if (_usinginertia)
            {
                CompositionTarget.Rendering -= Inertia_Processing;

                if (EndInertia != null) EndInertia(this, args);
            }
            else
            {
                if (Deceleration != 0.0 || AngularDeceleration != 0.0 || ExpansionDeceleration != 0.0)
                {
                    _usinginertia = true;

                    _iprocessor.InitialAngularVelocity = _mprocessor.GetAngularVelocity();
                    _iprocessor.InitialExpansionVelocity = _mprocessor.GetExpansionVelocity();
                    _iprocessor.InitialOriginX = _mprocessor.PivotPointX;
                    _iprocessor.InitialOriginY = _mprocessor.PivotPointY;
                    _iprocessor.InitialRadius = _mprocessor.PivotRadius;
                    _iprocessor.InitialVelocityX = _mprocessor.GetVelocityX();
                    _iprocessor.InitialVelocityY = _mprocessor.GetVelocityY();

                    CompositionTarget.Rendering += Inertia_Processing;
                }

                if (EndManipulation != null)
                    EndManipulation(this, args);
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Marshal.ReleaseComObject(_ieventsconnectionpoint);
            Marshal.ReleaseComObject(_meventsconnectionpoint);
            Marshal.ReleaseComObject(_iprocessor);
            Marshal.ReleaseComObject(_mprocessor);
        }

        #endregion

        #region Internal

        private void UpdatePivot()
        {
            Point pivot = _attachedElement.TransformToVisual(Container).Transform(new Point(_attachedElement.ActualWidth / 2.0, _attachedElement.ActualHeight / 2.0));
            _mprocessor.PivotPointX = (float)pivot.X;
            _mprocessor.PivotPointY = (float)pivot.Y;
            _mprocessor.PivotRadius = (float)(_attachedElement.ActualHeight + _attachedElement.ActualWidth) / 4.0f;
        }

        protected virtual void OnMouseStuff(object sender, MouseEventArgs args)
        {
            if (Container == null)
                Container = AssociatedObject;
            Point pt = args.GetPosition(Container);

            if (args.RoutedEvent == UIElement.PreviewMouseLeftButtonUpEvent ||
                (args.RoutedEvent == UIElement.PreviewMouseLeftButtonDownEvent && args.Source == null) ||
                (args.RoutedEvent == UIElement.PreviewMouseMoveEvent && args.Source == null && args.LeftButton == MouseButtonState.Released))
            {
                MultitouchWindow.RemoveMouseListener(_attachedElement, OnMouseStuff);
                ProcessPointUp(-1, pt);
            }
            else if (args.RoutedEvent == UIElement.PreviewMouseLeftButtonDownEvent)
            {
                MultitouchWindow.AddMouseListener(_attachedElement, OnMouseStuff);
                ProcessPointDown(-1, pt);
            }
            else if (args.RoutedEvent == UIElement.PreviewMouseMoveEvent)
            {
                ProcessPointMove(-1, pt);
            }
        }

        protected virtual void OnStylusStuff(object sender, StylusEventArgs args)
        {
            if (Container == null)
                Container = AssociatedObject;
            Point pt = args.GetPosition(Container);

            if (args.RoutedEvent == UIElement.PreviewStylusUpEvent ||
                (args.RoutedEvent == UIElement.PreviewStylusDownEvent && args.Source == null) ||
                (args.RoutedEvent == UIElement.PreviewStylusMoveEvent && args.Source == null && args.InAir))
            {
                MultitouchWindow.RemoveStylusListener(args.StylusDevice, _attachedElement, OnStylusStuff);
                ProcessPointUp(args.StylusDevice.Id, pt);
            }
            else if (args.RoutedEvent == UIElement.PreviewStylusDownEvent)
            {
                MultitouchWindow.AddStylusListener(args.StylusDevice, _attachedElement, OnStylusStuff);
                ProcessPointDown(args.StylusDevice.Id, pt);
            }
            else if (args.RoutedEvent == UIElement.PreviewStylusMoveEvent)
            {
                ProcessPointMove(args.StylusDevice.Id, pt);
            }
        }

        void Inertia_Processing(object sender, EventArgs e)
        {
            _iprocessor.Process();
        }

        #endregion
    }
}
