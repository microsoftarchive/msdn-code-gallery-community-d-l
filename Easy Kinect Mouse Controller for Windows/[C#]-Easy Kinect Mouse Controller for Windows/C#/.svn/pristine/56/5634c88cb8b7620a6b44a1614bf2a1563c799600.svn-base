using System;
using System.Windows;
using System.Windows.Forms;
using Microsoft.Kinect;
using Coding4Fun.Kinect.Wpf;
using System.Diagnostics;

namespace KinectCursorController
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private const float ClickHoldingRectThreshold = 0.05f;
        private Rect _clickHoldingLastRect;
        private readonly Stopwatch _clickHoldingTimer;
  
        private const float SkeletonMaxX = 0.60f;
        private const float SkeletonMaxY = 0.40f;
        private readonly NotifyIcon _notifyIcon = new NotifyIcon();


        public MainWindow()
        {
            InitializeComponent();

            // create tray icon
            _notifyIcon.Icon = new System.Drawing.Icon("CursorControl.ico");
            _notifyIcon.Visible = true;
            _notifyIcon.DoubleClick += delegate
            {
                Show();
                WindowState = WindowState.Minimized;
                Focus();
            };

            _clickHoldingTimer = new Stopwatch();
        }


        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            kinectSensorChooser.KinectSensorChanged += KinectSensorChooserKinectSensorChanged;
        }


        private void WindowStateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                Hide();
            }
        }


        private void WindowClosed(object sender, EventArgs e)
        {
            _notifyIcon.Visible = false;

            if (kinectSensorChooser.Kinect != null)
            {
                kinectSensorChooser.Kinect.Stop();
            }
        }


        void KinectSensorChooserKinectSensorChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var old = (KinectSensor)e.OldValue;

            StopKinect(old);

            var sensor = (KinectSensor)e.NewValue;

            if (sensor == null)
            {
                return;
            }

            var parameters = new TransformSmoothParameters();
            parameters.Smoothing = 0.7f;
            parameters.Correction = 0.3f;
            parameters.Prediction = 0.4f;
            parameters.JitterRadius = 1.0f;
            parameters.MaxDeviationRadius = 0.5f;

            sensor.SkeletonStream.Enable(parameters);
            
            sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
            sensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);

            sensor.AllFramesReady += SensorAllFramesReady;
            try
            {
                sensor.Start();
            }
            catch (System.IO.IOException)
            {
                //another app is using Kinect
                kinectSensorChooser.AppConflictOccurred();
            }
        }


        void SensorAllFramesReady(object sender, AllFramesReadyEventArgs e)
        {
            SensorDepthFrameReady(e);
            SensorSkeletonFrameReady(e);
        }


        void SensorDepthFrameReady(AllFramesReadyEventArgs e)
        {
            // if the window is displayed, show the depth buffer image
            if (WindowState == WindowState.Normal)
            {
                using (DepthImageFrame depthFrame = e.OpenDepthImageFrame())
                {
                    if (depthFrame == null)
                    {
                        return;
                    }

                    video.Source = depthFrame.ToBitmapSource();
                }
            }
        }


        void SensorSkeletonFrameReady(AllFramesReadyEventArgs e)
        {
            using (SkeletonFrame skeletonFrameData = e.OpenSkeletonFrame())
            {
                if (skeletonFrameData == null)
                {
                    return;
                }

                var allSkeletons = new Skeleton[skeletonFrameData.SkeletonArrayLength];

                skeletonFrameData.CopySkeletonDataTo(allSkeletons);

                foreach (Skeleton sd in allSkeletons)
                {
                    // the first found/tracked skeleton moves the mouse cursor
                    if (sd.TrackingState == SkeletonTrackingState.Tracked)
                    {
                        // make sure both hands are tracked
                        if (sd.Joints[JointType.HandRight].TrackingState == JointTrackingState.Tracked)
                        {
                            var wristRight = sd.Joints[JointType.WristRight];
                            var scaledRightHand = wristRight.ScaleTo((int)SystemParameters.PrimaryScreenWidth, (int)SystemParameters.PrimaryScreenHeight, SkeletonMaxX, SkeletonMaxY);

                            var cursorX = (int)scaledRightHand.Position.X + (int)MouseSpeed.Value;
                            var cursorY = (int)scaledRightHand.Position.Y + (int)MouseSpeed.Value;

                            var leftClick = CheckForClickHold(scaledRightHand);
                            NativeMethods.SendMouseInput(cursorX, cursorY, (int)SystemParameters.PrimaryScreenWidth, (int)SystemParameters.PrimaryScreenHeight, leftClick);
                        }
                    }
                }
            }
        }


        private bool CheckForClickHold(Joint hand)
        {
            // This does one handed click when you hover for the allotted time.  It gives a false positive when you hover accidentally.
            var x = hand.Position.X;
            var y = hand.Position.Y;

            var screenwidth = (int)SystemParameters.PrimaryScreenWidth;
            var screenheight = (int)SystemParameters.PrimaryScreenHeight;
            var clickwidth = (int)(screenwidth * ClickHoldingRectThreshold);
            var clickheight = (int)(screenheight * ClickHoldingRectThreshold);

            var newClickHold = new Rect(x - clickwidth, y - clickheight, clickwidth * 2, clickheight * 2);

            if (_clickHoldingLastRect != Rect.Empty)
            {
                if (newClickHold.IntersectsWith(_clickHoldingLastRect))
                {
                    if ((int)_clickHoldingTimer.ElapsedMilliseconds > (ClickDelay.Value * 1000))
                    {
                        _clickHoldingTimer.Stop();
                        _clickHoldingLastRect = Rect.Empty;
                        return true;
                    }

                    if (!_clickHoldingTimer.IsRunning)
                    {
                        _clickHoldingTimer.Reset();
                        _clickHoldingTimer.Start();
                    }
                    return false;
                }

                _clickHoldingTimer.Stop();
                _clickHoldingLastRect = newClickHold;
                return false;
            }

            _clickHoldingLastRect = newClickHold;
            if (!_clickHoldingTimer.IsRunning)
            {
                _clickHoldingTimer.Reset();
                _clickHoldingTimer.Start();
            }
            return false;
        }



        private void StopKinect(KinectSensor sensor)
        {
            if (sensor == null || !sensor.IsRunning) return;

            sensor.Stop();
            sensor.AudioSource.Stop();
        }
    }
}
