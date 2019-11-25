using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using LINQ_B_to_A.Models;
namespace LINQ_B_to_A.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public MyDataModel DtContext { get; set; } = new MyDataModel();

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Linq query with SelectMany
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectMany()
        {
            var selectMany = DtContext.Orders.SelectMany(order => order.Invoices).Take(10);
            var select = DtContext.Orders.Select(order => order.Invoices).Take(10);
            return PartialView("SelectMany", selectMany);
        }

        /// <summary>
        /// Linq query with Select
        /// </summary>
        /// <returns></returns>
        public ActionResult LoadAll()
        {
            var loadAllData = (from d in DtContext.Cities where d.CityName.StartsWith("C") select d).Take(10);

            //Method Chain Format
            var loadAllData1 = DtContext.Cities.Where(d => d.CityName.StartsWith("C")).Take(10);

            return PartialView(loadAllData);
        }

        /// <summary>
        /// Linq query with join and where
        /// </summary>
        /// <returns></returns>
        public ActionResult JoinWithWhere()
        {
            var loadAllData = (from oOrders in DtContext.Orders
                               join oOrderLines in DtContext.OrderLines
                               on oOrders.OrderID equals oOrderLines.OrderID
                               orderby oOrders.OrderID
                               select new OrderAndOrderLines()
                               {
                                   OrderId = oOrders.OrderID,
                                   Description = oOrderLines.Description,
                                   Quantity = oOrderLines.Quantity
                               }).Take(10);
            //Method Chain Format
            var asMethodChain = DtContext.Orders.Join(DtContext.OrderLines, oOrders => oOrders.OrderID,
                    oOrderLines => oOrderLines.OrderID,
                    (oOrders, oOrderLines) => new { oOrders, oOrderLines })
                .OrderBy(@o => @o.oOrders.OrderID)
                .Select(@s => new OrderAndOrderLines()
                {
                    OrderId = @s.oOrders.OrderID,
                    Description = @s.oOrderLines.Description,
                    Quantity = @s.oOrderLines.Quantity
                }).Take(10);

            return PartialView(loadAllData);
        }

        /// <summary>
        /// Linq query with Left Join
        /// </summary>
        /// <returns></returns>
        public ActionResult LeftJoin()
        {
            var loadAllData = (from oOrder in DtContext.Orders
                               join oOrderLine in DtContext.OrderLines
                               on oOrder.OrderID equals oOrderLine.OrderID
                               into lftOrder
                               from afterJoined in lftOrder.DefaultIfEmpty()
                               orderby oOrder.OrderID descending
                               select new OrderAndOrderLines()
                               {
                                   OrderId = oOrder.OrderID,
                                   Description = afterJoined.Description
                               }).Take(10).ToList();
            //Method Chain Format
            var lftJoinMethodChain = (DtContext.Orders.GroupJoin(DtContext.OrderLines,
                    oOrder => oOrder.OrderID, oOrderLine => oOrderLine.OrderID,
                    (oOrder, lftJoin) => new { oOrder, lftJoin })
                .SelectMany(@sm => @sm.lftJoin.DefaultIfEmpty(), (@sm, afterJoin) => new { @sm, afterJoin })
                .OrderByDescending(@o => @o.sm.oOrder.OrderID)
                .Select(@s => new OrderAndOrderLines()
                {
                    OrderId = @s.sm.oOrder.OrderID,
                    Description = @s.afterJoin.Description
                })).Take(10).ToList();

            return PartialView(loadAllData);
        }

        /// <summary>
        /// Linq query Distinct sample
        /// </summary>
        /// <returns></returns>
        public ActionResult DistinctSample()
        {
            var distictSample = (from oOrder in DtContext.OrderLines
                                 select oOrder.Description).Distinct().Take(10).ToList();

            //Method Chain Format
            var distictAsMethodChain = (DtContext.OrderLines.Select(oOrder => oOrder.Description)).Distinct().Take(10).ToList();

            return PartialView(distictSample);
        }

        /// <summary>
        /// Linq query Equals sample 
        /// </summary>
        /// <returns></returns>
        public ActionResult EqualsSamples()
        {
            var objEquals = (from objCity in DtContext.Cities
                             where objCity.CityName.Equals("Troy")
                             select objCity).Take(2);
            //Method Chain Format
            var objEquals1 = DtContext.Cities.Where(d => d.CityName.Equals("Troy")).Take(2);

            return PartialView("OperatorSamples", objEquals);
        }

        /// <summary>
        /// Linq query Not Equals sample 
        /// </summary>
        /// <returns></returns>
        public ActionResult NotEqualsSamples()
        {
            var objNotEquals = (from objCity in DtContext.Cities
                                where objCity.CityName != "Troy"
                                select objCity).Take(5);

            var objNotEquals1 = (from objCity in DtContext.Cities
                                 where !objCity.CityName.Equals("Troy")
                                 select objCity).Take(5);

            //Method Chain Format
            var objNotEquals2 = DtContext.Cities.Where(d => d.CityName != "Troy").Take(2);

            var objNotEquals3 = DtContext.Cities.Where(d => !d.CityName.Equals("Troy")).Take(2);

            return PartialView("OperatorSamples", objNotEquals);
        }

        /// <summary>
        /// Linq Paging Queries
        /// </summary>
        /// <returns></returns>
        public ActionResult PagingQueries()
        {
            var objNotEquals = (from objCity in DtContext.Cities
                                where objCity.CityName != "Troy"
                                orderby objCity.CityName ascending
                                select objCity).Skip(5).Take(5);

            //Method Chain Format
            var objNotEquals2 = DtContext.Cities.Where(d => d.CityName != "Troy").Skip(5).Take(5);

            return PartialView("OperatorSamples", objNotEquals);
        }

        /// <summary>
        /// Math Queries
        /// </summary>
        /// <returns></returns>
        public ActionResult MathQueries()
        {
            var objMath = (from objInv in DtContext.InvoiceLines
                           where objInv.ExtendedPrice > 10 && objInv.Quantity < 15
                           orderby objInv.InvoiceLineID descending
                           select new MathClass()
                           {
                               Actual = objInv.ExtendedPrice,
                               Round = Math.Round(objInv.ExtendedPrice),
                               Floor = Math.Floor(objInv.ExtendedPrice),
                               Ceiling = Math.Ceiling(objInv.ExtendedPrice),
                               Abs = Math.Abs(objInv.ExtendedPrice)
                           }).Take(10);

            //Method Chain Format
            var objMath2 = DtContext.InvoiceLines
                .Where(objInv => objInv.ExtendedPrice > 10 && objInv.Quantity < 15)
                .OrderByDescending(o => o.InvoiceLineID)
                .Select(objInv => new MathClass()
                {
                    Actual = objInv.ExtendedPrice,
                    Round = Math.Round(objInv.ExtendedPrice),
                    Floor = Math.Floor(objInv.ExtendedPrice),
                    Ceiling = Math.Ceiling(objInv.ExtendedPrice),
                    Abs = Math.Abs(objInv.ExtendedPrice)
                }).Take(10);

            return PartialView("MathQueries", objMath);
        }

        /// <summary>
        /// String Queries
        /// </summary>
        /// <returns></returns>
        public ActionResult StringQueries()
        {
            var objString = (from objInv in DtContext.InvoiceLines
                             where objInv.ExtendedPrice > 10 && objInv.Quantity < 15
                             orderby objInv.InvoiceLineID descending
                             select new StringClass()
                             {
                                 Actual = objInv.Description,
                                 Insert = objInv.Description.Insert(2, "SibeeshPassion"),
                                 Remove = objInv.Description.Remove(1, 1),
                                 Substring = objInv.Description.Substring(2, 3),
                                 ToLower = objInv.Description.ToLower(),
                                 ToUpper = objInv.Description.ToUpper(),
                                 TrimEnd = objInv.Description.TrimEnd(),
                                 TrimStart = objInv.Description.TrimStart()
                             }).Take(2);

            //Method Chain Format
            var objString2 = DtContext.InvoiceLines
                .Where(objInv => objInv.ExtendedPrice > 10 && objInv.Quantity < 15)
                .OrderByDescending(o => o.InvoiceLineID)
                .Select(objInv => new StringClass()
                {
                    Actual = objInv.Description,
                    Insert = objInv.Description.Insert(2, "SibeeshPassion"),
                    Remove = objInv.Description.Remove(1, 1),
                    Substring = objInv.Description.Substring(2, 3),
                    ToLower = objInv.Description.ToLower(),
                    ToUpper = objInv.Description.ToUpper(),
                    TrimEnd = objInv.Description.TrimEnd(),
                    TrimStart = objInv.Description.TrimStart()
                }).Take(2);

            return PartialView("StringQueries", objString);
        }
    }
}