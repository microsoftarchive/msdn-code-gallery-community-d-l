using System;
using System.Windows.Controls;
using IdentityMine.Windows.SimpleMultitouch;
using System.Windows;
using Windows7.Multitouch.ManipulationInterop;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Media;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace FlashCards.UI.Behaviors
{
    public class ScrollWithSelectionFocus : ScrollBehavior, IManipulationEvents
    {
        IInertiaProcessor _iprocessor;
        IConnectionPoint _conpt;
        int _cookie;
        bool _isanimating;

        public ScrollWithSelectionFocus()
        {
            Guid manipulationEventsId = new Guid(IIDGuid.IManipulationEvents);
            _iprocessor = new InertiaProcessor();
            _iprocessor.FindConnectionPoint(ref manipulationEventsId, out _conpt);
            _conpt.Advise(this, out _cookie);
        }

        protected override void OnAttached()
        {
            base.OnAttached();

            DependencyPropertyDescriptor.FromProperty(ListBox.SelectedIndexProperty, typeof(ListBox)).AddValueChanged(AssociatedObject.TemplatedParent, OnSelectedIndexChanged);
            OnSelectedIndexChanged(null, new EventArgs());
        }

        public static readonly DependencyProperty ItemPanelProperty =
            DependencyProperty.Register("ItemPanel", typeof(Panel), typeof(ScrollWithSelectionFocus),
            new PropertyMetadata(OnItemPanelChanged));

        public Panel ItemPanel
        {
            get { return (Panel)GetValue(ItemPanelProperty); }
            set { SetValue(ItemPanelProperty, value); }
        }

        private static void OnItemPanelChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            ((ScrollWithSelectionFocus)sender).OnSelectedIndexChanged(sender, null);
        }

        private void OnSelectedIndexChanged(object sender, EventArgs args)
        {
            if (AssociatedObject == null ||
                (AssociatedObject.TemplatedParent as ListBox) == null ||
                ItemPanel == null ||
                ItemPanel.Children.Count <= ((ListBox)AssociatedObject.TemplatedParent).SelectedIndex ||
                ((ListBox)AssociatedObject.TemplatedParent).SelectedIndex < 0) return;

            ((ListBox)AssociatedObject.TemplatedParent).UpdateLayout();
            FrameworkElement fe = ItemPanel.Children[((ListBox)AssociatedObject.TemplatedParent).SelectedIndex] as FrameworkElement;

            Point pt = fe.TransformToAncestor(AssociatedObject).Transform(new Point(fe.ActualWidth / 2.0, fe.ActualHeight / 2.0));

            pt.X -= AssociatedObject.ViewportWidth / 2.0;

            if (_isanimating)
            {
                _iprocessor.Reset();
                CompositionTarget.Rendering -= Update;
            }

            _iprocessor.InitialAngularVelocity = 0.0f;
            _iprocessor.InitialExpansionVelocity = 0.0f;
            _iprocessor.InitialOriginX = 0.0f;
            _iprocessor.InitialOriginY = 0.0f;
            _iprocessor.InitialVelocityX = 2.0f * Math.Sign(pt.X);
            _iprocessor.InitialVelocityY = 0.0f;
            _iprocessor.DesiredDisplacement = (float)Math.Abs(pt.X);
            _iprocessor.DesiredExpansion = 0.0f;
            _iprocessor.DesiredRotation = 0.0f;
            CompositionTarget.Rendering += Update;
            _isanimating = true;
        }

        void Update(object sender, EventArgs e)
        {
            _iprocessor.Process();
        }

        #region IManipulationEvents Members

        public void ManipulationStarted(float x, float y)
        {
        }

        public void ManipulationDelta(float x, float y, float translationDeltaX, float translationDeltaY, float scaleDelta, float expansionDelta, float rotationDelta, float cumulativeTranslationX, float cumulativeTranslationY, float cumulativeScale, float cumulativeExpansion, float cumulativeRotation)
        {
            AssociatedObject.ScrollToHorizontalOffset(AssociatedObject.HorizontalOffset + (double)translationDeltaX);
            AssociatedObject.ScrollToVerticalOffset(AssociatedObject.VerticalOffset + (double)translationDeltaY);
        }

        public void ManipulationCompleted(float x, float y, float cumulativeTranslationX, float cumulativeTranslationY, float cumulativeScale, float cumulativeExpansion, float cumulativeRotation)
        {
            CompositionTarget.Rendering -= Update;
            _iprocessor.Reset();
            _isanimating = false;
        }

        public void Dispose()
        {
            Marshal.ReleaseComObject(_iprocessor);
        }

        #endregion
    }
}
