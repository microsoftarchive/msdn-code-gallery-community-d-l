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
using System.Windows.Media.Animation;
using System.IO;
using FlashCards.ViewModel;

namespace FlashCards.UI
{
	/// <summary>
	/// Interaction logic for AdminHome.xaml
	/// </summary>
	public partial class GameHome : UserControl
	{
        public GameHome()
		{
			this.InitializeComponent();
		}

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditDialog editDialog = new EditDialog();
            editDialog.Show();
        }
	}
}