using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Expression.Interactivity;
using System.Windows.Documents;
using System.Windows.Controls;
using Windows7.Multitouch.Manipulation;
using System.Drawing;


namespace FlashCardUI.Behaviors
{

    /// <summary>
    /// A Inertia Enabled Scroll Behavior to apply to a scrollviewer
    /// </summary>
    public class ScrollBehavior : Behavior<ScrollViewer>
    {
        #region Data
        private ScrollViewer attachedElement;
        private ManipulationProcessor _processor = new ManipulationProcessor(ProcessorManipulations.TRANSLATE_X | ProcessorManipulations.TRANSLATE_Y);
        #endregion
   
        #region Behaviour Overrides

        protected override void OnAttached()
        {
            base.OnAttached();

            attachedElement = (ScrollViewer)this.AssociatedObject;

            attachedElement.PreviewStylusDown += (s, e) =>
            {
                MultitouchWindow.SafeCaptureStylus(e.StylusDevice, attachedElement);
                _processor.ProcessDown((uint)e.StylusDevice.Id, ToDrawingPointF(e.GetPosition(attachedElement)));
            };
            attachedElement.PreviewStylusUp += (s, e) =>
            {
                MultitouchWindow.SafeCaptureStylus(e.StylusDevice, null);
                _processor.ProcessUp((uint)e.StylusDevice.Id, ToDrawingPointF(e.GetPosition(attachedElement)));
            };
            attachedElement.PreviewStylusMove += (s, e) =>
            {
                _processor.ProcessMove((uint)e.StylusDevice.Id, ToDrawingPointF(e.GetPosition(attachedElement)));
            };

            attachedElement.PreviewMouseDown += (s, e) =>
            {
                MultitouchWindow.SafeCaptureMouse(attachedElement);
                _processor.ProcessDown((uint)1 << 31, ToDrawingPointF(e.GetPosition(attachedElement)));
            };
            attachedElement.PreviewMouseUp += (s, e) =>
            {
                MultitouchWindow.SafeCaptureMouse(null);
                _processor.ProcessUp((uint)1 << 31, ToDrawingPointF(e.GetPosition(attachedElement)));
            };
            attachedElement.PreviewMouseMove += (s, e) =>
            {
                _processor.ProcessMove((uint)1 << 31, ToDrawingPointF(e.GetPosition(attachedElement)));
            };

            //Handle the ManipulationDelta and the gestures
            _processor.ManipulationDelta += ProcessManipulationDelta;
            _processor.PivotRadius = 2;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }
        #endregion

        #region Internal

        private static PointF ToDrawingPointF(System.Windows.Point p)
        {
            return new System.Drawing.PointF((float)p.X, (float)p.Y);
        }

        /// <summary>
        /// Handler for the touch events and gestures
        /// </summary>
        void ProcessManipulationDelta(object sender, Windows7.Multitouch.Manipulation.ManipulationDeltaEventArgs e)
        {
            attachedElement.ScrollToVerticalOffset(attachedElement.VerticalOffset - e.TranslationDelta.Height);
            attachedElement.ScrollToHorizontalOffset(attachedElement.HorizontalOffset - e.TranslationDelta.Width);
        }

        #endregion

    }
}
