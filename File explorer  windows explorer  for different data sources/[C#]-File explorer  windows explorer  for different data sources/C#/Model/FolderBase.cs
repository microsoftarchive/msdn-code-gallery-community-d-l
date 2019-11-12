using FileExplorer.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FileExplorer.Model
{
    public abstract class FolderBase : FileBase, IFolder, IFolderCheck
    {
        protected const string searchAllWildChar = "*";
        protected object lockObj = new object();

        #region IFolder properties

        public override string Title
        {
            get
            {
                return title.IsNullOrEmpty() ? this.Name : title;
            }
            protected set
            {
                SetProperty(ref title, value, "Title");
            }
        }

        private bool isLoading = false;
        public bool IsLoading
        {
            get
            {
                return isLoading;
            }
            protected set
            {
                SetProperty(ref isLoading, value, "IsLoading");
            }
        }

        private bool isExpanded = false;
        public bool IsExpanded
        {
            get
            {
                return isExpanded;
            }
            set
            {
                SetProperty(ref isExpanded, value, "IsExpanded");
            }
        }

        private bool isSelected = false;
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                SetProperty(ref isSelected, value, "IsSelected");
            }
        }

        public override bool? IsChecked
        {
            get { return isChecked; }
            set
            {
                if (SetProperty(ref isChecked, value, "IsChecked"))
                {
                    CheckParent(this, isChecked);
                    CheckChildren(this, isChecked);
                    RaiseCheckedChanged(this);
                }
            }
        }

        private bool isCheckVisible = true;
        /// <summary>
        /// Is tree item  checkbox visible
        /// </summary>
        public bool IsCheckVisible
        {
            get
            {
                return isCheckVisible;
            }
            set
            {
                SetProperty(ref isCheckVisible, value, "IsCheckVisible");
            }
        }

        public bool IsCanceled
        {
            get;
            protected set;
        }

        private IFolder virtualParent = null;
        public IFolder VirtualParent
        {
            get { return virtualParent; }
            set
            {
                SetProperty(ref virtualParent, value, "VirtualParent");
            }
        }

        #endregion

        public FolderBase(string path, IFolder parent)
        {
            this.FullPath = path;
            this.Parent = parent;
            ///The root item's parent is null for the constructor
            if (!parent.IsNull() && this.Parent.IsChecked == true)
            {
                this.SetChecked(this.Parent.IsChecked);
            }
            fileAttr = FileAttributes.Directory;
        }

        protected FolderBase()
        {
            fileAttr = FileAttributes.Directory;
        }

        private ObservableCollection<IFolder> folders = new ObservableCollection<IFolder>();
        /// <summary>
        /// Sub folders
        /// </summary>
        public ObservableCollection<IFolder> Folders
        {
            get { return folders; }
        }

        private ObservableCollection<IFile> files = new ObservableCollection<IFile>();
        /// <summary>
        /// Sub files
        /// </summary>
        public ObservableCollection<IFile> Files
        {
            get { return files; }
        }

        private ObservableCollection<IFile> items = new ObservableCollection<IFile>();
        /// <summary>
        /// Sub folders and files
        /// </summary>
        public ObservableCollection<IFile> Items
        {
            get { return items; }
        }

        private bool isFolderLoaded = false;
        /// <summary>
        /// Is children folder loaded
        /// </summary>
        protected bool IsFolderLoaded
        {
            get { return isFolderLoaded; }
            set { isFolderLoaded = value; }
        }

        private bool isFileLoaded = false;
        /// <summary>
        /// Is children files loaded
        /// </summary>
        protected bool IsFileLoaded
        {
            get { return isFileLoaded; }
            set { isFileLoaded = value; }
        }

        /// <summary>
        /// Only support for all checked or no checked by parent, UI operations by user
        /// </summary>
        /// <param name="parentFolder"></param>
        /// <param name="isChecked"></param>
        public void CheckChildren(IFolder parentFolder, bool? isChecked)
        {
            if (parentFolder.IsNull() || !isChecked.HasValue ||
                !(parentFolder is IFolder))
            {
                return;
            }

            IFolder parent = parentFolder as IFolder;
            ///Use property better than method is for lazy load
            foreach (IFile file in parent.Files)
            {
                file.SetChecked(isChecked);
            }

            foreach (IFolder folder in parent.Folders)
            {
                folder.SetChecked(isChecked);
            }

            foreach (IFolder folder in parent.Folders)
            {
                CheckChildren(folder, isChecked);
            }
        }

        /// <summary>
        /// Get all checked items
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        public IEnumerable<IFile> GetCheckedItems(IFolder folder)
        {
            IEnumerable<IFile> result = new IFile[0];
            if (folder.IsNull() ||
                folder.IsChecked == false || !folder.IsEnabled)
            {
                return result;
            }

            ///The root folder's parent is itself
            ///so filter these folder items
            if (folder.IsChecked == true && folder.Parent != folder)
            {
                result = result.Union(new IFile[] { folder });
            }
            else
            {
                foreach (var item in folder.Items)
                {
                    if (item.IsChecked == true)
                    {
                        result = result.Union(new IFile[] { item });
                    }
                    else if ((item.IsChecked == null) && (item is IFolder))
                    {
                        IFolder subFolder = item as IFolder;
                        if (!subFolder.IsNull())
                        {
                            result = result.Union((item as IFolderCheck).GetCheckedItems(subFolder));
                        }
                    }
                }
            }

            return result;
        }

        public virtual void Cancel()
        {
            this.IsCanceled = true;
            this.IsLoading = false;
            this.Clear();
        }

        /// <summary>
        /// Clear files
        /// </summary>
        protected void Clear()
        {
            if (!this.IsFolderLoaded)
            {
                foreach (var item in this.Folders)
                {
                    item.Dispose();
                    this.Items.Remove(item);
                }
                this.Folders.Clear();
                this.AddPlaceHolder();
            }

            if (!this.IsFileLoaded)
            {
                foreach (var item in this.Files)
                {
                    this.Items.Remove(item);
                }
                this.Files.Clear();
            }
        }

        protected abstract void AddPlaceHolder();

        protected const int chunk = 50;
        protected bool AddItemsByChunk<T>(IEnumerable<T> source, params IList[] destinations) where T : IFile
        {
            if (source.IsNullOrEmpty() || destinations.IsNull())
            {
                return true;
            }

            int index = 0;
            int getCount = chunk;
            while (getCount > 0)
            {
                var chunkItems = source.Skip(index++ * chunk).Take(chunk);
                getCount = chunkItems.Count();
                if (IsCanceled)
                {
                    RunOnUIThread(() =>
                    {
                        Clear();
                    });
                    return false;
                }

                if (getCount == 0)
                {
                    break;
                }

                RunOnUIThread(() =>
                {
                    foreach (var item in chunkItems)
                    {
                        if (IsCanceled)
                        {
                            return;
                        }
                        //LogHelper.DebugFormat(" ---> new load item:{0}", item.FullPath);
                        foreach (var list in destinations)
                        {
                            list.Add(item);
                        }
                    }

                    //if (destinations.FirstOrDefault() != null)
                    //{
                    //    LogHelper.DebugFormat(" ---> new load count:{0}", destinations.FirstOrDefault().Count);
                    //}
                });
            }
            return true;
        }

        #region IFolderAsync

        public virtual void GetChildrenAsync(Action<IEnumerable<IFile>> callback)
        {
            IsCanceled = false;

            ///If all subitem got, don't need show loading
            if (!IsFolderLoaded || !IsFileLoaded)
            {
                IsLoading = true;
            }

            this.GetFoldersAsync((folders) =>
            {
                this.GetFilesAsync((files) =>
                {
#if DEBUG
                    if (!IsCanceled)
                    {
                        Debug.Assert(IsFolderLoaded && IsFileLoaded, "---- GetChildrenAsync callback conditions not all true");
                    }
#endif
                    IsLoading = false;
                    if (!callback.IsNull())
                    {
                        callback(this.Items);
                    }
                });
            });
        }

        protected void EndInvokeAction(IAsyncResult result)
        {
            Action action = result.AsyncState as Action;
            if (action.IsNull())
            {
                return;
            }
            action.EndInvoke(result);
        }

        public abstract void GetFoldersAsync(Action<IEnumerable<IFolder>> callback);

        public abstract void GetFilesAsync(Action<IEnumerable<IFile>> callback);

        public void GetItemAsync(string path, Action<IFile> callback, bool isRecursive = true)
        {
            if (path.IsNullOrEmpty() ||
                (!this.FullPath.IsNullOrEmpty() && !path.StartsWith(FullPath)))
            {
                if (!callback.IsNull())
                {
                    callback(null);
                }
                return;
            }

            if (path == this.FullPath)
            {
                if (!callback.IsNull())
                {
                    callback(this);
                }
                return;
            }

            IFile result = null;
            if (!isRecursive)
            {
                this.GetChildrenAsync((items) =>
                {
                    result = items.FirstOrDefault(f => f.FullPath == path);
                    if (!callback.IsNull())
                    {
                        callback(result);
                    }
                });
                return;
            }

            ///Get folder recursively
            const string pathFormat = "{0}{1}";
            const StringSplitOptions splitOpt = StringSplitOptions.RemoveEmptyEntries;
            char pathSepChar = Path.DirectorySeparatorChar;
            char[] pathSepChars = new[] { pathSepChar };

            string[] parts = null;
            if (this.FullPath.IsNullOrEmpty())
            {
                parts = path.Split(pathSepChars, splitOpt);
            }
            else if (this.FullPath == pathSepChar.ToString())
            {
                ///Remote root folder full path is \
                parts = path.Substring(path.IndexOf(this.FullPath) + 1).Split(pathSepChars, splitOpt);
            }
            else
            {
                parts = path.Replace(this.FullPath, string.Empty).Split(pathSepChars, splitOpt);
            }

            if (parts.IsNullOrEmpty())
            {
                if (!callback.IsNull())
                {
                    callback(null);
                }
                return;
            }

            string newPath = FullPath;

            if (newPath.IsNullOrEmpty())
            {
                ///The driver path,end with '\'
                newPath = string.Format(pathFormat, parts[0], pathSepChar);
            }
            else
            {
                newPath = Path.Combine(newPath, parts[0]);
            }

            this.GetChildrenAsync((items) =>
            {
                IFile item = items.FirstOrDefault(f => f.FullPath == newPath);
                if (!item.IsNull())
                {
                    if (item.FullPath == path)
                    {
                        if (!callback.IsNull())
                        {
                            callback(item);
                            return;
                        }
                    }

                    if (item is IFolder)
                    {
                        (item as IFolder).GetItemAsync(path, callback, isRecursive);
                    }
                }
                else if (!callback.IsNull())
                {
                    callback(null);
                    return;
                }
            });
        }

        public static IEnumerable<T> SetFolderOrder<T>(IEnumerable<T> list, bool isAsc = true) where T : IFile
        {
            if (list.IsNullOrEmpty())
            {
                return list;
            }

            if (isAsc)
            {
                return list.OrderBy(item => item.Name);
            }
            else
            {
                return list.OrderByDescending(item => item.Name);
            }
        }

        public static IEnumerable<T> SetFileOrder<T>(IEnumerable<T> list, bool isAsc = true) where T : IFile
        {
            if (list.IsNullOrEmpty())
            {
                return list;
            }

            if (isAsc)
            {
                return list.OrderBy(item => item.Name);//.ThenBy(item => item.Name.Length);
            }
            else
            {
                return list.OrderByDescending(item => item.Name);//.ThenByDescending(item => item.Name.Length);
            }
        }

        #endregion

        protected override void OnDisposing(bool isDisposing)
        {
            this.Cancel();
            foreach (var item in this.Folders)
            {
                item.Dispose();
            }
            this.Folders.Clear();
            this.Files.Clear();
            this.Items.Clear();
            this.Parent = null;
        }
    }
}
