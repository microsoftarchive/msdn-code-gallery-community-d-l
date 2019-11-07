//-----------------------------------------------------------------------------
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using Windows7.Multitouch.Interop;

namespace Windows7.Multitouch
{
    /// <summary>
    /// Handles touch events for a hWnd
    /// </summary>
    public class TouchHandler : Handler 
    {
        private bool _disablePalmRejection;

        public TouchHandler(IHwndWrapper hWndWrapper)
            : base(hWndWrapper)
        {
        }

        /// <summary>
        /// Enabling this flag disables palm rejection
        /// </summary>
        public bool DisablePalmRejection
        {
            get
            {
                return _disablePalmRejection;
            }
            set
            {
                if (_disablePalmRejection == value)
                    return;

                _disablePalmRejection = value;

                if (HWndWrapper.IsHandleCreated)
                {
                    User32.UnregisterTouchWindow(HWndWrapper.Handle);
                    SetHWndTouchInfo();
                }
            }
        }

        /// <summary>
        /// Register for touch event
        /// </summary>
        /// <returns>true if succeeded</returns>
        protected override bool SetHWndTouchInfo()
        {
            return User32.RegisterTouchWindow(ControlHandle, _disablePalmRejection ? User32.TouchWindowFlag.WantPalm : 0);
        }

        /// <summary>
        /// Intercept and fire touch events
        /// </summary>
        /// <param name="hWnd">The Windows Handle</param>
        /// <param name="msg">Windows Message</param>
        /// <param name="wparam">wParam</param>
        /// <param name="lparam">lParam</param>
        /// <returns></returns>
        public override uint WindowProc(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam)
        {
            switch (msg)
            {
                case User32.WM_GESTURE:
                    break;
                case User32.WM_TOUCH:

                    foreach (TouchEventArgs arg in DecodeMessage(hWnd, msg, wparam, lparam, DpiX, DpiY))
                    {

                        if (TouchDown != null && arg.IsTouchDown)
                        {
                            TouchDown(this, arg);
                        }
                    
                        if (TouchMove != null && arg.IsTouchMove)
                        {
                            TouchMove(this, arg);
                        }
                    
                        if (TouchUp != null && arg.IsTouchUp)
                        {
                            TouchUp(this, arg);
                        }
                    }
                    return 1; //handled
            }
            return 0;
        }


        /// <summary>
        /// Decode the message and create a collection of event arguments
        /// </summary>
        /// <remarks>
        /// One Windows message can result a group of events
        /// </remarks>
        /// <returns>An enumerator of thr resuting events</returns>
        /// <param name="hWnd">the WndProc hWnd</param>
        /// <param name="msg">the WndProc msg</param>
        /// <param name="wParam">the WndProc wParam</param>
        /// <param name="lParam">the WndProc lParam</param>
        private IEnumerable<TouchEventArgs> DecodeMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam, float dpiX, float dpiY)
        {
            // More than one touchinput may be associated with a touch message,
            // so an array is needed to get all event information.
            int inputCount = User32.LoWord(wParam.ToInt32()); // Number of touch inputs, actual per-contact messages

            TOUCHINPUT[] inputs; // Array of TOUCHINPUT structures
            inputs = new TOUCHINPUT[inputCount]; // Allocate the storage for the parameters of the per-contact messages
            try
            {
                // Unpack message parameters into the array of TOUCHINPUT structures, each
                // representing a message for one single contact.
                if (!User32.GetTouchInputInfo(lParam, inputCount, inputs, Marshal.SizeOf(inputs[0])))
                {
                    // Get touch info failed.
                    throw new Exception("Error calling GetTouchInputInfo API");
                }

                // For each contact, dispatch the message to the appropriate message
                // handler.
                // Note that for WM_TOUCHDOWN you can get down & move notifications
                // and for WM_TOUCHUP you can get up & move notifications
                // WM_TOUCHMOVE will only contain move notifications
                // and up & down notifications will never come in the same message
                for (int i = 0; i < inputCount; i++)
                {
                    TouchEventArgs touchEventArgs = new TouchEventArgs(HWndWrapper, dpiX, dpiY, ref inputs[i]);
                    yield return touchEventArgs;
                }
            }
            finally
            {
                User32.CloseTouchInputHandle(lParam);
            }
        }
       

        // Touch event handlers

        /// <summary>
        /// Register to receive TouchDown Events
        /// </summary>
        public event EventHandler<TouchEventArgs> TouchDown;   // touch down event handler

        /// <summary>
        /// Register to receive TouchUp Events
        /// </summary>
        public event EventHandler<TouchEventArgs> TouchUp;     // touch up event handler

        /// <summary>
        /// Register to receive TouchMove Events
        /// </summary>
        public event EventHandler<TouchEventArgs> TouchMove;   // touch move event handler
    }


    /// <summary>
    /// EventArgs passed to Touch handlers 
    /// </summary>
    public class TouchEventArgs : EventArgs
    {
        private readonly IHwndWrapper _hWndWrapper;
        private readonly float _dpiXFactor;
        private readonly float _dpiYFactor;

        /// <summary>
        /// Create new touch event argument instance
        /// </summary>
        /// <param name="hWndWrapper">The target control</param>
        /// <param name="touchInput">one of the inner touch input in the message</param>
        internal TouchEventArgs(IHwndWrapper hWndWrapper, float dpiX, float dpiY, ref TOUCHINPUT touchInput)
        {
            _hWndWrapper = hWndWrapper;
            _dpiXFactor = 96F / dpiX;
            _dpiYFactor = 96F / dpiY;
            DecodeTouch(ref touchInput);
        }

        private bool CheckFlag(int value)
        {
            return (Flags & value) != 0;
        }

        

        // Decodes and handles WM_TOUCH* messages.
        private void DecodeTouch(ref TOUCHINPUT touchInput)
        {
            // TOUCHINFO point coordinates and contact size is in 1/100 of a pixel; convert it to pixels.
            // Also convert screen to client coordinates.
            if ( (touchInput.dwMask & User32.TOUCHINPUTMASKF_CONTACTAREA) != 0)
                ContactSize = new Size(AdjustDpiX(touchInput.cyContact / 100), AdjustDpiY(touchInput.cyContact / 100));
                          
            Id = touchInput.dwID;

            Point p = _hWndWrapper.PointToClient(new Point(touchInput.x / 100, touchInput.y / 100));
            Location = new Point(AdjustDpiX(p.X), AdjustDpiY(p.Y));

            Time = touchInput.dwTime;
            TimeSpan ellapse = TimeSpan.FromMilliseconds(Environment.TickCount - touchInput.dwTime);
            AbsoluteTime = DateTime.Now - ellapse;
           
            Mask = touchInput.dwMask;
            Flags = touchInput.dwFlags;
        }


        private int AdjustDpiX(int value)
        {
            return (int)(value * _dpiXFactor);
        }

        private int AdjustDpiY(int value)
        {
            return (int)(value * _dpiYFactor);
        }
      
        /// <summary>
        /// Touch client coordinate in pixels
        /// </summary>
        public Point Location {get; private set; }

        /// <summary>
        /// A touch point identifier that distinguishes a particular touch input
        /// </summary>
        public int Id { get; private set; }
       
        /// <summary>
        /// A set of bit flags that specify various aspects of touch point
        /// press, release, and motion. 
        /// </summary>
        public int Flags { get; private set; }
        
        /// <summary>
        /// mask which fields in the structure are valid
        /// </summary>
        public int Mask { get; private set; }

        /// <summary>
        /// touch event time
        /// </summary>
        public DateTime AbsoluteTime { get; private set; }

        /// <summary>
        /// touch event time from system up
        /// </summary>
        public int Time { get; private set; }
        
        /// <summary>
        /// the size of the contact area in pixels
        /// </summary>
        public Size? ContactSize { get; private set; }

        /// <summary>
        /// Is Primary Contact (The first touch sequence)
        /// </summary>
        public bool IsPrimaryContact
        {
            get { return (Flags & User32.TOUCHEVENTF_PRIMARY) != 0; }
        }

        /// <summary>
        /// Specifies that movement occurred
        /// </summary>
        public bool IsTouchMove
        {
            get { return CheckFlag(User32.TOUCHEVENTF_MOVE); }
        }

        /// <summary>
        /// Specifies that the corresponding touch point was established through a new contact
        /// </summary>
        public bool IsTouchDown
        {
            get { return CheckFlag(User32.TOUCHEVENTF_DOWN); }
        }

        /// <summary>
        /// Specifies that a touch point was removed
        /// </summary>
        public bool IsTouchUp
        {
            get { return CheckFlag(User32.TOUCHEVENTF_UP); }
        }

        /// <summary>
        /// Specifies that a touch point is in range
        /// </summary>
        public bool IsTouchInRange
        {
            get { return CheckFlag(User32.TOUCHEVENTF_INRANGE); }
        }

        /// <summary>
        /// specifies that this input was not coalesced.
        /// </summary>
        public bool IsTouchNoCoalesce
        {
            get { return CheckFlag(User32.TOUCHEVENTF_NOCOALESCE); }
        }

        /// <summary>
        /// Specifies that the touch point is associated with a pen contact
        /// </summary>
        public bool IsTouchPen
        {
            get { return CheckFlag(User32.TOUCHEVENTF_PEN); }
        }

        /// <summary>
        /// The touch event came from the user's palm
        /// </summary>
        /// <remarks>Set <see cref="DisablePalmRejection"/> to true</remarks>
        public bool IsTouchPalm
        {
            get { return CheckFlag(User32.TOUCHEVENTF_PALM); }
        }
    }
}