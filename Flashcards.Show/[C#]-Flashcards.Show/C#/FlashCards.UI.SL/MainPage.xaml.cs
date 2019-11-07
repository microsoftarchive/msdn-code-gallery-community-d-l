using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Resources;
using FlashCards.ViewModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Browser;

namespace FlashCards.UI
{
    public partial class MainPage : UserControl
    {
        private const int PasswordLength = 6;
        private readonly string DownloadingDeckString;

        public MainPage()
        {
            InitializeComponent();

            this.DataContext = MainViewModel.Instance;

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

            DownloadingDeckString = (string)Application.Current.Resources["Resource_DownloadingDeck"];
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            MainViewModel.Instance.IsBusy = true;
            MainViewModel.Instance.WaitIndicatorText = string.Format(DownloadingDeckString, "0");

            // get parameters
            IDictionary<string, string> urlParameters = HtmlPage.Document.QueryString;

            //urlParameters.Add("param", "ZzdvaWlweW9jaGF5aw");
            string param;
            if (urlParameters.TryGetValue("param", out param))
            {
                param = Utils.Decode(param);
                string password = param.Substring(0, PasswordLength);
                string senderName = param.Substring(PasswordLength, param.Length - PasswordLength);

                MainViewModel.Instance.StartLoading(senderName, password);
            }
            else
            {
                MainViewModel.Instance.IsBusy = false;
            }
        }
    }
}
