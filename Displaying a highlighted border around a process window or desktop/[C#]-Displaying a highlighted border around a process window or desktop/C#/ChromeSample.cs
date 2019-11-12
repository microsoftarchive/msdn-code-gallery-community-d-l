using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
namespace ChromeSample
{
    public partial class ChromeSample : Form
    {
        public const int borderWidth = 5; //change to make border smaller or larger
        public List<Chrome> desktopChromes = new List<Chrome>(); 
        public Chrome currentChrome;        
        public IntPtr currentProcessHandle;
        public Process currentProcess;
        public Rectangle currentProcessWindow;
        public Process[] processes;
        public Thread RefreshChromeThread;
        public Thread RefreshDesktopChromeThread;
        public Screen[] screens;
        
        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, uint Msg);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        private static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);

        private const UInt32 SW_MAXIMIZE = 3;
        private const UInt32 SW_MINIMIZE = 2;
        private const uint SW_RESTORE = 0x09;


        public ChromeSample()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows a border around your desktop, spanning accross multiple monitors if you have more than one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDesktop_Click(object sender, EventArgs e)
        {

            screens = Screen.AllScreens;

            foreach(Screen screen in screens)
            {
                ShowDesktopChrome(screen);
            }

            ThreadStart ts = new ThreadStart(RefreshDesktopChrome);
            RefreshDesktopChromeThread = new Thread(ts);
            RefreshDesktopChromeThread.Start();
                        
        }

        private void ShowDesktopChrome(Screen screen)
        {
            int x = screen.Bounds.X;
            int y = screen.Bounds.Y;
            Size size = screen.Bounds.Size;
            Rectangle desktop = new Rectangle(new Point(x, y), size);
            Chrome chrome = new Chrome();
            chrome.Highlight(desktop, true, borderWidth);
            desktopChromes.Add(chrome);
           
        }

        /// <summary>
        /// This thread runs to see if any new monitors have been added, or if one has been removed
        /// </summary>
        private void RefreshDesktopChrome()
        {
            while (true)
            {
                foreach (Chrome desktopChrome in desktopChromes)
                {
                    this.Invoke(new ThreadSafeRefreshDesktopChromeDelegate(this.ThreadSafeRefreshDesktopChrome), null);
                }
                Thread.Sleep(2000);
            }
               
        }

        private delegate void ThreadSafeRefreshDesktopChromeDelegate();
        //bring the chrome window to the top most level
        private void ThreadSafeRefreshDesktopChrome()
        {
            foreach (Chrome desktopChrome in desktopChromes)
            {
                desktopChrome.TopMost = true;
            }
        }
        
        /// <summary>
        /// Gets a list of processes that have a user interface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGetProcesses_Click(object sender, EventArgs e)
        {
            listBoxProcesses.Items.Clear();
            processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                if (process.MainWindowHandle != (IntPtr)0) // check if process has UI
                {
                    listBoxProcesses.Items.Add(process.ProcessName);
                }
            }
        }

        /// <summary>
        /// Creates a border around an application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonProcess_Click(object sender, EventArgs e)
        {
            if (RefreshChromeThread!=null && RefreshChromeThread.IsAlive)
            {
                this.BeginInvoke(new ThreadSafeDisposeChromeDelegate(this.ThreadSafeDisposeChrome),currentChrome);
                RefreshChromeThread.Abort();
            }

            string processName = listBoxProcesses.SelectedItem.ToString();
            Process[] processes = Process.GetProcesses();
            currentProcess = null;
            foreach (Process process in processes)
            {
                if (processName == process.ProcessName)
                {
                    currentProcess = process;
                    break;                    
                }
            }

            currentProcessHandle = currentProcess.MainWindowHandle;            
            SetForegroundWindow(currentProcessHandle);
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            placement.length = Marshal.SizeOf(placement);
            GetWindowPlacement(currentProcessHandle, out placement);

            //if the application in minimized, restores it to previous size
            if (placement.showCmd == SW_MINIMIZE)
            {
                ShowWindow(currentProcessHandle, SW_RESTORE);
            }


            RECT processWindowSize = new RECT();
            GetWindowRect(currentProcessHandle, ref processWindowSize);
            Size size = new Size(processWindowSize.Height - processWindowSize.X,processWindowSize.Width - processWindowSize.Y);
            Rectangle processWindow = new Rectangle(new Point(processWindowSize.X, processWindowSize.Y), size);
            currentProcessWindow = processWindow;
            currentChrome = new Chrome();
            currentChrome.Highlight(processWindow, false, borderWidth);
            
            //special handling if application is maximized, the bottom border needs to be outside the application window
            if (placement.showCmd == SW_MAXIMIZE)
            {
                int taskBarSize = Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height;
                processWindow.X = 0;
                processWindow.Y = 0;
                processWindow.Height = (processWindowSize.Width + borderWidth) -2;
                processWindow.Width = processWindowSize.Height + processWindowSize.X;
                currentChrome.Highlight(processWindow, true, borderWidth);
            }
            else
            {
                currentChrome.Highlight(processWindow, false, borderWidth);
            }
            ThreadStart ts = new ThreadStart(RefreshChrome);
            RefreshChromeThread = new Thread(ts);
            RefreshChromeThread.Start();
            
        }

   
        /// <summary>
        /// This thread runs to detect if the application window has moved or resized
        /// </summary>
        private void RefreshChrome()
        {
            bool processExited = false;
            while (!processExited)
            {
                if (currentProcess.HasExited)
                {
                    this.BeginInvoke(new ThreadSafeDisposeChromeDelegate(this.ThreadSafeDisposeChrome), currentChrome);
                    processExited = true;
                }
                currentProcessHandle = currentProcess.MainWindowHandle;
                RECT processWindowSize = new RECT();
                GetWindowRect(currentProcessHandle, ref processWindowSize);
                Size size = new Size(processWindowSize.Height - processWindowSize.X, processWindowSize.Width - processWindowSize.Y);
                Rectangle processWindow = new Rectangle(new Point(processWindowSize.X, processWindowSize.Y), size);                
                if (currentProcessWindow.X != processWindow.X || currentProcessWindow.Y != processWindow.Y || currentProcessWindow.Width != processWindow.Width || currentProcessWindow.Height != processWindow.Height)
                {
                    bool maximized = false;
                    WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
                    placement.length = Marshal.SizeOf(placement);
                    GetWindowPlacement(currentProcessHandle, out placement);
                    //special handling if application is maximized, the bottom border needs to be outside the application window
                    if (placement.showCmd == SW_MAXIMIZE)
                    {
                        maximized = true;
                        int taskBarSize = Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height;
                        processWindow.X = 0;
                        processWindow.Y = 0;
                        processWindow.Height = (processWindowSize.Width + borderWidth) - 2;
                        processWindow.Width = processWindowSize.Height + processWindowSize.X;
                    }
                    this.BeginInvoke(new ThreadSafeDisposeChromeAndCreateNewDelegate(this.ThreadSafeDisposeChromeAndCreateNew), processWindow, maximized);
                }
                currentProcessWindow = processWindow;
                Thread.Sleep(1000);
            }
        }

        private delegate void ThreadSafeDisposeChromeDelegate(Chrome chromeToDispose);
        //Dispose of chrome object
        private void ThreadSafeDisposeChrome(Chrome chromeToDispose)
        {
            if (chromeToDispose != null)
            {
                chromeToDispose.Dispose();
            }
            if (desktopChromes.Count > 0)
            {
                foreach (Chrome desktopChrome in desktopChromes)
                {
                    desktopChrome.Dispose();
                }
            }
            desktopChromes.Clear();
           
        }

        private delegate void ThreadSafeDisposeChromeAndCreateNewDelegate(Rectangle processWindow, bool maximized);
        //Dispose of current chrome window and create a new one
        private void ThreadSafeDisposeChromeAndCreateNew(Rectangle processWindow, bool maximized)
        {
            if (currentChrome != null)
            {
                currentChrome.Dispose();
            }
            currentChrome = new Chrome();
            currentChrome.Highlight(processWindow, maximized, borderWidth);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int X;
            public int Y;
            public int Height;
            public int Width;
          
        }

        //for detecting if a window is minimized or maximized
        private struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        /// <summary>
        /// Hides and disposes of the chrome object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHide_Click(object sender, EventArgs e)
        {
            //Dispose the chrome window
            if (currentChrome != null)
            {
                currentChrome.Dispose();
            }

            //if desktop is highlighted, dispose all chrome windows
            if (desktopChromes.Count > 0)
            {
                foreach (Chrome desktopChrome in desktopChromes)
                {
                    desktopChrome.Dispose();
                }
            }

            //Kill all refreshing threads
            if (RefreshChromeThread != null && RefreshChromeThread.IsAlive)
            {
                RefreshChromeThread.Abort();
            }
            if (RefreshDesktopChromeThread != null && RefreshDesktopChromeThread.IsAlive)
            {
                RefreshDesktopChromeThread.Abort();
            }
        }
    }
}
