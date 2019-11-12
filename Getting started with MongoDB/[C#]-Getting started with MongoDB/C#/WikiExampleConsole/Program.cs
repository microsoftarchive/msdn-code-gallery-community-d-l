using System;
using System.Xml.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WikiExampleConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Connect...");

			MongoServer mongo = MongoServer.Create();
			mongo.Connect();

			Console.WriteLine("Connected"); Console.WriteLine();

			var db = mongo.GetDatabase("tutorial");

			using (mongo.RequestStart(db))
			{
				var collection = db.GetCollection<BsonDocument>("books");

				BsonDocument book = new BsonDocument()
					.Add("_id", BsonValue.Create(BsonType.ObjectId))
					.Add("author", "Ernest Hemingway")
					.Add("title", "For Whom the Bell Tolls");

				collection.Insert(book);

				var query = new QueryDocument("author", "Ernest Hemingway");

				foreach (BsonDocument item in collection.Find(query))
				{
					string json = item.ToJson();

					Console.WriteLine(json);
					Console.WriteLine();

					JToken token = JToken.Parse(json);
					token.SelectToken("title").Replace("some other title");

					Console.WriteLine("Author: {0}, Title: {1}", token.SelectToken("author"), token.SelectToken("title"));
					Console.WriteLine();

					XNode node = JsonConvert.DeserializeXNode(json, "documents");

					Console.WriteLine("Node:");
					Console.WriteLine(node);
					Console.WriteLine();

					BsonElement author = item.GetElement("author");
					BsonElement title = item.GetElement("title");

					foreach (BsonElement element in item.Elements)
					{
						Console.WriteLine("Name: {0}, Value: {1}", element.Name, element.Value);
					}

					Console.WriteLine();
					Console.WriteLine("Author: {0}, Title: {1}", author.Value, title.Value);
				}
			}

			Console.WriteLine();
			Console.Read();

			mongo.Disconnect();
		}
	}
}