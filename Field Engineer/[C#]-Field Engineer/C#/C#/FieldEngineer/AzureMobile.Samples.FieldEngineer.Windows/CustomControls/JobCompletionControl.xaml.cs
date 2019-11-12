// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using AzureMobile.Samples.FieldEngineer.DataModels;
using AzureMobile.Samples.FieldEngineer.DataSources;
using Capptain.Agent;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.Input.Inking;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace AzureMobile.Samples.FieldEngineer.CustomControls
{
    public sealed partial class JobCompletionControl : UserControl
    {
        private List<Point> points = new List<Point>();
        private bool signed;
        private InkManager inkManager = new InkManager();
        private uint penID;
        private uint touchID;
        private Point previousContactPt;
        private Point currentContactPt;
        private double x1;
        private double y1;
        private double x2;
        private double y2;
        private Job job;

        public JobCompletionControl()
        {
            this.InitializeComponent();
            this.Loaded += this.CustomerSignature_Loaded;
            ErrorMessage.Visibility = Visibility.Collapsed;
            PanelCanvas.PointerPressed += this.InkCanvas_PointerPressed;
            PanelCanvas.PointerMoved += this.InkCanvas_PointerMoved;
            PanelCanvas.PointerReleased += this.InkCanvas_PointerReleased;
            PanelCanvas.PointerExited += this.InkCanvas_PointerReleased;
        }

        private void CustomerSignature_Loaded(object sender, RoutedEventArgs e)
        {
            this.ClearCanvas();
        }

        #region Navigation Methods

        public void InkCanvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (e.Pointer.PointerId == this.penID)
            {
                PointerPoint pt = e.GetCurrentPoint(PanelCanvas);

                // Pass the pointer information to the InkManager. 
                this.inkManager.ProcessPointerUp(pt);
            }
            else if (e.Pointer.PointerId == this.touchID)
            {
                // Process touch input
                PointerPoint pt = e.GetCurrentPoint(PanelCanvas);

                // Pass the pointer information to the InkManager. 
                this.inkManager.ProcessPointerUp(pt);
            }

            this.touchID = 0;
            this.penID = 0;

            // Call an application-defined function to render the ink strokes.

            e.Handled = true;
        }

        private void InkCanvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (e.Pointer.PointerId == this.penID)
            {
                PointerPoint pt = e.GetCurrentPoint(PanelCanvas);

                // Render a red line on the canvas as the pointer moves. 
                // Distance() is an application-defined function that tests
                // whether the pointer has moved far enough to justify 
                // drawing a new line.
                this.currentContactPt = pt.Position;
                this.x1 = this.previousContactPt.X;
                this.y1 = this.previousContactPt.Y;
                this.x2 = this.currentContactPt.X;
                this.y2 = this.currentContactPt.Y;

                if (this.Distance(this.x1, this.y1, this.x2, this.y2) > 2.0)
                {
                    Line line = new Line()
                    {
                        X1 = this.x1,
                        Y1 = this.y1,
                        X2 = this.x2,
                        Y2 = this.y2,
                        StrokeThickness = 3.0,
                        Stroke = new SolidColorBrush(Colors.Black)
                    };

                    this.previousContactPt = this.currentContactPt;

                    // Draw the line on the canvas by adding the Line object as
                    // a child of the Canvas object.
                    PanelCanvas.Children.Add(line);

                    // Pass the pointer information to the InkManager.
                    this.inkManager.ProcessPointerUpdate(pt);
                }
            }
            else if (e.Pointer.PointerId == this.touchID)
            {
                // Process touch input
                PointerPoint pt = e.GetCurrentPoint(PanelCanvas);

                // Render a red line on the canvas as the pointer moves. 
                // Distance() is an application-defined function that tests
                // whether the pointer has moved far enough to justify 
                // drawing a new line.
                this.currentContactPt = pt.Position;
                this.x1 = this.previousContactPt.X;
                this.y1 = this.previousContactPt.Y;
                this.x2 = this.currentContactPt.X;
                this.y2 = this.currentContactPt.Y;

                if (this.Distance(this.x1, this.y1, this.x2, this.y2) > 2.0)
                {
                    Line line = new Line()
                    {
                        X1 = this.x1,
                        Y1 = this.y1,
                        X2 = this.x2,
                        Y2 = this.y2,
                        StrokeThickness = 4.0,
                        Stroke = new SolidColorBrush(Colors.Green)
                    };

                    this.previousContactPt = this.currentContactPt;

                    // Draw the line on the canvas by adding the Line object as
                    // a child of the Canvas object.
                    PanelCanvas.Children.Add(line);

                    // Pass the pointer information to the InkManager.
                    this.inkManager.ProcessPointerUpdate(pt);
                }
            }
        }

        private double Distance(double x1, double y1, double x2, double y2)
        {
            double d;
            d = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return d;
        }

        public void InkCanvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            // Get information about the pointer location.
            PointerPoint pt = e.GetCurrentPoint(PanelCanvas);
            this.previousContactPt = pt.Position;

            // Accept input only from a pen or mouse with the left button pressed. 
            PointerDeviceType pointerDevType = e.Pointer.PointerDeviceType;
            if (pointerDevType == PointerDeviceType.Pen ||
                    (pointerDevType == PointerDeviceType.Mouse && pt.Properties.IsLeftButtonPressed))
            {
                // Pass the pointer information to the InkManager.
                this.inkManager.ProcessPointerDown(pt);
                this.penID = pt.PointerId;

                e.Handled = true;
            }
            else if (pointerDevType == PointerDeviceType.Touch)
            {
                // Process touch input
                this.inkManager.ProcessPointerDown(pt);
                this.penID = pt.PointerId;

                e.Handled = true;
            }
        }
        #endregion Navigation Methods

        /// <summary>
        /// On click of erase, clear the signature
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Erase_Click(object sender, RoutedEventArgs e)
        {
            this.ClearCanvas();
        }

        /// <summary>
        /// Clear the Canvas
        /// </summary>
        private void ClearCanvas()
        {
            this.inkManager.Mode = InkManipulationMode.Erasing;
            var strokes = this.inkManager.GetStrokes();

            for (int i = 0; i < strokes.Count; i++)
            {
                strokes[i].Selected = true;
            }

            this.inkManager.DeleteSelected();

            PanelCanvas.Background = new SolidColorBrush(Colors.White);
            PanelCanvas.Children.Clear();

            CapptainAgent.Instance.SendSessionEvent("Job completion signature cleared");
        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            this.signed = PanelCanvas.Children.Count > 0 ? true : false;
            if (!this.signed)
            {
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            await DataManager.JobDataSource.UpdateJobStatus(this.job.Id);
            var message = new MessageDialog("You have completed your job. Email report will be sent to your manager", "Field Engineer");
            await message.ShowAsync();
            var currentFrame = Window.Current.Content as Frame;
            
            CapptainAgent.Instance.SendSessionEvent("Job completed with sign off");

            currentFrame.Navigate(typeof(JobListPage), null);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                this.job = (this.DataContext as AzureMobile.Samples.FieldEngineer.Common.ObservableDictionary)
                    .Where(item => item.Key.Equals("Job")).FirstOrDefault().Value as Job;
                CustomerNameTextbox.Text = (this.job as Job).Customer.FullName;
            }

            CapptainAgent.Instance.SendSessionEvent("Job completion window loaded");
        }
    }
}
