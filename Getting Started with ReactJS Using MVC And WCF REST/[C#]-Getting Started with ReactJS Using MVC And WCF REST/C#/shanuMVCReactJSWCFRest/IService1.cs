using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace shanuMVCReactJSWCFRest
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
	[ServiceContract]
	public interface IService1
	{

		[OperationContract]
		[WebInvoke(Method = "GET",
			  RequestFormat = WebMessageFormat.Json,
			  ResponseFormat = WebMessageFormat.Json,
			  UriTemplate = "/GetItemDetails/")]
		List<ShanuDataContract.itemDetailsDataContract> GetItemDetails();

		// TODO: Add your service operations here
	}


	public class ShanuDataContract
	{
		[DataContract]
		public class itemDetailsDataContract
		{
			[DataMember]
			public string ItemID { get; set; }

			[DataMember]
			public string ItemName { get; set; }

			[DataMember]
			public string Desc { get; set; }

			[DataMember]
			public string Price { get; set; }

			
		}
	}

}
