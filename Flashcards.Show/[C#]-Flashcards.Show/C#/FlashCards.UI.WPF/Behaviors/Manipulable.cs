using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Expression.Interactivity;
using System.Windows.Documents;
using System.Windows.Controls;
//using Windows7.Multitouch.Manipulation;
//using System.Drawing;
using Windows7.Multitouch.ManipulationInterop;
using System.Runtime.InteropServices;
using System;
using System.Runtime.InteropServices.ComTypes;


namespace FlashCardUI.Behaviors
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
            CumulativeRotation = cumulativeRotation;
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
            RotationDelta = rotationDelta;

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
        private IConnectionPoint _eventsconnectionpoint;
        private FrameworkElement _attachedElement;
        private int _cookie = -1;
        private TranslateTransform _mattranslate;
        private RotateTransform _matrotate;
        private ScaleTransform _matscale;
        private TransformGroup _mattransform;
        #endregion

        public Manipulable()
        {
            _mprocessor = new ManipulationProcessor();

            Guid manipulationEventsId = new Guid(IIDGuid.IManipulationEvents);
            _mprocessor.FindConnectionPoint(ref manipulationEventsId, out _eventsconnectionpoint);
            _eventsconnectionpoint.Advise(this, out _cookie);

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

            CumulativeTransform = _mattransform;
        }

        #region Behaviour Overrides

        private void UpdatePivot()
        {
            Point pivot = _attachedElement.TransformToVisual(Container).Transform(new Point(_attachedElement.ActualWidth / 2.0, _attachedElement.ActualHeight / 2.0));
            //_mprocessor.PivotRadius = 0;
            //_mprocessor.MinimumScaleRotateRadius = 0.5f;
            _mprocessor.PivotPointX = (float)pivot.X;
            _mprocessor.PivotPointY = (float)pivot.Y;
        }

        protected override void OnAttached()
        {
            _attachedElement = this.AssociatedObject;

            _attachedElement.PreviewStylusDown += (s, e) =>
            {
                if (Container == null) return;
                MultitouchWindow.SafeCaptureStylus(e.StylusDevice, _attachedElement);
                e.Handled = true;
                Point pos = e.GetPosition(Container);
                UpdatePivot();
                _mprocessor.ProcessDown((uint)e.StylusDevice.Id, (float)pos.X, (float)pos.Y);
            };
            _attachedElement.PreviewStylusUp += (s, e) =>
            {
                if (Container == null) return;
                MultitouchWindow.SafeCaptureStylus(e.StylusDevice, null);
                Point pos = e.GetPosition(Container);
                UpdatePivot();
                _mprocessor.ProcessUp((uint)e.StylusDevice.Id, (float)pos.X, (float)pos.Y);
            };
            _attachedElement.PreviewStylusMove += (s, e) =>
            {
                if (Container == null) return;
                Point pos = e.GetPosition(Container);
                UpdatePivot();
                _mprocessor.ProcessMove((uint)e.StylusDevice.Id, (float)pos.X, (float)pos.Y);
            };

            _attachedElement.PreviewMouseDown += (s, e) =>
            {
                if (Container == null) return;
                MultitouchWindow.SafeCaptureMouse(_attachedElement);
                e.Handled = true;
                Point pos = e.GetPosition(Container);
                UpdatePivot();
                _mprocessor.ProcessDown(1 << 30, (float)pos.X, (float)pos.Y);
            };

            _attachedElement.PreviewMouseUp += (s, e) =>
            {
                if (Container == null) return;
                MultitouchWindow.SafeCaptureMouse(null);
                Point pos = e.GetPosition(Container);
                UpdatePivot();
                _mprocessor.ProcessUp(1 << 30, (float)pos.X, (float)pos.Y);
            };
            _attachedElement.PreviewMouseMove += (s, e) =>
            {
                if (Container == null) return;
                Point pos = e.GetPosition(Container);
                UpdatePivot();
                _mprocessor.ProcessMove(1 << 30, (float)pos.X, (float)pos.Y);
            };
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }

        #endregion

        #region Events

        public event EventHandler<ManipulationStartedEventArgs> BeginManipulation;
        public event EventHandler<ManipulationDeltaEventArgs> Manipulate;
        public event EventHandler<ManipulationCompletedEventArgs> EndManipulation;

        #endregion

        #region Methods

        void ForceComplete()
        {
            _mprocessor.CompleteManipulation();
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
            DependencyProperty.RegisterReadOnly("CumulativeTransform", typeof(Transform), typeof(Manipulable),
            new PropertyMetadata(Transform.Identity));

        public static readonly DependencyProperty CumulativeTransformProperty = CumulativeTransformPropertyKey.DependencyProperty;

        public Transform CumulativeTransform
        {
            get { return (Transform)GetValue(CumulativeTransformProperty); }
            private set { SetValue(CumulativeTransformPropertyKey, value); }
        }

        private void OnManipulationUpdated(ManipulationDeltaEventArgs args)
        {
            if (args.CumulativeTranslation.X != 0.0)
                args.ToString();

            _mattranslate.X += args.TranslationDelta.X;
            _mattranslate.Y += args.TranslationDelta.Y;
            _matrotate.Angle += args.RotationDelta * 180 / Math.PI;
            _matscale.ScaleX *= args.ScaleDelta;
            _matscale.ScaleY *= args.ScaleDelta;
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

        #endregion

        #region IManipulationEvents Members

        public void ManipulationStarted(float x, float y)
        {
            if(BeginManipulation != null)
                BeginManipulation(this, new ManipulationStartedEventArgs(x,y));
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

            if (EndManipulation!= null)
                EndManipulation(this, args);

            //OnManipulationUpdated(args);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Marshal.ReleaseComObject(_mprocessor);
        }

        #endregion
    }
}
