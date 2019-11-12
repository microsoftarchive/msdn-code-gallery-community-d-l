using System;
using System.Windows;
using System.Windows.Data;

namespace FileExplorer.Helper
{
    public class AndVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility result = Visibility.Collapsed;
            if (values.IsNullOrEmpty())
            {
                return result;
            }

            bool isTrue = true;

            foreach (var item in values)
            {
                if (item == DependencyProperty.UnsetValue)
                {
                    isTrue &= false;
                }
                else
                {
                    isTrue &= (bool)item;
                }
            }
            result = isTrue ? Visibility.Visible : Visibility.Collapsed;
            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }    
 
}
