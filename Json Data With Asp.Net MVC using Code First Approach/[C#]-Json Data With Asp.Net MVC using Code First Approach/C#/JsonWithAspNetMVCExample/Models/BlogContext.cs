using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace JsonWithAspNetMVCExample.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("testConnection")
        {
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}