using System;
using System.Reflection;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using FlashCards.ViewModel;

namespace FlashCards.UI.Converters
{
    public class UriToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            if (!string.IsNullOrEmpty(value.ToString()))
            {
                try
                {
                    BitmapImage bi = MainViewModel.Instance.GetImage(value as string);

                    return bi;
                }
                catch (Exception e)
                {
                    Utils.LogException(MethodBase.GetCurrentMethod(), e);
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
