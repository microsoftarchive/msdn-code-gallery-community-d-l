using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.Globalization;

namespace FlashCards.UI.Converters
{
    

    /// <summary>
    /// A Generic Converter converts an object value to Visibility based on whether it is null or not. 
    /// If a paramter is passed along with the converter it checks the equality with the value and return visibility
    /// </summary>
    public class CompareConverter : IValueConverter
    {
        
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                if (value.ToString().Equals(parameter))
                    return true;

                return false;
            }

            if (value is bool)
            {
                if ((bool)value) return true;
                else return false;
            }

            if (value is string)
            {
                return !string.IsNullOrEmpty(value.ToString());
            }
            if (value == null)
                return false;
            else
                return true;
        }



        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
