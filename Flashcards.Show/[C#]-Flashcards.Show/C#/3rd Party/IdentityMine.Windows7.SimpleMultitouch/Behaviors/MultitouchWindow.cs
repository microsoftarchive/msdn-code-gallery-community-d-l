using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Interactivity;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System;
using System.Collections.Generic;
using Windows7.Multitouch;
using System.Collections.ObjectModel;


namespace IdentityMine.Windows.SimpleMultitouch
{
    /// <summary>
    /// Empowers a standard WPF window to handle multitouch input through the Stylus API.
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

        [Flags]
        private enum TabletFlags : uint
        {
            DisablePressAndHold      = 0x00000001,
            DisablePenTapFeedback    = 0x00000008,
            DisablePenBarrelFeedback = 0x00000010,
            DisableTouchUIForceOn    = 0x00000100,
            DisableTouchUIForceOff   = 0x00000200,
            DisableTouchSwitch       = 0x00008000,
            DisableFlicks            = 0x00010000,
            EnableMultitouchData     = 0x01000000,
        }

        [DllImport("user32")]
        private static extern bool SetProp(IntPtr hWnd, string lpString, TabletFlags hData);

        [DllImport("user32")]
        private static extern bool RegisterTouchWindow(System.IntPtr hWnd, TouchWindowFlag flags);

        #endregion

        #region Definitions

        private enum ListenerState
        {
            Normal,
            Marked,
            Removed
        };

        private class MouseListenerData : IDisposable
        {
            static public bool InListener = false;
            private UIElement _target;
            public Action<UIElement,MouseEventArgs> Callback;
            public ListenerState State;

            public MouseListenerData(UIElement el)
            {
                State = ListenerState.Marked;

                _target = el;
                _target.PreviewMouseLeftButtonDown += Handler;
                _target.PreviewMouseLeftButtonUp += Handler;
                _target.PreviewMouseMove += Handler;
                _target.PreviewMouseRightButtonDown += Handler;
                _target.PreviewMouseRightButtonUp += Handler;
                _target.PreviewMouseWheel += Handler;
                _target.PreviewMouseDown += Handler;
                _target.PreviewMouseUp += Handler;
            }

            private void Handler(object sender, MouseEventArgs args)
            {
                if (State == ListenerState.Normal) State = ListenerState.Marked;
            }
        
            public void  Dispose()
            {
                _target.PreviewMouseLeftButtonDown -= Handler;
                _target.PreviewMouseLeftButtonUp -= Handler;
                _target.PreviewMouseMove -= Handler;
                _target.PreviewMouseRightButtonDown -= Handler;
                _target.PreviewMouseRightButtonUp -= Handler;
                _target.PreviewMouseWheel -= Handler;
                _target.PreviewMouseDown -= Handler;
                _target.PreviewMouseUp -= Handler;
            }
        }

        private class StylusListenerData : IDisposable
        {
            static public bool InListener = false;
            private UIElement _target;
            public Action<object,StylusEventArgs> Callback;
            public ListenerState State;

            public StylusListenerData(UIElement el)
            {
                State = ListenerState.Marked;

                _target = el;
                _target.PreviewStylusButtonDown += Handler;
                _target.PreviewStylusButtonUp += Handler;
                _target.PreviewStylusDown += Handler;
                _target.PreviewStylusInAirMove += Handler;
                _target.PreviewStylusInRange += Handler;
                _target.PreviewStylusMove += Handler;
                _target.PreviewStylusOutOfRange += Handler;
                _target.PreviewStylusSystemGesture += Handler;
                _target.PreviewStylusUp += Handler;
            }

            private void Handler(object sender, StylusEventArgs args)
            {
                if (State == ListenerState.Normal) State = ListenerState.Marked;
            }
        
            public void  Dispose()
            {
                _target.PreviewStylusButtonDown -= Handler;
                _target.PreviewStylusButtonUp -= Handler;
                _target.PreviewStylusDown -= Handler;
                _target.PreviewStylusInAirMove -= Handler;
                _target.PreviewStylusInRange -= Handler;
                _target.PreviewStylusMove -= Handler;
                _target.PreviewStylusOutOfRange -= Handler;
                _target.PreviewStylusSystemGesture -= Handler;
                _target.PreviewStylusUp -= Handler;
            }
        }

        #endregion

        #region Data
        private static SortedDictionary<int, List<IPhysicalObject>> _manipulationstack = new SortedDictionary<int, List<IPhysicalObject>>();
        private static SortedDictionary<int, Point> _lastknownpositions = new SortedDictionary<int, Point>();
        private WindowInteropHelper wrapper;
        private Window attachedElement;
        private static SortedDictionary<int, IInputElement> capturemap;
        private static IInputElement mousecapture;
        private static SortedDictionary<int, Dictionary<UIElement, StylusListenerData>> listenmap;
        private static Dictionary<UIElement, MouseListenerData> mouselisteners;
        private SortedDictionary<int, bool> stylusdown;
        protected bool _rerouting;
        private static Action _stylusremove;
        private static Action _mouseremove;
        private static bool _hassyscapture;
        #endregion

        public MultitouchWindow()
        {
            capturemap = new SortedDictionary<int, IInputElement>();
            listenmap = new SortedDictionary<int, Dictionary<UIElement, StylusListenerData>>();
            mouselisteners = new Dictionary<UIElement, MouseListenerData>();
            stylusdown = new SortedDictionary<int, bool>();
        }

        #region Behaviour Overrides

        protected override void OnAttached()
        {
            attachedElement = (Window)this.AssociatedObject;

            attachedElement.PreviewStylusDown += (s, e) =>
                GenericStylusEventHandler(UIElement.PreviewStylusDownEvent, UIElement.StylusDownEvent, e,
                new StylusDownEventArgs(e.StylusDevice, e.Timestamp));

            attachedElement.PreviewStylusButtonDown += (s,e) =>
                GenericStylusEventHandler(UIElement.PreviewStylusButtonDownEvent, UIElement.StylusButtonDownEvent, e,
                new StylusButtonEventArgs(e.StylusDevice, e.Timestamp, e.StylusButton));

            attachedElement.PreviewStylusButtonUp += (s,e) =>
                GenericStylusEventHandler(UIElement.PreviewStylusButtonUpEvent, UIElement.StylusButtonUpEvent, e,
                new StylusButtonEventArgs(e.StylusDevice, e.Timestamp, e.StylusButton));

            attachedElement.PreviewStylusMove += (s,e) =>
                GenericStylusEventHandler(UIElement.PreviewStylusMoveEvent, UIElement.StylusMoveEvent, e,
                new StylusEventArgs(e.StylusDevice, e.Timestamp));

            attachedElement.PreviewStylusUp += (s,e) =>
                GenericStylusEventHandler(UIElement.PreviewStylusUpEvent, UIElement.StylusUpEvent, e,
                new StylusEventArgs(e.StylusDevice, e.Timestamp));

            attachedElement.PreviewStylusInAirMove += (s,e) =>
                GenericStylusEventHandler(UIElement.PreviewStylusInAirMoveEvent, UIElement.StylusInAirMoveEvent, e,
                new StylusEventArgs(e.StylusDevice, e.Timestamp));

            attachedElement.PreviewStylusInRange += (s,e) =>
                GenericStylusEventHandler(UIElement.PreviewStylusInRangeEvent, UIElement.StylusInRangeEvent, e,
                new StylusEventArgs(e.StylusDevice, e.Timestamp));

            attachedElement.PreviewStylusOutOfRange += (s,e) =>
                GenericStylusEventHandler(UIElement.PreviewStylusOutOfRangeEvent, UIElement.StylusOutOfRangeEvent, e,
                new StylusEventArgs(e.StylusDevice, e.Timestamp));

            attachedElement.PreviewStylusSystemGesture += (s, e) => { e.Handled = true; };
                //GenericStylusEventHandler(UIElement.PreviewStylusSystemGestureEvent, UIElement.StylusSystemGestureEvent, e,
                //new StylusSystemGestureEventArgs(e.StylusDevice, e.Timestamp, SystemGesture. e.SystemGesture));

            attachedElement.PreviewMouseDown += (s,e) =>
                GenericMouseEventHandler(UIElement.PreviewMouseDownEvent, UIElement.MouseDownEvent, e,
                new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton));

            attachedElement.PreviewMouseDoubleClick += (s,e) =>
                GenericMouseEventHandler(Control.PreviewMouseDoubleClickEvent, Control.MouseDoubleClickEvent, e,
                new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton));

            attachedElement.PreviewMouseLeftButtonDown += (s,e) =>
                GenericMouseButtonEventHandler(
                UIElement.PreviewMouseLeftButtonDownEvent,
                UIElement.MouseLeftButtonDownEvent,
                true, e,
                new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton));

            attachedElement.PreviewMouseLeftButtonUp += (s,e) =>
                GenericMouseButtonEventHandler(
                UIElement.PreviewMouseLeftButtonUpEvent,
                UIElement.MouseLeftButtonUpEvent,
                false, e,
                new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton));

            attachedElement.PreviewMouseMove += (s,e) =>
                GenericMouseEventHandler(UIElement.PreviewMouseMoveEvent, UIElement.MouseMoveEvent, e,
                new MouseEventArgs(e.MouseDevice, e.Timestamp, e.StylusDevice));

            attachedElement.PreviewMouseRightButtonDown += (s,e) =>
                GenericMouseButtonEventHandler(
                UIElement.PreviewMouseRightButtonDownEvent,
                UIElement.MouseRightButtonDownEvent,
                true, e,
                new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton));

            attachedElement.PreviewMouseRightButtonUp += (s,e) =>
                GenericMouseButtonEventHandler(
                UIElement.PreviewMouseRightButtonUpEvent,
                UIElement.MouseRightButtonUpEvent,
                false, e,
                new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton));

            attachedElement.PreviewMouseUp += (s,e) =>
                GenericMouseEventHandler(UIElement.PreviewMouseUpEvent, UIElement.MouseUpEvent, e,
                new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton));

            attachedElement.PreviewMouseWheel += (s, e) =>
                GenericMouseEventHandler(UIElement.PreviewMouseWheelEvent, UIElement.MouseWheelEvent, e,
                new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta));

            // For numeric stability, physical simulation needs to be handled at the window level.
            attachedElement.PreviewMouseMove += (s, e) => 
                ApplyPhysics(-1,
                (Func<IInputElement, Point>)delegate(IInputElement obj) { return e.GetPosition(obj); });

            attachedElement.PreviewStylusMove += (s, e) =>
                ApplyPhysics(e.StylusDevice.Id,
                (Func<IInputElement, Point>)delegate(IInputElement obj) { return e.GetPosition(obj); });

            if (attachedElement.IsActive)
                attachedElement_Activated(attachedElement, new EventArgs());
            else
                attachedElement.Activated += attachedElement_Activated;
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

        public static void AddStylusListener(StylusDevice stylus, UIElement target, Action<object,StylusEventArgs> callback)
        {
            Dictionary<UIElement, StylusListenerData> map;
            StylusListenerData data;

            if (!listenmap.ContainsKey(stylus.Id))
                listenmap[stylus.Id] = map = new Dictionary<UIElement, StylusListenerData>();
            else
                map = listenmap[stylus.Id];

            if (!map.ContainsKey(target))
            {
                if (StylusListenerData.InListener)
                    throw new InvalidOperationException("Listeners cannot be added in response to another listener.");

                map[target] = data = new StylusListenerData(target);
            }
            else
                data = map[target];

            data.Callback += callback;
        }

        public static void RemoveStylusListener(StylusDevice stylus, UIElement target, Action<object, StylusEventArgs> callback)
        {
            Action next = _stylusremove;

            Action act = delegate()
            {
                Dictionary<UIElement, StylusListenerData> map;
                StylusListenerData data;

                if (!listenmap.ContainsKey(stylus.Id))
                    return;

                map = listenmap[stylus.Id];

                if (!map.ContainsKey(target))
                    return;

                data = map[target];

                data.Callback -= callback;

                if (data.Callback == null)
                {
                    data.Dispose();
                    map.Remove(target);
                }

                if (next != null) next();
                else _stylusremove = null;
            };

            if (StylusListenerData.InListener)
                _stylusremove = act;
            else
                act();
        }

        public static void AddMouseListener(UIElement target, Action<UIElement,MouseEventArgs> callback)
        {
            MouseListenerData data;

            if (!mouselisteners.ContainsKey(target))
            {
                if (MouseListenerData.InListener)
                    throw new InvalidOperationException("Listeners cannot be added in response to another listener.");

                mouselisteners[target] = data = new MouseListenerData(target);
            }
            else
                data = mouselisteners[target];

            data.Callback += callback;
        }

        public static void RemoveMouseListener(UIElement target, Action<UIElement,MouseEventArgs> callback)
        {
            MouseListenerData data;
            Action next = _mouseremove;

            Action act = delegate()
            {
                if (!mouselisteners.ContainsKey(target))
                    return;

                data = mouselisteners[target];

                data.Callback -= callback;

                if (data.Callback == null)
                {
                    data.Dispose();
                    mouselisteners.Remove(target);
                }

                if (next != null) next();
                else
                {
                    _mouseremove = null;
                }
            };

            if (MouseListenerData.InListener)
                _mouseremove = act;
            else
                act();
        }

        public static void PushPhysicalReferenceFrame(InputDevice device, IPhysicalObject obj)
        {
            int id = 0;

            if (device is MouseDevice)
            {
                id = -1;
                _lastknownpositions[id] = ((MouseDevice)device).GetPosition(device.ActiveSource.RootVisual as IInputElement);
            }
            if (device is StylusDevice)
            {
                id = ((StylusDevice)device).Id;
                _lastknownpositions[id] = ((StylusDevice)device).GetPosition(device.ActiveSource.RootVisual as IInputElement);
            }

            if (!_manipulationstack.ContainsKey(id))
                _manipulationstack[id] = new List<IPhysicalObject>();

            _manipulationstack[id].Add(obj);
        }

        public static void ClearPhysicalReferenceFrame(InputDevice device)
        {
            int id = 0;

            if (device is MouseDevice)
                id = -1;
            if (device is StylusDevice)
                id = ((StylusDevice)device).Id;

            if(_manipulationstack.ContainsKey(id))
                _manipulationstack[id].Clear();
        }

        #endregion

        #region Internal

        void attachedElement_Activated(object sender, EventArgs e)
        {
            wrapper = new WindowInteropHelper(attachedElement);

            // Set the window property to enable multitouch input on inking context.
            SetProp(wrapper.Handle, "MicrosoftTabletPenServiceProperty", TabletFlags.EnableMultitouchData | TabletFlags.DisablePressAndHold | TabletFlags.DisableFlicks | TabletFlags.DisablePenTapFeedback | TabletFlags.DisablePenBarrelFeedback);
            if(System.Environment.OSVersion.Version.Major >= 7)
                RegisterTouchWindow(wrapper.Handle, TouchWindowFlag.FineTouch);

            attachedElement.Activated -= attachedElement_Activated;
        }

        void RaiseMouseListener(MouseEventArgs args)
        {
            MouseListenerData.InListener = true;
            object src = args.Source;
            args.Source = null;
            foreach (KeyValuePair<UIElement, MouseListenerData> data in mouselisteners)
                if (data.Value.State == ListenerState.Normal && !args.Handled)
                    data.Value.Callback(data.Key, args);
            MouseListenerData.InListener = false;
            args.Source = src;
        }

        void UnmarkMouseListeners()
        {
            if (_mouseremove != null) _mouseremove();

            foreach (MouseListenerData data in mouselisteners.Values)
                data.State = ListenerState.Normal;
        }

        void RaiseStylusListener(StylusEventArgs args)
        {
            if (!listenmap.ContainsKey(args.StylusDevice.Id)) return;

            object src = args.Source;
            args.Source = null;
            StylusListenerData.InListener = true;
            foreach (KeyValuePair<UIElement, StylusListenerData> data in listenmap[args.StylusDevice.Id])
                if (data.Value.State == ListenerState.Normal && !args.Handled)
                    data.Value.Callback(data.Key, args);
            StylusListenerData.InListener = false;
            args.Source = src;
        }

        void UnmarkStylusListeners(int i)
        {
            if (_stylusremove != null) _stylusremove();

            if(listenmap.ContainsKey(i))
                foreach (StylusListenerData data in listenmap[i].Values)
                    data.State = ListenerState.Normal;
        }

        virtual protected void GenericMouseEventHandler(
            RoutedEvent previewevent, 
            RoutedEvent finalevent, 
            MouseEventArgs e, 
            MouseEventArgs clone)
        {
            if (e.StylusDevice != null)
            {
                e.Handled = true;
                return;
            }
            if (_rerouting) return;

            IInputElement target = (mousecapture == null) ? (IInputElement)e.OriginalSource : mousecapture;

            _rerouting = true;
            clone.RoutedEvent = previewevent;
            clone.Source = e.Source;
            UnmarkMouseListeners();
            target.RaiseEvent(clone);
            RaiseMouseListener(clone);
            clone.RoutedEvent = finalevent;
            RaiseMouseListener(clone);
            target.RaiseEvent(clone);
            _rerouting = false;
            e.Handled = true;
        }

        virtual protected void GenericMouseButtonEventHandler(
            RoutedEvent previewevent, 
            RoutedEvent finalevent, 
            bool isdownnotup, 
            MouseButtonEventArgs e, 
            MouseButtonEventArgs clone)
        {
            if (e.StylusDevice != null)
            {
                e.Handled = true;
                return;
            }
            if (_rerouting) return;

            IInputElement target = (mousecapture == null) ? (IInputElement)e.OriginalSource : mousecapture;

            _rerouting = true;
            clone.RoutedEvent = previewevent;
            clone.Source = e.Source;
            UnmarkMouseListeners();
            //target.RaiseEvent(clone);
            //RaiseMouseListener(clone);
            clone.RoutedEvent = (isdownnotup ? UIElement.PreviewMouseDownEvent : UIElement.PreviewMouseUpEvent);
            target.RaiseEvent(clone);
            RaiseMouseListener(clone);
            //clone.RoutedEvent = finalevent;
            //RaiseMouseListener(clone);
            //target.RaiseEvent(clone);
            clone.RoutedEvent = (isdownnotup ? UIElement.MouseDownEvent : UIElement.MouseUpEvent);
            RaiseMouseListener(clone);
            target.RaiseEvent(clone);
            e.Handled = true;
            _rerouting = false;
        }

        virtual protected void GenericStylusEventHandler(RoutedEvent previewevent, RoutedEvent finalevent, StylusEventArgs e, StylusEventArgs clone)
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
            UnmarkStylusListeners(e.StylusDevice.Id);
            target.RaiseEvent(clone); 
            RaiseStylusListener(clone);
            clone.RoutedEvent = finalevent;
            target.RaiseEvent(clone);
            RaiseStylusListener(clone);
            _rerouting = false;
            e.Handled = true;
        }

        private void ApplyPhysics(int id, Func<IInputElement, Point> getposition)
        {
            if (!_manipulationstack.ContainsKey(id) || _manipulationstack[id].Count == 0) return;

            List<IPhysicalObject> stack = _manipulationstack[id];
            IPhysicalObject original = stack[stack.Count - 1];

            // Call Apply on the physical object. Pass the point and retrieve the unhandled vector.
            original.SetPoint(id, attachedElement.TransformToDescendant(original.ContainerVisual).Transform(_lastknownpositions[id]));
            Vector delta = original.ApplyManipulation(id, getposition(original.ContainerVisual));
            _lastknownpositions[id] = getposition(attachedElement);

            // while there are parent physical containers...
            for(int i = stack.Count - 2;i >= 0;i--)
            {
                IPhysicalObject parent = stack[i];

                // Find the touch point on the parent
                Point pt = getposition(parent.ContainerVisual);

                Matrix m = ((Transform)original.ContainerVisual.TransformToAncestor(parent.ContainerVisual)).Value;

                m.OffsetX = 0;
                m.OffsetY = 0;

                parent.SetPoint(id, pt + m.Transform(delta));

                // Find the transform from original to the parent.
                // Transform the parent-adjusted point to parent space
                // Call Apply on parent
                delta = parent.ApplyManipulation(id, pt);

                // original = parent
                original = parent;
            }
        }

        #endregion
    }
}