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
    /// <summary>
    /// Contains data for 
    /// </summary>
    public class TapEventArgs : EventArgs
    {
        InputDevice _device;
        Vector _jitter;

        public TapEventArgs(InputDevice device, Vector jitter)
        {
            _device = device;
            _jitter = jitter;
        }

        /// <summary>
        /// Gets the device used to tap. If the device was a stylus, find it under the StylusDevice property of this object.
        /// </summary>
        public InputDevice Device
        {
            get { return _device; }
        }

        /// <summary>
        /// Gets the vector pointing from where the tap was initiated to where it was fired.
        /// </summary>
        public Vector Jitter
        {
            get { return _jitter; }
        }
    }

    /// <summary>
    /// A tap behavior enabling button-like input using multitouch.
    /// </summary>
    /// <remarks>
    /// When attached to a ButtonBase object, this behavior does not override the original 
    /// button response to mouse input. Also, this behavior will invoke the click response
    /// on the button itself in response to a stylus tap.
    /// </remarks>
    public class TapBehavior : Behavior<UIElement>
    {
        #region Data
        private UIElement _attachedElement;
        private ButtonBase _button;
        private Dictionary<int, Point> _downpoint;
        private int _lasttap;
        #endregion

        public TapBehavior()
        {
            _downpoint = new Dictionary<int, Point>();
            _lasttap = 0;
        }

        #region Events
        public event EventHandler<TapEventArgs> Tap;
        public event EventHandler<TapEventArgs> DoubleTap;
        #endregion

        #region Behaviour Overrides

        protected override void OnAttached()
        {
            base.OnAttached();

            _attachedElement = (UIElement)this.AssociatedObject;

            // Using this here logic, the behavior will hook nicely into any Button object you attach it to,
            // OR you can attach it to the root of a control template of a button. Fancy.
            if (_attachedElement is ButtonBase)
                _button = _attachedElement as ButtonBase;
            else
                _button = VisualTreeHelper.GetParent(((FrameworkElement)_attachedElement)) as ButtonBase;

            _attachedElement.StylusDown += OnStylusStuff;
            _attachedElement.StylusMove += OnStylusStuff;
            _attachedElement.StylusUp += OnStylusStuff;
            if (_button == null)
            {
                _attachedElement.MouseDown += OnMouseStuff;
                _attachedElement.MouseMove += OnMouseStuff;
                _attachedElement.MouseUp += OnMouseStuff;
            }
        }

        protected override void OnDetaching()
        {
            _attachedElement.StylusDown -= OnStylusStuff;
            _attachedElement.StylusMove -= OnStylusStuff;
            _attachedElement.StylusUp -= OnStylusStuff;
            if (_button == null)
            {
                _attachedElement.MouseDown -= OnMouseStuff;
                _attachedElement.MouseMove -= OnMouseStuff;
                _attachedElement.MouseUp -= OnMouseStuff;
            }

            base.OnDetaching();
        }
        #endregion

        #region Dependency Properties

        #region Threshold

        public static readonly DependencyProperty ThresholdProperty =
            DependencyProperty.Register("Threshold", typeof(double), typeof(TapBehavior),
            new PropertyMetadata(20.0));

        public double Threshold
        {
            get { return (double)GetValue(ThresholdProperty); }
            set { SetValue(ThresholdProperty, value); }
        }

        #endregion

        #region DoubleTapDelay

        public static readonly DependencyProperty DoubleTapDelayProperty =
            DependencyProperty.Register("DoubleTapDelay", typeof(TimeSpan), typeof(TapBehavior),
            new PropertyMetadata(TimeSpan.FromMilliseconds(300)));

        public TimeSpan DoubleTapDelay
        {
            get { return (TimeSpan)GetValue(DoubleTapDelayProperty); }
            set { SetValue(DoubleTapDelayProperty, value); }
        }

        #endregion

        #region IsPressed

        public static bool GetIsPressed(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsPressedProperty);
        }

        public static void SetIsPressed(DependencyObject obj, bool value)
        {
            obj.SetValue(IsPressedProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsPressed.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPressedProperty =
            DependencyProperty.RegisterAttached("IsPressed", typeof(bool), typeof(TapBehavior), new UIPropertyMetadata(false));

        #endregion

        #endregion

        #region Internal


        internal static void ExecuteCommandSource(ICommandSource commandSource)
        {
            ICommand command = commandSource.Command;
            if (command != null)
            {
                object commandParameter = commandSource.CommandParameter;
                IInputElement commandTarget = commandSource.CommandTarget;
                RoutedCommand command2 = command as RoutedCommand;
                if (command2 != null)
                {
                    if (commandTarget == null)
                    {
                        commandTarget = commandSource as IInputElement;
                    }
                    if (command2.CanExecute(commandParameter, commandTarget))
                    {
                        command2.Execute(commandParameter, commandTarget);
                    }
                }
                else if (command.CanExecute(commandParameter))
                {
                    command.Execute(commandParameter);
                }
            }
        }


        private void OnStylusStuff(object sender, StylusEventArgs args)
        {
            if (args.RoutedEvent == UIElement.StylusUpEvent || 
                (args.RoutedEvent == UIElement.StylusDownEvent && args.Source == null) ||
                (args.RoutedEvent == UIElement.StylusMoveEvent && args.Source == null && args.InAir))
            {
                MultitouchWindow.RemoveStylusListener(args.StylusDevice, _attachedElement, OnStylusStuff);

                if (!_downpoint.ContainsKey(args.StylusDevice.Id)) return;

                //if (args.OriginalSource != _attachedElement) return;

                args.Handled = true;

                Point current = args.GetPosition(args.Device.ActiveSource.RootVisual as IInputElement);
                Vector jitter = Point.Subtract(current, _downpoint[args.StylusDevice.Id]);
                if (jitter.Length < Threshold)
                {
                    if (Tap != null)
                        Tap.Invoke(_attachedElement, new TapEventArgs(args.StylusDevice, jitter));

                    if (_button != null)
                    {
                        _button.SetValue(TapBehavior.IsPressedProperty, true);
                        _button.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                        ExecuteCommandSource(_button);
                        
                    }

                    if ((args.Timestamp - _lasttap) < DoubleTapDelay.TotalMilliseconds && DoubleTap != null)
                        DoubleTap.Invoke(_attachedElement, new TapEventArgs(args.StylusDevice, jitter));

                    if (_attachedElement is Control)
                        ((Control)_attachedElement).RaiseEvent(
                            new MouseButtonEventArgs(Mouse.PrimaryDevice, args.Timestamp,
                                MouseButton.Left, args.StylusDevice) { RoutedEvent = Control.MouseDoubleClickEvent });

                    _lasttap = args.Timestamp;
                }
            }
            else if (args.RoutedEvent == UIElement.StylusDownEvent)
            {
                MultitouchWindow.AddStylusListener(args.StylusDevice, _attachedElement, OnStylusStuff);
                _downpoint[args.StylusDevice.Id] = args.GetPosition(args.Device.ActiveSource.RootVisual as IInputElement);
               
                if (_button != null)
                    _button.SetValue(TapBehavior.IsPressedProperty, true);
            }
            else if (args.RoutedEvent == UIElement.StylusMoveEvent)
            {
                if (!_downpoint.ContainsKey(args.StylusDevice.Id)) return;

                Point current = args.GetPosition(args.Device.ActiveSource.RootVisual as IInputElement);
                if (Point.Subtract(current, _downpoint[args.StylusDevice.Id]).Length > Threshold)
                {
                    _downpoint.Remove(args.StylusDevice.Id);

                    if (_button != null)
                        _button.SetValue(TapBehavior.IsPressedProperty, false);
                }
            }
        }

        private void OnMouseStuff(object sender, MouseEventArgs args)
        {
            if (args.RoutedEvent == UIElement.MouseUpEvent ||
                (args.RoutedEvent == UIElement.MouseLeftButtonDownEvent && args.Source == null) ||
                (args.RoutedEvent == UIElement.MouseMoveEvent && args.Source == null && args.LeftButton == MouseButtonState.Released))
            {
                MultitouchWindow.RemoveMouseListener(_attachedElement, OnMouseStuff);

                if (!_downpoint.ContainsKey(-1)) return;

                //if (args.OriginalSource != _attachedElement) return;

                args.Handled = true;

                Point current = args.GetPosition(args.Device.ActiveSource.RootVisual as IInputElement);
                Vector jitter = Point.Subtract(current, _downpoint[-1]);
                if (jitter.Length < Threshold )
                {
                    if(Tap != null)
                        Tap.Invoke(_attachedElement, new TapEventArgs(args.MouseDevice, jitter));

                    if (args.Timestamp - _lasttap < DoubleTapDelay.TotalMilliseconds && DoubleTap != null)
                        DoubleTap.Invoke(_attachedElement, new TapEventArgs(args.MouseDevice, jitter));

                    if (_attachedElement is Control)
                        ((Control)_attachedElement).RaiseEvent(
                            new MouseButtonEventArgs(args.MouseDevice, args.Timestamp, 
                                ((MouseButtonEventArgs)args).ChangedButton) 
                                { RoutedEvent = Control.MouseDoubleClickEvent });

                    _lasttap = args.Timestamp;
                }
            }
            else if (args.RoutedEvent == UIElement.MouseDownEvent)
            {
                MultitouchWindow.AddMouseListener(_attachedElement, OnMouseStuff);
                _downpoint[-1] = args.GetPosition(args.Device.ActiveSource.RootVisual as IInputElement);
            }
            else if (args.RoutedEvent == UIElement.MouseMoveEvent)
            {
                if (!_downpoint.ContainsKey(-1)) return;

                Point current = args.GetPosition(args.Device.ActiveSource.RootVisual as IInputElement);
                if (Point.Subtract(current, _downpoint[-1]).Length > Threshold)
                    _downpoint.Remove(-1);
            }
        }

        #endregion

    }
}
