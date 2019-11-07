/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSDLToWebService
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServiceGenerator.Generate("TestWS.wsdl", "GeneratedWS.cs");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
