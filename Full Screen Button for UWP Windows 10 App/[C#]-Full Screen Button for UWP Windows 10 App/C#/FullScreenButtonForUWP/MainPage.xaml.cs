using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FullScreenButtonForUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        double d = 0.0;
        public MainPage()
        {
            this.InitializeComponent();
            Window.Current.SizeChanged += Window_SizeChanged;
        }

        private void Window_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            if (ApplicationView.GetForCurrentView().IsFullScreenMode)
            {
                CustomTitleBar.Visibility = Visibility.Collapsed;
            }
            else
            {
                CustomTitleBar.Visibility = Visibility.Visible;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ApplicationView.GetForCurrentView().TryEnterFullScreenMode();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        { 
            CoreApplicationViewTitleBar titleBar = CoreApplication.GetCurrentView().TitleBar;
            titleBar.ExtendViewIntoTitleBar = true;
            titleBar.LayoutMetricsChanged += TitleBar_LayoutMetricsChanged;
        }

        private void TitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
        {
            GrapPanel.Height = sender.Height;
            FullScreenButton.Margin = new Thickness(0, 0, sender.SystemOverlayRightInset, 0);
            Window.Current.SetTitleBar(GrapPanel);
        }

        private void ChangeTandartButtonsColor_Click(object sender, RoutedEventArgs e)
        {
           var apptitlebar = ApplicationView.GetForCurrentView().TitleBar;
            apptitlebar.ButtonHoverBackgroundColor = Colors.Purple;
            apptitlebar.ButtonBackgroundColor = Colors.Green;
        }
    }
}
