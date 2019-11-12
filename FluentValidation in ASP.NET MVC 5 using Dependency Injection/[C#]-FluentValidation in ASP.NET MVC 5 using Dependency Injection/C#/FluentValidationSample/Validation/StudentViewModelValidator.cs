using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FluentValidationSample.Models;

namespace FluentValidationSample.Validation
{
    public class StudentViewModelValidator : AbstractValidator<StudentViewModel>
    {
        public StudentViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("*Required");          
            RuleFor(x => x.Email).EmailAddress().WithMessage("Not Valid").NotEmpty().WithMessage("*Required");
        }
    }
}
