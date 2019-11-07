using FileExplorer.Helper;
using FileExplorer.Model;
using FileExplorer.Shell;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FileExplorer.Factory
{
    class LocalExplorerFactory : ExplorerFactoryBase
    {
        public const string ComputerParseName = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
        public static DataSourceShell GetPCRootShellItem()
        {
            DataSourceShell pcShell = GetShellItem(ComputerParseName);
            return pcShell;
        }

        public override void GetRootFoldersAsync(Action<IEnumerable<IFolder>> callback)
        {
            ObservableCollection<IFolder> roots = new ObservableCollection<IFolder>();

            LocalRootFolder pcFolder = new LocalRootFolder();
            roots.Add(pcFolder);

            IList<string> personPaths = new List<string>() 
            { 
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            LocalVirtualFolder personFolder = null;
            foreach (var path in personPaths)
            {
                DataSourceShell item = GetShellItem(path);
                if (!item.IsNull())
                {
                    using (item)
                    {
                        personFolder = new LocalVirtualFolder(item);
                        roots.Add(personFolder);
                    }
                    break;
                }
            }

            if (!personFolder.IsNull())
            {
                pcFolder.GetItemAsync(personFolder.FullPath, (item) =>
                {
                    if (!item.IsNull() && (item is IFolder))
                    {
                        personFolder.RealFolder = item as IFolder;
                        personFolder.IsExpanded = true;
                    }
                });
            }

            if (!callback.IsNull())
            {
                callback(roots);
            }
        }
    }
}
