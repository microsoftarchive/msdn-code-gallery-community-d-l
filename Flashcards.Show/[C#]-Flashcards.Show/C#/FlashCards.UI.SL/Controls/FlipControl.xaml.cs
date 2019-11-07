using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace FlashCards.UI.Controls
{
    /// <summary>
    /// Code is based on the work by Mike Taulty
    /// http://mtaulty.com/CommunityServer/blogs/mike_taultys_blog/archive/2009/04/27/silverlight-3-simple-flip-control-built-on-planeprojection.aspx
    /// </summary>
    public partial class FlipControl : UserControl
    {
        public event EventHandler FlipCompleted;

        public FlipControl()
        {
            InitializeComponent();
            FlipAxis = FlipAxis.Horizontal;
            FlipDirection = FlipDirection.Forwards;
        }

        public static DependencyProperty IsIdleProperty =
            DependencyProperty.Register("IsIdle", typeof(bool), typeof(FlipControl), new PropertyMetadata(true));

        public bool IsIdle
        {
            get
            {
                return ((bool)base.GetValue(IsIdleProperty));
            }
            internal set
            {
                base.SetValue(IsIdleProperty, value);
            }
        }

        public static DependencyProperty FrontContentProperty =
            DependencyProperty.Register("FrontContent", typeof(Panel), typeof(FlipControl), new PropertyMetadata(OnFrontContentChanged));

        public Panel FrontContent
        {
            get
            {
                return ((Panel)base.GetValue(FrontContentProperty));
            }
            set
            {
                base.SetValue(FrontContentProperty, value);
            }
        }

        static void OnFrontContentChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            OnPanelContentChanged(sender, args, true);
        }

        public static DependencyProperty RearContentProperty = DependencyProperty.Register("RearContent", typeof(Panel), typeof(FlipControl),
            new PropertyMetadata(OnRearContentChanged));

        public Panel RearContent
        {
            get
            {
                return ((Panel)base.GetValue(RearContentProperty));
            }
            set
            {
                base.SetValue(RearContentProperty, value);
            }
        }

        static void OnRearContentChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            OnPanelContentChanged(sender, args, false);
        }

        static void OnPanelContentChanged(object sender, DependencyPropertyChangedEventArgs args, bool front)
        {
            FlipControl control = sender as FlipControl;
            Panel oldPanel = args.OldValue as Panel;
            Panel newPanel = args.NewValue as Panel;

            if ((control != null) && (oldPanel != null))
            {
                control.LayoutRoot.Children.Remove(oldPanel);
            }
            if ((control != null) && (newPanel != null))
            {
                if (front)
                {
                    control.LayoutRoot.Children.Add(newPanel);
                }
                else
                {
                    control.LayoutRoot.Children.Insert(0, newPanel);
                    newPanel.Visibility = Visibility.Collapsed;
                }
            }
        }

        public FlipAxis FlipAxis { get; set; }

        public FlipDirection FlipDirection { get; set; }

        public static DependencyProperty DurationProperty = 
            DependencyProperty.Register("Duration", typeof(Duration), typeof(FlipControl), new PropertyMetadata(new Duration(new TimeSpan(0, 0, 1))));

        public Duration Duration
        {
            get
            {
                return ((Duration)base.GetValue(DurationProperty));
            }
            set
            {
                base.SetValue(DurationProperty, value);
            }
        }

        public static DependencyProperty OffsetXProperty = 
            DependencyProperty.Register("OffsetX", typeof(int), typeof(FlipControl), new PropertyMetadata(0));

        public int OffsetX
        {
            get
            {
                return ((int)base.GetValue(OffsetXProperty));
            }
            set
            {
                base.SetValue(OffsetXProperty, value);
            }
        }

        public static DependencyProperty OffsetYProperty =
            DependencyProperty.Register("OffsetY", typeof(int), typeof(FlipControl), new PropertyMetadata(0));

        public int OffsetY
        {
            get
            {
                return ((int)base.GetValue(OffsetYProperty));
            }
            set
            {
                base.SetValue(OffsetYProperty, value);
            }
        }

        public static DependencyProperty OffsetZProperty =
            DependencyProperty.Register("OffsetZ", typeof(int), typeof(FlipControl), new PropertyMetadata(0));

        public int OffsetZ
        {
            get
            {
                return ((int)base.GetValue(OffsetZProperty));
            }
            set
            {
                base.SetValue(OffsetZProperty, value);
            }
        }

        private int numberOfFlips = 0;

        public void Flip()
        {
            numberOfFlips++;

            if (numberOfFlips == 1)
            {
                DoFlip();
            }
        }

        public void DoFlip()
        {
            IsIdle = false;

            Storyboard sb = new Storyboard();

            Duration duration = new Duration(new TimeSpan(0, 0, 0, 0, (int)(Duration.TimeSpan.TotalMilliseconds / 2)));

            sb.Children.Add(MakeRotationAnimation(planeProjection, FlipAxis, FlipDirection, duration));

            sb.Children.Add(MakeOffsetAnimation(OffsetX, "GlobalOffsetX", duration));

            sb.Children.Add(MakeOffsetAnimation(OffsetY, "GlobalOffsetY", duration));

            sb.Children.Add(MakeOffsetAnimation(OffsetZ, "GlobalOffsetZ", duration));

            EventHandler handler = null;

            handler = (s, e) =>
            {
                sb.Completed -= handler;
                sb.Completed += (sender, args) =>
                {
                    IsIdle = true;
                    FireFlipCompleted();

                    numberOfFlips--;
                    if (numberOfFlips > 0)
                    {
                        DoFlip();
                    }
                };

                FlipVisibility(RearContent);
                FlipVisibility(FrontContent);
                sb.Begin();
            };

            sb.Completed += handler;

            sb.Begin();
        }

        DoubleAnimation MakeOffsetAnimation(int offset, string property, Duration duration)
        {
            if (FlipDirection == FlipDirection.Backwards)
            {
                offset = 0 - offset;
            }
            DoubleAnimation da = new DoubleAnimation();
            da.Duration = duration;
            da.By = offset / 2;
            Storyboard.SetTarget(da, planeProjection);
            Storyboard.SetTargetProperty(da, new PropertyPath(property));

            return (da);
        }

        static DoubleAnimation MakeRotationAnimation(PlaneProjection planeProjection, FlipAxis axis, FlipDirection direction, Duration duration)
        {
            DoubleAnimation da = new DoubleAnimation();

            da.Duration = duration;

            switch (axis)
            {
                case FlipAxis.Vertical:
                    da.By = direction == FlipDirection.Backwards ? -90 : 90;
                    break;
                case FlipAxis.Horizontal:
                    da.By = direction == FlipDirection.Backwards ? 90 : -90;
                    break;
                default:
                    break;
            }

            Storyboard.SetTarget(da, planeProjection);

            Storyboard.SetTargetProperty(da, new PropertyPath(
              axis == FlipAxis.Vertical ? "RotationX" : "RotationY"));

            return (da);
        }

        static void FlipVisibility(UIElement element)
        {
            element.Visibility = element.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        void FireFlipCompleted()
        {
            if (FlipCompleted != null)
            {
                FlipCompleted(this, null);
            }
        }

        #region IsFlipped

        /// <summary>
        /// IsFlipped Dependency Property
        /// </summary>
        public static readonly DependencyProperty IsFlippedProperty =
            DependencyProperty.Register("IsFlipped", typeof(bool), typeof(FlipControl),
                new FrameworkPropertyMetadata((bool)false,
                    new PropertyChangedCallback(OnIsFlippedChanged)));

        /// <summary>
        /// Gets or sets the IsFlipped property. This dependency property 
        /// indicates whether the flip contorl is flipped.
        /// </summary>
        public bool IsFlipped
        {
            get { return (bool)GetValue(IsFlippedProperty); }
            set { SetValue(IsFlippedProperty, value); }
        }

        /// <summary>
        /// Handles changes to the IsFlipped property.
        /// </summary>
        private static void OnIsFlippedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FlipControl target = (FlipControl)d;
            bool oldIsFlipped = (bool)e.OldValue;
            bool newIsFlipped = target.IsFlipped;
            target.OnIsFlippedChanged(oldIsFlipped, newIsFlipped);
        }

        /// <summary>
        /// Provides derived classes an opportunity to handle changes to the IsFlipped property.
        /// </summary>
        protected virtual void OnIsFlippedChanged(bool oldIsFlipped, bool newIsFlipped)
        {
            if (oldIsFlipped != newIsFlipped)
            {
                Flip();
            }
        }

        #endregion


    }
}