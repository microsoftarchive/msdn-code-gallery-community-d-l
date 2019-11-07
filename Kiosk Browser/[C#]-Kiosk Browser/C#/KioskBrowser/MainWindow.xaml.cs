using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;

namespace KioskBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer mIdle;

        private const long cIdleSeconds = 120;

        public MainWindow()
        {
            InitializeComponent();

            InputManager.Current.PreProcessInput += Idle_PreProcessInput;
            mIdle = new DispatcherTimer();
            mIdle.Interval = new TimeSpan(cIdleSeconds * 1000 * 10000);
            mIdle.IsEnabled = true;
            mIdle.Tick += Idle_Tick;
        }

        void Idle_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                EndSession();
        }

        void Idle_PreProcessInput(object sender, PreProcessInputEventArgs e)
        {
            mIdle.IsEnabled = false;
            mIdle.IsEnabled = true;
        }

        static DateTime end = new DateTime();

        private const int INTERNET_OPTION_END_BROWSER_SESSION = 42;
        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);

        Timer timer1 = new Timer();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Taskbar.Hide();

            button1.Visibility = Visibility.Visible;
            button2.Visibility = Visibility.Hidden;
            host.Visibility = Visibility.Hidden;
            label1.Visibility = Visibility.Hidden;
            lblTime.Text = "10:00";
            timer1.Enabled = false;

            #region AddBrowser
            webBrowser1.AllowWebBrowserDrop = false;
            webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            webBrowser1.IsWebBrowserContextMenuEnabled = false;
            webBrowser1.Name = "webBrowser1";
            webBrowser1.TabIndex = 0;
            webBrowser1.Url = new System.Uri("http://msdn.microsoft.com/en-US/", System.UriKind.Absolute);
            webBrowser1.WebBrowserShortcutsEnabled = false;
            webBrowser1.NewWindow += new System.ComponentModel.CancelEventHandler(this.webBrowser1_NewWindow);
            #endregion

            #region AddTimer
            timer1.Interval = 1000;
            timer1.Tick += new System.EventHandler(this.timer1_Tick);
            #endregion

            #region AddEndButton
            btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            btnEnd.Font = new System.Drawing.Font(btnEnd.Font.FontFamily, btnEnd.Font.Size, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnEnd.Image = Properties.Resources.endsession;
            #endregion

            #region AddLabel
            lblTime.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTime.ForeColor = System.Drawing.Color.Red;
            lblTime.BackColor = System.Drawing.Color.Transparent;
            #endregion
        }

        private void webBrowser1_NewWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            StartSession();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            EndSession();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan use = end - DateTime.Now;
            lblTime.Text = string.Format("{0:D2}:{1:D2}", use.Minutes, use.Seconds);

            if (use <= TimeSpan.FromSeconds(0))
                EndSession();
        }

        private void StartSession()
        {
            host.Visibility = Visibility.Visible;
            button2.Visibility = Visibility.Visible;

            label1.Visibility = Visibility.Visible;
            timer1.Enabled = true;
            end = DateTime.Now.AddMinutes(10);
        }

        private void EndSession()
        {
            webBrowser1.Document.Window.Navigate("http://msdn.microsoft.com/en-US/");
            System.Threading.Thread.Sleep(1000);
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_END_BROWSER_SESSION, IntPtr.Zero, 0);
            webBrowser1.Document.Window.Navigate("http://msdn.microsoft.com/en-US/");

            button2.Visibility = Visibility.Hidden;
            host.Visibility = Visibility.Hidden;
            label1.Visibility = Visibility.Hidden;
            lblTime.Text = "10:00";
            timer1.Enabled = false;
            end = new DateTime();
        }
    }
}
