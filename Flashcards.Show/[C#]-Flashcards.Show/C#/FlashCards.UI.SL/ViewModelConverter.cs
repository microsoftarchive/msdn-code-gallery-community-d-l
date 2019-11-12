using System.Windows.Data;
using System;
using System.Globalization;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using FlashCards.ViewModel;

namespace FlashCards.UI
{
    public class ViewModelConverter : IValueConverter
    {
        public ViewModelConverter()
        { 
        
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() == typeof(DecksCollection))
            {
                return new GameHome() { DataContext = value };
            }

            if (value.GetType() == typeof(LearningGameViewModel))
            {
                return new LearningGame() { DataContext = value };
            }

            if (value.GetType() == typeof(MatchingGameViewModel))
            {
                return new MatchingGame() { DataContext = value };
            }

            return null;
        }
     
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
