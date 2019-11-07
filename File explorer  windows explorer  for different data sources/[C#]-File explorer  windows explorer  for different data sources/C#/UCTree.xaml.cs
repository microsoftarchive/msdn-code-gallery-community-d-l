using FileExplorer.Helper;
using FileExplorer.Model;
using FileExplorer.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Linq;

namespace FileExplorer
{
    /// <summary>
    /// Interaction logic for UCFileTree.xaml
    /// </summary>
    public partial class UCTree : UserControl
    {
        public FileExplorerViewModel ViewModel
        {
            get
            {
                return this.DataContext as FileExplorerViewModel;
            }
        }

        public UCTree()
        {
            InitializeComponent();
            this.Loaded += (obj, e) => { this.treeExplorer.Focus(); };
        }

        /// <summary>
        /// expand tree item , load data dor sub-sub class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void treeExplorer_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.OriginalSource as TreeViewItem;
            if (item == null)
            {
                return;
            }
            IFolder folder = item.DataContext as IFolder;
            if (folder.IsNull())
            {
                return;
            }

            this.ViewModel.LoadFolderChildren(folder);
        }

        void treeExplorer_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            IFolder folder = e.NewValue as IFolder;
            if (folder.IsNull())
            {
                return;
            }

            this.ViewModel.SetCurrentFolder(folder);
        }


        #region Tree key navigation

        private IFolder lastFolder = null;
        void treeExplorer_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            IFolder folder = treeExplorer.SelectedItem as IFolder;
            if (folder.IsNull())
            {
                return;
            }

            IFolder newSelectFolder = null;
            switch (e.Key)
            {
                case Key.Left:
                    newSelectFolder = MoveLeft(folder);
                    break;

                case Key.Right:
                    MoveRight(folder);
                    break;

                case Key.Up:
                    newSelectFolder = MoveUp(folder);
                    break;

                case Key.Down:
                    newSelectFolder = MoveDown(folder);
                    break;
                default:
                    break;
            }

            ///Focus maybe out of tree area
            if (!newSelectFolder.IsNull())
            {
                TreeViewItem treeItem = treeExplorer.ItemContainerGenerator.ContainerFromItem(newSelectFolder) as TreeViewItem;
                if (!treeItem.IsNull())
                {
                    treeItem.Focus();
                }
            }
            e.Handled = true;
        }


        private IFolder MoveLeft(IFolder folder)
        {
            IFolder newSelectFolder = null;
            if (folder.IsNull())
            {
                return newSelectFolder;
            }

            ///The last folder explanded and selection will cause a splash
            ///So only one action can be trigged here
            if (!lastFolder.IsNull() && lastFolder == folder)
            {
                lastFolder.IsExpanded = false;
                lastFolder = null;
                return newSelectFolder;
            }

            if (folder.Parent == folder ||
                (!folder.Parent.VirtualParent.IsNull() && folder.Parent.VirtualParent == folder.Parent.VirtualParent.Parent))
            {
                if (folder.Parent == folder)
                {
                    newSelectFolder = folder;
                }
                else
                {
                    newSelectFolder = folder.Parent.VirtualParent;
                }
                newSelectFolder.IsSelected = true;
                lastFolder = newSelectFolder;
                return newSelectFolder;
            }
            newSelectFolder = folder.Parent;
            newSelectFolder.IsSelected = true;
            lastFolder = newSelectFolder;
            return newSelectFolder;
        }

        private IFolder MoveRight(IFolder folder)
        {
            IFolder newSelectFolder = null;
            if (folder.IsNull())
            {
                return newSelectFolder;
            }

            folder.GetFoldersAsync((folders) =>
            {
                folder.IsExpanded = true;
                if (folders.IsNullOrEmpty())
                {
                    newSelectFolder = folder;
                    newSelectFolder.IsSelected = true;
                    return;
                }

                IFolder firstChild = folders.FirstOrDefault();
                newSelectFolder = firstChild;
                newSelectFolder.IsSelected = true;
            });

            return newSelectFolder;
        }

        private IFolder MoveUp(IFolder folder)
        {
            IFolder newSelectFolder = null;
            if (folder.IsNull())
            {
                return newSelectFolder;
            }

            if (folder.Parent == folder)
            {
                var allTreeItems = treeExplorer.Items;
                int index = allTreeItems.IndexOf(folder);
                if (index > 0)
                {
                    newSelectFolder = allTreeItems[index - 1] as IFolder;
                    if (newSelectFolder.IsExpanded)
                    {
                        newSelectFolder = newSelectFolder.Folders.LastOrDefault();
                    }
                    newSelectFolder.IsSelected = true;
                }
                return newSelectFolder;
            }

            var upFolders = folder.Parent.Folders;
            int upIndex = upFolders.IndexOf(folder);
            if (upIndex > 0)
            {
                var upFolder = upFolders[upIndex - 1];
                newSelectFolder = upFolder;

                ///Folder with no sub folder, the IsExpanded maybe true
                while (!upFolder.IsNull() && upFolder.IsExpanded)
                {
                    newSelectFolder = upFolder.Folders.LastOrDefault();
                    if (!newSelectFolder.IsNull())
                    {
                        if (!newSelectFolder.IsExpanded || upFolder.Folders.IsNullOrEmpty())
                        {
                            break;
                        }
                        else
                        {
                            upFolder = newSelectFolder;
                        }
                    }
                    else
                    {
                        newSelectFolder = upFolder;
                        break;
                    }
                }
                if (!newSelectFolder.IsNull())
                {
                    newSelectFolder.IsSelected = true;
                }
            }
            else
            {
                if (folder.Parent == folder ||
                   (!folder.Parent.VirtualParent.IsNull() && folder.Parent.VirtualParent == folder.Parent.VirtualParent.Parent))
                {
                    var allTreeItems = treeExplorer.Items;
                    int index = -1;
                    if (folder.Parent == folder)
                    {
                        index = allTreeItems.IndexOf(folder);
                        if (index > 0)
                        {
                            newSelectFolder = allTreeItems[index - 1] as IFolder;
                            newSelectFolder.IsSelected = true;
                        }
                    }
                    else
                    {
                        newSelectFolder = folder.Parent.VirtualParent;
                        newSelectFolder.IsSelected = true;
                    }
                }
                else
                {
                    newSelectFolder = folder.Parent;
                    newSelectFolder.IsSelected = true;
                }
            }
            return newSelectFolder;
        }

        private IFolder MoveDown(IFolder folder)
        {
            IFolder newSelectFolder = null;
            if (folder.IsNull())
            {
                return newSelectFolder;
            }

            if (folder.IsExpanded)
            {
                var nextFolder = folder.Folders.FirstOrDefault();
                if (!nextFolder.IsNull())
                {
                    newSelectFolder = nextFolder;
                    newSelectFolder.IsSelected = true;
                    return newSelectFolder;
                }
            }

            var parentFolders = folder.Parent.Folders;
            int downIndex = parentFolders.IndexOf(folder);
            if (downIndex >= 0 && downIndex < parentFolders.Count - 1)
            {
                newSelectFolder = parentFolders[downIndex + 1];
                newSelectFolder.IsSelected = true;
            }
            else
            {
                var parent = folder.Parent;
                while (!parent.IsNull())
                {
                    if (parent == folder)
                    {
                        var allTreeItems = treeExplorer.Items;
                        int index = allTreeItems.IndexOf(folder.Parent);
                        if (index < allTreeItems.Count - 1)
                        {
                            newSelectFolder = allTreeItems[index + 1] as IFolder;
                            newSelectFolder.IsSelected = true;
                        }
                        break;
                    }
                    else
                    {
                        parentFolders = parent.Parent.Folders;
                        downIndex = parentFolders.IndexOf(parent);
                        if (downIndex >= 0 && downIndex < parentFolders.Count - 1)
                        {
                            newSelectFolder = parentFolders[downIndex + 1];
                            newSelectFolder.IsSelected = true;
                            break;
                        }
                        else
                        {
                            folder = parent;
                            parent = parent.Parent;
                        }
                    }
                }
            }

            return newSelectFolder;
        }

        #endregion
    }
}
