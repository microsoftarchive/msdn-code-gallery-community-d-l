using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fileprocess
{
    public class ValidateFile 
    {
       
        public static void Validate(string FileName)
        {
            if (!File.Exists(FileName))
                throw new Exception("Unable to locate the file");
            
                    
        }
    }
}
