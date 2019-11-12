using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.Models;
using ContosoUniversity.DAL;

namespace ContosoUniversity.Controllers
{
    public class CourseController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult UpdateCourseCredits(int? multiplier)
        {
            if (multiplier != null)
            {
                ViewBag.RowsAffected = unitOfWork.CourseRepository.UpdateCourseCredits(multiplier.Value);
            }
            return View();
        }

        //
        // GET: /Course/

        public ActionResult Index(int? SelectedDepartment)
        {
            var departments = unitOfWork.DepartmentRepository.Get(
                orderBy: q => q.OrderBy(d => d.Name));
            ViewBag.SelectedDepartment = new SelectList(departments, "DepartmentID", "Name", SelectedDepartment);

            int departmentID = SelectedDepartment.GetValueOrDefault();
            return View(unitOfWork.CourseRepository.Get(
                filter: d => !SelectedDepartment.HasValue || d.DepartmentID == departmentID,
                orderBy: q => q.OrderBy(d => d.CourseID),
                includeProperties: "Department"));
        }


        //
        // GET: /Course/Details/5

        public ActionResult Details(int id)
        {
            var query = "SELECT * FROM Course WHERE CourseID = @p0";
            return View(unitOfWork.CourseRepository.GetWithRawSql(query, id).Single());
        }

        //
        // GET: /Course/Create

        public ActionResult Create()
        {
            PopulateDepartmentsDropDownList(3);
            return View(new Course { Credits = 3, Title = "Algebra II", CourseID = 3333 });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID, Title, Credits, DepartmentID")]Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.CourseRepository.Insert(course);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(course);
        }

        public ActionResult Edit(int id)
        {
            Course course = unitOfWork.CourseRepository.GetByID(id);
            PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID, Title, Credits, DepartmentID")]Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.CourseRepository.Update(course);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(course);
        }

        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = unitOfWork.DepartmentRepository.Get(
                orderBy: q => q.OrderBy(d => d.Name));
            ViewBag.DepartmentID = new SelectList(departmentsQuery, "DepartmentID", "Name", selectedDepartment);
        }

        //
        // GET: /Course/Delete/5

        public ActionResult Delete(int id)
        {
            Course course = unitOfWork.CourseRepository.GetByID(id);
            return View(course);
        }

        //
        // POST: /Course/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = unitOfWork.CourseRepository.GetByID(id);
            unitOfWork.CourseRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
