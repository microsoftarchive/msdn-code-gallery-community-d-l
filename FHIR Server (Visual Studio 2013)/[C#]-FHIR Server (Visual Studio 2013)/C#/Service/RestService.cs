// ***********************************************************************
// Assembly         : Service
// Author           : SH
// Created          : 05-11-2014
//
// Last Modified By : SH
// Last Modified On : 05-11-2014
// ***********************************************************************
// <copyright file="RestService.cs" author="Stefan Heesch">
//     Apache 2.0 license : http://www.apache.org/licenses/LICENSE-2.0.html.
// </copyright>
// <summary>
// Entry point for the REST service implementation. This class dispatches
// all incoming requests to resource or system specific handlers.
// It also catches any exception thrown by the handlers and returns an 
// corresponding HTTP status code plus error message to the client.
//</summary>
// ***********************************************************************
using System;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Hl7.Fhir.Serialization;
using Model; 


namespace Service
{
    /// <summary>
    /// Class RestService.
    /// </summary>
    /// <remarks>N/A</remarks>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class RestService : IRestService
    {
        /// <summary>
        /// The _registry
        /// </summary>
        private static Registry _registry;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestService"/> class.
        /// </summary>
        /// <remarks>N/A</remarks>
        public RestService( IRepository repository )
        {
            _registry = new Registry(repository);
        }

        
        /// <summary>
        /// Errors the message.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="message">The message.</param>
        /// <returns>Stream.</returns>
        /// <remarks>N/A</remarks>
        private Stream ErrorMessage(HttpStatusCode statusCode, string message)
        {
            if (WebOperationContext.Current != null)
            {
                WebOperationContext.Current.OutgoingResponse.ContentType = "text/plain";
                WebOperationContext.Current.OutgoingResponse.StatusCode = statusCode;
            }
            return new MemoryStream(Encoding.UTF8.GetBytes(message));
        }

        private String GetContentType(string mime, string format = null )
        {
            string parameter = format;
            if (parameter == null) parameter = mime;

            string content = "xml";
            if (parameter == "xml" || parameter == "text/xml" || parameter == "application/xml" || 
                parameter == "application/xml+fhir")
            {
                content = "xml";
            }
            else if (parameter == "json" || parameter == "text/json" || parameter == "application/json" ||
                parameter == "application/json+fhir")
            {
                content = "json";
            }
            return content;
        }

        public Stream Conformance()
        {
            var conformance = _registry.Metadata();

            if (WebOperationContext.Current != null)
            {
                string accept = WebOperationContext.Current.IncomingRequest.Accept;
                string payload;
                if (!String.IsNullOrEmpty(accept) && accept == "application/json")
                {
                    payload = FhirSerializer.SerializeResourceToJson(conformance);
                }
                else
                {
                    payload = FhirSerializer.SerializeResourceToXml(conformance);
                }
                return new MemoryStream(Encoding.UTF8.GetBytes(payload));
            }
            return new MemoryStream();
        }

        public Stream Create(string type, string format, Stream content)
        {
            IResourceHandler handler = _registry.GetHandler(type);
            if (handler == null)
            {
                return ErrorMessage(HttpStatusCode.NotImplemented, String.Format("Create resource version of type {0} not implemented.", type));
            }

            try
            {
                var reader = new StreamReader(content);
                string data = reader.ReadToEnd();

                string contentType = GetContentType(WebOperationContext.Current.IncomingRequest.ContentType, format);

                WebOperationContext.Current.OutgoingResponse.StatusCode = handler.Create(contentType, data);
                return new MemoryStream(Encoding.UTF8.GetBytes(String.Empty));
            }
            catch (Exception e)
            {
                return ErrorMessage(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public Stream Update(string type, string id, string format, Stream content)
        {
            IResourceHandler handler = _registry.GetHandler(type);
            if (handler == null)
            {
                return ErrorMessage(HttpStatusCode.NotImplemented, String.Format("Create resource version of type {0} not implemented.", type));
            }

            try
            {
                var reader = new StreamReader(content);
                string data = reader.ReadToEnd();

                string contentType = GetContentType(WebOperationContext.Current.IncomingRequest.ContentType, format);

               WebOperationContext.Current.OutgoingResponse.StatusCode = handler.Update(id, contentType, data);
                return new MemoryStream(Encoding.UTF8.GetBytes(String.Empty));
            }
            catch (Exception e)
            {
                return ErrorMessage(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public Stream Read(string type, string id)
        {
            IResourceHandler handler = _registry.GetHandler(type);
            if (handler == null)
            {
                return ErrorMessage(HttpStatusCode.NotImplemented, String.Format("Get resource of type {0} not implemented.", type));
            }

            try
            {
                string payload = handler.Read(id);
                if (String.IsNullOrEmpty(payload))
                {
                    return ErrorMessage(HttpStatusCode.NotFound, String.Format("Patient resource {0} not found", id));
                }
                return new MemoryStream(Encoding.UTF8.GetBytes(payload));
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(NotImplementedException))
                {
                    return ErrorMessage(HttpStatusCode.NotImplemented, e.Message);
                }
                return ErrorMessage(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public Stream Vread(string type, string id, string vid)
        {
            IResourceHandler handler = _registry.GetHandler(type);
            if (handler == null)
            {
                return ErrorMessage(HttpStatusCode.NotImplemented, String.Format("Get resource version of type {0} not implemented.", type));
            }

            try
            {
                string payload = handler.VRead(id, vid);
                if (String.IsNullOrEmpty(payload))
                {
                    return ErrorMessage(HttpStatusCode.NotFound, String.Format("Patient resource {0} / version {1} not found", id, vid));
                }
                return new MemoryStream(Encoding.UTF8.GetBytes(payload));
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(NotImplementedException))
                {
                    return ErrorMessage(HttpStatusCode.NotImplemented, e.Message);
                }
                return ErrorMessage(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public Stream Delete(string type, string id)
        {
            IResourceHandler handler = _registry.GetHandler(type);
            if (handler == null)
            {
                return ErrorMessage(HttpStatusCode.NotImplemented, String.Format("Delete resource of type {0} not implemented.", type));
            }
            WebOperationContext.Current.OutgoingResponse.StatusCode = handler.Delete(id);
            return new MemoryStream(Encoding.UTF8.GetBytes(String.Empty));
        }

        public Stream ValidateType(string type, String format, Stream data)
        {
            IResourceHandler handler = _registry.GetHandler(type);
            if (handler == null)
            {
                return ErrorMessage(HttpStatusCode.NotImplemented, String.Format("Valiate resource of type {0} not implemented.", type));
            }
            throw new NotImplementedException();
        }

        public Stream Validate(string type, string id, String format, Stream data)
        {
            IResourceHandler handler = _registry.GetHandler(type);
            if (handler == null)
            {
                return ErrorMessage(HttpStatusCode.NotImplemented, String.Format("Valiate resource of type {0} not implemented.", type));
            }
            throw new NotImplementedException();
        }


        public Stream History(string type, string id)
        {
            IResourceHandler handler = _registry.GetHandler(type);
            if (handler == null)
            {
                return ErrorMessage(HttpStatusCode.NotImplemented, String.Format("Valiate resource of type {0} not implemented.", type));
            }
            throw new NotImplementedException();
        }

        public Stream HistoryType(string type)
        {
            IResourceHandler handler = _registry.GetHandler(type);
            if (handler == null)
            {
                return ErrorMessage(HttpStatusCode.NotImplemented, String.Format("Valiate resource of type {0} not implemented.", type));
            }
            throw new NotImplementedException();
        }

        public Stream HistoryAll()
        {
            throw new NotImplementedException();
        }

        public Stream Search(string type)
        {
            IResourceHandler handler = _registry.GetHandler(type);
            if (handler == null)
            {
                return ErrorMessage(HttpStatusCode.NotImplemented, String.Format("Search for resource of type {0} not implemented.", type));
            }
            throw new NotImplementedException();
        }

        public Stream SearchAll()
        {
            throw new NotImplementedException();
        }


        public Stream Transaction()
        {
            throw new NotImplementedException();
        }



    }
}
