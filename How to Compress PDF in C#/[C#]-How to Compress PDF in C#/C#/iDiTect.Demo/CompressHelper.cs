using iDiTect.Licensing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDiTect.Demo
{
    public static class CompressHelper
    {
        public static void CompressPDF()
        {
            //Please repace the trial key from trial-license.txt in download package 
            //This license registration line need to be at very beginning of our other code
            LicenseManager.SetKey("trial key");

            //Load PDF document
            PdfCompressor document = new PdfCompressor("sample.pdf"); 
            //Whether compress text content
            document.CompressContent = true;
            //Whether compress image embedded 
            document.CompressImage = true;
            //Whether delete the annotations
            document.RemoveAnnotations = false;
            //Whether delete the customized meta data
            document.RemoveMetaData = false;

            //Compress document
            document.Compress("compressed.pdf");
        }
        
       
    }
}
