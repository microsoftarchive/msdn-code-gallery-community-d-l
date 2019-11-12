using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.Globalization;

namespace FlashCards.UI.Converters
{
    
    #region IValueConverter Members

    /// <summary>
    /// A Generic Converter converts an object value to Visibility based on whether it is null or not. 
    /// If a paramter is passed along with the converter it checks the equality with the value and return visibility
    /// </summary>
    public class ObjectToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                if (value == null)
                    return Visibility.Collapsed;
                else
                {
                    if (value.ToString().Equals(parameter))
                        return Visibility.Visible;

                    return Visibility.Collapsed;
                }
            }

            if (value is bool)
            {
                if ((bool)value) return Visibility.Visible;
                else return Visibility.Collapsed;
            }

            if (value is string)
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;

            }

            if (value == null)
                return Visibility.Collapsed;
            else
                return Visibility.Visible;
        }



        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
