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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlashCards.ViewModel;
using FlashCards.UI.Common;

namespace FlashCards.UI
{
	/// <summary>
	/// Interaction logic for DeckEditView.xaml
	/// </summary>
	public partial class DeckEditView : UserControl
	{
		public DeckEditView()
		{
			this.InitializeComponent();
            this.Loaded += new RoutedEventHandler(DeckEditView_Loaded);
		}

        void DeckEditView_Loaded(object sender, RoutedEventArgs e)
        {
            if (lstCard.Items.Count > 0)
            {
                lstCard.SelectedIndex = 0;
                CardPair pair = lstCard.SelectedValue as CardPair;
                pair.IsSelected = true;
            }
            this.SizeChanged += new SizeChangedEventHandler(DecksView_SizeChanged);
        }

        void DecksView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _panel.Margin = new Thickness(e.NewSize.Width / 2.0, 0, e.NewSize.Width / 2.0, 0);
        }

        private void TapBehavior_Tap(object sender, EventArgs e)
        {
            ListBoxItem item = (ListBoxItem)HelperClass.FindVisualAncestor((DependencyObject)sender, (o) => o.GetType() == typeof(ListBoxItem));

            if (item != null)
                item.IsSelected = true;
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            CardDeck deck = DataContext as CardDeck;

            deck.SaveDeck.Execute(null);
        }

        private void SetCover_Click(object sender, RoutedEventArgs e)
        {
            CardDeck deck = DataContext as CardDeck;

            if (deck.SelectedCardPair == null || deck.SelectedCardPair.ActiveCard == null) return;

            deck.SelectedCardPair.ActiveCard.DeSelectAll();

            Visual visualCover = pairEditControl.GetActiveCardVisual();

            deck.SetCover(visualCover);

        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            AboutDialog dlg = new AboutDialog();
            dlg.Owner = App.Current.MainWindow;
            dlg.ShowDialog();
        }

        StackPanel _panel;
        private void panel_Loaded(object sender, RoutedEventArgs e)
        {
            _panel = sender as StackPanel;
        }

        private void CommandsSelectLeft_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (lstCard.SelectedIndex != 0);
        }

        private void CommandsSelectLeft_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            lstCard.SelectedIndex = Math.Max(0, lstCard.SelectedIndex - 1);
        }

        private void CommandsSelectRight_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (lstCard.SelectedIndex != lstCard.Items.Count - 1);
        }

        private void CommandsSelectRight_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            lstCard.SelectedIndex = Math.Min(lstCard.Items.Count - 1, lstCard.SelectedIndex + 1);
        }

        private void lstCard_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommandManager.InvalidateRequerySuggested();
        }
	}
}