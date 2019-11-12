// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Practices.Prism.StoreApps;
using Windows.UI.Xaml;

namespace AdventureWorks.Shopper.Behaviors
{
    // Documentation on validating user input is at http://go.microsoft.com/fwlink/?LinkID=288817&clcid=0x409

    public class HighlightFormFieldOnErrors : Behavior<FrameworkElement>
    {
        public ReadOnlyCollection<string> PropertyErrors
        {
            get { return (ReadOnlyCollection<string>)GetValue(PropertyErrorsProperty); }
            set { SetValue(PropertyErrorsProperty, value); }
        }

        public string HighlightStyleName
        {
            get { return (string)GetValue(HighlightStyleNameProperty); }
            set { SetValue(HighlightStyleNameProperty, value); }
        }

        public string OriginalStyleName
        {
            get { return (string)GetValue(OriginalStyleNameProperty); }
            set { SetValue(OriginalStyleNameProperty, value); }
        }

        public static DependencyProperty PropertyErrorsProperty =
            DependencyProperty.RegisterAttached("PropertyErrors", typeof(ReadOnlyCollection<string>), typeof(HighlightFormFieldOnErrors), new PropertyMetadata(BindableValidator.EmptyErrorsCollection, OnPropertyErrorsChanged));

        // The default for this property only applies to TextBox controls.
        public static DependencyProperty HighlightStyleNameProperty =
            DependencyProperty.RegisterAttached("HighlightStyleName", typeof(string), typeof(HighlightFormFieldOnErrors), new PropertyMetadata("HighlightTextBoxStyle"));

        // The default for this property only applies to TextBox controls.
        protected static DependencyProperty OriginalStyleNameProperty =
            DependencyProperty.RegisterAttached("OriginalStyleName", typeof(Style), typeof(HighlightFormFieldOnErrors), new PropertyMetadata("BaseTextBoxStyle"));

        private static void OnPropertyErrorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            if (args == null || args.NewValue == null)
            {
                return;
            }

            var control = ((Behavior<FrameworkElement>)d).AssociatedObject;
            var propertyErrors = (ReadOnlyCollection<string>)args.NewValue;

            Style style = (propertyErrors.Any()) ?
                (Style)Application.Current.Resources[((HighlightFormFieldOnErrors)d).HighlightStyleName] :
                (Style)Application.Current.Resources[((HighlightFormFieldOnErrors)d).OriginalStyleName];

            control.Style = style;
        }

        protected override void OnAttached()
        {
        }

        protected override void OnDetached()
        {
        }
    }
}
