using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestJqGrid
{
    public class JqGridDataPagos
    {
        public int total { get; set; }
        public int page { get; set; }
        public int records { get; set; }
        public List<Pago> rows { get; set; }
    }

    public class Pago
    {
        public int ID { set; get; }
        public DateTime FechaPago { set; get; }
        public string Concepto { set; get; }
        public decimal Importe { set; get; }
        public decimal Tasas { set; get; }
        public decimal Total {set;get;}
        public string Notas { set; get; }
    }
}