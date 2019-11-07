using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace FileExplorer.Helper
{
    public class AndConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool result = false;
            if (values.IsNullOrEmpty())
            {
                return result;
            }

            result = true;
            foreach (var item in values)
            {
                if (item == DependencyProperty.UnsetValue)
                {
                    result &= false;
                }
                else
                {
                    result &= (bool)item;
                }
            }
            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    
    public class ReverseBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool result = true;
            if (value == null || value == DependencyProperty.UnsetValue)
                return result;

            result = (bool)value ? false : true;
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
