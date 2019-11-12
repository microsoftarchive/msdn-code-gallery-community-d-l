using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using FlashCards.ViewModel;

namespace FlashCards.UI
{
    public class MediaPlayerHelper
    {

        public static bool GetIsPlay(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsPlayProperty);
        }

        public static void SetIsPlay(DependencyObject obj, bool value)
        {
            obj.SetValue(IsPlayProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsPlay.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPlayProperty =
            DependencyProperty.RegisterAttached("IsPlay", typeof(bool), typeof(MediaPlayerHelper), new UIPropertyMetadata(false,
                (s, e) =>
                {
                    MediaElement elem = s as MediaElement;
                    
                    if ((bool)e.NewValue)
                    {
                        elem.Play();
                    }
                    else
                    {
                        elem.Pause();
                        VideoDecal decal = elem.DataContext as VideoDecal;
                        decal.Position = elem.Position;
                    }

                }));


    }
}
