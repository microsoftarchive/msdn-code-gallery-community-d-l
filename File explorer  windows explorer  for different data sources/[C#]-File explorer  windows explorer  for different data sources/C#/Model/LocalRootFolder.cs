using FileExplorer.Factory;
using FileExplorer.Helper;
using FileExplorer.Shell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileExplorer.Model
{
    public class LocalRootFolder : LocalFolder
    {
        DriverWatcher driverWatcher = null;

        public LocalRootFolder()
            : base(string.Empty, null)
        {
            using (DataSourceShell shellItem = LocalExplorerFactory.GetPCRootShellItem())
            {
                this.Name = shellItem.DisplayName;
                this.Icon = shellItem.Icon;
            }

            this.IsCheckVisible = false;
            this.IsExpanded = true;
            this.IsSelected = true;
            this.Parent = this;
        }

        protected override IEnumerable<IFolder> GetFolders()
        {
            if (!IsFolderLoaded)
            {
                var drivers = DriverWatcher.GetDrivers();
                var list = drivers.Select(item => new LocalDriver(item.Name, this));
                IsFolderLoaded = AddItemsByChunk(list, this.Folders, this.Items);

                driverWatcher = new DriverWatcher();
                driverWatcher.Start(drivers.Select(item => item.Name).ToList());
                driverWatcher.DriverChanged += driverWatcher_DriverChanged;
            }
            return this.Folders;
        }

        void driverWatcher_DriverChanged(List<string> drives, bool isAdd)
        {
            if (drives.IsNullOrEmpty())
            {
                return;
            }

            RunOnUIThreadAsync(() =>
            {
                if (isAdd)
                {
                    foreach (var item in drives)
                    {
                        this.Folders.Add(new LocalDriver(item, this));
                    }
                }
                else
                {
                    foreach (var item in drives)
                    {
                        var driver = this.Folders.FirstOrDefault(d => d.Name == item);
                        if (!driver.IsNull())
                        {
                            driver.Dispose();
                            this.Folders.Remove(driver);
                        }
                    }
                }
            });
        }

        protected override void OnDisposing(bool isDisposing)
        {
            base.OnDisposing(isDisposing);
            if (!driverWatcher.IsNull())
            {
                driverWatcher.DriverChanged -= driverWatcher_DriverChanged;
                driverWatcher.Stop();
            }
        }
    }

    public class LocalDriver : LocalFolder
    {
        public LocalDriver(string path, IFolder parent)
            : base(path, parent)
        {
            /// CD-ROM is not existed 
            /// Virtual folder is not existed

            this.FullPath = path;
            this.Parent = parent;
            this.AddPlaceHolder();
            fileAttr = FileAttributes.Directory;
        }
    }

    public class LocalVirtualFolder : LocalFolder
    {
        public LocalVirtualFolder(DataSourceShell shellItem)
            : base(string.Empty, null)
        {
            if (shellItem.IsNull())
            {
                throw new ArgumentNullException();
            }
            this.Name = shellItem.DisplayName;
            this.Icon = shellItem.Icon;
            this.FullPath = shellItem.Path;
            this.IsCheckVisible = false;
            this.Parent = this;
        }

        private IFolder realFolder;
        public IFolder RealFolder
        {
            get { return realFolder; }
            set
            {
                if (realFolder != value)
                {
                    if (!realFolder.IsNull())
                    {
                        realFolder.VirtualParent = null;
                    }

                    realFolder = value;
                    if (!realFolder.IsNull())
                    {
                        realFolder.VirtualParent = this;
                    }
                }
            }
        }

        public override void GetFoldersAsync(Action<IEnumerable<IFolder>> callback)
        {
            if (RealFolder.IsNull())
            {
                if (!callback.IsNull())
                {
                    callback(this.Folders);
                }
                return;
            }

            this.RealFolder.GetFoldersAsync((folders) =>
            {
                if (!IsFolderLoaded)
                {
                    IsFolderLoaded = AddItemsByChunk(folders, this.Folders, this.Items);
                }
                if (!callback.IsNull())
                {
                    callback(this.Folders);
                }
            });
        }

        public override void GetFilesAsync(Action<IEnumerable<IFile>> callback)
        {
            if (RealFolder.IsNull())
            {
                if (!callback.IsNull())
                {
                    callback(this.Files);
                }
                return;
            }

            this.RealFolder.GetFilesAsync((files) =>
            {
                if (!IsFileLoaded)
                {
                    IsFileLoaded = AddItemsByChunk(files, this.Files, this.Items);
                }

                if (!callback.IsNull())
                {
                    callback(this.Files);
                }
            });
        }
    }
}
