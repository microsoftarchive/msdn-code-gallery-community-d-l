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
using System.Windows.Markup;
using FlashCards.ViewModel;

namespace FlashCards.UI
{
    public class DecalsTemplateSelector : ContentControl
    {
        protected override void OnContentChanged(object oldContent, object newContent)
        {
            if (newContent is ImageDecal)
            {
                ContentTemplate = Application.Current.Resources["ImageDecalKey"] as DataTemplate;
            }
            else if (newContent is TextDecal)
            {
                ContentTemplate = Application.Current.Resources["TextDecalKey"] as DataTemplate;
            }
            else if (newContent is InfoLinkDecal)
            {
                ContentTemplate = Application.Current.Resources["InfoLinkDecalKey"] as DataTemplate;
            }
            else if (newContent is VideoControlDecal)
            { 
                ContentTemplate = Application.Current.Resources["VideoControlDecalKey"] as DataTemplate;
            }
            else if (newContent is VideoDecal)
            {
                ContentTemplate = Application.Current.Resources["VideoDecalKey"] as DataTemplate;
            }
            else if (newContent is TextToSpeechDecal)
            {
                ContentTemplate = Application.Current.Resources["TextToSpeechDecalKey"] as DataTemplate;
            }
        }
    }
}
