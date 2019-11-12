using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodDonors.Models;


namespace BloodDonor.Controllers
{
    public class DonorController : Controller
    {

        private DonorDBContext db = new DonorDBContext();

        //
        // GET: /Donors/

        public ViewResult Index()
        {

            return View(db.Donors.ToList());


        }

        //
        // GET: /Donors/Details/5

        public ViewResult Details(int id)
        {
            Donor Donors = db.Donors.Find(id);
            return View(Donors);
        }

        //
        // GET: /Donors/Create

        public ActionResult Create()
        {
            Donor Donors = new Donor();
            return View(Donors);
        }

        //
        // POST: /Donors/Create

        [HttpPost]
        public ActionResult Create(Donor Donors)
        {
            if (ModelState.IsValid)
            {
                db.Donors.Add(Donors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Donors);
        }

        //
        // GET: /Donors/Edit/5

        public ActionResult Edit(int id)
        {
            Donor Donors = db.Donors.Find(id);
            return View(Donors);
        }

        //
        // POST: /Donors/Edit/5

        [HttpPost]
        public ActionResult Edit(Donor Donors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Donors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Donors);
        }

        //
        // GET: /Donors/Delete/5

        public ActionResult Delete(int id)
        {
            Donor Donors = db.Donors.Find(id);
            return View(Donors);
        }

        //
        // POST: /Donors/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Donor Donors = db.Donors.Find(id);
            db.Donors.Remove(Donors);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}