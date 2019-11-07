using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fileprocess;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileParserFacade facade = new FileParserFacade();
            facade.ParseFile(@"D:\Yesu\Fileparser\Fileprocess\Files\Emp.xlsx");
            facade.ParseFile(@"D:\Yesu\Fileparser\Fileprocess\Files\Emp.csv");
            facade.ParseFile(@"D:\Yesu\Fileparser\Fileprocess\Files\Emp.pipe");
        }
    }
}
