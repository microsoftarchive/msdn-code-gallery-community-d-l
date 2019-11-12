Imports MongoDB.Bson
Imports MongoDB.Driver
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module Module1

    Sub Main()

        Console.WriteLine("Connect...")

        Dim mongo As MongoServer = MongoServer.Create()
        mongo.Connect()

        Console.WriteLine("Connected")
        Console.WriteLine()

        Dim db = mongo.GetDatabase("tutorial")

        Using mongo.RequestStart(db)
            Dim collection = db.GetCollection(Of BsonDocument)("books")

            Dim book As BsonDocument = New BsonDocument() _
                                       .Add("_id", BsonValue.Create(BsonType.ObjectId)) _
                                       .Add("author", "Ernest Hemingway") _
                                       .Add("title", "For Whom the Bell Tolls")

            collection.Insert(book)

            Dim query = New QueryDocument("author", "Ernest Hemingway")

            For Each item As BsonDocument In collection.Find(query)
                Dim json As String = item.ToJson()

                Console.WriteLine(json)
                Console.WriteLine()

                Dim token As JToken = JToken.Parse(json)
                token.SelectToken("title").Replace("some other title")

                Console.WriteLine("Author: {0}, Title: {1}", token.SelectToken("author"), token.SelectToken("title"))
                Console.WriteLine()

                Dim node As XNode = JsonConvert.DeserializeXNode(json, "documents")

                Console.WriteLine("Node:")
                Console.WriteLine(node)
                Console.WriteLine()

                Dim author As BsonElement = item.GetElement("author")
                Dim title As BsonElement = item.GetElement("title")

                For Each element As BsonElement In item.Elements
                    Console.WriteLine("Name: {0}, Value: {1}", element.Name, element.Value)
                Next

                Console.WriteLine()
                Console.WriteLine("Author: {0}, Title: {1}", author.Value, title.Value)

            Next
        End Using

        Console.WriteLine()
        Console.Read()

        mongo.Disconnect()
    End Sub

End Module