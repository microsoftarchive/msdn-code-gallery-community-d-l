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
using System.Windows.Resources;
using System.IO;
using System.Windows.Controls.Primitives;

namespace FlashCards.UI.Phone.Views
{
    public partial class SelectGamePage : PhoneApplicationPage
    {
        public SelectGamePage()
        {
            InitializeComponent();
        }

        private const string IsolatedStorageFileNameKey = "IsolatedStorageFileNameKey";
        private const string GameModeKey = "GameModeKey";

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.Uri.ToString() == "app://external/")
            {
                this.SaveState(IsolatedStorageFileNameKey, MainViewModel.Instance.IsolatedStorageFileName);
                this.SaveState(GameModeKey, MainViewModel.Instance.GameMode);
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            string isolatedStorageFileName = this.LoadState<string>(IsolatedStorageFileNameKey);
            if (!string.IsNullOrEmpty(isolatedStorageFileName))
            {
                MainViewModel.Instance.IsolatedStorageFileName = isolatedStorageFileName;
                MainViewModel.Instance.GameMode = this.LoadState<GameModes>(GameModeKey);

                // load stream from isolated storage
                MainViewModel.Instance.LoadDeckFromIsolatedStorage();
            }
            else
            {
            }
            
            MainViewModel.Instance.GameMode = GameModes.GameSelect;
            MainViewModel.Instance.CurrentView = MainViewModel.Instance.Decks;
            DataContext = MainViewModel.Instance.CurrentView;
        }

        private void AppbarButtonLearning_Click(object sender, EventArgs e)
        {
            MainViewModel.Instance.GameMode = GameModes.LearningGame;
        }

        private void AppbarButtonMatching_Click(object sender, EventArgs e)
        {
            MainViewModel.Instance.GameMode = GameModes.MatchingGame;
        }

        private void AppbarButtonMemory_Click(object sender, EventArgs e)
        {
            MainViewModel.Instance.GameMode = GameModes.MemoryGame;
        }

        private void AppbarButtonAbout_Click(object sender, EventArgs e)
        {
            App.ShowAboutDialog();
        }
    }
}