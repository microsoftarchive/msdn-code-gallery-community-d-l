namespace XmlTransformation
{
	using System;

	internal class Program
	{
		private static void Main()
		{
			var person = CreatePerson();

			ShowPersonXml(person);

			Console.WriteLine();

			ShowPersonXmlTranformation(person);
		}

		private static Person CreatePerson()
		{
			return
				new Person
				{
					Name = "Bill",
					Age = 30
				};
		}

		private static void ShowPersonXml(Person person)
		{
			var xml =
				new XmlSerializerHelper()
					.Serialize(person);

			Console.WriteLine(xml);
		}

		private static void ShowPersonXmlTranformation(Person person)
		{
			var xslt = 
				new ResourcesReader()
					.Read("XmlTransformation.Res.PersonHtml.xslt");

			var xsltTransformer = new XsltTransformer(xslt);

			var transformedXml =
				xsltTransformer	
					.Transform(person);

			Console.WriteLine(transformedXml);
		}
	}
}