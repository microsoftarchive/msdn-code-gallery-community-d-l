using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JsonWithAspNetMVCExample.Models
{
    [Table("NextCategories")]
    public class Category
    {
        [Key]
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        [MaxLength(25)]
        public string CategoryName { get; set; }

    }
}