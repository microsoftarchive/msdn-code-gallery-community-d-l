using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace convert_word_to_tiff
{
    class Program
    {
        static void Main(string[] args)
        {
            Document document = new Document(@"E:\Visual Studio\Sample\baby.docx");
            JoinTiffImages(SaveAsImage(document), "result.tiff", EncoderValue.CompressionLZW);
            System.Diagnostics.Process.Start("result.tiff");
        }

        private static Image[] SaveAsImage(Document document)
        {
            Image[] images = document.SaveToImages(ImageType.Bitmap);
            return images;
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            for (int j = 0; j < encoders.Length; j++)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            throw new Exception(mimeType + " mime type not found in ImageCodecInfo");
        }

        public static void JoinTiffImages(Image[] images, string outFile, EncoderValue compressEncoder)
        {
            //use the save encoder
            System.Drawing.Imaging.Encoder enc = System.Drawing.Imaging.Encoder.SaveFlag;
            EncoderParameters ep = new EncoderParameters(2);
            ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.MultiFrame);
            ep.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)compressEncoder);
            Image pages = images[0];
            int frame = 0;
            ImageCodecInfo info = GetEncoderInfo("image/tiff");
            foreach (Image img in images)
            {
                if (frame == 0)
                {
                    pages = img;
                    //save the first frame
                    pages.Save(outFile, info, ep);
                }

                else
                {
                    //save the intermediate frames
                    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.FrameDimensionPage);

                    pages.SaveAdd(img, ep);
                }
                if (frame == images.Length - 1)
                {
                    //flush and close.
                    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.Flush);
                    pages.SaveAdd(ep);
                }
                frame++;
            }
        }
    }
}
