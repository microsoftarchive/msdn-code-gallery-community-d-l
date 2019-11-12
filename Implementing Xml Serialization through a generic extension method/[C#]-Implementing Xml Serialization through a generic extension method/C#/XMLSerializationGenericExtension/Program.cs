/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XMLSerializationGenericExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomDataType objectInstance = new CustomDataType();
            objectInstance.DateTimeMember = DateTime.Now;
            objectInstance.IntMember = 42;
            objectInstance.StringMember = "Some random string";

            string xmlString = objectInstance.XmlSerialize();

            Console.WriteLine(xmlString);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
