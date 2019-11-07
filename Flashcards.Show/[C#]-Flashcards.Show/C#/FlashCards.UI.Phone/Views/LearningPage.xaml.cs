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
    public partial class LearningPage : PhoneApplicationPage
    {
        public LearningPage()
        {
            InitializeComponent();
        }

        private const string IsolatedStorageFileNameKey = "IsolatedStorageFileNameKey";
        private const string GameModeKey = "GameModeKey";

        private const string LearningGameCardPairIndexKey = "LearningGameCardPairIndexKey";

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.Uri.ToString() == "app://external/")
            {
                this.SaveState(IsolatedStorageFileNameKey, MainViewModel.Instance.IsolatedStorageFileName);
                this.SaveState(GameModeKey, MainViewModel.Instance.GameMode);

                // save game specific state
                LearningGameViewModel learningGame = MainViewModel.Instance.CurrentView as LearningGameViewModel;
                this.SaveState(LearningGameCardPairIndexKey, learningGame.Index);
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

            LearningGameViewModel game = new LearningGameViewModel(MainViewModel.Instance.Decks.SelectedDeck);

            if (!string.IsNullOrEmpty(isolatedStorageFileName))
            {
                game.Index = this.LoadState<int>(LearningGameCardPairIndexKey);
                game.SelectedCardPair = MainViewModel.Instance.Decks.SelectedDeck.Collection[game.Index];
            }

            MainViewModel.Instance.GameMode = GameModes.LearningGame;
            MainViewModel.Instance.CurrentView = game;
            DataContext = MainViewModel.Instance.CurrentView;
        }

        private void AppbarButtonAbout_Click(object sender, EventArgs e)
        {
            App.ShowAboutDialog();
        }

        private void AppbarButtonReset_Click(object sender, EventArgs e)
        {
            LearningGameViewModel learningGame = this.DataContext as LearningGameViewModel;
            learningGame.ResetCards.Execute(null);
        }
    }
}