using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ConditionalValidation.Models.Home;

namespace ConditionalValidation.Controllers
{
    public class HomeController : Controller
    {
        // dirty hack to keep the sample simple ;-)
        private static readonly List<PendingRequestModel> PendingRequests =
            new List<PendingRequestModel>
                {
                    new PendingRequestModel { Id = 1, Title = "2 boxes of pens", RequestedOn =  new DateTime(2011,05,10), DueOn = new DateTime(2011, 05, 15)},
                    new PendingRequestModel { Id = 2, Title = "10 notepads", RequestedOn =  new DateTime(2011,05,01), DueOn = new DateTime(2011, 05, 10)},
                    new PendingRequestModel { Id = 3, Title = "Blank ink cartridge", RequestedOn =  new DateTime(2011,05, 3), DueOn= new DateTime(2011, 05, 11)},
                };

        public ActionResult Index()
        {
            var model = new IndexModel
                            {
                                Message = (string) TempData["Message"],
                                PendingRequests = PendingRequests
                            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var request = PendingRequests.First(pr => pr.Id == id); // no error handling!
            var model = new EditModel
                            {
                                PendingRequest = request
                            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(PendingRequestModel pendingRequest)
        {
            if (ModelState.IsValid)
            {
                Save(pendingRequest);
                TempData["Message"] = "Changes saved";
                return RedirectToAction("Index");
            }
            var model = new EditModel
                            {
                                PendingRequest = pendingRequest
                            };
            return View(model);
        }

        private void Save(PendingRequestModel pendingRequest)
        {
            PendingRequests.RemoveAll(pr => pr.Id == pendingRequest.Id);
            PendingRequests.Add(pendingRequest);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
