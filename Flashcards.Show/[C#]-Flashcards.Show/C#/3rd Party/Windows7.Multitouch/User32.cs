//-----------------------------------------------------------------------------
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace Windows7.Multitouch.Interop
{
    internal static class User32
    {
        //Misc APIs
        [DllImport("user32")]
        public static extern bool SetProcessDPIAware();

        [DllImport("user32")]
        public static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32")]
        public static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);

        public const int WM_NCDESTROY = 0x0082;

        //Subclass API
        [DllImport("user32", EntryPoint = "SetWindowLongPtr")]
        public static extern IntPtr SubclassWindow64(IntPtr hWnd, int nIndex, WindowProcDelegate dwNewLong);

        [DllImport("user32", EntryPoint = "SetWindowLong")]
        public static extern IntPtr SubclassWindow(IntPtr hWnd, int nIndex, WindowProcDelegate dwNewLong);


        [DllImport("user32")]
        public static extern uint CallWindowProc(IntPtr prevWndFunc, IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam);

        public delegate uint WindowProcDelegate(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam);

        public const int GWLP_WNDPROC = -4;

        //Touch
        [DllImport("user32", EntryPoint = "GetSystemMetrics")]
        public static extern int GetDigitizerCapabilities(DigitizerIndex index);

        public enum DigitizerIndex
        {
            SM_DIGITIZER = 94,
            SM_MAXIMUMTOUCHES = 95
        }

        // Touch event window message constants [winuser.h]
        public const int WM_TOUCH = 0x0240;

        public enum TouchWindowFlag : uint
        {
            None = 0x0,
            FineTouch = 0x1,
            WantPalm = 0x2
        }

        [DllImport("user32")]
        public static extern bool RegisterTouchWindow(System.IntPtr hWnd, TouchWindowFlag flags);

        [DllImport("user32")]
        public static extern bool UnregisterTouchWindow(System.IntPtr hWnd);
        
        [DllImport("user32")]
        public static extern bool IsTouchWindow(System.IntPtr hWnd, out uint ulFlags);

        [DllImport("user32")]
        public static extern bool GetTouchInputInfo(System.IntPtr hTouchInput, int cInputs, [In, Out] TOUCHINPUT[] pInputs, int cbSize);

        [DllImport("user32")]
        public static extern void CloseTouchInputHandle(System.IntPtr lParam);

        [DllImport("user32")]
        public static extern bool SetProp(IntPtr hWnd, string lpString, IntPtr hData);

        // Extracts lower 16-bit word from an 32-bit int.
        // in:
        //      number      int
        // returns:
        //      lower word
        public static ushort LoWord(uint number)
        {
            return (ushort)(number & 0xffff);
        }

        // Extracts higher 16-bit word from an 32-bit int.
        // in:
        //      number      uint
        // returns:
        //      lower word
        public static ushort HiWord(uint number)
        {
            return (ushort)((number >> 16) & 0xffff);
        }

        // Extracts lower 32-bit word from an 64-bit int.
        // in:
        //      number      ulong
        // returns:
        //      lower word
        public static uint LoDWord(ulong number)
        {
            return (uint)(number & 0xffffffff);
        }

        // Extracts higher 32-bit word from an 64-bit int.
        // in:
        //      number      ulong
        // returns:
        //      lower word
        public static uint HiDWord(ulong number)
        {
            return (uint)((number >> 32) & 0xffffffff);
        }


        // Extracts lower 16-bit word from an 32-bit int.
        // in:
        //      number      int
        // returns:
        //      lower word
        public static short LoWord(int number)
        {
            return (short)number;
        }

        // Extracts higher 16-bit word from an 32-bit int.
        // in:
        //      number      int
        // returns:
        //      lower word
        public static short HiWord(int number)
        {
            return (short)(number >> 16);
        }

        // Extracts lower 32-bit word from an 64-bit int.
        // in:
        //      number      long
        // returns:
        //      lower word
        public static int LoDWord(long number)
        {
            return (int)(number);
        }

        // Extracts higher 32-bit word from an 64-bit int.
        // in:
        //      number      long
        // returns:
        //      lower word
        public static int HiDWord(long number)
        {
            return (int)((number >> 32));
        }


        // Touch event flags ((TOUCHINPUT.dwFlags) [winuser.h]
        public const int TOUCHEVENTF_MOVE = 0x0001;
        public const int TOUCHEVENTF_DOWN = 0x0002;
        public const int TOUCHEVENTF_UP = 0x0004;
        public const int TOUCHEVENTF_INRANGE = 0x0008;
        public const int TOUCHEVENTF_PRIMARY = 0x0010;
        public const int TOUCHEVENTF_NOCOALESCE = 0x0020;
        public const int TOUCHEVENTF_PEN = 0x0040;
        public const int TOUCHEVENTF_PALM = 0x0080;

        // Touch input mask values (TOUCHINPUT.dwMask) [winuser.h]
        public const int TOUCHINPUTMASKF_TIMEFROMSYSTEM = 0x0001; // the dwTime field contains a system generated value
        public const int TOUCHINPUTMASKF_EXTRAINFO = 0x0002; // the dwExtraInfo field is valid
        public const int TOUCHINPUTMASKF_CONTACTAREA = 0x0004; // the cxContact and cyContact fields are valid

        //Gesture

        public const uint GC_ALLGESTURES = 0x00000001;

        public const int WM_GESTURE = 0x0119;

        public const int WM_GESTURENOTIFY = 0x011A;

        

        
         // Gesture notification structure
         //  - The WM_GESTURENOTIFY message lParam contains a pointer to this structure.
         //  - The WM_GESTURENOTIFY message notifies a window that gesture recognition is
         //    in progress and a gesture will be generated if one is recognized under the
         //    current gesture settings.
        public struct GESTURENOTIFYSTRUCT
        {
            public uint   cbSize;                   // size, in bytes, of this structure
            public uint   dwFlags;                  // unused
            public IntPtr hwndTarget;               // handle to window targeted by the gesture
            public POINTS  ptsLocation;              // starting location
            public uint   dwInstanceID;             // internally used
        };


        [DllImport("user32")]
        public static extern bool SetGestureConfig(
                                    IntPtr hwnd,                        // window for which configuration is specified
                                    uint dwReserved,                    // reserved, must be 0
                                    uint cIDs,                          // count of GESTURECONFIG structures
                                    GESTURECONFIG [] pGestureConfig,    // array of GESTURECONFIG structures, dwIDs will be processed in the
                                                                        // order specified and repeated occurances will overwrite previous ones
                                    uint cbSize);                       // sizeof(GESTURECONFIG)



        

        [DllImport("user32")]
        public static extern bool GetGestureInfo(IntPtr hGestureInfo, ref GESTUREINFO pGestureInfo);

        // Gesture argument helpers
        //   - Angle should be a double in the range of -2pi to +2pi
        //   - Argument should be an unsigned 16-bit value
        //
        public static ushort GID_ROTATE_ANGLE_TO_ARGUMENT(ushort arg)    { return ((ushort)(((arg + 2.0 * 3.14159265) / (4.0 * 3.14159265)) * 65535.0)); }
        public static double GID_ROTATE_ANGLE_FROM_ARGUMENT(ushort arg)  { return ((((double)arg / 65535.0) * 4.0 * 3.14159265) - 2.0 * 3.14159265); }


        [DllImport("user32")]
        public static extern bool CloseGestureInfoHandle(IntPtr hGestureInfo);
       
        //Gesture flags - GESTUREINFO.dwFlags
        public const uint GF_BEGIN =    0x00000001;
        public const uint GF_INERTIA =  0x00000002;
        public const uint GF_END =      0x00000004;

        //Gesture IDs
        public const uint GID_BEGIN        =  1;
        public const uint GID_END          =  2;
        public const uint GID_ZOOM         =  3;
        public const uint GID_PAN          =  4;
        public const uint GID_ROTATE       =  5;
        public const uint GID_TWOFINGERTAP =  6;
        public const uint GID_PRESSANDTAP  =  7;
    }


    //Touch
   
    /// <summary>
    /// Touch API defined structures [winuser.h]
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TOUCHINPUT
    {
        public int x;
        public int y;
        public System.IntPtr hSource;
        public int dwID;
        public int dwFlags;
        public int dwMask;
        public int dwTime;
        public System.IntPtr dwExtraInfo;
        public int cxContact;
        public int cyContact;
    }

    /// <summary>
    /// A Simple POINTS Interop structure
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINTS
    {
        public short x;
        public short y;
    }

    /// <summary>
    /// A Simple POINT Interop structure
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x;
        public int y;
    }

    
    //Gesture

    /// <summary>
    /// Gesture Config Interop Structure
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct GESTURECONFIG
    {
        public uint dwID;                     // gesture ID
        public uint dwWant;                   // settings related to gesture ID that are to be turned on
        public uint dwBlock;                  // settings related to gesture ID that are to be turned off
    }

    /// <summary>
    /// Gesture Info Interop Structure
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct GESTUREINFO 
    {
        public uint cbSize;                // size, in bytes, of this structure (including variable length Args field)
        public uint dwFlags;               // see GF_* flags
        public uint dwID;                  // gesture ID, see GID_* defines
        public IntPtr hwndTarget;          // handle to window targeted by this gesture
        public POINTS ptsLocation;          // current location of this gesture
        public uint dwInstanceID;          // internally used
        public uint dwSequenceID;          // internally used
        public ulong ullArguments;         // arguments for gestures whose arguments fit in 8 BYTES
        public uint cbExtraArgs;           // size, in bytes, of extra arguments, if any, that accompany this gesture
    }

    class Kernel32
    {
        /// <summary>
        /// Get the native thread id
        /// </summary>
        /// <returns>Thread ID</returns>
        [DllImport("Kernel32")]
        public static extern uint GetCurrentThreadId();
    }
}