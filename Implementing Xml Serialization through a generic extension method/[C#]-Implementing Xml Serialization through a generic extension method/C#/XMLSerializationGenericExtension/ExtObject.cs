/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace XMLSerializationGenericExtension
{
    public static class ExtObject
    {
        public static string XmlSerialize<T>(this T objectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter);

            xmlWriter.Formatting = Formatting.Indented;
            xmlSerializer.Serialize(xmlWriter, objectToSerialize);

            return stringWriter.ToString();
        }
    }
}
