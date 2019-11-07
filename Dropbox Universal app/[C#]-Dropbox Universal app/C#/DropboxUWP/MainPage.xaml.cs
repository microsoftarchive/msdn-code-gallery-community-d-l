using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Authentication.Web;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DropboxUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ViewModel.MainViewModel mainViewModel = new ViewModel.MainViewModel();
        ViewModel.Get_List_Files Get_List_files = new ViewModel.Get_List_Files();
        string clienId = "your clientid";
        public MainPage()
        {
            this.InitializeComponent();
            Login();
        }

        private async void Login()
        {
            if (clienId != "your clientid")
            {
                WebAuthenticationResult webResult = await mainViewModel.AuthorizeWithDropbox(clienId);
                mainViewModel.Get_Token(webResult, txtAccessToken);
                await Task.Delay(10);
            }
            else
            {
                var dialog = new MessageDialog("Your client Id got null, please put it in");
                await dialog.ShowAsync();
            }
           
        }

        private void pivContent_LayoutUpdated(object sender, object e)
        {
            lstFiles.Width = pivContent.ActualWidth;
            
            CvasRename.Width = 400;
            CvasRename.Height = 200;
            CvasCreateNewFolder.Width = 400;
            CvasCreateNewFolder.Height = 200;
        }

        private async void Files_Tapped(object sender, TappedRoutedEventArgs e)
        {
            lstFiles.ItemsSource = null;
            lstFiles.ItemsSource = await Get_List_files.List_Root_Folder("",txtAccessToken.Text);
        }

        public async Task<ImageSource> ConvertToImage(byte[] imageBuffer)
        {
            ImageSource imgSource = null;
            using (MemoryStream stream = new MemoryStream(imageBuffer))
            {
               
                var ras = stream.AsRandomAccessStream();
                BitmapImage t = new BitmapImage();
                await t.SetSourceAsync(ras);
                imgSource = t;
            }
            return imgSource;
        }
        
        string path = "";
        string file = "";
        string type = "";
        private async void lstFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstFiles.SelectedIndex!=-1)
            {
                commandBar.Visibility = Visibility.Visible;
                //var items = ((GridView)sender).SelectedItem as ViewModel.Get_List_Files.RootObject;
                var items = lstFiles.SelectedItem as ViewModel.Get_List_Files.RootObject;
                if (items.type == "file")
                {
                    type = "file";
                    //Get_File(items.thumbail, items.name, items.modified + "-" + items.size);
                    
                    string[] split_type = items.name.Split('.');
                    if(split_type[1]=="jpg"||split_type[1]=="png")
                    {
                        pivContent.SelectedIndex = 1;
                        var bufferofimage = await mainViewModel.GetThumbail(items.pathlower, txtAccessToken.Text);
                        thumbailforimage.Source = await ConvertToImage(bufferofimage);
                        path = "";
                        file = items.pathlower;
                    }
                    else
                    {
                        path = "";
                        file = items.pathlower;// Removing this file with this name
                    }

                }
                else if (items.type == "folder")
                {
                    type = "folder";
                    lstFiles.ItemsSource = null;
                    lstFiles.ItemsSource = await Get_List_files.List_Root_Folder(items.pathlower, txtAccessToken.Text);
                    path = items.pathlower;
                    //file = items.pathlower;// Removing this file with this name
                }
            }
            
        }

       

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            pivContent.SelectedIndex = 0;
        }

       

        private void Delete_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mainViewModel.Remove(txtAccessToken.Text, file);
        }

        private void NewFolder_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CvasCreateNewFolder.Visibility = Visibility.Visible;
            CvasRename.Visibility = Visibility.Collapsed;
            

        }

        private async void Created_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mainViewModel.CreateANewFolder(txtAccessToken.Text, path + "/" + tbcreatefolder.Text);
            CvasCreateNewFolder.Visibility = Visibility.Collapsed;
            CvasRename.Visibility = Visibility.Collapsed;
            lstFiles.ItemsSource = null;
            lstFiles.ItemsSource = await Get_List_files.List_Root_Folder(path, txtAccessToken.Text);
        }

        private void Downloaded_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (type == "file")
            {
                mainViewModel.Download(txtAccessToken.Text, file);
            }
            else
                return;
            
        }
    }
}
