using ContosoUniversity.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.DAL;
using ContosoUniversity.ViewModels;

namespace ContosoUniversity.Controllers
{
    public class HomeController : Controller
    {
       private SchoolContext db = new SchoolContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Contoso University";

            return View();
        }

        public ActionResult About()
        {
            var query = "SELECT EnrollmentDate, COUNT(*) AS StudentCount "
                + "FROM Person "
                + "WHERE EnrollmentDate IS NOT NULL "
                + "GROUP BY EnrollmentDate";
            var data = db.Database.SqlQuery<EnrollmentDateGroup>(query);

           return View(data);
        }

       // Click the DbgSeed link to debug the Seed method
        public ActionResult Contact()
        {
            var configuration = new Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();

            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
           db.Dispose();
           base.Dispose(disposing);
        }
    }
}
