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
using System.Threading;

namespace FlashCards.UI.Phone.Views
{
    public partial class MatchingPage : PhoneApplicationPage
    {
        public MatchingPage()
        {
            InitializeComponent();
        }

        private const string IsolatedStorageFileNameKey = "IsolatedStorageFileNameKey";
        private const string GameModeKey = "GameModeKey";

        private const string CardsOrderKey = "CardsOrderKey";
        private const string CardsUseDuplicateKey = "CardsUseDuplicateKey";
        private const string CardsIsMatchedKey = "CardsIsMatchedKey";
        private const string CardsIsSelectedKey = "CardsIsSelectedKey";

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.Uri.ToString() == "app://external/")
            {
                this.SaveState(IsolatedStorageFileNameKey, MainViewModel.Instance.IsolatedStorageFileName);
                this.SaveState(GameModeKey, MainViewModel.Instance.GameMode);

                // save game specific state
                MatchingGameViewModel matchingGame = MainViewModel.Instance.CurrentView as MatchingGameViewModel;
                
                int[] cardsOrder;
                bool[] cardsUseDuplicate;
                bool[] cardsIsMatched;
                bool[] cardsIsSelected;
                matchingGame.GetGameState(out cardsOrder, out cardsUseDuplicate, out cardsIsMatched, out cardsIsSelected);

                this.SaveState(CardsOrderKey, cardsOrder);
                this.SaveState(CardsUseDuplicateKey, cardsUseDuplicate);
                this.SaveState(CardsIsMatchedKey, cardsIsMatched);
                this.SaveState(CardsIsSelectedKey, cardsIsSelected);
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            MatchingGameViewModel game;

            string isolatedStorageFileName = this.LoadState<string>(IsolatedStorageFileNameKey);
            if (!string.IsNullOrEmpty(isolatedStorageFileName))
            {
                MainViewModel.Instance.IsolatedStorageFileName = isolatedStorageFileName;
                MainViewModel.Instance.GameMode = this.LoadState<GameModes>(GameModeKey);

                int[] cardsOrder = this.LoadState<int[]>(CardsOrderKey);
                bool[] cardsUseDuplicate = this.LoadState<bool[]>(CardsUseDuplicateKey);
                bool[] cardsIsMatched = this.LoadState<bool[]>(CardsIsMatchedKey);
                bool[] cardsIsSelected = this.LoadState<bool[]>(CardsIsSelectedKey);

                // load stream from isolated storage
                MainViewModel.Instance.LoadDeckFromIsolatedStorage();

                bool isMatchingGame = MainViewModel.Instance.GameMode == GameModes.MatchingGame;
                game = new MatchingGameViewModel(MainViewModel.Instance.Decks.SelectedDeck, isMatchingGame, cardsOrder, cardsUseDuplicate, cardsIsMatched, cardsIsSelected);
            }
            else
            {
                bool isMatchingGame = MainViewModel.Instance.GameMode == GameModes.MatchingGame;
                game = new MatchingGameViewModel(MainViewModel.Instance.Decks.SelectedDeck, isMatchingGame);
            }

            MainViewModel.Instance.CurrentView = game;
            DataContext = MainViewModel.Instance.CurrentView;
        }

        private void AppbarButtonReset_Click(object sender, EventArgs e)
        {
            MatchingGameViewModel matchingGame = this.DataContext as MatchingGameViewModel;
            matchingGame.ResetCards.Execute(null);
        }

        private void AppbarButtonAbout_Click(object sender, EventArgs e)
        {
            App.ShowAboutDialog();
        }
    }
}