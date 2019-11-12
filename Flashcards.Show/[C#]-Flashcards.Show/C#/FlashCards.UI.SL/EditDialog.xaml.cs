using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser;

namespace FlashCards.UI
{
    public partial class EditDialog : ChildWindow
    {
        private const string FlashCardsClickOnceUrl = "http://flashcardsshowclient.blob.core.windows.net/flashcards/WPFClient/publish.htm";

        public EditDialog()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            HtmlPage.Window.Navigate(new Uri(FlashCardsClickOnceUrl), "_blank");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

