//-----------------------------------------------------------------------------
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Windows7.Multitouch.Interop;
using System.Drawing;

namespace Windows7.Multitouch
{
    /// <summary>
    /// Handles gesture events
    /// </summary>
    /// <remarks>
    /// The handler simplifies handling gesture such as rotate, zoom and pan 
    /// by keeping the requires knowledge of the previous and first event in 
    /// the gesture event sequence.  
    /// </remarks>
    public class GestureHandler : Handler
    {
        //Simplifying event handling by not dealing with empty event
        private static readonly EventHandler<GestureEventArgs> _emptyFunc = (s,e) => {};

        //Using this map, fireing event is easy
        private readonly Dictionary<uint, EventHandler<GestureEventArgs>> _eventMap =
            new Dictionary<uint, EventHandler<GestureEventArgs>>
            {
                {EventMapID.Begin, _emptyFunc},
                {EventMapID.End, _emptyFunc},
                {EventMapID.PanBegin, _emptyFunc},
                {EventMapID.Pan, _emptyFunc},
                {EventMapID.PanEnd, _emptyFunc},
                {EventMapID.PressAndTap, _emptyFunc},
                {EventMapID.RotateBegin, _emptyFunc},
                {EventMapID.Rotate, _emptyFunc},
                {EventMapID.RotateEnd, _emptyFunc},
                {EventMapID.TwoFingerTap, _emptyFunc},
                {EventMapID.ZoomBegin, _emptyFunc},
                {EventMapID.Zoom, _emptyFunc},
                {EventMapID.ZoomEnd, _emptyFunc}
            };

        //All gesture events
        private static class EventMapID
        {
            public static readonly uint Begin = MapWM2EventId(User32.GID_BEGIN, 0);
            public static readonly uint End = MapWM2EventId(User32.GID_END, 0);
            public static readonly uint PanBegin = MapWM2EventId(User32.GID_PAN, User32.GF_BEGIN);
            public static readonly uint Pan = MapWM2EventId(User32.GID_PAN, 0);
            public static readonly uint PanEnd = MapWM2EventId(User32.GID_PAN, User32.GF_END);
            public static readonly uint PressAndTap = MapWM2EventId(User32.GID_PRESSANDTAP, 0);
            public static readonly uint RotateBegin = MapWM2EventId(User32.GID_ROTATE, User32.GF_BEGIN);
            public static readonly uint Rotate = MapWM2EventId(User32.GID_ROTATE, 0);
            public static readonly uint RotateEnd = MapWM2EventId(User32.GID_ROTATE, User32.GF_END);
            public static readonly uint TwoFingerTap = MapWM2EventId(User32.GID_TWOFINGERTAP, 0);
            public static readonly uint ZoomBegin = MapWM2EventId(User32.GID_ZOOM, User32.GF_BEGIN);
            public static readonly uint Zoom = MapWM2EventId(User32.GID_ZOOM, 0);
            public static readonly uint ZoomEnd = MapWM2EventId(User32.GID_ZOOM, User32.GF_END);
        }

        //A magical mapping of WM Gesture id and flags to a unique event entry in the event map
        private static uint MapWM2EventId(uint dwID, uint dwFlags)
        {
            return (dwID << 3) + (dwID == User32.GID_TWOFINGERTAP || dwID == User32.GID_PRESSANDTAP
                || dwID == User32.GID_BEGIN || dwID == User32.GID_END ?
                0 : dwFlags & 5);
        }
        
        /// <summary>
        /// Construct a gesture handler instance
        /// </summary>
        /// <param name="hWndWrapper">The target control wrapper</param>
        internal GestureHandler(IHwndWrapper hWndWrapper)
            : base(hWndWrapper)
        {
        }

        /// <summary>
        /// Register the form to get gesture events
        /// </summary>
        /// <returns>true if succeeded</returns>
        protected override bool SetHWndTouchInfo()
        {
            GESTURECONFIG[] gestureConfig = new[] { new GESTURECONFIG { dwID = 0, dwWant = User32.GC_ALLGESTURES, dwBlock = 0 } };
            
            return User32.SetGestureConfig(ControlHandle, 0, 1, gestureConfig, (uint)Marshal.SizeOf(typeof(GESTURECONFIG)));
        }

        /// <summary>
        /// The event that started the current gesture
        /// </summary>
        internal GestureEventArgs LastBeginEvent
        {
            get; set; 
        }

        /// <summary>
        /// The last event in the current gesture event sequence
        /// </summary>
        internal GestureEventArgs LastEvent
        {
            get; set;
        }

        // Gesture event handlers

        /// <summary>
        /// Indicate a that a gesture is beginning
        /// </summary>
        public event EventHandler<GestureEventArgs> Begin
        {
            add
            {
                _eventMap[EventMapID.Begin] += value;
            }
            remove
            {
                _eventMap[EventMapID.Begin] -= value;
            }
        }

        /// <summary>
        /// Indicate an end of a gesture
        /// </summary>
        public event EventHandler<GestureEventArgs> End
        {
            add
            {
                _eventMap[EventMapID.End] += value;
            }
            remove
            {
                _eventMap[EventMapID.End] -= value;
            }
        }

        /// <summary>
        /// Start the pannin sequence
        /// </summary>
        public event EventHandler<GestureEventArgs> PanBegin 
        {
            add
            {
                _eventMap[EventMapID.PanBegin] += value;
            }
            remove
            {
                _eventMap[EventMapID.PanBegin] -= value;
            }
        }

        /// <summary>
        /// Panning continue
        /// </summary>
        /// /// <remarks>
        /// Use the PanTranslation property of the event argument to get the
        /// relative translation size (relative to the last pan event) 
        /// </remarks>
        public event EventHandler<GestureEventArgs> Pan
        {
            add
            {
                _eventMap[EventMapID.Pan] += value;
            }
            remove
            {
                _eventMap[EventMapID.Pan] -= value;
            }
        }

        /// <summary>
        /// End pan event
        /// </summary>
        public event EventHandler<GestureEventArgs> PanEnd
        {
            add
            {
                _eventMap[EventMapID.PanEnd] += value;
            }
            remove
            {
                _eventMap[EventMapID.PanEnd] -= value;
            }
        }

        /// <summary>
        /// RollOver gesture event, this is a single event
        /// </summary>
        public event EventHandler<GestureEventArgs> PressAndTap 
        {
            add
            {
                _eventMap[EventMapID.PressAndTap] += value;
            }
            remove
            {
                _eventMap[EventMapID.PressAndTap] -= value;
            }
        }

        /// <summary>
        /// Starting rotate gesture 
        /// </summary>
        public event EventHandler<GestureEventArgs> RotateBegin
        {
            add
            {
                _eventMap[EventMapID.RotateBegin] += value;
            }
            remove
            {
                _eventMap[EventMapID.RotateBegin] -= value;
            }
        }

        /// <summary>
        /// Continue rotating
        /// </summary>
        /// <remarks>
        /// Use the RotateAngle in the event argument to get the relative 
        /// rotation angle
        /// </remarks>
        public event EventHandler<GestureEventArgs> Rotate
        {
            add
            {
                _eventMap[EventMapID.Rotate] += value;
            }
            remove
            {
                _eventMap[EventMapID.Rotate] -= value;
            }
        }

        /// <summary>
        /// Rotate end
        /// </summary>
        public event EventHandler<GestureEventArgs> RotateEnd
        {
            add
            {
                _eventMap[EventMapID.RotateEnd] += value;
            }
            remove
            {
                _eventMap[EventMapID.RotateEnd] -= value;
            }
        }

        /// <summary>
        /// Two fingers tap event.
        /// </summary>
        /// <remarks>
        /// This is a single event
        /// </remarks>
        public event EventHandler<GestureEventArgs> TwoFingerTap
        {
            add
            {
                _eventMap[EventMapID.TwoFingerTap] += value;
            }
            remove
            {
                _eventMap[EventMapID.TwoFingerTap] -= value;
            }
        }

        /// <summary>
        /// Start zoom gesture
        /// </summary>
        public event EventHandler<GestureEventArgs> ZoomBegin
        {
            add
            {
                _eventMap[EventMapID.ZoomBegin] += value;
            }
            remove
            {
                _eventMap[EventMapID.ZoomBegin] -= value;
            }
        }

        /// <summary>
        /// Continue zooming
        /// </summary>
        /// <remarks>
        /// Use the ZoomFactor to know the relative zoom factor
        /// </remarks>
        public event EventHandler<GestureEventArgs> Zoom
        {
            add
            {
                _eventMap[EventMapID.Zoom] += value;
            }
            remove
            {
                _eventMap[EventMapID.Zoom] -= value;
            }
        }

        /// <summary>
        /// Zoom End event
        /// </summary>
        public event EventHandler<GestureEventArgs> ZoomEnd
        {
            add
            {
                _eventMap[EventMapID.ZoomEnd] += value;
            }
            remove
            {
                _eventMap[EventMapID.ZoomEnd] -= value;
            }
        }


        /// <summary>
        /// The Windows message interception for gesture events handling
        /// </summary>
        /// <param name="hWnd">WndProc hWnd</param>
        /// <param name="msg">WndProc msg</param>
        /// <param name="wParam">WndProc wParam</param>
        /// <param name="lParam">WndProc lParam</param>
        /// <returns>WndProc return</returns>
        public override uint WindowProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam)
        {
            //We care only for gesture events
            if (msg != User32.WM_GESTURE)
                return 0;

            GESTUREINFO gestureInfo = new GESTUREINFO
            {
                cbSize = (uint)Marshal.SizeOf(typeof(GESTUREINFO))
            };

            bool result = User32.GetGestureInfo(lParam, ref gestureInfo);

            if (!result)
                throw new Exception("Cannot get gesture information");

            //Decode the gesture info and get the message event argument
            GestureEventArgs eventArgs = new GestureEventArgs(this, ref gestureInfo);
            try
            {
                //Fire the event using the event map
                _eventMap[MapWM2EventId(gestureInfo.dwID, gestureInfo.dwFlags)].Invoke(this, eventArgs);
            }
            catch (ArgumentOutOfRangeException) //In case future releases will introduce new event values
            {
            }

            //Keep the last message for relative calculations
            LastEvent = eventArgs;

            //Keep the first message for relative calculations
            if (eventArgs.IsBegin)
                LastBeginEvent = eventArgs;

            User32.CloseGestureInfoHandle(lParam);

            return 1;
        }
    }

    /// <summary>
    /// Event arguments for all gesture events
    /// </summary>
    /// <remarks>
    /// Some of the properties are related to specific messages:
    /// Panning: PanTranslation
    /// Zooming: ZoomFactor
    /// Rotation: RotateAngle
    /// </remarks>
    public class GestureEventArgs : EventArgs
    {
        private readonly uint _dwFlags;
        
        /// <summary>
        /// Create new gesture event instance and decode the gesture info structure
        /// </summary>
        /// <param name="handler">The gesture handler</param>
        /// <param name="gestureInfo">The gesture information</param>
        internal GestureEventArgs(GestureHandler handler, ref GESTUREINFO gestureInfo)
        {
            _dwFlags = gestureInfo.dwFlags;
            GestureId = gestureInfo.dwID;
            GestureArguments = gestureInfo.ullArguments;
            
            //Get the last event from the handler
            LastEvent = handler.LastEvent;

            //Get the last begin event from the handler 
            LastBeginEvent = handler.LastBeginEvent;

            DecodeGesture(handler.HWndWrapper, ref gestureInfo);

            //new gesture, clear last and first event fields
            if (IsBegin)
            {
                LastBeginEvent = null;
                LastEvent = null;
            }
        }

        //Decode the gesture
        private void DecodeGesture(IHwndWrapper hWndWrapper, ref GESTUREINFO gestureInfo)
        {
            Location = hWndWrapper.PointToClient(new Point(gestureInfo.ptsLocation.x, gestureInfo.ptsLocation.y));
            
            Center = Location;

            switch (GestureId)
            {
                case User32.GID_ROTATE:
                    ushort lastArguments = (ushort)(IsBegin ? 0 : LastEvent.GestureArguments);

                    RotateAngle = User32.GID_ROTATE_ANGLE_FROM_ARGUMENT((ushort)(gestureInfo.ullArguments - lastArguments));
                    break;


                case User32.GID_ZOOM:
                    Point first = IsBegin ? Location : LastBeginEvent.Location;
                    Center = new Point((Location.X + first.X) / 2, (Location.Y + first.Y) / 2);
                    ZoomFactor = IsBegin ? 1 : (double)gestureInfo.ullArguments / LastEvent.GestureArguments;
                    //DistanceBetweenFingers = User32.LoDWord(gestureInfo.ullArguments);
                    break;

                case User32.GID_PAN:
                    PanTranslation = IsBegin ? new Size(0, 0) :
                        new Size(Location.X - LastEvent.Location.X, Location.Y - LastEvent.Location.Y);
                    int panVelocity = User32.HiDWord((long)(gestureInfo.ullArguments));
                    PanVelocity = new Size(User32.LoWord(panVelocity), User32.HiWord(panVelocity));
                    //DistanceBetweenFingers = User32.LoDWord(gestureInfo.ullArguments);
                    break;
            }                
        }

        /// <summary>
        /// The windows gesture id
        /// </summary>
        public uint GestureId
        {
            get; private set;
        }

        /// <summary>
        /// the raw Gesture arguments
        /// </summary>
        public ulong GestureArguments
        {
            get; private set;
        }

        /// <summary>
        /// The gesture location translated into client area
        /// </summary>
        public Point Location
        {
            get; private set; 
        }

        /// <summary>
        /// The first event of a gesture
        /// </summary>
        public bool IsBegin
        {
            get
            {
                return (_dwFlags & User32.GF_BEGIN) != 0;
            }
        }

        /// <summary>
        /// The last event of a gesture
        /// </summary>
        public bool IsEnd
        {
            get
            {
                return (_dwFlags & User32.GF_END) != 0;
            }
        }

        /// <summary>
        /// The gesture has triggered inertia
        /// </summary>
        public bool IsInertia
        {
            get
            {
                return (_dwFlags & User32.GF_INERTIA) != 0;
            }
        }

        /// <summary>
        /// The relative rotation angle, used by the Rotate event
        /// </summary>
        public double RotateAngle
        {
            get; private set;
        }

        /// <summary>
        /// The calculated gesture center
        /// </summary>
        public Point Center {get; private set; }

        /// <summary>
        /// The zoom factor, used by the Zoom event
        /// </summary>
        public double ZoomFactor {get; private set; }

        /// <summary>
        /// The relative panning translation, used by the Pan event
        /// </summary>
        public Size PanTranslation {get; private set; }

        /// <summary>
        /// The velocity vector of the pan gesture, can be used for custom inertia
        /// </summary>
        public Size PanVelocity { get; private set; }

        /// <summary>
        /// The distance between fingers in the Pan and Zoom gestures
        /// </summary>
        //public uint DistanceBetweenFingers { get; private set; }

        /// <summary>
        /// The first gesture in this gesture event sequence
        /// </summary>
        public GestureEventArgs LastBeginEvent {get; internal set; }

        /// <summary>
        /// The last gesture in this gesture event sequence
        /// </summary>
        public GestureEventArgs LastEvent {get; internal set; }
    }
}