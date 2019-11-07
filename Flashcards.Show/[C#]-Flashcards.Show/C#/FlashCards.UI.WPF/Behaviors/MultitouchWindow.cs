using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Expression.Interactivity;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System;
using System.Collections.Generic;
using Windows7.Multitouch;


namespace FlashCardUI.Behaviors
{
    /// <summary>
    /// A Inertia Enabled Scroll Behavior to apply to a scrollviewer
    /// </summary>
    public class MultitouchWindow : Behavior<Window>
    {
        #region Interop

        public enum TouchWindowFlag : uint
        {
            None = 0x0,
            FineTouch = 0x1,
            WantPalm = 0x2
        }
        
        [DllImport("user32")]
        private static extern bool SetProp(IntPtr hWnd, string lpString, IntPtr hData);

        [DllImport("user32")]
        private static extern bool RegisterTouchWindow(System.IntPtr hWnd, TouchWindowFlag flags);

        #endregion

        #region Data
        private WindowInteropHelper wrapper;
        private Window attachedElement;
        private static Dictionary<int, IInputElement> capturemap;
        private static IInputElement mousecapture;
        private bool _rerouting;
        #endregion

        public MultitouchWindow()
        {
            capturemap = new Dictionary<int, IInputElement>();
        }

        #region Behaviour Overrides

        protected override void OnAttached()
        {
            attachedElement = (Window)this.AssociatedObject;
            attachedElement.PreviewStylusDown += new StylusDownEventHandler(attachedElement_PreviewStylusDown);
            attachedElement.PreviewStylusButtonDown += new StylusButtonEventHandler(attachedElement_PreviewStylusButtonDown);
            attachedElement.PreviewStylusButtonUp += new StylusButtonEventHandler(attachedElement_PreviewStylusButtonUp);
            attachedElement.PreviewStylusMove += new StylusEventHandler(attachedElement_PreviewStylusMove);
            attachedElement.PreviewStylusUp += new StylusEventHandler(attachedElement_PreviewStylusUp);
            attachedElement.PreviewStylusInAirMove += new StylusEventHandler(attachedElement_PreviewStylusInAirMove);
            attachedElement.PreviewStylusInRange += new StylusEventHandler(attachedElement_PreviewStylusInRange);
            attachedElement.PreviewStylusOutOfRange += new StylusEventHandler(attachedElement_PreviewStylusOutOfRange);
            attachedElement.PreviewStylusSystemGesture += new StylusSystemGestureEventHandler(attachedElement_PreviewStylusSystemGesture);

            attachedElement.StylusButtonDown += new StylusButtonEventHandler(attachedElement_StylusButtonDown);
            attachedElement.StylusButtonUp += new StylusButtonEventHandler(attachedElement_StylusButtonUp);
            attachedElement.StylusDown += new StylusDownEventHandler(attachedElement_StylusDown);
            attachedElement.StylusEnter += new StylusEventHandler(attachedElement_StylusEnter);
            attachedElement.StylusInAirMove += new StylusEventHandler(attachedElement_StylusInAirMove);
            attachedElement.StylusInRange += new StylusEventHandler(attachedElement_StylusInRange);
            attachedElement.StylusLeave += new StylusEventHandler(attachedElement_StylusLeave);
            attachedElement.StylusMove += new StylusEventHandler(attachedElement_StylusMove);
            attachedElement.StylusOutOfRange += new StylusEventHandler(attachedElement_StylusOutOfRange);
            attachedElement.StylusSystemGesture += new StylusSystemGestureEventHandler(attachedElement_StylusSystemGesture);
            attachedElement.StylusUp += new StylusEventHandler(attachedElement_StylusUp);

            attachedElement.PreviewMouseDown += new MouseButtonEventHandler(attachedElement_PreviewMouseDown);
            attachedElement.PreviewMouseDoubleClick += new MouseButtonEventHandler(attachedElement_PreviewMouseDoubleClick);
            attachedElement.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(attachedElement_PreviewMouseLeftButtonDown);
            attachedElement.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(attachedElement_PreviewMouseLeftButtonUp);
            attachedElement.PreviewMouseMove += new MouseEventHandler(attachedElement_PreviewMouseMove);
            attachedElement.PreviewMouseRightButtonDown += new MouseButtonEventHandler(attachedElement_PreviewMouseRightButtonDown);
            attachedElement.PreviewMouseRightButtonUp += new MouseButtonEventHandler(attachedElement_PreviewMouseRightButtonUp);
            attachedElement.PreviewMouseUp += new MouseButtonEventHandler(attachedElement_PreviewMouseUp);
            attachedElement.PreviewMouseWheel += new MouseWheelEventHandler(attachedElement_PreviewMouseWheel);

            if (attachedElement.IsActive)
            {
                wrapper = new WindowInteropHelper(attachedElement);

                // Set the window property to enable multitouch input on inking context.
                SetProp(wrapper.Handle, "MicrosoftTabletPenServiceProperty", new IntPtr(0x01000000));
                RegisterTouchWindow(wrapper.Handle, TouchWindowFlag.FineTouch);
            }
            else
            {
                attachedElement.Activated += (s, e) => 
                {
                    if (wrapper == null)
                    {
                        wrapper = new WindowInteropHelper(attachedElement);

                        // Set the window property to enable multitouch input on inking context.
                        SetProp(wrapper.Handle, "MicrosoftTabletPenServiceProperty", new IntPtr(0x01000000));
                        RegisterTouchWindow(wrapper.Handle, TouchWindowFlag.FineTouch);
                    }
                };
            }
        }

        protected override void OnDetaching()
        {
            attachedElement = null;

            base.OnDetaching();
        }

        #endregion

        #region Methods

        public static void SafeCaptureStylus(StylusDevice stylus, IInputElement target)
        {
            if (target != null)
                capturemap[stylus.Id] = target;
            else
                capturemap.Remove(stylus.Id);
            
        }

        public static void SafeCaptureMouse(IInputElement target)
        {
            mousecapture = target;
        }

        #endregion

        #region Internal

        void attachedElement_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            GenericMouseEventHandler(UIElement.PreviewMouseWheelEvent, UIElement.MouseWheelEvent, e,
                new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta));
        }

        void attachedElement_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            GenericMouseEventHandler(UIElement.PreviewMouseUpEvent, UIElement.MouseUpEvent, e,
                new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton));
        }

        void attachedElement_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            GenericMouseButtonEventHandler(
                UIElement.PreviewMouseRightButtonUpEvent, 
                UIElement.MouseRightButtonUpEvent, 
                false, e,
                new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton));
        }

        void attachedElement_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            GenericMouseButtonEventHandler(
                UIElement.PreviewMouseRightButtonDownEvent, 
                UIElement.MouseRightButtonDownEvent, 
                true, e,
                new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton));
        }

        void attachedElement_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            GenericMouseEventHandler(UIElement.PreviewMouseMoveEvent, UIElement.MouseMoveEvent, e,
                new MouseEventArgs(e.MouseDevice, e.Timestamp, e.StylusDevice));
        }

        void attachedElement_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GenericMouseButtonEventHandler(
                UIElement.PreviewMouseLeftButtonUpEvent, 
                UIElement.MouseLeftButtonUpEvent,
                false, e,
                new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton));
        }

        void attachedElement_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GenericMouseButtonEventHandler(
                UIElement.PreviewMouseLeftButtonDownEvent, 
                UIElement.MouseLeftButtonDownEvent, 
                true, e,
                new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton));
        }

        void attachedElement_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            GenericMouseEventHandler(Control.PreviewMouseDoubleClickEvent, Control.MouseDoubleClickEvent, e,
                new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton));
        }

        void attachedElement_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            GenericMouseEventHandler(UIElement.PreviewMouseDownEvent, UIElement.MouseDownEvent, e,
                new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton));
        }

        void attachedElement_StylusUp(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        void attachedElement_StylusSystemGesture(object sender, StylusSystemGestureEventArgs e)
        {
            e.Handled = true;
        }

        void attachedElement_StylusOutOfRange(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        void attachedElement_StylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        void attachedElement_StylusLeave(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        void attachedElement_StylusInRange(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        void attachedElement_StylusInAirMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        void attachedElement_StylusEnter(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        void attachedElement_StylusDown(object sender, StylusDownEventArgs e)
        {
            e.Handled = true;
        }

        void attachedElement_StylusButtonUp(object sender, StylusButtonEventArgs e)
        {
            e.Handled = true;
        }

        void attachedElement_StylusButtonDown(object sender, StylusButtonEventArgs e)
        {
            e.Handled = true;
        }

        void attachedElement_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            GenericStylusEventHandler(UIElement.PreviewStylusUpEvent, UIElement.StylusUpEvent, e,
                new StylusEventArgs(e.StylusDevice, e.Timestamp));
        }

        void attachedElement_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            GenericStylusEventHandler(UIElement.PreviewStylusMoveEvent, UIElement.StylusMoveEvent, e,
                new StylusEventArgs(e.StylusDevice, e.Timestamp));
        }

        void attachedElement_PreviewStylusButtonUp(object sender, StylusButtonEventArgs e)
        {
            GenericStylusEventHandler(UIElement.PreviewStylusButtonUpEvent, UIElement.StylusButtonUpEvent, e,
                new StylusButtonEventArgs(e.StylusDevice, e.Timestamp, e.StylusButton));
        }

        void attachedElement_PreviewStylusButtonDown(object sender, StylusButtonEventArgs e)
        {
            GenericStylusEventHandler(UIElement.PreviewStylusButtonDownEvent, UIElement.StylusButtonDownEvent, e,
                new StylusButtonEventArgs(e.StylusDevice, e.Timestamp, e.StylusButton));
        }

        void attachedElement_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            GenericStylusEventHandler(UIElement.PreviewStylusDownEvent, UIElement.StylusDownEvent, e, 
                new StylusDownEventArgs(e.StylusDevice, e.Timestamp));
        }

        void attachedElement_PreviewStylusSystemGesture(object sender, StylusSystemGestureEventArgs e)
        {
            GenericStylusEventHandler(UIElement.PreviewStylusSystemGestureEvent, UIElement.StylusSystemGestureEvent, e,
                new StylusSystemGestureEventArgs(e.StylusDevice, e.Timestamp, e.SystemGesture));
        }

        void attachedElement_PreviewStylusOutOfRange(object sender, StylusEventArgs e)
        {
            GenericStylusEventHandler(UIElement.PreviewStylusOutOfRangeEvent, UIElement.StylusOutOfRangeEvent, e,
                new StylusEventArgs(e.StylusDevice, e.Timestamp));
        }

        void attachedElement_PreviewStylusInRange(object sender, StylusEventArgs e)
        {
            GenericStylusEventHandler(UIElement.PreviewStylusInRangeEvent, UIElement.StylusInRangeEvent, e,
                new StylusEventArgs(e.StylusDevice, e.Timestamp));
        }

        void attachedElement_PreviewStylusInAirMove(object sender, StylusEventArgs e)
        {
            GenericStylusEventHandler(UIElement.PreviewStylusInAirMoveEvent, UIElement.StylusInAirMoveEvent, e,
                new StylusEventArgs(e.StylusDevice, e.Timestamp));
        }

        void GenericMouseEventHandler(RoutedEvent previewevent, RoutedEvent finalevent, MouseEventArgs e, MouseEventArgs clone)
        {
            if (e.StylusDevice != null)
            {
                e.Handled = true;
                return;
            }
            if (_rerouting) return;

            if (mousecapture != null)
            {
                IInputElement target = mousecapture;

                _rerouting = true;
                clone.RoutedEvent = previewevent;
                clone.Source = e.Source;
                target.RaiseEvent(clone);
                clone.RoutedEvent = finalevent;
                target.RaiseEvent(clone);
                e.Handled = true;
                _rerouting = false;
            }
        }

        void GenericMouseButtonEventHandler(RoutedEvent previewevent, RoutedEvent finalevent, bool isdownnotup, MouseButtonEventArgs e, MouseButtonEventArgs clone)
        {
            if (e.StylusDevice != null)
            {
                e.Handled = true;
                return;
            }
            if (_rerouting) return;

            if (mousecapture != null)
            {
                IInputElement target = mousecapture;

                _rerouting = true;
                clone.RoutedEvent = previewevent;
                clone.Source = e.Source;
                target.RaiseEvent(clone);
                clone.RoutedEvent = (isdownnotup ? UIElement.PreviewMouseDownEvent : UIElement.PreviewMouseUpEvent);
                target.RaiseEvent(clone);
                clone.RoutedEvent = finalevent;
                target.RaiseEvent(clone);
                clone.RoutedEvent = (isdownnotup ? UIElement.MouseDownEvent : UIElement.MouseUpEvent);
                target.RaiseEvent(clone);
                e.Handled = true;
                _rerouting = false;
            }
        }

        void GenericStylusEventHandler(RoutedEvent previewevent, RoutedEvent finalevent, StylusEventArgs e, StylusEventArgs clone)
        {
            if (Mouse.Captured != null)
            {
                e.Handled = true;
                return;
            }
            if (_rerouting) return;

            IInputElement target = capturemap.ContainsKey(e.StylusDevice.Id) ? capturemap[e.StylusDevice.Id] : (IInputElement)e.OriginalSource;

            _rerouting = true;
            clone.RoutedEvent = previewevent;
            clone.Source = e.Source;
            target.RaiseEvent(clone);
            clone.RoutedEvent = finalevent;
            target.RaiseEvent(clone);
            _rerouting = false;
            e.Handled = true;
        }

        #endregion
    }
}
