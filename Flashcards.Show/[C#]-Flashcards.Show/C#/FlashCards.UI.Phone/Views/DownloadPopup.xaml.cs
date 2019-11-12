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
using FlashCards.ViewModel;
using System.Collections.ObjectModel;

namespace FlashCards.UI.Phone.Views
{
    public partial class DownloadPopup : UserControl
    {
        public DownloadPopup()
        {
            InitializeComponent();

            DataContext = MainViewModel.Instance;
            MainViewModel.Instance.LoadSavedDecks();
        }

        private void GetDeckButton_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.Instance.StartLoading();
            
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ImageItem imageItem = (sender as FrameworkElement).DataContext as ImageItem;
            MainViewModel.Instance.LoadDeckFromIsolatedStorage(imageItem.FileName);
            MainViewModel.Instance.GameMode = GameModes.GameSelect;
        }

        private void DeleteImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ImageItem imageItem = (sender as FrameworkElement).DataContext as ImageItem;
            MainViewModel.Instance.RemoveFromIsolatedStorage(imageItem.FileName);
            MainViewModel.Instance.Images.Remove(imageItem);
        }

        /// <summary>
        /// Get a preset demo deck from storage - use hard coded values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetDemoDeckButton_Click(object sender, RoutedEventArgs e)
        {
            // Use Yochayk prefixed demo deck.
            MainViewModel.Instance.SenderName = "Demo";
            MainViewModel.Instance.Password = "f5f2vu";

            MainViewModel.Instance.StartLoading();
        }
    }
}
