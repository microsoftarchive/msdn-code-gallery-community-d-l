//
// GhostscriptProcessor.cs
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
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ghostscript.NET.Processor
{
    public class GhostscriptProcessor : IDisposable
    {
        #region Private constants

        private readonly char[] EMPTY_SPACE_SPLIT = new char[] { ' ' };

        #endregion

        #region Private variables

        private bool _disposed = false;
        private GhostscriptLibrary _gs;
        private GhostscriptStdIO _stdIO_Callback;
        private GhostscriptProcessorInternalStdIOHandler _internalStdIO_Callback;
        private StringBuilder _outputMessages = new StringBuilder();
        private StringBuilder _errorMessages = new StringBuilder();
        private int _totalPages;

        #endregion

        #region Public events

        public event GhostscriptProcessorProcessingEventHandler Processing;
        public event GhostscriptProcessorErrorEventHandler Error;

        #region OnProcessing

        protected void OnProcessing(GhostscriptProcessorProcessingEventArgs e)
        {
            if (Processing != null)
            {
                this.Processing(this, e);
            }
        }

        #endregion

        #region OnError

        protected void OnError(GhostscriptProcessorErrorEventArgs e)
        {
            if (Error != null)
            {
                this.Error(this, e);
            }
        }

        #endregion

        #endregion

        #region Constructor - gsDll

        public GhostscriptProcessor(byte[] gsDll)
        {
            _gs = new GhostscriptLibrary(gsDll);
        }

        #endregion

        #region Constructor - version

        public GhostscriptProcessor(GhostscriptVersionInfo version) : this(version, false)
        { }

        #endregion

        #region Constructor - version, fromMemory

        public GhostscriptProcessor(GhostscriptVersionInfo version, bool fromMemory)
        {
            _gs = new GhostscriptLibrary(version, fromMemory);
        }

        #endregion

        #region Destructor

        ~GhostscriptProcessor()
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
                    _gs.Dispose();
                }

                _disposed = true;
            }
        }

        #endregion

        #endregion

        #region Process

        /// <summary>
        /// Run Ghostscript.
        /// </summary>
        /// <param name="args">Command arguments</param>
        /// <param name="stdIO_callback">StdIO callback, can be set to null if you dont want to handle it.</param>
        public void Process(string[] args, GhostscriptStdIO stdIO_callback)
        {
            IntPtr instance = IntPtr.Zero;

            int rc_ins = _gs.gsapi_new_instance(out instance, IntPtr.Zero);

            if (ierrors.IsError(rc_ins))
            {
                throw new GhostscriptAPICallException("gsapi_new_instance", rc_ins);
            }

            try
            {
                _stdIO_Callback = stdIO_callback;

                _internalStdIO_Callback = new GhostscriptProcessorInternalStdIOHandler(
                                                new StdInputEventHandler(OnStdIoInput), 
                                                new StdOutputEventHandler(OnStdIoOutput), 
                                                new StdErrorEventHandler(OnStdIoError));

                int rc_stdio = _gs.gsapi_set_stdio(instance,
                                        _internalStdIO_Callback._std_in,
                                        _internalStdIO_Callback._std_out,
                                        _internalStdIO_Callback._std_err);

                if (ierrors.IsError(rc_stdio))
                {
                    throw new GhostscriptAPICallException("gsapi_set_stdio", rc_stdio);
                }

                int rc_init = _gs.gsapi_init_with_args(instance, args.Length, args);

                if (ierrors.IsErrorIgnoreQuit(rc_init))
                {
                    throw new GhostscriptAPICallException("gsapi_init_with_args", rc_init);
                }

                int rc_exit = _gs.gsapi_exit(instance);

                if (ierrors.IsErrorIgnoreQuit(rc_exit))
                {
                    throw new GhostscriptAPICallException("gsapi_exit", rc_exit);
                }
            }
            finally
            {
                _gs.gsapi_delete_instance(instance);
            }
        }

        #endregion

        #region OnStdIoInput

        private void OnStdIoInput(out string input, int count)
        {
            if (_stdIO_Callback != null)
            {
                _stdIO_Callback.StdIn(out input, count);
            }
            else
            {
                input = string.Empty;
            }
        }

        #endregion

        #region OnStdIoOutput

        private void OnStdIoOutput(string output)
        {
            lock (_outputMessages)
            {
                _outputMessages.Append(output);

                int rIndex = _outputMessages.ToString().IndexOf("\r\n");

                while (rIndex > -1)
                {
                    string line = _outputMessages.ToString().Substring(0, rIndex);
                    _outputMessages = _outputMessages.Remove(0, rIndex + 2);

                    this.ProcessOutputLine(line);

                    rIndex = _outputMessages.ToString().IndexOf("\r\n");
                }

                if (_stdIO_Callback != null)
                {
                    _stdIO_Callback.StdOut(output);
                }
            }
        }

        #endregion

        #region OnStdIoError

        private void OnStdIoError(string error)
        {
            lock (_errorMessages)
            {
                _outputMessages.Append(error);

                int rIndex = _errorMessages.ToString().IndexOf("\r\n");

                while (rIndex > -1)
                {
                    string line = _errorMessages.ToString().Substring(0, rIndex);
                    _errorMessages = _errorMessages.Remove(0, rIndex + 2);

                    this.ProcessErrorLine(line);

                    rIndex = _errorMessages.ToString().IndexOf("\r\n");
                }

                if (_stdIO_Callback != null)
                {
                    _stdIO_Callback.StdError(error);
                }
            }
        }

        #endregion

        #region ProcessOutputLine

        private void ProcessOutputLine(string line)
        {
            if (line.StartsWith("Processing pages"))
            {
                string[] chunks = line.Split(EMPTY_SPACE_SPLIT);
                _totalPages = int.Parse(chunks[chunks.Length - 1].TrimEnd('.'));
            }
            else if (line.StartsWith("Page"))
            {
                string[] chunks = line.Split(EMPTY_SPACE_SPLIT);
                int currentPage = int.Parse(chunks[chunks.Length - 1]);

                this.OnProcessing(new GhostscriptProcessorProcessingEventArgs(currentPage, _totalPages));
            }
        }

        #endregion

        #region ProcessErrorLine

        private void ProcessErrorLine(string line)
        {
            this.OnError(new GhostscriptProcessorErrorEventArgs(line));
        }

        #endregion
    }
}
