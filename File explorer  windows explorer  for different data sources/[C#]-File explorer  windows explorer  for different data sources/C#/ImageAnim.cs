using System;
using System.Net;
using System.IO;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Resources;
using System.Collections.Generic;

namespace FileExplorer
{
    /// <summary>
    /// Image animation exception event
    /// </summary>
    public class ImageAnimExceptionRoutedEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// Error exception class
        /// </summary>
        public Exception ErrorException;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="routedEvent">Routed event</param>
        /// <param name="obj">Object</param>
        public ImageAnimExceptionRoutedEventArgs(RoutedEvent routedEvent, object obj)
            : base(routedEvent, obj)
        {
        }
    }

    class WebReadState
    {
        public WebRequest webRequest;
        public MemoryStream memoryStream;
        public Stream readStream;
        public byte[] buffer;
    }

    public partial class ImageAnim : IDisposable
    {
        private bool _alreadyDisposed = false;

        // Summary:
        //     Performs application-defined tasks associated with freeing, releasing, or
        //     resetting unmanaged resources.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (_alreadyDisposed)
                return;
            if (isDisposing)
            {
                // TODO: release managed resources
                DeletePreviousImage();

                if (_gifAnimation != null)
                {
                    _gifAnimation.Reset();
                }
                _gifAnimation = null;
                _image = null;
                isFirstLoaded = true;
            }
            // TODO: release unmanaged resources
            _alreadyDisposed = true;
        }

        ~ImageAnim()
        {
            Dispose(false);
        }
    }

    class GifAnimation : Viewbox
    {
        private class GifFrame : Image
        {
            public int delayTime;
            public int disposalMethod;
            public int left;
            public int top;
            public int width;
            public int height;
        }

        // Gif Animation Fields
        private Canvas _canvas = null;

        private List<GifFrame> _frameList = null;

        private int _frameCounter = 0;
        private int _numberOfFrames = 0;

        private int _numberOfLoops = -1;
        private int _currentLoop = 0;

        private int _logicalWidth = 0;
        private int _logicalHeight = 0;

        private DispatcherTimer _frameTimer = null;

        private GifFrame _currentParseGifFrame;

        public GifAnimation()
        {
            _canvas = new Canvas();
            this.Child = _canvas;
        }

        public void Reset()
        {
            if (_frameList != null)
            {
                _frameList.Clear();
            }
            _frameList = null;
            _frameCounter = 0;
            _numberOfFrames = 0;
            _numberOfLoops = -1;
            _currentLoop = 0;
            _logicalWidth = 0;
            _logicalHeight = 0;
            if (_frameTimer != null)
            {
                _frameTimer.Stop();
                _frameTimer = null;
            }
        }

        private void ParseGif(byte[] gifData)
        {
            _frameList = new List<GifFrame>();
            _currentParseGifFrame = new GifFrame();
            ParseGifDataStream(gifData, 0);
        }

        private int ParseBlock(byte[] gifData, int offset)
        {
            switch (gifData[offset])
            {
                case 0x21:
                    if (gifData[offset + 1] == 0xF9)
                    {
                        return ParseGraphicControlExtension(gifData, offset);
                    }
                    else
                    {
                        return ParseExtensionBlock(gifData, offset);
                    }
                case 0x2C:
                    offset = ParseGraphicBlock(gifData, offset);
                    _frameList.Add(_currentParseGifFrame);
                    _currentParseGifFrame = new GifFrame();
                    return offset;
                case 0x3B:
                    return -1;
                default:
                    //ToDo
                    throw new Exception("GIF format incorrect: missing graphic block or special-purpose block. ");
            }
        }

        private int ParseGraphicControlExtension(byte[] gifData, int offset)
        {
            int returnOffset = offset;
            // Extension Block
            int length = gifData[offset + 2];
            returnOffset = offset + length + 2 + 1;

            byte packedField = gifData[offset + 3];
            _currentParseGifFrame.disposalMethod = (packedField & 0x1C) >> 2;

            // Get DelayTime
            int delay = BitConverter.ToUInt16(gifData, offset + 4);
            _currentParseGifFrame.delayTime = delay;
            while (gifData[returnOffset] != 0x00)
            {
                returnOffset = returnOffset + gifData[returnOffset] + 1;
            }

            returnOffset++;

            return returnOffset;
        }

        private int ParseLogicalScreen(byte[] gifData, int offset)
        {
            _logicalWidth = BitConverter.ToUInt16(gifData, offset);
            _logicalHeight = BitConverter.ToUInt16(gifData, offset + 2);

            byte packedField = gifData[offset + 4];
            bool hasGlobalColorTable = (int)(packedField & 0x80) > 0 ? true : false;

            int currentIndex = offset + 7;
            if (hasGlobalColorTable)
            {
                int colorTableLength = packedField & 0x07;
                colorTableLength = (int)Math.Pow(2, colorTableLength + 1) * 3;
                currentIndex = currentIndex + colorTableLength;
            }
            return currentIndex;
        }

        private int ParseGraphicBlock(byte[] gifData, int offset)
        {
            _currentParseGifFrame.left = BitConverter.ToUInt16(gifData, offset + 1);
            _currentParseGifFrame.top = BitConverter.ToUInt16(gifData, offset + 3);
            _currentParseGifFrame.width = BitConverter.ToUInt16(gifData, offset + 5);
            _currentParseGifFrame.height = BitConverter.ToUInt16(gifData, offset + 7);
            if (_currentParseGifFrame.width > _logicalWidth)
            {
                _logicalWidth = _currentParseGifFrame.width;
            }
            if (_currentParseGifFrame.height > _logicalHeight)
            {
                _logicalHeight = _currentParseGifFrame.height;
            }
            byte packedField = gifData[offset + 9];
            bool hasLocalColorTable = (int)(packedField & 0x80) > 0 ? true : false;

            int currentIndex = offset + 9;
            if (hasLocalColorTable)
            {
                int colorTableLength = packedField & 0x07;
                colorTableLength = (int)Math.Pow(2, colorTableLength + 1) * 3;
                currentIndex = currentIndex + colorTableLength;
            }
            currentIndex++; // Skip 0x00

            currentIndex++; // Skip LZW Minimum Code Size;

            while (gifData[currentIndex] != 0x00)
            {
                int length = gifData[currentIndex];
                currentIndex = currentIndex + gifData[currentIndex];
                currentIndex++; // Skip initial size byte
            }
            currentIndex = currentIndex + 1;
            return currentIndex;
        }

        private int ParseExtensionBlock(byte[] gifData, int offset)
        {
            int returnOffset = offset;
            // Extension Block
            int length = gifData[offset + 2];
            returnOffset = offset + length + 2 + 1;
            // check if netscape continousLoop extension
            if (gifData[offset + 1] == 0xFF && length > 10)
            {
                string netscape = System.Text.ASCIIEncoding.ASCII.GetString(gifData, offset + 3, 8);
                if (netscape == "NETSCAPE")
                {
                    _numberOfLoops = BitConverter.ToUInt16(gifData, offset + 16);
                    if (_numberOfLoops > 0)
                    {
                        _numberOfLoops++;
                    }
                }
            }
            while (gifData[returnOffset] != 0x00)
            {
                returnOffset = returnOffset + gifData[returnOffset] + 1;
            }

            returnOffset++;

            return returnOffset;
        }

        private int ParseHeader(byte[] gifData, int offset)
        {
            string str = System.Text.ASCIIEncoding.ASCII.GetString(gifData, offset, 3);
            if (str != "GIF")
            {
                //ToDo
                throw new Exception("Not a proper GIF file: missing GIF header");
            }
            return 6;
        }

        private void ParseGifDataStream(byte[] gifData, int offset)
        {
            offset = ParseHeader(gifData, offset);
            offset = ParseLogicalScreen(gifData, offset);
            while (offset != -1)
            {
                offset = ParseBlock(gifData, offset);
            }
        }

        public void CreateGifAnimation(MemoryStream memoryStream)
        {
            Reset();

            byte[] gifData = memoryStream.GetBuffer();  // Use GetBuffer so that there is no memory copy

            GifBitmapDecoder decoder = new GifBitmapDecoder(memoryStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);

            _numberOfFrames = decoder.Frames.Count;

            try
            {
                ParseGif(gifData);
            }
            catch
            {
                throw new FileFormatException("Unable to parse Gif file format.");
            }

            for (int f = 0; f < decoder.Frames.Count; f++)
            {
                _frameList[f].Source = decoder.Frames[f];
                _frameList[f].Visibility = Visibility.Hidden;
                _canvas.Children.Add(_frameList[f]);
                Canvas.SetLeft(_frameList[f], _frameList[f].left);
                Canvas.SetTop(_frameList[f], _frameList[f].top);
                Canvas.SetZIndex(_frameList[f], f);
            }
            _canvas.Height = _logicalHeight;
            _canvas.Width = _logicalWidth;

            _frameList[0].Visibility = Visibility.Visible;
            if (_frameList.Count > 1)
            {
                if (_numberOfLoops == -1)
                {
                    _numberOfLoops = 1;
                }
                _frameTimer = new System.Windows.Threading.DispatcherTimer();
                _frameTimer.Tick += NextFrame;
                _frameTimer.Interval = new TimeSpan(0, 0, 0, 0, _frameList[0].delayTime * 10);
                _frameTimer.Start();
            }
        }

        public void NextFrame()
        {
            NextFrame(null, null);
        }

        public void NextFrame(object sender, EventArgs e)
        {
            _frameTimer.Stop();
            if (_numberOfFrames == 0) return;
            if (_frameList[_frameCounter].disposalMethod == 2)
            {
                _frameList[_frameCounter].Visibility = Visibility.Hidden;
            }
            if (_frameList[_frameCounter].disposalMethod >= 3)
            {
                _frameList[_frameCounter].Visibility = Visibility.Hidden;
            }
            _frameCounter++;

            if (_frameCounter < _numberOfFrames)
            {
                _frameList[_frameCounter].Visibility = Visibility.Visible;
                _frameTimer.Interval = new TimeSpan(0, 0, 0, 0, _frameList[_frameCounter].delayTime * 10);
                _frameTimer.Start();
            }
            else
            {
                if (_numberOfLoops != 0)
                {
                    _currentLoop++;
                }
                if (_currentLoop < _numberOfLoops || _numberOfLoops == 0)
                {
                    for (int f = 0; f < _frameList.Count; f++)
                    {
                        _frameList[f].Visibility = Visibility.Hidden;
                    }
                    _frameCounter = 0;
                    _frameList[_frameCounter].Visibility = Visibility.Visible;
                    _frameTimer.Interval = new TimeSpan(0, 0, 0, 0, _frameList[_frameCounter].delayTime * 10);
                    _frameTimer.Start();
                }
            }
        }
    }

    /// <summary>
    /// Image amination control
    /// </summary>
    public partial class ImageAnim : System.Windows.Controls.UserControl
    {
        // Only one of the following (_gifAnimation or _image) should be non null at any given time
        private GifAnimation _gifAnimation = null;
        private Image _image = null;

        private bool isFirstLoaded = true;
        public bool IsSelfDestroy
        {
            get { return (bool)GetValue(IsSelfDestroyProperty); }
            set { SetValue(IsSelfDestroyProperty, value); }
        }

        public static readonly DependencyProperty IsSelfDestroyProperty =
            DependencyProperty.Register("IsSelfDestroy", typeof(bool),
            typeof(ImageAnim), new UIPropertyMetadata(false));

        public ImageAnim()
        {
            this.Loaded += ImageAnim_Loaded;
            this.Unloaded += ImageAnim_Unloaded;
        }

        void ImageAnim_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstLoaded && !IsSelfDestroy)
            {
                this.CreateFromSourceString(Source);
            }
            isFirstLoaded = false;
        }

        void ImageAnim_Unloaded(object sender, RoutedEventArgs e)
        {
            if (IsSelfDestroy)
                Dispose();
            else
            {
                DeletePreviousImage();
            }
        }

        /// <summary>
        /// Force gif anim property
        /// </summary>
        public static readonly DependencyProperty ForceGifAnimProperty = DependencyProperty.Register("ForceGifAnim", typeof(bool), typeof(ImageAnim), new FrameworkPropertyMetadata(false));
        /// <summary>
        /// Force gif anim property
        /// </summary>
        public bool ForceGifAnim
        {
            get { return (bool)this.GetValue(ForceGifAnimProperty); }
            set { this.SetValue(ForceGifAnimProperty, value); }
        }

        /// <summary>
        /// Source property
        /// </summary>
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(string), typeof(ImageAnim), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OnSourceChanged)));
      /// <summary>
        /// Source property
      /// </summary>
        /// <param name="d">Dependency object</param>
        /// <param name="e">Dependency property changed event args</param>
        private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ImageAnim obj = (ImageAnim)d;
            string s = (string)e.NewValue;
            obj.CreateFromSourceString(s);
        }
        /// <summary>
        /// Source
        /// </summary>
        public string Source
        {
            get { return (string)this.GetValue(SourceProperty); }
            set { this.SetValue(SourceProperty, value); }
        }

        /// <summary>
        /// Stretch property 
        /// </summary>
        public static readonly DependencyProperty StretchProperty = DependencyProperty.Register("Stretch", typeof(Stretch), typeof(ImageAnim), new FrameworkPropertyMetadata(Stretch.Fill, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(OnStretchChanged)));
        /// <summary>
        /// Stretch property 
        /// </summary>
        /// <param name="d">Dependency object</param>
        /// <param name="e">Dependency property changed event args</param>
        private static void OnStretchChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ImageAnim obj = (ImageAnim)d;
            Stretch s = (Stretch)e.NewValue;
            if (obj._gifAnimation != null)
            {
                obj._gifAnimation.Stretch = s;
            }
            else if (obj._image != null)
            {
                obj._image.Stretch = s;
            }
        }
        /// <summary>
        /// Stretch
        /// </summary>
        public Stretch Stretch
        {
            get { return (Stretch)this.GetValue(StretchProperty); }
            set { this.SetValue(StretchProperty, value); }
        }
        /// <summary>
        /// Stretch direction property
        /// </summary>
        public static readonly DependencyProperty StretchDirectionProperty = DependencyProperty.Register("StretchDirection", typeof(StretchDirection), typeof(ImageAnim), new FrameworkPropertyMetadata(StretchDirection.Both, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(OnStretchDirectionChanged)));
        /// <summary>
        /// Stretch direction property
        /// </summary>
        /// <param name="d">Dependency object</param>
        /// <param name="e">Dependency property changed event args</param>
        private static void OnStretchDirectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ImageAnim obj = (ImageAnim)d;
            StretchDirection s = (StretchDirection)e.NewValue;
            if (obj._gifAnimation != null)
            {
                obj._gifAnimation.StretchDirection = s;
            }
            else if (obj._image != null)
            {
                obj._image.StretchDirection = s;
            }
        }
        /// <summary>
        /// Strech direction
        /// </summary>
        public StretchDirection StretchDirection
        {
            get { return (StretchDirection)this.GetValue(StretchDirectionProperty); }
            set { this.SetValue(StretchDirectionProperty, value); }
        }

        /// <summary>
        /// Image amination exception event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="args">Event args</param>
        public delegate void ExceptionRoutedEventHandler(object sender, ImageAnimExceptionRoutedEventArgs args);

        /// <summary>
        /// Image failed event
        /// </summary>
        public static readonly RoutedEvent ImageFailedEvent = EventManager.RegisterRoutedEvent("ImageFailed", RoutingStrategy.Bubble, typeof(ExceptionRoutedEventHandler), typeof(ImageAnim));
        /// <summary>
        /// Image faild event
        /// </summary>
        public event ExceptionRoutedEventHandler ImageFailed
        {
            add { AddHandler(ImageFailedEvent, value); }
            remove { RemoveHandler(ImageFailedEvent, value); }
        }

        void _image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            RaiseImageFailedEvent(e.ErrorException);
        }

        void RaiseImageFailedEvent(Exception exp)
        {
            ImageAnimExceptionRoutedEventArgs newArgs = new ImageAnimExceptionRoutedEventArgs(ImageFailedEvent, this);
            newArgs.ErrorException = exp;
            RaiseEvent(newArgs);
        }

        private void DeletePreviousImage()
        {
            if (_image != null)
            {
                this.RemoveLogicalChild(_image);
                _image = null;
            }
            if (_gifAnimation != null)
            {
                this.RemoveLogicalChild(_gifAnimation);
                _gifAnimation.Reset();
                _gifAnimation = null;
            }
        }

        private void CreateNonGifAnimationImage()
        {
            _image = new Image();
            _image.ImageFailed += new EventHandler<ExceptionRoutedEventArgs>(_image_ImageFailed);
            ImageSource src = (ImageSource)(new ImageSourceConverter().ConvertFromString(Source));
            _image.Source = src;
            _image.Stretch = Stretch;
            _image.StretchDirection = StretchDirection;
            this.Content = null;
            this.AddChild(_image);
        }

        private void CreateGifAnimation(MemoryStream memoryStream)
        {
            _gifAnimation = new GifAnimation();
            _gifAnimation.CreateGifAnimation(memoryStream);
            _gifAnimation.Stretch = Stretch;
            _gifAnimation.StretchDirection = StretchDirection;
            //DeletePreviousImage(); //Why delete?
            this.Content = null;
            this.AddChild(_gifAnimation);
        }

        private void CreateFromSourceString(string source)
        {
            DeletePreviousImage();
            Uri uri;
            try
            {
                uri = new Uri(source, UriKind.RelativeOrAbsolute);
            }
            catch (Exception exp)
            {
                RaiseImageFailedEvent(exp);
                return;
            }

            if (source.Trim().ToUpperInvariant().EndsWith(".GIF", StringComparison.InvariantCulture) || ForceGifAnim)
            {
                if (!uri.IsAbsoluteUri)
                {
                    GetGifStreamFromPack(uri);
                }
                else
                {

                    string leftPart = uri.GetLeftPart(UriPartial.Scheme);

                    if (leftPart == "http://" || leftPart == "ftp://" || leftPart == "file://")
                    {
                        GetGifStreamFromHttp(uri);
                    }
                    else if (leftPart == "pack://")
                    {
                        GetGifStreamFromPack(uri);
                    }
                    else
                    {
                        CreateNonGifAnimationImage();
                    }
                }
            }
            else
            {
                CreateNonGifAnimationImage();
            }
        }

        private delegate void WebRequestFinishedDelegate(MemoryStream memoryStream);

        private void WebRequestFinished(MemoryStream memoryStream)
        {
            CreateGifAnimation(memoryStream);
        }

        private delegate void WebRequestErrorDelegate(Exception exp);

        private void WebRequestError(Exception exp)
        {
            RaiseImageFailedEvent(exp);
        }

        private void WebResponseCallback(IAsyncResult asyncResult)
        {
            WebReadState webReadState = (WebReadState)asyncResult.AsyncState;
            WebResponse webResponse;
            try
            {
                webResponse = webReadState.webRequest.EndGetResponse(asyncResult);
                webReadState.readStream = webResponse.GetResponseStream();
                webReadState.buffer = new byte[100000];
                webReadState.readStream.BeginRead(webReadState.buffer, 0, webReadState.buffer.Length, new AsyncCallback(WebReadCallback), webReadState);
            }
            catch (WebException exp)
            {
                this.Dispatcher.Invoke(DispatcherPriority.Render, new WebRequestErrorDelegate(WebRequestError), exp);
            }
        }

        private void WebReadCallback(IAsyncResult asyncResult)
        {
            WebReadState webReadState = (WebReadState)asyncResult.AsyncState;
            int count = webReadState.readStream.EndRead(asyncResult);
            if (count > 0)
            {
                webReadState.memoryStream.Write(webReadState.buffer, 0, count);
                try
                {
                    webReadState.readStream.BeginRead(webReadState.buffer, 0, webReadState.buffer.Length, new AsyncCallback(WebReadCallback), webReadState);
                }
                catch (WebException exp)
                {
                    this.Dispatcher.Invoke(DispatcherPriority.Render, new WebRequestErrorDelegate(WebRequestError), exp);
                }
            }
            else
            {
                this.Dispatcher.Invoke(DispatcherPriority.Render, new WebRequestFinishedDelegate(WebRequestFinished), webReadState.memoryStream);
            }
        }

        private void GetGifStreamFromHttp(Uri uri)
        {
            try
            {
                WebReadState webReadState = new WebReadState();
                webReadState.memoryStream = new MemoryStream();
                webReadState.webRequest = WebRequest.Create(uri);
                webReadState.webRequest.Timeout = 10000;

                webReadState.webRequest.BeginGetResponse(new AsyncCallback(WebResponseCallback), webReadState);
            }
            catch (SecurityException)
            {
                // Try image load, The Image class can display images from other web sites
                CreateNonGifAnimationImage();
            }
        }

        private void ReadGifStreamSynch(Stream s)
        {
            byte[] gifData;
            MemoryStream memoryStream;
            using (s)
            {
                memoryStream = new MemoryStream((int)s.Length);
                BinaryReader br = new BinaryReader(s);
                gifData = br.ReadBytes((int)s.Length);
                memoryStream.Write(gifData, 0, (int)s.Length);
                memoryStream.Flush();
            }
            CreateGifAnimation(memoryStream);
        }

        private void GetGifStreamFromPack(Uri uri)
        {
            try
            {
                StreamResourceInfo streamInfo;

                if (!uri.IsAbsoluteUri)
                {
                    streamInfo = Application.GetContentStream(uri);
                    if (streamInfo == null)
                    {
                        streamInfo = Application.GetResourceStream(uri);
                    }
                }
                else
                {
                    if (uri.GetLeftPart(UriPartial.Authority).Contains("siteoforigin"))
                    {
                        streamInfo = Application.GetRemoteStream(uri);
                    }
                    else
                    {
                        streamInfo = Application.GetContentStream(uri);
                        if (streamInfo == null)
                        {
                            streamInfo = Application.GetResourceStream(uri);
                        }
                    }
                }
                if (streamInfo == null)
                {
                    //ToDo
                    throw new FileNotFoundException("Resource not found.", uri.ToString());
                }
                ReadGifStreamSynch(streamInfo.Stream);
            }
            catch (Exception exp)
            {
                RaiseImageFailedEvent(exp);
            }
        }
    }
}
