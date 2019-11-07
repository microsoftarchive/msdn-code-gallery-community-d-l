using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace WPFSample.Controls
{
    /// <summary>
    /// Provides an <see cref="Adorner"/> layer to render a <see cref="Control"/> on 
    /// top of another user interface elements.
    /// </summary>
    public class OverlayTextAdorner : Adorner
    {
        #region Fields

        private OverlayTextControl overlayTextControl;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Intializes a new instance of the <see cref="OverlayTextAdorner"/>.
        /// </summary>
        /// <param name="adornedElement">
        /// The user interface <see cref="UIElement"/> to render on.
        /// </param>
        public OverlayTextAdorner(UIElement adornedElement)
            : base(adornedElement)
        { }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the visual children count for this <see cref="OverlayTextAdorner"/>.
        /// As the <see cref="OverlayTextAdorner"/> can only host one control to render
        /// the input hint, the visual children count should be either one or zero.
        /// </summary>
        protected override int VisualChildrenCount
        {
            get
            {
                return (overlayTextControl == null ? 0 : 1);
            }
        }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Links <see cref="OverlayTextControl"/> as the visual child of itself.
        /// </summary>
        /// <param name="element">
        /// The <see cref="DependencyObject"/> to retrieve the attached properties.
        /// </param>
        /// <param name="targetOverlayTextControl">
        /// The <see cref="OverlayTextControl"/> to link for.
        /// </param>
        public void LinkOverlayTextControl(DependencyObject element, OverlayTextControl targetOverlayTextControl)
        {
            if (overlayTextControl != null || element == null ||
                (targetOverlayTextControl == null || targetOverlayTextControl.OverlayTextAdorner != null)) return;

            overlayTextControl = targetOverlayTextControl;
            overlayTextControl.OverlayTextAdorner = this;
            overlayTextControl.IsEnabled = (bool)element.GetValue(UIElement.IsEnabledProperty);
            overlayTextControl.Text = OverlayTextService.GetText(element);
            overlayTextControl.Style = OverlayTextService.GetOverlayStyle(element);

            AddVisualChild(overlayTextControl);
        }

        /// <summary>
        /// Unlinks current <see cref="OverlayTextControl"/> as the visual child of itself.
        /// </summary>
        public void UnlinkOverlayTextControl()
        {
            if (overlayTextControl == null) return;

            overlayTextControl.OverlayTextAdorner = null;
            RemoveVisualChild(overlayTextControl);
            overlayTextControl = null;
        }

        #endregion Public Methods

        #region Internal Methods

        /// <summary>
        /// Called when the target <see cref="UIElement"/> text is changed.
        /// </summary>
        /// <param name="text">
        /// The text value.
        /// </param>
        internal void OnTargetElementTextChanged(string text)
        {
            overlayTextControl.IsActive = string.IsNullOrEmpty(text);
        }

        #endregion Internal Methods

        #region Visual Override Methods

        /// <summary>
        /// Gets the <see cref="Visual"/> child by the index. There should be at most
        /// one <see cref="Control"/> child for <see cref="OverlayTextAdorner"/>.
        /// Also, this method must be called after the internal <see cref="Control"/>
        /// has been initialized.
        /// </summary>
        /// <param name="index">
        /// The index for the child in the visual tree.
        /// </param>
        /// <returns>
        /// The visual child for the given index.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If the index passed in is not zero or the internal <see cref="Control"/>
        /// is not yet initialized.
        /// </exception>
        protected override Visual GetVisualChild(int index)
        {
            if (index != 0 ||
                overlayTextControl == null)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            return overlayTextControl;
        }

        /// <summary>
        /// Measures the size for this <see cref="OverlayTextAdorner"/> to render.
        /// </summary>
        /// <param name="constraint">
        /// The <see cref="Size"/> available to measure.
        /// </param>
        /// <returns>
        /// The <see cref="Size"/> required for this <see cref="OverlayTextAdorner"/>.
        /// If the internal <see cref="Control"/> has not been initialized,
        /// zero size will be returned.
        /// </returns>
        protected override Size MeasureOverride(Size constraint)
        {
            if (overlayTextControl != null)
            {
                Size childConstraint = new Size(Double.PositiveInfinity, Double.PositiveInfinity);
                overlayTextControl.Measure(childConstraint);
            }

            return new Size(0, 0);
        }

        /// <summary>
        /// Arranges the final size for current <see cref="OverlayTextAdorner"/> before rendering.
        /// </summary>
        /// <param name="finalSize">
        /// The final <see cref="Size"/> available for <see cref="OverlayTextAdorner"/>.
        /// </param>
        /// <returns>
        /// The final <see cref="Size"/> arranged for this <see cref="OverlayTextAdorner"/>
        /// </returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            if (overlayTextControl != null)
            {
                overlayTextControl.Arrange(new Rect(overlayTextControl.DesiredSize));
            }

            return finalSize;
        }

        #endregion Visual Override Methods
    }
}
