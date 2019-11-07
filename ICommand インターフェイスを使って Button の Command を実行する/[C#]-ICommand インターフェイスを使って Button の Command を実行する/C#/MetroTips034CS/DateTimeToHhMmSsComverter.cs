using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTips034CS
{
  class DateTimeToHhMmSsConverter : Windows.UI.Xaml.Data.IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, string language)
    {
      if (targetType == typeof(string))
        if (value is DateTimeOffset)
          if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            return ((DateTimeOffset)value).ToString("HH:mm:ss") + " (Design Mode)";
          else
            return ((DateTimeOffset)value).ToString("HH:mm:ss");

      return Windows.UI.Xaml.DependencyProperty.UnsetValue;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
      return Windows.UI.Xaml.DependencyProperty.UnsetValue;
    }
  }
}
