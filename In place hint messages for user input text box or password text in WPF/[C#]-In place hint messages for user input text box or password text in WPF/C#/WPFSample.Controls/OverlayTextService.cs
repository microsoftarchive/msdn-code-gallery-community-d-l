using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace WPFSample.Controls
{
    /// <summary>
    /// The service class to enable the overlay controls on top of other controls.
    /// </summary>
    public class OverlayTextService
    {
        #region Attached Properties

        #region Text Property

        /// <summary>
        /// The DependencyProperty for text message property.  
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.RegisterAttached(
                "Text",
                typeof(string),
                typeof(OverlayTextService),
                new FrameworkPropertyMetadata(
                    null,
                    new PropertyChangedCallback(OnTextPropertyChanged)));

        /// <summary>
        /// Gets the value of text message on the specified object
        /// </summary>
        /// <param name="element">
        /// The <see cref="DependencyObject"/> to get the text message.
        /// </param>
        /// <returns>
        /// The text message string for <paramref name="element"/>.
        /// </returns>
        public static string GetText(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            return (string)element.GetValue(TextProperty);
        }

        /// <summary>
        /// Sets the value of text message on the specified object
        /// </summary>
        /// <param name="element">
        /// The <see cref="DependencyObject"/> to set the text message.
        /// </param>
        /// <param name="value">
        /// The text message string for <paramref name="element"/>.
        /// </param>
        public static void SetText(DependencyObject element, string value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            element.SetValue(TextProperty, value);
        }

        private static void OnTextPropertyChanged(DependencyObject element, 
            DependencyPropertyChangedEventArgs args)
        {
            string newText = (string)args.NewValue;
            string oldText = (string)args.OldValue;

            bool isNewEmpty = string.IsNullOrEmpty(newText);

            if (isNewEmpty == string.IsNullOrEmpty(oldText))
            {
                // Both new and old values are empty
                return;
            }

            if (isNewEmpty)
            {
                UnregisterTextElement(element);
            }
            else
            {
                RegisterTextElement(element);
            }
        }

        #endregion Text Property

        #region Style Property

        /// <summary>
        /// Dependency property for the input hint style.
        /// </summary>
        public static readonly DependencyProperty OverlayStyleProperty =
            DependencyProperty.RegisterAttached(
                "OverlayStyle",
                typeof(Style),
                typeof(OverlayTextService),
                new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Gets the <see cref="Style"/> value for the specified <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="element">
        /// The <see cref="DependencyObject"/> to get <see cref="Style"/>.
        /// </param>
        /// <returns>
        /// The <see cref="Style"/> for <paramref name="element"/>.
        /// </returns>
        public static Style GetOverlayStyle(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            return (Style)element.GetValue(OverlayStyleProperty);
        }

        /// <summary>
        /// Sets the <see cref="Style"/> value for the specified <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="element">
        /// The <see cref="DependencyObject"/> to set <see cref="Style"/>.
        /// </param>
        /// <param name="value">
        /// The <see cref="Style"/> value for <paramref name="element"/>.
        /// </param>
        public static void SetOverlayStyle(DependencyObject element, Style value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            element.SetValue(OverlayStyleProperty, value);
        }

        #endregion Style Property

        /// <summary>
        /// Stores the <see cref="OverlayTextAdorner"/>.
        /// </summary>
        private static readonly DependencyProperty OverlayTextAdornerProperty =
            DependencyProperty.RegisterAttached(
                "OverlayTextAdorner",
                typeof(OverlayTextAdorner),
                typeof(OverlayTextService),
                new UIPropertyMetadata(null));

        /// <summary>
        /// Stores the <see cref="UIElement"/> that has <see cref="OverlayTextAdorner"/>.
        /// </summary>
        private static readonly DependencyProperty OverlayTextAdornerHolderProperty =
            DependencyProperty.RegisterAttached(
                "OverlayTextAdornerHolder",
                typeof(UIElement),
                typeof(OverlayTextService),
                new UIPropertyMetadata(null));

        #endregion Attached Properties

        #region Register/Unregister Elements

        private static void RegisterTextElement(DependencyObject element)
        {
            if (element == null) return;

            UIElement adornedElement = element.GetContainingElement();
            if (adornedElement == null)
            {
                // No parent element
                return;
            }

            AdornerLayer adornerLayer = adornedElement.GetAdornerLayer();
            if (adornerLayer == null)
            {
                // No adorner layer
                return;
            }

            OverlayTextAdorner adorner = new OverlayTextAdorner(adornedElement);
            OverlayTextControl overlayTextControl = new OverlayTextControl();

            adorner.LinkOverlayTextControl(element, overlayTextControl);
            adornerLayer.Add(adorner);
            element.SetValue(OverlayTextAdornerProperty, adorner);
            element.SetValue(OverlayTextAdornerHolderProperty, adornedElement);

            HookTargetElementEventHandlers(element);
        }

        private static void UnregisterTextElement(DependencyObject element)
        {
            if (element == null) return;

            // Remove overlay text control from adorner.
            OverlayTextAdorner adorner = (OverlayTextAdorner)element.GetValue(OverlayTextAdornerProperty);
            UIElement adornedElement = (UIElement)element.GetValue(OverlayTextAdornerHolderProperty);

            if (adornedElement != null && adorner != null)
            {
                adorner.UnlinkOverlayTextControl();

                AdornerLayer adornerLayer = adornedElement.GetAdornerLayer();
                if (adornerLayer != null)
                {
                    adornerLayer.Remove(adorner);
                }
            }

            element.ClearValue(OverlayTextAdornerProperty);
            element.ClearValue(OverlayTextAdornerHolderProperty);

            UnhookTargetElementEventHandlers(element);
        }

        private static void HookTargetElementEventHandlers(DependencyObject element)
        {
            TextBox textBox = element as TextBox;
            if (textBox != null)
            {
                textBox.TextChanged += OnTextChanged;
                return;
            }

            PasswordBox passwordBox = element as PasswordBox;
            if (passwordBox != null)
            {
                passwordBox.PasswordChanged += OnPasswordChanged;
            }
        }

        private static void UnhookTargetElementEventHandlers(DependencyObject element)
        {
            TextBox textBox = element as TextBox;
            if (textBox != null)
            {
                textBox.TextChanged -= OnTextChanged;
                return;
            }

            PasswordBox passwordBox = element as PasswordBox;
            if (passwordBox != null)
            {
                passwordBox.PasswordChanged -= OnPasswordChanged;
            }
        }

        #endregion Register/Unregister Elements

        #region TextBox/PasswordBox Events

        private static void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;

            OverlayTextAdorner adorner = (OverlayTextAdorner)textBox.GetValue(OverlayTextAdornerProperty);
            if (adorner != null)
            {
                adorner.OnTargetElementTextChanged(textBox.Text);
            }
        }

        private static void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            if (passwordBox == null) return;

            OverlayTextAdorner adorner = (OverlayTextAdorner)passwordBox.GetValue(OverlayTextAdornerProperty);
            if (adorner != null)
            {
                adorner.OnTargetElementTextChanged(passwordBox.Password);
            }
        }

        #endregion TextBox/PasswordBox Events
    }
}
