// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace AdventureWorks.Shopper.Converters
{
    /// <summary>
    /// Value converter that translates NOT null to <see cref="Visibility.Visible"/> and the opposite to <see cref="Visibility.Collapsed"/> 
    /// </summary>
    public sealed class NotNullToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value != null) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (value is Visibility && (Visibility)value == Visibility.Visible) ? true : false;
        }
    }
}
