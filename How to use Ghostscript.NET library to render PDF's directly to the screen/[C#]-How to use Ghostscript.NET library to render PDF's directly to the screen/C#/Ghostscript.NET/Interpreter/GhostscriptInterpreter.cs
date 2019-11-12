//
// GhostscriptInterpreter.cs
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
using System.Runtime.InteropServices;

namespace Ghostscript.NET.Interpreter
{
    public class GhostscriptInterpreter : IDisposable
    {

        #region Private constants

        private const int RUN_STRING_MAX_LENGTH = 65535;

        #endregion

        #region Private variables

        private bool _disposed = false;
        private GhostscriptLibrary _gs = null;
        private IntPtr _gs_instance = IntPtr.Zero;
        private GhostscriptStdIO _stdIO = null;
        private GhostscriptDisplayDevice _displayDevice = null;
        private IntPtr _displayDevice_callback_handle = IntPtr.Zero;

        #endregion

        #region Constructor - gsDll

        public GhostscriptInterpreter(byte[] gsDll)
        {
            _gs = new GhostscriptLibrary(gsDll);
            this.Initialize();
        }

        #endregion

        #region Constructor - version

        public GhostscriptInterpreter(GhostscriptVersionInfo version) : this(version, false)
        { }

        #endregion

        #region Constructor - version, fromMemory

        public GhostscriptInterpreter(GhostscriptVersionInfo version, bool fromMemory)
        {
            _gs = new GhostscriptLibrary(version, fromMemory);
            this.Initialize();
        }

        #endregion

        #region Destructor

        ~GhostscriptInterpreter()
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
                    _gs.gsapi_exit(_gs_instance);

                    _gs.gsapi_delete_instance(_gs_instance);

                    _gs.Dispose();
                }

                if (_displayDevice_callback_handle != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(_displayDevice_callback_handle);
                }

                _disposed = true;
            }
        }

        #endregion

        #endregion

        #region Initialize

        private void Initialize()
        {
            int rc_ins = _gs.gsapi_new_instance(out _gs_instance, IntPtr.Zero);

            if (ierrors.IsError(rc_ins))
            {
                throw new GhostscriptAPICallException("gsapi_new_instance", rc_ins);
            }
        }

        #endregion

        #region Setup

        public void Setup(GhostscriptStdIO stdIO, GhostscriptDisplayDevice displayDevice)
        {
            if (stdIO != null)
            {
                if (_stdIO == null)
                {

                    int rc_stdio = _gs.gsapi_set_stdio(_gs_instance,
                                            stdIO != null ? stdIO._std_in : null,
                                            stdIO != null ? stdIO._std_out : null,
                                            stdIO != null ? stdIO._std_err : null);

                    if (ierrors.IsError(rc_stdio))
                    {
                        throw new GhostscriptAPICallException("gsapi_set_stdio", rc_stdio);
                    }

                    _stdIO = stdIO;
                }
                else
                {
                    throw new GhostscriptException("StdIO callback is already set!");
                }
            }

            if (displayDevice != null)
            {
                if (_displayDevice == null)
                {

                    _displayDevice_callback_handle = Marshal.AllocCoTaskMem(displayDevice._callback.size);

                    Marshal.StructureToPtr(displayDevice._callback, _displayDevice_callback_handle, true);

                    int rc_dev = _gs.gsapi_set_display_callback(_gs_instance, _displayDevice_callback_handle);

                    if (ierrors.IsError(rc_dev))
                    {
                        throw new GhostscriptAPICallException("gsapi_set_display_callback", rc_dev);
                    }

                    _displayDevice = displayDevice;

                }
                else
                {
                    throw new GhostscriptException("DisplayDevice callback is already set!");
                }
            }

        }

        #endregion

        #region InitArgs

        public void InitArgs(string[] args)
        {
            int rc_init = _gs.gsapi_init_with_args(_gs_instance, args.Length, args);

            if (ierrors.IsError(rc_init))
            {
                throw new GhostscriptAPICallException("gsapi_init_with_args", rc_init);
            }
        }


        private static string ToHexadecimal(byte[] bytes)
        {
            System.Text.StringBuilder hexBuilder = new System.Text.StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                hexBuilder.Append(bytes[i].ToString("x2"));
            }
            return hexBuilder.ToString();
        }

        #endregion

        #region Run


        public void Run(string str)
        {
            lock (this)
            {
                int exit_code;

                if (str.Length < RUN_STRING_MAX_LENGTH)
                {
                    int rc_run = _gs.gsapi_run_string(_gs_instance, str, 0, out exit_code);

                    if (ierrors.IsFatalIgnoreNeedInput(rc_run))
                    {
                        throw new GhostscriptAPICallException("gsapi_run_string", rc_run);
                    }
                }
                else
                {
                    int rc_run_beg = _gs.gsapi_run_string_begin(_gs_instance, 0, out exit_code);

                    if (ierrors.IsFatalIgnoreNeedInput(rc_run_beg))
                    {
                        throw new GhostscriptAPICallException("gsapi_run_string_begin", rc_run_beg);
                    }

                    int chunkStart = 0;

                    for (int size = str.Length; size > 0; size -= RUN_STRING_MAX_LENGTH)
                    {
                        int chunkSize = (size < RUN_STRING_MAX_LENGTH) ? size : RUN_STRING_MAX_LENGTH;
                        string chunk = str.Substring(chunkStart, chunkSize);

                        int rc_run_con = _gs.gsapi_run_string_continue(_gs_instance, chunk, (uint)chunkSize, 0, out exit_code);

                        if (ierrors.IsFatalIgnoreNeedInput(rc_run_con))
                        {
                            throw new GhostscriptAPICallException("gsapi_run_string_continue", rc_run_con);
                        }

                        chunkStart += chunkSize;
                    }

                    int rc_run_end = _gs.gsapi_run_string_end(_gs_instance, 0, out exit_code);

                    if (ierrors.IsFatalIgnoreNeedInput(rc_run_end))
                    {
                        throw new GhostscriptAPICallException("gsapi_run_string_end", rc_run_end);
                    }
                }
            }
        }

        #endregion

        #region RunPSFile

        public void RunPSFile(string path)
        {
            int exit_code;

            int rc_run = _gs.gsapi_run_file(_gs_instance, path, 0, out exit_code);

            if (ierrors.IsFatal(rc_run))
            {
                throw new GhostscriptAPICallException("gsapi_run_file", rc_run);
            }
        }

        #endregion

    }
}
