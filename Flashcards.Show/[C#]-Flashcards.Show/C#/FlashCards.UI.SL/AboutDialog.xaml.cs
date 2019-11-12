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
#if WINDOWS_PHONE

#elif SILVERLIGHT
using System.Windows.Browser;
#endif

namespace FlashCards.UI
{

    public partial class AboutDialog : ChildWindow
    {
        public AboutDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Canvas_MouseLeftButtonUp_IdentityMine(object sender, MouseButtonEventArgs e)
        {
            HtmlPage.Window.Navigate(new Uri("http://www.identitymine.com/flashcards/"), "_blank");
        }

        private void Canvas_MouseLeftButtonUp_Sela(object sender, MouseButtonEventArgs e)
        {
            HtmlPage.Window.Navigate(new Uri("http://www.selagroup.com/"), "_blank");
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            HtmlPage.Window.Navigate(new Uri("http://www.microsoft.com/"), "_blank");
        }
    }
}
