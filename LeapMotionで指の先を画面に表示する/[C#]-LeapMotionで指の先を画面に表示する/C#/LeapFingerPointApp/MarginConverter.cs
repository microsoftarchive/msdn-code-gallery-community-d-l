using System;
using System.Windows;
using System.Windows.Data;

namespace LeapFingerPointApp
{
    public class MarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var width = Application.Current.MainWindow.ActualWidth;
            var height = Application.Current.MainWindow.ActualHeight;
            var pos = (FingerPoint)value;
            var result = new Thickness();

            result.Top = height - height * pos.Y;
            result.Left = width * pos.X;

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
