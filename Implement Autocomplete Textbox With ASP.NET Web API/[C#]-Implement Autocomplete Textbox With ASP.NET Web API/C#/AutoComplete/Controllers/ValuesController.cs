using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoComplete.Models;
namespace AutoComplete.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/test
        public IDictionary<int,string> Get(string term)
        {
            using (MVCMUSICSTOREEntities context = new MVCMUSICSTOREEntities()) {
                return context.Artists.Where(x => x.Name.Contains(term)).ToDictionary(x => x.ArtistId, x => x.Name);    
            }            
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post(string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}