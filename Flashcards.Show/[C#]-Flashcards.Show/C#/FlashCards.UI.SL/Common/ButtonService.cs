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

namespace FlashCards.UI.Common
{
    /// <summary>
    /// Code is based on the work by Patrick Cauldwell
    /// http://www.cauldwell.net/patrick/blog/MVVMBindingToCommandsInSilverlight.aspx
    /// </summary>
  public static class ButtonService
    {
        #region CommandParameter

        /// <summary>
        /// CommandParameter Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached("CommandParameter", typeof(string), typeof(ButtonService),
                new PropertyMetadata(OnCommandParameterChanged));

        /// <summary>
        /// Gets the CommandParameter property.
        /// </summary>
        public static string GetCommandParameter(DependencyObject d)
        {
            return (string)d.GetValue(CommandParameterProperty);
        }

        /// <summary>
        /// Sets the CommandParameter property.
        /// </summary>
        public static void SetCommandParameter(DependencyObject d, string value)
        {
            d.SetValue(CommandParameterProperty, value);
        }

        /// <summary>
        /// Handles changes to the CommandParameter property.
        /// </summary>
        private static void OnCommandParameterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }

        #endregion
        
        #region Command

        /// <summary>
        /// Command Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(ButtonService),
                new PropertyMetadata(OnCommandChanged));

        /// <summary>
        /// Gets the Command property.
        /// </summary>
        public static ICommand GetCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(CommandProperty);
        }

        /// <summary>
        /// Sets the Command property.
        /// </summary>
        public static void SetCommand(DependencyObject d, ICommand value)
        {
            d.SetValue(CommandProperty, value);
        }

        /// <summary>
        /// Handles changes to the Command property.
        /// </summary>
        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Button)
            {
                string parameter = d.GetValue(CommandParameterProperty) as string;
                Button b = d as Button;
                ICommand c = e.NewValue as ICommand;
                b.Click += delegate(object sender, RoutedEventArgs arg) { c.Execute(parameter); };
            }
        }

        #endregion
        
        
    }

}
