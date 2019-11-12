using FileExplorer.Helper;
using FileExplorer.Shell;
using FileExplorer.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media;

namespace FileExplorer.Model
{
    public abstract class FileBase : ViewModelBase, IFile, IFileCheck
    {
        public static event EventHandler<ContentEventArgs<IFile>> ItemCheckedChanged;

        #region  IFile Properties

        private string fullPath = string.Empty;
        public string FullPath
        {
            get
            {
                return fullPath;
            }
            protected set
            {
                SetProperty(ref fullPath, value, "FullPath");
            }
        }

        private string name = string.Empty;
        public string Name
        {
            get
            {
                return name;
            }
            protected set
            {
                SetProperty(ref name, value, "Name");
            }
        }

        private string extension = string.Empty;
        public string Extension
        {
            get
            {
                return extension;
            }
            protected set
            {
                SetProperty(ref extension, value, "Extension");
            }
        }

        protected string title = string.Empty;
        public virtual string Title
        {
            get
            {
                if (title.IsNullOrEmpty())
                    title = this.Name;
                return title;
            }
            protected set
            {
                SetProperty(ref title, value, "Title");
            }
        }

        private DateTime lastModifyTime;
        public DateTime LastModifyTime
        {
            get
            {
                return lastModifyTime;
            }
            protected set
            {
                SetProperty(ref lastModifyTime, value, "LastModifyTimeString");
            }
        }

        protected readonly DateTime UTCDateMin = DateTime.Parse("1900-1-1");
        /// <summary>
        /// format last modify time 
        /// </summary>
        public string LastModifyTimeString
        {
            get
            {
                if (LastModifyTime <= UTCDateMin) return string.Empty;
                return LastModifyTime.ToString();
            }
        }

        private long size = 0;
        public long Size
        {
            get
            {
                return size;
            }
            protected set
            {
                SetProperty(ref size, value, "SizeString");
            }
        }

        private const double sizeUnit = 1024d;
        /// <summary>
        /// format size number to string ,unit is K or M
        /// </summary>
        public string SizeString
        {
            get
            {
                string result = string.Empty;
                if (this.IsFolder)
                {
                    return result;
                }

                if (Size <= 0)
                    result = "0 KB";
                else if (Size <= sizeUnit)
                    result = "1 KB";
                else if (Size < Math.Pow(sizeUnit, 2))
                    result = string.Format("{0} KB", Math.Ceiling(Size / sizeUnit));
                else
                    result = string.Format("{0:0,0} KB", Math.Ceiling(Size / sizeUnit));
                return result;
            }
        }

        private bool isEnabled = true;
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                SetProperty(ref isEnabled, value, "IsEnabled");
            }
        }

        protected bool? isChecked = false;
        public virtual bool? IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                if (SetProperty(ref isChecked, value, "IsChecked"))
                {
                    CheckParent(this, isChecked);
                    RaiseCheckedChanged(this);
                }
            }
        }

        private IFolder parent = null;
        public IFolder Parent
        {
            get { return parent; }
            protected set
            {
                SetProperty(ref parent, value, "Parent");
            }
        }


        protected string folderPath = null;
        /// <summary>
        /// Folder path for search
        /// </summary>
        public virtual string FolderPath
        {
            get
            {
                folderPath = folderPath.IsNullOrEmpty() && !Parent.IsNull() ? this.Parent.FullPath : folderPath;
                return folderPath;
            }
        }

        protected virtual string IconKey
        {
            get
            {
                return this.FullPath;
            }
        }

        protected FileAttributes fileAttr = FileAttributes.Normal;
        protected ImageSource icon = null;
        public virtual ImageSource Icon
        {
            get
            {
                if (icon.IsNull())
                {
                    var iconResult = GetIcon(this.IconKey, fileAttr);
                    if (!iconResult.IsNull() && icon.IsNull())
                    {
                        if (this is LocalDriver)
                        {
                            this.Title = iconResult.Item2;
                        }
                        icon = iconResult.Item1;
                        typeName = iconResult.Item3;
                        OnPropertyChanged("TypeName");
                    }
                }
                return icon;
            }
            set
            {
                SetProperty(ref icon, value, "Icon", "TypeName");
            }
        }

        protected string typeName = string.Empty;
        public virtual string TypeName
        {
            get
            {
                typeName = typeName.IsNullOrEmpty() ? GetTypeName(this.IconKey) : typeName;
                return typeName;
            }
        }

        /// <summary>
        /// IsFolder for sort ordering
        /// </summary>
        public bool IsFolder
        {
            get
            {
                return this is IFolder;
            }
        }

        /// <summary>
        /// IsFile for sort ordering
        /// </summary>
        public bool IsFile
        {
            get
            {
                return !IsFolder;
            }
        }

        #endregion

        public FileBase(string path, IFolder parent)
        {
            if (parent.IsNull())
            {
                throw new ArgumentNullException();
            }
            this.FullPath = path;
            this.Parent = parent;
            this.IsEnabled = parent.IsEnabled;
            if (this.Parent.IsChecked == true)
            {
                this.SetChecked(this.Parent.IsChecked);
            }
        }

        /// <summary>
        /// Construct for folder with no physical path
        /// such as MyComputer
        /// </summary>
        protected FileBase()
        {
        }

        /// <summary>
        /// Checked item not to do the recursive  checked opertion
        /// </summary>
        /// <param name="isChecked"></param>
        public void SetChecked(bool? isChecked)
        {
            if (this.IsEnabled)
            {
                this.isChecked = isChecked;
                this.OnPropertyChanged("IsChecked");
                RaiseCheckedChanged(this);
            }
        }

        public void CheckParent(IFile child, bool? isChecked)
        {
            if (child.IsNull() || child.Parent.IsNull() ||
                child == child.Parent)//For the root folder
            {
                return;
            }

            IFolder parent = child.Parent;
            var children = parent.Items.Where(item => item.IsEnabled);

            if (!isChecked.HasValue)
            {
                parent.SetChecked(isChecked);
            }
            else
            {
                if (isChecked.Value)
                {
                    if (children.All(item => item.IsChecked == true))
                    {
                        parent.SetChecked(isChecked);
                    }
                    else
                    {
                        parent.SetChecked(null);
                    }
                }
                else
                {
                    if (children.Any(item => item.IsChecked != false))
                    {
                        parent.SetChecked(null);
                    }
                    else
                    {
                        parent.SetChecked(isChecked);
                    }
                }
            }
            CheckParent(parent, isChecked);
        }

        protected void RaiseCheckedChanged(IFile file)
        {
            if (!ItemCheckedChanged.IsNull())
            {
                ItemCheckedChanged(this, new ContentEventArgs<IFile>(file));
            }
        }

        static IDictionary<string, Tuple<ImageSource, string, string>> iconCache = new Dictionary<string, Tuple<ImageSource, string, string>>();
        internal static Tuple<ImageSource, string, string> GetIcon(string path, FileAttributes attr)
        {
            Tuple<ImageSource, string, string> result = null;
            if (path.IsNullOrEmpty())
            {
                return result;
            }

            string fileExt = Path.GetExtension(path);
            if (!fileExt.IsNullOrEmpty() && iconCache.ContainsKey(fileExt))
            {
                result = iconCache[fileExt];
            }
            else
            {
                result = DataSourceShell.LoadFileInfoByPath(path, attr);
                if (!result.IsNull() && !fileExt.IsNullOrEmpty())
                {
                    iconCache[fileExt] = result;
                }
            }
            return result;
        }

        protected static string GetTypeName(string path)
        {
            string result = null;
            if (path.IsNullOrEmpty())
            {
                return result;
            }

            string fileExt = Path.GetExtension(path);
            if (!fileExt.IsNullOrEmpty() && iconCache.ContainsKey(fileExt))
            {
                result = iconCache[fileExt].Item3;
            }
            return result;
        }

        protected override void OnDisposing(bool isDisposing)
        {
            this.FullPath = null;
            this.icon = null;
            this.parent = null;
        }

        /// <summary>
        /// Clone value members without ref members
        /// </summary>
        /// <returns></returns>
        public abstract object Clone();

        protected void CloneMembers(FileBase destFile)
        {
            if (destFile == null)
            {
                return;
            }

            destFile.fullPath = this.FullPath;
            ///Don't set the parent property
            ///else the item checked in search view will checked the parent too            
            destFile.folderPath = this.FolderPath;
            destFile.name = this.Name;
            destFile.extension = this.Extension;
            destFile.size = this.Size;
            destFile.lastModifyTime = this.LastModifyTime;
            destFile.icon = this.icon;
        }
    }
}
