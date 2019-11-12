//------------------------------------------------------------------------------
// <copyright file="KinectSensorChooser.xaml.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Microsoft.Samples.Kinect.WpfViewers
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Media.Animation;
    using System.Windows.Navigation;

    using Microsoft.Kinect;

    /// <summary>
    /// Interaction logic for KinectSensorChooser.xaml
    /// </summary>
    public partial class KinectSensorChooser : UserControl
    {
        public static readonly DependencyProperty KinectProperty =
            DependencyProperty.Register("Kinect", typeof(KinectSensor), typeof(KinectSensorChooser), new UIPropertyMetadata(null, new PropertyChangedCallback(KinectPropertyChanged)));

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(KinectSensorChooser), new UIPropertyMetadata(null));

        public static readonly DependencyProperty MoreInfoProperty =
            DependencyProperty.Register("MoreInfo", typeof(string), typeof(KinectSensorChooser), new UIPropertyMetadata(null));

        public static readonly DependencyProperty MoreInfoUriProperty =
            DependencyProperty.Register("MoreInfoUri", typeof(Uri), typeof(KinectSensorChooser), new UIPropertyMetadata(null));

        public static readonly DependencyProperty ShowRetryProperty =
            DependencyProperty.Register("ShowRetry", typeof(bool), typeof(KinectSensorChooser), new UIPropertyMetadata(false));

        public static readonly RoutedEvent KinectSensorChangedEvent = EventManager.RegisterRoutedEvent(
            "KinectSensorChanged", RoutingStrategy.Bubble, typeof(DependencyPropertyChangedEventHandler), typeof(ImageViewer));

        private bool sensorConflict;

        public KinectSensorChooser()
        {
            InitializeComponent();
            this.Loaded += this.KinectSensorChooserLoaded;

            this.IsRequired = true;

            // Setup bindings via code
            Binding binding = new Binding("Message") { Source = this };
            MessageTextBlock.SetBinding(TextBlock.TextProperty, binding);
            Binding binding2 = new Binding("MoreInfo") { Source = this };
            TellMeMoreLink.SetBinding(TextBlock.ToolTipProperty, binding2);
            Binding binding3 = new Binding("MoreInfo") { Source = this, Converter = new NullToVisibilityConverter() };
            TellMeMore.SetBinding(TextBlock.VisibilityProperty, binding3);
            Binding binding4 = new Binding("ShowRetry") { Source = this, Converter = new BoolToVisibilityConverter() };
            RetryButton.SetBinding(Button.VisibilityProperty, binding4);
            Binding binding5 = new Binding("MoreInfoUri") { Source = this };
            TellMeMoreLink.SetBinding(Hyperlink.NavigateUriProperty, binding5);

            this.UpdateMessage(
                KinectStatus.Undefined,
                "Required",
                "This application needs a Kinect for Windows sensor in order to function. Please plug one into the PC.",
                new Uri("http://go.microsoft.com/fwlink/?LinkID=239815"),
                false);
        }

        public event DependencyPropertyChangedEventHandler KinectSensorChanged;

        public bool IsRequired { get; set; }

        public KinectSensor Kinect
        {
            get { return (KinectSensor)GetValue(KinectProperty); }
            set { SetValue(KinectProperty, value); }
        }

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public string MoreInfo
        {
            get { return (string)GetValue(MoreInfoProperty); }
            set { SetValue(MoreInfoProperty, value); }
        }

        public Uri MoreInfoUri
        {
            get { return (Uri)GetValue(MoreInfoUriProperty); }
            set { SetValue(MoreInfoUriProperty, value); }
        }

        public bool ShowRetry
        {
            get { return (bool)GetValue(ShowRetryProperty); }
            set { SetValue(ShowRetryProperty, value); }
        }

        public void AppConflictOccurred()
        {
            if (this.Kinect != null)
            {
                this.sensorConflict = true;

                // sensorConflict is considered when handling status updates,
                // so we call UpdateStatus with the current Status to ensure that the
                // logic takes the sensorConflict into account.
                this.UpdateStatus(this.Kinect.Status);
            }
        }

        private static void KinectPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            KinectSensorChooser sensorChooser = (KinectSensorChooser)d;
            if (sensorChooser.KinectSensorChanged != null)
            {
                sensorChooser.KinectSensorChanged(sensorChooser, args);
            }
        }

        private void KinectSensorChooserLoaded(object sender, RoutedEventArgs e)
        {
            KinectSensor.KinectSensors.StatusChanged += this.KinectSensorsStatusChanged;
            this.DiscoverSensor();
        }

        private void DiscoverSensor()
        {
            // When this control is running in a designer, it should not discover a KinectSensor
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                // Find first sensor that is connected.
                foreach (KinectSensor sensor in KinectSensor.KinectSensors)
                {
                    if (sensor.Status == KinectStatus.Connected)
                    {
                        this.UpdateStatus(sensor.Status);
                        this.Kinect = sensor;
                        break;
                    }
                }

                // If we didn't find a connected Sensor
                if (this.Kinect == null)
                {
                    // NOTE: this doesn't handle the multiple Kinect sensor case very well.
                    foreach (KinectSensor sensor in KinectSensor.KinectSensors)
                    {
                        this.UpdateStatus(sensor.Status);
                    }
                }
            }
        }

        private void KinectSensorsStatusChanged(object sender, StatusChangedEventArgs e)
        {
            var status = e.Status;
            if (this.Kinect == null)
            {
                this.UpdateStatus(status);
                if (e.Status == KinectStatus.Connected)
                {
                    this.Kinect = e.Sensor;
                }
            }
            else
            {
                if (this.Kinect == e.Sensor)
                {
                    this.UpdateStatus(status);
                    if (e.Status == KinectStatus.Disconnected ||
                        e.Status == KinectStatus.NotPowered)
                    {
                        this.Kinect = null;
                        this.sensorConflict = false;
                        this.DiscoverSensor();
                    }
                }
            }
        }

        private void UpdateStatus(KinectStatus status)
        {
            string message = null;
            string moreInfo = null;
            Uri moreInfoUri = null;
            bool showRetry = false;

            switch (status)
            {
                case KinectStatus.Connected:
                    // If there's a sensor conflict, we wish to display all of the normal 
                    // states and statuses, with the exception of Connected.
                    if (this.sensorConflict)
                    {
                        message = "This Kinect is being used by another application.";
                        moreInfo = "This application needs a Kinect for Windows sensor in order to function. However, another application is using the Kinect Sensor.";
                        moreInfoUri = new Uri("http://go.microsoft.com/fwlink/?LinkID=239812");
                        showRetry = true;
                    }
                    else
                    {
                        message = "All set!";
                        moreInfo = null;
                        moreInfoUri = null;
                    }

                    break;
                case KinectStatus.DeviceNotGenuine:
                    message = "This sensor is not genuine!";
                    moreInfo = "This application needs a genuine Kinect for Windows sensor in order to function. Please plug one into the PC.";
                    moreInfoUri = new Uri("http://go.microsoft.com/fwlink/?LinkID=239813");

                    break;
                case KinectStatus.DeviceNotSupported:
                    message = "Kinect for Xbox not supported.";
                    moreInfo = "This application needs a Kinect for Windows sensor in order to function. Please plug one into the PC.";
                    moreInfoUri = new Uri("http://go.microsoft.com/fwlink/?LinkID=239814");

                    break;
                case KinectStatus.Disconnected:
                    if (this.IsRequired)
                    {
                        message = "Required";
                        moreInfo = "This application needs a Kinect for Windows sensor in order to function. Please plug one into the PC.";
                        moreInfoUri = new Uri("http://go.microsoft.com/fwlink/?LinkID=239815");
                    }
                    else
                    {
                        message = "Get the full experience by plugging in a Kinect for Windows sensor.";
                        moreInfo = "This application will use a Kinect for Windows sensor if one is plugged into the PC.";
                        moreInfoUri = new Uri("http://go.microsoft.com/fwlink/?LinkID=239816");
                    }

                    break;
                case KinectStatus.NotReady:
                case KinectStatus.Error:
                    message = "Oops, there is an error.";
                    moreInfo = "The Kinect Sensor is plugged in, however an error has occured. For steps to resolve, please click the \"Tell me more\" link.";
                    moreInfoUri = new Uri("http://go.microsoft.com/fwlink/?LinkID=239817");
                    break;
                case KinectStatus.Initializing:
                    message = "Initializing...";
                    moreInfo = null;
                    moreInfoUri = null;
                    break;
                case KinectStatus.InsufficientBandwidth:
                    message = "Too many USB devices! Please unplug one or more.";
                    moreInfo = "The Kinect Sensor needs the majority of the USB Bandwidth of a USB Controller. If other devices are in contention for that bandwidth, the Kinect Sensor may not be able to function.";
                    moreInfoUri = new Uri("http://go.microsoft.com/fwlink/?LinkID=239818");
                    break;
                case KinectStatus.NotPowered:
                    message = "Plug my power cord in!";
                    moreInfo = "The Kinect Sensor is plugged into the computer with its USB connection, but the power plug appears to be not powered.";
                    moreInfoUri = new Uri("http://go.microsoft.com/fwlink/?LinkID=239819");
                    break;
            }

            this.UpdateMessage(status, message, moreInfo, moreInfoUri, showRetry);
        }

        private void UpdateMessage(KinectStatus status, string message, string moreInfo, Uri moreInfoUri, bool showRetry)
        {
            this.Message = message;
            this.MoreInfo = moreInfo;
            this.MoreInfoUri = moreInfoUri;
            this.ShowRetry = showRetry;

            if ((status == KinectStatus.Connected) && !this.sensorConflict)
            {
                var fadeAnimation = new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(500)));

                fadeAnimation.Completed += (sender, args) =>
                {
                    // If we've reached the end of the animation and achieved total transparency, 
                    // the chooser should no longer be clickable - hide it.
                    if (this.Opacity == 0)
                    {
                        this.Visibility = Visibility.Hidden;
                    }
                };

                this.BeginAnimation(UserControl.OpacityProperty, fadeAnimation, HandoffBehavior.SnapshotAndReplace);
            }
            else
            {
                // The chooser is heading towards opaque - as long as it's not completely transparent, 
                // it should be Visible and clickable.
                this.Visibility = Visibility.Visible;

                var fadeAnimation = new DoubleAnimation(1.0, new Duration(TimeSpan.FromMilliseconds(500)));
                this.BeginAnimation(UserControl.OpacityProperty, fadeAnimation, HandoffBehavior.SnapshotAndReplace);
            }
        }

        private void RetryButtonClick(object sender, RoutedEventArgs e)
        {
            this.sensorConflict = false;
            var sensorToRetry = this.Kinect;

            // Necessary to null the Kinect value first. Otherwise, no property change will be detected.
            this.Kinect = null;
            this.Kinect = sensorToRetry;

            this.UpdateStatus(KinectStatus.Connected);
        }

        private void TellMeMoreLinkRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Hyperlink hyperlink = e.OriginalSource as Hyperlink;
            if (hyperlink != null)
            {
                // Careful - ensure that this NavigateUri comes from a trusted source, as in this sample, before launching a process using it.
                Process.Start(new ProcessStartInfo(hyperlink.NavigateUri.ToString()));
            }

            e.Handled = true;
        }
    }

    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isVisible = value != null;
            return isVisible ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isVisible = (bool)value;
            return isVisible ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
