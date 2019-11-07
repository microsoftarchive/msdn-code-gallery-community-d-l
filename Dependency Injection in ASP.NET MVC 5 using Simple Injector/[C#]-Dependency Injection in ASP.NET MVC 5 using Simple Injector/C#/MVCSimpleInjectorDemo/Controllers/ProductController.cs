using MVCSimpleInjectorDemo.DomainModels;
using MVCSimpleInjectorDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSimpleInjectorDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repository;

        //inject dependency
        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        // GET: Product
        public ActionResult Index()
        {
            var data = repository.GetAll();
            return View(data);
        }

        public ActionResult Edit(int Id)
        {
            var data = repository.Get(Id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.Update(product);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}