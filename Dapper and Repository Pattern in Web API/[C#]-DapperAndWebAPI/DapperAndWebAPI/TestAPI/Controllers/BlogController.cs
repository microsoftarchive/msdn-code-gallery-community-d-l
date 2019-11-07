using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace TestAPI.Controllers
{
    public class BlogController : ApiController
    {
        IBlogService _blogService;

        public BlogController()
        {

        }
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<IHttpActionResult> GetAllBlogPostsByPageIndex()
        {
            var resultData = await _blogService.GetAllBlogByPageIndex(3, 4);
            if (resultData == null)
            {
                return NotFound();
            }
            return Ok(resultData);
        }
    }
}
