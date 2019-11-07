using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileExplorer.Helper
{
    public static class FileExtension
    {
        /// <summary> The image extensions. </summary>
        public static string[] GetImageExtensions()
        {
            return new string[]
            {            
                ".BMP",
                ".GIF",
                ".JPE",
                ".JPEG",
                ".JPG",
                ".LJP",
                ".PNG",
                ".TIF",
                ".TIFF",
                ".3FR",
	            ".ARI",
	            ".ARW",
	            ".SRF",
	            ".SR2",
	            ".BAY",
	            ".CRW",
	            ".CR2",
	            ".CAP",
	            ".IIQ",
	            ".EIP",
	            ".DCS",
	            ".DCR",
	            ".DRF",
	            ".K25",
	            ".KDC",
	            ".DNG",
	            ".ERF",
	            ".FFF",
	            ".MEF",
	            ".MDC",
	            ".MOS",
	            ".MRW",
	            ".NEF",
	            ".NRW",
	            ".ORF",
	            ".PEF",
	            ".PTX",
	            ".PXN",
	            ".R3D",
	            ".RAF",
	            ".RAW",
	            ".RW2",
	            ".RAW",
	            ".RWL",
	            ".DNG",
	            ".RWZ",
	            ".SRW",
	            ".X3F",
            };
        }

        /// <summary> The audio extensions. </summary>
        public static string[] GetAudioExtensions()
        {
            return new string[]
            {            
                ".AAC",
                ".AC3",
                ".AIF",
                ".AIFF",
                ".APE",
                ".FLAC",
                ".M2A",
                ".M4A",
                ".MKA",
                ".MP2",
                ".MP2A",
                ".MP3",
                ".MP4",
                ".MPA",
                ".MPA2",
                ".OGA",
                ".OGG",
                ".WAV",
                ".WAVE",
                ".WMA",
            };
        }

        /// <summary> The video extensions. </summary>
        public static string[] GetVideoExtensions()
        {
            return new string[]
            {            
                ".3G2",
                ".3GP",
                ".A52",
                ".ASF",
                ".AVI",
                ".BSF",
                ".DAT",
                ".DIVX",
                ".DV",
                ".DVR-MS",
                ".DVSD",
                ".EVO",
                ".FLV",
                ".M1V",
                ".M2P",
                ".M2T",
                ".M2TS",
                ".M2V",
                ".M4V",
                ".MJPG",
                ".MKV",
                ".MMV",
                ".MOD",
                ".MOV",
                ".MP2V",
                ".MP4",
                ".MPE",
                ".MPEG",
                ".MPG",
                ".MPV2",
                ".MTS",
                ".OGM",
                ".TOD",
                ".TRP",
                ".TS",
                ".VOB",
                ".WMV",
                ".WTV",
            };
        }

        /// <summary> The video extensions for files only available up from Windows 7. </summary>
        public static string[] GetWin7VideoExtensions()
        {
            return new string[]
            {            
                ".WTV",
            };
        }
        /// <summary> The document extensions. </summary>
        public static string[] GetDocumentExtensions()
        {
            return new string[]
            {    
                ".TXT",
	            ".XLSX",
	            ".XLS",
	            ".DOC",
	            ".DOCX",
	            ".PPT",
	            ".PPTX",
	            ".PDF",
                ".VSD",
	            ".XPS"
            };
        }
    }
}
