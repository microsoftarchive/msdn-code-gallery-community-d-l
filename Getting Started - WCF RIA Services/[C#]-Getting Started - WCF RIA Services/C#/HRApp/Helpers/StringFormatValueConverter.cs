namespace HRApp
{
    using System;
    using System.Windows.Data;

    /// <summary>
    ///     Two way IValueConverter that lets you bind a property on a bindable object
    ///     that can be an empty string value to a dependency property that should 
    ///     be set to null in that case
    /// </summary>
    public class StringFormatValueConverter : IValueConverter
    {
        private readonly string formatString;

        /// <summary>
        ///     Creates a new <see cref="StringFormatValueConverter"/>
        /// </summary>
        /// <param name="formatString">Format string, it can take zero or one parameters, the first one being replaced by the source value</param>
        public StringFormatValueConverter(string formatString)
        {
            this.formatString = formatString;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return string.Format(System.Globalization.CultureInfo.CurrentUICulture, this.formatString, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
