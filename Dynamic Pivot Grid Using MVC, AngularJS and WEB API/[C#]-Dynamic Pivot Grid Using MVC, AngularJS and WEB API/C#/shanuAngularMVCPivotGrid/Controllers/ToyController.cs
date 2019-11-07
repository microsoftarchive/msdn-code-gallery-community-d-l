using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace shanuAngularMVCPivotGrid.Controllers
{
    public class ToyController : ApiController
    {
		ToysDBEntities objAPI = new ToysDBEntities();

		// to Search Student Details and display the result
		[HttpGet]
		public IEnumerable<USP_ToySales_Select_Result> Get(string ToyType, string ToyName)
		{
			if (ToyType == null)
				ToyType = "";
			if (ToyName == null)
				ToyName = "";

			return objAPI.USP_ToySales_Select(ToyType, ToyName).AsEnumerable();

		}
	}
}
