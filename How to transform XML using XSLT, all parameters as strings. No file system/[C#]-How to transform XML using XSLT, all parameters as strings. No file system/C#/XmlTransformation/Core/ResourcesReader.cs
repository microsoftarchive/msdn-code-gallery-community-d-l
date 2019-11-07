namespace XmlTransformation
{
	using System;
	using System.IO;
	using System.Reflection;

	public class ResourcesReader
	{
		/// <exception cref="ArgumentException">Cannot find a resources with the specified name.</exception>
		public string Read(string name)
		{
			using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
			{
				if (stream == null)
				{
					throw new ArgumentException("Cannot find a resources with the specified name.");
				}

				using (var reader = new StreamReader(stream))
				{
					return reader.ReadToEnd();
				}
			}
		}
	}
}