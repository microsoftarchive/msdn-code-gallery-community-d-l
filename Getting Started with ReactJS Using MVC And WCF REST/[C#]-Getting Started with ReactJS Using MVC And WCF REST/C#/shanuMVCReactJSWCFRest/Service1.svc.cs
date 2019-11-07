using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace shanuMVCReactJSWCFRest
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class Service1 : IService1
	{
		ItemDBEntities OME;
		public Service1()
		{
			OME = new ItemDBEntities();
		}

		public List<ShanuDataContract.itemDetailsDataContract> GetItemDetails()
		{
			var query = (from a in OME.ItemDetails
						 select a).Distinct();

			List<ShanuDataContract.itemDetailsDataContract> ItemDetailsList = new List<ShanuDataContract.itemDetailsDataContract>();

			query.ToList().ForEach(rec =>
			{
				ItemDetailsList.Add(new ShanuDataContract.itemDetailsDataContract
				{
					ItemID = Convert.ToString(rec.ItemID),
					ItemName = rec.ItemName,
					Desc = rec.Desc,
					Price =rec.Price
				});
			});
			return ItemDetailsList;
		}
	}
}
