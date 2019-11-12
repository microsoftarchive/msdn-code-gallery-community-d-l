using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Comments.Controllers;
using Comments.Models;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using System.Web.Http.Hosting;

namespace Comments.Test
{
    [TestClass]
    public class CommentsControllerTest
    {
        [TestMethod]
        public void GetComments()
        {
            CommentsController controller = new CommentsController(new InitialData());
            IEnumerable<Comment> comments = controller.GetComments();
            Assert.IsNotNull(comments);
            Assert.IsTrue(comments.Count() > 0);
        }

        [TestMethod]
        public void GetComment()
        {
            CommentsController controller = new CommentsController(new InitialData());
            int id = 1;
            Comment comment = controller.GetComment(id);
            Assert.IsNotNull(comment);
            Assert.AreEqual(comment.ID, id);
        }

        [TestMethod]
        public void DeleteComment()
        {
            CommentsController controller = new CommentsController(new InitialData());
            int id = 1;
            Comment comment = controller.DeleteComment(id);
            Assert.IsNotNull(comment);
            Assert.AreEqual(comment.ID, id);
        }

        [TestMethod]
        public void PostComment()
        {
            Comment comment = new Comment()
            {
                Author = "Dan",
                Email = "daroth@microsoft.com",
                Text = "I love ASP.NET Web API!"
            };
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://localhost");
            request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            ICommentRepository repository = new InitialData();
            CommentsController controller = new CommentsController(repository) { Request = request };
            HttpResponseMessage response = controller.PostComment(comment);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Headers.Location);
            Comment postedComment = response.Content.ReadAsAsync<Comment>().Result;
            Assert.IsTrue(repository.TryGet(postedComment.ID, out postedComment));
        }

        [TestMethod]
        public void PagingGet()
        {
            CommentsController controller = new CommentsController(new InitialData());
            List<Comment> comments = new List<Comment>(controller.GetComments());
            int pageIndex = 1;
            int pageSize = 2;
            List<Comment> commentsPage = new List<Comment>(controller.GetComments(pageIndex, pageSize));
            Assert.AreEqual(2, commentsPage.Count);
            for (int i = 0; i < commentsPage.Count; i++)
            {
                Assert.AreEqual(comments[pageIndex * pageSize + i].ID, commentsPage[i].ID);
            }
        }
    }
}
