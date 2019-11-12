using System;
using System.Windows.Media;

namespace FileExplorer.Model
{
    public interface IFile : ICloneable
    {
        /// <summary>
        /// Full file path
        /// </summary>
        string FullPath { get; }

        /// <summary>
        /// File name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// File extension 
        /// </summary>
        string Extension { get; }

        /// <summary>
        /// File title for display
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Type name
        /// </summary>
        string TypeName { get; }

        /// <summary>
        /// Folder path for search
        /// </summary>
        string FolderPath { get; }

        DateTime LastModifyTime { get; }
        string LastModifyTimeString { get; }

        long Size { get; }
        string SizeString { get; }

        ImageSource Icon { get; }

        bool IsEnabled { get; set; }

        /// <summary>
        /// IsFolder for sort ordering
        /// </summary>
        bool IsFolder { get; }

        /// <summary>
        /// IsFile for sort ordering
        /// </summary>
        bool IsFile { get; }

        /// <summary>
        /// True: full checked
        /// Null: half checked
        /// False: not checked
        /// </summary>
        bool? IsChecked { get; set; }

        void SetChecked(bool? isChecked);

        IFolder Parent { get; }
    }
}
