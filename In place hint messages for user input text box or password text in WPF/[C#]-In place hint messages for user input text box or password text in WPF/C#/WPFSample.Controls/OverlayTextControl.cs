using System;

using System.Windows;
using System.Windows.Controls;

namespace WPFSample.Controls
{
    /// <summary>
    /// The control used to render on the adoner.
    /// </summary>
    public class OverlayTextControl : Control
    {
        #region Constructors

        /// <summary>
        /// Static metadata registration.
        /// </summary>
        static OverlayTextControl()
        {
            Type ownerType = typeof(OverlayTextControl);

            DefaultStyleKeyProperty.OverrideMetadata(ownerType, new FrameworkPropertyMetadata(ownerType));
            IsHitTestVisibleProperty.OverrideMetadata(ownerType, new UIPropertyMetadata(false));
        }

        #endregion Constructors

        #region Dependency Properties

        #region Text Property

        /// <summary>
        /// Stores the text to display for the input hint.
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(OverlayTextControl),
                new FrameworkPropertyMetadata(
                    string.Empty,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// Gets or sets the input hint text.
        /// </summary>
        public string Text
        {
            get
            { 
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        #endregion Text Property

        #region IsActive Property

        /// <summary>
        /// Stores indicator whether to show content or not.
        /// </summary>
        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register(
                "IsActive",
                typeof(bool),
                typeof(OverlayTextControl),
                new FrameworkPropertyMetadata(
                    true,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// Gets or sets whether the content should be active or not.
        /// </summary>
        public bool IsActive
        {
            get
            {
                return (bool)GetValue(IsActiveProperty);
            }
            set
            {
                SetValue(IsActiveProperty, value);
            }
        }

        #endregion IsActive Property

        #endregion Dependency Properties

        #region Methods

        /// <summary>
        /// Gets or sets the <see cref="OverlayTextAdorner"/> to host <see cref="OverlayTextControl"/>.
        /// </summary>
        internal OverlayTextAdorner OverlayTextAdorner
        {
            get;
            set;
        }

        #endregion Methods
    }
}
