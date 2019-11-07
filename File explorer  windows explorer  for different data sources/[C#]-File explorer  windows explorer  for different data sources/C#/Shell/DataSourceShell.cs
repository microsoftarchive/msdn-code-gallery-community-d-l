
using FileExplorer.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FileExplorer.Shell
{
    /// <summary>
    /// Special folder type enums 
    /// </summary>
    public enum SpecialFolderType
    {
        None = 0,
        MyComputerControlPanel,
        Internet,
        RecycleBin,
        MyComputer,
        Network,
        SharedDocuments,
        MyDocuments,
        DesktopControlPanel,
        CurrentUserProfile
    };

    /// <summary>
    /// Class is used to handle the ishell data source
    /// </summary>
    public class DataSourceShell : IDisposable
    {
        #region memeber data

        bool _blibrary = false;

        const int PAGE_SIZE = 10;

        bool hasSubFolder;

        // Sets a flag specifying whether or not we've got the IShellFolder interface for the Desktop.
        private static Boolean haveRootShell = false;
        private bool isRoot = false;

        bool isFileSystem = false;

        #endregion

        #region Constructor
        static DataSourceShell()
        {
            GetSpecialFolders();
        }

        /// <summary>
        /// Constructor. Creates the ShellItem object for the Desktop.
        /// </summary>
        public DataSourceShell()
        {
            // new ShellItem() can only be called once.
            int result;
            if (!haveRootShell)
            {
                //throw new Exception("The Desktop shell item already exists so cannot be created again.");

                // Obtain the root IShellFolder interface.
                result = ShellAPI.SHGetDesktopFolder(ref shellRoot);
                if (result != 0)
                    Marshal.ThrowExceptionForHR(result);
            }
            try
            {
                // Now get the PIDL for the Desktop shell item.
                result = ShellAPI.SHGetSpecialFolderLocation(IntPtr.Zero, ShellAPI.CSIDL.CSIDL_DESKTOP, ref ptrIDL);
                if (result != 0)
                    Marshal.ThrowExceptionForHR(result);
            }
            catch (Exception ex)
            {
                LogHelper.Debug("ShellAPI.SHGetSpecialFolderLocation Failed", ex);
            }

            isRoot = true;
            isFolder = true;
            hasSubFolder = true;
            shellItemPath = GetPath();

            // Internal with no set{} mutator.
            shellFolder = RootShellFolder;
            haveRootShell = true;

            LoadFileInfo(ptrIDL);

            // AH: Get pidl of desktop Control Panel 
            string ControlPanelGUID = ShellAPI.ControlPanelGUID;
            uint cParsed = 0;
            uint pdwAttrib = 0;
            IntPtr pIDL = IntPtr.Zero;
            if (shellFolder.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, ControlPanelGUID, out cParsed, out pIDL, ref pdwAttrib) == 0)
                listSpecialFolders.Add(new SPECIAL_FOLDER { FolderType = SpecialFolderType.DesktopControlPanel, PIDL = pIDL });
        }

        /// <summary>
        /// Constructor. Create a sub-item shell item object.
        /// </summary>
        /// <param name="shFolder">IShellFolder interface of the Desktop</param>
        /// <param name="pIDL">The fully qualified PIDL for this shell item</param>
        /// <param name="shellDesktop">The ShellItem object for desktop</param>
        public DataSourceShell(ShellAPI.IShellFolder shellDesktop, IntPtr pIDL, DataSourceShell shellParent, bool hasOnlyFolders, SpecialFolderType folderType)
        {
            _specialFolderType = folderType;

            // We need the Desktop shell item to exist first.
            if (haveRootShell == false)
                throw new Exception("The root shell item must be created before creating a sub-item");

            // Create the FQ PIDL for this new item.
            ptrIDL = ShellAPI.ILCombine(shellParent.PIDL, pIDL);

            shellItemPath = GetPath();

            // Get the properties of this item.
            ShellAPI.SFGAOF uFlags =
                ShellAPI.SFGAOF.SFGAO_FOLDER |
                //ShellAPI.SFGAOF.SFGAO_HASSUBFOLDER |
                ShellAPI.SFGAOF.SFGAO_BROWSABLE |
                ShellAPI.SFGAOF.SFGAO_STREAM |
                ShellAPI.SFGAOF.SFGAO_LINK |
                ShellAPI.SFGAOF.SFGAO_FILESYSTEM |
                ShellAPI.SFGAOF.SFGAO_HIDDEN |
                ShellAPI.SFGAOF.SFGAO_REMOVABLE
                ;

            // Here we get some basic attributes.
            uint result = shellParent.shellFolder.GetAttributesOf(1, ref pIDL, ref uFlags);
            isFolder = Convert.ToBoolean(uFlags & ShellAPI.SFGAOF.SFGAO_FOLDER);
            hasSubFolder = Convert.ToBoolean(uFlags & ShellAPI.SFGAOF.SFGAO_HASSUBFOLDER);
            IsBrowsable = Convert.ToBoolean(uFlags & ShellAPI.SFGAOF.SFGAO_BROWSABLE);
            IsStream = Convert.ToBoolean(uFlags & ShellAPI.SFGAOF.SFGAO_STREAM);
            IsLink = Convert.ToBoolean(uFlags & ShellAPI.SFGAOF.SFGAO_LINK);
            isFileSystem = Convert.ToBoolean(uFlags & ShellAPI.SFGAOF.SFGAO_FILESYSTEM);
            IsHidden = Convert.ToBoolean(uFlags & ShellAPI.SFGAOF.SFGAO_HIDDEN);
            IsRemovable = Convert.ToBoolean(uFlags & ShellAPI.SFGAOF.SFGAO_REMOVABLE);

            ShellAPI.IShellItem pshellitem;
            if (ShellAPI.SHCreateShellItem(IntPtr.Zero, null, PIDL, out pshellitem) == 0)
            {
                Int32 length = 0;
            }

            IntPtr parseString = IntPtr.Zero;
            pshellitem.GetDisplayName(ShellAPI.SIGDN.SIGDN_DESKTOPABSOLUTEPARSING, out parseString);
            this.ParsingName = Marshal.PtrToStringAuto(parseString);

            LoadFileInfo(ptrIDL);
            //  [1/18/2010 jozhang #92129]
            //when IsStream and isFolder is true,it means the file is .cab or .zip so isFolder should be changed to false;
            if (IsStream && isFolder) isFolder = false; // In case of zip 

            try
            {
                // Create the IShellFolder interface for this item.
                if (IsFolder)
                {
                    result = shellParent.shellFolder.BindToObject(pIDL, IntPtr.Zero, ref ShellAPI.IID_IShellFolder, out shellFolder);
                    if (result != 0)
                        Marshal.ThrowExceptionForHR((int)result);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Debug("shellParent.shellFolder.BindToObject Failed", ex);
            }
        }

        public DataSourceShell(ShellAPI.IShellItem psiDirectory)
        {
            if (haveRootShell == false)
                throw new Exception("The root shell item must be created before creating a sub-item");

            ShellAPI.SFGAO sfgAttribs;
            if (psiDirectory.GetAttributes(ShellAPI.SFGAO.SFGAO_FILESYSTEM, out sfgAttribs) == 0)
            {
                string pszSelection;
                IntPtr pszDisplay = IntPtr.Zero;
                if (psiDirectory.GetDisplayName(ShellAPI.SIGDN.SIGDN_NORMALDISPLAY, out pszDisplay) == 0)
                {
                    if (pszDisplay != IntPtr.Zero)
                    {
                        pszSelection = Marshal.PtrToStringAuto(pszDisplay);
                        DisplayName = pszSelection;
                    }
                }

                isFolder = true; // for display it as a folder.
                hasSubFolder = Convert.ToBoolean(sfgAttribs & ShellAPI.SFGAO.SFGAO_HASSUBFOLDER);
                IsBrowsable = Convert.ToBoolean(sfgAttribs & ShellAPI.SFGAO.SFGAO_BROWSABLE);
                IsStream = Convert.ToBoolean(sfgAttribs & ShellAPI.SFGAO.SFGAO_STREAM);
                IsLink = Convert.ToBoolean(sfgAttribs & ShellAPI.SFGAO.SFGAO_LINK);
                isFileSystem = Convert.ToBoolean(sfgAttribs & ShellAPI.SFGAO.SFGAO_FILESYSTEM);
                IsHidden = Convert.ToBoolean(sfgAttribs & ShellAPI.SFGAO.SFGAO_HIDDEN);
                IsRemovable = Convert.ToBoolean(sfgAttribs & ShellAPI.SFGAO.SFGAO_REMOVABLE);

                LoadFileInfo(DisplayName, 0);

                try
                {
                    //Int32 result = ShellAPI.ItemBindToHandler(psiDirectory, out shellFolder);
                    //if (result != 0)
                    //    Marshal.ThrowExceptionForHR((int)result);
                    IntPtr pIDL = IntPtr.Zero;
                    if (ShellAPI.ILCreateFromPath(psiDirectory, out pIDL) == 0)
                    {
                        ptrIDL = pIDL;
                        shellItemPath = GetPath();
                        LoadFileInfo(ptrIDL);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Debug("ShellAPI.ILCreateFromPath Failed", ex);
                }
            }
        }

        #endregion

        #region private method
        /// <summary>
        /// Gets the system path for this shell item.
        /// </summary>
        /// <returns>A path string.</returns>
        string GetPath()
        {
            // AH: Increasing size of buffer to properly read files having filenames with max length
            StringBuilder buffer = new StringBuilder(512);
            ShellAPI.SHGetPathFromIDList(
                ptrIDL,
                buffer
            );
            return buffer.ToString();
        }

        /// <summary>
        /// Gets the page.
        /// </summary>
        /// <param name="getNextPage">if set to <c>true</c> [get next page].</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        List<DataSourceShell> GetPage(ShellAPI.IEnumIDList pEnum)
        {
            IntPtr pIDLChild = IntPtr.Zero;
            Int32 iGotChild = 0;
            List<DataSourceShell> lst = new List<DataSourceShell>();
            pEnum.Next(1, out pIDLChild, out iGotChild);
            while (!pIDLChild.Equals(IntPtr.Zero) && iGotChild == 1)
            {
                SpecialFolderType specialFolderType = CheckSpecialFolderType(shellFolder, ptrIDL, pIDLChild);
                if (specialFolderType != SpecialFolderType.Internet &&
                    specialFolderType != SpecialFolderType.RecycleBin &&
                    specialFolderType != SpecialFolderType.MyComputerControlPanel &&
                    specialFolderType != SpecialFolderType.DesktopControlPanel &&
                    (SpecialFolderType != SpecialFolderType.MyComputer ||
                    (specialFolderType != SpecialFolderType.MyDocuments &&
                    specialFolderType != SpecialFolderType.SharedDocuments))
                    )
                {
                    // Create the new ShellItem object.
                    DataSourceShell shItem = new DataSourceShell(shellRoot, pIDLChild, this, false, specialFolderType);
                    if (shItem.IsFolder && !shItem.IsStream)
                    {
                        lst.Add(shItem);
                    }
                }

                // Free the PIDL and reset counters.
                Marshal.FreeCoTaskMem(pIDLChild);
                pIDLChild = IntPtr.Zero;
                iGotChild = 0;

                // Grab the next item.
                pEnum.Next(1, out pIDLChild, out iGotChild);
            }

            if (this.SpecialFolderType != SpecialFolderType.MyComputer)
            {
                List<DataSourceShell> tempLst = new List<DataSourceShell>();
                IComparer<DataSourceShell> comparer = new SortAscending();
                for (int i = 0; isRoot && i < lst.Count; i++)
                {
                    if (lst[i].SpecialFolderType == SpecialFolderType.MyComputer ||
                        lst[i].SpecialFolderType == SpecialFolderType.DesktopControlPanel ||
                        lst[i].SpecialFolderType == SpecialFolderType.Network ||
                        lst[i].SpecialFolderType == SpecialFolderType.MyDocuments ||
                        lst[i].SpecialFolderType == SpecialFolderType.SharedDocuments ||
                        lst[i].SpecialFolderType == SpecialFolderType.CurrentUserProfile
                        )
                    {
                        tempLst.Add(lst[i]);
                        lst.RemoveAt(i);
                        i--;
                    }
                }
                lst.Sort(comparer);
                for (int i = 0; isRoot && i < tempLst.Count; i++)
                    lst.Insert(i, tempLst[i]);
            }
            return lst;
        }

        /// <summary>
        /// Checks the type of the special folder.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="parentPIDL">The parent PIDL.</param>
        /// <param name="pidl">The pidl.</param>
        /// <returns></returns>
        SpecialFolderType CheckSpecialFolderType(ShellAPI.IShellFolder parent, IntPtr parentPIDL, IntPtr pidl)
        {
            IntPtr pIDLCombined = ShellAPI.ILCombine(parentPIDL, pidl);
            for (int i = 0; i < listSpecialFolders.Count; i++)
            {
                if (shellRoot.CompareIDs(0, listSpecialFolders[i].PIDL, pIDLCombined) == 0)
                {
                    return listSpecialFolders[i].FolderType;
                }
            }
            return SpecialFolderType.None;
        }


        /// <summary>
        /// Load file information, dislpay name, icon, file type from shell
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="attr">The attr.</param>
        void LoadFileInfo(string path, FileAttributes attr)
        {
            //TT91027 - The folder's icon doesn't display in the content list while restore the backup job which target is FTP.
            //change ftp path '/' to '\' for XP.
            path = path.Replace('/', '\\');
            ShellAPI.SHFILEINFO shellInfo = new ShellAPI.SHFILEINFO();
            ShellAPI.SHGFI vFlags =
                ShellAPI.SHGFI.SHGFI_SMALLICON |
                ShellAPI.SHGFI.SHGFI_ICON |
                ShellAPI.SHGFI.SHGFI_USEFILEATTRIBUTES |
                ShellAPI.SHGFI.SHGFI_DISPLAYNAME |
                ShellAPI.SHGFI.SHGFI_TYPENAME;
            ShellAPI.SHGetFileInfo(path, (uint)attr, ref shellInfo, (uint)Marshal.SizeOf(shellInfo), vFlags);
            DisplayName = shellInfo.szDisplayName;
            if (shellInfo.hIcon != IntPtr.Zero)
            {
                Icon = GetImageSourceFromIcon(shellInfo.hIcon);
                ShellAPI.DestroyIcon(shellInfo.hIcon);
                shellInfo.hIcon = IntPtr.Zero;
            }
            TypeName = shellInfo.szTypeName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="attr"></param>
        /// <returns>image,displayname,typename</returns>
        public static Tuple<ImageSource, string, string> LoadFileInfoByPath(string path, FileAttributes attr = 0)
        {
            ImageSource icon = null;
            //TT91027 - The folder's icon doesn't display in the content list while restore the backup job which target is FTP.
            //change ftp path '/' to '\' for XP.
            path = path.Replace('/', '\\');
            ShellAPI.SHFILEINFO shellInfo = new ShellAPI.SHFILEINFO();
            ShellAPI.SHGFI vFlags =
                ShellAPI.SHGFI.SHGFI_SMALLICON |
                ShellAPI.SHGFI.SHGFI_ICON |
                ShellAPI.SHGFI.SHGFI_USEFILEATTRIBUTES |
                ShellAPI.SHGFI.SHGFI_DISPLAYNAME |
                ShellAPI.SHGFI.SHGFI_TYPENAME;
            ShellAPI.SHGetFileInfo(path, (uint)attr, ref shellInfo, (uint)Marshal.SizeOf(shellInfo), vFlags);
            string displayName = shellInfo.szDisplayName;
            if (shellInfo.hIcon != IntPtr.Zero)
            {
                icon = GetImageSourceFromIcon(shellInfo.hIcon);
                ShellAPI.DestroyIcon(shellInfo.hIcon);
                shellInfo.hIcon = IntPtr.Zero;
            }
            string typeName = shellInfo.szTypeName;
            return new Tuple<ImageSource, string, string>(icon, displayName, typeName);
        }

        /// <summary>
        /// Load file information, dislpay name, icon, file type from shell
        /// </summary>
        /// <param name="pidl">The pidl.</param>
        void LoadFileInfo(IntPtr pidl)
        {
            ShellAPI.SHFILEINFO shellInfo = new ShellAPI.SHFILEINFO();
            ShellAPI.SHGFI vFlags =
                ShellAPI.SHGFI.SHGFI_SMALLICON |
                ShellAPI.SHGFI.SHGFI_ICON |
                ShellAPI.SHGFI.SHGFI_PIDL |
                ShellAPI.SHGFI.SHGFI_DISPLAYNAME |
                ShellAPI.SHGFI.SHGFI_TYPENAME |
                ShellAPI.SHGFI.SHGFI_ADDOVERLAYS;
            ShellAPI.SHGetFileInfo(pidl, 0, ref shellInfo, (uint)Marshal.SizeOf(shellInfo), vFlags);
            DisplayName = shellInfo.szDisplayName;
            if (shellInfo.hIcon != IntPtr.Zero)
            {
                Icon = GetImageSourceFromIcon(shellInfo.hIcon);
                ShellAPI.DestroyIcon(shellInfo.hIcon);
                shellInfo.hIcon = IntPtr.Zero;
            }
            TypeName = shellInfo.szTypeName;
        }

        static System.Windows.Media.ImageSource GetImageSourceFromIcon(IntPtr hIcon)
        {
            try
            {
                if (hIcon == IntPtr.Zero)
                    return null;

                ImageSource img = Imaging.CreateBitmapSourceFromHIcon(
                        hIcon,
                        Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions());
                img.Freeze();
                return img;
            }
            catch (ArgumentException exp)
            {
                LogHelper.Debug("GetImageSourceFromIcon Failed", exp);
            }
            catch (Exception ex)
            {
                LogHelper.Debug("GetImageSourceFromIcon Failed", ex);
            }
            return null;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="DataSourceShell"/> is reclaimed by garbage collection.
        /// </summary>
        ~DataSourceShell()
        {
            Dispose(false);
        }
        #endregion

        #region static variable
        static List<SPECIAL_FOLDER> listSpecialFolders = new List<SPECIAL_FOLDER>();
        #endregion

        #region static method

        /// <summary>
        /// Gets special folder type, like internet, drives, network etc
        /// </summary>
        private static void GetSpecialFolders()
        {
            IntPtr pidl = IntPtr.Zero;

            pidl = IntPtr.Zero;
            ShellAPI.SHGetSpecialFolderLocation(IntPtr.Zero, ShellAPI.CSIDL.CSIDL_INTERNET,
                ref pidl);
            listSpecialFolders.Add(new SPECIAL_FOLDER { FolderType = SpecialFolderType.Internet, PIDL = pidl });

            pidl = IntPtr.Zero;
            ShellAPI.SHGetSpecialFolderLocation(IntPtr.Zero, ShellAPI.CSIDL.CSIDL_BITBUCKET,
                ref pidl);
            listSpecialFolders.Add(new SPECIAL_FOLDER { FolderType = SpecialFolderType.RecycleBin, PIDL = pidl });

            pidl = IntPtr.Zero;
            ShellAPI.SHGetSpecialFolderLocation(IntPtr.Zero, ShellAPI.CSIDL.CSIDL_DRIVES,
                ref pidl);
            listSpecialFolders.Add(new SPECIAL_FOLDER { FolderType = SpecialFolderType.MyComputer, PIDL = pidl });

            pidl = IntPtr.Zero;
            ShellAPI.SHGetSpecialFolderLocation(IntPtr.Zero, ShellAPI.CSIDL.CSIDL_NETWORK,
                ref pidl);
            listSpecialFolders.Add(new SPECIAL_FOLDER { FolderType = SpecialFolderType.Network, PIDL = pidl });

            pidl = IntPtr.Zero;
            ShellAPI.SHGetSpecialFolderLocation(IntPtr.Zero, ShellAPI.CSIDL.CSIDL_COMMON_DOCUMENTS,
                ref pidl);
            listSpecialFolders.Add(new SPECIAL_FOLDER { FolderType = SpecialFolderType.SharedDocuments, PIDL = pidl });

            pidl = IntPtr.Zero;
            ShellAPI.SHGetSpecialFolderLocation(IntPtr.Zero, ShellAPI.CSIDL.CSIDL_PERSONAL,
                ref pidl);
            listSpecialFolders.Add(new SPECIAL_FOLDER { FolderType = SpecialFolderType.MyDocuments, PIDL = pidl });

            pidl = IntPtr.Zero;
            ShellAPI.SHGetSpecialFolderLocation(IntPtr.Zero, ShellAPI.CSIDL.CSIDL_CONTROLS,
                ref pidl);
            listSpecialFolders.Add(new SPECIAL_FOLDER { FolderType = SpecialFolderType.MyComputerControlPanel, PIDL = pidl });

            pidl = IntPtr.Zero;
            ShellAPI.SHGetSpecialFolderLocation(IntPtr.Zero, ShellAPI.CSIDL.CSIDL_PROFILE,
                ref pidl);
            listSpecialFolders.Add(new SPECIAL_FOLDER { FolderType = SpecialFolderType.CurrentUserProfile, PIDL = pidl });
        }

        #endregion

        #region Public Methods

        public const string ComputerParseName = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";

        /// <summary>
        /// get sub shell items for path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DataSourceShell GetShellItem(string path)
        {
            if (!Directory.Exists(path)) return null;

            try
            {
                DataSourceShell shell = new DataSourceShell();
                var items = shell.GetSubItems();
                var rootNode = items.FirstOrDefault(o => o.ParsingName == ComputerParseName);
                bool isStop = false;
                DataSourceShell targetShell = null;
                while (!isStop)
                {
                    var shells = rootNode.GetSubItems();

                    targetShell = shells.FirstOrDefault(o => CheckIsTopLevel(o.Path, path));
                    if (targetShell.Path.Equals(path))
                        isStop = true;
                    rootNode = targetShell;
                }
                return targetShell;
            }
            catch (Exception ex)
            {
                LogHelper.Debug(ex.Message);
                return null;
            }
        }

        /// <summary>
        ///  check father path or grand-father path.
        ///  if same ,return true
        /// </summary>
        /// <param name="topPath">check parent path</param>
        /// <param name="subPath">check sub path</param>
        /// <returns></returns>
        public static bool CheckIsTopLevel(string topPath, string subPath)
        {
            if (topPath == null || subPath == null) return false;
            if (string.Compare(topPath, subPath, StringComparison.OrdinalIgnoreCase) == 0) return true;

            var parentArray = topPath.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
            var subArray = subPath.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
            if (parentArray.Length > subArray.Length) return false;
            for (int i = 0; i < parentArray.Length; i++)
            {
                if (!string.Equals(parentArray[i], subArray[i], StringComparison.CurrentCultureIgnoreCase)) return false;
            }
            return true;
        }

        /// <summary>
        /// Retrieves an array of ShellItem objects for sub-folders of this shell item.
        /// always sub-folders, non file
        /// </summary>
        /// <returns>ArrayList of ShellItem objects.</returns>
        public List<DataSourceShell> GetSubItems()
        {
            //this._getfolders = getfolders;

            //T#81733 - BIU support for Windows 7 libraries and the new Windows 7 open file dialog 

            if (this._blibrary) //support for windows 7 library
            {
                List<DataSourceShell> lst = new List<DataSourceShell>();
                ShellAPI.IShellItem psi;
                if (ShellAPI.SHCreateShellItem(IntPtr.Zero, null, PIDL, out psi) == 0)
                {
                    Int32 length = 0;
                    if (ShellAPI.SHLoadLibraryFromItem(psi, ref length) == 0)
                    {
                        for (int i = 0; i <= length; i++)
                        {
                            ShellAPI.IShellItem psiarry;
                            if (ShellAPI.SHGetShellItemsAt(psi, i, out psiarry) == 0)
                            {
                                DataSourceShell shItem = new DataSourceShell(psiarry);
                                lst.Add(shItem);
                            }
                        }
                        return lst;
                    }
                }
                return lst;
            }
            else
            {
                // Make sure we have a folder.
                if (IsFolder == false)
                    throw new Exception("Unable to retrieve sub-folders for a non-folder.");

                // Get the IEnumIDList interface pointer.
                ShellAPI.SHCONTF flags =
                    ShellAPI.SHCONTF.SHCONTF_INCLUDEHIDDEN;
                flags |= ShellAPI.SHCONTF.SHCONTF_FOLDERS;

                ShellAPI.IEnumIDList pEnum = null;
                if (ShellFolder != null)
                {
                    uint result = ShellFolder.EnumObjects(IntPtr.Zero,
                        flags
                        , out pEnum);
                    if (result == 0)
                    {
                        List<DataSourceShell> lst = GetPage(pEnum);
                        if (pEnum != null)
                            Marshal.ReleaseComObject(pEnum);
                        return lst;
                    }
                }
                return new List<DataSourceShell>();
            }
        }

        public List<DataSourceShell> GetFolderByPage(int pageSize, int pageindex, out bool isEndPage)
        {
            ShellAPI.IEnumIDList shllEnum = null;
            IntPtr ptrIDLChild = IntPtr.Zero;
            Int32 isGotChild = 0;


            List<DataSourceShell> lst = new List<DataSourceShell>();
            LogHelper.DebugFormat("shell GetFolderByPage ==>{0}", this.ParsingName);

            if (this._blibrary) //support for windows 7 library
            {
                #region For library
                ShellAPI.IShellItem psi;
                if (ShellAPI.SHCreateShellItem(IntPtr.Zero, null, PIDL, out psi) == 0)
                {
                    Int32 length = 0;
                    if (ShellAPI.SHLoadLibraryFromItem(psi, ref length) == 0)
                    {
                        for (int i = 0; i <= length; i++)
                        {
                            ShellAPI.IShellItem psiarry;
                            if (ShellAPI.SHGetShellItemsAt(psi, i, out psiarry) == 0)
                            {
                                DataSourceShell shItem = new DataSourceShell(psiarry);
                                lst.Add(shItem);
                            }
                        }
                        isEndPage = true;
                        return lst;
                    }
                }
                #endregion
            }


            #region init
            isEndPage = false;
            // Get the IEnumIDList interface pointer.
            ShellAPI.SHCONTF flags = ShellAPI.SHCONTF.SHCONTF_FOLDERS;
            if (shllEnum != null)
                Marshal.ReleaseComObject(shllEnum);

            uint result = ShellFolder.EnumObjects(IntPtr.Zero,
                flags
                , out shllEnum);

            if (result != 0)
            {
                isEndPage = true;
                LogHelper.Debug("result != 0   ==> true");
                return null;
            }
            #endregion

            #region reset enum
            ptrIDLChild = IntPtr.Zero;
            isGotChild = 0;
            shllEnum.Reset();
            #endregion

            #region skip pageIndex*pageSize
            // Grab the first enumeration.
            for (int i = 0; i <= ((pageindex - 1) * pageSize); i++)
            {
                // Free the PIDL and reset counters.
                Marshal.FreeCoTaskMem(ptrIDLChild);
                ptrIDLChild = IntPtr.Zero;
                isGotChild = 0;

                // Grab the next item.
                shllEnum.Next(1, out ptrIDLChild, out isGotChild);
            }
            #endregion

            LogHelper.Debug("enum .....");

            #region enum item

            int itemIndex = 0;
            while (itemIndex < pageSize)
            {
                SpecialFolderType specialFolderType = CheckSpecialFolderType(shellFolder, ptrIDL, ptrIDLChild);
                if (specialFolderType != SpecialFolderType.Internet &&
                    specialFolderType != SpecialFolderType.RecycleBin &&
                    specialFolderType != SpecialFolderType.MyComputerControlPanel &&
                    specialFolderType != SpecialFolderType.DesktopControlPanel &&
                    (SpecialFolderType != SpecialFolderType.MyComputer ||
                    (specialFolderType != SpecialFolderType.MyDocuments &&
                    specialFolderType != SpecialFolderType.SharedDocuments))
                    )
                {
                    LogHelper.DebugFormat("enum-1   : {0}", ptrIDLChild);
                    // Create the new ShellItem object.
                    DataSourceShell shItem = new DataSourceShell(shellRoot, ptrIDLChild, this, false, specialFolderType);
                    if (shItem.IsFolder && !shItem.IsStream)
                    {
                        lst.Add(shItem);
                    }

                    LogHelper.DebugFormat("enum  : {0}", shItem.ParsingName);
                }
                // Free the PIDL and reset counters.
                Marshal.FreeCoTaskMem(ptrIDLChild);
                ptrIDLChild = IntPtr.Zero;
                isGotChild = 0;

                // Grab the next item.
                shllEnum.Next(1, out ptrIDLChild, out isGotChild);
                if (ptrIDLChild.Equals(IntPtr.Zero) && isGotChild == 0)
                {
                    LogHelper.Debug("ptrIDLChild.Equals(IntPtr.Zero) && iGotChild == 0   ==> true");
                    isEndPage = true;
                    break;
                }
                itemIndex++;
            }
            #endregion

            LogHelper.Debug("enum <==");
            #region sort item
            // AH: If _getfolders flag is true, sort treeview items.
            if (this.SpecialFolderType != SpecialFolderType.MyComputer)
            {
                List<DataSourceShell> tempLst = new List<DataSourceShell>();
                IComparer<DataSourceShell> comparer = new SortAscending();
                for (int i = 0; isRoot && i < lst.Count; i++)
                {
                    if (lst[i].SpecialFolderType == SpecialFolderType.MyComputer ||
                        lst[i].SpecialFolderType == SpecialFolderType.DesktopControlPanel ||
                        lst[i].SpecialFolderType == SpecialFolderType.Network ||
                        lst[i].SpecialFolderType == SpecialFolderType.MyDocuments ||
                        lst[i].SpecialFolderType == SpecialFolderType.SharedDocuments ||
                        lst[i].SpecialFolderType == SpecialFolderType.CurrentUserProfile
                        )
                    {
                        tempLst.Add(lst[i]);
                        lst.RemoveAt(i);
                        i--;
                    }
                }
                lst.Sort(comparer);
                for (int i = 0; isRoot && i < tempLst.Count; i++)
                    lst.Insert(i, tempLst[i]);
            }
            #endregion
            LogHelper.Debug("enum end==");
            return lst;
        }

        public override string ToString()
        {
            return "DataSourceShell" + this.Path.ToString();
        }
        #endregion

        #region public Properties

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
        public string DisplayName { get; set; }           // Dispaly name of file / folder

        /// <summary>
        /// Gets or sets the name of the file / folder type.
        /// </summary>
        /// <value>The name of the file / folder type.</value>
        public string TypeName { get; protected set; }              // Display file / folder type

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        public ImageSource Icon { get; set; }             // Icon of file / folder

        bool isFolder = false;
        /// <summary>
        /// Gets or sets a boolean indicating whether this shell item is a folder.
        /// </summary>
        public bool IsFolder
        {
            get { return isFolder; }
        }


        /// <summary>
        /// Gets the IShellFolder interface of the Desktop.
        /// </summary>
        public ShellAPI.IShellFolder RootShellFolder
        {
            get { return shellRoot; }
        }
        static ShellAPI.IShellFolder shellRoot = null;

        /// <summary>
        /// Gets the IShellFolder interface of this shell item.
        /// </summary>
        public ShellAPI.IShellFolder ShellFolder
        {
            get { return shellFolder; }
        }
        ShellAPI.IShellFolder shellFolder = null;

        /// <summary>
        /// Gets the fully qualified PIDL for this shell item.
        /// </summary>
        public IntPtr PIDL
        {
            get { return ptrIDL; }
        }
        IntPtr ptrIDL = IntPtr.Zero;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is stream.
        /// </summary>
        /// <value><c>true</c> if this instance is stream; otherwise, <c>false</c>.</value>
        public bool IsStream { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is browsable.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is browsable; otherwise, <c>false</c>.
        /// </value>
        public bool IsBrowsable { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is link.
        /// </summary>
        /// <value><c>true</c> if this instance is link; otherwise, <c>false</c>.</value>
        public bool IsLink { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is hidden.
        /// </summary>
        /// <value><c>true</c> if this instance is hidden; otherwise, <c>false</c>.</value>
        public bool IsHidden { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is removable.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is removable; otherwise, <c>false</c>.
        /// </value>
        public bool IsRemovable { get; private set; }

        SpecialFolderType _specialFolderType = SpecialFolderType.None;

        /// <summary>
        /// Gets the type of the special folder.
        /// </summary>
        /// <value>The type of the special folder.</value>
        public SpecialFolderType SpecialFolderType { get { return _specialFolderType; } }

        /// <summary>
        /// Gets or sets the system path for this shell item.
        /// </summary>
        public string Path
        {
            get { return shellItemPath; }
        }
        string shellItemPath = "";

        /// <summary>
        /// identifer for shell object
        /// </summary>
        public string ParsingName { get; set; }

        public int FoldersCount
        {
            get
            {
                return 0;
            }
        }


        #endregion

        #region class
        /// <summary>
        /// AH: For comparison of treeview items in ascending order 
        /// </summary>
        private class SortAscending : IComparer<DataSourceShell>
        {
            #region IComparer<DataSourceShell> Members

            /// <summary>
            /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
            /// </summary>
            /// <param name="x">The first object to compare.</param>
            /// <param name="y">The second object to compare.</param>
            /// <returns>
            /// Value
            /// Condition
            /// Less than zero
            /// <paramref name="x"/> is less than <paramref name="y"/>.
            /// Zero
            /// <paramref name="x"/> equals <paramref name="y"/>.
            /// Greater than zero
            /// <paramref name="x"/> is greater than <paramref name="y"/>.
            /// </returns>
            public int Compare(DataSourceShell x, DataSourceShell y)
            {
                return String.Compare(x.DisplayName, y.DisplayName, StringComparison.OrdinalIgnoreCase);
            }

            #endregion
        }
        #endregion

        #region struct
        public struct SPECIAL_FOLDER
        {
            public IntPtr PIDL { get; set; }
            public SpecialFolderType FolderType { get; set; }

        };
        #endregion

        #region IDisposable Members
        protected virtual void Dispose(bool isDisposing)
        {
            try
            {
                // Free the PIDL too.
                if (!ptrIDL.Equals(IntPtr.Zero))
                    Marshal.FreeCoTaskMem(ptrIDL);
            }
            catch (Exception ex)
            {
                LogHelper.Debug("Exception:", ex);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
