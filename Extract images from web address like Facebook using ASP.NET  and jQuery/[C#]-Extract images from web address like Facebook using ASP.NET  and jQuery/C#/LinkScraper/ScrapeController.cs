using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace LinkScraper
{
    public class ScrapeController : ApiController
    {
        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        public string Post([FromBody]string value)
        {

            try
            {
               
                HttpWebRequest request = HttpWebRequest.Create(value) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                var ResponseStream = response.GetResponseStream();

                HtmlDocument document = new HtmlDocument();
                document.Load(ResponseStream);
                string imgSrc = string.Empty;
                var ogMeta = document.DocumentNode.SelectNodes("//meta[@property]");
                //Check if contain Open graph element
                if (ogMeta != null)
                {
                    var ogImage = document.DocumentNode.SelectNodes("//meta[@property]").Where(x => x.Attributes["property"].Value == "og:image");
                    if (ogImage.Count() > 0) //check og:image found
                        return string.Concat("<li> <img src=", ogImage.FirstOrDefault().Attributes["content"].Value, " /></li>");
                    else  //return some images
                        return GetImages(document.DocumentNode.SelectNodes("//img"));
                }
                else
                {

                     return GetImages(document.DocumentNode.SelectNodes("//img"));
                }

               

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        private string GetImages(HtmlNodeCollection DOM)
        {
            StringBuilder Images = new StringBuilder();
            if (DOM != null)
            {
                foreach (var img in DOM)
                {


                    Images.AppendFormat("<li>");
                    Images.AppendFormat(img.OuterHtml);
                    Images.AppendFormat("</li>");

                }
            }
            return Images.ToString();
        }
        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}