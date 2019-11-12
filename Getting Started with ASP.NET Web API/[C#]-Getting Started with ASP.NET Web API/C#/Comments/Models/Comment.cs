using System.ComponentModel.DataAnnotations;
using System.Web;
using Microsoft.Web.Helpers;

namespace Comments.Models
{
    public class Comment
    {
        public Comment() { }

        public Comment(string text, string author)
        {
            Text = text;
            Author = author;
        }

        public int ID { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Author is too long! This was validated on the server.")]
        public string Author { get; set; }

        [Required]
        public string Email { get; set; }

        public string GravatarUrl
        {
            get
            {
                return HttpUtility.HtmlDecode(Gravatar.GetUrl(Email ?? "", 40, defaultImage: "retro", rating: GravatarRating.G));
            }
            set { }
        }
    }
}