using System;
using System.Windows.Data;

namespace FileExplorer.Helper
{
    public class GridColumnWidthConverter : IValueConverter
    {
        const int offset = 30;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return 0;

            double width = 0;
            double.TryParse(value.ToString(), out width);
            if (width < offset)
                return 0;

            return width - offset;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
