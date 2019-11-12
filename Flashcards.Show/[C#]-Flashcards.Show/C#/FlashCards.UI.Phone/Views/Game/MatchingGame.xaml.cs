using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FlashCards.UI.Controls;
using System.Windows.Media.Animation;
using FlashCards.ViewModel;

namespace FlashCards.UI
{
	/// <summary>
	/// Interaction logic for DeckView.xaml
	/// </summary>
	public partial class MatchingGame : UserControl
	{
        public MatchingGame()
        {
            this.InitializeComponent();

            Loaded += new RoutedEventHandler(MatchingGame_Loaded);
        }

        void MatchingGame_Loaded(object sender, RoutedEventArgs e)
        {
            MatchingGameViewModel game = this.DataContext as MatchingGameViewModel;
            game.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(game_PropertyChanged);

            if (game.SelectedDeck.Count <= 8)
                GameViewbox.MaxHeight = 500.0;
        }

        private Storyboard sb;

        void game_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsFinished")
            {
                if (((MatchingGameViewModel)sender).IsFinished)
                {
                    sb = this.Resources["FireWorksAnimation"] as Storyboard;
                    sb.Begin();
                }
                else
                {
                    sb = this.Resources["StopFireWorksAnimation"] as Storyboard;
                    sb.Begin();
                }
            }
        }
	}
}
