using System;
using System.ComponentModel.DataAnnotations;

namespace HRApp.Web
{
    public static class GenderValidator
    {
        public static ValidationResult IsGenderValid(string gender, ValidationContext context)
        {
            if (gender == "M" || gender == "m" || gender == "F" || gender == "f")
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("The Gender field only has two valid values 'M'/'F'", new string[] {"Gender"});
            }
        }
    }
}
