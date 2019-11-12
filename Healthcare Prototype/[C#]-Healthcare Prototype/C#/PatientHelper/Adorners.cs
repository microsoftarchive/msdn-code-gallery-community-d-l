using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace IdentityMine.Avalon.Controls
{
    // Adorners must subclass the abstract base class Adorner.
    public class RectangleBrushAdorner : Adorner
    {
        // Be sure to call the base class constructor.
        public RectangleBrushAdorner(UIElement adornedElement, Brush adorningFill)
            : base(adornedElement)
        {
            _adorningFill = adorningFill;

            _child = new Rectangle();

            _child.Height = 100;
            _child.Width = 100;

           // DoubleAnimation animation = new DoubleAnimation(1, 1, new Duration(TimeSpan.FromSeconds(1)));
           // animation.AutoReverse = true;

           // animation.RepeatBehavior = System.Windows.Media.Animation.RepeatBehavior.Forever;
           // _adorningFill.BeginAnimation(System.Windows.Media.Brush.OpacityProperty, animation);

            _child.Fill = _adorningFill;
            _child.IsHitTestVisible = false;
        }

        protected override Size MeasureOverride(Size constraint)
        {
            _child.Measure(constraint);
            return _child.DesiredSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            _child.Arrange(new Rect(finalSize));
            return finalSize;
        }

        protected override Visual GetVisualChild(int index)
        {
            return _child;
        }

        protected override int VisualChildrenCount
        {
            get
            {
                return 1;
            }
        }

        public double LeftOffset
        {
            get
            {
                return _leftOffset;
            }
            set
            {
                _leftOffset = value;
                UpdatePosition();
            }
        }

        public double TopOffset
        {
            get
            {
                return _topOffset;
            }
            set
            {
                _topOffset = value;
                UpdatePosition();

            }
        }

        private void UpdatePosition()
        {
            AdornerLayer adornerLayer = this.Parent as AdornerLayer;
            if (adornerLayer != null)
            {
                adornerLayer.Update(AdornedElement);
            }
        }

        public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
        {
            GeneralTransformGroup result = new GeneralTransformGroup();
            result.Children.Add(base.GetDesiredTransform(transform));
            result.Children.Add(new TranslateTransform(_leftOffset, _topOffset));
            return result;
        }

        public void ClearAnimations()
        {
            if (_adorningFill == null)
                return;

            //_adorningFill.BeginAnimation(System.Windows.Media.Brush.OpacityProperty, null);
        }

        private Brush _adorningFill;
        private Rectangle _child = null;
        private double _leftOffset = 0;
        private double _topOffset = 0;
    }

}
