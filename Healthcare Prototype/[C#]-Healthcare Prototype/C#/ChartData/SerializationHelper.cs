using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace IdentityMine.Avalon.PatientSimulator
{
    public class SerializationHelper
    {
        public static void UnknownNode(object sender, XmlNodeEventArgs e)
        {
            Console.WriteLine("Unknown Node:" + e.Name + "\t" + e.Text);
        }

        public static void UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            System.Xml.XmlAttribute attr = e.Attr;
            Console.WriteLine("Unknown attribute " + attr.Name + "='" + attr.Value + "'");
        }
    }
}
