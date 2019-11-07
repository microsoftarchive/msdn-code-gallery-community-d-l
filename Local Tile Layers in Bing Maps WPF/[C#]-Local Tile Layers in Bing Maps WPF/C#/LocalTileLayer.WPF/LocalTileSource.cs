using Microsoft.Maps.MapControl.WPF;
using Microsoft.Maps.MapControl.WPF.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LocalTileLayer.WPF
{
    public class LocalTileSource : TileSource
    {
        private string _tilePath = string.Empty;

        public LocalTileSource(string tilePath)
        {
            _tilePath = tilePath;

            this.DirectImage = new ImageCallback(TileRender);
        }

        public BitmapImage TileRender(long x, long y, int zoomLevel)
        {
            if (!string.IsNullOrWhiteSpace(_tilePath))
            {
                var q = new QuadKey((int)x, (int)y, zoomLevel);
                
                var filePath = _tilePath.Replace("{quadkey}", q.Key).Replace("{x}", x.ToString()).Replace("{y}", y.ToString()).Replace("{zoomlevel}", zoomLevel.ToString());

                var fi = new FileInfo(filePath);
                if (fi.Exists)
                {
                    using (var fStream = fi.OpenRead())
                    {
                        var bmp = new BitmapImage();
                        bmp.BeginInit();
                        bmp.StreamSource = fStream;
                        bmp.CacheOption = BitmapCacheOption.OnLoad;
                        bmp.EndInit();
                        return bmp;
                    }
                }
            }

            return CreateTransparentTile();
        }
        
        private BitmapImage CreateTransparentTile()
        {
            int width = 256;
            int height = 256;

            var source = BitmapSource.Create(width, height,
                                            96, 96,
                                            PixelFormats.Indexed1,
                                            new BitmapPalette(new List<Color>(){
                                                Colors.Transparent
                                            }),
                                            new byte[width * height],
                                            width);

            var image = new BitmapImage();

            var memoryStream = new MemoryStream();

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(source));
            encoder.Save(memoryStream);

            memoryStream.Position = 0;
            
            image.BeginInit();
            image.StreamSource = memoryStream;
            image.EndInit();

            return image;
        }
    }
}
