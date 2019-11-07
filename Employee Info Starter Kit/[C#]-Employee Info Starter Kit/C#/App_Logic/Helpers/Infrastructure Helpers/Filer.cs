/****************** Copyright Notice *****************
 
This code is licensed under Microsoft Public License (Ms-PL). 
You are free to use, modify and distribute any portion of this code. 
The only requirement to do that, you need to keep the developer name, as provided below to recognize and encourage original work:

=======================================================
   
Architecture Designed and Implemented By:
Mohammad Ashraful Alam
Microsoft Most Valuable Professional, ASP.NET 2007 – 2011
Twitter: http://twitter.com/AshrafulAlam | Blog: http://blog.ashraful.net | Portfolio: http://www.ashraful.net
   
*******************************************************/

namespace Eisk.Helpers
{
    using System;
    using System.IO;
    using System.Web;
    using System.Web.UI.HtmlControls;
    /// <summary>
    /// Contains necessary utility methods to facilitate working on file and file paths.
    /// Design and Architecture: Mohammad Ashraful Alam [http://www.ashraful.net]
    /// </summary>
    public sealed class Filer
    {
        public static string ReadFromFile(string filePath)
        {
            FileStream fStream;

            // Reading the file content.
            fStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sReader = new StreamReader(fStream);
            string line = sReader.ReadToEnd();
            sReader.Close();

            return line;
        }

        public static byte[] GetBytesFromStream(Stream stream)
        {
            int size = Convert.ToInt32(stream.Length);
            byte[] bytes = new byte[size];
            stream.Read(bytes, 0, size);
            return bytes;
        }
    }
}
