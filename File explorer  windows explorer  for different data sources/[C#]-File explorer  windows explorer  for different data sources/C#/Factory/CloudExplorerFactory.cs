using FileExplorer.Helper;
using FileExplorer.Model;
using System;
using System.Collections.Generic;

namespace FileExplorer.Factory
{
    class CloudExplorerFactory : ExplorerFactoryBase
    {
        public override void GetRootFoldersAsync(Action<IEnumerable<IFolder>> callback)
        {
            //IFolder[] roots = new IFolder[] { new CloudRootFolder() };
            IFolder[] roots = new IFolder[0];
            if (!callback.IsNull())
            {
                callback(roots);
            }
        }
    }
}
