using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace Base64Thumbnails
{
    public static class ExtBitmap
    {
        public static List<string> ToBase64Thumbnails(this string path, int width, int height, bool wrapImageTag, params string[] fileTypes)
        {
            List<string> base64Thumbnails = new List<string>();

            string searchFilter = String.Empty;

            if (fileTypes != null)
            {
                for (int k = 0; k < fileTypes.Length; k++)
                {
                    searchFilter += "*." + fileTypes[k];

                    if (k < fileTypes.Length - 1)
                    {
                        searchFilter += "|";
                    }
                }
            }
            else
            {
                searchFilter = "*.*";
            }

            string[] files = Directory.GetFiles(path, searchFilter);

            for (int k = 0; k < files.Length; k++)
            {
                StreamReader streamReader = new StreamReader(files[k]);
                Image img = Image.FromStream(streamReader.BaseStream);
                streamReader.Close();

                base64Thumbnails.Add(img.ToBase64Thumbnail(width, height, wrapImageTag));

                img.Dispose();
            }

            return base64Thumbnails;
        }

        public static string ToBase64Thumbnail(this Image bmp, int width, int height, bool wrapImageTag)
        {
            Image.GetThumbnailImageAbort callback = new Image.GetThumbnailImageAbort(ThumbnailCallback);

            Image thumbnailImage = bmp.GetThumbnailImage(width, height, callback, new IntPtr());

            string base64String = String.Empty;

            if (wrapImageTag == true)
            {
                base64String = thumbnailImage.ToBase64ImageTag();
            }
            else
            {
                base64String = thumbnailImage.ToBase64String();
            }

            thumbnailImage.Dispose();

            return base64String;
        }

        private static bool ThumbnailCallback()
        {
            return true;
        }
        
        public static string ToBase64String(this Image bmp)
        {
            string base64String = string.Empty;
            MemoryStream memoryStream = null;

            try
            {
                memoryStream = new MemoryStream();
                bmp.Save(memoryStream, ImageFormat.Png);
            }
            catch (Exception exc)
            {
                return String.Empty;
            }

            memoryStream.Position = 0;
            byte[] byteBuffer = memoryStream.ToArray();

            memoryStream.Close();

            base64String = Convert.ToBase64String(byteBuffer, Base64FormattingOptions.InsertLineBreaks);
            byteBuffer = null;

            return base64String;
        }

        public static string ToBase64ImageTag(this Image bmp)
        {
            string imgTag = string.Empty;
            string base64String = string.Empty;

            base64String = bmp.ToBase64String();

            imgTag = "<img src=\"data:image/" + "png" + ";base64,";
            imgTag += base64String + "\" ";
            imgTag += "width=\"" + bmp.Width.ToString() + "\" ";
            imgTag += "height=\"" + bmp.Height.ToString() + "\" />";

            return imgTag;
        }

        public static Bitmap Base64StringToBitmap(this string base64String)
        {
            Bitmap bmpReturn = null;
            byte[] byteBuffer = null;

            try
            {
                byteBuffer = Convert.FromBase64String(base64String);
            }
            catch (Exception exc)
            {
                return null;
            }

            MemoryStream memoryStream = new MemoryStream(byteBuffer);

            memoryStream.Position = 0;

            bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);

            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;

            return bmpReturn;
        }
    }
}
