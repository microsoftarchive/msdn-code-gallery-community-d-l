using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;

namespace WPF_DynamicSplashScreen.Startup
{

    public partial class SplashScreen
    {
        public static readonly DependencyProperty AvailablePluginsProperty =
            DependencyProperty.Register("AvailablePlugins", typeof (IEnumerable<string>), typeof (SplashScreen),
                                        new UIPropertyMetadata(null));

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof (string), typeof (SplashScreen),
                                        new UIPropertyMetadata(null, OnMessageChanged));


        public static readonly DependencyProperty LicenseeProperty =
            DependencyProperty.Register("Licensee", typeof (string), typeof (SplashScreen), new UIPropertyMetadata(null));


        public SplashScreen()
        {
            this.InitializeComponent();

            //simulate long splash screen loading
            Thread.Sleep(1000);
        }

        public string Licensee
        {
            get { return (string) this.GetValue(LicenseeProperty); }
            set { this.SetValue(LicenseeProperty, value); }
        }


        public IEnumerable<string> AvailablePlugins
        {
            get { return (IEnumerable<string>) this.GetValue(AvailablePluginsProperty); }
            set { this.SetValue(AvailablePluginsProperty, value); }
        }


        public string Message
        {
            get { return (string) this.GetValue(MessageProperty); }
            set { this.SetValue(MessageProperty, value); }
        }


        public event EventHandler MessageChanged;

        private void RaiseMessageChanged(EventArgs e)
        {
            EventHandler handler = this.MessageChanged;
            if (handler != null) handler(this, e);
        }

        private static void OnMessageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SplashScreen splashScreen = (SplashScreen) d;
            splashScreen.RaiseMessageChanged(EventArgs.Empty);
            //splashScreen.messageTextBlock.Text = splashScreen.Message;
        }
    }
}