using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.ComponentModel;
using System.Data;

using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Windows.Interop;

namespace IdentityMine.Avalon.Controls
{
    public class PowerChecker
    {

        public enum PowerPlan
        {
            Automatic,
            HighPerformance,
            PowerSaver,
        };

        public delegate void PowerChanged();

        // Event that this class raises 
        // when the power information changes.
        public virtual event PowerChanged PowerChangedEvent;

        private IntPtr hBattCapacity;
        private IntPtr hMonitorOn;
        private IntPtr hPowerScheme;
        private IntPtr hPowerSrc;
        private bool runningOnDC;
        private bool monitorOn;
        private bool machineInSuspend;
        private PowerPlan powerPlan;

        public PowerChecker()
        {
        }

        public void Close()
        {
            // Clean up by unregistering any notifications we have registered for.
            try
            {
                UnregisterForPowerNotifications();
            }
            catch
            {
                //API not supported
            }
        }

        public void Load()
        {
            if (Application.Current.Windows[0] != null)
            {
                try
                {
                    RegisterForPowerNotifications();
                }
                catch
                {
                    //API not supported
                }
                HwndSource source = HwndSource.FromHwnd(new WindowInteropHelper(Application.Current.Windows[0]).Handle);
                source.AddHook(new HwndSourceHook(WndProc));
            }
        }

        #region WndProc
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case WM_POWERBROADCAST:
                    OnPowerBroadcast(wParam, lParam);
                    break;
            }
            return IntPtr.Zero;
        } 
        #endregion

        #region RegisterForPowerNotifications
        private void RegisterForPowerNotifications()
        {
            IntPtr handle = new WindowInteropHelper(Application.Current.Windows[0]).Handle;
            hPowerSrc = RegisterPowerSettingNotification(handle,
                                        ref GUID_ACDC_POWER_SOURCE,
                                        DEVICE_NOTIFY_WINDOW_HANDLE);

            hBattCapacity = RegisterPowerSettingNotification(handle,
                                        ref GUID_BATTERY_PERCENTAGE_REMAINING,
                                        DEVICE_NOTIFY_WINDOW_HANDLE);

            hMonitorOn = RegisterPowerSettingNotification(handle,
                                        ref GUID_MONITOR_POWER_ON,
                                        DEVICE_NOTIFY_WINDOW_HANDLE);

            hPowerScheme = RegisterPowerSettingNotification(handle,
                                        ref GUID_POWERSCHEME_PERSONALITY,
                                        DEVICE_NOTIFY_WINDOW_HANDLE);


        } 
        #endregion

        #region UnregisterForPowerNotifications
        private void UnregisterForPowerNotifications()
        {
            UnregisterPowerSettingNotification(hBattCapacity);
            UnregisterPowerSettingNotification(hMonitorOn);
            UnregisterPowerSettingNotification(hPowerScheme);
            UnregisterPowerSettingNotification(hPowerSrc);
        } 
        #endregion

        #region Properties
        public bool RunningOnBattery
        {
            get
            {
                return runningOnDC;
            }
        }

        public bool MonitorOn
        {
            get
            {
                return monitorOn;
            }
        }

        public bool InSuspend
        {
            get
            {
                return machineInSuspend;
            }
        }

        public PowerPlan ActivePowerPlan
        {
            get
            {
                return powerPlan;
            }
        }
        #endregion

        #region Power changed message information

        private void OnPowerBroadcast(IntPtr wParam, IntPtr lParam)
        {
            // Report the change that has occurred.
            ReportPowerChange((int)wParam);

            if ((int)wParam == PBT_POWERSETTINGCHANGE)
            {
                // Respond to a change in the power settings.
                PowerSettingChange(lParam);
            }

            try
            {
                // Raise the event to notify any listeners of a change.
                if (PowerChangedEvent != null)
                {
                    PowerChangedEvent();
                }
            }
            catch (Exception ex)
            {
                // An exception possibly thrown by the client of our event                
            }
        }

        protected void ReportPowerChange(int reason)
        {
            string report = string.Empty;
            switch (reason)
            {
                case PBT_APMSUSPEND:
                    report = "System is suspending operation ";
                    machineInSuspend = true;
                    break;
                case PBT_APMSTANDBY:
                    report = "System is standing by ";
                    machineInSuspend = true;
                    break;
                case PBT_APMRESUMECRITICAL:
                    report = "Operation resuming after critical suspension.";
                    machineInSuspend = false;
                    break;
                case PBT_APMRESUMESUSPEND:
                    report = "Operation resuming after suspension.";
                    machineInSuspend = false;
                    break;
                case PBT_APMRESUMESTANDBY:
                    report = "Operation resuming after stand by.";
                    machineInSuspend = false;
                    break;
                case PBT_APMBATTERYLOW:
                    report = "Battery power is low.";
                    break;
                case PBT_APMPOWERSTATUSCHANGE:
                    report = "Power status has changed.";
                    break;
                case PBT_APMOEMEVENT:
                    report = "OEM-defined event occurred.";
                    break;
                case PBT_APMRESUMEAUTOMATIC:
                    report = "Operation resuming automatically after event.";
                    break;
                case PBT_POWERSETTINGCHANGE:
                    // report = "Power setting has changed";
                    break;
                default:
                    report = "Unknown reason:" + reason.ToString();
                    break;
            }
            if (string.Empty != report)
            {
                ///Use this in case the kind of power change need to be displayed.
                ///eventsListBox.Items.Add(report);
                ///
            }
        }

        private void PowerSettingChange(IntPtr lParam)
        {
            POWERBROADCAST_SETTING ps =
                                (POWERBROADCAST_SETTING)Marshal.PtrToStructure(
                                                lParam, typeof(POWERBROADCAST_SETTING));

            IntPtr pData = (IntPtr)((int)lParam + Marshal.SizeOf(ps));

            // Handle a change to the power plan.
            if (ps.PowerSetting == GUID_POWERSCHEME_PERSONALITY)
            {
                SetPowerPlan(ps, pData);
            }
            else
                if (ps.DataLength == Marshal.SizeOf(typeof(Int32)))
                {
                    Int32 iData = (Int32)Marshal.PtrToStructure(pData, typeof(Int32));
                    if (ps.PowerSetting == GUID_BATTERY_PERCENTAGE_REMAINING)
                    {
                        SetBatteryLevel(iData);
                    }
                    else if (ps.PowerSetting == GUID_MONITOR_POWER_ON)
                    {
                        SetMonitorState(iData);
                    }
                    else if (ps.PowerSetting == GUID_ACDC_POWER_SOURCE)
                    {
                        SetPowerSource(iData);
                    }
                }
        }

        private void SetBatteryLevel(Int32 iData)
        {
            string eventText = "Battery percentage remaining chenged";

            //iData is the level of battery charge remaining            
        }

        private void SetPowerSource(Int32 iData)
        {
            string powerSrc;
            switch (iData)
            {
                case 0:
                    runningOnDC = false;
                    powerSrc = "AC";
                    break;
                case 1:
                    runningOnDC = true;
                    powerSrc = "DC";
                    break;
                case 2:
                    runningOnDC = true;
                    powerSrc = "Short term DC (e.g. UPS)";
                    break;
                default:
                    powerSrc = "Unknown";
                    break;
            }
        }

        private void SetMonitorState(Int32 iData)
        {

            string eventText;
            switch (iData)
            {
                case 0:
                    monitorOn = false;
                    eventText = "Monitor powered down";
                    break;
                case 1:
                    monitorOn = true;
                    eventText = "Monitor powered up";
                    break;
                default:
                    eventText = "Unknown monitor event";
                    break;
            }
        }

        private void SetPowerPlan(POWERBROADCAST_SETTING ps, IntPtr pData)
        {
            string eventText;
            if (ps.DataLength == Marshal.SizeOf(typeof(Guid)))
            {
                Guid newPersonality = (Guid)Marshal.PtrToStructure(pData, typeof(Guid));
                if (newPersonality == GUID_MAX_POWER_SAVINGS)
                {
                    powerPlan = PowerPlan.PowerSaver;
                    eventText = "Switched to Max Power savings";
                }
                else if (newPersonality == GUID_MIN_POWER_SAVINGS)
                {
                    powerPlan = PowerPlan.HighPerformance;
                    eventText = "Switched to Min Power savings";
                }
                else if (newPersonality == GUID_TYPICAL_POWER_SAVINGS)
                {
                    powerPlan = PowerPlan.Automatic;
                    eventText = "Switched to Automatic Power savings";
                }
                else
                {
                    eventText = "switched to unknown Power savings";
                }
            }
        }
        #endregion
    
        # region Vista Platform SDK APIs and declarations 
                // These Guids can be found in WinNT.h in the Vista Platform SDK

                Guid GUID_BATTERY_PERCENTAGE_REMAINING = new Guid("A7AD8041-B45A-4CAE-87A3-EECBB468A9E1");
                Guid GUID_MONITOR_POWER_ON = new Guid(0x02731015, 0x4510, 0x4526, 0x99, 0xE6, 0xE5, 0xA1, 0x7E, 0xBD, 0x1A, 0xEA);
                Guid GUID_ACDC_POWER_SOURCE = new Guid(0x5D3E9A59, 0xE9D5, 0x4B00, 0xA6, 0xBD, 0xFF, 0x34, 0xFF, 0x51, 0x65, 0x48);
                Guid GUID_POWERSCHEME_PERSONALITY = new Guid(0x245D8541, 0x3943, 0x4422, 0xB0, 0x25, 0x13, 0xA7, 0x84, 0xF6, 0x79, 0xB7);

                // POWER PERSONALITIES

                // Maximum Power Savings - Very aggressive power savings 
                // measures are used to help stretch battery life.
                Guid GUID_MAX_POWER_SAVINGS = new Guid(0xA1841308, 0x3541, 0x4FAB, 0xBC, 0x81, 0xF7, 0x15, 0x56, 0xF2, 0x0B, 0x4A);
                // No Power Savings - Almost no power savings measures are used.
                Guid GUID_MIN_POWER_SAVINGS = new Guid(0x8C5E7FDA, 0xE8BF, 0x4A96, 0x9A, 0x85, 0xA6, 0xE2, 0x3A, 0x8C, 0x63, 0x5C);
                // Typical Power Savings - Fairly aggressive power savings measures are used.
                Guid GUID_TYPICAL_POWER_SAVINGS = new Guid(0x381B4222, 0xF694, 0x41F0, 0x96, 0x85, 0xFF, 0x5B, 0xB2, 0x60, 0xDF, 0x2E);


                // Win32 decls and defs
                //
                const int WM_POWERBROADCAST = 0x0218;

                const int PBT_APMQUERYSUSPEND = 0x0000;
                const int PBT_APMQUERYSTANDBY = 0x0001;
                const int PBT_APMQUERYSUSPENDFAILED = 0x0002;
                const int PBT_APMQUERYSTANDBYFAILED = 0x0003;
                const int PBT_APMSUSPEND = 0x0004;
                const int PBT_APMSTANDBY = 0x0005;
                const int PBT_APMRESUMECRITICAL = 0x0006;
                const int PBT_APMRESUMESUSPEND = 0x0007;
                const int PBT_APMRESUMESTANDBY = 0x0008;
                const int PBT_APMBATTERYLOW = 0x0009;
                const int PBT_APMPOWERSTATUSCHANGE = 0x000A; // power status
                const int PBT_APMOEMEVENT = 0x000B;
                const int PBT_APMRESUMEAUTOMATIC = 0x0012;
                const int PBT_POWERSETTINGCHANGE = 0x8013; // DPPE


                const int DEVICE_NOTIFY_WINDOW_HANDLE = 0x00000000;
                const int DEVICE_NOTIFY_SERVICE_HANDLE = 0x00000001;

                // This structure is sent when the PBT_POWERSETTINGSCHANGE message is sent.
                // It describes the power setting that has changed and contains data about the change
                [StructLayout(LayoutKind.Sequential, Pack = 4)]
                internal struct POWERBROADCAST_SETTING
                {
                    public Guid PowerSetting;
                    public Int32 DataLength;
                }

                [DllImport(@"User32", EntryPoint = "RegisterPowerSettingNotification",
                     CallingConvention = CallingConvention.StdCall)]
                private static extern IntPtr RegisterPowerSettingNotification(
                    IntPtr hRecipient,
                    ref Guid PowerSettingGuid,
                    Int32 Flags);

                [DllImport(@"User32", EntryPoint = "UnregisterPowerSettingNotification",
                     CallingConvention = CallingConvention.StdCall)]
                private static extern bool UnregisterPowerSettingNotification(
                    IntPtr handle);

                // Used by SetThreadExecutionState.
                [FlagsAttribute]
                public enum EXECUTION_STATE : uint
                {
                    ES_SYSTEM_REQUIRED = 0x00000001,
                    ES_DISPLAY_REQUIRED = 0x00000002,
                    // Legacy flag, should not be used.
                    // ES_USER_PRESENT   = 0x00000004,
                    ES_CONTINUOUS = 0x80000000,
                }

                [DllImport("Kernel32.DLL", CharSet = CharSet.Auto,
                     SetLastError = true)]
                public extern static
                    EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE state);


        # endregion

    

    }
}
