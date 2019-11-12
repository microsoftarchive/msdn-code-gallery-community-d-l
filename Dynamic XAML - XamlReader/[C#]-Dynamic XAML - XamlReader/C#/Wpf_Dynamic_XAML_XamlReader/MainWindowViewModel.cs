using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Wpf_Dynamic_XAML_XamlReader
{
    public class MainWindowViewModel : ViewModelBase
    {
        public RelayCommand Hello {get; set;}

        private double msgOpacity = 0.0;

        public double MsgOpacity
        {
            get
            {
                return msgOpacity;
            }
            set
            {
                msgOpacity = value;
                RaisePropertyChanged();
            }
        }


        private string msg = "";
        public string Msg
        {
            get
            {
                return msg;
            }
            set
            {
                msg = value;
                RaisePropertyChanged();
            }
        }
        
        public MainWindowViewModel()
        {
            Hello = new RelayCommand(HelloExecute);
        }

        private void HelloExecute()
        {
            Msg = "Hello";
            MsgOpacity = 1.0;
            MsgOpacity = 0.0;
        }
    }
}
