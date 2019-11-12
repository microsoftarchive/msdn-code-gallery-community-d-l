using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;

namespace TestJqGrid
{
    /// <summary>
    /// Summary description for WsDataProvider
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WsDataProvider : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public JqGridDataPagos GetGridDataOrder(int page, int rows, string sidx, string sord, bool _search)
        {
            List<Pago> data = Controller.PagosController.GetListaPagos();

            bool orderAsc = false;
            if (sord == "asc") orderAsc = true;

            if (!string.IsNullOrEmpty(sidx))
            {
                switch (sidx)
                {
                    case "ID":
                        if (orderAsc) data = data.OrderBy(e => e.ID).ToList();
                        else data = data.OrderByDescending(e => e.ID).ToList();
                        break;
                    case "FechaPago":
                        if (orderAsc) data = data.OrderBy(e => e.FechaPago).ToList();
                        else data = data.OrderByDescending(e => e.FechaPago).ToList();
                        break;
                    case "Concepto":
                        if (orderAsc) data = data.OrderBy(e => e.Concepto).ToList();
                        else data = data.OrderByDescending(e => e.Concepto).ToList();
                        break;
                    case "Importe":
                        if (orderAsc) data = data.OrderBy(e => e.Importe).ToList();
                        else data = data.OrderByDescending(e => e.Importe).ToList();
                        break;
                    case "Tasas":
                        if (orderAsc) data = data.OrderBy(e => e.Tasas).ToList();
                        else data = data.OrderByDescending(e => e.Tasas).ToList();
                        break;
                    case "Total":
                        if (orderAsc) data = data.OrderBy(e => e.Total).ToList();
                        else data = data.OrderByDescending(e => e.Total).ToList();
                        break;
                    case "Notas":
                        if (orderAsc) data = data.OrderBy(e => e.Notas).ToList();
                        else data = data.OrderByDescending(e => e.Notas).ToList();
                        break;
                }
            }

            int recordsCount = data.Count;

            int startIndex = (page - 1) * rows;
            int endIndex = (startIndex + rows < recordsCount) ? startIndex + rows : recordsCount;
            List<Pago> gridRows = new List<Pago>(rows);
            for (int i = startIndex; i < endIndex; i++)
                gridRows.Add(data[i]);

            return new JqGridDataPagos()
            {
                total = (recordsCount + rows - 1) / rows,
                page = page,
                records = recordsCount,
                rows = gridRows
            };
        }
    }
}
