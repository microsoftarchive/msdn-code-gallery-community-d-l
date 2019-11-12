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
using FlashCards.UI.Controls;
using IdentityMine.Windows.SimpleMultitouch;
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
            Emitter.StylusDown += new StylusDownEventHandler(Emitter_StylusDown);
            Emitter.StylusUp += new StylusEventHandler(Emitter_StylusUp);
            Emitter.StylusMove += new StylusEventHandler(Emitter_StylusMove);
            Emitter.StylusLeave += new StylusEventHandler(Emitter_StylusUp);

            Emitter.MouseDown += new MouseButtonEventHandler(Emitter_MouseDown);
            Emitter.MouseUp += new MouseButtonEventHandler(Emitter_MouseUp);
            Emitter.MouseMove += new MouseEventHandler(Emitter_MouseMove);
            Emitter.MouseLeave += new MouseEventHandler(LayoutRoot_MouseLeave);

            Loaded += new RoutedEventHandler(MatchingGame_Loaded);
        }

        void MatchingGame_Loaded(object sender, RoutedEventArgs e)
        {
            MatchingGameViewModel game = this.DataContext as MatchingGameViewModel;
            game.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(game_PropertyChanged);

            if (game.SelectedDeck.Count <= 8)
                GameViewbox.MaxHeight = 500.0;
        }

        Storyboard sb;

        void game_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsFinished")
            {
                if (((MatchingGameViewModel)sender).IsFinished)
                {
                    sb = this.TryFindResource("FireWorksAnimation") as Storyboard;
                    sb.Begin(this);
                }
                else
                {
                    sb = this.TryFindResource("StopFireWorksAnimation") as Storyboard;
                    sb.Begin(this);
                }
            }
            
        }

        void LayoutRoot_MouseLeave(object sender, MouseEventArgs e)
        {
            Emitter.IsEmitting = false;
        }

        void Emitter_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Emitter.EmitLocation = e.GetPosition(Emitter);
            }
        }

        void Emitter_MouseUp(object sender, MouseButtonEventArgs e)
        {

            Emitter.IsEmitting = false;

        }

        void Emitter_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Emitter.EmitLocation = e.GetPosition(Emitter);
            Emitter.IsEmitting = true;
            //DoubleAnimation anim = new DoubleAnimation(0., 6, new Duration(TimeSpan.FromSeconds(1.5)));
            //Emitter.BeginAnimation(ParticleEmitter.ZoomProperty, anim);
        }

        void Emitter_StylusMove(object sender, StylusEventArgs e)
        {
            Emitter.EmitLocation = e.GetPosition(Emitter);

        }

        void Emitter_StylusUp(object sender, StylusEventArgs e)
        {
            Emitter.IsEmitting = false;

        }

        void Emitter_StylusDown(object sender, StylusDownEventArgs e)
        {
            Emitter.EmitLocation = e.GetPosition(Emitter);
            Emitter.IsEmitting = true;
        }

        private void TapBehavior_Tap(object sender, TapEventArgs e)
        {
            if (e.Device is StylusDevice)
            {
                ListBoxItem item = (ListBoxItem)HelperClass.FindVisualAncestor((DependencyObject)sender, (o) => o.GetType() == typeof(ListBoxItem));

                if (item != null)
                    item.IsSelected = !item.IsSelected;
            }
        }

        private void Flickable_HorizontalFlick(object sender, IdentityMine.Windows.SimpleMultitouch.FlickEventArgs e)
        {

            ListBoxItem item = (ListBoxItem)HelperClass.FindVisualAncestor((DependencyObject)sender, (o) => o.GetType() == typeof(ListBoxItem));

            if (item != null)
                item.IsSelected = !item.IsSelected;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AboutDialog dlg = new AboutDialog();
            dlg.Owner = App.Current.MainWindow;
            dlg.ShowDialog();
        }
	}
}
