// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace AdventureWorks.Shopper.Common
{
    // <summary>
    /// Helper class that allows you to monitor a property corresponding to a dependency property 
    /// on some object for changes and have an event raised from
    /// the instance of this helper that you can handle.
    /// Usage: Construct an instance, passing in the object and the name of the normal .NET property that
    /// wraps a DependencyProperty, then subscribe to the PropertyChanged event on this helper instance. 
    /// Your subscriber will be called whenever the source DependencyProperty changes.
    /// </summary>
    public class DependencyPropertyChangedHelper : DependencyObject
    {
        /// <summary>
        /// Constructor for the helper. 
        /// </summary>
        /// <param name="source">Source object that exposes the DependencyProperty you wish to monitor.</param>
        /// <param name="propertyPath">The name of the property on that object that you want to monitor.</param>
        public DependencyPropertyChangedHelper(DependencyObject source, string propertyPath)
        {
            // Set up a binding that flows changes from the source DependencyProperty through to a DP contained by this helper 
            Binding binding = new Binding
            {
                Source = source,
                Path = new PropertyPath(propertyPath)
            };
            BindingOperations.SetBinding(this, HelperProperty, binding);
        }

        /// <summary>
        /// Dependency property that is used to hook property change events when an internal binding causes its value to change.
        /// This is only public because the DependencyProperty syntax requires it to be, do not use this property directly in your code.
        /// </summary>
        public static DependencyProperty HelperProperty =
            DependencyProperty.Register("Helper", typeof(object), typeof(DependencyPropertyChangedHelper), new PropertyMetadata(null, OnPropertyChanged));

        /// <summary>
        /// Wrapper property for a helper DependencyProperty used by this class. Only public because the DependencyProperty syntax requires it.
        /// DO NOT use this property directly.
        /// </summary>
        public object Helper
        {
            get { return (object)GetValue(HelperProperty); }
            set { SetValue(HelperProperty, value); }
        }

        // When our dependency property gets set by the binding, trigger the property changed event that the user of this helper can subscribe to
        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var helper = (DependencyPropertyChangedHelper)d;
            helper.PropertyChanged(d, e);
        }

        /// <summary>
        /// This event will be raised whenever the source object property changes, and carries along the before and after values
        /// </summary>
        public event EventHandler<DependencyPropertyChangedEventArgs> PropertyChanged = delegate { };
    }
}
