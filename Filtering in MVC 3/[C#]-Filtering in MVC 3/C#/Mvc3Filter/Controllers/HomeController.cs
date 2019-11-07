using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Mvc3Filter.Models;
using Mvc3Filter.Filters;
using Mvc3Filter.Helpers;

namespace Mvc3Filter.Controllers {

    public class HomeController : Controller {
        IUserDB _repository;

#if  InMemDB
        public HomeController() : this(InMemoryDB.Instance) { }
#else
        public HomeController() : this(new EF_UserRepository()) { }
#endif


        public HomeController(IUserDB repository) {
            _repository = repository;
        }

        public ViewResult Index() {
            return View("Index", _repository.GetAllUsers);
        }

        public ActionResult Details(string id) {
            User user = _repository.GetUser(id);
            if (user == null)
                return RedirectToAction("Index");

            return View("Details", user);
        }

        public ActionResult Edit(string id) {
            User user = _repository.GetUser(id);
            if (user == null)
                return RedirectToAction("Index");

            EditUserModel model = new EditUserModel();
            ModelCopier.CopyModel(user, model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserModel model) {
            try {
                User user = _repository.GetUser(model.UserName);
                ModelCopier.CopyModel(model, user);
                _repository.Update(user);

                return RedirectToAction("Details", new { id = model.UserName });
            } catch (Exception) {
                ModelState.AddModelError("", "Edit Failure, see inner exception.");
            }

            return View(model);
        }

        public ActionResult About() {
            return View();
        }

        public ViewResult Create() {
            return View(new CreateUserModel());
        }

        [HttpPost]
        public ActionResult Create(CreateUserModel model) {
            try {
                if (ModelState.IsValid) {
                    User user = new User();
                    ModelCopier.CopyModel(model, user);
                    _repository.CreateNewUser(user);

                    return RedirectToAction("Details", new { id = user.UserName });
                }
            } catch (Exception) {
                ModelState.AddModelError("", "Create Failure, try another user name or" +
                    " see inner exception.");
            }

            return View("Create", model);
        }

        public ActionResult Delete(string id) {
            User user = _repository.GetUser(id);
            if (user == null)
                return RedirectToAction("Index");

            return View(user);
        }

        [HttpPost]
        public RedirectToRouteResult Delete(string id, FormCollection collection) {
            _repository.Remove(id);
            return RedirectToAction("Index");
        }



        public ActionResult TestStatus(int id) {

            switch (id) {
                case 410:
                    return new HttpStatusCodeResult(410, "Please remove this link");


                case 404:
                    return new HttpStatusCodeResult(404);

                case 40404:
                    return HttpNotFound();

                case 404404:
                    return HttpNotFound("My Not Found Message");

                default:
                    return new HttpNotFoundResult("file not found");
            }
        }
    }
}
