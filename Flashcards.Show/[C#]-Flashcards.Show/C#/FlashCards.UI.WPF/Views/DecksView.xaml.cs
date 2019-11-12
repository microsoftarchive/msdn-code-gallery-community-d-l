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
using System.Linq;
using FlashCards.ViewModel;

namespace FlashCards.UI
{
	/// <summary>
	/// Interaction logic for DecksView.xaml
	/// </summary>
	public partial class DecksView : UserControl
	{
        StackPanel _panel;
		public DecksView()
		{
			this.InitializeComponent();

            Loaded += new RoutedEventHandler(DecksView_Loaded);
        }

        void DecksView_Loaded(object sender, RoutedEventArgs e)
        {
            CardDeck cardDeck = null;

            if (!string.IsNullOrEmpty(MainViewModel.Instance.SelectedZipPath))
            {
                // find CardDeck using SelectedZipPath
                cardDeck = (from x in lstDecks.Items.OfType<CardDeck>()
                            where x.ZipPath == MainViewModel.Instance.SelectedZipPath
                            select x).SingleOrDefault();
            }

            if (cardDeck != null)
            {
                // mark CardDeck as selected
                cardDeck.IsSelected = true;
                lstDecks.SelectedItem = cardDeck;
            }
            else
            {
                if (MainViewModel.Instance.SelectedZipPath != string.Empty)
                {
                    Taskbar.RemoveEntryFromJumpList(MainViewModel.Instance.SelectedZipPath);
                }

                // selected middle item
                lstDecks.SelectedIndex = lstDecks.Items.Count / 2;
                CardDeck deck = lstDecks.SelectedValue as CardDeck;
                if (deck != null)
                {
                    deck.IsSelected = true;
                }
            }

            this.SizeChanged += new SizeChangedEventHandler(DecksView_SizeChanged);
        }

        void DecksView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _panel.Margin = new Thickness(e.NewSize.Width / 2.0, 0, e.NewSize.Width / 2.0,0);
        }

        private void TapBehavior_Tap(object sender, EventArgs e)
        {
            ListBoxItem item = (ListBoxItem)HelperClass.FindVisualAncestor((DependencyObject)sender, (o) => o.GetType() == typeof(ListBoxItem));

            if (item != null)
                item.IsSelected = true;
        }

        private void TapBehavior_DoubleTap(object sender, IdentityMine.Windows.SimpleMultitouch.TapEventArgs e)
        {
            if (MainViewModel.Instance.IsAdmin)
            {
                FrameworkElement elem = sender as FrameworkElement;

                if (elem != null && elem.DataContext != null)
                {
                    ((CardDeck)elem.DataContext).EditDeck.Execute(null);
                }
            }
        }

        private void panel_Loaded(object sender, RoutedEventArgs e)
        {
            _panel = sender as StackPanel;
        }

        private void CommandsSelectLeft_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (lstDecks.SelectedIndex != 0);
        }

        private void CommandsSelectLeft_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            lstDecks.SelectedIndex = Math.Max(0, lstDecks.SelectedIndex - 1);
        }

        private void CommandsSelectRight_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (lstDecks.SelectedIndex != lstDecks.Items.Count - 1);
        }

        private void CommandsSelectRight_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            lstDecks.SelectedIndex = Math.Min(lstDecks.Items.Count - 1, lstDecks.SelectedIndex + 1);
        }

        private void lstDecks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (object o in e.RemovedItems)
            {
                CardDeck cardDeck = o as CardDeck;
                if (cardDeck != null)
                {
                    cardDeck.ShareClicked -= ShareButtonClicked;
                }
            }

            foreach (object o in e.AddedItems)
            {
                CardDeck cardDeck = o as CardDeck;
                if (cardDeck != null)
                {
                    cardDeck.ShareClicked += ShareButtonClicked;
                }
            }

            CommandManager.InvalidateRequerySuggested();
        }

        private void ShareButtonClicked(object sender, EventArgs e)
        {
            ShareDialog shareDialog = new ShareDialog();

            ShareViewModel shareViewModel = new ShareViewModel(sender as CardDeck);
            shareViewModel.ErrorOccured +=
                (s, args) => 
                {
                    MessageBox.Show(args.GetException().Message);
                    shareViewModel.CloseForm.Execute(null);
                };

            shareDialog.DataContext = shareViewModel;
            shareDialog.Owner = App.Current.MainWindow;
            shareDialog.ShowDialog();
        }
    }
}