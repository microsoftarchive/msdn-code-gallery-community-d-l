using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Operations_In_MVC_Using_Web_API.Models
{

    public class Subscriber
    {
        public List<tbl_Subscribers> getSubcribers(SibeeshPassionEntities sb)
        {
            try
            {
                if (sb != null)
                {
                    return sb.tbl_Subscribers.ToList();
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}