using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fileprocess
{
    class EmployeeValidation
    {

        public static void Validate(IEmployeeResult emp)
        {
            
            var results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(emp);
            List<string> errors = new List<string>();
            bool Isvalid = Validator.TryValidateObject(emp, context, results);
            if (!Isvalid)
            {
                foreach (var validationResult in results)
                {
                   errors.Add(validationResult.ErrorMessage);
                }
                emp.ErrorMessages = errors;
            }

        }
    }
}
