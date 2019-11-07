using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.Windows.Automation.Peers;
using System.Windows.Interactivity;
using IdentityMine.Windows.SimpleMultitouch;

namespace FlashCards.UI.Controls
{
   /// <summary>
   /// This class instances can be manipulated with Multi-gestures to do Zoom, Pan and Roate
   /// </summary>
    public class ScatterViewItem : ContentControl
    {
  
        #region Ctrs

        static ScatterViewItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ScatterViewItem), new FrameworkPropertyMetadata(typeof(ScatterViewItem)));
        }

        public ScatterViewItem()
        {
           
        }
        
        public ScatterViewItem(ScatterView parent)
        {
            _parent = parent;
         
        }

        #endregion

        #region Overrides
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            if ((ScatterView)this.Parent != null)
                _parent = (ScatterView)this.Parent;

            if (adornerLayer == null)
                adornerLayer = AdornerLayer.GetAdornerLayer(this);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _viewBox = Template.FindName("PART_VIEWBOX", this) as FrameworkElement;

            if (IsManipulable)
            {
                _manipulable = new Manipulable() { Container = _parent };
                TapBehavior _tapbehavior = new TapBehavior() { Threshold= 5};
                _manipulable.SupportedManipulations = ManipulationTypes.All;

                _manipulable.Manipulate += new EventHandler<ManipulationDeltaEventArgs>(_manipulable_Manipulate);
                _tapbehavior.Tap += new EventHandler<TapEventArgs>(_tapbehavior_DoubleTap);

                BehaviorCollection bCollection = Interaction.GetBehaviors(this);
                bCollection.Add(_manipulable);
                bCollection.Add(_tapbehavior);
            }
        }

        #endregion

        #region DPs

        #region IsSelcted attached property

        public static bool GetIsSelected(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsSelectedProperty);
        }

        public static void SetIsSelected(DependencyObject obj, bool value)
        {
            obj.SetValue(IsSelectedProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.RegisterAttached("IsSelected", typeof(bool), typeof(ScatterViewItem), new UIPropertyMetadata(false,new PropertyChangedCallback(OnIsSelectedChanged)));

        #endregion

        #region Stretch DP
        public Stretch Stretch
        {
            get { return (Stretch)GetValue(StretchProperty); }
            set { SetValue(StretchProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Stretch.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StretchProperty =
            DependencyProperty.Register("Stretch", typeof(Stretch), typeof(ScatterViewItem), new UIPropertyMetadata(Stretch.Fill));


        #endregion

        #region IsManipulable DP

        public bool IsManipulable
        {
            get { return (bool)GetValue(IsManipulableProperty); }
            set { SetValue(IsManipulableProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsManipulable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsManipulableProperty =
            DependencyProperty.Register("IsManipulable", typeof(bool), typeof(ScatterViewItem), new UIPropertyMetadata(false));

        #endregion

        #region CanResize

        public bool CanResize
        {
            get { return (bool)GetValue(CanResizeProperty); }
            set { SetValue(CanResizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanResize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanResizeProperty =
            DependencyProperty.Register("CanResize", typeof(bool), typeof(ScatterViewItem), new UIPropertyMetadata(true));

        #endregion

        #region CanMove

        public bool CanMove
        {
            get { return (bool)GetValue(CanMoveProperty); }
            set { SetValue(CanMoveProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanMove.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanMoveProperty =
            DependencyProperty.Register("CanMove", typeof(bool), typeof(ScatterViewItem), new UIPropertyMetadata(true));

        #endregion

        #endregion

        #region SelectedEvent

        public static readonly RoutedEvent SelectedEvent = Selector.SelectedEvent.AddOwner(typeof(ScatterViewItem));
        public static readonly RoutedEvent UnselectedEvent = Selector.UnselectedEvent.AddOwner(typeof(ScatterViewItem));

        // Events
        public event RoutedEventHandler Selected
        {
            add
            {
                base.AddHandler(SelectedEvent, value);
            }
            remove
            {
                base.RemoveHandler(SelectedEvent, value);
            }
        }

        public event RoutedEventHandler Unselected
        {
            add
            {
                base.AddHandler(UnselectedEvent, value);
            }
            remove
            {
                base.RemoveHandler(UnselectedEvent, value);
            }
        }

        private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ScatterViewItem container = d as ScatterViewItem;
            bool newValue = (bool)e.NewValue;
            ScatterView parentSelector = container._parent;

            if (newValue)
            {
                parentSelector.SetSelectedItem(container, true);
                container.RaiseEvent(new RoutedEventArgs(Selector.SelectedEvent, container));
                container.OnSelected();
            }
            else
            {
                parentSelector.SetSelectedItem(container, false);
                container.RaiseEvent(new RoutedEventArgs(Selector.UnselectedEvent, container));
                container.OnUnSelected();
            }
        }

        private void OnSelected()
        {
            if (_viewBox != null && CanResize)
            {
                ShowAdorner();
            }
        }

        #endregion


        public FrameworkElement ContentElement
        {
            get { return _viewBox; }
            set { _viewBox = value; }
        }

        #region Private Methods

        private void ShowAdorner()
        {
            if (resizingAdorner == null)
                resizingAdorner = new ScatterResizeAdorner(_viewBox, this);
            if (adornerLayer.GetAdorners(this) == null)
                adornerLayer.Add(resizingAdorner);
            else if (!adornerLayer.GetAdorners(this).Contains(resizingAdorner))
                adornerLayer.Add(resizingAdorner);
        }

        private void OnUnSelected()
        {
            if(resizingAdorner != null)
                adornerLayer.Remove(resizingAdorner);
        }

        void _manipulable_Manipulate(object sender, ManipulationDeltaEventArgs e)
        {

            if (CanMove && CanResize)
            {         
                Point center = (Point)this.GetValue(ScatterCanvas.CenterProperty);
                double size = (double)this.GetValue(ScatterCanvas.SizeProperty);
                double orientation = (double)this.GetValue(ScatterCanvas.OrientationProperty);

                this.SetValue(ScatterCanvas.CenterProperty, new Point(center.X + e.TranslationDelta.X / _parent.ActualWidth, center.Y + e.TranslationDelta.Y / _parent.ActualHeight));
                this.SetValue(ScatterCanvas.SizeProperty, size * e.ScaleDelta);
                this.SetValue(ScatterCanvas.OrientationProperty, orientation + e.RotationDelta);
            }
        
        }

        void _tapbehavior_DoubleTap(object sender, TapEventArgs e)
        {
            SetValue(IsSelectedProperty, true);
        }

        #endregion

        #region Private Variables
        private AdornerLayer adornerLayer;
        private ScatterView _parent;
        private FrameworkElement _viewBox;

        ScatterResizeAdorner resizingAdorner;

        Manipulable _manipulable;

        #endregion

    }
}
