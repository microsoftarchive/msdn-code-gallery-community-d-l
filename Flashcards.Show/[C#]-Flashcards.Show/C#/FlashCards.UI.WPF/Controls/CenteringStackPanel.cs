using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using EffectLibrary;

namespace FlashCards.UI.Controls
{
    /// <summary>
    /// This is a StackPanel that shifts items such that the item corresponding to CenteredIndex
    /// will be placed in the center of the Panel. This is refactored functionality from the
    /// FilmStripPanel and FilmStripControl in the PhotoSuru project which can be downloaded from:
    /// here: http://windowsclient.net/wpf/starter-kits/sce/ScePhotoViewer.exe 
    /// 
    /// Note that this control has a dependency on the EffectLibrary.dll assembly that gets built
    /// with that project.
    /// </summary>
    public class CenteringStackPanel : StackPanel
    {

        public CenteringStackPanel()
        {
            this.Orientation = Orientation.Horizontal;
            this.Loaded += new RoutedEventHandler(CenteringStackPanel_Loaded);
        }

        void CenteringStackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateCenteredItem(0, this.ActualWidth, true, true);
        }

        private void UpdateCenteredItem(int elementIndex, double viewPortWidth, bool suspendAnimation, bool suspendBlur)
        {
            // get the centeredItem
            UIElement centeredItem = null;

            if (elementIndex >= 0 && elementIndex <= this.Children.Count - 1)
            {
                centeredItem = this.Children[elementIndex];

                // find the location of the centeredItem
                Vector vector = VisualTreeHelper.GetOffset(centeredItem);

                // convert the vector to a point value.
                Point offsetPoint = new Point(vector.X, vector.Y);

                // get the combined size of all of the children
                double totalWidth = 0;
                foreach (UIElement child in this.Children)
                {
                    totalWidth += child.DesiredSize.Width;
                }

                // get the width of the current view
                double viewWidth = viewPortWidth;

                // calculate the offset
                double x = ((totalWidth - viewWidth) / 2 - offsetPoint.X) - (centeredItem.DesiredSize.Width / 2);
                Shift(x, 0, suspendAnimation, suspendBlur);
            }
        }

        protected override System.Windows.Size ArrangeOverride(System.Windows.Size arrangeSize)
        {
            Size returnSize = base.ArrangeOverride(arrangeSize);

            // after we have arranged the items, we shift the panel so that the
            // CenteredIndex item is in the center of the panel

            UpdateCenteredItem(this.CenteredIndex, arrangeSize.Width, false, false);

            return returnSize;
        }

        private void Shift(double x, double y) { Shift(x, y, false, false); }

        private void Shift(double x, double y, bool suspendAnimation, bool suspendBlur)
        {
            x = Math.Floor(x);
            y = Math.Floor(y);

            if (this.IsAnimated && !suspendAnimation)
            {
                AnimateShift(x, y, (this.IsBlurred && !suspendBlur));
            }
            else
            {
                ShiftTransform.X = x;
                ShiftTransform.Y = y;
            }
        }

        private TranslateTransform shiftTransform;

        private TranslateTransform ShiftTransform
        {
            get
            {
                if (this.RenderTransform == null || !(this.RenderTransform is TranslateTransform))
                {
                    shiftTransform = new TranslateTransform();
                    this.RenderTransform = shiftTransform;
                }
                return shiftTransform;
            }
        }

        private DirectionalBlurEffect filmStripBlurEffect;
        private DoubleAnimation filmStripMultiItemBlurEffectAnimation = new DoubleAnimation();
        private DoubleAnimation filmStripOneItemBlurEffectAnimation = new DoubleAnimation();
        private static Duration standardSlideFilmStripDuration = new Duration(new TimeSpan(1700000));
        private static int perItemSlideFilmStripTime = 400000;

        private static double avgItemWidth = 100;

        private void AnimateShift(double x, double y, bool isBlurEnabled)
        {
            // Blur

            double scrollDirection = (x - ShiftTransform.X > 0) ? 1 : -1;
            double absDeltaX = Math.Abs(this.ShiftTransform.X - x);
            int numberOfItemsDelta = Math.Max((int)absDeltaX / (int)avgItemWidth, 1);
            double blurAmount = 0.02; // the default DirectionalBlurEffect amount

            if (isBlurEnabled)
            {
                if (this.Effect == null || !(this.filmStripBlurEffect is DirectionalBlurEffect))
                {
                    this.filmStripBlurEffect = new DirectionalBlurEffect();
                    this.filmStripBlurEffect.Angle = 0;
                    this.Effect = filmStripBlurEffect;
                }


                if (absDeltaX > (avgItemWidth * 3))
                {
                    // The amount of blur is relative to the number of items being scrolled within the film strip
                    // with the maximum blur amount of blurAmount. The blur direction must also match direction of the
                    // FilmStripPanel.SetHorizontalOffset's horizontal animation to prevent jittering
                    blurAmount *= scrollDirection;
                    this.filmStripMultiItemBlurEffectAnimation.From = blurAmount * ((numberOfItemsDelta <= 0.0 ? 1.0 : numberOfItemsDelta) / (this.ActualWidth <= 0.0 ? 1.0 : (this.ActualWidth / avgItemWidth)));
                    this.filmStripMultiItemBlurEffectAnimation.To = 0;
                    this.filmStripMultiItemBlurEffectAnimation.Duration = standardSlideFilmStripDuration + new Duration(new TimeSpan(numberOfItemsDelta * perItemSlideFilmStripTime));
                    this.filmStripMultiItemBlurEffectAnimation.AccelerationRatio = 0;
                    this.filmStripMultiItemBlurEffectAnimation.DecelerationRatio = 1;
                    this.Effect.BeginAnimation(DirectionalBlurEffect.BlurAmountProperty, this.filmStripMultiItemBlurEffectAnimation, HandoffBehavior.SnapshotAndReplace);
                }
                else if (absDeltaX > 0)
                {
                    if (this.filmStripOneItemBlurEffectAnimation.From == null)
                    {
                        this.filmStripOneItemBlurEffectAnimation.From = 0;
                    }

                    // The amount of blur should slowly accumulate when moving between many items sequentially
                    // such as holding down the arrow key. The HandoffBehavior.SnapshotAndReplace behavior will ensure 
                    // the a smooth transition to the next animation.
                    this.filmStripOneItemBlurEffectAnimation.From += blurAmount * 0.001 * scrollDirection; // accumulate blur in small increments
                    this.filmStripOneItemBlurEffectAnimation.To = 0;
                    this.filmStripOneItemBlurEffectAnimation.Duration = standardSlideFilmStripDuration + new Duration(new TimeSpan(numberOfItemsDelta * perItemSlideFilmStripTime));
                    this.filmStripOneItemBlurEffectAnimation.AccelerationRatio = 0;
                    this.filmStripOneItemBlurEffectAnimation.DecelerationRatio = 1;
                    this.filmStripOneItemBlurEffectAnimation.Completed += new EventHandler(this.FilmStripOneItemBlurEffectAnimationCompleted);
                    this.Effect.BeginAnimation(DirectionalBlurEffect.BlurAmountProperty, this.filmStripOneItemBlurEffectAnimation, HandoffBehavior.SnapshotAndReplace);
                }
            }

            // Translate

            DoubleAnimation transformAnimation = new DoubleAnimation();

            // animate horizontally so that current item is positioned at the center of the viewport
            //transformAnimation.From = centerRelativeOffset - this.offset.X;

            double from = ShiftTransform.X;
            transformAnimation.To = x;

            // this duration must match FilmStripControl.BringCurrentItemIntoView's Effect animation duration
            numberOfItemsDelta = (int)Math.Abs((int)(from - transformAnimation.To) / (int)avgItemWidth);
            transformAnimation.Duration = standardSlideFilmStripDuration + new Duration(new TimeSpan(numberOfItemsDelta * perItemSlideFilmStripTime));

            transformAnimation.AccelerationRatio = 0;
            transformAnimation.DecelerationRatio = 1;
            ShiftTransform.BeginAnimation(TranslateTransform.XProperty, transformAnimation);

        }

        private void FilmStripOneItemBlurEffectAnimationCompleted(object sender, EventArgs e)
        {
            this.filmStripOneItemBlurEffectAnimation.From = null;
        }

        void d_Completed(object sender, EventArgs e)
        {
            this.Effect = null;
        }

        #region CenteredIndex

        /// <summary>
        /// CenteredIndex Dependency Property
        /// </summary>
        public static readonly DependencyProperty CenteredIndexProperty =
            DependencyProperty.Register("CenteredIndex", typeof(int), typeof(CenteringStackPanel),
                new FrameworkPropertyMetadata((int)-1,
                    new PropertyChangedCallback(OnCenteredIndexChanged)));

        /// <summary>
        /// Gets or sets the CenteredIndex property.  This dependency property 
        /// indicates ....
        /// </summary>
        public int CenteredIndex
        {
            get { return (int)GetValue(CenteredIndexProperty); }
            set { SetValue(CenteredIndexProperty, value); }
        }

        /// <summary>
        /// Handles changes to the CenteredIndex property.
        /// </summary>
        private static void OnCenteredIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CenteringStackPanel)d).OnCenteredIndexChanged(e);
        }

        /// <summary>
        /// Provides derived classes an opportunity to handle changes to the CenteredIndex property.
        /// </summary>
        protected virtual void OnCenteredIndexChanged(DependencyPropertyChangedEventArgs e)
        {
            UpdateCenteredItem((int)e.NewValue, this.ActualWidth, false, false);
        }

        #endregion

        #region IsAnimated

        /// <summary>
        /// IsAnimated Dependency Property
        /// </summary>
        public static readonly DependencyProperty IsAnimatedProperty =
            DependencyProperty.Register("IsAnimated", typeof(bool), typeof(CenteringStackPanel),
                new FrameworkPropertyMetadata((bool)true));

        /// <summary>
        /// Gets or sets the IsAnimated property.  This dependency property 
        /// indicates ....
        /// </summary>
        public bool IsAnimated
        {
            get { return (bool)GetValue(IsAnimatedProperty); }
            set { SetValue(IsAnimatedProperty, value); }
        }

        #endregion

        #region IsBlurred

        /// <summary>
        /// IsBlurred Dependency Property
        /// </summary>
        public static readonly DependencyProperty IsBlurredProperty =
            DependencyProperty.Register("IsBlurred", typeof(bool), typeof(CenteringStackPanel),
                new FrameworkPropertyMetadata((bool)true));

        /// <summary>
        /// Gets or sets the IsBlurred property.  This dependency property 
        /// indicates ....
        /// </summary>
        public bool IsBlurred
        {
            get { return (bool)GetValue(IsBlurredProperty); }
            set { SetValue(IsBlurredProperty, value); }
        }

        #endregion
    }

}
