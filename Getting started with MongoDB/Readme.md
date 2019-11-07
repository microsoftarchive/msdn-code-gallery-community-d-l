# Getting started with MongoDB
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- NoSql
- MongoDB
## Topics
- Data Access
- Getting Started
## Updated
- 02/01/2012
## Description

<h1>Einf&uuml;hrung</h1>
<p><a title="MongoDB" href="http://www.mongodb.org/"><span style="color:#034efa">MongoDB</span></a> ist einer der bekannteren Vertreter der NoSQL-Datenbanken. Es ist eine dokumentenorientierte Datenbank. In diesem Artikel werden wir sehen wie man MongoDB in
 Windows aufsetzt und wie man es in .NET nutzen kann.</p>
<p>Dieser Artikel&nbsp;ist ebenfalls im <a href="http://social.technet.microsoft.com/wiki/contents/articles/getting-started-with-mongodb.aspx">
TechNet Wiki</a> (Englisch und Deutsch)&nbsp;vorhanden, zusammen mit anderen n&uuml;tzlichen Artikeln.</p>
<h1>MongoDB in Windows aufsetzen</h1>
<p>Als erstes muss man die MongoDB-Dateien von folgender Seite herunterladen - <a href="http://www.mongodb.org/downloads">
<span style="color:#034efa">http://www.mongodb.org/downloads</span></a> und in einen Ordner entpackt werden. Als n&auml;chstes muss ein Ordner erstellt werden in dem MongoDB die Daten speichern kann. Dieser wird leider nicht automatisch erstellt.</p>
<p>Folgendes Statement muss in der Kommandozeile ausgef&uuml;hrt werden:</p>
<p><em>C:\&gt; mkdir \data</em><br>
<em>C:\&gt; mkdir \data\db</em></p>
<p>Als letzten Schritt muss man MongoDB nur noch laufen lassen. Dazu navigiert man zum MongoDB-Ordner und f&uuml;hrt mongod.exe aus:</p>
<p><em>C:\ cd \my_mongo_dir\bin</em><br>
<em>C:\my_mongo_dir\bin&gt; mongod</em></p>
<p>Nun sind wir startklar. F&uuml;r das starten der Administrationskonsole&nbsp;nutzen folgenden Befehl:</p>
<p><em>C:\my_mongo_dir\bin&gt; mongo</em></p>
<p>Man kann auch die web-basierte Administrationskonsole nutzen - <a href="http://localhost:28017/">
<span style="color:#034efa">http://localhost:28017/</span></a></p>
<p>Eine detaillierte Anleitung befindet sich auf der folgenden Seite - <a href="http://www.mongodb.org/display/DOCS/Quickstart&#43;Windows">
<span style="color:#034efa">http://www.mongodb.org/display/DOCS/Quickstart&#43;Windows</span></a></p>
<h1>Arbeiten mit MongoDB</h1>
<h2>Aufsetzen der Datenbank</h2>
<p>F&uuml;r dieses Beispiel wollen wir eine Datenbank nutzen, die Autoren und ihre B&uuml;cher speichert. Um die Komplexit&auml;t zu reduzieren&nbsp;bauen wir eine einfache Konsolenanwendung, aber alles was du hier lernst kannst du auch in einer ASP.NET-Applikation
 benutzen. Lass uns unsere Datenbank und unsere Collection erstellen.</p>
<p>Falls noch nicht geschehen, starte&nbsp;<em>mongo.exe</em> aus der Kommandozeile:</p>
<p><em>C:\my_mongo_dir\bin&gt; mongo</em></p>
<p>Falls du Hilfe zu irgendwelchen Kommandos brauchst, gebe einfach den folgenden Befehl ein:</p>
<p><em>&gt; help</em></p>
<p>Dadurch wird eine Liste der serverweiten Kommandos bereitgestellt. Zur Zeit wollen wir einfach nur eine Datenbank erstellen:</p>
<p><em>&gt; use tutorial</em></p>
<p>Falls die Datenbank bereits besteht wird man einfach zu dieser verbunden. Andernfalls wird diese erstellt.</p>
<p>Um mehr Datenbank-spezifische Befehle kennen zu lernen nutze den folgenden Befehl:</p>
<p><em>&gt; db.help()</em></p>
<p>Der letzen Schritt ist die Erstellung einer Collection:</p>
<p><em>&gt; db.CreateCollection(books)</em></p>
<p>Nun k&ouml;nnen wir mit dem eigentlich Code anfangen.</p>
<h2>File - New - Project</h2>
<p>Erstelle eine neue Konsolen-Applikation und gebe ihr einen beliebigen Namen. F&uuml;r die Verbindung zu MongoDB kann man mehrere APIs benutzen. Mein pers&ouml;nlicher Favorit is der offiziele Driver, welcher auf NuGet erh&auml;tlich ist -<a href="http://www.nuget.org/List/Packages/mongocsharpdriver"><span style="color:#034efa">http://www.nuget.org/List/Packages/mongocsharpdriver</span></a></p>
<h2>Zu MongoDB verbinden</h2>
<p>Als erstes stellen wir eine Verbindung zu der Datenbank, die wir vorher erstellt haben, her.</p>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">Imports MongoDB.Bson
Imports MongoDB.Driver

Module Module1

    Sub Main()
        Dim mongo As MongoServer = MongoServer.Create()
        mongo.Connect()

        Dim db = mongo.GetDatabase(&quot;tutorial&quot;)

        ...

        mongo.Disconnect()
    End Sub

End Module</pre>
<pre class="hidden">using System;
using System.Xml.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WikiExampleConsole
{
    class Program
    {
        MongoServer mongo = MongoServer.Create();
        mongo.Connect();

        var db = mongo.GetDatabase(&quot;tutorial&quot;);

        ...

        mongo.Disconnect();
    }
}</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span> MongoDB.Bson 
<span class="visualBasic__keyword">Imports</span> MongoDB.Driver 
 
<span class="visualBasic__keyword">Module</span> Module1 
 
    <span class="visualBasic__keyword">Sub</span> Main() 
        <span class="visualBasic__keyword">Dim</span> mongo <span class="visualBasic__keyword">As</span> MongoServer = MongoServer.Create() 
        mongo.Connect() 
 
        <span class="visualBasic__keyword">Dim</span> db = mongo.GetDatabase(<span class="visualBasic__string">&quot;tutorial&quot;</span>) 
 
        ... 
 
        mongo.Disconnect() 
    <span class="visualBasic__keyword">End</span> <span class="visualBasic__keyword">Sub</span> 
 
<span class="visualBasic__keyword">End</span> <span class="visualBasic__keyword">Module</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</div>
<p>Dieser Code ist gr&ouml;&szlig;tenteil selbsterk&auml;rend. Als erstes wird ein
<em>MongoServer</em>-Objekt erstellt, dass uns mit der <strong>tutorial</strong> Datenbank verbindet.</p>
<p>Am Ende sollte man nicht vergessen die Verbindung auch wieder zu schlie&szlig;en.</p>
<h2>Verbinden zur Collection</h2>
<p>Als zweites verbinden wir uns zu unserer <strong>book</strong> Collection.</p>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">...
Using mongo.RequestStart(db)
    Dim collection = db.GetCollection(Of BsonDocument)(&quot;books&quot;)
    ...
End Using
...</pre>
<pre class="hidden">...
using (mongo.RequestStart(db))
{
    var collection = db.GetCollection&lt;BsonDocument&gt;(&quot;books&quot;);
    ...
}
...</pre>
<div class="preview">
<pre class="vb">... 
<span class="visualBasic__keyword">Using</span> mongo.RequestStart(db) 
    <span class="visualBasic__keyword">Dim</span> collection = db.GetCollection(<span class="visualBasic__keyword">Of</span> BsonDocument)(<span class="visualBasic__string">&quot;books&quot;</span>) 
    ... 
<span class="visualBasic__keyword">End</span> <span class="visualBasic__keyword">Using</span> 
...</pre>
</div>
</div>
</div>
<h2 class="endscriptcode">Speichern von Daten</h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">Using mongo.RequestStart(db)
    Dim collection = db.GetCollection(Of BsonDocument)(&quot;books&quot;)

    Dim book As BsonDocument = New BsonDocument) _
        .Add(&quot;_id&quot;, BsonValue.Create(BsonType.ObjectId)) _
        .Add(&quot;author&quot;, &quot;Ernest Hemingway&quot;) _
        .Add(&quot;title&quot;, &quot;For Whom the Bell Tolls&quot;)

    collection.Insert(book)
End Using</pre>
<pre class="hidden">using (mongo.RequestStart(db))
{
    var collection = db.GetCollection&lt;BsonDocument&gt;(&quot;books&quot;);

    BsonDocument = new BsonDocument()
        .Add(&quot;_id&quot;, BsonValue.Create(BsonType.ObjectId))
        .Add(&quot;author&quot;, &quot;Ernest Hemingway&quot;)
        .Add(&quot;title&quot;, &quot;For Whom The Bell Tolls&quot;);

        collection.Insert(book);
}</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Using</span> mongo.RequestStart(db) 
    <span class="visualBasic__keyword">Dim</span> collection = db.GetCollection(<span class="visualBasic__keyword">Of</span> BsonDocument)(<span class="visualBasic__string">&quot;books&quot;</span>) 
 
    <span class="visualBasic__keyword">Dim</span> book <span class="visualBasic__keyword">As</span> BsonDocument = <span class="visualBasic__keyword">New</span> BsonDocument) _ 
        .Add(<span class="visualBasic__string">&quot;_id&quot;</span>, BsonValue.Create(BsonType.ObjectId)) _ 
        .Add(<span class="visualBasic__string">&quot;author&quot;</span>, <span class="visualBasic__string">&quot;Ernest Hemingway&quot;</span>) _ 
        .Add(<span class="visualBasic__string">&quot;title&quot;</span>, <span class="visualBasic__string">&quot;For Whom the Bell Tolls&quot;</span>) 
 
    collection.Insert(book) 
<span class="visualBasic__keyword">End</span> <span class="visualBasic__keyword">Using</span></pre>
</div>
</div>
</div>
</div>
<p>Hier erstellen wir eine neue Instanz eines BsonDocument und f&uuml;gen ihm eine ID, einen Autor und einen Buchtitel hinzu. Danach wird das Dokument in der Collection gespeichert. Unser Dokument sieht jetzt wie folgt aus:</p>
<p><em>{ &quot;_id&quot; : 7, &quot;author&quot; : &quot;Ernest Hemingway&quot;, &quot;title&quot; : &quot;For Whom the Bell Tolls&quot; }</em></p>
<h2>Datenabfrage</h2>
<p>Wir haben nun unsere Daten am richtigen Platz und es wird Zeit ein paar Daten aus der Datenbank zu kriegen. Erstmal wollen wir nur den Namen des Autors und den Titel des Buches finden.</p>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">...
Using mongo.RequestStart(db)
    Dim collection = db.GetCollection(Of BsonDocument)(&quot;books&quot;)

    Dim book As BsonDocument = New BsonDocument() _
        .Add(&quot;_id&quot;, BsonValue.Create(BsonType.ObjectId))
        .Add(&quot;author&quot;, &quot;Ernest Hemingway&quot;) _
        .Add(&quot;title&quot;, &quot;For Whom the Bell Tolls&quot;)

    collection.Insert(book)

    Dim query = New QueryDocument(&quot;author&quot;, &quot;Ernest Hemingway&quot;)

    For Each item As BsonDocument In collection.Find(query)
        Dim author As BsonElement = item.GetElement(&quot;author&quot;)
        Dim title As BsonElement = item.GetElement(&quot;title&quot;)

        Console.WriteLine(&quot;Author: {0}, Title: {1}&quot;, author.Value, title.Value)
    Next
    ...
End Using
...</pre>
<pre class="hidden">...
using (mongo.RequestStart(db))
{
    var collection = db.GetCollection&lt;BsonDocument&gt;(&quot;books&quot;);

    BsonDocument book = new BsonDocument()
        .Add(&quot;_id&quot;, BsonValue.Create(BsonType.ObjectId))
        .Add(&quot;author&quot;, &quot;Ernest Hemingway&quot;)
        .Add(&quot;title&quot;, &quot;For Whom the Bell Tolls&quot;);

    collection.Insert(book);

    var query = new QueryDocument(&quot;author&quot;, &quot;Ernest Hemingway&quot;);

    foreach (BsonDocument item in collection.Find(query))
    {
        BsonElement author = item.GetElement(&quot;author&quot;);
        BsonElement title = item.GetElement(&quot;title&quot;);

        Console.WriteLine(&quot;Author: {0}, Title: {1}&quot;, author.Value, title.Value);
    }

    ...
}
...</pre>
<div class="preview">
<pre class="vb">... 
<span class="visualBasic__keyword">Using</span> mongo.RequestStart(db) 
    <span class="visualBasic__keyword">Dim</span> collection = db.GetCollection(<span class="visualBasic__keyword">Of</span> BsonDocument)(<span class="visualBasic__string">&quot;books&quot;</span>) 
 
    <span class="visualBasic__keyword">Dim</span> book <span class="visualBasic__keyword">As</span> BsonDocument = <span class="visualBasic__keyword">New</span> BsonDocument() _ 
        .Add(<span class="visualBasic__string">&quot;_id&quot;</span>, BsonValue.Create(BsonType.ObjectId)) 
        .Add(<span class="visualBasic__string">&quot;author&quot;</span>, <span class="visualBasic__string">&quot;Ernest Hemingway&quot;</span>) _ 
        .Add(<span class="visualBasic__string">&quot;title&quot;</span>, <span class="visualBasic__string">&quot;For Whom the Bell Tolls&quot;</span>) 
 
    collection.Insert(book) 
 
    <span class="visualBasic__keyword">Dim</span> query = <span class="visualBasic__keyword">New</span> QueryDocument(<span class="visualBasic__string">&quot;author&quot;</span>, <span class="visualBasic__string">&quot;Ernest Hemingway&quot;</span>) 
 
    <span class="visualBasic__keyword">For</span> <span class="visualBasic__keyword">Each</span> item <span class="visualBasic__keyword">As</span> BsonDocument <span class="visualBasic__keyword">In</span> collection.Find(query) 
        <span class="visualBasic__keyword">Dim</span> author <span class="visualBasic__keyword">As</span> BsonElement = item.GetElement(<span class="visualBasic__string">&quot;author&quot;</span>) 
        <span class="visualBasic__keyword">Dim</span> title <span class="visualBasic__keyword">As</span> BsonElement = item.GetElement(<span class="visualBasic__string">&quot;title&quot;</span>) 
 
        Console.WriteLine(<span class="visualBasic__string">&quot;Author: {0}, Title: {1}&quot;</span>, author.Value, title.Value) 
    <span class="visualBasic__keyword">Next</span> 
    ... 
<span class="visualBasic__keyword">End</span> <span class="visualBasic__keyword">Using</span> 
...</pre>
</div>
</div>
</div>
</div>
<p>Als erste erstellen wir unsere query. Diese ist &auml;hnlich zu einer Schl&uuml;ssel-Wert-Suche. Was f&uuml;r eine &Uuml;berraschung, wir suchen nach Ernest Hemingway.<br>
Die <em>Find</em>-Methode f&uuml;hrt unsere&nbsp;Query aus und mit der&nbsp;<em>BsonDocument</em>-Instanz holen wir uns den Autor und den Buchtitel.</p>
<p>Jetzt haben wir unsere Daten. Aber was machen wir, wenn wir alle Daten haben wollen?</p>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">For Each element As BsonElement In item.Elements
    Console.WriteLine(&quot;Name: {0}, Value: {1}&quot;, element.Name, element.Value)
Next</pre>
<pre class="hidden">...
foreach (BsonElement element in item.Elements)
{
    Console.WriteLine(&quot;Name: {0}, Value: {1}&quot;, element.Name, element.Value);
}
...</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">For</span> <span class="visualBasic__keyword">Each</span> element <span class="visualBasic__keyword">As</span> BsonElement <span class="visualBasic__keyword">In</span> item.Elements 
    Console.WriteLine(<span class="visualBasic__string">&quot;Name: {0}, Value: {1}&quot;</span>, element.Name, element.Value) 
<span class="visualBasic__keyword">Next</span></pre>
</div>
</div>
</div>
</div>
<p>Damit sind wir am Ende. Ich hoffe du hattest Spa&szlig; und hast auch ein bisschen was gelernt. Unten findest du den kompletten Code</p>
<h2>Der komplette Code</h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">Imports MongoDB.Bson
Imports MongoDB.Dirver
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module Module1

    Sub Main()

        Console.WriteLine(&quot;Connect...&quot;)

        Dim mongo As MongoServer = MongoServer.Create()
        mongo.Connect()

        Console.WriteLine(&quot;Connected&quot;)
        Console.WriteLine()

        Dim db = mongo.GetDatabase(&quot;tutorial&quot;)

        Using mongo.RequestStart(db)
            Dim collection = db.GetCollection(Of BsonDocument)(&quot;books&quot;)

            Dim book As BsonDocument = New BsonDocument() _
                .Add(&quot;_id&quot;, BsonValue.Create(BsonType.ObjectId)) _
                .Add(&quot;author&quot;, &quot;Ernest Hemingway&quot;) _
                .Add(&quot;title&quot;, &quot;For Whom the Bell Tolls&quot;)

            collection.Insert(book)

            Dim query = New QueryDocument(&quot;author&quot;, &quot;Ernest Hemingway&quot;)

            For Each item As BsonDocument In collection.Find(query)
                Dim author As BsonElement = item.GetElement(&quot;author&quot;)
                Dim title = item.GetElement(&quot;title&quot;)

                Console.WriteLine(&quot;Author: {0}, Title: {1}&quot;, author.Value, title.Value)

                For Each element As BsonElement In item.Elements
                    Console.WriteLine(&quot;Name: {0}, Value: {1}&quot;, element.Name, element.Value)
                Next
            Next
        End Using

        Console.WriteLine()
        Console.Read()

        mongo.Disconnect
    End Sub

End Module</pre>
<pre class="hidden">using System;
using System.Xml.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WikiExampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(&quot;Connect...&quot;);

            MongoSever mongo = MongoServer.Create();
            mongo.Connect();

            Console.WriteLine(&quot;Connected&quot;);
            Console.WriteLine();

            var db = mongo.GetDatabase(&quot;tutorial&quot;);

            using (mongo.RequestStart(db))
            {
                var collection = db.GetCollection&lt;BsonDocument&gt;(&quot;books&quot;);

                BsonDocument book = new BsonDocument()
                    .Add(&quot;_id&quot;, BsonValue.Create(BsonType.ObjectId))
                    .Add(&quot;author&quot;, &quot;Ernest Hemingway&quot;)
                    .Add(&quot;title&quot;, &quot;For Whom the Bell Tolls&quot;);

                collection.Insert(book);

                var query = new QueryDocument(&quot;author&quot;, &quot;Ernest Hemingway&quot;);

                foreach (BsonDocument item in collection.Find(query))
                {
                    BsonElement author = item.GetElement(&quot;author&quot;);
                    BsonElement title = item.GetElement(&quot;title&quot;);

                    Console.WriteLine(&quot;Author: {0}, Title: {1}&quot;, author.Value, title.Value);
&acute;
                    foreach (BsonElement element in item.Elements)
                    {
                        Console.WriteLine(&quot;Name: {0}, Value: {1}&quot;, element.Name, element.Value);
                    }
                }
            }

            Console.WriteLine();
            Console.Read();

            mongo.Disconnect();
        }
    }
}</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span> MongoDB.Bson 
<span class="visualBasic__keyword">Imports</span> MongoDB.Dirver 
<span class="visualBasic__keyword">Imports</span> Newtonsoft.Json 
<span class="visualBasic__keyword">Imports</span> Newtonsoft.Json.Linq 
 
<span class="visualBasic__keyword">Module</span> Module1 
 
    <span class="visualBasic__keyword">Sub</span> Main() 
 
        Console.WriteLine(<span class="visualBasic__string">&quot;Connect...&quot;</span>) 
 
        <span class="visualBasic__keyword">Dim</span> mongo <span class="visualBasic__keyword">As</span> MongoServer = MongoServer.Create() 
        mongo.Connect() 
 
        Console.WriteLine(<span class="visualBasic__string">&quot;Connected&quot;</span>) 
        Console.WriteLine() 
 
        <span class="visualBasic__keyword">Dim</span> db = mongo.GetDatabase(<span class="visualBasic__string">&quot;tutorial&quot;</span>) 
 
        <span class="visualBasic__keyword">Using</span> mongo.RequestStart(db) 
            <span class="visualBasic__keyword">Dim</span> collection = db.GetCollection(<span class="visualBasic__keyword">Of</span> BsonDocument)(<span class="visualBasic__string">&quot;books&quot;</span>) 
 
            <span class="visualBasic__keyword">Dim</span> book <span class="visualBasic__keyword">As</span> BsonDocument = <span class="visualBasic__keyword">New</span> BsonDocument() _ 
                .Add(<span class="visualBasic__string">&quot;_id&quot;</span>, BsonValue.Create(BsonType.ObjectId)) _ 
                .Add(<span class="visualBasic__string">&quot;author&quot;</span>, <span class="visualBasic__string">&quot;Ernest Hemingway&quot;</span>) _ 
                .Add(<span class="visualBasic__string">&quot;title&quot;</span>, <span class="visualBasic__string">&quot;For Whom the Bell Tolls&quot;</span>) 
 
            collection.Insert(book) 
 
            <span class="visualBasic__keyword">Dim</span> query = <span class="visualBasic__keyword">New</span> QueryDocument(<span class="visualBasic__string">&quot;author&quot;</span>, <span class="visualBasic__string">&quot;Ernest Hemingway&quot;</span>) 
 
            <span class="visualBasic__keyword">For</span> <span class="visualBasic__keyword">Each</span> item <span class="visualBasic__keyword">As</span> BsonDocument <span class="visualBasic__keyword">In</span> collection.Find(query) 
                <span class="visualBasic__keyword">Dim</span> author <span class="visualBasic__keyword">As</span> BsonElement = item.GetElement(<span class="visualBasic__string">&quot;author&quot;</span>) 
                <span class="visualBasic__keyword">Dim</span> title = item.GetElement(<span class="visualBasic__string">&quot;title&quot;</span>) 
 
                Console.WriteLine(<span class="visualBasic__string">&quot;Author: {0}, Title: {1}&quot;</span>, author.Value, title.Value) 
 
                <span class="visualBasic__keyword">For</span> <span class="visualBasic__keyword">Each</span> element <span class="visualBasic__keyword">As</span> BsonElement <span class="visualBasic__keyword">In</span> item.Elements 
                    Console.WriteLine(<span class="visualBasic__string">&quot;Name: {0}, Value: {1}&quot;</span>, element.Name, element.Value) 
                <span class="visualBasic__keyword">Next</span> 
            <span class="visualBasic__keyword">Next</span> 
        <span class="visualBasic__keyword">End</span> <span class="visualBasic__keyword">Using</span> 
 
        Console.WriteLine() 
        Console.Read() 
 
        mongo.Disconnect 
    <span class="visualBasic__keyword">End</span> <span class="visualBasic__keyword">Sub</span> 
 
<span class="visualBasic__keyword">End</span> <span class="visualBasic__keyword">Module</span></pre>
</div>
</div>
</div>
<p>Der Download erh&auml;lt ein paar zus&auml;tzliche Zeilen Code, die zeigen, was man noch so mit MongoDB machen kann.</p>
<h1>Weitere Quellen</h1>
<ul>
<li><a href="http://www.mongodb.org/"><span style="color:#034efa">http://www.mongodb.org/</span></a>
</li><li><a href="http://www.mongodb.org/display/DOCS/Tutorial"><span style="color:#034efa">http://www.mongodb.org/display/DOCS/Tutorial</span></a>
</li><li><a href="http://www.mongodb.org/display/DOCS/CSharp&#43;Driver&#43;Tutorial"><span style="color:#034efa">http://www.mongodb.org/display/DOCS/CSharp&#43;Driver&#43;Tutorial</span></a>
</li><li><a href="https://github.com/samus/mongodb-csharp"><span style="color:#034efa">https://github.com/samus/mongodb-csharp</span></a>
</li><li><a title="MongoDB and C#" href="http://www.codeproject.com/KB/database/MongoDBCS.aspx"><span style="color:#034efa">MongoDB and C#</span></a>
</li><li><a title="NoSQL Databases" href="http://www.christof-strauch.de/nosqldbs.pdf"><span style="color:#034efa">NoSQL Databases</span></a>
</li></ul>
