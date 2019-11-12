# Introduction to IndexedDB
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- indexedDB
## Topics
- data and storage
## Updated
- 07/14/2014
## Description

<div style="text-align:justify">Today I am going to write about a storage method which is available in HTML5 as well is in Windows Store Apps which is &ldquo;IndexedDB&rdquo;. IndexedDB is an API for client-side storage where significant amounts of structured
 data can be stored. Since IndexedDB is based on indexes, it provides high performance query capability.<br>
<br>
</div>
<div style="text-align:justify">IndexedDB has two API modes which are Synchronous and Asynchronous.&nbsp;As of today,&nbsp;synchronous API of IndexedDB has not yet been implemented in any browser, so I will be using the asynchronous API here. We can get the
 asynchronous access to a database by calling open() on the indexedDB attribute of a window object. When using asynchronous API, database operations do not execute immediately; instead operations return request objects that are executed in the background. And
 again IndexedDB is an event-driven API. So we can define event handlers for returned requests and then respond to success, failure etc events of those requests.<br>
<br>
</div>
<div style="text-align:justify">Now lets dive into see how we can use IndexedDB in a HTML5 application. I am creating a simple web applictaion to store my ToDO list.<br>
<br>
</div>
<div style="text-align:justify">Before creating a IndexedDB, first thing to do is check whether the browser supports IndexedDB. As of today,
<a href="https://developer.mozilla.org/en-US/docs/IndexedDB#Browser_compatibility" target="_blank">
these</a> are the browsers and&nbsp;their&nbsp;versions that support IndexedDB.</div>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; border:1px solid silver; font-family:'Courier New',courier,monospace; padding:4px; direction:ltr; margin:20px 0px 10px; line-height:12pt; max-height:800px; width:97.5%; background-color:#f4f4f4">
<div id="codeSnippet" style="border-style:none; overflow:visible; font-size:8pt; color:black; padding:0px; direction:ltr; line-height:12pt; width:100%">
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white"><span style="color:blue">var</span> indexedDB = window.indexedDB || window.webkitIndexedDB || window.mozIndexedDB || window.msIndexedDB;<span style="font-size:8pt; line-height:12pt; background-color:#f4f4f4">&nbsp;</span></pre>
<br>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white"><span style="color:blue">if</span> (!window.indexedDB) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    alert(<span style="color:#006080">&quot;Your browser doesn't support IndexedDB&quot;</span>);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">}</pre>
</div>
</div>
<p>After checking the browser support I can create the database.</p>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; border:1px solid silver; font-family:'Courier New',courier,monospace; padding:4px; direction:ltr; margin:20px 0px 10px; line-height:12pt; max-height:800px; width:97.5%; background-color:#f4f4f4">
<div id="codeSnippet" style="border-style:none; overflow:visible; font-size:8pt; color:black; padding:0px; direction:ltr; line-height:12pt; width:100%">
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white"><span style="color:blue">function</span> initDb() {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    <span style="color:blue">var</span> request = indexedDB.open(<span style="color:#006080">&quot;ToDoDB&quot;</span>, 1);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">    request.onsuccess = <span style="color:blue">function</span> (<span style="color:blue">event</span>) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">        db = request.result;</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">        showAllItems();</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    };</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">    request.onerror = <span style="color:blue">function</span> (<span style="color:blue">event</span>) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">        console.log(<span style="color:#006080">&quot;IndexedDB error: &quot;</span> &#43; <span style="color:blue">event</span>.target.errorCode);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">    };</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    request.onupgradeneeded = <span style="color:blue">function</span> (<span style="color:blue">event</span>) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">        <span style="color:blue">var</span> objectStore = <span style="color:blue">event</span>.currentTarget.result.createObjectStore(<span style="color:#006080">&quot;todo&quot;</span>, { keyPath: <span style="color:#006080">&quot;id&quot;</span>, autoIncrement: <span style="color:blue">true</span> });</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">        objectStore.createIndex(<span style="color:#006080">&quot;priority&quot;</span>, <span style="color:#006080">&quot;priority&quot;</span>, { unique: <span style="color:blue">false</span> });</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">        objectStore.createIndex(<span style="color:#006080">&quot;tododesc&quot;</span>, <span style="color:#006080">&quot;tododesc&quot;</span>, { unique: <span style="color:blue">true</span> });</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    };</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">}</pre>
</div>
</div>
<div style="text-align:justify">Here indexedDB.open() accepts two parameters (database name and the version number) and returns a
<a href="http://msdn.microsoft.com/en-us/library/windows/apps/hh972615.aspx" target="_blank">
IDBOpenDBRequest</a>. If the database is not there, the open() method will create a new one. When the database open request succeeds the request.onsuccess event is fired. If an error occurred, request.onerror event is fired. In the case where the database&rsquo;s
 version is smaller then the provided version the request.upgradeneeded event will be fired and you will be able to change the database&rsquo;s structure in it&rsquo;s handler. In the handler we can create a
<a href="https://developer.mozilla.org/en-US/docs/IndexedDB/IDBObjectStore" target="_blank">
objectStore</a>. Object store holds records, which are key-value pairs. Records within an object store are sorted according to the keys. This sorting enables fast insertion, look-up, and ordered retrieval. Key paths and key generators are used to create the
 main index for the stored value. The key is like a primary key. Then I am creating another indexes to search my &ldquo;todo&rdquo; object store by &ldquo;priority&rdquo; and &ldquo;tododesc&rdquo;. In here I am putting a unique constraint to &quot;tododesc&quot;, assuming
 I can&rsquo;t have same&nbsp;&quot;tododesc&quot;. But same priority can be there with many &quot;tododesc&quot;.<br>
<br>
</div>
<h2><a name="Add_New_Item"></a>Add New Item</h2>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; border:1px solid silver; font-family:'Courier New',courier,monospace; padding:4px; direction:ltr; margin:20px 0px 10px; line-height:12pt; max-height:800px; width:97.5%; background-color:#f4f4f4">
<span style="font-size:8pt; line-height:12pt; color:blue">function</span><span style="font-size:8pt; line-height:12pt; background-color:white"> addNewItem() {</span><br>
<div id="codeSnippet" style="border-style:none; overflow:visible; font-size:8pt; color:black; padding:0px; direction:ltr; line-height:12pt; width:100%">
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    <span style="color:blue">var</span> priority = <span style="color:#006080">&quot;Normal&quot;</span></pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">    <span style="color:blue">var</span> tododesc = <span style="color:#006080">&quot;My Task 1&quot;</span></pre>
<br>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">    <span style="color:blue">var</span> transaction = db.transaction([<span style="color:#006080">&quot;todo&quot;</span>], <span style="color:#006080">&quot;readwrite&quot;</span>);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    <span style="color:blue">var</span> objectStore = transaction.objectStore(<span style="color:#006080">&quot;todo&quot;</span>);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">    <span style="color:blue">var</span> request = objectStore.add({ priority: priority, tododesc: tododesc });</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    request.onsuccess = <span style="color:blue">function</span> (event) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">        alert(<span style="color:#006080">&quot;added&quot;</span>);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">};</pre>
</div>
</div>
<div style="text-align:justify">Before doing anything with the database, I need to start a transaction first. Transactions come from the database object, and we have to specify which object stores I want the transaction to span. Also, I need to mention whether
 I am going to make changes to the database or I am just going to read from it. Then I am getting my particular object store from the transaction and I am adding a new object to it. Again it will return me a request which the events can be fired upon.<br>
<br>
</div>
<h2><a name="Delete_Item"></a>Delete Item</h2>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; border:1px solid silver; font-family:'Courier New',courier,monospace; padding:4px; direction:ltr; margin:20px 0px 10px; line-height:12pt; max-height:800px; width:97.5%; background-color:#f4f4f4">
<span style="font-size:8pt; line-height:12pt; color:blue">function</span><span style="font-size:8pt; line-height:12pt; background-color:white"> deleteItem(id) {</span><br>
<div id="codeSnippet" style="border-style:none; overflow:visible; font-size:8pt; color:black; padding:0px; direction:ltr; line-height:12pt; width:100%">
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    <span style="color:blue">var</span> transaction = db.transaction([<span style="color:#006080">&quot;todo&quot;</span>], <span style="color:#006080">&quot;readwrite&quot;</span>);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">    <span style="color:blue">var</span> objectStore = transaction.objectStore(<span style="color:#006080">&quot;todo&quot;</span>);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    <span style="color:blue">var</span> request = objectStore.delete(parseInt(id));</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">    request.onsuccess = <span style="color:blue">function</span> (<span style="color:blue">event</span>) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">        alert(<span style="color:#006080">&quot;deleted&quot;</span>);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">    };</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    request.onerror = <span style="color:blue">function</span> (<span style="color:blue">event</span>) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">        alert(<span style="color:#006080">&quot;error deleting record&quot;</span>);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    };</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">}</pre>
</div>
</div>
<p>Again it&rsquo;s the same as adding a new item. I am just parsing the id to delete.<br>
<br>
</p>
<h2><a name="Show_All_Items"></a>Show All Items</h2>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; border:1px solid silver; font-family:'Courier New',courier,monospace; padding:4px; direction:ltr; margin:20px 0px 10px; line-height:12pt; max-height:800px; width:97.5%; background-color:#f4f4f4">
<span style="font-size:8pt; line-height:12pt; color:blue">function</span><span style="font-size:8pt; line-height:12pt; background-color:white"> showAllItems() {</span><br>
<div id="codeSnippet" style="border-style:none; overflow:visible; font-size:8pt; color:black; padding:0px; direction:ltr; line-height:12pt; width:100%">
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    <span style="color:blue">var</span> transaction = db.transaction([<span style="color:#006080">&quot;todo&quot;</span>], <span style="color:#006080">&quot;readwrite&quot;</span>);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">    <span style="color:blue">var</span> objectStore = transaction.objectStore(<span style="color:#006080">&quot;todo&quot;</span>);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    <span style="color:blue">var</span> request = objectStore.openCursor();</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">&nbsp;</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    request.onsuccess = <span style="color:blue">function</span> (<span style="color:blue">event</span>) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">        <span style="color:blue">var</span> cursor = <span style="color:blue">event</span>.target.result;</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">        <span style="color:blue">if</span> (cursor) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">            alert(<span style="color:#006080">&quot;ID: &quot;</span> &#43; cursor.key &#43; <span style="color:#006080">&quot; \nPriority: &quot;</span> &#43; cursor.value.priority &#43; <span style="color:#006080">&quot; \nTo Do Desc: &quot;</span> &#43; cursor.value.tododesc &#43; <span style="color:#006080">&quot; &quot;</span>);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">            cursor.<span style="color:blue">continue</span>();</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">        }</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">        <span style="color:blue">else</span> {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">            <span style="color:green">// no more records</span></pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">        }</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">    };</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">}</pre>
</div>
</div>
<div style="text-align:justify">To get all the items in the object store, I can use a cursor.
<a href="https://developer.mozilla.org/en-US/docs/IndexedDB/Cursor" target="_blank">
Cursors</a> are used to iterate over multiple records in a database.&nbsp;The openCursor() function takes several arguments. First We can limit the range of items that are retrieved by using a key range object. Second, we can specify the direction that we want
 to iterate. Here it will be in the ascending order. Then to keep iterating, I am calling cursor.continue().<br>
<br>
</div>
<h2><a name="Delete_Database"></a>Delete Database</h2>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; border:1px solid silver; font-family:'Courier New',courier,monospace; padding:4px; direction:ltr; margin:20px 0px 10px; line-height:12pt; max-height:800px; width:97.5%; background-color:#f4f4f4">
<span style="font-size:8pt; line-height:12pt; color:blue">function</span><span style="font-size:8pt; line-height:12pt; background-color:white"> deleteDb() {</span><br>
<div id="codeSnippet" style="border-style:none; overflow:visible; font-size:8pt; color:black; padding:0px; direction:ltr; line-height:12pt; width:100%">
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    <span style="color:blue">var</span> iDb = indexedDB.deleteDatabase(<span style="color:#006080">&quot;ToDoDB&quot;</span>);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">    iDb.onsuccess = <span style="color:blue">function</span> (<span style="color:blue">event</span>) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">        alert(<span style="color:#006080">&quot;database deleted&quot;</span>);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">    };</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    iDb.onerror = <span style="color:blue">function</span> (<span style="color:blue">event</span>) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">        alert(<span style="color:#006080">&quot;error deleting database&quot;</span>);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    };</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">}</pre>
</div>
</div>
<div style="text-align:justify">Deleting the database is pretty much straight forward. Just call the deleteDatabase of the indexedDB of a window object. You have to provide the database name, and the database will be deleted.</div>
