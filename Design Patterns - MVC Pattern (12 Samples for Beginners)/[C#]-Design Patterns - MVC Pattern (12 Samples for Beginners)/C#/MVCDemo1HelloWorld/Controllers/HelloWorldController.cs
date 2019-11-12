using System.Web.Mvc;

namespace MVCDemo1HelloWorld
{
    public class HelloWorldController : Controller
    {
        public string SayHello()
        {
            string message = "Step1 : Hello World! I am just one Controller with one Action, without View and Model<br>";
            message += "Step2 : You can also invoke me as <a href='http://localhost:55551/HelloWorld'> http://localhost:55551/HelloWorld</a> <br>";
            message += "Step3 : You can also invoke me as <a href='http://localhost:55551/HelloWorld/SayHello'> http://localhost:55551/HelloWorld/SayHello </a> <br>";
            message += "Step4 : Now go to Global.aspx.cs and see the methods, so that you will understan, how I was invoked.";

            return message;
        }
    }
}