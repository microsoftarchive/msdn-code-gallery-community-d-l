using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Diagnostics;


namespace FlashCards.UI.Controls
{

    public class ScatterResizeAdorner : Adorner
    {
        ScatterViewItem svi;
        FrameworkElement adornedElement;

        #region Data
        // Resizing adorner uses Thumbs for visual elements.  
        // The Thumbs have built-in mouse input handling.
        Thumb topLeft, topRight, bottomLeft, bottomRight , rotate;

        // To store and manage the adorner's visual children.
        VisualCollection visualChildren;
        #endregion

        #region Ctor
        // Initialize the ResizingAdorner.
        public ScatterResizeAdorner(FrameworkElement adornedElement, ScatterViewItem scatterViewItem)
            : base(adornedElement)
        {
            svi = scatterViewItem;

            this.adornedElement = adornedElement;
            visualChildren = new VisualCollection(this);

            BuildAdornerCornerRotate(ref rotate, Cursors.Hand);

            // Call a helper method to initialize the Thumbs
            // with a customized cursors.
            BuildAdornerCorner(ref topLeft, Cursors.SizeNWSE);
            BuildAdornerCorner(ref topRight, Cursors.SizeNESW);
            BuildAdornerCorner(ref bottomLeft, Cursors.SizeNESW);
            BuildAdornerCorner(ref bottomRight, Cursors.SizeNWSE);

            // Add handlers for resizing.
            bottomLeft.DragDelta += new DragDeltaEventHandler(HandleBottomLeft);
            bottomRight.DragDelta += new DragDeltaEventHandler(HandleBottomRight);
            topLeft.DragDelta += new DragDeltaEventHandler(HandleTopLeft);
            topRight.DragDelta += new DragDeltaEventHandler(HandleTopRight);

            rotate.DragDelta += new DragDeltaEventHandler(HandleRotate);

        }

        #endregion

        #region Private Methods


        private void HandleRotate(object sender, DragDeltaEventArgs args)
        {
           Thumb hitThumb = sender as Thumb;

           if (args.HorizontalChange > 2.0 || args.VerticalChange > 2.0)
           {

               double prevAngle = (double)svi.GetValue(ScatterCanvas.OrientationProperty);

               if (Math.Sign(args.HorizontalChange) > 0 || Math.Sign(args.VerticalChange) < 0)
                   prevAngle += 3.0;
               else
                   prevAngle -= 3.0;

               svi.SetValue(ScatterCanvas.OrientationProperty, prevAngle);
           }
        }

        // Handler for resizing from the bottom-right.
        private void HandleBottomRight(object sender, DragDeltaEventArgs args)
        {
            Thumb hitThumb = sender as Thumb;

            if (adornedElement == null || hitThumb == null) return;
            double orgSize = (double)svi.GetValue(ScatterCanvas.SizeProperty);

            if (Math.Sign(args.HorizontalChange) > 0 || Math.Sign(args.VerticalChange) > 0)
                orgSize *= 1.015;
            else
                orgSize *= 0.985;

            svi.SetValue(ScatterCanvas.SizeProperty, orgSize);

        }

        // Handler for resizing from the bottom-left.
        private void HandleBottomLeft(object sender, DragDeltaEventArgs args)
        {
          Thumb hitThumb = sender as Thumb;

            if (adornedElement == null || hitThumb == null) return;
            double orgSize = (double)svi.GetValue(ScatterCanvas.SizeProperty);

            if (Math.Sign(args.HorizontalChange) < 0 || Math.Sign(args.VerticalChange) > 0)
                orgSize *= 1.015;
            else
                orgSize *= 0.985;

            svi.SetValue(ScatterCanvas.SizeProperty, orgSize);
        }


        // Handler for resizing from the top-right.
        private void HandleTopRight(object sender, DragDeltaEventArgs args)
        {
            Thumb hitThumb = sender as Thumb;

            if (adornedElement == null || hitThumb == null) return;

            double orgSize = (double)svi.GetValue(ScatterCanvas.SizeProperty);

            if (Math.Sign(args.HorizontalChange) > 0 || Math.Sign(args.VerticalChange) < 0)
                orgSize *= 1.015;
            else
                orgSize *= 0.985;

            svi.SetValue(ScatterCanvas.SizeProperty, orgSize);
        }

        // Handler for resizing from the top-left.
        private void HandleTopLeft(object sender, DragDeltaEventArgs args)
        {
            Thumb hitThumb = sender as Thumb;

            if (adornedElement == null || hitThumb == null) return;

            double orgSize = (double)svi.GetValue(ScatterCanvas.SizeProperty);

            if (Math.Sign(args.HorizontalChange) < 0 || Math.Sign(args.VerticalChange) < 0)
                orgSize *= 1.015;
            else
                orgSize *= 0.985;

            svi.SetValue(ScatterCanvas.SizeProperty, orgSize);
        }


        // Helper method to instantiate the corner Thumbs, set the Cursor property, 
        // set some appearance properties, and add the elements to the visual tree.
        private void BuildAdornerCorner(ref Thumb cornerThumb, Cursor customizedCursor)
        {
            if (cornerThumb != null) return;

            cornerThumb = new Thumb();

            // Set some arbitrary visual characteristics.
            cornerThumb.Cursor = customizedCursor;
            cornerThumb.Height = cornerThumb.Width = 20;
            cornerThumb.Style = (Style)FindResource("FlatThumb");
            visualChildren.Add(cornerThumb);
        }



        private void BuildAdornerCornerRotate(ref Thumb rotateThumb, Cursor cursor)
        {
            if (rotateThumb != null) return;

            rotateThumb = new Thumb();

            // Set some arbitrary visual characteristics.
            rotateThumb.Cursor = cursor;
            rotateThumb.Height = rotateThumb.Width = 30;
            rotateThumb.Margin = new Thickness(0, -15, 0, 0);
           
            rotateThumb.Style = (Style)FindResource("EllipseThumb");
            visualChildren.Add(rotateThumb);
        }

        #endregion

        #region Overrides
        // Arrange the Adorners.
        protected override Size ArrangeOverride(Size finalSize)
        {
            double desiredWidth = adornedElement.ActualWidth;
            double desiredHeight = adornedElement.ActualHeight;

            topLeft.Arrange(new Rect(-desiredWidth / 2, -desiredHeight / 2, desiredWidth, desiredHeight));

            topRight.Arrange(new Rect(desiredWidth / 2, -desiredHeight / 2, desiredWidth, desiredHeight));

            bottomLeft.Arrange(new Rect(-desiredWidth / 2, desiredHeight/ 2, desiredWidth, desiredHeight));

            bottomRight.Arrange(new Rect(desiredWidth  / 2, desiredHeight / 2, desiredWidth, desiredHeight));

            rotate.Arrange(new Rect(0, -desiredHeight / 2, desiredWidth, desiredHeight));

            return finalSize;
        }

        // Override the VisualChildrenCount and GetVisualChild properties to interface with 
        // the adorner's visual collection.
        protected override int VisualChildrenCount { get { return visualChildren.Count; } }
        protected override Visual GetVisualChild(int index) { return visualChildren[index]; }
        #endregion
    }
}
