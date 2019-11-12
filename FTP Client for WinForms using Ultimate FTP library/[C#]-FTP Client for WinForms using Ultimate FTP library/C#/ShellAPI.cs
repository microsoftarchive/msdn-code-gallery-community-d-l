using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace ClientSample
{
    public class ShellAPI
    {
        private const int MAX_PATH = 260;
        private const int SHGFI_DISPLAYNAME = 0x200;
        private const int SHGFI_EXETYPE = 0x2000;
        private const int SHGFI_SYSICONINDEX = 0x4000;
        private const int SHGFI_LARGEICON = 0x0;
        private const int SHGFI_SMALLICON = 0x1;
        private const int SHGFI_SHELLICONSIZE = 0x4;
        private const int SHGFI_TYPENAME = 0x400;
        private const int ILD_TRANSPARENT = 0x1;
        private const int BASIC_SHGFI_FLAGS = SHGFI_TYPENAME + SHGFI_SHELLICONSIZE + SHGFI_SYSICONINDEX + SHGFI_DISPLAYNAME + SHGFI_EXETYPE;

        [StructLayout(LayoutKind.Sequential)]
        private class SHFileInfo
        {
            public int IconHandle = 0;
            public int IconSysIndex = 0;
            public int Attributes = 0;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public String DisplayName = "";
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public String TypeName = "";
        }

        [DllImport("shell32", SetLastError = true)]
        private static extern int SHGetFileInfoA(string pszPath, int dwFileAttributes, [InAttribute, OutAttribute] SHFileInfo psfi, int cbSizeFileInfo, int uFlags);

        [DllImport("comctl32", SetLastError = true)]
        private static extern int ImageList_Draw(int hIml, int i, int hdcDest, int X, int Y, int flags);

        [StructLayout(LayoutKind.Sequential)]
        private struct ShellExecuteInfo
        {
            public int cbSize;
            public int fMask;
            public int hWnd;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpVerb;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpParameters;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpDirectory;
            public int nShow;
            public int hInstApp;
            public int lpIDList;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpClass;
            public int hkeyClass;
            public int dwHotKey;
            public int hIcon;
            public int hProcess;
        }

        [DllImport("shell32", SetLastError = true)]
        private static extern bool ShellExecuteExA(ref ShellExecuteInfo lpExecInfo);

        private const int SEE_MASK_INVOKEIDLIST = 0xC;
        private const int SEE_MASK_NOCLOSEPROCESS = 0x40;
        private const int SEE_MASK_FLAG_NO_UI = 0x400;

        [StructLayout(LayoutKind.Sequential)]
        private struct ShBrowseInfo
        {
            public int hOwner;
            public int pidlRoot;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pszDisplayName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpszTitle;
            public int ulFlags;
            public int lpfn;
            public int lParam;
            public int iImage;
        }

        private const int BIF_RETURNONLYFSDIRS = 0x1;
        //private const int BIF_DONTGOBELOWDOMAIN = 0x2;
        //private const int BIF_STATUSTEXT = 0x4;
        //private const int BIF_RETURNFSANCESTORS = 0x8;
        //private const int BIF_BROWSEFORCOMPUTER = 0x1000;
        //private const int BIF_BROWSEFORPRINTER = 0x2000;

        [DllImport("shell32", SetLastError = true)]
        private static extern int SHBrowseForFolderA(ref ShBrowseInfo lpBrowseInfo);

        [DllImport("shell32", SetLastError = true, CharSet = CharSet.Ansi)]
        private static extern int SHGetPathFromIDListA(int pidl, StringBuilder pszPath);

        [DllImport("ole32", SetLastError = true)]
        private static extern void CoTaskMemFree(int pv);

        public static string GetFileDescription(string fileName)
        {
            string l_Description;
            try
            {
                SHFileInfo shinfo = new SHFileInfo();
                SHGetFileInfoA(fileName, 0, shinfo, Marshal.SizeOf(shinfo), BASIC_SHGFI_FLAGS);
                l_Description = shinfo.TypeName;
            }
            catch
            {
                l_Description = "";
            }
            try
            {
                if (l_Description.Length == 0)
                    l_Description = System.IO.Path.GetExtension(fileName).ToUpper().Substring(1) + " File";
            }
            catch
            {
                l_Description = "";
            }
            return l_Description;
        }

        public static void ShowFileProperties(string filePath, IntPtr ownerHwnd)
        {
            ShellExecuteInfo sei = new ShellExecuteInfo();
            sei.cbSize = Marshal.SizeOf(sei);
            sei.fMask = SEE_MASK_NOCLOSEPROCESS | SEE_MASK_INVOKEIDLIST | SEE_MASK_FLAG_NO_UI;
            sei.hWnd = ownerHwnd.ToInt32();
            sei.lpVerb = "properties";
            sei.lpFile = filePath;
            ShellExecuteExA(ref sei);
        }

        /// <summary>
        /// Gets the system icon for the specified file name.
        /// </summary>
        /// <param name="filePath">The file name.</param>
        /// <param name="getLargeIcon">A boolean value indicates whether to get large icon or small icon.</param>
        /// <returns>The Image object.</returns>
        public static Image ExtractIcon(string filePath, bool getLargeIcon)
        {
            SHFileInfo shinfo = new SHFileInfo();
            Image FileIcon = null;

            try
            {
                int hImg;
                short iPixels;
                if (getLargeIcon)
                {
                    iPixels = 32;
                    hImg = SHGetFileInfoA(filePath, 0, shinfo, Marshal.SizeOf(shinfo), BASIC_SHGFI_FLAGS | SHGFI_LARGEICON);
                }
                else
                {
                    iPixels = 16;
                    hImg = SHGetFileInfoA(filePath, 0, shinfo, Marshal.SizeOf(shinfo), BASIC_SHGFI_FLAGS | SHGFI_SMALLICON);
                }

                if (shinfo.IconSysIndex != 0)
                {
                    FileIcon = new Bitmap(iPixels, iPixels);
                    Graphics ImgGraphics = Graphics.FromImage(FileIcon);
                    IntPtr hDC = ImgGraphics.GetHdc();
                    ImageList_Draw(hImg, shinfo.IconSysIndex, hDC.ToInt32(), 0, 0, ILD_TRANSPARENT);
                    ImgGraphics.ReleaseHdc(hDC);
                }
            }
            catch { /* If we fail to get the icon, return null */ }

            return FileIcon;
        }

        public static string BrowseForFolder(string title, System.Windows.Forms.Form owner)
        {
            ShBrowseInfo bi = new ShBrowseInfo();
            StringBuilder buffer = new StringBuilder(MAX_PATH);

            bi.hOwner = owner.Handle.ToInt32();
            bi.pidlRoot = 0;
            bi.lpszTitle = title;
            bi.ulFlags = BIF_RETURNONLYFSDIRS;

            int pidl = SHBrowseForFolderA(ref bi);
            SHGetPathFromIDListA(pidl, buffer);
            CoTaskMemFree(pidl);

            return buffer.ToString();
        }
    }
}
