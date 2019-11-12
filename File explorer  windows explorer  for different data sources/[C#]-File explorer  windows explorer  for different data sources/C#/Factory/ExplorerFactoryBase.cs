using FileExplorer.Model;
using FileExplorer.Shell;
using System;
using System.Collections.Generic;

namespace FileExplorer.Factory
{
     abstract class ExplorerFactoryBase
    {
        public static DataSourceShell GetShellItem(string parseNames)
        {
            DataSourceShell result = null;

            using (DataSourceShell rootShell = new DataSourceShell())
            {
                List<DataSourceShell> rootChildren = rootShell.GetSubItems();
                foreach (var item in rootChildren)
                {
                    if (parseNames.Contains(item.ParsingName))
                    {
                        result = item;
                    }
                    else
                    {
                        item.Dispose();
                    }
                }
            }
            return result;
        }

        public abstract void GetRootFoldersAsync(Action<IEnumerable<IFolder>> callback);
    }
}
