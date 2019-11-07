using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Mvc3Filter.Models {
    public class EditUserModel {
        [Editable(false)]
        public virtual string UserName { get; set; }

        [Required]
        [StringLength(18, MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required()]
        public string City { get; set; }
    }

    public class CreateUserModel : EditUserModel {
        [Required]
        [StringLength(6, MinimumLength = 3)]
        [RegularExpression(@"(\S)+", ErrorMessage = "White space is not allowed")]
        [Editable(true)]
        public override string UserName { get; set; }
    }

}
