//-----------------------------------------------------------------------------
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Windows7.Multitouch.Interop;
using System.Reflection;
using System.Threading;
using System.Drawing;

namespace Windows7.Multitouch
{
    /// <summary>
    /// Wrapp HWND source such as System.Windows.Forms.Control, or System.Windows.Window
    /// </summary>
    public interface IHwndWrapper
    {
        /// <summary>
        /// The Underline Windows Handle
        /// </summary>
        IntPtr Handle { get; }

        /// <summary>
        /// The .NET object that wrap the Windows Handle (WinForm, WinForm Control, WPF Window, IntPtr of HWND)
        /// </summary>
        object Source { get; }

        /// <summary>
        /// The Win32 Handle has been created
        /// </summary>
        event EventHandler HandleCreated;

        /// <summary>
        /// /// The Win32 Handle has been destroyed
        /// </summary>
        event EventHandler HandleDestroyed;

        /// <summary>
        /// Check if the Win32 Handle is already created
        /// </summary>
        bool IsHandleCreated { get; }

        /// <summary>
        /// Computes the location of the specified screen point into client coordinates
        /// </summary>
        /// <param name="point">The screen coordinate System.Drawing.Point to convert</param>
        /// <returns>A point that represents the converted point in client coordinates</returns>
        Point PointToClient(Point point);
    }

    /// <summary>
    /// A Common interface foir timer.
    /// The timer has to be in the UI thread context
    /// </summary>
    public interface IGUITimer : IDisposable
    {
        /// <summary>
        /// Gets or sets whether the timer is running.
        /// </summary>
        bool Enabled { get; set; }
        
        /// <summary>
        /// Gets or sets the time, in milliseconds, before the Tick event is raised
        /// </summary>
        int Interval { get; set; }
        
        /// <summary>
        ///   Occurs when the specified timer interval has elapsed and the timer is enabled.
        /// </summary>
        event EventHandler Tick;

        /// <summary>
        /// Starts the timer.
        /// </summary>
        void Start();
        
        /// <summary>
        /// Stops the timer.
        /// </summary>
        void Stop();
    }

    
    /// <summary>
    /// Base class for handling Gesture and Touch event
    /// </summary>
    /// <remarks>
    /// A form can have one handler, either touch handler or gesture handler. 
    /// The form need to create the handler and register to events. 
    /// The code is not thread safe, we assume that the calling thread is the 
    /// UI thread. There is no blocking operation in the code.
    /// </remarks>
    public abstract class Handler
    {
        private readonly IHwndWrapper _hWndWrapper;
        static private List<object> _controlInUse = new List<object>();
        private User32.WindowProcDelegate _windowProcDelegate;
        private IntPtr _originalWindowProcId;
        
        /// <summary>
        /// Initiate touch support for the underline hWnd 
        /// </summary>
        /// <remarks>Registering the hWnd to touch support or configure the hWnd to receive gesture messages</remarks>
        /// <returns>true if succeeded</returns>
        protected abstract bool SetHWndTouchInfo();

        /// <summary>
        /// The interceptor WndProc
        /// </summary>
        /// <param name="hWnd">WndProc hWnd</param>
        /// <param name="msg">WndProc msg</param>
        /// <param name="wparam">WndProc wParam</param>
        /// <param name="lparam">WndProc lPara</param>
        /// <returns>WndProc return</returns>
        public abstract uint WindowProc(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam);

        
        internal static T CreateHandler<T>(IHwndWrapper hWndWrapper) where T : Handler
        {
            if (_controlInUse.Contains(hWndWrapper.Source))
                throw new Exception("Only one handler can be registered for a control.");

            hWndWrapper.HandleDestroyed += (s, e) => _controlInUse.Remove(s);
            _controlInUse.Add(hWndWrapper.Source);

            return Activator.CreateInstance(typeof(T), BindingFlags.CreateInstance | BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.Instance,
                null, new object [] { hWndWrapper }, Thread.CurrentThread.CurrentCulture) as T;
        }


        /// <summary>
        /// We create the hanlder using a factory method.
        /// </summary>
        /// <param name="hWndWrapper">The control or Window that registered for touch/gesture events</param>
        internal Handler(IHwndWrapper hWndWrapper)
        {
            _hWndWrapper = hWndWrapper;

            if (_hWndWrapper.IsHandleCreated)
                Initialize();
            else
                _hWndWrapper.HandleCreated += (s, e) => Initialize();

        }

        /// <summary>
        /// Connect the handler to the Control
        /// </summary>
        /// <remarks>
        /// The trick is to subclass the Control and intercept touch/gesture events, then reflect
        /// them back to the control.
        /// </remarks>
        private void Initialize()
        {
            if (!SetHWndTouchInfo())
            {
                throw new NotSupportedException("Cannot register window");
            }

            _windowProcDelegate = WindowProcSubClass;

            //According to the SDK doc SetWindowLongPtr should be exported by both 32/64 bit O/S
            //But it does not.
            //_originalWindowProcId = IntPtr.Size == 4 ?
            //    User32.SubclassWindow(_hWndWrapper.Handle, User32.GWLP_WNDPROC, _windowProcDelegate) :
            //    User32.SubclassWindow64(_hWndWrapper.Handle, User32.GWLP_WNDPROC, _windowProcDelegate);

            //take the desktop DPI
            using (Graphics graphics = Graphics.FromHwnd(_hWndWrapper.Handle))
            {
                DpiX = graphics.DpiX;
                DpiY = graphics.DpiY;
            }

            WindowMessage += (s, e) => { };
        }

        /// <summary>
        /// Intercept touch/gesture events using Windows subclassing
        /// </summary>
        /// <param name="hWnd">The hWnd of the registered form</param>
        /// <param name="msg">The WM code</param>
        /// <param name="wparam">The WM WParam</param>
        /// <param name="lparam">The WM LParam</param>
        /// <returns></returns>
        private uint WindowProcSubClass(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam)
        {
            WindowMessage(this, new WMEventArgs(hWnd, msg, wparam, lparam));
            
            if (msg == User32.WM_GESTURENOTIFY && GestureNotify != null)
            {
                GestureNotify(this, new GestureNotifyEventArgs(lparam));
            }
            else
            {

                uint result = WindowProc(hWnd, msg, wparam, lparam);

                if (result != 0)
                    return result;
            }

            return User32.CallWindowProc(_originalWindowProcId, hWnd, msg, wparam, lparam);
        }


        /// <summary>
        /// The registered control wrapper
        /// </summary>
        internal IHwndWrapper HWndWrapper
        {
            get
            {
                return _hWndWrapper;
            }
        }

        /// <summary>
        /// The registered control's handler
        /// </summary>
        protected IntPtr ControlHandle
        {
            get
            {
                return _hWndWrapper.IsHandleCreated ? _hWndWrapper.Handle : IntPtr.Zero;
            }
        }

        /// <summary>
        /// The X DPI of the target window
        /// </summary>
        public float DpiX { get; private set; }

        /// <summary>
        /// The Y DPI of the target window
        /// </summary>
        public float DpiY { get; private set; }

        /// <summary>
        ///  GestureNotify event notifies a window that gesture recognition is
        //   in progress and a gesture will be generated if one is recognized under the
        //   current gesture settings.
        /// </summary>
        public event EventHandler<GestureNotifyEventArgs> GestureNotify;

        /// <summary>
        /// Enable advanced message handling/blocking
        /// </summary>
        internal event EventHandler<WMEventArgs> WindowMessage;

        /// <summary>
        /// Report digitizer capabilities
        /// </summary>
        public static class DigitizerCapabilities
        {
            /// <summary>
            /// Get the current Digitizer Status
            /// </summary>
            public static DigitizerStatus Status
            {
                get
                {
                    return (DigitizerStatus)User32.GetDigitizerCapabilities(User32.DigitizerIndex.SM_DIGITIZER);
                }
            }

            /// <summary>
            /// Get the maximum touches capability
            /// </summary>
            public static int MaxumumTouches
            {
                get
                {
                    return User32.GetDigitizerCapabilities(User32.DigitizerIndex.SM_MAXIMUMTOUCHES);
                }
            }

            /// <summary>
            /// Check for integrated touch support
            /// </summary>
            public static bool IsIntegratedTouch
            {
                get
                {
                    return (Status & DigitizerStatus.IntegratedTouch) != 0;
                }
            }

            /// <summary>
            /// Check for external touch support
            /// </summary>
            public static bool IsExternalTouch
            {
                get
                {
                    return (Status & DigitizerStatus.ExternalTouch) != 0;
                }
            }

            /// <summary>
            /// Check for Pen support
            /// </summary>
            public static bool IsIntegratedPan
            {
                get
                {
                    return (Status & DigitizerStatus.IntegratedPan) != 0;
                }
            }

            /// <summary>
            /// Check for external Pan support
            /// </summary>
            public static bool IsExternalPan
            {
                get
                {
                    return (Status & DigitizerStatus.ExternalPan) != 0;
                }
            }

            /// <summary>
            /// Check for multi-input
            /// </summary>
            public static bool IsMultiInput
            {
                get
                {
                    return (Status & DigitizerStatus.MultiInput) != 0;
                }
            }

            /// <summary>
            /// Check if touch device is ready
            /// </summary>
            public static bool IsStackReady
            {
                get
                {
                    return (Status & DigitizerStatus.StackReady) != 0;
                }
            }

            /// <summary>
            /// Check if Multi-touch support device is ready
            /// </summary>
            public static bool IsMultiTouchReady
            {
                get
                {
                    return (Status & (DigitizerStatus.StackReady | DigitizerStatus.MultiInput)) != 0;
                }
            }
        }

        /// <summary>
        /// Check if the Window is registered for multitouch events
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        public static bool IsTouchWindows(IntPtr hWnd)
        {
            uint cap;
            return User32.IsTouchWindow(hWnd, out cap);
        }
    }

    /// <summary>
    ///  GestureNotify event notifies a window that gesture recognition is
    //   in progress and a gesture will be generated if one is recognized under the
    //   current gesture settings.
    /// </summary>
    public class GestureNotifyEventArgs : EventArgs
    {
        internal GestureNotifyEventArgs(IntPtr lparam)
        {
            User32.GESTURENOTIFYSTRUCT gestureNotify = 
                (User32.GESTURENOTIFYSTRUCT)Marshal.PtrToStructure(lparam, typeof(User32.GESTURENOTIFYSTRUCT));
            
            //TODO: Do we need to be DPI aware also here? 
            Location = new Point(gestureNotify.ptsLocation.x, gestureNotify.ptsLocation.y);
            TargetHwnd = gestureNotify.hwndTarget;
        }

        /// <summary>
        /// The gesture location
        /// </summary>
        public Point Location { get; private set; }

        /// <summary>
        /// The gesture target window
        /// </summary>
        public IntPtr TargetHwnd { get; private set; }
    }

    /// <summary>
    /// Enable advanced message handling/blocking
    /// </summary>
    internal class WMEventArgs : EventArgs
    {
        public WMEventArgs(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam)
        {
            HWnd = hWnd;
            Message = msg;
            WParam = wparam;
            LParam = lparam;
        }

        public IntPtr HWnd { get; private set; }
        public int Message { get; private set; }
        public IntPtr WParam { get; private set; }
        public IntPtr LParam { get; private set; }
    }


#pragma warning disable 1591
    /// <summary>
    /// All availible digitizer capabilities
    /// </summary>
    [Flags]
    public enum DigitizerStatus : byte
    {
        IntegratedTouch = 0x01,
        ExternalTouch = 0x02,
        IntegratedPan = 0x04,
        ExternalPan = 0x08,
        MultiInput = 0x40,
        StackReady = 0x80
    }
}