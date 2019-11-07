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
using FlashCards.UI.Common;

namespace FlashCards.UI
{
	/// <summary>
	/// Interaction logic for DeckView.xaml
	/// </summary>
	public partial class LearningGame : UserControl
	{
        public LearningGame()
        {
            this.InitializeComponent();

            DataContextChangedHelper.AddDataContextChangedHandler(flipControl, FlipControl_DataContextChanged);
        }

        private void flipper_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //flipper.Reset();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AboutDialog dlg = new AboutDialog();
            dlg.Show();
        }

        private void FlipControl_DataContextChanged(object sender, EventArgs e)
        {
            // reset flip
            flipControl.IsFlipped = false;
        }

        private void leftCardEditView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(flipControl);

            flipControl.FlipDirection = (p.X > flipControl.ActualWidth / 2.0) ? FlipDirection.Forwards : FlipDirection.Backwards;
            flipControl.IsFlipped = !flipControl.IsFlipped;
        }

        private void rightCardEditView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(flipControl);

            flipControl.FlipDirection = (p.X < flipControl.ActualWidth / 2.0) ? FlipDirection.Forwards : FlipDirection.Backwards;
            flipControl.IsFlipped = !flipControl.IsFlipped;
        }

	}
}
