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

using System;
using System.IO;
using System.Web;

namespace Eisk.Helpers
{

    public sealed class Logger
    {
        private Logger() { }

        public static void LogError()
        {
            System.Exception ex = System.Web.HttpContext.Current.Server.GetLastError();
            LogError(ex);

        }

        public static void LogError(Exception ex)
        {
            var currentContext = HttpContext.Current;

            if (ex.Message.Equals("File does not exist."))
            {
                currentContext.ClearError();
                return;
            }

            string logSummery, logDetails, filePath = "No file path found.", url = "No url found to be reported.";
            
            if (currentContext != null)
            {
                filePath = currentContext.Request.FilePath;
                url = currentContext.Request.Url.AbsoluteUri;
            }
            
            logSummery = ex.Message;
            logDetails = ex.ToString();

            //-----------------------------------------------------

            string path = System.Web.HttpContext.Current.Server.MapPath("~/App_Resources/system/log/log.txt");
            FileStream fStream = new FileStream(path, FileMode.Append, FileAccess.Write);
            BufferedStream bfs = new BufferedStream(fStream);
            StreamWriter sWriter = new StreamWriter(bfs);
            
            //insert a separator line
            sWriter.WriteLine("=================================================================================================");
            
            //create log for header
            sWriter.WriteLine(logSummery);
            sWriter.WriteLine("Log time:" + DateTime.Now);
            sWriter.WriteLine("URL: " + url);
            sWriter.WriteLine("File Path: " + filePath);
            
            //create log for body
            sWriter.WriteLine(logDetails);
            
            //insert a separator line
            sWriter.WriteLine("=================================================================================================");

            sWriter.Close();

        }
    }
}



