using FileExplorer.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FileExplorer.Model
{
    public class LocalFolder : FolderBase
    {
        static List<string> localExcludedFolders = new List<string>();
        static LocalFolder()
        {
            var str = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            string progPath = str.IsNullOrEmpty() ? string.Empty : str.ToLower();

            str = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            string progX86Path = str.IsNullOrEmpty() ? string.Empty : str.ToLower();

            str = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            string windPath = str.IsNullOrEmpty() ? string.Empty : str.ToLower();

            str = Environment.GetEnvironmentVariable("ProgramW6432");
            string progW6432 = str.IsNullOrEmpty() ? string.Empty : str.ToLower();

            if (!windPath.IsNullOrEmpty())
            {
                localExcludedFolders.Add(windPath);
            }

            if (!progPath.IsNullOrEmpty())
            {
                localExcludedFolders.Add(progPath);
            }

            if (!progW6432.IsNullOrEmpty() && !localExcludedFolders.Contains(progW6432))
            {
                localExcludedFolders.Add(progW6432);
            }

            if (!progX86Path.IsNullOrEmpty() && !localExcludedFolders.Contains(progX86Path))
            {
                localExcludedFolders.Add(progX86Path);
            }
        }

        const FileAttributes excludeFileAttributes = FileAttributes.Hidden;
        public static readonly IFolder PlackHolderItem = new LocalFolder();

        protected LocalFolder()
        {
        }

        public LocalFolder(string path, IFolder parent)
            : base(path, parent)
        {
            /// CD-ROM is not existed 
            /// Virtual folder is not existed
            //if (!this.FullPath.IsNullOrEmpty() && Directory.Exists(this.FullPath))
            if (this.FullPath.IsNullOrEmpty())
            {
                return;
            }

            this.AddPlaceHolder();
            this.IsEnabled = !localExcludedFolders.Contains(path.ToLower());
            if (!this.Parent.IsNull() && !this.Parent.IsEnabled)
            {
                this.IsEnabled = this.Parent.IsEnabled;
            }

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(this.FullPath);
                if (!dirInfo.IsNull())
                {
                    this.fileAttr = dirInfo.Attributes;
                    this.Name = dirInfo.Name;
                    this.LastModifyTime = dirInfo.LastWriteTime;
                }
                ///Pre-load network driver icon 
                ///else will block UI
                var icon = this.Icon;
            }
            catch (Exception ex)
            {
                LogHelper.Debug("Local folder constructor:{0}", ex);
            }
        }

        #region Sync Folder or file  query

        protected virtual IEnumerable<IFolder> GetFolders()
        {
            if (!IsFolderLoaded)
            {
                RunOnUIThread(() =>
                {
                    this.Folders.Clear();
                });

                IEnumerable<IFolder> folders = SearchFolders();
                IsFolderLoaded = AddItemsByChunk(folders, this.Folders, this.Items);
            }
            return this.Folders;
        }

        private IEnumerable<IFolder> SearchFolders(string searchPattern = searchAllWildChar)
        {
            IEnumerable<IFolder> result = new IFolder[0];

            try
            {
                ///Check is folder is existed before query
                ///CD-ROM will block query for a while without check existed
                if (Directory.Exists(this.FullPath))
                {
                    string[] dirs = Directory.GetDirectories(this.FullPath, searchPattern);
                    result = dirs.Where(item => (File.GetAttributes(item) & excludeFileAttributes) == 0)
                                 .Select(item => new LocalFolder(item, this));
                    result = SetFolderOrder(result);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                ///Access denied exception
                LogHelper.Debug(ex);
            }

            return result;
        }

        protected virtual IEnumerable<IFile> GetFiles()
        {
            if (!IsFileLoaded)
            {
                IEnumerable<IFile> files = SearchFiles();
                IsFileLoaded = AddItemsByChunk(files, this.Files, this.Items);
            }
            return Files;
        }

        private IEnumerable<IFile> SearchFiles(string searchPattern = searchAllWildChar)
        {
            IEnumerable<IFile> result = new IFile[0];
            try
            {
                ///Check is folder is existed before query
                ///CD-ROM will block query for a while without check existed
                if (Directory.Exists(this.FullPath))
                {
                    string[] files = Directory.GetFiles(this.FullPath, searchPattern);
                    result = files.Where(item => (File.GetAttributes(item) & excludeFileAttributes) == 0)
                                  .Select(item => new LocalFile(item, this));
                    result = SetFileOrder(result);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                ///Access denied exception
                LogHelper.Debug(ex);
            }

            return result;
        }

        protected override void AddPlaceHolder()
        {
            if (this != PlackHolderItem &&
                !this.Folders.Contains(PlackHolderItem))
            {
                this.Folders.Add(PlackHolderItem);
            }
        }

        #endregion

        #region Async interface

        public override void GetFoldersAsync(Action<IEnumerable<IFolder>> callback)
        {
            Action action = () =>
            {
                lock (lockObj)
                {
                    if (!IsFolderLoaded)
                    {
                        GetFolders();
                    }
                }
            };

            action.BeginInvoke(ar =>
            {
                EndInvokeAction(ar);
                if (!callback.IsNull())
                {
                    callback(this.Folders);
                }
            }, action);
        }

        public override void GetFilesAsync(Action<IEnumerable<IFile>> callback)
        {
            Action action = () =>
            {
                lock (lockObj)
                {
                    if (!IsFileLoaded)
                    {
                        GetFiles();
                    }
                }
            };

            action.BeginInvoke(ar =>
            {
                EndInvokeAction(ar);
                if (!callback.IsNull())
                {
                    callback(this.Files);
                }
            }, action);
        }

        #endregion
        public override object Clone()
        {
            LocalFolder folder = new LocalFolder();
            CloneMembers(folder);
            return folder;
        }

    }
}
