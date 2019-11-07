using InterfaceInjection.Idata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceInjection.Implementation
{
    public class DataGeneration:IDATA
    {
        private int SNO;
        private string ADDRESS;

        public int Sno
        {
            get
            {
                return SNO;
            }
            set
            {
                this.SNO = value;
            }
        }

        public string Address
        {
            get
            {
                return ADDRESS;
            }
            set
            {
                this.ADDRESS = value;
            }
        }
    }
}
