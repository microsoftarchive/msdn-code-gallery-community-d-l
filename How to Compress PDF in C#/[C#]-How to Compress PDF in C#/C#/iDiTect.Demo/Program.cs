using iDiTect.Licensing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDiTect.Demo
{
    class Program
    {
        static void Main(string[] args)
        {            
            CompressHelper.CompressPDF();
            ImageHelper.ConvertPDF2Image();
            SignatureHelper.AddTextSignature2PDF();
            TextHelper.PDF2Text();
            WatermarkHelper.TextWatermark();
        }

       

        

        


    }
}
