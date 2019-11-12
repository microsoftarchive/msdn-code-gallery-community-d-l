using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using System.Windows.Data;
using System.Windows;

namespace FlashCards.UI.Converters
{
    public class ValueToValueConverter : IValueConverter
    {
        private static Dictionary<object, Dictionary<string, string>> _cacheDictionaries = new Dictionary<object, Dictionary<string, string>>();

        private static Dictionary<string, string> BuildDictionaryFromString(object parameter)
        {
            Dictionary<string, string> values;
            string parameterString = parameter as string;
            if (parameterString == null)
            {
                throw new ArgumentException("Converter parameter must be a non-null string", "parameter");
            }

            values = new Dictionary<string, string>();

            string[] pairs = parameterString.Split(',');
            for (int i = 0; i < pairs.Length; ++i)
            {
                string[] pairParts = pairs[i].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                if (pairParts.Length != 2)
                {
                    throw new ArgumentException(
                        "Converter parameter must have a single ',' between pairs and a single ' ' between pair parts" +
                        "\n" +
                        "For example: 'True False,False True'", "parameter");
                }

                values[pairParts[0]] = pairParts[1];
            }

            return values;
        }

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // get values dictionary
            if (!_cacheDictionaries.ContainsKey(parameter as string))
            {
                _cacheDictionaries[parameter] = BuildDictionaryFromString(parameter);
            }
            Dictionary<string, string> values = _cacheDictionaries[parameter];

            // return value if key exists
            string valueString = value.ToString();
            return (values.ContainsKey(valueString)) ? values[valueString] : DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
