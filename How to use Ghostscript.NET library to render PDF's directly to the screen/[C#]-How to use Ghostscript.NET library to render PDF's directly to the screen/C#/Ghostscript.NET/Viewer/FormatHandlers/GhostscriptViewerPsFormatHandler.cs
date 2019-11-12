//
// GhostscriptViewerPsFormatHandler.cs
// This file is part of Ghostscript.NET library
//
// Author: Josip Habjan (habjan@gmail.com, http://www.linkedin.com/in/habjan) 
// Copyright (c) 2013 Josip Habjan. All rights reserved.
//
// Author ported some parts of this code from GSView. 
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
using System.Drawing;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Ghostscript.NET.Viewer
{
    internal class GhostscriptViewerPsFormatHandler : GhostscriptViewerFormatHandler
    {
        #region Private constants

        private const string DSC_PAGES = "%%Pages:";
        private const string DSC_PAGE = "%%Page:";
        private const string DSC_BOUNDINGBOX = "%%BoundingBox:";
        private const string DSC_PAGEBOUNDINGBOX = "%%PageBoundingBox:";
        private const string DSC_TRAILER = "%%Trailer";
        private const string DSC_EOF = "%%EOF";

        #endregion

        #region Private variables

        private PostscriptDSCTokenizer _tokenizer;
        private Dictionary<int, DSCToken> _pageTokens = new Dictionary<int, DSCToken>();
        private DSCToken _lastPageEnding;

        #endregion

        #region Constructor

        public GhostscriptViewerPsFormatHandler(GhostscriptViewer viewer) : base(viewer) { }

        #endregion

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_tokenizer != null)
                {
                    _tokenizer.Dispose();
                    _tokenizer = null;
                }
            }

            base.Dispose(disposing);
        }

        #endregion

        #region Initialize

        public override void Initialize()
        {
            
        }

        #endregion

        #region Open

        public override void Open(string filePath)
        {
            this.OpenPsFile(filePath);
        }

        #endregion

        #region StdOutput

        public override void StdOutput(string message)
        {
            System.Diagnostics.Debug.WriteLine("PS OUT: " + message);
        }

        #endregion

        #region StdError

        public override void StdError(string message)
        {
            System.Diagnostics.Debug.WriteLine("PS OUT ERROR: " + message);
        }

        #endregion

        #region InitPage

        public override void InitPage(int pageNumber)
        {
            
        }

        #endregion

        #region ShowPage

        public override void ShowPage(int pageNumber)
        {
            this.CurrentPageNumber = pageNumber;

            DSCToken pageToken = _pageTokens[pageNumber];
            DSCToken pageEndToken;
            
            if (pageNumber == _pageTokens.Count)
            {
                pageEndToken = _lastPageEnding;
            }
            else
            {
                pageEndToken = _pageTokens[pageNumber + 1];
            }

            int pageSize = (int)(pageEndToken.StartPosition - pageToken.StartPosition);
            string pageContent = _tokenizer.ReadContent((int)pageToken.StartPosition, pageSize);

            this.Execute(pageContent);
        }

        #endregion

        #region OpenPsFile

        private void OpenPsFile(string path)
        {
            _tokenizer = new PostscriptDSCTokenizer(path);

            this.FirstPageNumber = 1;

            DSCToken token = null;

            // loop through all DSC comments based on keyword
            while ((token = _tokenizer.GetNextDSCKeywordToken()) != null)
            {
                switch (token.Text)
                {
                    case DSC_PAGES:        // %%Pages: <numpages> | (atend)
                        {
                            token = _tokenizer.GetNextDSCValueToken(DSCTokenEnding.Whitespace | DSCTokenEnding.LineEnd);
                            
                            // check if we need to ignore this comment because it's set at the end of the file
                            if (token.Text != "(atend)")
                            {
                                // we got it, memorize it
                                this.LastPageNumber = int.Parse(token.Text);
                            }

                            break;
                        }
                    case DSC_BOUNDINGBOX:  // { %%BoundingBox: <llx> <lly> <urx> <ury> } | (atend)
                        {
                            try
                            {
                                DSCToken llx = _tokenizer.GetNextDSCValueToken(DSCTokenEnding.Whitespace | DSCTokenEnding.LineEnd);

                                if (llx.Text != "(atend)")
                                {
                                    DSCToken lly = _tokenizer.GetNextDSCValueToken(DSCTokenEnding.Whitespace);
                                    DSCToken urx = _tokenizer.GetNextDSCValueToken(DSCTokenEnding.Whitespace);
                                    DSCToken ury = _tokenizer.GetNextDSCValueToken(DSCTokenEnding.Whitespace | DSCTokenEnding.LineEnd);

                                    this.BoundingBox = new RectangleF(
                                        float.Parse(urx.Text, System.Globalization.CultureInfo.InvariantCulture),
                                        float.Parse(ury.Text, System.Globalization.CultureInfo.InvariantCulture),
                                        float.Parse(llx.Text, System.Globalization.CultureInfo.InvariantCulture),
                                        float.Parse(lly.Text, System.Globalization.CultureInfo.InvariantCulture));
                                }
                            }
                            catch { }

                            break;
                        }
                    case DSC_PAGE:         // %%Page: <label> <ordinal>
                        {
                            // label can be anything, we need to get oridinal which is the last
                            // value of the line

                            DSCToken pageNumberToken;
                            
                            // loop through each comment value
                            while ((pageNumberToken = _tokenizer.GetNextDSCValueToken(DSCTokenEnding.Whitespace | DSCTokenEnding.LineEnd)) != null)
                            {
                                // check if this is the last comment value in this line
                                if (pageNumberToken.Ending == DSCTokenEnding.LineEnd)
                                {
                                    // we got it, add this comment keyword to the page list
                                    _pageTokens.Add(int.Parse(pageNumberToken.Text), token);
                                    break;
                                }
                            }

                            break;
                        }
                    case DSC_TRAILER:       // %%Trailer (no keywords)
                        {
                            // if the postscript is well formatted, we should get this one
                            // save this comment so we can know the position when the last page is ending
                            _lastPageEnding = token;

                            break;
                        }
                    case DSC_EOF:           // %%EOF (no keywords)
                        {
                            // check if we already know where the last page is ending
                            if (_lastPageEnding == null)
                            {
                                // we don't know, use start of the %%EOF comment as the last page ending position 
                                _lastPageEnding = token;
                            }

                            break;
                        }
                }
            }

            // check if we didn't find %%Trailer or %%EOF comment
            if (_lastPageEnding == null)
            {
                // it seems that the last page goes to the end of the file, set the last page ending
                // position to the complete file size value
                _lastPageEnding = new DSCToken();
                _lastPageEnding.StartPosition = _tokenizer.FileSize;
            }

            // we did'n find %%Pages comment, set the last page number to 1
            if (this.LastPageNumber == 0)
            {
                this.LastPageNumber = 1;
            }

            // check if we didn't find any %%Page comment
            if (_pageTokens.Count == 0)
            {
                // create dummy one that will point to the first byte in the file
                _pageTokens.Add(1, new DSCToken() { StartPosition = 0 });
            }

            // hpd = Header, Procedure definitions, Document setup
            // start position of the first %%Page: comment is te hpd size
            int hpdSize = (int)_pageTokens[1].StartPosition;
            // get the hpd text
            string hpdContent = _tokenizer.ReadContent(0, hpdSize);

            // process header, procedure definitions and document setup
            this.Execute(hpdContent);
        }

        #endregion

        #region enum DSCTokenEnding

        private enum DSCTokenEnding
        {
            LineEnd = 1,
            Whitespace = 2
        }

        #endregion

        #region class DSCToken

        private class DSCToken
        {
            #region Private variables

            private long _startPosition;
            private long _length;
            private string _text;
            private DSCTokenEnding _ending;

            #endregion

            #region StartPosition

            public long StartPosition
            {
                get { return _startPosition; }
                set { _startPosition = value; }
            }

            #endregion

            #region Length

            public long Length
            {
                get { return _length; }
                set { _length = value; }
            }

            #endregion

            #region Text

            public string Text
            {
                get { return _text; }
                set { _text = value; }
            }

            #endregion

            #region Ending

            public DSCTokenEnding Ending
            {
                get { return _ending; }
                set { _ending = value; }
            }

            #endregion

            #region ToString

            public override string ToString()
            {
                return _text;
            }

            #endregion
        }

        #endregion

        #region class PostscriptDSCTokenizer

        private class PostscriptDSCTokenizer : IDisposable
        {
            #region Private variables

            private bool _disposed = false;
            private FileStream _stream;
            private BufferedStream _bufferedStream;

            #endregion

            #region Constructor

            public PostscriptDSCTokenizer(string path)
            {
                _stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                _bufferedStream = new BufferedStream(_stream);
            }

            #endregion

            #region Destructor

            ~PostscriptDSCTokenizer()
            {
                this.Dispose(false);
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
                        _bufferedStream.Close();
                        _bufferedStream.Dispose();
                        _bufferedStream = null;

                        _stream.Close();
                        _stream.Dispose();
                        _stream = null;
                    }

                    _disposed = true;
                }
            }

            #endregion

            #endregion

            #region GetNextDSCKeywordToken

            public DSCToken GetNextDSCKeywordToken()
            {
                int c;

                while ((c = _bufferedStream.ReadByte()) > -1)
                {
                    if (c == '%')
                    {
                        if (_bufferedStream.ReadByte() == '%')
                        {
                            return this.ReadUntill("%%", DSCTokenEnding.Whitespace | DSCTokenEnding.LineEnd);
                        }
                    }
                }

                return null;
            }

            #endregion

            #region GetNextDSCValueToken

            public DSCToken GetNextDSCValueToken(DSCTokenEnding end)
            {
                return this.ReadUntill(string.Empty, end);
            }

            #endregion

            #region ReadUntill

            private DSCToken ReadUntill(string prefix, DSCTokenEnding end)
            {
                int c;
                DSCToken token = new DSCToken();
                token.StartPosition = _bufferedStream.Position - prefix.Length;

                StringBuilder text = new StringBuilder(prefix, 64);

                int lastAppendedChar = 0;

                while ((c = _bufferedStream.ReadByte()) > -1)
                {
                    if (c == '\n' && (end & DSCTokenEnding.LineEnd) == DSCTokenEnding.LineEnd)
                    {
                        token.Length = _bufferedStream.Position - 1 - token.StartPosition;
                        token.Text = text.ToString().Trim();
                        token.Ending = DSCTokenEnding.LineEnd;
                        return token;
                    }
                    else if (c == '\r' && _bufferedStream.ReadByte() == '\n' && (end & DSCTokenEnding.LineEnd) == DSCTokenEnding.LineEnd)
                    {
                        token.Length = _bufferedStream.Position - 2 - token.StartPosition;
                        token.Text = text.ToString().Trim();
                        token.Ending = DSCTokenEnding.LineEnd;
                        return token;
                    }
                    else if (c == ' ' && text.Length > 0 && lastAppendedChar != ' ' && (end & DSCTokenEnding.Whitespace) == DSCTokenEnding.Whitespace)
                    {
                        token.Length = _bufferedStream.Position - 1 - token.StartPosition;
                        token.Text = text.ToString().Trim();
                        token.Ending = DSCTokenEnding.Whitespace;
                        return token;
                    }
                    else
                    {
                        text.Append((char)c);
                        lastAppendedChar = c;
                    }
                }

                return null;
            }

            #endregion

            #region ReadContent

            public string ReadContent(int start, int count)
            {
                long bkpPos = _bufferedStream.Position;

                _bufferedStream.Seek(start, SeekOrigin.Begin);
                byte[] buffer = new byte[count];
                int readCount = _bufferedStream.Read(buffer, 0, count);

                _bufferedStream.Seek(bkpPos, SeekOrigin.Begin);

                return System.Text.Encoding.UTF8.GetString(buffer);
            }

            #endregion
            
            #region FileSize

            public long FileSize
            {
                get { return _bufferedStream.Length; }
            }

            #endregion

        }

        #endregion

    }
}
