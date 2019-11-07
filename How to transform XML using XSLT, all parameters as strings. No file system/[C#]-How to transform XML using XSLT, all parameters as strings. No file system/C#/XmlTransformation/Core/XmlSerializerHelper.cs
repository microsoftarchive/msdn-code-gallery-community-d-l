namespace XmlTransformation
{
	using System.IO;
	using System.Xml;
	using System.Xml.Serialization;

	public class XmlSerializerHelper
	{
		public string Serialize(object obj)
		{
			var serializer = new XmlSerializer(obj.GetType());

			var writerSettings = 
				new XmlWriterSettings
					{
						OmitXmlDeclaration = true,
						Indent = true
					};

			var emptyNameSpace = new XmlSerializerNamespaces();
			emptyNameSpace.Add(string.Empty, string.Empty);

			var stringWriter = new StringWriter();
			using (var xmlWriter = XmlWriter.Create(stringWriter, writerSettings))
			{
				serializer.Serialize(xmlWriter, obj, emptyNameSpace);

				return stringWriter.ToString();
			}
		}
	}
}