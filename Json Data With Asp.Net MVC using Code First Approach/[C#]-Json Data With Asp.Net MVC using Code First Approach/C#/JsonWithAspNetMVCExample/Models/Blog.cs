using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JsonWithAspNetMVCExample.Models
{
    [Table("NextPosts")]
    public class Blog
    {
        [Key]
        public int PostId { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "varchar")]
        public string PostTitle { get; set; }

        [MaxLength(1000)]
        [Column(TypeName = "text")]
        public string ShortPostContent { get; set; }

        [Column(TypeName = "text")]
        public string FullPostContent { get; set; }

        [MaxLength(255)]
        public string MetaKeywords { get; set; }

        [MaxLength(500)]
        public string MetaDescription { get; set; }
        public DateTime PostAddedDate { get; set; }

        public int CategoryId { get; set; }

        //public virtual int CategoryId { get; set; }
        //[ForeignKey("CategoryId")]
        //public virtual Category Categories { get; set; }
    }
}