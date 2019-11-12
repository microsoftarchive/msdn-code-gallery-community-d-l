using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropDownList.Controllers
{
    public class SampleController : Controller
    {
        // GET: Sample
        public ActionResult Index()
        {
            List<string> ListItems = new List<string>();
            ListItems.Add("Select");
            ListItems.Add("India");
            ListItems.Add("Australia");
            ListItems.Add("America");
            ListItems.Add("North Africa");
            SelectList Countries = new SelectList(ListItems);
            ViewData["Countries"] = Countries;
            return View();
        }
        public JsonResult States(string Country)
        {
            List<string> StatesList = new List<string>();
            switch (Country)
            {
                case "India":
                    StatesList.Add("New Delhi");
                    StatesList.Add("Mumbai");
                    StatesList.Add("Kolkata");
                    StatesList.Add("Chennai");
                    break;
                case "Australia":
                    StatesList.Add("Canberra");
                    StatesList.Add("Melbourne");
                    StatesList.Add("Perth");
                    StatesList.Add("Sydney");
                    break;
                case "America":
                    StatesList.Add("California");
                    StatesList.Add("Florida");
                    StatesList.Add("New York");
                    StatesList.Add("Washignton");
                    break;
                case "North Africa":
                    StatesList.Add("Tunisia");
                    StatesList.Add("Libya");
                    StatesList.Add("Morocco");
                    StatesList.Add("Sudan");
                    break;
            }
            return Json(StatesList);
        }
    }
}