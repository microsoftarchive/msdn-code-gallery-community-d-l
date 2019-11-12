using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fileprocess
{
    /// <summary>
    /// Parsing pipe dilimited file 
    /// </summary>
    public class PipeParser : BaseParser
    {

         public PipeParser(string FileName):base(FileName)
       {
          
       }
         public PipeParser()
           : base()
       {
       }
        public override void Read()
        {

            Delimiter = "|";
            base.Read();
        }
       
        public override string ToString()
        {
            return ParserType.PIPE.ToString();
        }
    }
}
