using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fileprocess
{
   public abstract class BaseParser
    {
       public BaseParser()
       {
           Results = new List<IEmployeeResult>();
       }
       /// <summary>
       /// Invoking the default constructor to load Results property
       /// </summary>
       /// <param name="FileName"></param>
       public BaseParser(string FileName):this()
       {
           this.FileName = FileName;
       }
       public virtual string Delimiter { get; set; }
       /// <summary>
       /// Read the file rows and process it for CSV,PIPE and other delimiters 
       /// </summary>
       public virtual void Read()
       {
           using (FileStream stream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read))
           {
               using (StreamReader reader = new StreamReader(stream))
               {

                   string Linestring = "";// reader.ReadLine();

                   while ((Linestring = reader.ReadLine()) != null)
                   {
                       IEmployeeResult emp = ConvertToObject.Getobject(Linestring, Delimiter);
                       EmployeeValidation.Validate(emp);
                       Results.Add(emp);
                   }


               }
           }
       }
      public string FileName { get; set; }

      public  List<IEmployeeResult> Results { get; set; }
    }
}
