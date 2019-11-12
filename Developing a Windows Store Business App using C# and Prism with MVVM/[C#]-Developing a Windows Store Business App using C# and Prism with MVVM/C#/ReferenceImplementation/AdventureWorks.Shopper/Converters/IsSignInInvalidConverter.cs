// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Data;

namespace AdventureWorks.Shopper.Converters
{
    /// <summary>
    /// Value converter that translates a boolean value to an invalid sign-in message.
    /// </summary>
    public sealed class IsSignInInvalidConverter : IValueConverter
    {
        ResourceLoader resourceLoader = new ResourceLoader();

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value is bool && (bool)value) ? resourceLoader.GetString("ErrorInvalidSignInErrorMessage") : string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
