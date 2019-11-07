using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileExplorer.Helper
{
    static class LogHelper
    {
        internal static void Debug(string s)
        {
            System.Diagnostics.Debug.WriteLine(s);
        }

        internal static void Debug(string s, Exception ex)
        {
            Debug(string.Format("{0},exception:{1}", s, ex.Message));
        }

        internal static void Debug(Exception ex)
        {
            Debug(string.Format("exception:{0}", ex.Message));
        }

        internal static void DebugFormat(string format, params object[] values)
        {
            Debug(string.Format(format, values));
        }

        internal static void Info(string s)
        {
            System.Diagnostics.Debug.WriteLine(s);
        }
    }
}
