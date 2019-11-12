using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Api.DbContext;
using MongoDB.Bson;
using MongoDB.Driver;
using Api.Models;

namespace Api.Controllers
{
    public class ProductController : ApiController
    {
        // GET api/<controller>
        [Route("v1/products/getAllProducts")]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var blogContext = new ProductContext();
            var recentPosts = await blogContext.Products.Find(x => true).ToListAsync();
            return recentPosts;
        }

        // POST api/<controller>
        [Route("v1/products/addProduct")]
        public async Task<HttpResponseMessage> PostAddProduct(Product product)
        {
            var productContext = new ProductContext();
            var post = new Product
            {
                Brand = product.Brand,
                Type = product.Type,
                Name = product.Name,
            };

            await productContext.Products.InsertOneAsync(post);

            return Request.CreateResponse("Product Successfully Added");
        }

        // POST api/<controller>
        [Route("v1/products/updateProduct")]
        public async Task<HttpResponseMessage> PostUpdateProduct(Product product)
        {
            var productContext = new ProductContext();
            await productContext.Products.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(product.Id)), product);

            return Request.CreateResponse("Product Successfully Updated");
        }
    }
}