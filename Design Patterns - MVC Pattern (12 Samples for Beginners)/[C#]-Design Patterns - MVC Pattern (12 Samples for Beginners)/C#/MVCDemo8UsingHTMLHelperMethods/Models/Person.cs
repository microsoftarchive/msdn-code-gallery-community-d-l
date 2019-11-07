using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVCDemo8UsingHTMLHelperMethods
{
    [Bind(Exclude = "Id")]
    public class Person
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Person name is required")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(160)]
        [DisplayName("Person Name")]
        public string Name { get; set; }
        
        [MVCDemo8UsingHTMLHelperMethods.Validations.AgeValidation]
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
    }
}