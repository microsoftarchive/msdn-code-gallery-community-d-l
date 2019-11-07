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

namespace FlashCards.UI
{
	/// <summary>
	/// Interaction logic for DeckView.xaml
	/// </summary>
    public partial class CardEditView : UserControl
	{
        public CardEditView()
        {
            this.InitializeComponent();

            this.PreviewMouseDown += new MouseButtonEventHandler(ScatterView_MouseDown);
            this.PreviewStylusDown += new StylusDownEventHandler(CardEditView_PreviewStylusDown);
        }

        void CardEditView_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectionCheck(e.GetPosition((UIElement)this));
        }

        void ScatterView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectionCheck(e.GetPosition((UIElement)this));
        }

        private void SelectionCheck(Point pt)
        {

            // Perform the hit test against a given portion of the visual object tree.
            HitTestResult result = VisualTreeHelper.HitTest(this, pt);

            if (result != null)
            {
                FrameworkElement elem = result.VisualHit as FrameworkElement;

                if (elem != null && !(elem.DataContext is Decal))
                {
                    Card card = DataContext as Card;

                    card.DeSelectAll();
                }
            }
        }
	}
}