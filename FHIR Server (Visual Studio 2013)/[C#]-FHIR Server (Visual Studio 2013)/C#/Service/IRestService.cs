// ***********************************************************************
// Assembly         : ServiceLayer
// Author           : SH
// Created          : 05-11-2014
//
// Last Modified By : SH
// Last Modified On : 05-11-2014
// ***********************************************************************
// <copyright file="IRestService.cs" author="Stefan Heesch">
//     Apache 2.0 license : http://www.apache.org/licenses/LICENSE-2.0.html.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

#pragma warning disable 1587
/// <summary>
/// The API describes the FHIR resources as a set of operations (known as "interactions") on
/// resources where individual resource instances are managed in collections by their type.
/// Servers can choose which of these interactions are made available and which resource types
/// they support. Servers SHALL provide a conformance statement that specifies what interactions
/// and resources are supported.
/// </summary>
/// <remarks>
/// The specification of the RESTful API can be found on the HL7 FHIR website:
/// http://www.hl7.org/implement/standards/fhir/http.html
/// </remarks>
#pragma warning restore 1587
namespace Service
{
    /// <summary>
    /// Interface IRestService
    /// </summary>
    /// <remarks>N/A</remarks>
    [ServiceContract]
    public interface IRestService
    {
        // Set of logical interactions with either instance, type or system as defined in spec:
        // http://www.hl7.org/implement/standards/fhir/http.html
        //
        #region Locgical interactions 
        /// <summary>
        /// Read the current state of the resource
        /// </summary>
        /// <param name="type">The resource type.</param>
        /// <param name="id">The rescoure identifier.</param>
        /// <returns>This returns a single instance with the content specified for the resource type.
        /// This url may be accessed by a browser. The possible values for the Logical Id (id) itself 
        /// are described in the id type. Servers are required to return a content-location header 
        /// with the response which is the full version specific url (see vread below) and a 
        /// Last-Modified header. </returns>
        /// <remarks>
        /// The read interaction accesses the current contents of a resource. The interaction is 
        /// performed by an HTTP GET command.
        /// Unknown resources and deleted resources are treated differently on a read: A GET
        /// for a deleted resource returns a 410 status code, whereas a GET for an unknown 
        /// resource returns 404. Systems that do not track deleted records will treat deleted 
        /// records as an unknown resource. </remarks>
        [OperationContract]
        [WebGet(UriTemplate = "/{type}/{id}")]
        Stream Read(string type, string id);


        /// <summary>
        /// Read the state of a specific version of the resource
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="vid">The vid.</param>
        /// <returns>Stream.</returns>
        /// <remarks>N/A</remarks>
        [OperationContract]
        [WebGet(UriTemplate = "/{type}/{id}/_history/{vid}")]
        Stream Vread(string type, string id, string vid);


        /// <summary>
        /// Get a conformance statement for the system
        /// </summary>
        /// <returns>Stream.</returns>
        /// <remarks>N/A</remarks>
        [OperationContract]
        [WebGet(UriTemplate = "/metadata")]
        Stream Conformance();


        /// <summary>
        /// Update an existing resource by its id (or create it if it is new).
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="format"></param>
        /// <param name="data"></param>
        /// <returns>Stream.</returns>
        /// <remarks>N/A</remarks>
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/{type}/{id}?_format={format}", BodyStyle = WebMessageBodyStyle.Bare)]
        Stream Update(string type, string id, string format, Stream data);


        /// <summary>
        /// Create a new resource with a server assigned id
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="format"></param>
        /// <param name="data"></param>
        /// <returns>Stream.</returns>
        /// <remarks>N/A</remarks>
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/{type}?_format={format}", BodyStyle = WebMessageBodyStyle.Bare)]
        Stream Create(string type, string format, Stream data);


        /// <summary>
        /// Update, create or delete a set of resources as a single transaction
        /// </summary>
        /// <returns>Stream.</returns>
        /// <remarks>N/A</remarks>
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/")]
        Stream Transaction();


        /// <summary>
        /// Delete a resource
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Stream.</returns>
        /// <remarks>N/A</remarks>
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/{type}/{id}")]
        Stream Delete(string type, string id);

        /// <summary>
        /// Search the resource type based on some filter criteria
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Stream.</returns>
        /// <remarks>N/A</remarks>
        [OperationContract]
        [WebGet(UriTemplate = "/{type}?")]
        Stream Search(string type);

        /// <summary>
        /// Search across all resource types based on some filter criteria
        /// </summary>
        /// <returns>Stream.</returns>
        /// <remarks>N/A</remarks>
        [OperationContract]
        [WebGet(UriTemplate = "/")]
        Stream SearchAll();


        /// <summary>
        /// Check that the content would be acceptable as an update
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Stream.</returns>
        /// <remarks>N/A</remarks>
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/{type}/_validate?_format={format}", BodyStyle = WebMessageBodyStyle.Bare)]
        Stream ValidateType(string type, string format, Stream data);

        /// <summary>
        /// Check that the content would be acceptable as an update
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Stream.</returns>
        /// <remarks>N/A</remarks>
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/{type}/_validate({id}?_format={format}", BodyStyle = WebMessageBodyStyle.Bare)]
        Stream Validate(string type, string id, string format, Stream data);

        /// <summary>
        /// Retrieve the update history for a particular resource
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Stream.</returns>
        /// <remarks>N/A</remarks>
        [OperationContract]
        [WebGet(UriTemplate = "/{type}/{id}/_history")]
        Stream History(string type, string id);

        /// <summary>
        /// Retrieve the update history for a particular resource type
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Stream.</returns>
        /// <remarks>N/A</remarks>
        [OperationContract]
        [WebGet(UriTemplate = "/{type}/_history")]
        Stream HistoryType(string type);


        /// <summary>
        /// Retrieve the update history for all resources
        /// </summary>
        /// <returns>Stream.</returns>
        /// <remarks>N/A</remarks>
        [OperationContract]
        [WebGet(UriTemplate = "/_history")]
        Stream HistoryAll();
        #endregion

        #region Tags
        // Not defined yet, can be added here - follow defintions above and see spec:
        // http://www.hl7.org/implement/standards/fhir/http.html#summary
        #endregion

        #region Mailbox
        // Not defined yet, can be added here - follow defintions above and see spec:
        // http://www.hl7.org/implement/standards/fhir/http.html#summary
        #endregion

        #region Document
        // Not defined yet, can be added here - follow defintions above and see spec:
        // http://www.hl7.org/implement/standards/fhir/http.html#summary
        #endregion
    }
}
