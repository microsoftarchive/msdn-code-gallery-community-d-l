using FileExplorer.Factory;
using FileExplorer.Helper;
using FileExplorer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace FileExplorer.ViewModel
{
    public class FileExplorerViewModel : SortOrderViewModel
    {
        private ExplorerFactoryBase RootFactory { get; set; }

        #region Properties

        private ObservableCollection<IFolder> items = new ObservableCollection<IFolder>();
        /// <summary>
        /// Root items
        /// </summary>
        public ObservableCollection<IFolder> Items
        {
            get { return items; }
        }

        private IFolder currentFolder;
        public IFolder CurrentFolder
        {
            get { return currentFolder; }
            private set
            {
                if (SetProperty(ref currentFolder, value, "CurrentFolder"))
                {
                    this.SearchViewModel.InitialSearch(currentFolder);
                }
            }
        }

        public IFolder RootFolder { get; private set; }

        private SearchViewModel searchViewModel = null;
        public SearchViewModel SearchViewModel
        {
            get { return searchViewModel; }
            set
            {
                SetProperty(ref searchViewModel, value, "SearchViewModel");
            }
        }

        #endregion

        public FileExplorerViewModel()
        {
            SearchViewModel = new SearchViewModel();
        }

        public void SetCurrentFolder(IFolder folder)
        {
            if (folder.IsNull() || this.CurrentFolder == folder)
            {
                return;
            }

            this.RunOnUIThread(() =>
            {
                ///If the new folder is current folder's child
                ///current folder need load all childrens
                ///Can not be canceled
                if (!this.CurrentFolder.IsNull() && folder.Parent != this.CurrentFolder)
                {
                    this.CurrentFolder.Cancel();
                }
                ClearSortOptions();
                this.CurrentFolder = folder;
                this.ContentView = CollectionViewSource.GetDefaultView(this.CurrentFolder.Items);
                this.SetSortOrder(SortPropertyName, ListSortDirection.Ascending);
                this.InvokeSortOrderCallback();
            });

            folder.GetChildrenAsync((items) =>
            {
                // this.SetCheckedPaths();
            });
        }

        public void LoadFolderChildren(IFolder folder)
        {
            if (folder.IsNull() || this.CurrentFolder == folder)
            {
                return;
            }

            folder.GetChildrenAsync((folders) =>
            {
                //this.SetCheckedPaths();
            });
        }

        #region Check operation

        public IEnumerable<string> GetCheckedPaths()
        {
            IEnumerable<IFile> checkedItems = null;
            if (this.SearchViewModel.IsSearchEnabled)
            {
                checkedItems = this.SearchViewModel.GetCheckedItems();
            }
            else
            {
                checkedItems = (this.RootFolder as IFolderCheck).GetCheckedItems(this.RootFolder);
            }

            IEnumerable<string> result = checkedItems.Select(item => item.FullPath);
#if DEBUG
            foreach (var item in result)
            {
                LogHelper.DebugFormat("/---- selected path:{0}", item);
            }
#endif
            return result;
        }

        IList<string> checkedPaths;
        public IList<string> CheckedPaths
        {
            get
            {
                checkedPaths = checkedPaths ?? new List<string>();
                return checkedPaths;
            }
            private set
            {
                if (checkedPaths != value)
                {
                    checkedPaths = value;
                }
            }
        }

        public void SetCheckedPaths(IList<string> pathList)
        {
            if (pathList.IsNullOrEmpty())
            {
                return;
            }
            this.CheckedPaths = pathList.OrderBy(item => item.Length).ToList();
            SetCheckedPaths();
        }

        public void SetCheckedPaths()
        {
            SetPathChecked(CheckedPaths);
        }

        public void SetPathChecked(IEnumerable<string> list, bool isChecked = true)
        {
            if (list.IsNullOrEmpty() || this.RootFolder.IsNull()) //this.RootFolder.IsLoading
            {
                return;
            }

            foreach (string path in list)
            {
                this.RootFolder.GetItemAsync(path, (file) =>
                {
                    if (!file.IsNull())
                    {
                        file.IsChecked = isChecked;
#if DEBUG
                        LogHelper.DebugFormat("/---- selected path:{0}", file.FullPath);
#endif
                    }
                });
            }
        }

        #endregion

        internal void InitialExplorer(ExplorerFactoryBase factory)
        {
            if (factory.IsNull())
            {
                throw new ArgumentNullException("factory");
            }

            RemoveExplorer();
            this.RootFactory = factory;
            this.RootFactory.GetRootFoldersAsync((items) =>
            {
                this.RunOnUIThread(() =>
                {
                    foreach (var item in items)
                    {
                        if (RootFolder.IsNull())
                        {
                            RootFolder = item;
                        }
                        this.Items.Add(item);
                    }
                });
            });

        }

        public void LoadLocalExplorer()
        {
            this.InitialExplorer(new LocalExplorerFactory());
        }

        //public void LoadExplorerByJob(BackupJob backupJob)
        //{
        //    if (backupJob == null)
        //    {
        //        throw new ArgumentNullException("BackupJob");
        //    }

        //    ExplorerFactoryBase result = null;
        //    switch (backupJob.JobTarget)
        //    {
        //        case JobTarget.HardDisk:
        //        case JobTarget.LocalNetworkStorage:
        //        case JobTarget.RemovableDisk:
        //            if (backupJob.LastBackupFile == null ||
        //                string.IsNullOrEmpty(backupJob.LastBackupFile.NbixFilePath))
        //            {
        //                throw new ArgumentNullException("backupJob.LastBackupFile");
        //            }
        //            result = new JsonExplorerFactory(backupJob.LastBackupFile.NbixFilePath);
        //            break;

        //        case JobTarget.OpticalDisk:
        //            if (string.IsNullOrEmpty(backupJob.JobFilePath))
        //            {
        //                throw new ArgumentNullException(" backupJob.JobFilePath");
        //            }
        //            result = new CDRomExplorerFactory(backupJob.JobFilePath);
        //            break;

        //        case JobTarget.Online:
        //            result = new CloudExplorerFactory();
        //            break;

        //        default:
        //            result = new LocalExplorerFactory();
        //            break;
        //    }
        //    this.InitialExplorer(result);
        //}

        private void RemoveExplorer()
        {
            foreach (var item in this.Items)
            {
                item.Dispose();
            }

            this.Items.Clear();
            this.RootFactory = null;
            this.RootFolder = null;
            this.ContentView = null;
            this.CurrentFolder = null;

            this.SearchViewModel.UninitialSearch();
        }

        protected override void OnDisposing(bool isDisposing)
        {
            RemoveExplorer();
            this.SearchViewModel.Dispose();
            base.OnDisposing(isDisposing);
        }
    }
}
