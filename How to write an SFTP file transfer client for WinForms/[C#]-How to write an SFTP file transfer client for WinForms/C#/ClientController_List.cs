using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ComponentPro;
using ComponentPro.IO;
using ComponentPro.Net;

namespace ClientSample
{
    partial class ClientController
    {
        #region Remote

        /// <summary>
        /// Refreshes the remote list view.
        /// </summary>
        public
#if Framework4_5
        async
#endif
        void RefreshRemoteList()
        {
            // Disable the dialog.
            _view.EnableView(false);

#if Framework4_5
            try
            {
                // Asynchronously retrieve a list of remote files.
#if Framework4_5
                FtpFileInfoCollection files = await client.ListDirectoryAsync();
#else
                FtpFileInfoCollection files = client.ListDirectory();
#endif
                ShowRemoteList(files);
            }
            catch (Exception exc)
            {
                if (!HandleException(exc))
                    return;
            }
            finally
            {
                // Enable the dialog and handle the exception.
                EnableDialog(true);
            }
#else
            _client.ListDirectoryAsync();
#endif
        }

#if !Framework4_5
        /// <summary>
        /// Handles the client's GetFileListCompleted event.
        /// </summary>
        /// <param name="sender">The Ftp object.</param>
        /// <param name="e">The event arguments.</param>
        private void client_ListDirectoryCompleted(object sender, ExtendedAsyncCompletedEventArgs<FileInfoCollection> e)
        {
            _view.EnableView(true);

            if (e.Error != null)
            {
                if (!HandleException(e.Error))
                    return;
                Disconnect();
                return;
            }

            DoListDirPost(e.Result);
        }
#endif

        void DoListDirPost(FileInfoCollection files)
        {            
            ListFiles(files, _currentDirectory.Length <= 1, false);
        }

        private void ListFiles(FileInfoCollection files, bool rootDir, bool local)
        {
            List<ListItemInfo> viewList = new List<ListItemInfo>();
            ListItemInfo item;

            // Add directories into the list first.
            for (int i = 0; i < files.Count; i++)
            {
                AbstractFileInfo f = files[i];

                if (f.IsDirectory)
                {
                    if (f.Name != "." && f.Name != "..")
                    {
                        item = new ListItemInfo();
                        item.FileInfo = f;

                        if (!local)
                            item.Permissions = _clientPlugin.GetPermissionsString(f);

                        viewList.Add(item);
                    }
                }
                else if (f.IsSymlink) // Add symlinks.
                {
                    item = new ListItemInfo();
                    item.FileInfo = f;
                    item.LinkedFile = _client.GetFileInfo(f.SymlinkPath);
                    item.Permissions = _clientPlugin.GetPermissionsString(f);

                    viewList.Add(item);
                }
                else //Add Files.
                {
                    item = new ListItemInfo();
                    item.FileInfo = f;
                    if (!local)
                        item.Permissions = _clientPlugin.GetPermissionsString(f);

                    viewList.Add(item);
                }
            }

            if (!rootDir)
            {
                // Add Cdup list item.
                item = new ListItemInfo();
                if (local)
                    item.FileInfo = DiskFileSystem.Default.CreateFileInfo("..", FileAttributes.Directory, -1, DateTime.MinValue);
                else
                    item.FileInfo = _client.CreateFileInfo("..", FileAttributes.Directory, -1, DateTime.MinValue);
                viewList.Add(item);
            }

            if (local)
                _view.ListLocalFiles(viewList);
            else
                _view.ListRemoteFiles(viewList);
        }

        #endregion

        #region Local

        /// <summary>
        /// Refreshes the local list view.
        /// </summary>
        public void RefreshLocalList()
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(_currentLocalDirectory);
                FileInfoCollection list = DiskFileSystem.Default.ListDirectory(directory.FullName);

                ListFiles(list, directory.FullName.Length <= 3, true);
            }
            catch (Exception exc)
            {
                _view.ShowError(exc);
                return;
            }
        }

        #endregion

        /// <summary>
        /// Changes local directory.
        /// </summary>
        /// <param name="dir">The new target path.</param>
        public void DoRemoteChangeDirectory(string dir)
        {
            if (_state != ConnectionState.Ready || dir == ".")
                return;

            if (dir == "..")
                dir = _client.GetDirectoryName(_currentDirectory);
            else
                dir = _client.CombinePath(_currentDirectory, dir);

            try
            {
                _client.SetCurrentDirectory(dir);
            }
            catch (Exception ex)
            {
                _view.ShowError(ex);
                return;
            }

            _view.UpdateRemotePath(dir);
            _currentDirectory = dir;
            RefreshRemoteList();
        }

        /// <summary>
        /// Changes local directory.
        /// </summary>
        /// <param name="dir">The new target path.</param>
        public void DoLocalChangeDirectory(string dir)
        {
            dir = Path.GetFullPath(Path.Combine(_currentLocalDirectory, dir));
            _view.UpdateLocalPath(dir);
            _currentLocalDirectory = dir;
            RefreshLocalList();
        }
    }
}
