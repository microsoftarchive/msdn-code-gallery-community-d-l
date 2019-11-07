using Dropbox.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Security.Authentication.Web;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace DropboxUWP.ViewModel
{
    public class MainViewModel
    {
        public string Get_Target(string name)
        {
            string icon = "";
            switch (name)
            {
                case "rar":
                    icon = "/Assets/Archive-50.png";
                    break;
                case "zip":
                    icon = "/Assets/Archive-50.png";
                    break;
                case "pdf":
                    icon = "/Assets/PDF-50.png";
                    break;
                case "docx":
                    icon = "/Assets/MS Word-50.png";
                    break;
                case "xlsx":
                    icon = "/Assets/MS Excel-50.png";
                    break;
                case "folder":
                    icon = "/Assets/Folder-48.png";
                    break;
                case "mp3":
                    icon = "/Assets/MP3-48.png";
                    break;
                case "mp4":
                    icon = "/Assets/CD-48.png";
                    break;
                case "dll":
                    icon = "/Assets/DLL-48.png";
                    break;
                case "exe":
                    icon = "/Assets/EXE-50.png";
                    break;
                case "png":
                    icon = "/Assets/Image File-50.png";
                    break;

                case "jpg":
                    icon = "/Assets/Image File-50.png";
                    break;
                default:
                    icon = "/Assets/File-50.png";
                    break;
            }
            return icon;
        }
        

        public string Get_Size(ulong count)
        {
            string result = "";
            float size = count / 1024;
            if(size<1024)
            {
                result = string.Format("{0,00}",size) +" KB";
            }
            else if(size>1024)
            {
                result = string.Format("{0:0.0}", size / 1024) + " MB";
                
            }
            else if((size/1024)/1024>1024)
            {
                result = string.Format("{0:0.0}", (size / 1024) / 1024) + " GB";
            }
            return result;
        }
        
     
        public async Task<WebAuthenticationResult> AuthorizeWithDropbox(string clientid)
        {
            var dropboxUrl = "https://www.dropbox.com/1/oauth2/authorize?client_id=" + Uri.EscapeDataString(clientid) + "&response_type=token&redirect_uri=" + Uri.EscapeDataString("https://boxDrive.com/callback") + "&state=xyzbc";
            var endUri = new Uri("https://boxDrive.com/callback");
            var startUri = new Uri(dropboxUrl);

            WebAuthenticationResult WebAuthenresult = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, startUri, endUri);
            return WebAuthenresult;
        }

        public async void Get_Token(WebAuthenticationResult result,TextBlock txtToken)
        {
            
            if(result.ResponseStatus==WebAuthenticationStatus.Success)
            {
                WwwFormUrlDecoder decoder = new WwwFormUrlDecoder(result.ResponseData);
                txtToken.Text = decoder[0].Value;
            }
            else if(result.ResponseStatus==WebAuthenticationStatus.ErrorHttp || result.ResponseStatus==WebAuthenticationStatus.UserCancel)
            {
                var dialog = new MessageDialog(result.ResponseStatus.ToString());
                await dialog.ShowAsync();
            }
        }

        public async Task<byte[]> GetThumbail(string path, string token)
        {
            byte[] getbyte;
            using (var dbx = new DropboxClient(token))
            {
                using (var t = await dbx.Files.GetThumbnailAsync(path, null, Dropbox.Api.Files.ThumbnailSize.W1024h768.Instance))
                {
                    getbyte = await t.GetContentAsByteArrayAsync();
                }
                
            }
            return getbyte;
        }


        public async void CreateANewFolder(string token,string path)
        {
            using (var dbx = new DropboxClient(token))
            {
                var created = await dbx.Files.CreateFolderAsync(path);
                //var endCreated = await dbx.Files.EndCreateFolder();
            }
        }

        public async void RenameFile(string token,string path)
        {
            using (var dbx = new DropboxClient(token))
            {
                var rename = await dbx.Files.DeleteAsync(path);
            }
        }

        public async void Remove(string token, string path)
        {
            using (var dbx = new DropboxClient(token))
            {
                var remove = await dbx.Files.DeleteAsync(path);
            }
        }

        public async void Download(string token, string path)
        {
            /*
            The Dropbox.NET SDK doesn't currently offer a way to get the progress of a download, but I'll be sure to pass this along as a feature request. 

            It also doesn't offer a way to download folders in bulk, so you'll need to iterate through to download each desired file.

            I dont know where it was saved!!!!
            */
          
            using (var dbx = new DropboxClient(token))
            {
                var download = await dbx.Files.DownloadAsync(path);
            }
        }
    }
}
