using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fileprocess
{
    /// <summary>
    /// Parse the CSV file
    /// </summary>
   public  class CSVParser:BaseParser 
    {
    
       public CSVParser(string FileName):base(FileName)
       {
          
       }
       public CSVParser()
           : base()
       {
       }
        public override void Read()
        {

            Delimiter = ",";
            base.Read();
        }

       
        public override string ToString()
        {
            return ParserType.CSV.ToString();
        }
    }
}
