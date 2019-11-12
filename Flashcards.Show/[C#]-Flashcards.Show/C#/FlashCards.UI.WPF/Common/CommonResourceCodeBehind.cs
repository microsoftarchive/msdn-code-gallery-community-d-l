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
using FlashCards.ViewModel;

namespace FlashCards.UI
{
    public partial class ResourceCodeGame : ResourceDictionary
    {

        void MediaLoaded(object sender, RoutedEventArgs e)
        {
            MediaElement elem = sender as MediaElement;
            VideoDecal decal = elem.DataContext as VideoDecal;
            elem.Position = decal.Position;
            elem.Play();
            elem.Pause();
        }
    }

    public partial class ResourceCode : ResourceDictionary
    {

        void MediaLoaded(object sender, RoutedEventArgs e)
        {
            MediaElement elem = sender as MediaElement;
            VideoDecal decal = elem.DataContext as VideoDecal;
            elem.Position = decal.Position;
            elem.Play();
            elem.Pause();
           
        }

        void Decal_Select_Click(object sender, RoutedEventArgs e)
        {
            ((Decal)((FrameworkElement)sender).DataContext).IsSelected = !((Decal)((FrameworkElement)sender).DataContext).IsSelected;
        }

        void Decal_DeSelect_Click(object sender, RoutedEventArgs e)
        {
            ((Decal)((FrameworkElement)sender).DataContext).IsSelected = false;
        }


        void VisibilityChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                if (!((TextBox)sender).IsFocused)
                {
                    ((TextBox)sender).SelectAll();
                    ((TextBox)sender).Focus();
                }
            }
        }
    }
}