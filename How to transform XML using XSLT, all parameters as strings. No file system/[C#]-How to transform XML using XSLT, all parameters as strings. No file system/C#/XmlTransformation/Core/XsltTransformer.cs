namespace XmlTransformation
{
	using System.IO;
	using System.Xml;
	using System.Xml.Xsl;

	public class XsltTransformer
	{
		private readonly XslCompiledTransform xslTransform;

		public XsltTransformer(string xsl)
		{
			xslTransform = new XslCompiledTransform();

			var xslt = XmlReader.Create(new StringReader(xsl));
			xslTransform.Load(xslt);
		}

		public string Transform(object person)
		{
			var xml =
				new XmlSerializerHelper()
					.Serialize(person);

			using (var writer = new StringWriter())
			{
				var input = XmlReader.Create(new StringReader(xml));

				xslTransform.Transform(input, null, writer);
				return writer.ToString();
			}
		}
	}
}