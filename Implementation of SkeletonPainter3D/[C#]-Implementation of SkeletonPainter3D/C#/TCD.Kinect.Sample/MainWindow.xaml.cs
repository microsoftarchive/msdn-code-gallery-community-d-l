using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;

namespace TCD.Kinect.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KinectSensor sensor = null;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                sensor = KinectSensor.KinectSensors.FirstOrDefault();
                if (sensor == null)
                    return;
                sensor.SkeletonFrameReady += sensor_SkeletonFrameReady;
                sensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Default;
                sensor.SkeletonStream.Enable();
                sensor.Start();
            }
            catch { this.Title = "Error =/"; }
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (sensor == null)
                return;
            sensor.Stop();
            sensor.Dispose();
            base.OnClosing(e);
        }

        private void sensor_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            SkeletonFrame frame = e.OpenSkeletonFrame();
            if (frame == null)
                return;
            Skeleton[] skeletons = new Skeleton[frame.SkeletonArrayLength];
            frame.CopySkeletonDataTo(skeletons);
            frame.Dispose();
            //TODO: draw additional objects
            //Model3DCollection group = new Model3DCollection();
            painter.Draw(skeletons);
        }
    }
}
