using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.Models;
using ContosoUniversity.DAL;
using System.Data.Entity.Infrastructure;

namespace ContosoUniversity.Controllers
{
    public class DepartmentController : Controller
    {
        private SchoolContext db = new SchoolContext();

        private void ValidateOneAdministratorAssignmentPerInstructor(Department department)
        {
            if (department.PersonID != null)
            {
                var duplicateDepartment = db.Departments
                   .Include("Administrator")
                   .Where(d => d.PersonID == department.PersonID)
                   .AsNoTracking()
                   .FirstOrDefault();
                if (duplicateDepartment != null && duplicateDepartment.DepartmentID != department.DepartmentID)
                {
                    var errorMessage = String.Format(
                        "Instructor {0} {1} is already administrator of the {2} department.",
                        duplicateDepartment.Administrator.FirstMidName,
                        duplicateDepartment.Administrator.LastName,
                        duplicateDepartment.Name);
                    ModelState.AddModelError(string.Empty, errorMessage);
                }
            }
        }


        //
        // GET: /Department/

        public ActionResult Index()
        {
            var departments = db.Departments.Include(d => d.Administrator);
            return View(departments.ToList());
        }

        //
        // GET: /Department/Details/5

        public ActionResult Details(int id = 0)
        {
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        //
        // GET: /Department/Create

        public ActionResult Create()
        {
            ViewBag.PersonID  = new SelectList(db.Instructors, "PersonID", "FullName",
               db.Instructors.Single(i => i.LastName == "Fakhouri").PersonID);
            return View(new Department { Budget = 5000.00M, Name = "Computer Science", StartDate=DateTime.Now });
        }

        //
        // POST: /Department/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Budget, StartDate, PersonID")]Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonID  = new SelectList(db.Instructors, "PersonID", "FullName", department.PersonID );
            return View(department);
        }

        //
        // GET: /Department/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonID  = new SelectList(db.Instructors, "PersonID", "FullName", department.PersonID );
            return View(department);
        }

        //
        // POST: /Department/Edit/5

[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Edit([Bind(Include = "DepartmentID, Name, Budget, StartDate, PersonID, RowVersion")]Department department)
{
   try
   {
       if (ModelState.IsValid)
       {
           ValidateOneAdministratorAssignmentPerInstructor(department);
       }
      if (ModelState.IsValid)
      {
         db.Entry(department).State = EntityState.Modified;
         db.SaveChanges();
         return RedirectToAction("Index");
      }
   }
   catch (DbUpdateConcurrencyException ex)
   {
      var entry = ex.Entries.Single();
      var clientValues = (Department)entry.Entity;
      var databaseValues = (Department)entry.GetDatabaseValues().ToObject();

      if (databaseValues.Name != clientValues.Name)
                 ModelState.AddModelError("Name", "Current value: "
                     + databaseValues.Name);
              if (databaseValues.Budget != clientValues.Budget)
                 ModelState.AddModelError("Budget", "Current value: "
                     + String.Format("{0:c}", databaseValues.Budget));
              if (databaseValues.StartDate != clientValues.StartDate)
                 ModelState.AddModelError("StartDate", "Current value: "
                     + String.Format("{0:d}", databaseValues.StartDate));
              if (databaseValues.PersonID  != clientValues.PersonID )
                 ModelState.AddModelError("PersonID ", "Current value: "
                     + db.Instructors.Find(databaseValues.PersonID ).FullName);
              ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                  + "was modified by another user after you got the original value. The "
                  + "edit operation was canceled and the current values in the database "
                  + "have been displayed. If you still want to edit this record, click "
                  + "the Save button again. Otherwise click the Back to List hyperlink.");
              department.RowVersion = databaseValues.RowVersion;
           }
           catch (DataException /* dex */)
           {
              //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
              ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
           }

           ViewBag.PersonID  = new SelectList(db.Instructors, "PersonID ", "FullName", department.PersonID );
           return View(department);
        }


        //
        // GET: /Department/Delete/5

        public ActionResult Delete(int id, bool? concurrencyError)
        {
           Department department = db.Departments.Find(id);

           if (concurrencyError.GetValueOrDefault())
           {
              if (department == null)
              {
                 ViewBag.ConcurrencyErrorMessage = "The record you attempted to delete "
                     + "was deleted by another user after you got the original values. "
                     + "Click the Back to List hyperlink.";
              }
              else
              {
                 ViewBag.ConcurrencyErrorMessage = "The record you attempted to delete "
                     + "was modified by another user after you got the original values. "
                     + "The delete operation was canceled and the current values in the "
                     + "database have been displayed. If you still want to delete this "
                     + "record, click the Delete button again. Otherwise "
                     + "click the Back to List hyperlink.";
              }
           }

           return View(department);
        }

        //
        // POST: /Department/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Department department)
        {
           try
           {
              db.Entry(department).State = EntityState.Deleted;
              db.SaveChanges();
              return RedirectToAction("Index");
           }
           catch (DbUpdateConcurrencyException)
           {
              return RedirectToAction("Delete", new { concurrencyError = true });
           }
           catch (DataException /* dex */)
           {
              //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
              ModelState.AddModelError(string.Empty, "Unable to delete. Try again, and if the problem persists contact your system administrator.");
              return View(department);
           }
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}