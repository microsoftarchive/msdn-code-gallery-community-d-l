using System;
using System.Diagnostics;
using System.Windows.Data;

namespace LeapFingerPointApp
{
    public class SizeConverter : IValueConverter
    {
        public double BaseSize { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var pos = (FingerPoint)value;
            var z = -1 * (pos.Z - 1);
            return this.BaseSize + this.BaseSize * z;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
