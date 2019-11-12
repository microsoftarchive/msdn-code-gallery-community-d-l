//
// GhostscriptViewer.cs
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
using System.Drawing;
using System.Collections.Generic;
using Ghostscript.NET.Interpreter;

namespace Ghostscript.NET.Viewer
{
    public class GhostscriptViewer : IDisposable
    {
        #region Private variables

        private bool _disposed = false;
        private GhostscriptInterpreter _interpreter = null;
        private string _filePath = null;
        private GhostscriptViewerFormatHandler _formatHandler = null;
        private int _progressiveUpdateInterval = 100;
        private GhostscriptStdIO _stdIoCallback = null;
        private int _zoom_xDpi = 96;
        private int _zoom_yDpi = 96;

        #endregion

        #region Public events

        public event GhostscriptViewerViewEventHandler DisplaySize;
        public event GhostscriptViewerViewEventHandler DisplayUpdate;
        public event GhostscriptViewerViewEventHandler DisplayPage;

        #region OnDisplaySize

        protected virtual void OnDisplaySize(GhostscriptViewerViewEventArgs e)
        {
            if (DisplaySize != null)
            {
                DisplaySize(this, e);
            }
        }

        #endregion

        #region OnDisplayUpdate

        protected virtual void OnDisplayUpdate(GhostscriptViewerViewEventArgs e)
        {
            if (DisplayUpdate != null)
            {
                DisplayUpdate(this, e);
            }
        }

        #endregion

        #region OnDisplayPage

        protected virtual void OnDisplayPage(GhostscriptViewerViewEventArgs e)
        {
            if (DisplayPage != null)
            {
                DisplayPage(this, e);
            }
        }

        #endregion

        #endregion

        #region Constructor

        public GhostscriptViewer()
        {

        }

        #endregion

        #region Destructor

        ~GhostscriptViewer()
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
                    if (_formatHandler != null)
                    {
                        _formatHandler.Dispose();
                        _formatHandler = null;
                    }

                    if (_interpreter != null)
                    {
                        _interpreter.Dispose();
                        _interpreter = null;
                    }
                }

                _disposed = true;
            }
        }

        #endregion

        #endregion

        #region Open - versionInfo, fromMemory

        public void Open(GhostscriptVersionInfo versionInfo, bool fromMemory)
        {
            this.Open(string.Empty, versionInfo, fromMemory);
        }

        #endregion

        #region Open - path, versionInfo, fromMemory

        public void Open(string path, GhostscriptVersionInfo versionInfo, bool fromMemory)
        {
            this.Close();

            _filePath = path;

            _interpreter = new GhostscriptInterpreter(versionInfo, fromMemory);

            this.Open();
        }

        #endregion

        #region Open - gsDll

        public void Open(byte[] gsDll)
        {
            this.Open(string.Empty, gsDll);
        }

        #endregion

        #region Open - path, gsDll

        public void Open(string path, byte[] gsDll)
        {
            this.Close();

            _filePath = path;

            _interpreter = new GhostscriptInterpreter(gsDll);

            this.Open();
        }

        #endregion

        #region Open

        private void Open()
        {
            string extension = Path.GetExtension(_filePath).ToLower();

            switch (extension)
            {
                case ".pdf":
                    {
                        _formatHandler = new GhostscriptViewerPdfFormatHandler(this);
                        break;
                    }
                case ".ps":
                    {
                        _formatHandler = new GhostscriptViewerPsFormatHandler(this);
                        break;
                    }
                default:
                    {
                        _formatHandler = new GhostscriptViewerDefaultFormatHandler(this);
                        break;
                    }
            }

            _interpreter.Setup(new GhostscriptViewerStdIOHandler(this, _formatHandler), new GhostscriptViewerDisplayHandler(this));

            List<string> args = new List<string>();
            args.Add("GSNET");
            args.Add("-sDEVICE=display");

            if (Environment.Is64BitProcess)
            {
                args.Add("-sDisplayHandle=0");
            }
            else
            {
                args.Add("-dDisplayHandle=0");
            }

            args.Add("-dDisplayFormat=" + 
                        ((int)DISPLAY_FORMAT_COLOR.DISPLAY_COLORS_RGB |
                        (int)DISPLAY_FORMAT_ALPHA.DISPLAY_ALPHA_NONE |
                        (int)DISPLAY_FORMAT_DEPTH.DISPLAY_DEPTH_8 |
                        (int)DISPLAY_FORMAT_ENDIAN.DISPLAY_LITTLEENDIAN |
                        (int)DISPLAY_FORMAT_FIRSTROW.DISPLAY_BOTTOMFIRST).ToString());
            //args.Add("-dNOINTERPOLATE");
            //args.Add("-dCOLORSCREEN=0");
            //args.Add("-dAlignToPixels=0");

            args.Add("-dDOINTERPOLATE");
            args.Add("-dTextAlphaBits=4");
            args.Add("-dGraphicAlphaBits=4");
            //args.Add("-dGridFitTT=0");
            //args.Add("-dHaveTrueTypes=true");

            _interpreter.InitArgs(args.ToArray());

            _formatHandler.Initialize();
            _formatHandler.Open(_filePath);

            this.ShowPage(_formatHandler.FirstPageNumber, true);
        }

        #endregion

        #region Close

        public void Close()
        {
            if (_formatHandler != null)
            {
                _formatHandler = null;
            }

            if (_interpreter != null)
            {
                _interpreter.Dispose();
                _interpreter = null;
            }
        }

        #endregion

        #region AttachStdIO

        public void AttachStdIO(GhostscriptStdIO stdIoCallback)
        {
            _stdIoCallback = stdIoCallback;
        }

        #endregion

        #region ShowPage - pageNumber

        public void ShowPage(int pageNumber)
        {
            this.ShowPage(pageNumber, false);
        }

        #endregion

        #region ShowPage - pageNumber, refresh

        public void ShowPage(int pageNumber, bool refresh)
        {
            if (!this.IsEverythingInitialized)
                return;

            if (refresh == false && pageNumber == this.CurrentPageNumber)
                return;

            _formatHandler.InitPage(pageNumber);

            this.Interpreter.Run(@"
                            %%BeginPageSetup 
                            %%%%BeginFeature: PageSize Custom 
                            <<");

            if (_formatHandler.IsMediaBoxSet)
            {
                this.Interpreter.Run(string.Format("/PageSize [{0} {1}]", _formatHandler.MediaBox.Width, _formatHandler.MediaBox.Height));
                this.Interpreter.Run(string.Format("/MediaBox [{0} {1} {2} {3}]", 0, 0, _formatHandler.MediaBox.Width, _formatHandler.MediaBox.Height));
            }
            
            this.Interpreter.Run(string.Format("/HWResolution [{0} {1}]", _zoom_xDpi, _zoom_yDpi));

            this.Interpreter.Run(@">> 
                           setpagedevice");

            this.Interpreter.Run(@"
                           %%EndFeature 
                           %%EndPageSetup");

            _formatHandler.ShowPage(pageNumber);
        }

        #endregion

        #region ShowFirstPage

        public void ShowFirstPage()
        {
            if (this.CurrentPageNumber == this.FirstPageNumber)
                return;

            this.ShowPage(this.FirstPageNumber);
        }

        #endregion

        #region ShowNextPage

        public void ShowNextPage()
        {
            if (this.CurrentPageNumber + 1 <= this.LastPageNumber)
            {
                this.ShowPage(this.CurrentPageNumber + 1);
            }
        }

        #endregion

        #region ShowPreviousPage

        public void ShowPreviousPage()
        {
            if (this.CurrentPageNumber - 1 >= this.FirstPageNumber)
            {
                this.ShowPage(this.CurrentPageNumber - 1);
            }
        }

        #endregion

        #region ShowLastPage

        public void ShowLastPage()
        {
            if (this.CurrentPageNumber == this.LastPageNumber)
                return;

            this.ShowPage(this.LastPageNumber);
        }

        #endregion

        #region RefreshPage

        public void RefreshPage()
        {
            if (this.IsEverythingInitialized)
            {
                this.ShowPage(this.CurrentPageNumber, true);
            }
        }

        #endregion

        #region Zoom

        private void Zoom(float scale)
        {
            int tmpZoopX = (int)(_zoom_xDpi * scale + 0.5);
            int tmpZoomY = (int)(_zoom_yDpi * scale + 0.5);

            if (tmpZoopX < 39)
                return;

            if (tmpZoopX > 496)
                return;

            _zoom_xDpi = tmpZoopX;
            _zoom_yDpi = tmpZoomY;

            //System.Diagnostics.Debug.WriteLine("ZOOM: " + _zoom_xDpi.ToString());
        }

        #endregion

        #region ZoomIn

        public void ZoomIn()
        {
            if (this.IsEverythingInitialized)
            {
                this.Zoom(1.2f);
                this.RefreshPage();
            }
        }

        #endregion

        #region ZoomOut

        public void ZoomOut()
        {
            if (this.IsEverythingInitialized)
            {
                this.Zoom(0.8333333f);
                this.RefreshPage();
            }
        }

        #endregion

        #region Internal methods

        #region StdInput

        internal void StdInput(out string input, int count)
        {
            input = null;

            if (_stdIoCallback != null)
            {
                _stdIoCallback.StdIn(out input, count);
            }
        }

        #endregion

        #region StdOutput

        internal void StdOutput(string message)
        {
            if (_stdIoCallback != null)
            {
                _stdIoCallback.StdOut(message);
            }
        }

        #endregion

        #region StdError

        internal void StdError(string message)
        {
            if (_stdIoCallback != null)
            {
                _stdIoCallback.StdError(message);
            }
        }

        #endregion

        #region RaiseDisplaySize

        internal void RaiseDisplaySize(GhostscriptViewerViewEventArgs e)
        {
            this.OnDisplaySize(e);
        }

        #endregion

        #region RaiseDisplayPage

        internal void RaiseDisplayPage(GhostscriptViewerViewEventArgs e)
        {
            this.OnDisplayPage(e);
        }

        #endregion

        #region RaiseDisplayUpdate

        internal void RaiseDisplayUpdate(GhostscriptViewerViewEventArgs e)
        {
            this.OnDisplayUpdate(e);
        }

        #endregion

        #region ZoomXDpi

        internal int ZoomXDpi
        {
            get { return _zoom_xDpi; }
        }

        #endregion

        #region ZoomYDpi

        internal int ZoomYDpi
        {
            get { return _zoom_yDpi; }
        }

        #endregion

        #endregion

        #region Public properties

        #region Interpreter

        public GhostscriptInterpreter Interpreter
        {
            get { return _interpreter; }
        }

        #endregion

        #region IsEverythingInitialized

        public bool IsEverythingInitialized
        {
            get { return _formatHandler != null; }
        }

        #endregion

        #region FilePath

        public string FilePath
        {
            get
            {
                if (this.IsEverythingInitialized)
                {
                    return _filePath;
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

        #region CurrentPageNumber

        public int CurrentPageNumber
        {
            get 
            {
                if (this.IsEverythingInitialized)
                {
                    return _formatHandler.CurrentPageNumber;
                }
                else
                {
                    return 0;
                }
            }
        }

        #endregion

        #region FirstPageNumber

        public int FirstPageNumber
        {
            get 
            {
                if (this.IsEverythingInitialized)
                {
                    return _formatHandler.FirstPageNumber;
                }
                else
                {
                    return 0;
                }
            }
        }

        #endregion

        #region LastPageNumber

        public int LastPageNumber
        {
            get 
            {
                if (this.IsEverythingInitialized)
                {
                    return _formatHandler.LastPageNumber;
                }
                else
                {
                    return 0;
                }
            }
        }

        #endregion

        #region ProgressiveUpdateInterval

        public int ProgressiveUpdateInterval
        {
            get { return _progressiveUpdateInterval; }
            set { _progressiveUpdateInterval = value; }
        }

        #endregion

        #endregion

    }
}
