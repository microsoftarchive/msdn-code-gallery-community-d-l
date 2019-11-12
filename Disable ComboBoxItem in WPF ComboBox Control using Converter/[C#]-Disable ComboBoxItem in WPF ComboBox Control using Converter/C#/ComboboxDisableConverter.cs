using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace ComboboxDisable
{
    // Converter for disabling ComboboxItem
    class ComboboxDisableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return value;
            // You can add your custom logic here to disable combobox item
            if (value == "CollectionItem2" || value == "CollectionItem3")
                return true;

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
