using CURD.Code;
using CURD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CURD.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddEditUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id.HasValue)
                {
                    StaticData.Update(model);
                }
                else
                {
                    StaticData.Save(model);
                }
            }
            string status = model.Id.HasValue ? "updated" : "saved";
            string message = $"User has been { status } successfully!";
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteUser(int id)
        {
            StaticData.Delete(id);
            string message = $"User has been removed successfully!";
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAllUsers()
        {
            List<UserViewModel> users = StaticData.UserList;
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetUser(int id)
        {
            UserViewModel userViewModel = StaticData.Find(id);
            return Json(userViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}