using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Interactivity;
using System.Windows.Documents;
using System.Windows.Controls;
using Windows7.Multitouch.Manipulation;
using System.Drawing;
using System.Collections.Generic;
using System;
using System.IO;


namespace IdentityMine.Windows.SimpleMultitouch
{

    /// <summary>
    /// A Inertia Enabled Scroll Behavior to apply to a scrollviewer
    /// </summary>
    public class ScrollBehavior : Behavior<ScrollViewer>, IPhysicalObject
    {
        #region Data
        private ScrollViewer _attachedElement;
        private ManipulationProcessor _processor;
        private Vector _delta;
        private SortedDictionary<int, System.Windows.Point> _pts;
        #endregion

        public ScrollBehavior()
        {
            try
            {
                _processor = new ManipulationProcessor(ProcessorManipulations.TRANSLATE_X | ProcessorManipulations.TRANSLATE_Y);
                _pts = new SortedDictionary<int, System.Windows.Point>();
            }
            catch { }
        }
   
        #region Behaviour Overrides

        protected override void OnAttached()
        {
            if (_processor == null) return;

            base.OnAttached();

            _attachedElement = (ScrollViewer)this.AssociatedObject;

            _attachedElement.PreviewStylusDown += OnStylusStuff;
            _attachedElement.PreviewStylusMove += OnStylusStuff;
            _attachedElement.PreviewStylusUp += OnStylusStuff;
            _attachedElement.PreviewMouseDown += OnMouseStuff;
            _attachedElement.PreviewMouseMove += OnMouseStuff;
            _attachedElement.PreviewMouseUp += OnMouseStuff;

            //Handle the ManipulationDelta and the gestures
            _processor.ManipulationDelta += ProcessManipulationDelta;
            _processor.PivotRadius = 2;
        }

        protected override void OnDetaching()
        {
            _attachedElement.PreviewStylusDown -= OnStylusStuff;
            _attachedElement.PreviewStylusMove -= OnStylusStuff;
            _attachedElement.PreviewStylusUp -= OnStylusStuff;
            _attachedElement.PreviewMouseDown -= OnMouseStuff;
            _attachedElement.PreviewMouseMove -= OnMouseStuff;
            _attachedElement.PreviewMouseUp -= OnMouseStuff;

            base.OnDetaching();
        }
        #endregion

        #region Internal

        private void OnStylusStuff(object sender, StylusEventArgs args)
        {
            if (args.RoutedEvent == UIElement.PreviewStylusUpEvent || 
                (args.RoutedEvent == UIElement.PreviewStylusDownEvent && args.Source == null) ||
                (args.RoutedEvent == UIElement.PreviewStylusMoveEvent && args.Source == null && args.InAir))
            {
                _pts.Remove(args.StylusDevice.Id);
                MultitouchWindow.ClearPhysicalReferenceFrame(args.StylusDevice);
                MultitouchWindow.RemoveStylusListener(args.StylusDevice, _attachedElement, OnStylusStuff);
                _processor.ProcessUp((uint)args.StylusDevice.Id, ToDrawingPointF(args.GetPosition(_attachedElement)));
            }
            else if (args.RoutedEvent == UIElement.PreviewStylusDownEvent)
            {
                System.Windows.Point pt = args.GetPosition(_attachedElement);
                _pts.Add(args.StylusDevice.Id, pt);
                MultitouchWindow.PushPhysicalReferenceFrame(args.StylusDevice, this);
                MultitouchWindow.AddStylusListener(args.StylusDevice, _attachedElement, OnStylusStuff);
                _processor.ProcessDown((uint)args.StylusDevice.Id, ToDrawingPointF(pt));
            }
            else if (args.RoutedEvent == UIElement.PreviewStylusMoveEvent)
            {
                if (!_pts.ContainsKey(-1)) return;
                //_processor.ProcessMove((uint)args.StylusDevice.Id, ToDrawingPointF(args.GetPosition(_attachedElement)));
            }
        }

        private void OnMouseStuff(object sender, MouseEventArgs args)
        {
            if (args.RoutedEvent == UIElement.PreviewMouseUpEvent ||
                (args.RoutedEvent == UIElement.PreviewMouseLeftButtonDownEvent && args.Source == null) ||
                (args.RoutedEvent == UIElement.PreviewMouseMoveEvent && args.Source == null && args.LeftButton == MouseButtonState.Released))
            {
                if (!_pts.ContainsKey(-1)) return;

                _pts.Remove(-1);
                MultitouchWindow.RemoveMouseListener(_attachedElement, OnMouseStuff);
                MultitouchWindow.ClearPhysicalReferenceFrame(args.MouseDevice);
                _processor.ProcessUp(unchecked((uint)-1), ToDrawingPointF(args.GetPosition(_attachedElement)));
            }
            else if (args.RoutedEvent == UIElement.PreviewMouseDownEvent)
            {
                _pts[-1] = args.GetPosition(_attachedElement);
                MultitouchWindow.AddMouseListener(_attachedElement, OnMouseStuff);
                MultitouchWindow.PushPhysicalReferenceFrame(args.MouseDevice, this);
                _processor.ProcessDown(unchecked((uint)-1), ToDrawingPointF(_pts[-1]));
            }
            else if (args.RoutedEvent == UIElement.PreviewMouseMoveEvent)
            {
                if (!_pts.ContainsKey(-1))
                    return;

               //_processor.ProcessMove(unchecked((uint)-1), ToDrawingPointF(args.GetPosition(_attachedElement)));
            }
        }

        private static PointF ToDrawingPointF(System.Windows.Point p)
        {
            return new System.Drawing.PointF((float)p.X, (float)p.Y);
        }

        /// <summary>
        /// Handler for the touch events and gestures
        /// </summary>
        void ProcessManipulationDelta(object sender, Windows7.Multitouch.Manipulation.ManipulationDeltaEventArgs e)
        {
            double expectedv = _attachedElement.VerticalOffset - e.TranslationDelta.Height;
            double expectedh = _attachedElement.HorizontalOffset - e.TranslationDelta.Width;

            double actualv = Math.Min(_attachedElement.ScrollableHeight, Math.Max(0, expectedv));
            double actualh = Math.Min(_attachedElement.ScrollableWidth, Math.Max(0, expectedh));

            _attachedElement.ScrollToVerticalOffset(expectedv);
            _attachedElement.ScrollToHorizontalOffset(expectedh);

            _delta = new Vector(expectedh - actualh, expectedv - actualv);
        }

        #endregion

        #region IPhysicalObject Members

        public UIElement ContainerVisual
        {
            get { return _attachedElement; }
        }

        public Vector ApplyManipulation(int id, System.Windows.Point loc)
        {
            _pts[id] = loc;
            _processor.ProcessMove((uint)id, ToDrawingPointF(loc));
            return _delta;
        }

        public void SetPoint(int id, System.Windows.Point pos)
        {
            if (!_pts.ContainsKey(id)) return;

            _processor.ProcessUp((uint)id, ToDrawingPointF(_pts[id]));
            _pts[id] = pos;
            _processor.ProcessDown((uint)id, ToDrawingPointF(_pts[id]));
        }

        #endregion
    }
}
