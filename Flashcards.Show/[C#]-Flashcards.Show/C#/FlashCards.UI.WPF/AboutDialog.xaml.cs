using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Diagnostics;

namespace FlashCards.UI
{

    public partial class AboutDialog : Window
    {
        public AboutDialog()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo(((Hyperlink)sender).NavigateUri.ToString()));
            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Canvas_MouseLeftButtonUp_IdentityMine(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo("http://www.identitymine.com/flashcards/"));
        }

        private void Canvas_MouseLeftButtonUp_Sela(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo("http://www.selagroup.com/"));
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo("http://www.microsoft.com/"));
        }

    

    }
}
