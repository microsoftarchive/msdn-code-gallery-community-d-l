using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShanuMVCWebAPIAngular.Controllers
{
    public class ImageController : ApiController
    {
        ImageDBEntities objAPI = new ImageDBEntities();

        //get all Images
        [HttpGet]
        public IEnumerable<ImageDetails> Get()
        {
           return objAPI.ImageDetails.AsEnumerable();
            //return objAPI.ImageDetails.AsEnumerable().OrderByDescending(item => item.ImageID );

        }

        //insert Image
        public HttpResponseMessage Post(ImageDetails imagedetails)
        {
            if (ModelState.IsValid)
            {
                objAPI.ImageDetails.Add(imagedetails);
                objAPI.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, imagedetails);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = imagedetails.Image_Path}));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }



    }
}
