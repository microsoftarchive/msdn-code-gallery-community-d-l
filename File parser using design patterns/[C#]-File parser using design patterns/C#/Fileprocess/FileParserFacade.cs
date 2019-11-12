using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fileprocess
{
    public class FileParserFacade 
    {
        ParserFactory Factory = null;
        BaseParser parser = null;
        public FileParserFacade()
        {
            Factory = new ParserFactory();
           
        }
        public void ParseFile(string FileName)
        {
            ValidateFile.Validate(FileName);
            ParserType type = GetExtention(FileName);
            parser = Factory.GetObject(type.ToString());
            parser.FileName = FileName;
            parser.Read();

                     
        }

        public ParserType GetExtention(string FileName)
        {
            string strFileType = Path.GetExtension(FileName).ToLower();
            switch (strFileType)
            {
                case ".xls":
                    return ParserType.EXCEL;
                case ".xlsx":
                    return ParserType.EXCEL;
                case ".pipe":
                    return ParserType.PIPE;
                default:
                    return ParserType.CSV;
            }
        }
    }
}
