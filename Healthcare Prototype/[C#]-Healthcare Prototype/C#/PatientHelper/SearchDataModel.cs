using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Controls;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.Windows.Ink;

namespace IdentityMine.Avalon.Controls
{
    public class SearchData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public SearchData()
        {
            _SearchXPSData = new SearchXPSItemCollection();
            _SearchMSNData = new SearchMSNItemCollection();
        }

        #region Properties

        public SearchXPSItemCollection SearchXPSData
        {
            get { return _SearchXPSData; }
        }

        public SearchMSNItemCollection SearchMSNData
        {
            get { return _SearchMSNData; }
        }

        #endregion

        private void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private SearchXPSItemCollection _SearchXPSData;
        private SearchMSNItemCollection _SearchMSNData;
    }

    public class SearchXPSItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string Path
        {
            get { return _Path; }
            set
            {
                _Path = value;
                NotifyPropertyChanged("Path");
            }
        }

        private void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private string _Name = "";
        private string _Path = "";
    }

    public class SearchXPSItemCollection : ObservableCollection<SearchXPSItem>
    {
        public event EventHandler SearchXPSItemCostChanged;

        public new void Add(SearchXPSItem item)
        {
            if (item != null)
            {
                item.PropertyChanged += new PropertyChangedEventHandler(SearchXPSItemPropertyChanged);
            }
            base.Add(item);

            RaiseSearchXPSItemCostChanged(this, new EventArgs());
        }

        public new void Remove(SearchXPSItem item)
        {
            base.Remove(item);

            RaiseSearchXPSItemCostChanged(this, new EventArgs());
        }

        private void SearchXPSItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Cost")
            {
                RaiseSearchXPSItemCostChanged(this, new EventArgs());
            }
        }

        void RaiseSearchXPSItemCostChanged(object sender, EventArgs args)
        {
            if (SearchXPSItemCostChanged != null)
            {
                SearchXPSItemCostChanged(sender, args);
            }
        }
    }

    public class SearchMSNItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string Path
        {
            get { return _Path; }
            set
            {
                _Path = value;
                NotifyPropertyChanged("Path");
            }
        }

        private void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private string _Name = "";
        private string _Path = "";
    }

    public class SearchMSNItemCollection : ObservableCollection<SearchMSNItem>
    {
        public event EventHandler SearchMSNItemCostChanged;

        public new void Add(SearchMSNItem item)
        {
            if (item != null)
            {
                item.PropertyChanged += new PropertyChangedEventHandler(SearchMSNItemPropertyChanged);
            }
            base.Add(item);

            RaiseSearchMSNItemCostChanged(this, new EventArgs());
        }

        public new void Remove(SearchMSNItem item)
        {
            base.Remove(item);

            RaiseSearchMSNItemCostChanged(this, new EventArgs());
        }

        private void SearchMSNItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Cost")
            {
                RaiseSearchMSNItemCostChanged(this, new EventArgs());
            }
        }

        void RaiseSearchMSNItemCostChanged(object sender, EventArgs args)
        {
            if (SearchMSNItemCostChanged != null)
            {
                SearchMSNItemCostChanged(sender, args);
            }
        }
    }

}



