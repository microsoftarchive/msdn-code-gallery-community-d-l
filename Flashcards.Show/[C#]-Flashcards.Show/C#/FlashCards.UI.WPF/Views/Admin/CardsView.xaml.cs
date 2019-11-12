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

namespace FlashCardUI
{
	/// <summary>
	/// Interaction logic for CardDeckView.xaml
	/// </summary>
	public partial class CardsView : UserControl
	{
		public CardsView()
		{
			this.InitializeComponent();
		}

        private void TapBehavior_Tap(object sender, EventArgs e)
        {
            ListBoxItem item = (ListBoxItem)HelperClass.FindVisualAncestor((DependencyObject)sender, (o) => o.GetType() == typeof(ListBoxItem));

            if (item != null)
                item.IsSelected = true;
        }
	}
}