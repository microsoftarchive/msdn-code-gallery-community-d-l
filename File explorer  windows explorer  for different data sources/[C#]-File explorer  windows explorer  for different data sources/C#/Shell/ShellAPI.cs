
using System;
using System.Text;
using System.Runtime.InteropServices;

namespace FileExplorer.Shell
{
    /// <summary>
    /// Class for shell API
    /// </summary>
    public class ShellAPI
    {
        #region Constants

        public enum FO_Func : uint
        {
            FO_MOVE = 0x0001,
            FO_COPY = 0x0002,
            FO_DELETE = 0x0003,
            FO_RENAME = 0x0004,
        }

        public const ushort FOF_NOCONFIRMATION = 0x10;
        public const ushort FOF_ALLOWUNDO = 0x40;
        public const ushort FOF_NO_UI = 0x614;
        public const Int32 FILE_ATTRIBUTE_NORMAL = 0x80;
        public static Guid IID_IShellFolder = new Guid("000214E6-0000-0000-C000-000000000046");
        public static string ControlPanelGUID = "::{26EE0668-A00A-44D7-9371-BEB064C98683}";
        #endregion

        #region DLL Imports

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr pWnd, UInt32 uMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("shell32.dll")]
        public static extern Int32 SHGetDesktopFolder(ref IShellFolder ppshf);

        /// <summary>
        /// MI: Used for unicode and Ansi strings as it is from shell. 
        /// </summary>
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SHGetFileInfo([MarshalAs(UnmanagedType.LPWStr)] string pszPath, uint dwFileAttribs, ref SHFILEINFO psfi, uint cbFileInfo, SHGFI uFlags);

        /// <summary>
        /// MI: Used for unicode and Ansi strings as it is from shell. 
        /// </summary>
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SHGetFileInfo(IntPtr pIDL, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, SHGFI uFlags);

        [DllImport("User32.dll")]
        public static extern int DestroyIcon(IntPtr hIcon);

        [DllImport("shell32.dll")]
        public static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr pszPath);

        /// <summary>
        /// Used for get special folder location
        /// </summary>
        [DllImport("shell32.dll")]
        public static extern Int32 SHGetSpecialFolderLocation(IntPtr hwndOwner, CSIDL nFolder, ref IntPtr ppidl);

        [DllImport("shell32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool SHFileOperation([In, Out] SHFILEOPSTRUCT lpFileOp);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public class SHFILEOPSTRUCT
        {
            public IntPtr hwnd;
            public FO_Func wFunc;
            public string pFrom;
            public string pTo;
            public UInt16 fFlags;
            public Int32 fAnyOperationsAborted;
            public IntPtr hNameMappings;
            public string lpszProgressTitle;
        }

        [DllImport("LibraryBackup.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 Win7ILCreateFromPath(IShellItem ppsi,
            out IntPtr pidl
            );

        [DllImport("LibraryBackup.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 Win7SHLoadLibraryFromItem(
            IShellItem ppsi,
            ref Int32 nlength
        );


        [DllImport("LibraryBackup.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 Win7SHGetShellItemsAt(
            IShellItem ppsi,
            Int32 place,
            [MarshalAs(UnmanagedType.Interface)] out IShellItem shellitems
        );

        [DllImport("shell32.dll")]
        public static extern Int32 SHCreateShellItem(
            IntPtr pidlParent,
            [In, MarshalAs(UnmanagedType.Interface)] IShellFolder psfParent,
            IntPtr pidl,
            [MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi
        );


        /// <summary>
        /// Used for combine
        /// </summary>
        [DllImport("shell32.dll")]
        public static extern IntPtr ILCombine(IntPtr pIDLParent, IntPtr pIDLChild);

        /// <summary>
        /// MI: Used for unicode and Ansi strings as it is from shell. 
        /// </summary>
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern Int32 SHGetPathFromIDList(IntPtr pIDL, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder strPath);

        [DllImport("shell32.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr ShellExecute(
            IntPtr hwnd,
            string lpOperation,
            string lpFile,
            string lpParameters,
            string lpDirectory,
            ShowCommands nShowCmd);

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr ILCreateFromPath([In, MarshalAs(UnmanagedType.LPWStr)] string pszPath);

        [DllImport("Shell32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        static extern int SHLoadLibraryFromItem(
                    [In, MarshalAs(UnmanagedType.Interface)] IShellItem library,
                    [In] uint flags,
                    [In] ref Guid IID,
                    out IntPtr libraryObj);

        /// <summary>
        /// load library .if Xp, return 1 else return 0
        /// </summary>
        /// <param name="ppsi"></param>
        /// <param name="nlength"></param>
        /// <returns></returns>
        public static Int32 SHLoadLibraryFromItem(IShellItem ppsi, ref Int32 nlength)
        {
            try
            {
                // 5.0=2000 5.1=xp 6.0= vista 6.1=win7  
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    return Win7SHLoadLibraryFromItem(ppsi, ref nlength);
                }
                return 1;
            }
            catch (Exception ex)
            {
               // LogHelper.Debug("Exception:", ex);
                return 1;
            }
        }


        /// <summary>
        /// ILCreateFromPath fro win7
        /// </summary>
        /// <param name="ppsi"></param>
        /// <param name="pidl"></param>
        /// <returns></returns>
        public static Int32 ILCreateFromPath(IShellItem ppsi, out IntPtr pidl)
        {
            pidl = IntPtr.Zero;

            try
            {
                // 5.0=2000 5.1=xp 6.0= vista 6.1=win7  
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    return Win7ILCreateFromPath(ppsi, out pidl);
                }
                return 1;
            }
            catch (Exception ex)
            {
               // LogHelper.Debug("Exception:", ex);
                return 1;
            }
        }

        /// <summary>
        /// SHGetShellItemsAt for win7
        /// </summary>
        /// <param name="ppsi"></param>
        /// <param name="place"></param>
        /// <param name="shellitems"></param>
        /// <returns></returns>
        public static Int32 SHGetShellItemsAt(IShellItem ppsi, Int32 place,
            [MarshalAs(UnmanagedType.Interface)] out IShellItem shellitems)
        {
            shellitems = null;
            try
            {
                // 5.0=2000 5.1=xp 6.0= vista 6.1=win7  
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    return Win7SHGetShellItemsAt(ppsi, place, out shellitems);
                }
                return 1;
            }
            catch (Exception ex)
            {
               // LogHelper.Debug("Exception:", ex);
                return 1;
            }
        }

        // AH: Added function to get folder path by using CSIDL
        [DllImport("shfolder.dll", CharSet = CharSet.Auto)]
        public static extern int SHGetFolderPath(IntPtr hwndOwner, int nFolder, IntPtr hToken, int dwFlags, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpszPath);

        #endregion

        #region Enumerations

        [Flags]
        public enum SHGNO : uint
        {
            SHGDN_NORMAL = 0x0000,                 // Default (display purpose)
            SHGDN_INFOLDER = 0x0001,               // Displayed under a folder (relative)
            SHGDN_FOREDITING = 0x1000,             // For in-place editing
            SHGDN_FORADDRESSBAR = 0x4000,          // UI friendly parsing name (remove ugly stuff)
            SHGDN_FORPARSING = 0x8000,             // Parsing name for ParseDisplayName()
        }

        [Flags]
        public enum SHCONTF : uint
        {
            SHCONTF_FOLDERS = 0x0020,              // Only want folders enumerated (SFGAO_FOLDER)
            SHCONTF_NONFOLDERS = 0x0040,           // Include non folders
            SHCONTF_INCLUDEHIDDEN = 0x0080,        // Show items normally hidden
            SHCONTF_INIT_ON_FIRST_NEXT = 0x0100,   // Allow EnumObject() to return before validating enum
            SHCONTF_NETPRINTERSRCH = 0x0200,       // Hint that client is looking for printers
            SHCONTF_SHAREABLE = 0x0400,            // Hint that client is looking sharable resources (remote shares)
            SHCONTF_STORAGE = 0x0800,              // Include all items with accessible storage and their ancestors
            SHCONTF_FASTITEMS = 0x2000
        }

        [Flags]
        public enum SFGAOF : uint
        {
            SFGAO_CANCOPY = 0x1,                   // Objects can be copied  (DROPEFFECT_COPY)
            SFGAO_CANMOVE = 0x2,                   // Objects can be moved   (DROPEFFECT_MOVE)
            SFGAO_CANLINK = 0x4,                   // Objects can be linked  (DROPEFFECT_LINK)
            SFGAO_STORAGE = 0x00000008,            // Supports BindToObject(IID_IStorage)
            SFGAO_CANRENAME = 0x00000010,          // Objects can be renamed
            SFGAO_CANDELETE = 0x00000020,          // Objects can be deleted
            SFGAO_HASPROPSHEET = 0x00000040,       // Objects have property sheets
            SFGAO_DROPTARGET = 0x00000100,         // Objects are drop target
            SFGAO_CAPABILITYMASK = 0x00000177,
            SFGAO_ENCRYPTED = 0x00002000,          // Object is encrypted (use alt color)
            SFGAO_ISSLOW = 0x00004000,             // 'Slow' object
            SFGAO_GHOSTED = 0x00008000,            // Ghosted icon
            SFGAO_LINK = 0x00010000,               // Shortcut (link)
            SFGAO_SHARE = 0x00020000,              // Shared
            SFGAO_READONLY = 0x00040000,           // Read-only
            SFGAO_HIDDEN = 0x00080000,             // Hidden object
            SFGAO_DISPLAYATTRMASK = 0x000FC000,
            SFGAO_FILESYSANCESTOR = 0x10000000,    // May contain children with SFGAO_FILESYSTEM
            SFGAO_FOLDER = 0x20000000,             // Support BindToObject(IID_IShellFolder)
            SFGAO_FILESYSTEM = 0x40000000,         // Is a win32 file system object (file/folder/root)
            SFGAO_HASSUBFOLDER = 0x80000000,       // May contain children with SFGAO_FOLDER
            SFGAO_CONTENTSMASK = 0x80000000,
            SFGAO_VALIDATE = 0x01000000,           // Invalidate cached information
            SFGAO_REMOVABLE = 0x02000000,          // Is this removeable media?
            SFGAO_COMPRESSED = 0x04000000,         // Object is compressed (use alt color)
            SFGAO_BROWSABLE = 0x08000000,          // Supports IShellFolder, but only implements CreateViewObject() (non-folder view)
            SFGAO_NONENUMERATED = 0x00100000,      // Is a non-enumerated object
            SFGAO_NEWCONTENT = 0x00200000,         // Should show bold in explorer tree
            SFGAO_CANMONIKER = 0x00400000,         // Defunct
            SFGAO_HASSTORAGE = 0x00400000,         // Defunct
            SFGAO_STREAM = 0x00400000,             // Supports BindToObject(IID_IStream)
            SFGAO_STORAGEANCESTOR = 0x00800000,    // May contain children with SFGAO_STORAGE or SFGAO_STREAM
            SFGAO_STORAGECAPMASK = 0x70C50008,     // For determining storage capabilities, ie for open/save semantics            

            SFGAO_ALL = 0xFFFFFFFF
        }

        [Flags]
        public enum STRRET : uint
        {
            STRRET_WSTR = 0,
            STRRET_OFFSET = 0x1,
            STRRET_CSTR = 0x2,
        }

        [Flags]
        public enum SHGFI
        {
            SHGFI_ICON = 0x000000100,               //Retrieves the handle to the icon that represents the file and the index of the icon within the system image list.
            SHGFI_DISPLAYNAME = 0x000000200,
            SHGFI_TYPENAME = 0x000000400,
            SHGFI_ATTRIBUTES = 0x000000800,
            SHGFI_ICONLOCATION = 0x000001000,
            SHGFI_EXETYPE = 0x000002000,
            SHGFI_SYSICONINDEX = 0x000004000,
            SHGFI_LINKOVERLAY = 0x000008000,
            SHGFI_SELECTED = 0x000010000,
            SHGFI_ATTR_SPECIFIED = 0x000020000,
            SHGFI_LARGEICON = 0x000000000,
            SHGFI_SMALLICON = 0x000000001,
            SHGFI_OPENICON = 0x000000002,
            SHGFI_SHELLICONSIZE = 0x000000004,
            SHGFI_PIDL = 0x000000008,
            SHGFI_USEFILEATTRIBUTES = 0x000000010,
            SHGFI_ADDOVERLAYS = 0x000000020,
            SHGFI_OVERLAYINDEX = 0x000000040
        }

        [Flags]
        public enum CSIDL : uint
        {
            CSIDL_DESKTOP = 0x0000,    // <desktop>
            CSIDL_INTERNET = 0x0001,    // Internet Explorer (icon on desktop)
            CSIDL_PROGRAMS = 0x0002,    // Start Menu\Programs
            CSIDL_CONTROLS = 0x0003,    // My Computer\Control Panel
            CSIDL_PRINTERS = 0x0004,    // My Computer\Printers
            CSIDL_PERSONAL = 0x0005,    // My Documents
            CSIDL_FAVORITES = 0x0006,    // <user name>\Favorites
            CSIDL_STARTUP = 0x0007,    // Start Menu\Programs\Startup
            CSIDL_RECENT = 0x0008,    // <user name>\Recent
            CSIDL_SENDTO = 0x0009,    // <user name>\SendTo
            CSIDL_BITBUCKET = 0x000a,    // <desktop>\Recycle Bin
            CSIDL_STARTMENU = 0x000b,    // <user name>\Start Menu
            CSIDL_MYDOCUMENTS = 0x000c,    // logical "My Documents" desktop icon
            CSIDL_MYMUSIC = 0x000d,    // "My Music" folder
            CSIDL_MYVIDEO = 0x000e,    // "My Videos" folder
            CSIDL_DESKTOPDIRECTORY = 0x0010,    // <user name>\Desktop
            CSIDL_DRIVES = 0x0011,    // My Computer
            CSIDL_NETWORK = 0x0012,    // Network Neighborhood (My Network Places)
            CSIDL_NETHOOD = 0x0013,    // <user name>\nethood
            CSIDL_FONTS = 0x0014,    // windows\fonts
            CSIDL_TEMPLATES = 0x0015,
            CSIDL_COMMON_STARTMENU = 0x0016,    // All Users\Start Menu
            CSIDL_COMMON_PROGRAMS = 0X0017,    // All Users\Start Menu\Programs
            CSIDL_COMMON_STARTUP = 0x0018,    // All Users\Startup
            CSIDL_COMMON_DESKTOPDIRECTORY = 0x0019,    // All Users\Desktop
            CSIDL_APPDATA = 0x001a,    // <user name>\Application Data
            CSIDL_PRINTHOOD = 0x001b,    // <user name>\PrintHood

            CSIDL_LOCAL_APPDATA = 0x001c,    // <user name>\Local Settings\Applicaiton Data (non roaming)

            CSIDL_ALTSTARTUP = 0x001d,    // non localized startup
            CSIDL_COMMON_ALTSTARTUP = 0x001e,    // non localized common startup
            CSIDL_COMMON_FAVORITES = 0x001f,

            CSIDL_INTERNET_CACHE = 0x0020,
            CSIDL_COOKIES = 0x0021,
            CSIDL_HISTORY = 0x0022,
            CSIDL_COMMON_APPDATA = 0x0023,    // All Users\Application Data
            CSIDL_WINDOWS = 0x0024,    // GetWindowsDirectory()
            CSIDL_SYSTEM = 0x0025,    // GetSystemDirectory()
            CSIDL_PROGRAM_FILES = 0x0026,    // C:\Program Files
            CSIDL_MYPICTURES = 0x0027,    // C:\Program Files\My Pictures

            CSIDL_PROFILE = 0x0028,    // USERPROFILE
            CSIDL_SYSTEMX86 = 0x0029,    // x86 system directory on RISC
            CSIDL_PROGRAM_FILESX86 = 0x002a,    // x86 C:\Program Files on RISC

            CSIDL_PROGRAM_FILES_COMMON = 0x002b,    // C:\Program Files\Common

            CSIDL_PROGRAM_FILES_COMMONX86 = 0x002c,    // x86 Program Files\Common on RISC
            CSIDL_COMMON_TEMPLATES = 0x002d,    // All Users\Templates

            CSIDL_COMMON_DOCUMENTS = 0x002e,    // All Users\Documents
            CSIDL_COMMON_ADMINTOOLS = 0x002f,    // All Users\Start Menu\Programs\Administrative Tools
            CSIDL_ADMINTOOLS = 0x0030,    // <user name>\Start Menu\Programs\Administrative Tools

            CSIDL_CONNECTIONS = 0x0031,    // Network and Dial-up Connections
            CSIDL_COMMON_MUSIC = 0x0035,    // All Users\My Music
            CSIDL_COMMON_PICTURES = 0x0036,    // All Users\My Pictures
            CSIDL_COMMON_VIDEO = 0x0037,    // All Users\My Video

            CSIDL_CDBURN_AREA = 0x003b    // USERPROFILE\Local Settings\Application Data\Microsoft\CD Burning
        }

        public enum ShowCommands : int
        {
            SW_HIDE = 0,
            SW_SHOWNORMAL = 1,
            SW_NORMAL = 1,
            SW_SHOWMINIMIZED = 2,
            SW_SHOWMAXIMIZED = 3,
            SW_MAXIMIZE = 3,
            SW_SHOWNOACTIVATE = 4,
            SW_SHOW = 5,
            SW_MINIMIZE = 6,
            SW_SHOWMINNOACTIVE = 7,
            SW_SHOWNA = 8,
            SW_RESTORE = 9,
            SW_SHOWDEFAULT = 10,
            SW_FORCEMINIMIZE = 11,
            SW_MAX = 11
        }

        #endregion

        #region Structures

        /// <summary>
        /// MI: Used for unicode and Ansi strings as it is from shell. 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        #endregion

        #region Interfaces

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("000214E6-0000-0000-C000-000000000046")]
        public interface IShellFolder
        {
            // Translates a file object's or folder's display name into an item identifier list.
            // Return value: error code, if any
            [PreserveSig()]
            uint ParseDisplayName(
                IntPtr hwnd,             // Optional window handle
                IntPtr pbc,              // Optional bind context that controls the parsing operation. This parameter is normally set to NULL. 
                [In(), MarshalAs(UnmanagedType.LPWStr)] 
                string pszDisplayName,   // Null-terminated UNICODE string with the display name.
                out uint pchEaten,       // Pointer to a ULONG value that receives the number of characters of the display name that was parsed.
                out IntPtr ppidl,        // Pointer to an ITEMIDLIST pointer that receives the item identifier list for the object.
                ref uint pdwAttributes); // Optional parameter that can be used to query for file attributes. This can be values from the SFGAO enum

            // Allows a client to determine the contents of a folder by creating an item identifier enumeration object and returning its IEnumIDList interface.
            // Return value: error code, if any
            [PreserveSig()]
            uint EnumObjects(
                IntPtr hwnd,                    // If user input is required to perform the enumeration, this window handle should be used by the enumeration object as the parent window to take user input.
                SHCONTF grfFlags,               // Flags indicating which items to include in the enumeration. For a list of possible values, see the SHCONTF enum. 
                out IEnumIDList ppenumIDList);  // Address that receives a pointer to the IEnumIDList interface of the enumeration object created by this method. 

            // Retrieves an IShellFolder object for a subfolder.
            // Return value: error code, if any
            [PreserveSig()]
            uint BindToObject(
                IntPtr pidl,            // Address of an ITEMIDLIST structure (PIDL) that identifies the subfolder.
                IntPtr pbc,             // Optional address of an IBindCtx interface on a bind context object to be used during this operation.
                [In()]
                ref Guid riid,          // Identifier of the interface to return. 
                out IShellFolder ppv);        // Address that receives the interface pointer.

            // Requests a pointer to an object's storage interface. 
            // Return value: error code, if any
            [PreserveSig()]
            uint BindToStorage(
                IntPtr pidl,            // Address of an ITEMIDLIST structure that identifies the subfolder relative to its parent folder. 
                IntPtr pbc,             // Optional address of an IBindCtx interface on a bind context object to be used during this operation.
                [In()]
                ref Guid riid,          // Interface identifier (IID) of the requested storage interface.
                [MarshalAs(UnmanagedType.Interface)]
                out object ppv);        // Address that receives the interface pointer specified by riid.

            // Determines the relative order of two file objects or folders, given their item identifier lists. 
            // Return value: If this method is successful, the CODE field of the HRESULT contains one of the following values (the code can be retrived using the helper function GetHResultCode)...
            // A negative return value indicates that the first item should precede the second (pidl1 < pidl2). 
            // A positive return value indicates that the first item should follow the second (pidl1 > pidl2).  Zero A return value of zero indicates that the two items are the same (pidl1 = pidl2). 
            [PreserveSig()]
            int CompareIDs(
                int lParam,             // Value that specifies how the comparison should be performed. The lower sixteen bits of lParam define the sorting rule.
                // The upper sixteen bits of lParam are used for flags that modify the sorting rule. values can be from the SHCIDS enum
                IntPtr pidl1,           // Pointer to the first item's ITEMIDLIST structure.
                IntPtr pidl2);          // Pointer to the second item's ITEMIDLIST structure.

            // Requests an object that can be used to obtain information from or interact with a folder object.
            // Return value: error code, if any
            [PreserveSig()]
            uint CreateViewObject(
                IntPtr hwndOwner,       // Handle to the owner window.
                [In()]
                ref Guid riid,          // Identifier of the requested interface.
                [MarshalAs(UnmanagedType.Interface)]
                out object ppv);        // Address of a pointer to the requested interface. 

            // Retrieves the attributes of one or more file objects or subfolders. 
            // Return value: error code, if any
            [PreserveSig()]
            uint GetAttributesOf(
                int cidl,               // Number of file objects from which to retrieve attributes. 
                ref IntPtr apidl,           // Address of an array of pointers to ITEMIDLIST structures, each of which uniquely identifies a file object relative to the parent folder.
                ref SFGAOF rgfInOut);       // Address of a single ULONG value that, on entry, contains the attributes that the caller is requesting. On exit, this value contains the requested attributes that are common to all of the specified objects. this value can be from the SFGAO enum

            // Retrieves an OLE interface that can be used to carry out actions on the specified file objects or folders. 
            // Return value: error code, if any
            [PreserveSig()]
            uint GetUIObjectOf(
                IntPtr hwndOwner,       // Handle to the owner window that the client should specify if it displays a dialog box or message box.
                int cidl,               // Number of file objects or subfolders specified in the apidl parameter. 
                [In(), MarshalAs(UnmanagedType.LPArray)] IntPtr[]
                apidl,                  // Address of an array of pointers to ITEMIDLIST structures, each of which uniquely identifies a file object or subfolder relative to the parent folder.
                [In()]
                ref Guid riid,          // Identifier of the COM interface object to return.
                IntPtr rgfReserved,     // Reserved. 
                [MarshalAs(UnmanagedType.Interface)]
                out object ppv);        // Pointer to the requested interface.

            // Retrieves the display name for the specified file object or subfolder. 
            // Return value: error code, if any
            [PreserveSig()]
            uint GetDisplayNameOf(
                IntPtr pidl,            // Address of an ITEMIDLIST structure (PIDL) that uniquely identifies the file object or subfolder relative to the parent folder. 
                SHGNO uFlags,           // Flags used to request the type of display name to return. For a list of possible values. 
                out STRRET pName);      // Address of a STRRET structure in which to return the display name.

            // Sets the display name of a file object or subfolder, changing the item identifier in the process.
            // Return value: error code, if any
            [PreserveSig()]
            uint SetNameOf(
                IntPtr hwnd,            // Handle to the owner window of any dialog or message boxes that the client displays.
                IntPtr pidl,            // Pointer to an ITEMIDLIST structure that uniquely identifies the file object or subfolder relative to the parent folder. 
                [In(), MarshalAs(UnmanagedType.LPWStr)] 
                string pszName,         // Pointer to a null-terminated string that specifies the new display name. 
                SHGNO uFlags,           // Flags indicating the type of name specified by the lpszName parameter. For a list of possible values, see the description of the SHGNO enum. 
                out IntPtr ppidlOut);   // Address of a pointer to an ITEMIDLIST structure which receives the new ITEMIDLIST. 
        }

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("000214F2-0000-0000-C000-000000000046")]
        public interface IEnumIDList
        {

            // Retrieves the specified number of item identifiers in the enumeration sequence and advances the current position by the number of items retrieved. 
            [PreserveSig()]
            uint Next(
                uint celt,                // Number of elements in the array pointed to by the rgelt parameter.
                out IntPtr rgelt,         // Address of an array of ITEMIDLIST pointers that receives the item identifiers. The implementation must allocate these item identifiers using the Shell's allocator (retrieved by the SHGetMalloc function). 
                // The calling application is responsible for freeing the item identifiers using the Shell's allocator.
                out Int32 pceltFetched    // Address of a value that receives a count of the item identifiers actually returned in rgelt. The count can be smaller than the value specified in the celt parameter. This parameter can be NULL only if celt is one. 
                );

            // Skips over the specified number of elements in the enumeration sequence. 
            [PreserveSig()]
            uint Skip(
                uint celt                 // Number of item identifiers to skip.
                );

            // Returns to the beginning of the enumeration sequence. 
            [PreserveSig()]
            uint Reset();

            // Creates a new item enumeration object with the same contents and state as the current one. 
            [PreserveSig()]
            uint Clone(
                out IEnumIDList ppenum    // Address of a pointer to the new enumeration object. The calling application must eventually free the new object by calling its Release member function. 
                );
        }

        [ComImport,
        Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE"),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IShellItem
        {
            [PreserveSig()]
            uint BindToHandler(
                [In, MarshalAs(UnmanagedType.Interface)] IntPtr pbc,
                [In] ref Guid bhid,
                [In] ref Guid riid,
                out ShellAPI.IShellFolder ppv);

            [PreserveSig()]
            void GetParent([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

            [PreserveSig()]
            uint GetDisplayName(
                [In] SIGDN sigdnName,
               out IntPtr ppszName);

            [PreserveSig()]
            uint GetAttributes([In] SFGAO sfgaoMask, out SFGAO psfgaoAttribs);

        }

        #region Shell Enums
        public enum SIGDN : uint
        {
            SIGDN_NORMALDISPLAY = 0x00000000,           // SHGDN_NORMAL
            SIGDN_PARENTRELATIVEPARSING = 0x80018001,   // SHGDN_INFOLDER | SHGDN_FORPARSING
            SIGDN_DESKTOPABSOLUTEPARSING = 0x80028000,  // SHGDN_FORPARSING
            SIGDN_PARENTRELATIVEEDITING = 0x80031001,   // SHGDN_INFOLDER | SHGDN_FOREDITING
            SIGDN_DESKTOPABSOLUTEEDITING = 0x8004c000,  // SHGDN_FORPARSING | SHGDN_FORADDRESSBAR
            SIGDN_FILESYSPATH = 0x80058000,             // SHGDN_FORPARSING
            SIGDN_URL = 0x80068000,                     // SHGDN_FORPARSING
            SIGDN_PARENTRELATIVEFORADDRESSBAR = 0x8007c001,     // SHGDN_INFOLDER | SHGDN_FORPARSING | SHGDN_FORADDRESSBAR
            SIGDN_PARENTRELATIVE = 0x80080001           // SHGDN_INFOLDER
        }

        [Flags]
        public enum SFGAO : uint
        {
            /// <summary>
            /// The specified items can be copied.
            /// </summary>
            SFGAO_CANCOPY = 0x00000001,

            /// <summary>
            /// The specified items can be moved.
            /// </summary>
            SFGAO_CANMOVE = 0x00000002,

            /// <summary>
            /// Shortcuts can be created for the specified items. This flag has the same value as DROPEFFECT. 
            /// The normal use of this flag is to add a Create Shortcut item to the shortcut menu that is displayed 
            /// during drag-and-drop operations. However, SFGAO_CANLINK also adds a Create Shortcut item to the Microsoft 
            /// Windows Explorer's File menu and to normal shortcut menus. 
            /// If this item is selected, your application's IContextMenu::InvokeCommand is invoked with the lpVerb 
            /// member of the CMINVOKECOMMANDINFO structure set to "link." Your application is responsible for creating the link.
            /// </summary>
            SFGAO_CANLINK = 0x00000004,

            /// <summary>
            /// The specified items can be bound to an IStorage interface through IShellFolder::BindToObject.
            /// </summary>
            SFGAO_STORAGE = 0x00000008,

            /// <summary>
            /// The specified items can be renamed.
            /// </summary>
            SFGAO_CANRENAME = 0x00000010,

            /// <summary>
            /// The specified items can be deleted.
            /// </summary>
            SFGAO_CANDELETE = 0x00000020,

            /// <summary>
            /// The specified items have property sheets.
            /// </summary>
            SFGAO_HASPROPSHEET = 0x00000040,

            /// <summary>
            /// The specified items are drop targets.
            /// </summary>
            SFGAO_DROPTARGET = 0x00000100,

            /// <summary>
            /// This flag is a mask for the capability flags.
            /// </summary>
            SFGAO_CAPABILITYMASK = 0x00000177,

            /// <summary>
            /// Windows 7 and later. The specified items are system items.
            /// </summary>
            SFGAO_SYSTEM = 0x00001000,

            /// <summary>
            /// The specified items are encrypted.
            /// </summary>
            SFGAO_ENCRYPTED = 0x00002000,

            /// <summary>
            /// Indicates that accessing the object = through IStream or other storage interfaces, 
            /// is a slow operation. 
            /// Applications should avoid accessing items flagged with SFGAO_ISSLOW.
            /// </summary>
            SFGAO_ISSLOW = 0x00004000,

            /// <summary>
            /// The specified items are ghosted icons.
            /// </summary>
            SFGAO_GHOSTED = 0x00008000,

            /// <summary>
            /// The specified items are shortcuts.
            /// </summary>
            SFGAO_LINK = 0x00010000,

            /// <summary>
            /// The specified folder objects are shared.
            /// </summary>    
            SFGAO_SHARE = 0x00020000,

            /// <summary>
            /// The specified items are read-only. In the case of folders, this means 
            /// that new items cannot be created in those folders.
            /// </summary>
            SFGAO_READONLY = 0x00040000,

            /// <summary>
            /// The item is hidden and should not be displayed unless the 
            /// Show hidden files and folders option is enabled in Folder Settings.
            /// </summary>
            SFGAO_HIDDEN = 0x00080000,

            /// <summary>
            /// This flag is a mask for the display attributes.
            /// </summary>
            SFGAO_DISPLAYATTRMASK = 0x000FC000,

            /// <summary>
            /// The specified folders contain one or more file system folders.
            /// </summary>
            SFGAO_FILESYSANCESTOR = 0x10000000,

            /// <summary>
            /// The specified items are folders.
            /// </summary>
            SFGAO_FOLDER = 0x20000000,

            /// <summary>
            /// The specified folders or file objects are part of the file system 
            /// that is, they are files, directories, or root directories).
            /// </summary>
            SFGAO_FILESYSTEM = 0x40000000,

            /// <summary>
            /// The specified folders have subfolders = and are, therefore, 
            /// expandable in the left pane of Windows Explorer).
            /// </summary>
            SFGAO_HASSUBFOLDER = 0x80000000,

            /// <summary>
            /// This flag is a mask for the contents attributes.
            /// </summary>
            SFGAO_CONTENTSMASK = 0x80000000,

            /// <summary>
            /// When specified as input, SFGAO_VALIDATE instructs the folder to validate that the items 
            /// pointed to by the contents of apidl exist. If one or more of those items do not exist, 
            /// IShellFolder::GetAttributesOf returns a failure code. 
            /// When used with the file system folder, SFGAO_VALIDATE instructs the folder to discard cached 
            /// properties retrieved by clients of IShellFolder2::GetDetailsEx that may 
            /// have accumulated for the specified items.
            /// </summary>
            SFGAO_VALIDATE = 0x01000000,

            /// <summary>
            /// The specified items are on removable media or are themselves removable devices.
            /// </summary>
            SFGAO_REMOVABLE = 0x02000000,

            /// <summary>
            /// The specified items are compressed.
            /// </summary>
            SFGAO_COMPRESSED = 0x04000000,

            /// <summary>
            /// The specified items can be browsed in place.
            /// </summary>
            SFGAO_BROWSABLE = 0x08000000,

            /// <summary>
            /// The items are nonenumerated items.
            /// </summary>
            SFGAO_NONENUMERATED = 0x00100000,

            /// <summary>
            /// The objects contain new content.
            /// </summary>
            SFGAO_NEWCONTENT = 0x00200000,

            /// <summary>
            /// It is possible to create monikers for the specified file objects or folders.
            /// </summary>
            SFGAO_CANMONIKER = 0x00400000,

            /// <summary>
            /// Not supported.
            /// </summary>
            SFGAO_HASSTORAGE = 0x00400000,

            /// <summary>
            /// Indicates that the item has a stream associated with it that can be accessed 
            /// by a call to IShellFolder::BindToObject with IID_IStream in the riid parameter.
            /// </summary>
            SFGAO_STREAM = 0x00400000,

            /// <summary>
            /// Children of this item are accessible through IStream or IStorage. 
            /// Those children are flagged with SFGAO_STORAGE or SFGAO_STREAM.
            /// </summary>
            SFGAO_STORAGEANCESTOR = 0x00800000,

            /// <summary>
            /// This flag is a mask for the storage capability attributes.
            /// </summary>
            SFGAO_STORAGECAPMASK = 0x70C50008,

            /// <summary>
            /// Mask used by PKEY_SFGAOFlags to remove certain values that are considered 
            /// to cause slow calculations or lack context. 
            /// Equal to SFGAO_VALIDATE | SFGAO_ISSLOW | SFGAO_HASSUBFOLDER.
            /// </summary>
            SFGAO_PKEYSFGAOMASK = 0x81044000,
        }
        #endregion
    };
        #endregion
}

