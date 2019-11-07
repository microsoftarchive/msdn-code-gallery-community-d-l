using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Markup;
using System.Windows.Threading;

namespace FlashCards.UI.Controls
{
    public class Flipper3DControl : Control
    {
        Storyboard rotatestart1, rotatestart2, rotateend1, rotateend2,loaded;
        Grid mainGrid;
        bool _direction;

        public Flipper3DControl()
        {
            this.DefaultStyleKey = typeof(Flipper3DControl);
        }


        public override void OnApplyTemplate()
        {
            mainGrid = GetTemplateChild("PART_MainGrid") as Grid;

            rotatestart1 = Template.Resources["RotateStart1"] as Storyboard;
            rotateend1 = Template.Resources["RotateEnd1"] as Storyboard;

            rotatestart2 = Template.Resources["RotateStart2"] as Storyboard;
            rotateend2 = Template.Resources["RotateEnd2"] as Storyboard;

            loaded = Template.Resources["OnLoaded1"] as Storyboard;

            base.OnApplyTemplate();
        }

        private void DoRotate()
        {       
            if (IsFlipped)
            {
                if (_direction)
                {
                    if (rotatestart1 == null) return;
                    rotatestart1.Begin(mainGrid, HandoffBehavior.SnapshotAndReplace, true);
                }
                else
                {
                    if (rotateend2 == null) return;
                    rotatestart2.Begin(mainGrid, HandoffBehavior.SnapshotAndReplace, true);
                }
            }
            else
            {
                if (_direction)
                {
                    if (rotateend2 == null) return;
                    rotateend2.Begin(mainGrid, HandoffBehavior.SnapshotAndReplace, true);
                }
                else
                {
                    if (rotatestart1 == null) return;
                    rotateend1.Begin(mainGrid, HandoffBehavior.SnapshotAndReplace, true);
                }
            }


            isWorking = true;

            DispatcherTimer _timer = new DispatcherTimer();

            _timer.Interval = TimeSpan.FromMilliseconds(800); //Just waiting to Sync rotation

            _timer.Tick += new EventHandler(delegate(object s, EventArgs ev)
            {

                isWorking = false;

                _timer.Stop();

            });

            _timer.Start();
        }

        bool isWorking;

        public void Rotate(bool Direction)
        {
            _direction = Direction;

            if(!isWorking)
                IsFlipped = !IsFlipped;
        }


        public bool IsFlipped
        {
            get { return (bool)GetValue(IsFlippedProperty); }
            set { SetValue(IsFlippedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsFlipped.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsFlippedProperty =
            DependencyProperty.Register("IsFlipped", typeof(bool), typeof(Flipper3DControl), new UIPropertyMetadata(false, (s, e) =>
                {
                    if (e.NewValue != e.OldValue)
                    {
                        ((Flipper3DControl)s).DoRotate();
                    }
                }));

        public UIElement FrontContent
        {
            get { return (UIElement)GetValue(FrontContentProperty); }
            set { SetValue(FrontContentProperty, value); }
        }

        public static readonly DependencyProperty FrontContentProperty =
            DependencyProperty.Register("FrontContent", typeof(UIElement), typeof(Flipper3DControl), new PropertyMetadata(null));

                
        public UIElement BackContent
        {
            get { return (UIElement)GetValue(BackContentProperty); }
            set { SetValue(BackContentProperty, value); }
        }

        public static readonly DependencyProperty BackContentProperty =
            DependencyProperty.Register("BackContent", typeof(UIElement), typeof(Flipper3DControl), new PropertyMetadata(null));


        internal void Reset()
        {
            IsFlipped = false;
            if (loaded == null) return;
                loaded.Begin(mainGrid, HandoffBehavior.SnapshotAndReplace, true);
        }
    }
}
