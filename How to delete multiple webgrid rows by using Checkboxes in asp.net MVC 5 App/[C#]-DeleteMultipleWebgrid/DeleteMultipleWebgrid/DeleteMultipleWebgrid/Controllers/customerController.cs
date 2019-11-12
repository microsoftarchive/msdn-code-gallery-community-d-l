using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeleteMultipleWebgrid.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult List()
        {
            List<CustomerInfo> allCust = new List<CustomerInfo>();

            // Here MyDatabaseEntities is our Data Context
            using (Database1Entities dc = new Database1Entities())
            {
                allCust = dc.CustomerInfoes.ToList();
            }
            return View(allCust);
        }

        public ActionResult DeleteSelected(string[] ids)
        {
            //Delete Selected 
            int[] id = null;
            if (ids != null)
            {
                id = new int[ids.Length];
                int j = 0;
                foreach (string i in ids)
                {
                    int.TryParse(i, out id[j++]);
                }
            }

            if (id != null && id.Length > 0)
            {
                List<CustomerInfo> allSelected = new List<CustomerInfo>();
                using (Database1Entities dc = new Database1Entities())
                {
                    allSelected = dc.CustomerInfoes.Where(a => id.Contains(a.CustomerID)).ToList();
                    foreach (var i in allSelected)
                    {
                        dc.CustomerInfoes.Remove(i);
                    }
                    dc.SaveChanges();
                }
            }

            return RedirectToAction("List");
        }

    }
}
