using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace KioskBrowser
{
	public static class Taskbar
	{
		[DllImport("user32.dll")]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count); 
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool EnumThreadWindows(int threadId, EnumThreadProc pfnEnum, IntPtr lParam);
		[DllImport("user32.dll", SetLastError = true)]
		private static extern System.IntPtr FindWindow(string lpClassName, string lpWindowName);
		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className,  string windowTitle);
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindowEx(IntPtr parentHwnd, IntPtr childAfterHwnd, IntPtr className, string windowText);
        [DllImport("user32.dll")]
		private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
		[DllImport("user32.dll")]
		private static extern uint GetWindowThreadProcessId(IntPtr hwnd, out int lpdwProcessId);

		private const int SW_HIDE = 0;
		private const int SW_SHOW = 5;

		private const string VistaStartMenuCaption = "Start";
		private static IntPtr vistaStartMenuWnd = IntPtr.Zero;
		private delegate bool EnumThreadProc(IntPtr hwnd, IntPtr lParam);

		public static void Show()
		{
			SetVisibility(true);
		}

		public static void Hide()
		{
			SetVisibility(false);
		}

		public static bool Visible
		{
			set { SetVisibility(value); }
		}

		private static void SetVisibility(bool show)
		{
			IntPtr taskBarWnd = FindWindow("Shell_TrayWnd", null);

			IntPtr startWnd = FindWindowEx(taskBarWnd, IntPtr.Zero, "Button", "Start");

            if (startWnd == IntPtr.Zero)
            {
                startWnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, (IntPtr)0xC017, "Start");
            }

			if (startWnd == IntPtr.Zero)
			{
				startWnd = FindWindow("Button", null);

				if (startWnd == IntPtr.Zero)
				{
					startWnd = GetVistaStartMenuWnd(taskBarWnd);
				}
			}
			
			ShowWindow(taskBarWnd, show ? SW_SHOW : SW_HIDE);
			ShowWindow(startWnd, show ? SW_SHOW : SW_HIDE);
		}

		private static IntPtr GetVistaStartMenuWnd(IntPtr taskBarWnd)
		{
			int procId;
			GetWindowThreadProcessId(taskBarWnd, out procId);

			Process p = Process.GetProcessById(procId);
			if (p != null)
			{
				foreach (ProcessThread t in p.Threads)
				{
					EnumThreadWindows(t.Id, MyEnumThreadWindowsProc, IntPtr.Zero);
				}
			}
			return vistaStartMenuWnd;
		}

		private static bool MyEnumThreadWindowsProc(IntPtr hWnd, IntPtr lParam)
		{
			StringBuilder buffer = new StringBuilder(256);
			if (GetWindowText(hWnd, buffer, buffer.Capacity) > 0)
			{
				Console.WriteLine(buffer);
				if (buffer.ToString() == VistaStartMenuCaption)
				{
					vistaStartMenuWnd = hWnd;
					return false;
				}
			}
			return true;
		}
	}
}
