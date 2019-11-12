using Dropbox.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropboxUWP.ViewModel
{
    public class Get_List_Files
    {
        MainViewModel mainViewModel = new MainViewModel();
        public class RootObject
        {
            public string name { get; set; }
            public string size { get; set; }
            public string thumbail { get; set; }
            public string modified { get; set; }
            public string pathlower { get; set; }
            public string type { get; set; }
        }
        public async Task<List<RootObject>> List_Root_Folder(string path,string Token)
        {
            List<RootObject> arrays = new List<RootObject>();

            using (var dbx = new DropboxClient(Token))
            {
                var list = await dbx.Files.ListFolderAsync(path);
                foreach (var item in list.Entries)
                {
                    RootObject root = new RootObject();
                    string[] split = item.Name.Split('.');



                    if (item.IsFile == true)
                    {
                        root.type = "file";
                        root.thumbail = mainViewModel.Get_Target(split[1]);
                        if (item.Name != null)
                        {
                            root.name = item.Name;
                        }
                        else
                        {
                            root.name = "Unkown";
                        }

                        if (item.PathLower != null)
                        {
                            root.pathlower = item.PathLower;
                        }
                        else
                        {
                            root.pathlower = "Unkown";
                        }

                        if (item.AsFile.Size.ToString() != null)
                        {
                            root.size = mainViewModel.Get_Size(item.AsFile.Size);
                        }
                        else
                            root.size = "-----------";

                        if (item.AsFile.ClientModified != null)
                        {
                            root.modified = item.AsFile.ClientModified.Month + "/" + item.AsFile.ClientModified.Day + "/" + item.AsFile.ClientModified.Year;
                        }
                        else
                            root.modified = "0/0/0";
                    }
                    else if (item.IsFolder == true)
                    {
                        root.type = "folder";
                        root.thumbail = mainViewModel.Get_Target("folder");
                        if (item.Name != null)
                        {
                            root.name = item.Name;
                        }
                        else
                        {
                            root.name = "Unkown";
                        }

                        if (item.PathLower != null)
                        {
                            root.pathlower = item.PathLower;
                        }
                        else
                        {
                            root.pathlower = "Unkown";
                        }
                        root.size = "-----------";
                    }



                    arrays.Add(root);
                }
            }
            return arrays;
        }
    }
}
