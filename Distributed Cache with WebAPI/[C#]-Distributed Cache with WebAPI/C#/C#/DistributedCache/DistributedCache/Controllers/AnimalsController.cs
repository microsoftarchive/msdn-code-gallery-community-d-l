using System.Collections.Generic;
using System.Globalization;
using System.Web.Http;
using System.Linq;
using DistributedCache.DAL;
using DistributedCache.Filters;

namespace DistributedCache.Controllers
{
    [RoutePrefix("api/animals")]
    public class AnimalsController : ApiController
    {
        [OutputCacheWebApi(serverCacheSecond: 60, allowAnonymous: true)]
        [Route]
        [HttpGet]
        public IEnumerable<Animal> Get()
        {
            using (var dbContext = new Model1())
            {
                return dbContext.Animals.OrderBy(a => a.Name).ToList();
            }
        }

        [OutputCacheWebApi(serverCacheSecond: 60, allowAnonymous: true)]
        [Route("{id:int}", Name = "GetById")]
        [HttpGet]
        public Animal Get(int id)
        {
            using (var dbContext = new Model1())
            {
                return dbContext.Animals.FirstOrDefault(a => a.Id == id);
            }
        }

        [Route]
        public IHttpActionResult Post(string name, int age)
        {
            var newAnimal = new Animal() { Name = name, Age = age };
            using (var dbContext = new Model1())
            {                
                dbContext.Animals.Add(newAnimal);
                dbContext.SaveChanges();
            }

            var location = Url.Link("GetById", new { id = newAnimal.Id.ToString(CultureInfo.InvariantCulture) });
            return this.Created(location, newAnimal);
        }
    }
}