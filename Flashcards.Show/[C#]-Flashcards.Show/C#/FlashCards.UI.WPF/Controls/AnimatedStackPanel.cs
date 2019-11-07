using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace FlashCardUI.Controls
{
    public class AnimatedStackPanel : Panel
    {
       // Fields
        private static DoubleAnimation animation = new DoubleAnimation();
        public static readonly DependencyProperty ScaleFactorProperty = DependencyProperty.RegisterAttached("ScaleFactor", typeof(Point), typeof(AnimatedStackPanel), new UIPropertyMetadata(new Point()));
        private double scaleFactorX = 1.0;
        private double scaleFactorY = 1.0;
        public static readonly DependencyProperty DurationProperty = DependencyProperty.RegisterAttached("Duration", typeof(Duration), typeof(AnimatedStackPanel), new UIPropertyMetadata(new Duration(TimeSpan.FromMilliseconds(100.0))));
        public static readonly DependencyProperty DecelerationProperty = DependencyProperty.RegisterAttached("Deceleration", typeof(double), typeof(AnimatedStackPanel), new UIPropertyMetadata(0.5));
        public static readonly DependencyProperty SelectedItemIndexProperty = DependencyProperty.Register("SelectedItemIndex", typeof(int), typeof(AnimatedStackPanel), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsArrange));

        // Methods
        public AnimatedStackPanel()
        {
            animation.Duration = Duration;
            animation.DecelerationRatio = Deceleration;
        }


        protected override Size ArrangeOverride(Size finalSize)
        {
            if (base.Children.Count != 0)
            {

                double x = 0;

                if (SelectedItemIndex == -1)
                {
                    for (int i = 0; i < Children.Count; i++)
                    {
                        UIElement elem = Children[i];
                        this.MakeTransform(elem, new Point(x, 0.0), i);
                        elem.Arrange(new Rect(x, 0.0, elem.DesiredSize.Width, elem.DesiredSize.Height));
                        x += elem.DesiredSize.Width;
                    }
                }

                else
                {
                    double selectedWidth = Children[SelectedItemIndex].DesiredSize.Width;

                    x = 0;
                    for (int i = 0; i < SelectedItemIndex; i++)
                    {
                        UIElement elem = Children[i];
                        this.MakeTransform(elem, new Point(x , 0.0), i);
                        elem.Arrange(new Rect(x , 0.0, elem.DesiredSize.Width, elem.DesiredSize.Height));
                        x += elem.DesiredSize.Width;
                    }
                    double sX = x;
                    x += Children[SelectedItemIndex].DesiredSize.Width;
                    for (int i = SelectedItemIndex + 1; i < Children.Count; i++)
                    {
                        if (i >= Children.Count) break;

                        UIElement elem = Children[i];
                        this.MakeTransform(elem, new Point(x , 0.0), i);
                        elem.Arrange(new Rect(x , 0.0, elem.DesiredSize.Width, elem.DesiredSize.Height));
                        x += elem.DesiredSize.Width;
                    }

                    UIElement elem1 = Children[SelectedItemIndex];
                    this.MakeTransform(elem1, new Point(sX , 0.0), SelectedItemIndex);
                    elem1.Arrange(new Rect(sX , 0.0, elem1.DesiredSize.Width, elem1.DesiredSize.Height));
                }
            }
            return finalSize;
        }

        public static Point GetScaleFactor(DependencyObject obj)
        {
            return (Point)obj.GetValue(ScaleFactorProperty);
        }

        private static DoubleAnimation MakeAnimation(double start, double toValue)
        {
            animation.From = new double?(start);
            animation.To = new double?(toValue);
            return animation;
        }

        private void MakeTransform(UIElement child, Point newOffset, int i)
        {
            int num = Math.Abs((int)(i - this.SelectedItemIndex));
            Point point = child.PointToScreen(new Point(0.0, 0.0));
            point = base.PointFromScreen(point);
            TranslateTransform transform = new TranslateTransform();
            ScaleTransform transform2 = new ScaleTransform();
            transform2.ScaleX = Math.Pow(this.scaleFactorX, (double)num);
            transform2.ScaleY = Math.Pow(this.scaleFactorY, (double)num);
            TransformGroup group = new TransformGroup();
            group.Children.Add(transform);
            group.Children.Add(transform2);
            child.RenderTransform = group;
            child.RenderTransformOrigin = new Point(0.5, 0.5);
            Point point2 = (Point)child.GetValue(ScaleFactorProperty);
            transform.BeginAnimation(TranslateTransform.XProperty, MakeAnimation(point.X - newOffset.X, 0.0));
            //transform2.BeginAnimation(ScaleTransform.ScaleXProperty, MakeAnimation(point2.X, Math.Pow(this.scaleFactorX, (double)num)));
            //transform2.BeginAnimation(ScaleTransform.ScaleYProperty, MakeAnimation(point2.Y, Math.Pow(this.scaleFactorY, (double)num)));
            child.SetValue(ScaleFactorProperty, new Point(transform2.ScaleX, transform2.ScaleY));
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            double x = 0;
            Size size = new Size(double.PositiveInfinity, double.PositiveInfinity);
            if (base.Children.Count != 0)
            {
              
                foreach (FrameworkElement element in base.InternalChildren)
                {
                    element.Measure(size);
                    x += element.DesiredSize.Width;
                }
            }
            if (!double.IsInfinity(availableSize.Height) && !double.IsInfinity(availableSize.Width))
            {
                return availableSize;
            }
            return new Size(x, availableSize.Height);
        }

        public static void SetScaleFactor(DependencyObject obj, Point value)
        {
            obj.SetValue(ScaleFactorProperty, value);
        }

        // Properties
        public int SelectedItemIndex
        {
            get
            {
                return (int)base.GetValue(SelectedItemIndexProperty);
            }
            set
            {
                base.SetValue(SelectedItemIndexProperty, value);
            }
        }

        public double Deceleration
        {
            get
            {
                return (double)base.GetValue(DecelerationProperty);
            }
            set
            {
                base.SetValue(DecelerationProperty, value);
            }
        }

        public Duration Duration
        {
            get
            {
                return (Duration)base.GetValue(DurationProperty);
            }
            set
            {
                base.SetValue(DurationProperty, value);
            }
        }

    }

}
