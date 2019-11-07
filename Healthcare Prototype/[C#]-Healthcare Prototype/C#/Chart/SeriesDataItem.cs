using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace IdentityMine.Avalon.Controls
{
    public class SeriesDataItem : DependencyObject,INotifyPropertyChanged
    {
        private SeriesDataItems _itemParent;

        public SeriesDataItem()
        {

        }

        public SeriesDataItem(SeriesDataItems itemParent, double itemValue)
        {
            _itemParent = itemParent;
            DependencyObject dob = new DependencyObject();
            this.SetValue(SeriesDataItem.ValueProperty, itemValue);
        }

        #region Dependency Properties Value

        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value",
            typeof(double), typeof(SeriesDataItem), new FrameworkPropertyMetadata((double)0, new PropertyChangedCallback(ValueInvalidated)));

        public static double GetValue(DependencyObject d)
        {
            return (double)(d.GetValue(SeriesDataItem.ValueProperty));
        }

        public static void SetValue(DependencyObject d, double value)
        {
            d.SetValue(SeriesDataItem.ValueProperty, value);
        }

        private static void ValueInvalidated(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            if (target == null)
                return;
        }
        #endregion

        public SeriesDataItems Parent
        {
            get { return _itemParent; }
        }

        public double Value
        {
            get { return (double)this.GetValue(SeriesDataItem.ValueProperty); }
            set { this.SetValue(SeriesDataItem.ValueProperty,value); OnPropertyChanged("Value"); }
        }

        // The following variable and method provide the support for
        // handling property changed events.
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
}
