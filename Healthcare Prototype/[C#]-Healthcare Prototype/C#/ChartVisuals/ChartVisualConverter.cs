using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.ComponentModel;

namespace IdentityMine.Avalon.Controls
{
    public class ChartVisualConverter : IValueConverter
    {
        public ChartVisualConverter()
        {
            System.Diagnostics.Debug.WriteLine("ChartVisualConverter Initialized");
        }

        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo cultureInfo)
        {
            if (targetType == typeof(Brush) && value is String)
            {
                String chartKey = value as String;
                Dictionary<string, VisualBrush> chartVisuals = parameter as Dictionary<string, VisualBrush>;
                if (chartVisuals.Count == 0)
                    return null;

                return (chartVisuals[chartKey]);
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo cultureInfo)
        {
            //if (targetType == typeof(Double) && value is Nullable<Double>)
            //{
            //    Nullable<Double> nullableValue = (Nullable<Double>)value;

            //    if (nullableValue.HasValue)
            //    {
            //        return nullableValue.Value;
            //    }
            //}

            return DependencyProperty.UnsetValue;
        }
    }
}
