using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConditionalValidation.Infrastructure;

namespace ConditionalValidation.Models.Home
{
    public class PendingRequestModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [StringLength(20)]
        [Required]
        public string Title { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime RequestedOn { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueOn { get; set; }

        public bool IsComplete { get; set; }

        [DataType(DataType.MultilineText)]
        //[RequiredIf("IsComplete", ErrorMessage = "Must add comments if the item is complete")]instl
        [RequiredIf("IsComplete || DueOn < DateTime.Now", ErrorMessage = "Must add comments if the item is complete or overdue")]
        public string Comments { get; set; }

        [RequiredIf("Title == \"Test\" || DueOn < RequestedOn", ErrorMessage= "Test")]
        public string Wibble { get; set; }
    }
}