using InterfaceInjection.Idata;
using InterfaceInjection.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceInjection
{
    class Program
    {
        static void Main(string[] args)
        {


            PassData orgdata = new PassData();
            IDATA injection = orgdata.Addidata();

          
           DataInjection Injection = new DataInjection();
           Injection.addData(injection);


           Console.Read();
        }
    }
}
