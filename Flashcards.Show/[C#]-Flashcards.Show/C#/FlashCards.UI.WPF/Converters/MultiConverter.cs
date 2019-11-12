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
    public class AndOperationConverter : IMultiValueConverter
    {

        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)values[0] && (bool)values[1];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
