using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using CRUD_Operations_In_MVC_Using_Web_API.Models;
namespace CRUD_Operations_In_MVC_Using_Web_API.Controllers
{
    public class SubscribersController : ApiController
    {
        public List<tbl_Subscribers> getSubscribers()
        {
            try
            {
                using (var db = new SibeeshPassionEntities())
                {
                    Subscriber sb = new Subscriber();
                    return (sb.getSubcribers(db).ToList());
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
