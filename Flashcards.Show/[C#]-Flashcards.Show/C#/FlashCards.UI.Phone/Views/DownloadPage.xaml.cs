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
using Microsoft.Phone.Controls;
using FlashCards.ViewModel;

namespace FlashCards.UI.Phone.Views
{
    public partial class DownloadPage : PhoneApplicationPage
    {
        public DownloadPage()
        {
            InitializeComponent();
        }

        private const string GameModeKey = "GameModeKey";

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.Uri.ToString() == "app://external/")
            {
                this.SaveState(GameModeKey, MainViewModel.Instance.GameMode);
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            MainViewModel.Instance.GameMode = this.LoadState<GameModes>(GameModeKey);
        }
    }
}