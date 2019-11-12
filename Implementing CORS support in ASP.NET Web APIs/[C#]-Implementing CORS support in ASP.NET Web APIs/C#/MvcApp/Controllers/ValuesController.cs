using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Net;

namespace MvcApp.Controllers
{
    public class ValuesController : ApiController
    {
        static List<string> allValues = new List<string> { "value1", "value2" };

        // GET /api/values
        public IEnumerable<string> Get()
        {
            return allValues;
        }

        // GET /api/values/5
        public string Get(int id)
        {
            if (id < allValues.Count)
            {
                return allValues[id];
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // POST /api/values
        public HttpResponseMessage Post(string value)
        {
            allValues.Add(value);
            return new HttpResponseMessage<int>(allValues.Count - 1, HttpStatusCode.Created);
        }

        // PUT /api/values/5
        public void Put(int id, string value)
        {
            if (id < allValues.Count)
            {
                allValues[id] = value;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // DELETE /api/values/5
        public void Delete(int id)
        {
            if (id < allValues.Count)
            {
                allValues.RemoveAt(id);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}