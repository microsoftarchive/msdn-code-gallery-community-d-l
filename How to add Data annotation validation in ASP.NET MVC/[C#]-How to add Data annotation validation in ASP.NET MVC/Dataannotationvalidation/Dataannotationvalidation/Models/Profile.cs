using System.ComponentModel.DataAnnotations;

namespace Dataannotationvalidation.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Email ID is Required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email ID is not valid.")]
        [Display(Name = "Email Id")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Contact No is Required")]
        [Display(Name = "Contact No")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered Contact No format is not valid.")]
        public string ContactNo { get; set; }

        [StringLength(5)]
        [Required(ErrorMessage = "Rating is Required")]
        public string Rating { get; set; }

        [Required(ErrorMessage = "Age is Required")]
        [Range(1, 100, ErrorMessage = "Age must be between $1 and $100")]
        public decimal Age { get; set; }
    }
}