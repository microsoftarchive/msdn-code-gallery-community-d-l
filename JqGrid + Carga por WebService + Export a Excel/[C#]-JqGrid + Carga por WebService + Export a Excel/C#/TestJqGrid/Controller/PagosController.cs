using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestJqGrid.Controller
{
    public class PagosController
    {
        public static List<Pago> GetListaPagos()
        {
            List<Pago> data = new List<Pago>();

            Random rnd = new Random();

            for (int n = 0; n < 30; n++)
            {
                int num_days = rnd.Next(-365, -30);
                DateTime fecha = DateTime.Today.AddDays(num_days);
                decimal importe = Math.Round(Convert.ToDecimal((rnd.NextDouble() * 1000)), 2);
                decimal tasa = Math.Round(Convert.ToDecimal((rnd.NextDouble() * 100)), 2);
                decimal total = Math.Round((importe + tasa), 2);
                data.Add(new Pago()
                {
                    ID = n + 1,
                    FechaPago = fecha,
                    Concepto = "JOHN DOE " + (n + 1).ToString(),
                    Importe = importe,
                    Tasas = tasa,
                    Total = total,
                    Notas = "Nota " + (n + 1).ToString()
                });
            }

            return data;
        }
    }
}