using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ApplicationNavigation.View
{
    public partial class UserControl6 : UserControl, INotifyPropertyChanged
    {
        UIElement _CurrentPage;
        public UIElement CurrentPage
        {
            get
            {
                return _CurrentPage;
            }
            set
            {
                if (_CurrentPage != value)
                {
                    _CurrentPage = value;
                    RaisePropertyChanged("CurrentPage");
                }
            }
        }

        public UserControl6()
        {
            InitializeComponent();
            DataContext = this;
        }

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage = new UserControl7();
        }

    }
}
