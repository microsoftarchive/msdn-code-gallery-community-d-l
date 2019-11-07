using System.Web.Mvc;

namespace MVCDemo2ControllerParameters
{
    public class HelloWorldParametersController : Controller
    {
        public string SayHello()
        {
            string message = "Step1 : Hello World! I am just 1 Controller with 3 Actions, without View and Model<br>";
            message += "Step2 : You can also invoke SayHelloMessage as <a href='http://localhost:55552/HelloWorldParameters/SayHelloMessage?YourName=Sai'> http://localhost:55552/HelloWorldParameters/SayHelloMessage?YourName=Sai </a> <br>";
            message += "Step3 : You can also invoke SayHelloMessage as <a href='http://localhost:55552/HelloWorldParameters/SayHelloId?Id=123'> http://localhost:55552/HelloWorldParameters/SayHelloId?Id=123 </a> <br>";
            message += "Step4 : You can also invoke SayHelloMessage as <a href='http://localhost:55552/HelloWorldParameters/SayHelloId/456'> http://localhost:55552/HelloWorldParameters/SayHelloId/456 </a> <br><br>";
            message += "Step5 : Now go to Global.aspx.cs and see <b> Id </b> mentioned as default parameter.";

            return message;
        }
        public string SayHelloMessage(string YourName)
        {
            string message = "Hello ... " + YourName;

            return message;
        }
        public string SayHelloId(int Id)
        {
            string message = "Your Luckey Number is ..." + Id;

            return message;
        }
    }
}