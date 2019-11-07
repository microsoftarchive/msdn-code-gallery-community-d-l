using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FluentValidationSample.Models;

namespace FluentValidationSample.Validation
{
    public class CustomerViewModelValidator : AbstractValidator<CustomerViewModel>
    {
        public CustomerViewModelValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("*Required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("*Required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Not Valid").NotEmpty().WithMessage("*Required");
        }
    }
}