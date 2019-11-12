//
// GhostscriptStdIO.cs
// This file is part of Ghostscript.NET library
//
// Author: Josip Habjan (habjan@gmail.com, http://www.linkedin.com/in/habjan) 
// Copyright (c) 2013 Josip Habjan. All rights reserved.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Ghostscript.NET
{
    public abstract class GhostscriptStdIO
    {
        #region Internal variables

        internal gsapi_stdio_callback _std_in = null;
        internal gsapi_stdio_callback _std_out = null;
        internal gsapi_stdio_callback _std_err = null;

        #endregion

        #region Constructor

        public GhostscriptStdIO(bool attachStdIn, bool attachStdOut, bool attachStdErr)
        {
            if (attachStdIn)
            {
                _std_in = new gsapi_stdio_callback(gs_std_in);
            }

            if (attachStdOut)
            {
                _std_out = new gsapi_stdio_callback(gs_std_out);
            }

            if (attachStdErr)
            {
                _std_err = new gsapi_stdio_callback(gs_std_err);
            }
        }

        #endregion

        #region gs_std_in

        private int gs_std_in(IntPtr handle, IntPtr pointer, int count)
        {
            string input;
            this.StdIn(out input, count);

            if (input == null)
                return 0;

            if (input.Length > count)
                input = input.Substring(0, count);

            pointer = Marshal.StringToHGlobalAnsi(input);

            return input.Length;
        }

        #endregion

        #region gs_std_out

        private int gs_std_out(IntPtr handle, IntPtr pointer, int count)
        {
            this.StdOut(Marshal.PtrToStringAnsi(pointer, count).Replace("\n", "\r\n"));
            return count;
        }

        #endregion

        #region gs_std_err

        private int gs_std_err(IntPtr handle, IntPtr pointer, int count)
        {
            this.StdError(Marshal.PtrToStringAnsi(pointer, count).Replace("\n", "\r\n"));
            return count;
        }

        #endregion

        #region Abstract functions

        public abstract void StdIn(out string input, int count);
        public abstract void StdOut(string output);
        public abstract void StdError(string error);

        #endregion

    }
}
