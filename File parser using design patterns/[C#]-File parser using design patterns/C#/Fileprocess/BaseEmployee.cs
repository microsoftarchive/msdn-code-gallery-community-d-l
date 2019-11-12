using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace Fileprocess
{
    public interface IEmployee
    {
        string Name { get; set; }
        DateTime DateOfBirth { get; set; }
        int EmpNo { get; set; }
        int Sal { get; set; }

    }

    public interface IEmployeeResult : IEmployee
    {
        List<string> ErrorMessages { get; set; }
    }


    public class Employee : IEmployeeResult
    {


        [Required(ErrorMessage = "The Emp Name is Empty")]
        public string Name
        {
            get;
            set;

        }
        [Required(ErrorMessage = "The Emp DOB is Empty")]
        public DateTime DateOfBirth
        {
            get;

            set;

        }

        [Required(ErrorMessage = "The Emp No is Empty or Invalid")]
        public int EmpNo
        {
            get;

            set;

        }

        [Required(ErrorMessage = "The Emp No salary is Empty  or Invalid")]
        public int Sal
        {
            get;

            set;

        }

        public List<string> ErrorMessages
        {
            get;

            set;
        }
    }

}
