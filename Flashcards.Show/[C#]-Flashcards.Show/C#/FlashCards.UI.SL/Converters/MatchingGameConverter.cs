using System;
using System.Windows;
using System.Windows.Data;

namespace FlashCards.UI.Converters
{
    public class MatchingGameConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool isMatchingGame = (bool)value;

            switch ((string)parameter)
            {
                case "ItemTemplate":
                    if (isMatchingGame)
                    {
                        return Application.Current.Resources["MatchingGameCarPair_Template"];
                    }
                    else
                    {
                        return Application.Current.Resources["CarPair_Template"];
                    }

                case "ItemContainerStyle":
                    if (isMatchingGame)
                    {
                        return Application.Current.Resources["ListBoxItemStyle_MatchingGameCardPair"];
                    }
                    else
                    {
                        return Application.Current.Resources["ListBoxItemStyle_CardPair"];
                    }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
