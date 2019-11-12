//
// GhostscriptLibrary.cs
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
using System.IO;
using Microsoft.WinAny.Interop;

namespace Ghostscript.NET
{
    public class GhostscriptLibrary : IDisposable
    {

        #region Private variables

        private bool _disposed = false;
        private DynamicNativeLibrary _library;
        private GhostscriptVersionInfo _version;
        private bool _loadedFromMemory = false;

        #endregion

        #region Constructor - buffer

        /// <summary>
        /// Loads Ghostscript library from the memory.
        /// </summary>
        /// <param name="buffer">Byte array.</param>
        public GhostscriptLibrary(byte[] gsDll)
        {
            _library = new DynamicNativeLibrary(gsDll);
            _loadedFromMemory = true;
            this.Initialize();
        }

        #endregion

        #region Constructor - version

        /// <summary>
        /// Loads Ghostscript library from the GhostscriptVersionInfo object by using standard LoadLibrary windows function.
        /// </summary>
        /// <param name="version">GhostscriptVersionInfo object.</param>
        public GhostscriptLibrary(GhostscriptVersionInfo version) : this(version, false) 
        { }

        #endregion

        #region Constructor - version, fromMemory

        /// <summary>
        /// Loads Ghostscript library from the GhostscriptVersionInfo object with ability to load it from the memory and not from the disk.
        /// </summary>
        /// <param name="version">GhostscriptVersionInfo object.</param>
        /// <param name="fromMemory"></param>
        public GhostscriptLibrary(GhostscriptVersionInfo version, bool fromMemory)
        {
            _version = version;
            _loadedFromMemory = fromMemory;

            if (fromMemory)
            {
                _library = new DynamicNativeLibrary(File.ReadAllBytes(version.DllPath));
            }
            else
            {
                _library = new DynamicNativeLibrary(version.DllPath);
            }

            this.Initialize();
        }

        #endregion

        #region Destructor

        ~GhostscriptLibrary()
        {
            Dispose(false);
        }

        #endregion

        #region Dispose

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Dispose - disposing

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _library.Dispose(); _library = null;
                }

                _disposed = true;
            }
        }

        #endregion

        #endregion

        #region Functions

        public gsapi_revision @gsapi_revision = null;
        public gsapi_new_instance @gsapi_new_instance = null;
        public gsapi_delete_instance @gsapi_delete_instance = null;
        public gsapi_set_stdio @gsapi_set_stdio = null;
        public gsapi_set_poll @gsapi_set_poll = null;
        public gsapi_set_display_callback @gsapi_set_display_callback = null;
        public gsapi_init_with_args @gsapi_init_with_args = null;
        public gsapi_run_string_begin @gsapi_run_string_begin = null;
        public gsapi_run_string_continue @gsapi_run_string_continue = null;
        public gsapi_run_string_end @gsapi_run_string_end = null;
        public gsapi_run_string_with_length @gsapi_run_string_with_length = null;
        public gsapi_run_string @gsapi_run_string = null;
        public gsapi_run_file @gsapi_run_file = null;
        public gsapi_exit @gsapi_exit = null;

        #endregion 

        #region Initialize

        private void Initialize()
        {
            this.gsapi_revision = _library.GetDelegateForFunction("gsapi_revision", typeof(gsapi_revision)) as gsapi_revision;
            this.gsapi_new_instance = _library.GetDelegateForFunction("gsapi_new_instance", typeof(gsapi_new_instance)) as gsapi_new_instance;
            this.gsapi_delete_instance = _library.GetDelegateForFunction("gsapi_delete_instance", typeof(gsapi_delete_instance)) as gsapi_delete_instance;
            this.gsapi_set_stdio = _library.GetDelegateForFunction("gsapi_set_stdio", typeof(gsapi_set_stdio)) as gsapi_set_stdio;
            this.gsapi_set_poll = _library.GetDelegateForFunction("gsapi_set_poll", typeof(gsapi_set_poll)) as gsapi_set_poll;
            this.gsapi_set_display_callback = _library.GetDelegateForFunction("gsapi_set_display_callback", typeof(gsapi_set_display_callback)) as gsapi_set_display_callback;
            this.gsapi_init_with_args = _library.GetDelegateForFunction("gsapi_init_with_args", typeof(gsapi_init_with_args)) as gsapi_init_with_args;
            this.gsapi_run_string_begin = _library.GetDelegateForFunction("gsapi_run_string_begin", typeof(gsapi_run_string_begin)) as gsapi_run_string_begin;
            this.gsapi_run_string_continue = _library.GetDelegateForFunction("gsapi_run_string_continue", typeof(gsapi_run_string_continue)) as gsapi_run_string_continue;
            this.gsapi_run_string_end = _library.GetDelegateForFunction("gsapi_run_string_end", typeof(gsapi_run_string_end)) as gsapi_run_string_end;
            this.gsapi_run_string_with_length = _library.GetDelegateForFunction("gsapi_run_string_with_length", typeof(gsapi_run_string_with_length)) as gsapi_run_string_with_length;
            this.gsapi_run_string = _library.GetDelegateForFunction("gsapi_run_string", typeof(gsapi_run_string)) as gsapi_run_string;
            this.gsapi_run_file = _library.GetDelegateForFunction("gsapi_run_file", typeof(gsapi_run_file)) as gsapi_run_file;
            this.gsapi_exit = _library.GetDelegateForFunction("gsapi_exit", typeof(gsapi_exit)) as gsapi_exit;
        }

        #endregion

    }
}
