using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ListViewDemo.Models;

namespace ListViewDemo.ViewModels
{
    public class ListViewPageViewModel : INotifyPropertyChanged
    {

        ObservableCollection<Order> _ordersList;
        public ObservableCollection<Order> OrdersList
        {
            get
            {
                return _ordersList;
            }
            set
            {
                _ordersList = value;
                OnPropertyChanged("OrdersList");
            }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
           [CallerMemberName]string propertyName = "",
           Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        //INotifyPropertyChanged implementation method
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;
            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ListViewPageViewModel()
        {
            var ordersList = new ObservableCollection<Order>();

            ordersList.Add(new Order() { OrderType = "Completed Orders", TotalCount = "56566" });
            ordersList.Add(new Order() { OrderType = "Limit Orders", TotalCount = "878" });
            ordersList.Add(new Order() { OrderType = "Market Orders", TotalCount = "39856" });
            ordersList.Add(new Order() { OrderType = "Stop Orders", TotalCount = "056708" });
            ordersList.Add(new Order() { OrderType = "Imbalance Orders", TotalCount = "64775674" });
            ordersList.Add(new Order() { OrderType = "Conditional Orders", TotalCount = "56" });
            ordersList.Add(new Order() { OrderType = "Scheduled Orders", TotalCount = "1457575763" });
            ordersList.Add(new Order() { OrderType = "Mid-Point Orders", TotalCount = "2443" });
            ordersList.Add(new Order() { OrderType = "Odd lot Orders", TotalCount = "65781" });
            ordersList.Add(new Order() { OrderType = "Pending Orders", TotalCount = "9896" });

            OrdersList = ordersList;
        }
    }
}
