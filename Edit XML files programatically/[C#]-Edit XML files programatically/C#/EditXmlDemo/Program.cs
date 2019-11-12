using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;

namespace EditXmlDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            
            string path = @"C:\Users\TestFolder\EditXmlDemo\EditXmlDemo\XMLFile1.xml";
            doc.Load(path);
            IEnumerator ie = doc.SelectNodes("/appSettings/add").GetEnumerator();

            while (ie.MoveNext())
            {
                if ((ie.Current as XmlNode).Attributes["key"].Value == "ServerAddress")
                {
                    (ie.Current as XmlNode).Attributes["value"].Value = "hello";
                }
            }

            doc.Save(path);
        }
    }
}
