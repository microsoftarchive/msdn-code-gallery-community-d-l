using System;
using System.Runtime.InteropServices;

namespace Ghostscript.NET
{
    internal class wdm
    {
        [DllImport("kernel32.dll", EntryPoint = "RtlMoveMemory")]
        public static extern void MoveMemory(IntPtr destination, IntPtr source, uint length);
    }
}
