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
using System.Windows.Media.Animation;
using FlashCards.ViewModel;

namespace FlashCards.UI
{
	/// <summary>
	/// Interaction logic for CardView.xaml
	/// </summary>
	public partial class CardPairEdit : UserControl
	{
		public CardPairEdit()
		{
			this.InitializeComponent();

            DataContextChanged += new DependencyPropertyChangedEventHandler(CardPairEdit_DataContextChanged);

            Loaded += new RoutedEventHandler(CardPairEdit_Loaded);
		}

        void CardPairEdit_Loaded(object sender, RoutedEventArgs e)
        {
            //rightCardEditView.MouseDown += new MouseButtonEventHandler(rightCardEditView_MouseDoubleClick);
            //leftCardEditView.MouseDown += new MouseButtonEventHandler(leftCardEditView_MouseDoubleClick);
        }

        void leftCardEditView_Click(object sender, EventArgs e)
        {
            LeftCardActivate();
        }


        void rightCardEditView_Click(object sender, EventArgs e)
        {
            RightCardActivate();
        }

        private void LeftCardActivate()
        {
            CardPair pair = ((CardPair)this.DataContext);

            if (pair.ActiveCard != pair.Card1)
            {
                Storyboard sb = this.Resources["LeftCardActivation"] as Storyboard;
                sb.Begin(this);
                pair.ActiveCard = pair.Card1;
            }

            Keyboard.Focus(leftCardEditView);
        }

        private void RightCardActivate()
        {
            CardPair pair = ((CardPair)this.DataContext);

            if (pair.ActiveCard != pair.Card2)
            {
                Storyboard sb = this.Resources["RightCardActivation"] as Storyboard;
                sb.Begin(this);
                pair.ActiveCard = pair.Card2;
            }

            Keyboard.Focus(rightCardEditView);
        }

        void CardPairEdit_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Storyboard sb = this.Resources["OnLoaded1"] as Storyboard;
            sb.Begin(this);
        }

        void sb_Completed(object sender, EventArgs e)
        {
            CardPair pair = ((CardPair)this.DataContext);

            if(pair ==  null) return;

            if (pair.ActiveCard == pair.Card2)
            {
                Storyboard sb = this.Resources["RightCardActivation"] as Storyboard;
                sb.Begin(this);
            }

            if (pair.ActiveCard == pair.Card1)
            {
                Storyboard sb = this.Resources["LeftCardActivation"] as Storyboard;
                sb.Begin(this);
            }
        }


        internal Visual GetActiveCardVisual()
        {
            CardPair pair = ((CardPair)this.DataContext);

            if (rightCardEditView.DataContext == pair.ActiveCard)
            {
                return (Visual)rightCardEditView.ScatterView;
            }
            else
            {
                return (Visual)leftCardEditView.ScatterView;
            }
        }
    }
}