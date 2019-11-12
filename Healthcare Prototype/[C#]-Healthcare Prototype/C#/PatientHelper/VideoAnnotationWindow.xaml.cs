using System;
using System.IO;
using System.ComponentModel;
using System.Collections;
using System.Collections.Specialized;
using System.Windows.Data;
using System.Windows.Navigation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Threading;
using System.Windows.Markup;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Security;
using System.Windows.Interop;
using System.Windows.Ink;


namespace IdentityMine.Avalon.Controls
{


    public partial class VideoAnnotationWindow : Window
    {
        public VideoAnnotationWindow()
        {
            InitializeComponent();
        }

        void OnInitialized(object sender, EventArgs e)
        {

            // setup shopping cart
            _VideoAnnotation = new VideoAnnotation();
            _VideoAnnotation.Data = (VideoAnnotationData)this.FindResource("VideoAnnotationData");


            string path = AppPath + _ANNOTATION_FILE;
            VideoAnnotation sc = new VideoAnnotation();
            sc.ImportFromFile(path);

            if ((sc.Data != null) && (sc.Data.VideoAnnotationItems.Count > 0))
            {
                foreach (VideoAnnotationItem sci in sc.Data.VideoAnnotationItems)
                {
                    _VideoAnnotation.Add(sci.Strokes, sci.ID, sci.Description, sci.InkTimeSpan, new Point(sci.PositionLeft, sci.PositionTop));
                }
            }

        }

        private void OnLoaded(object sender, EventArgs e)
        {
        }

        #region Properties

        public static string AppPath
        {
            get
            {
                return System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\";
            }
        }

        #endregion

        #region Events

        #region Buttons

        private void OnBeginButton(object sender, RoutedEventArgs e)
        {
            _CurrentSecond = 0;
        }

        private void OnPauseButton(object sender, RoutedEventArgs e)
        {
            EnableAnnotations();
        }

        private void OnDeleteButton(object sender, RoutedEventArgs e)
        {
            _VideoAnnotation.Data.VideoAnnotationItems.Clear();
            TextBox1.Text = "";
            DisableAnnotations();
            ToggleButton1.IsChecked = false;
            ToggleButton1.Content = "Annotate";

        }

        private void OnResumeButton(object sender, RoutedEventArgs e)
        {
            ToggleButton1.IsChecked = false;
            ToggleButton1.Content = "Annotate";
            AnnotationsListBox.UnselectAll();
            DisableAnnotations();

        }

        private void OnAnnotationToggle(object sender, RoutedEventArgs e)
        {
            ToggleButton tb = sender as ToggleButton;
            Point pt = new Point();

            if (tb == null)
                return;

            if (tb.IsChecked == true)
            {
                ToggleButton1.Content = "Save";
                //Button2.Visibility = Visibility.Visible;
                _PausedMediaTimeSpan = new TimeSpan(_CurrentMediaTimeSpan.Ticks);

                Button1.RaiseEvent(e); // forward click event to pause button
                Application.Current.Windows[1].Height = _ANNOTATE_HEIGHT;
            }
            else
            {
                // save the annotation
                //if (myInkCanvas.Strokes.Count != 0)
                {
                    ToggleButton1.Content = "Annotate";
                    //Button2.Visibility = Visibility.Collapsed;

                    TransformGroup tg = Ellipse2.RenderTransform as TransformGroup;
                    TranslateTransform tt = tg.Children[5] as TranslateTransform;
                    pt.X = tt.X;

                    tg = Ellipse2.RenderTransform as TransformGroup;
                    tt = tg.Children[5] as TranslateTransform;
                    pt.Y = tt.Y;

                    _VideoAnnotation.Add(myInkCanvas.Strokes.Clone(), _CurrentAnnotationID.ToString(), TextBox1.Text, _PausedMediaTimeSpan, pt);

                    _CurrentAnnotationID++;
                }

                Button2.RaiseEvent(e); // forward click event to resume button



            }

        }

        #endregion

        #region Animations

        private void OnCurrentTimeInvalidated(object sender, EventArgs e)
        {
            Clock clock = (Clock)sender;

            if (clock == null)
                return;

            _CurrentMediaTimeSpan = new TimeSpan(clock.CurrentTime.Value.Ticks);
            TimerText.Text = _CurrentMediaTimeSpan.ToString();
            Slider1.Value = _CurrentMediaTimeSpan.Seconds;

            //DebugHelp3D.Trace.Message(_CurrentMediaTimeSpan.TotalSeconds.ToString());

            // determine if we need to pause and show an annotation
            if (((int)_CurrentMediaTimeSpan.TotalSeconds) == 0)
            {
                _CurrentSecond = 0;
            }
            if (_CurrentSecond <= (int)_CurrentMediaTimeSpan.TotalSeconds)
            {
                //DebugHelp3D.Trace.Message(_CurrentSecond.ToString());
                VideoAnnotationItem sci = _VideoAnnotation.FindAnnotation(_CurrentMediaTimeSpan);

                if (sci != null)
                {
                    Storyboard s = (Storyboard)DocumentRoot.FindResource("OnLoaded");
                    s.Seek(DocumentRoot, TimeSpan.FromSeconds(sci.InkTimeSpan.TotalSeconds), TimeSeekOrigin.BeginTime);
                    PauseShowAnnotation(sci);

                }

                _CurrentSecond = (int)_CurrentMediaTimeSpan.TotalSeconds + 1;
            }
        }

        private void OnStoryboardInvalidated(object sender, EventArgs e)
        {

            Clock clock = (Clock)sender;

            if (clock == null)
                return;

            if (clock.CurrentState != ClockState.Active)  // Ended case
            {
                return;
            }

        }

        #endregion

        #region ListBox

        void OnAnnotationsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((e.AddedItems == null) || (e.AddedItems.Count == 0))
                return;

            VideoAnnotationItem sci = e.AddedItems[0] as VideoAnnotationItem;

            if (sci == null)
                return;

            SeekShowAnnotation(sci);
        }

        #endregion

        #region Slider

        private void SeekClick(object sender, RoutedEventArgs e)
        {
            Storyboard s = (Storyboard)this.FindResource("OnLoaded");
            s.Seek(DocumentRoot, TimeSpan.FromSeconds(15), TimeSeekOrigin.BeginTime);
        }

        private void Slider_MouseDown(object sender, RoutedEventArgs e)
        {
            Storyboard s = (Storyboard)this.FindResource("OnLoaded");
            s.Pause(DocumentRoot);
        }
        private void Slider_MouseUp(object sender, RoutedEventArgs e)
        {
            Slider slider = (Slider)sender;
            TimeSpan SliderTimeSpan = new TimeSpan(System.Convert.ToInt64(slider.Value));


            Storyboard s = (Storyboard)this.FindResource("OnLoaded");
            s.Seek(DocumentRoot, TimeSpan.FromSeconds(slider.Value), TimeSeekOrigin.BeginTime);
            s.Resume(DocumentRoot);
            AnnotationsListBox.UnselectAll();
            DisableAnnotations();
            _CurrentSecond = SliderTimeSpan.Seconds;
        }
        private void Slider_ValueChanged(object sender, RoutedEventArgs e)
        {
            Slider slider = (Slider)sender;
            TimeSpan SliderTimeSpan = new TimeSpan(System.Convert.ToInt64(slider.Value));

            Storyboard s = (Storyboard)this.FindResource("OnLoaded");
            s.Seek(DocumentRoot, TimeSpan.FromSeconds(slider.Value), TimeSeekOrigin.BeginTime);
            TimerText.Text = _CurrentMediaTimeSpan.ToString();

        }

        #endregion

        #region Keyboard

        private void OnKeyDown(object sender, KeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.F2:
                    string path = AppPath + _ANNOTATION_FILE;
                    _VideoAnnotation.ExportToFile(path);
                    break;
            }
        }


        #endregion

        #endregion

        #region Private Methods

        private void EnableAnnotations()
        {
            myInkCanvas.Visibility = Visibility.Visible;
            TextBox1.Visibility = Visibility.Visible;
        }

        private void DisableAnnotations()
        {

            myInkCanvas.Visibility = Visibility.Collapsed;
            TextBox1.Visibility = Visibility.Collapsed;
            myInkCanvas.Strokes.Clear();
            TextBox1.Text = "";
            Application.Current.Windows[1].Height = _DEFAULT_HEIGHT;
            
        }

        private void PauseShowAnnotation(VideoAnnotationItem sci)
        {
            if (sci == null)
                return;

            Application.Current.Windows[1].Height = _ANNOTATE_HEIGHT;
            ToggleButton1.IsChecked = true;
            ToggleButton1.Content = "Save";
            myInkCanvas.Strokes = sci.Strokes.Clone();
            TextBox1.Text = sci.Description;
            Button1.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // forward click event to pause button
        }

        private void SeekShowAnnotation(VideoAnnotationItem sci)
        {
            if (sci == null)
                return;

            PauseShowAnnotation(sci);
            Storyboard s = (Storyboard)DocumentRoot.FindResource("OnLoaded");
            s.Seek(DocumentRoot, TimeSpan.FromSeconds(sci.InkTimeSpan.TotalSeconds), TimeSeekOrigin.BeginTime);
            _CurrentSecond = (int)sci.InkTimeSpan.TotalSeconds;

        }

        #endregion

        #region Globals

        VideoAnnotation _VideoAnnotation;
        int _CurrentAnnotationID = 0;
        TimeSpan _PausedMediaTimeSpan;
        TimeSpan _CurrentMediaTimeSpan;
        int _CurrentSecond = 0;

        // Constants
        const string _ANNOTATION_FILE = "annotations.xml";
        const double _ANNOTATE_HEIGHT = 600;
        const double _DEFAULT_HEIGHT = 500;

        #endregion
    }

    namespace DebugHelp3D
    {
        using System.Runtime.InteropServices;
        using System.Text;
        using System.IO;
        // Trace Syntax:
        //		DebugHelp.Trace.Message(a string);
        //
        // Launch "start DBMon" to see the output
        public class Trace
        {
            [DllImport("kernel32.dll", EntryPoint = "OutputDebugStringW", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            private static extern void OutputDebugString(string msg);

            public static void Message(string msg)
            {
                OutputDebugString(msg + "\n");
            }
        }

        public class FileTest
        {
            private static string filePath = System.Environment.GetEnvironmentVariable("TMP").ToString() + @"\log.txt";

            public static void WriteFile(string input)
            {
                FileInfo logFile = new FileInfo(filePath);

                if (logFile.Exists)
                {
                    if (logFile.Length >= 1000000)
                        File.Delete(filePath);
                }

                FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamWriter w = new StreamWriter(fs);

                w.BaseStream.Seek(0, SeekOrigin.End);
                w.Write(input);
                w.Flush();
                w.Close();
            }

            public static string ReadFile()
            {
                FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StringBuilder output = new StringBuilder();

                output.Length = 0;

                StreamReader r = new StreamReader(fs);

                r.BaseStream.Seek(0, SeekOrigin.Begin);
                while (r.Peek() > -1)
                {
                    output.Append(r.ReadLine() + "\n");
                }

                r.Close();
                return output.ToString();
            }
        }
    }

}