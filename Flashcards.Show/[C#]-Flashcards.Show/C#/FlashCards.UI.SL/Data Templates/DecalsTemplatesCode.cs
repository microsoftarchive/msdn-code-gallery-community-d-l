using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using FlashCards.ViewModel;
using System.IO;
using System.Windows.Controls.Primitives;

namespace FlashCards.UI
{
    public partial class DecalsTemplatesCode : ResourceDictionary
    {
        public DecalsTemplatesCode() 
        { 
                InitializeComponent(); 
        } 

        void MediaLoaded(object sender, RoutedEventArgs e)
        {
            MediaElement elem = sender as MediaElement;
            VideoDecal decal = elem.DataContext as VideoDecal;
            if (decal != null)
            {
                elem.SetSource(MainViewModel.Instance.GetVideo(decal.MetaData.Source));
                elem.Position = decal.Position;
                elem.Play();
                elem.Pause();

            }
        }

        void PlayVideo(object sender, RoutedEventArgs e)
        {
            ToggleButton elem = sender as ToggleButton;
            VideoControlDecal decal = elem.DataContext as VideoControlDecal;
            if (decal != null)
            {
                decal.IsPlay = !decal.IsPlay;
            }
        }

        void OpenUrl(object sender, RoutedEventArgs e)
        {
            Button elem = sender as Button;
            InfoLinkDecal decal = elem.DataContext as InfoLinkDecal;
            if (decal != null)
            {
                decal.OpenUrl.Execute(null);
            }
        }
    }
}
