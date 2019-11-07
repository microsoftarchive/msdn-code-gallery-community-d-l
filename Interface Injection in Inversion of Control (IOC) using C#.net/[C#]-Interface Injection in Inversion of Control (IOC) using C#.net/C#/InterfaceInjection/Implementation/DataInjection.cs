using InterfaceInjection.Iaction;
using InterfaceInjection.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceInjection.Implementation
{



    public class DataInjection : IOperations
    {
        public void addData(Idata.IDATA idata)
        {
            Console.WriteLine(idata.Sno.ToString());
            Console.WriteLine(idata.Address.ToString());
            //throw new NotImplementedException();
        }
    }


    public class PassData:IACTION
    {
        public Idata.IDATA Addidata()
        {
            return new DataGeneration { Sno = 1234, Address = "Hyderabad" };
        }
    }





}
