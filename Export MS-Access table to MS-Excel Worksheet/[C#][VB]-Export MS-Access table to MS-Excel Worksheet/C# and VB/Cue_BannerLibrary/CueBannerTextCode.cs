using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Cue_BannerLibrary
{
    public static class CueBannerTextCode
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private extern static Int32 SendMessage(
            IntPtr hWnd,
            int msg,
            int wParam, [MarshalAs(UnmanagedType.LPWStr)]
        string lParam);

        [System.Runtime.InteropServices.DllImport("user32",
            EntryPoint = "FindWindowExA",
            ExactSpelling = true,
            CharSet = CharSet.Ansi, SetLastError = true)]

        private static extern IntPtr FindWindowEx(IntPtr hWnd1, IntPtr hWnd2, string lpsz1, string lpsz2);
        private const int EM_SETCUEBANNER = 0x1501;
        /// <summary>
        /// Used to place shadow text into a TextBox or ComboBox when control does not have focus
        /// </summary>
        /// <param name="control">Name of control</param>
        /// <param name="text">Shadow text to show when control does not have focus</param>
        /// <remarks>
        /// Some might call this a watermark affect
        /// </remarks>
        public static void SetCueText(this Control control, string text)
        {

            if (control is ComboBox)
            {
                IntPtr Edit_hWnd = FindWindowEx(control.Handle, IntPtr.Zero, "Edit", null);
                if (!(Edit_hWnd == IntPtr.Zero))
                {
                    SendMessage(Edit_hWnd, EM_SETCUEBANNER, 0, text);
                }
            }
            else if (control is TextBox)
            {
                SendMessage(control.Handle, EM_SETCUEBANNER, 0, text);
            }
        }
    }
}
