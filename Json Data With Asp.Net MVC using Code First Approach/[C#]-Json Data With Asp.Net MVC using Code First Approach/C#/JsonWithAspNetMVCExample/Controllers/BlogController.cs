using JsonWithAspNetMVCExample.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JsonWithAspNetMVCExample.Controllers
{
    public class BlogController : Controller
    {
        BlogContext db = null;
        // GET: Blog
        public BlogController()
        {
            db = new BlogContext();
        }
        public ActionResult Index()
        {
            List<SelectListItem> blogCategories = new List<SelectListItem>();
            blogCategories.Add(new SelectListItem { Text = "Select Category", Value = "0", Selected = true });
            var categories = db.Categories.ToList();
            foreach (var c in categories)
            {
                blogCategories.Add(new SelectListItem { Text = c.CategoryName, Value = Convert.ToString(c.CategoryId) });
            }
            ViewBag.CategoryList = blogCategories;
            return View();
        }
        public JsonResult GetBlogDetailByCategoryID(int categoryId)
        {
            List<Blog> blogs = new List<Blog>();
            blogs = db.Blogs.Where(x => x.CategoryId == categoryId).Take(5).ToList();
           
            return Json(blogs, JsonRequestBehavior.AllowGet);
        }

    }
}