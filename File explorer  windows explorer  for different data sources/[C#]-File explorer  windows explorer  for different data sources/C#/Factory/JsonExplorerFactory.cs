using FileExplorer.Helper;
using FileExplorer.Model;
using FileExplorer.Shell;
using System;
using System.Collections.Generic;

namespace FileExplorer.Factory
{
     class JsonExplorerFactory : ExplorerFactoryBase
    {
        public string JsonPath { get; private set; }

        public JsonExplorerFactory(string jsonPath)
        {
            if (jsonPath.IsNullOrEmpty())
            {
                throw new ArgumentNullException();
            }
            JsonPath = jsonPath;
        }

        public override void GetRootFoldersAsync(Action<IEnumerable<IFolder>> callback)
        {
            //IFolder[] roots = new IFolder[] { new JsonRootFolder( JsonPath) };
            IFolder[] roots = new IFolder[0];
            if (!callback.IsNull())
            {
                callback(roots);
            }
        }
    }
}
