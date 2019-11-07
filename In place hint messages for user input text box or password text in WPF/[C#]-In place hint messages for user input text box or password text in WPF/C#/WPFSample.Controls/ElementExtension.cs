using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace WPFSample.Controls
{
    /// <summary>
    /// Provides extension helper methods for visual tree.
    /// </summary>
    internal static class ElementExtension
    {
        /// <summary>
        /// Returns the first <see cref="UIElement"/> in the ancestral chain including 
        /// the element itself.
        /// </summary>
        /// <param name="element">
        /// The <see cref="DependencyObject"/> to get the containing UI element for.
        /// </param>
        /// <returns>
        /// The first <see cref="UIElement"/> that contains the <paramref name="element"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="element"/> is null.
        /// </exception>
        internal static UIElement GetContainingElement(this DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            UIElement uiElement = element as UIElement;
            if (uiElement != null)
            {
                return uiElement;
            }

            ContentElement contentElement = element as ContentElement;
            if (contentElement != null)
            {
                DependencyObject parent = ContentOperations.GetParent(contentElement)
                    ?? LogicalTreeHelper.GetParent(contentElement);
                if (parent != null)
                {
                    return GetContainingElement(parent);
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the first <see cref="AdornerLayer"/> in the ancestral chain including 
        /// the <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="visual">
        /// The <see cref="DependencyObject"/> to get the <see cref="AdornerLayer"/>.
        /// </param>
        /// <returns>
        /// The first <see cref="AdornerLayer"/> in the ancestral chain including the 
        /// <paramref name="visual"/>.
        /// </returns>
        internal static AdornerLayer GetAdornerLayer(this DependencyObject visual)
        {
            if (visual == null)
            {
                throw new ArgumentNullException("visual");
            }

            Visual parent = VisualTreeHelper.GetParent(visual) as Visual;
            while (parent != null)
            {
                AdornerDecorator adornerDecorator = parent as AdornerDecorator;
                if (adornerDecorator != null)
                {
                    return adornerDecorator.AdornerLayer;
                }

                parent = VisualTreeHelper.GetParent(parent) as Visual;
            }

            return null;
        }
    }
}
