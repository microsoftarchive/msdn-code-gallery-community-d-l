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
using Microsoft.Phone.Controls;
using FlashCards.ViewModel;

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

        private void FlipControl_DataContextChanged(object sender, EventArgs e)
        {
            // reset flip
            flipControl.IsFlipped = false;
        }

        private void OnTap(object sender, GestureEventArgs e)
        {
            Point p = e.GetPosition(flipControl);

            if (flipControl.IsFlipped)
            {
                flipControl.FlipDirection = (p.X > flipControl.ActualWidth / 2.0) ? FlipDirection.Backwards : FlipDirection.Forwards;
            }
            else
            {
                flipControl.FlipDirection = (p.X < flipControl.ActualWidth / 2.0) ? FlipDirection.Backwards : FlipDirection.Forwards;
            }
                
            flipControl.IsFlipped = !flipControl.IsFlipped;
        }

        private const int AngleThreshold = 40;

        private void OnFlick(object sender, FlickGestureEventArgs e)
        {
            if (e.Direction == Orientation.Horizontal)
            {
                LearningGameViewModel learningGameViewModel = DataContext as LearningGameViewModel;

                if ((e.Angle > 180 - AngleThreshold) && (e.Angle < 180 + AngleThreshold))
                {
                    VisualStateManager.GoToState(this, Normal.Name, false);
                    VisualStateManager.GoToState(this, AdvanceLeft.Name, false);
                    learningGameViewModel.NextCommand.Execute(null);
                    e.Handled = true;
                }
                else if ((e.Angle < 0 + AngleThreshold) || (e.Angle > 360 - AngleThreshold))
                {
                    VisualStateManager.GoToState(this, Normal.Name, false);
                    VisualStateManager.GoToState(this, AdvanceRight.Name, false);
                    learningGameViewModel.PreviousCommand.Execute(null);
                    e.Handled = true;
                }
            }
        }
	}
}
