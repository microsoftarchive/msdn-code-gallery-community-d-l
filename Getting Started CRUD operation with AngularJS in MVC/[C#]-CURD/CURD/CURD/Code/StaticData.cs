using CURD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CURD.Code
{
    public static class StaticData
    {
        public static List<UserViewModel> UserList = new List<UserViewModel>();

        public static UserViewModel Find(int id)
        {
            return UserList.SingleOrDefault(u => u.Id == id);
        }

        public static void Save(UserViewModel model)
        {
            model.Id = model.Id ?? new Random().Next(999999);
            model.CreatedDate = DateTime.Now.ToString();
            UserList.Add(model);
        }

        public static void Update(UserViewModel model)
        {
            bool isRemoved = Delete(model.Id.Value);
            if (isRemoved)
            {
                Save(model);
            }
        }

        public static bool Delete(int id)
        {
            UserViewModel model = StaticData.Find(id);
            return UserList.Remove(model);
        }
    }
}