using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Xml.Serialization;
using FlashCards.Commands;
using System.Windows;
using System;
#if WINDOWS_PHONE

#elif SILVERLIGHT
using System.Windows.Browser;
#endif

namespace FlashCards.ViewModel
{
    public class InfoLinkDecal : Decal
    {
        public InfoLinkDecal()
        {
            MetaData = new InfoLinkMetaData() { Source = "http://" };
            Stretch = System.Windows.Media.Stretch.Uniform;
            Size = 1;
            CanResize = false;
            Stretch = System.Windows.Media.Stretch.None;
            Center = new System.Windows.Point(1, 1);
            PinPoint = new System.Windows.Point(1, 1);
            CanMove = false;

            OpenUrl = new DelegateCommand(() =>
            {
                if (!MetaData.Source.StartsWith("http://"))
                {
                    MetaData.Source = "http://" + MetaData.Source;
                }
#if WINDOWS_PHONE
                Microsoft.Phone.Controls.PhoneApplicationFrame frame = Application.Current.RootVisual as Microsoft.Phone.Controls.PhoneApplicationFrame;
                frame.Navigate(new Uri(MetaData.Source));
#elif SILVERLIGHT

                HtmlPage.Window.Navigate(new Uri(MetaData.Source), "_blank");
#else
                Process.Start(MetaData.Source);
#endif
            }, CanOpenUrl);
        }

        public bool CanOpenUrl()
        {
#if !SILVERLIGHT
            string pattern = @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(MetaData.Source);
#else
            return true;
#endif
        }

        [XmlIgnore]
        public ICommand OpenUrl { get; private set; }
    }
}
