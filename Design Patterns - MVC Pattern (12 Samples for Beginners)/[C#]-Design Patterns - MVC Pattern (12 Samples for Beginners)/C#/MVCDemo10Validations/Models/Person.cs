using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVCDemo10Validations
{
    
    //IValidatableObject to prevent the insertion of repeated data, performing an extra validation at server side that will run after attribute validation is performed.

    [Bind(Exclude = "Id")] // Exclude Id
    public class Person : IValidatableObject
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Person name is required")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(160)]
        [DisplayName("Person Name")]
        public string Name { get; set; }

        [MVCDemo10Validations.CustomValidations.AgeValidation]
        [DisplayName("Age")]
                
        public int Age { get; set; }

        [DisplayName("Street")]
        public string Street { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("State")]
        public string State { get; set; }
        
        [Range(1, 100, ErrorMessage = "Zipcode must be between 10000 and 99999")]
        [DisplayName("Zipcode")]
        public int Zipcode { get; set; }


        //[Required(ErrorMessage = "Email Address is required")]
        //[DisplayName("Email Address")]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email is is not valid.")]
        //[DataType(DataType.EmailAddress)]
        //public object Email { get; set; }

        public Person()
        {
            Id = 1;
            Name = "Sai";
            Age = 30;
            Street = "50 Heaven St";
            City = "Mansfield";
            State = "MA";
            Zipcode = 02048;
        }

        #region IValidatableObject Members

        public System.Collections.Generic.IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Perform logic here to check if the entries are exists in the database, if so throw the error.
            if (1 == 2)
            {
                yield return new ValidationResult("Existing Person Object", new string[] { "Person" });
            }
        }

        #endregion
    }
}