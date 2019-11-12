using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductStore.Models;

namespace ProductStore.Controllers
{
    public class ProductsController : ApiController
    {
        IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> Get()
        {
            return _repository.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var product = _repository.GetByID(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        public IHttpActionResult Post(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repository.Add(product);
            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }
    }
}
