using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCDemo6HTTPGetPost
{
    public class PersonController : Controller
    {
        static List<Person> people = new List<Person>();
        static Person person = new Person();
        
        // GET: /Person/
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            //ViewModel.Session = this.ControllerContext.HttpContext.Session.SessionID;
            return View();
        }

        // GET: /Person/Details
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Details(Person person)
        {
            return View(person);
        }

        // GET: /Person/Create
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            return View();
        }
        
        // POST: /Person/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", person);
            }

            people.Add(person);
            
            //Redirect(); 
            //return RedirectToAction("Index");
            return RedirectToAction("Details",person);
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult Create(int Id, string Name, int Age, string Street, string City, string State, int ZipCode)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View("Create", people);
        //    }
        //    else
        //    {
        //        person.Id = Id;
        //        person.Name = Name;
        //        person.Age = Age;
        //        person.Street = Street;
        //        person.City = City;
        //        person.State = State;
        //        person.Zipcode = ZipCode;
        //        people.Add(person);
                
        //        return RedirectToAction("Details", person);
        //    }
        //}
    }
}

/*
<!--
Good MVC Samples can be found here
http://dotnetslackers.com/articles/aspnet/ASP-NET-MVC-2-0-Using-Multiple-Actions.aspx

 foreach ( LogOn As MvcApplication1.LogOn in ViewData.Model) 
          <p> 
 
          LogOn.EntryDate.ToShortTimeString()
          LogOn.Message%> 
          </p> 
--------------------------------------------------------     
Html.Hidden("TimeStamp", Model.TimeStamp)

<form action="/RenderingActions/Custom" method="post">
<div>
Name: <input id="CustomName" name="CustomName" type="text" value="" />
</div>
<div>
Value: <input id="CustomValue" name="CustomValue" type="text" value="" />
</div>
<input type="submit" value="save" />
</form>
--------------------------------------------------------------
<p>

<div id="customresponse"></div>
<% using (Ajax.BeginForm("AjaxCustom", new AjaxOptions { UpdateTargetId = "customresponse" }))
{ %>
<div>
Name: <%= Html.TextBox("CustomName")%>
</div>
<div>
Value: <%= Html.TextBox("CustomValue")%>
</div>
<input type="submit" value="save" />
<% } %>
</p>

HttpPost]

public ActionResult AjaxCustom(FormCollection post)
{
if (Request.IsAjaxRequest())
return Content("Success");
else
return PartialView();
} 
--------------------------------------------------------------
<p>

JQuery Ajax Index
</p>
<% Html.BeginForm(); %>
<div>
Name: <%= Html.TextBox("IndexName") %>
</div>
<div>
Value: <%= Html.TextBox("IndexValue") %>
</div>
<input type="submit" value="save" />
<% Html.EndForm(); %>
<div id="JQueryCustomParent">
<%= Html.Action("JQueryCustomIndex") %>
</div>

<script type='text/javascript'>
function attachToForm() 
{
$("#JQueryCustomParent").find("form:first").submit(function(e) 
{
e.preventDefault();
$.post($(this).attr("action"), $(this).serialize(),               
function(data) 
{
$("#JQueryCustomParent").replaceWith($("<div/>")
.attr("id", "JQueryCustomParent").html(data));
attachToForm();
});
});
}
$(document).ready(function() 
{
attachToForm();
});

</script>

Enter this in textbox to inject java script <script>alert(“Boo!”)</script>
-->

What is REST? 
 
REST stands for REpresentational State Transfer and it is a method for retrieving content from an HTTP endpoint. 
REST is not new having been around since HTML 1.0. The World Wide Web itself is the largest REST example. 
A server is at rest, waiting for a request. A client invokes a request from a resource that is identified by a Uniform Resource Locator (URL).  
At that moment, the server is no longer at rest as it invokes the actions that are defined in the URL. The request is processed and returned to the client. 
The server goes back to its restful state.  REST’s most notable feature is that it is stateless. In other words, each call has all the necessary information for the server to process the request. 
These kinds of requests are known as HTTP GET requests. This is not to say the server can’t hold and manage state. We do this all of the time with sessions in IIS. 
Most of the time, when we make requests, the response is a combination of HTML markup, CSS, script (JavaScript/jQuery) and data. 
It’s all combined and presented in a browser, whether it is on your desktop, laptop, tablet or phone. If this is the only way to present your information, several limitations result. 
For one thing, you data presentation is locked into a specific implementation. 
It’s still RESTful, but from a separation of concerns standpoint, you have the classic monolithic application problem wherein your application is difficult to maintain, is not flexible, not amenable to change, etc. 
It’s far better to tease your application apart and a good way to start is to expose endpoints that just serve data.

 */
