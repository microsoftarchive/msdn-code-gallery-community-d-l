using SQLiteWithCSharp.Common;
using SQLiteWithCSharp.Models;
using SQLiteWithCSharp.Services;
using SQLiteWithCSharp.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLiteWithCSharp
{
    public partial class Form1 : Form
    {
        public object EmployeeService { get; private set; }

        public Form1()
        {
            InitializeComponent();
            BuildConnectionString();



            Employee e = new Employee();
            e.Name = "Swaraj";
            e.Email = "swaraj.ece.jgec@gmail.com";
            e.JobDescription = "Software Developer";
            e.Technology = "DotNet";
            e.Age = 27;

           long generatedEmployeeId = InsertEmployee(e);
            textBox1.Text = string.Format("{0}", generatedEmployeeId);
            // Similarly call other methods



        }

        public void BuildConnectionString()
        {
            if (String.IsNullOrEmpty(Storage.ConnectionString))
            {
                Storage.ConnectionString = string.Format("Data Source={0};Version=3;", System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetEntryAssembly().Location).Replace(@"\bin\Debug", System.Configuration.ConfigurationManager.AppSettings["DatabaseFile"]));
            }
        }

        public  long InsertEmployee(Employee newEmployee)
        {
           return new EmployeeService().Add(newEmployee);
        }
        public void UpdateEmployee(Employee existingEmployee)
        {
            new EmployeeService().Update(existingEmployee);
        }

        public Employee GetEmployee(long id)
        {
            return new EmployeeService().GetById(id);
        }

        public List<Employee> GetEmployeesByTechnology(string technology)
        {

            var employeeFilter = new Filter<Employee>();
            employeeFilter.Add(x => x.Technology, technology);
            // You can add more filters

            EmployeeService svc = new EmployeeService();
            return svc.Find(employeeFilter).ToList();
        }

    }
}
