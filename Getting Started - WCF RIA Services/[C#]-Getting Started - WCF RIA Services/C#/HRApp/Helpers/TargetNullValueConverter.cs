namespace HRApp
{
    using System;
    using System.Windows.Data;

    /// <summary>
    ///     Two way IValueConverter that lets you bind a property on a bindable object
    ///     that can be an empty string value to a dependency property that should 
    ///     be set to null in that case
    /// </summary>
    public class TargetNullValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return string.IsNullOrEmpty((string)value) ? null : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value ?? string.Empty;
        }
    }
}
