using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstCore.Models
{
    public class Article
    {
        
        public int ID { get; set; }
        [Required(ErrorMessage = "Enter Article Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Article")]
        public string ArticleText { get; set; }
    }
}
