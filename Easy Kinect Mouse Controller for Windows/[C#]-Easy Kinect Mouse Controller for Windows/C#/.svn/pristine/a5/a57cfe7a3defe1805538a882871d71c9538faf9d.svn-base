//------------------------------------------------------------------------------
// <copyright file="KinectDepthViewer.xaml.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Microsoft.Samples.Kinect.WpfViewers
{
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Microsoft.Kinect;

    /// <summary>
    /// Interaction logic for KinectDepthViewer.xaml
    /// </summary>
    public partial class KinectDepthViewer : ImageViewer
    {
        // color divisors for tinting depth pixels
        private static readonly int[] IntensityShiftByPlayerR = { 1, 2, 0, 2, 0, 0, 2, 0 };
        private static readonly int[] IntensityShiftByPlayerG = { 1, 2, 2, 0, 2, 0, 0, 1 };
        private static readonly int[] IntensityShiftByPlayerB = { 1, 0, 2, 2, 0, 2, 0, 2 };

        private const int RedIndex = 2;
        private const int GreenIndex = 1;
        private const int BlueIndex = 0;
        private static readonly int Bgr32BytesPerPixel = (PixelFormats.Bgr32.BitsPerPixel + 7) / 8;

        private DepthImageFormat lastImageFormat;
        private short[] pixelData;

        // We want to control how depth data gets converted into false-color data
        // for more intuitive visualization, so we keep 32-bit color frame buffer versions of
        // these, to be updated whenever we receive and process a 16-bit frame.
        private byte[] depthFrame32;
        private WriteableBitmap outputBitmap;

        public KinectDepthViewer()
        {
            InitializeComponent();
        }

        protected override void OnKinectChanged(KinectSensor oldKinectSensor, KinectSensor newKinectSensor)
        {
            if (oldKinectSensor != null)
            {
                oldKinectSensor.DepthFrameReady -= this.DepthImageReady;
                kinectDepthImage.Source = null;
                this.lastImageFormat = DepthImageFormat.Undefined;
            }

            if (newKinectSensor != null && newKinectSensor.Status == KinectStatus.Connected)
            {
                ResetFrameRateCounters();

                newKinectSensor.DepthFrameReady += this.DepthImageReady;
            }
        }

        private void DepthImageReady(object sender, DepthImageFrameReadyEventArgs e)
        {
            using (DepthImageFrame imageFrame = e.OpenDepthImageFrame())
            {
                if (imageFrame != null)
                {
                    // We need to detect if the format has changed.
                    bool haveNewFormat = this.lastImageFormat != imageFrame.Format;

                    if (haveNewFormat)
                    {
                        this.pixelData = new short[imageFrame.PixelDataLength];
                        this.depthFrame32 = new byte[imageFrame.Width * imageFrame.Height * Bgr32BytesPerPixel];
                    }

                    imageFrame.CopyPixelDataTo(this.pixelData);

                    byte[] convertedDepthBits = this.ConvertDepthFrame(this.pixelData, ((KinectSensor)sender).DepthStream);

                    // A WriteableBitmap is a WPF construct that enables resetting the Bits of the image.
                    // This is more efficient than creating a new Bitmap every frame.
                    if (haveNewFormat)
                    {
                        this.outputBitmap = new WriteableBitmap(
                            imageFrame.Width, 
                            imageFrame.Height, 
                            96,  // DpiX
                            96,  // DpiY
                            PixelFormats.Bgr32, 
                            null);

                        this.kinectDepthImage.Source = this.outputBitmap;
                    }

                    this.outputBitmap.WritePixels(
                        new Int32Rect(0, 0, imageFrame.Width, imageFrame.Height), 
                        convertedDepthBits,
                        imageFrame.Width * Bgr32BytesPerPixel,
                        0);

                    this.lastImageFormat = imageFrame.Format;

                    UpdateFrameRate();
                }
            }
        }

        // Converts a 16-bit grayscale depth frame which includes player indexes into a 32-bit frame
        // that displays different players in different colors
        private byte[] ConvertDepthFrame(short[] depthFrame, DepthImageStream depthStream)
        {
            int tooNearDepth = depthStream.TooNearDepth;
            int tooFarDepth = depthStream.TooFarDepth;
            int unknownDepth = depthStream.UnknownDepth;

            for (int i16 = 0, i32 = 0; i16 < depthFrame.Length && i32 < this.depthFrame32.Length; i16++, i32 += 4)
            {
                int player = depthFrame[i16] & DepthImageFrame.PlayerIndexBitmask;
                int realDepth = depthFrame[i16] >> DepthImageFrame.PlayerIndexBitmaskWidth;
                
                // transform 13-bit depth information into an 8-bit intensity appropriate
                // for display (we disregard information in most significant bit)
                byte intensity = (byte)(~(realDepth >> 4));

                if (player == 0 && realDepth == 0)
                {
                    // white 
                    this.depthFrame32[i32 + RedIndex] = 255;
                    this.depthFrame32[i32 + GreenIndex] = 255;
                    this.depthFrame32[i32 + BlueIndex] = 255;
                }
                else if (player == 0 && realDepth == tooFarDepth)
                {
                    // dark purple
                    this.depthFrame32[i32 + RedIndex] = 66;
                    this.depthFrame32[i32 + GreenIndex] = 0;
                    this.depthFrame32[i32 + BlueIndex] = 66;
                }
                else if (player == 0 && realDepth == unknownDepth)
                {
                    // dark brown
                    this.depthFrame32[i32 + RedIndex] = 66;
                    this.depthFrame32[i32 + GreenIndex] = 66;
                    this.depthFrame32[i32 + BlueIndex] = 33;
                }
                else
                {
                    // tint the intensity by dividing by per-player values
                    this.depthFrame32[i32 + RedIndex] = (byte)(intensity >> IntensityShiftByPlayerR[player]);
                    this.depthFrame32[i32 + GreenIndex] = (byte)(intensity >> IntensityShiftByPlayerG[player]);
                    this.depthFrame32[i32 + BlueIndex] = (byte)(intensity >> IntensityShiftByPlayerB[player]);
                }
            }

            return this.depthFrame32;
        }
    }
}
