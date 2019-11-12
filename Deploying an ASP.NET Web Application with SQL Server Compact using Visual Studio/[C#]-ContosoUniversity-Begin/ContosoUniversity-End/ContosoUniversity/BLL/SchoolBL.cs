using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContosoUniversity.DAL;
using System.Data;

namespace ContosoUniversity.BLL
{
    public class SchoolBL : IDisposable
    {
        private SchoolContext context = new SchoolContext();

        public IEnumerable<Student> GetStudents()
        {
            return GetStudents("");
        }

        public IEnumerable<Student> GetStudents(string sortExpression)
        {
            var students = from s in context.Students.Include("Enrollments")
                           select s;
            switch (sortExpression)
            {
                case "LastName DESC":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "EnrollmentDate":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "EnrollmentDate DESC":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(s => s.LastName);
                    break;
            }
            return students.ToList();
        }

        public void InsertStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            context.Students.Attach(student);
            context.Students.Remove(student);
            context.SaveChanges();
        }


        public void UpdateStudent(Student student)
        {
            Student studentToUpdate = context.Students.Attach(student);
            context.Entry(student).State = System.Data.EntityState.Modified;
            context.SaveChanges();
        }

        public IEnumerable<Department> GetDepartments()
        {
            return GetDepartmentsByName("");
        }

        public IEnumerable<Department> GetDepartmentsByName(string nameSearchString)
        {
            var departments = from d in context.Departments.Include("Administrator").Include("Courses")
                              select d;
            if (!String.IsNullOrEmpty(nameSearchString))
            {
                departments = departments.Where(d => d.Name.ToUpper().Contains(nameSearchString.ToUpper()));
            }
            return departments.OrderBy(d => d.Name).ToList();
        }

        public void UpdateDepartment(Department Department)
        {
            Department DepartmentToUpdate = context.Departments.Attach(Department);
            context.Entry(Department).State = System.Data.EntityState.Modified;
            context.SaveChanges();
        }

        public IEnumerable<OfficeAssignment> GetOfficeAssignments(string sortExpression)
        {
            if (string.IsNullOrEmpty(sortExpression)) sortExpression = "Person.LastName";
            return context.OfficeAssignments.ToList();
        }

        public void InsertOfficeAssignment(OfficeAssignment officeAssignment)
        {
            context.OfficeAssignments.Add(officeAssignment);
            context.SaveChanges();
        }

        public void DeleteOfficeAssignment(OfficeAssignment officeAssignment)
        {
            context.OfficeAssignments.Remove(officeAssignment);
            context.SaveChanges();
        }

        public void UpdateOfficeAssignment(OfficeAssignment officeAssignment, OfficeAssignment origOfficeAssignment)
        {
            Department departmentToUpdate = context.Departments.Find(origOfficeAssignment.PersonID);
            context.ObjectContext.ApplyCurrentValues("OfficeAssignments", officeAssignment);
            context.SaveChanges();
        }

        public IEnumerable<Course> GetCoursesByDepartment(int DepartmentID)
        {
            var Courses = from c in context.Courses
                          where c.DepartmentID == DepartmentID
                          select c;
            return Courses.ToList();
        }


        public IEnumerable<Course> GetCoursesByInstructor(int PersonID)
        {
            var instructor = context.Instructors.Include("Courses.Department").Where(i => i.PersonID == PersonID).FirstOrDefault();
            if (instructor != null)
            {
                return instructor.Courses.ToList();

            }
            else
            {
                return new List<Course>();
            }
        }


        public void UpdateCourse(Course Course)
        {
            Course CourseToUpdate = context.Courses.Attach(Course);
            context.Entry(Course).State = System.Data.EntityState.Modified;
            context.SaveChanges();
        }


        public IEnumerable<Instructor> GetInstructors()
        {
            var Instructors = (from i in context.Instructors
                               where i.HireDate != null
                               select i).ToList();
            foreach (Instructor i in Instructors)
            {
                context.Entry(i).Reference(x => x.OfficeAssignment).Load();
            }
            return Instructors.ToList();
        }

        public Instructor GetInstructorByID(int instructorID)
        {
            var instructor = context.Instructors.Find(instructorID);
            context.Entry(instructor).Reference(x => x.OfficeAssignment).Load();
            return instructor;
        }

        public void UpdateInstructor(Instructor Instructor)
        {
            Instructor InstructorToUpdate = context.Instructors.Attach(Instructor);
            context.Entry(Instructor).State = System.Data.EntityState.Modified;
            context.SaveChanges();
        }

        public IEnumerable<EnrollmentDateGroup> GetStudentStatistics()
        {
            var query = "SELECT EnrollmentDate, COUNT(*) AS StudentCount "
                + "FROM Person "
                + "WHERE EnrollmentDate IS NOT NULL "
                + "GROUP BY EnrollmentDate";
            var data = context.Database.SqlQuery<EnrollmentDateGroup>(query);
            return data.ToList();
        }


        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}