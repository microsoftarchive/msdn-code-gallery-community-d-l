using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace FlashCards.UI.Controls
{
    /// <summary>
    /// A custom panel which has a coordinate space of (0,0) as the top left and (1,1) as the bottom right.
    /// </summary>
    public class ScatterCanvas : Panel
    {
        #region Dependancy Properties

        #region Center (Attached)

        /// <summary>
        /// Gets the Center attached dependency property
        /// </summary>
        public static Point GetCenter(DependencyObject obj)
        {
            return (Point)obj.GetValue(CenterProperty);
        }

        /// <summary>
        /// Sets the PinPoint attached dependency property
        /// </summary>
        public static void SetCenter(DependencyObject obj, Point value)
        {
            obj.SetValue(CenterProperty, value);
        }

        /// <summary>
        /// Identifies the Center dependency property
        /// </summary>
        public static readonly DependencyProperty CenterProperty =
            DependencyProperty.RegisterAttached("Center", typeof(Point), typeof(ScatterCanvas),
             new FrameworkPropertyMetadata(new Point(0.5, 0.5), 
                 FrameworkPropertyMetadataOptions.AffectsParentMeasure |  FrameworkPropertyMetadataOptions.AffectsParentArrange
             , null, new CoerceValueCallback(CoerceCenter) ));

        /// <summary>
        /// Restricting the Center property by limiting it inside 0-1
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static object CoerceCenter(DependencyObject obj, object value) 
        {
            Point val = (Point)value;

            if (val.X < 0.0)
                val.X = 0.0;
            if (val.Y < 0.0)
                val.Y = 0.0;

            if (val.X > 1.0)
                val.X = 1.0;
            if (val.Y > 1.0)
                val.Y = 1.0;

            return val; 
        }

        #endregion

        #region PinPoint (Attached)

        /// <summary>
        /// Gets the PinPoint attached dependency property
        /// </summary>
        public static Point GetPinPoint(DependencyObject obj)
        {
            return (Point)obj.GetValue(PinPointProperty);
        }

        /// <summary>
        /// Sets the PinPoint attached dependency property
        /// </summary>
        public static void SetPinPoint(DependencyObject obj, Point value)
        {
            obj.SetValue(PinPointProperty, value);
        }

        /// <summary>
        /// Identifies the PinPoint dependency property
        /// </summary>
        public static readonly DependencyProperty PinPointProperty =
            DependencyProperty.RegisterAttached("PinPoint", typeof(Point), typeof(ScatterCanvas),
             new FrameworkPropertyMetadata(new Point(0.5, 0.5), FrameworkPropertyMetadataOptions.AffectsParentMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));

        #endregion

        #region Size (Attached)

        /// <summary>
        /// Gets the Size attached dependency property
        /// </summary>
        public static double GetSize(DependencyObject obj)
        {
            return (double)obj.GetValue(SizeProperty);
        }

        /// <summary>
        /// Sets the Size attached dependency property
        /// </summary>
        public static void SetSize(DependencyObject obj, double value)
        {
            obj.SetValue(SizeProperty, value);
        }

        /// <summary>
        /// Identifies the Size dependency property
        /// </summary>
        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.RegisterAttached("Size", typeof(double), typeof(ScatterCanvas),
             new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsParentMeasure |FrameworkPropertyMetadataOptions.AffectsParentArrange,
                 null, new CoerceValueCallback(CoerceSize)));

         /// <summary>
        /// Restricting the Center property by limiting it inside 0-1
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static object CoerceSize(DependencyObject obj, object value) 
        {
            double val = (double)value;

            if (val < 0.1)
                val = 0.1;
           
            if (val > 5.0)
                val = 5.0;
          
            return val; 
        }

        #endregion

        #region Orientation (Attached)

        /// <summary>
        /// Gets the Orientation attached dependency property
        /// </summary>
        public static double GetOrientation(DependencyObject obj)
        {
            return (double)obj.GetValue(OrientationProperty);
        }

        /// <summary>
        /// Sets the Orientation attached dependency property
        /// </summary>
        public static void SetOrientation(DependencyObject obj, double value)
        {
            obj.SetValue(OrientationProperty, value);
        }

        /// <summary>
        /// Identifies the Orientation dependency property
        /// </summary>
        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.RegisterAttached("Orientation", typeof(double), typeof(ScatterCanvas),
             new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsParentMeasure | FrameworkPropertyMetadataOptions.AffectsParentArrange));

        #endregion


        #endregion

        #region overrides

        /// <summary>
        /// Measure the Children with Positive infinity height and width.
        /// </summary>
        protected override Size MeasureOverride( Size constraint)
        {
            Size unconstrained = new Size(Double.PositiveInfinity, Double.PositiveInfinity);

            foreach (FrameworkElement child in Children)
            {
                double size = ScatterCanvas.GetSize(child);

                double tempHeight = constraint.Height * size, tempWidth = constraint.Width * size;

                if (tempHeight < 0 || tempWidth < 0) continue;

                if ((Stretch)child.GetValue(ScatterViewItem.StretchProperty) == Stretch.None)
                {                    
                    tempHeight = Double.PositiveInfinity;

                    tempWidth = Double.PositiveInfinity;
                }

                child.Measure(new Size(tempWidth, tempHeight));
            }

            return constraint;
        }

        /// <summary>
        /// Arrange Children based on their set relative position and size.
        /// </summary>
        protected override Size ArrangeOverride(Size finalSize)
        {

            if (Children == null || Children.Count == 0)
                return finalSize;

            foreach (FrameworkElement child in Children)
            {
                double size = ScatterCanvas.GetSize(child);

                double tempHeight = finalSize.Height*size, tempWidth = finalSize.Width*size;

                if (tempHeight < 0 || tempWidth < 0) continue;

                if((Stretch)child.GetValue(ScatterViewItem.StretchProperty) == Stretch.None)
                {
                    tempHeight = child.DesiredSize.Height;
                    tempWidth = child.DesiredSize.Width;
                }

                Point center = ScatterCanvas.GetCenter(child);

                Point pinPoint = ScatterCanvas.GetPinPoint(child);

                Point actualPinPoint = new Point(center.X * finalSize.Width - tempWidth * pinPoint.X, center.Y * finalSize.Height - tempHeight * pinPoint.Y);

                child.Arrange(new Rect(actualPinPoint, new Size(tempWidth, tempHeight)));
            }

            return finalSize;
        }

        #endregion

        #region private methods

        #endregion
    }
}
