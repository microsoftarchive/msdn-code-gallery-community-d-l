using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GR.Web.Models;
using GR.Data;


namespace GR.Web.Controllers
{
    public class AuthorController : Controller
    {
        private IRepository<Author> repoAuthor;
        private IRepository<Book> repoBook;
        public AuthorController(IRepository<Author> repoAuthor, IRepository<Book> repoBook)
        {
            this.repoAuthor = repoAuthor;
            this.repoBook = repoBook;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<AuthorListingViewModel> model = new List<AuthorListingViewModel>();

            repoAuthor.GetAll().ToList().ForEach(a =>
            {
                AuthorListingViewModel author = new AuthorListingViewModel
                {
                    Id = a.Id,
                    Name = $"{a.FirstName} {a.LastName}",
                    Email = a.Email
                };
                author.TotalBooks = repoBook.GetAll().Count(x => x.AuthorId == a.Id);
                model.Add(author);
            });
            return View("Index", model);

        }

        [HttpGet]
        public PartialViewResult AddAuthor()
        {
            AuthorBookViewModel model = new AuthorBookViewModel();
            return PartialView("_AddAuthor", model);
        }

        [HttpPost]
        public ActionResult AddAuthor(AuthorBookViewModel model)
        {
            Author author = new Author
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                AddedDate = DateTime.UtcNow,
                IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                ModifiedDate = DateTime.UtcNow,
                Books = new List<Book>
                {
                    new Book
                    {
                        Name = model.BookName,
                        ISBN= model.ISBN,
                        Publisher = model.Publisher,
                        IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                        AddedDate = DateTime.UtcNow,
                        ModifiedDate = DateTime.UtcNow
                    }
                }
            };
            repoAuthor.Insert(author);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAuthor(long id)
        {
            AuthorViewModel model = new AuthorViewModel();
            Author author = repoAuthor.Get(id);
            if (author != null)
            {
                model.FirstName = author.FirstName;
                model.LastName = author.LastName;
                model.Email = author.Email;
            }
            return PartialView("_EditAuthor", model);
        }
        [HttpPost]
        public IActionResult EditAuthor(long id, AuthorViewModel model)
        {
            Author author = repoAuthor.Get(id);
            if (author != null)
            {
                author.FirstName = model.FirstName;
                author.LastName = model.LastName;
                author.Email = model.Email;
                author.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                author.ModifiedDate = DateTime.UtcNow;
                repoAuthor.Update(author);
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public PartialViewResult AddBook(long id)
        {
            BookViewModel model = new BookViewModel();
            return PartialView("_AddBook", model);
        }
        [HttpPost]
        public IActionResult AddBook(long id, BookViewModel model)
        {
            Book book = new Book
            {
                AuthorId = id,
                Name = model.BookName,
                ISBN = model.ISBN,
                Publisher = model.Publisher,
                IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                AddedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };
            repoBook.Insert(book);
            return RedirectToAction("Index");
        }
    }
}
