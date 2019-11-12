using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityMine.Avalon.Controls
{
    public class DateTimeBinding : System.ComponentModel.INotifyPropertyChanged
    {
        private string _CompoundDateTime = DateTime.Now.ToLongTimeString() + " | " + DateTime.Now.ToShortDateString();
        private System.Windows.Threading.DispatcherTimer DateTimeTimer;
        public DateTimeBinding()
        {
            DateTimeTimer = new System.Windows.Threading.DispatcherTimer();
            DateTimeTimer.Interval = TimeSpan.FromSeconds((double)1);
            DateTimeTimer.Tick += new EventHandler(uiTimer_Tick);
            DateTimeTimer.Start();
        }

        public string CompoundDateTime
        {
            get
            {
                return _CompoundDateTime;
            }
            set
            {
                _CompoundDateTime = value;
                OnPropertyChanged("CompoundDateTime");
            }

        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(info));
        }

        void uiTimer_Tick(object sender, EventArgs e)
        {
            this.CompoundDateTime = DateTime.Now.ToLongTimeString() + " | " + DateTime.Now.ToShortDateString();
        }
    }
}
