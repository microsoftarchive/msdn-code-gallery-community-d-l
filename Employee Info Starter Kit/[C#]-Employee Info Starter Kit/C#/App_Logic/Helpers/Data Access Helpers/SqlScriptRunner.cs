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

using System.IO;
using Eisk.Helpers;

namespace Eisk.DataAccessLayer
{
    public sealed class SqlScriptRunner
    {
        public static void RunScript(string scriptPath)
        {
            using (DatabaseContext _DatabaseContext = new DatabaseContext())
            {
                _DatabaseContext.ExecuteStoreCommand(Filer.ReadFromFile(scriptPath));
            }

        }
       
    }
}
