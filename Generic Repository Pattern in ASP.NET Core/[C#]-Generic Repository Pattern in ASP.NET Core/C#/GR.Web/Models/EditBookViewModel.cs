using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GR.Web.Models
{
    public class EditBookViewModel
    {
        [Display(Name="Book Name")]
        public string BookName { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public List<SelectListItem> Authors { get; set; } = new List<SelectListItem>();
        [Display(Name = "Author")]
        public long AuthorId { get; set; }
    }
}
