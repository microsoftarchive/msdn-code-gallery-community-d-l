using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FileExplorer.Model
{
    public interface IFolder : IFile, IDisposable
    {
        /// <summary>
        /// is loading children
        /// </summary>
        bool IsLoading { get; }

        /// <summary>
        /// Is tree item  expanded
        /// </summary>
        bool IsExpanded { get; set; }

        /// <summary>
        /// Is tree item  selected
        /// </summary>
        bool IsSelected { get; set; }

        /// <summary>
        /// Is extracting canceled
        /// </summary>
        bool IsCanceled { get; }

        /// <summary>
        /// Is tree item  checkbox visible
        /// </summary>
        bool IsCheckVisible { get; set; }

        /// <summary>
        /// Folder in virtual folder has a virtual parent
        /// </summary>
        IFolder VirtualParent { get; set; }

        /// <summary>
        /// Sub folders
        /// </summary>
        ObservableCollection<IFolder> Folders { get; }

        /// <summary>
        /// Sub files
        /// </summary>
        ObservableCollection<IFile> Files { get; }

        /// <summary>
        /// Sub folders and files
        /// </summary>
        ObservableCollection<IFile> Items { get; }

        /// <summary>
        /// Cancel current extracting
        /// </summary>
        void Cancel();

        /// <summary>
        /// Get sub folders and files async
        /// </summary>
        /// <returns></returns>
        void GetChildrenAsync(Action<IEnumerable<IFile>> callback);

        /// <summary>
        /// Get sub folders async
        /// </summary>
        /// <returns></returns>
        void GetFoldersAsync(Action<IEnumerable<IFolder>> callback);

        /// <summary>
        /// Get sub  files async
        /// </summary>
        /// <returns></returns>
        void GetFilesAsync(Action<IEnumerable<IFile>> callback);

        /// <summary>
        ///  Get sub foldr or file by path
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="callback"></param>
        /// <param name="isRecursive"></param>
        void GetItemAsync(string filePath, Action<IFile> callback, bool isRecursive = true);

    }
}
