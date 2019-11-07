    using FileExplorer.Factory;
using FileExplorer.Helper;
using FileExplorer.Model;
using FileExplorer.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace FileExplorer
{
    /// <summary>
    /// Interaction logic for UCFileExplorer.xaml
    /// </summary>
    public partial class UCFileExplorer : UserControl
    {
        #region DP

        /// <summary>
        ///Is Search enabled
        /// </summary>
        public static readonly DependencyProperty IsSearchEnabledProperty =
            DependencyProperty.Register("IsSearchEnabled", typeof(bool), typeof(UCFileExplorer));

        public static void SetIsSearchEnabled(DependencyObject element, bool value)
        {
            if (element == null)
                return;
            element.SetValue(IsSearchEnabledProperty, value);
        }

        public static bool GetIsSearchEnabled(DependencyObject element)
        {
            if (element == null)
                return false;
            return (bool)element.GetValue(IsSearchEnabledProperty);
        }

        #endregion

        private FileExplorerViewModel viewModel = null;
        public FileExplorerViewModel ViewModel
        {
            get
            {
                if (viewModel.IsNull())
                {
                    viewModel = new FileExplorerViewModel();
                    viewModel.LoadLocalExplorer();
                }
                return viewModel;
            }
        }

        public UCFileExplorer()
        {
            InitializeComponent();
            this.DataContext = this.ViewModel;
            this.ucContent.ItemClicked += ucContent_ItemClicked;
        }

        void ucContent_ItemClicked(object sender, ContentEventArgs<Model.IFile> e)
        {
            IFile item = e.Content;
            if (item.IsNull())
            {
                return;
            }

            if (item is IFolder)
            {
                IFolder folder = item as IFolder;
                folder.IsExpanded = true;
                folder.IsSelected = true;
                this.ViewModel.SetCurrentFolder(folder);
            }
            else if (item is LocalFile)
            {
                if (File.Exists(item.FullPath))
                {
                    try
                    {
                        Process.Start(item.FullPath);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Debug("Exception:", ex);
                    }
                }
            }
        }

        #region Tree test code

        void btnGet_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in this.ViewModel.GetCheckedPaths())
            {
                LogHelper.DebugFormat("===> get checked path:{0}", item);
            }
        }

        void btnSet_Click(object sender, RoutedEventArgs e)
        {
            this.ViewModel.SetCheckedPaths(new List<string>() {                
                @"C:\Users\nick\AndroidStudioProjects\MyApplication",
                @"C:\Users\nick\Music\吉克隽逸 - 即刻出发.mp3",
                @"C:\Users\nick\Music\王菲 - 容易受伤的女人.mp3",
                @"D:\Images\0\2.jpg",                 
                @"D:\GitHub\Self\WP-photo-zoom-and-rotation\PhotoZoom",
                @"E:\SDK\WindowsPhonePowerTools.application",
                @"D:\Images\A\B.JPG",
                @"D:\Images\A\c.MP3",
                @"D:\pic\1000 jpg pics\[0002].jpg",
                @"D:\pic\1000 jpg pics\[0002].PNG",
                @"\yFZcGp-Q9G5vq9XTN5DhZA",
                @"\JqRBfwQMrMsZwWZCIdkjUg\NvWxIEN187CMY2nd0vpS6A\AWBkUzxWWuJuWm3ayRChug\iAiEoTe14634ZLmy-wvfQg\vWkvIW9Vv7FcMIWfPisCSQ",
                @"\tPTxDqSjlaJqwTPD5boblw",
            });
        }

        void btnSource_Click(object sender, RoutedEventArgs e)
        {
            string sourceName = (sender as Button).Content.ToString();
            switch (sourceName)
            {
                case "Local":
                    this.ViewModel.InitialExplorer(new LocalExplorerFactory());
                    break;
                case "Cloud":
                    this.ViewModel.InitialExplorer(new CloudExplorerFactory());
                    break;
                case "Json":
                    JsonExplorerFactory jsonFactory = new JsonExplorerFactory(@"D:\tt\20150317_152749_79a4cf7d-ac78-4120-b6f9-e76e9877921d.nbix");
                    this.ViewModel.InitialExplorer(jsonFactory);
                    break;
                case "CDRom":
                    CDRomExplorerFactory factory = new CDRomExplorerFactory(@"I:\20150228_094851_b5ee3920-f96d-4ff8-93d8-6671bdf949df.nbi");
                    this.ViewModel.InitialExplorer(factory);
                    break;

                default:
                    break;
            }
        }

        #endregion

    }
}
