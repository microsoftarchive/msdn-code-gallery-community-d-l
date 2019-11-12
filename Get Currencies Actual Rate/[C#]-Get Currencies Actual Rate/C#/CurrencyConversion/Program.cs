using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CurrencyHelper
{
    class Program
    {
        const string SERVICEBASE = "http://rate-exchange.appspot.com";
        const string SERVICEREQUEST = "currency?from={0}&to=EUR&q=1";

        static List<string> Currencies = new List<string>() { "AED", "AFN", "ALL", "AMD", "ANG", "AOA", "ARS", "AUD", "AWG", "AZN", "BAM", "BBD", "BDT", "BGN", "BHD", "BIF", "BMD", "BND", "BOB", "BRL", "BSD", "BTN", "BWP", "BYR", "BZD", "CAD", "CDF", "CHF", "CLP", "CNY", "COP", "CRC", "CUC", "CUP", "CVE", "CZK", "DJF", "DKK", "DOP", "DZD", "EGP", "ERN", "ETB", "EUR", "FJD", "FKP", "GBP", "GEL", "GGP", "GHS", "GIP", "GMD", "GNF", "GTQ", "GYD", "HKD", "HNL", "HRK", "HTG", "HUF", "IDR", "ILS", "IMP", "INR", "IQD", "IRR", "ISK", "JEP", "JMD", "JOD", "JPY", "KES", "KGS", "KHR", "KMF", "KPW", "KRW", "KWD", "KYD", "KZT", "LAK", "LBP", "LKR", "LRD", "LSL", "LYD", "MAD", "MDL", "MGA", "MKD", "MMK", "MNT", "MOP", "MRO", "MUR", "MVR", "MWK", "MXN", "MYR", "MZN", "NAD", "NGN", "NIO", "NOK", "NPR", "NZD", "OMR", "PAB", "PEN", "PGK", "PHP", "PKR", "PLN", "PYG", "QAR", "RON", "RSD", "RUB", "RWF", "SAR", "SBD", "SCR", "SDG", "SEK", "SGD", "SHP", "SLL", "SOS", "SPL", "SRD", "STD", "SVC", "SYP", "SZL", "THB", "TJS", "TMT", "TND", "TOP", "TRY", "TTD", "TVD", "TWD", "TZS", "UAH", "UGX", "USD", "UYU", "UZS", "VEF", "VND", "VUV", "WST", "XAF", "XAG", "XAU", "XCD", "XDR", "XOF", "XPD", "XPF", "XPT", "YER", "ZAR", "ZWD" };

        static void Main(string[] args)
        {
            DateTime start = DateTime.Now; 
            List<Task<Currency>> res = getCurrenciesValue();
            Console.WriteLine(res.Count);
            DateTime end = DateTime.Now;

            Console.WriteLine((end - start).TotalMilliseconds);

            Console.ReadLine();
        }

        /// <summary>
        /// Return a List of Task of type Currency
        /// </summary>
        /// <returns></returns>
        private static List<Task<Currency>> getCurrenciesValue()
        {
            var res = new List<Task<Currency>>();
            foreach (var currency in Currencies)
            {
                Task<Currency> t1 = getCurrencyValue(currency);
                res.Add(t1);
            }
            Task.WaitAll(res.ToArray());
            return res;
        }

        /// <summary>
        /// Return a Task of type Currency for a specific currency
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        static async Task<Currency> getCurrencyValue(string currency)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(SERVICEBASE);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(string.Format(SERVICEREQUEST, currency));

                response.EnsureSuccessStatusCode();

                Currency res = await response.Content.ReadAsAsync<Currency>();

                return res;
            }
        }
    }

    public class Currency
    {
        //{"to": "EUR", "rate": 0.87792700000000001, "from": "USD", "v": 0.87792700000000001}
        public string to { get; set; }
        public decimal rate { get; set; }
        public string  from { get; set; }
        public decimal v { get; set; }

        public override string ToString()
        {
            return v.ToString();
        }
    }
}

