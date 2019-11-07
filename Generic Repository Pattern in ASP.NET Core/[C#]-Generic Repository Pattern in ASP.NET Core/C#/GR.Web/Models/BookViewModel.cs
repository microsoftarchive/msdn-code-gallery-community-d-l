using System.ComponentModel.DataAnnotations;

namespace GR.Web.Models
{
    public class BookViewModel
    {
        [Display(Name ="Book Name")]
        public string BookName { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
    }
}
