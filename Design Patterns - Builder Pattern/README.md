# Design Patterns - Builder Pattern
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- Silverlight
- ASP.NET
- Windows Forms
- WPF
- Prism
- Unity
- Unity Blocks
## Topics
- Architecture and Design
- Design Patterns
- Builder Pattern
- Builder
## Updated
- 01/30/2014
## Description

<div><span style="color:#008000; font-size:medium">Targeted Audience:</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">1.&nbsp;.NET Architects</span><br>
<span style="font-size:small">2.&nbsp;.NET Application Designers</span><br>
<span style="font-size:small">3.&nbsp;.NET Application Developers</span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">Prerequisites:</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">1.&nbsp;.Net technologies.</span><br>
<span style="font-size:small">2.&nbsp;Basic understanding of design patterns.</span><br>
<span style="font-size:small">3.&nbsp;Basic understanding of OOPS.</span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">What is Builder Pattern?</span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="font-size:small">&bull;&nbsp;Separating the complex object construction from its representation.</span><br>
<span style="font-size:small">&bull;&nbsp;A common software creational design pattern that's used to encapsulate the construction logic for an object.</span></div>
<div><span style="font-size:small"><span style="font-size:small">&bull;&nbsp;</span>The intention is to abstract steps of construction of objects so that different implementations of these steps can construct different representations of objects.</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium"><img id="65541" src="http://i1.gallery.technet.s-msft.com/design-patterns-builder-029fb7ae/image/file/65541/1/3.png" alt="" width="712" height="222"></span></div>
<div><span style="color:#008000; font-size:medium"><span style="color:#008000; font-size:medium">Builder Pattern Principle:</span>
<div><span style="color:#000000; font-size:small">&nbsp;</span></div>
<div><span style="color:#000000; font-size:small"><span style="color:#000000; font-size:small">&bull;&nbsp;</span>Break up the construction of a complex object.
</span><br>
<span style="color:#000000; font-size:small">&bull;&nbsp;Hide the construction process from the consumer, and allow for additional representations of the product to be added with ease.
</span><br>
<span style="color:#000000; font-size:small">&bull;&nbsp;Separation of concerns and promotes application extensibility.</span></div>
<div><span style="color:#000000; font-size:medium">&nbsp;</span></div>
</span></div>
<div><span style="color:#008000; font-size:medium">Components of Builder Pattern:</span></div>
<div><span style="color:#808000; font-size:small">&nbsp;</span></div>
<div><span style="color:#808000; font-size:small">1.&nbsp;Builder:</span><br>
<span style="font-size:small">Defines a template for the steps to construct the product.
</span><br>
<span style="font-size:small">Specifies an abstract interface for creating parts of a Product object.</span></div>
<div><span style="color:#808000; font-size:small">&nbsp;</span></div>
<div><span style="color:#808000; font-size:small">2.&nbsp;Concrete Builder:</span><br>
<span style="font-size:small">Implements the builder interface and provides an interface for getting the product.
</span><span style="font-size:small">Constructs and assembles parts of the product by implementing the Builder interface defines and keeps track of the representation it creates provides an interface for retrieving the product.</span><br>
<span style="font-size:small">ConcreteBuilder builds the product's internal representation and defines the process by which it's assembled includes classes that define the constituent parts, including interfaces for assembling the parts into the final result.</span></div>
<div><span style="color:#808000; font-size:small">&nbsp;</span></div>
<div><span style="color:#808000; font-size:small">3.&nbsp;Director:</span><br>
<span style="font-size:small">Actually constructs the object through the builder interface.</span><br>
<span style="font-size:small">Constructs an object using the Builder interface.</span></div>
<div><span style="color:#808000"><span style="font-size:small">&nbsp;</span></span></div>
<div><span style="color:#808000"><span style="font-size:small">4.&nbsp;Product:</span></span><br>
<span style="font-size:small">Main object that's constructed.</span><br>
<span style="font-size:small">Represents the complex object under construction. </span>
</div>
<div><span style="font-size:small">&nbsp;</span>&nbsp;</div>
<div><span style="color:#008000; font-size:medium">Implementation&nbsp;Steps:</span></div>
<div><span style="font-size:small">&nbsp;</span>&nbsp;</div>
<div><span style="font-size:small">1. Product - The main object that will be created by the Director using Builder.</span></div>
<div><span style="font-size:small">
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Pizza&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Sauce&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Topping&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
</div>
</span><span style="font-size:small">2. Builder - Abstract interface for creating objects (the product)</span></div>
<div><span style="font-size:small">
<div class="endscriptcode">&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">abstract</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;PizzaBuilder&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;Pizza&nbsp;pizza;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Pizza&nbsp;GetPizza()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;pizza;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;CreateNewPizzaProduct()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pizza&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Pizza();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">abstract</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;BuildSauce();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">abstract</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;BuildTopping();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</span>
<div class="endscriptcode"><span style="font-size:small">3.&nbsp;Concrete Builder - Provides implementation for Builder; An object able to construct other objects.</span></div>
</div>
<div><span style="font-size:small">
<div class="endscriptcode">&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;3.1&nbsp;Constructs&nbsp;and&nbsp;assembles&nbsp;parts&nbsp;to&nbsp;build&nbsp;the&nbsp;objects&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;ChesePizzaBuilder&nbsp;:&nbsp;PizzaBuilder&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;BuildSauce()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pizza.Sauce&nbsp;=&nbsp;<span class="cs__string">&quot;Chese&quot;</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;BuildTopping()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pizza.Topping&nbsp;=&nbsp;<span class="cs__string">&quot;Green&nbsp;Pepper&quot;</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;3.2&nbsp;Constructs&nbsp;and&nbsp;assembles&nbsp;parts&nbsp;to&nbsp;build&nbsp;the&nbsp;objects&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;SpicyPizzaBuilder&nbsp;:&nbsp;PizzaBuilder&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;BuildSauce()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pizza.Sauce&nbsp;=&nbsp;<span class="cs__string">&quot;Hot&nbsp;Sauce&quot;</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;BuildTopping()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pizza.Topping&nbsp;=&nbsp;<span class="cs__string">&quot;Red&nbsp;Pepper&nbsp;,&nbsp;Jalapeno&quot;</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
</div>
</span>
<div class="endscriptcode"></div>
</div>
<div><span style="font-size:small">4. Director - Responsible for managing the correct sequence of object creation.<br>
&nbsp;&nbsp;&nbsp; Receives a Concrete Builder as a parameter and performs the necessary operations on it.</span></div>
<div><span style="font-size:small">&nbsp;</span>
<div class="endscriptcode"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">class</span>&nbsp;Cook&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;PizzaBuilder&nbsp;_pizzaBuilderObject;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Step&nbsp;1.&nbsp;Construct&nbsp;the&nbsp;builder&nbsp;object&nbsp;for&nbsp;the&nbsp;given&nbsp;concrete&nbsp;object&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;SetPizzaBuilder(PizzaBuilder&nbsp;pizzaBuilderObject)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_pizzaBuilderObject&nbsp;=&nbsp;pizzaBuilderObject;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Step&nbsp;2.&nbsp;Call&nbsp;required&nbsp;methods&nbsp;from&nbsp;the&nbsp;builder&nbsp;class&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Step&nbsp;3.&nbsp;Call&nbsp;required&nbsp;methods&nbsp;from&nbsp;the&nbsp;concrete&nbsp;builder&nbsp;classes&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ConstructPizza()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Calling&nbsp;builder&nbsp;object's&nbsp;method.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_pizzaBuilderObject.CreateNewPizzaProduct();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Calling&nbsp;Concrete&nbsp;object's&nbsp;methods.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_pizzaBuilderObject.BuildSauce();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_pizzaBuilderObject.BuildTopping();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Step&nbsp;4.&nbsp;Return&nbsp;the&nbsp;product&nbsp;after&nbsp;creating&nbsp;it&nbsp;based&nbsp;on&nbsp;the&nbsp;builder&nbsp;and&nbsp;concrete&nbsp;objects.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Pizza&nbsp;GetPizza()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_pizzaBuilderObject.GetPizza();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</span></div>
<div class="endscriptcode"><span style="font-size:small">5. Final Program</span></div>
</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">class</span>&nbsp;Program&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;1.&nbsp;Create&nbsp;an&nbsp;instance&nbsp;for&nbsp;Builder&nbsp;and&nbsp;initialize&nbsp;with&nbsp;Concrete&nbsp;builder&nbsp;-&nbsp;ChesePizzaBuilder.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PizzaBuilder&nbsp;chesePizzaBuilder&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ChesePizzaBuilder();&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;2.&nbsp;Create&nbsp;an&nbsp;instance&nbsp;for&nbsp;Director.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Cook&nbsp;cook&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Cook();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;3.&nbsp;By&nbsp;using&nbsp;Director&nbsp;instance,&nbsp;call&nbsp;the&nbsp;concrete&nbsp;object&nbsp;methods.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cook.SetPizzaBuilder(chesePizzaBuilder);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cook.ConstructPizza();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;4.&nbsp;Create&nbsp;and&nbsp;get&nbsp;the&nbsp;product,&nbsp;by&nbsp;using&nbsp;the&nbsp;Director.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Pizza&nbsp;chesePizzaProduct&nbsp;=&nbsp;cook.GetPizza();&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;5.&nbsp;Deliver&nbsp;the&nbsp;product.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Chese&nbsp;Pizza&nbsp;prepared&nbsp;by&nbsp;using&nbsp;&quot;</span>&nbsp;&#43;&nbsp;chesePizzaProduct.Topping&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;and&nbsp;&quot;</span>&nbsp;&#43;&nbsp;chesePizzaProduct.Sauce);&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;1.&nbsp;Create&nbsp;an&nbsp;instance&nbsp;for&nbsp;Builder&nbsp;and&nbsp;initialize&nbsp;with&nbsp;Concrete&nbsp;builder&nbsp;-&nbsp;SpicyPizzaBuilder.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PizzaBuilder&nbsp;spicyPizzaBuilder&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SpicyPizzaBuilder();&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;2.&nbsp;Use&nbsp;same&nbsp;Director&nbsp;instance.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;3.&nbsp;And&nbsp;pass&nbsp;the&nbsp;new&nbsp;concrete&nbsp;Builder&nbsp;instance.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cook.SetPizzaBuilder(spicyPizzaBuilder);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cook.ConstructPizza();&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;4.&nbsp;Create&nbsp;and&nbsp;get&nbsp;the&nbsp;product,&nbsp;by&nbsp;using&nbsp;the&nbsp;Director.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Pizza&nbsp;spicyPizzaProduct&nbsp;=&nbsp;cook.GetPizza();&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;5.&nbsp;Deliver&nbsp;the&nbsp;product.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Spicy&nbsp;Pizza&nbsp;prepared&nbsp;by&nbsp;using&nbsp;&quot;</span>&nbsp;&#43;&nbsp;spicyPizzaProduct.Topping&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;and&nbsp;&quot;</span>&nbsp;&#43;&nbsp;spicyPizzaProduct.Sauce);&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<div><span style="color:#008000; font-size:medium">Advantages of &nbsp;Builder Pattern:</span></div>
<div><span style="font-size:small">&nbsp;</span>&nbsp;</div>
<div><span style="font-size:small">1. This pattern is often used when the construction process of an object is complex.
</span></div>
<div><span style="font-size:small">2. It's also well suited for constructing multiple representations of the same class.</span></div>
<div><span style="font-size:small">3. </span><span style="color:#000000; font-size:small">Designers can&nbsp;implement complex object creation&nbsp;with Builder so that developers can focus on their respective business logic.</span></div>
<div><span style="font-size:small">4. Helpful in frameworks implementation like Microsoft used this pattern extensively in Enterprise library, Unity blocks,&nbsp; Prism.</span></div>
<p><span style="color:#008000; font-size:medium">Disadvantages of&nbsp; Builder Pattern:</span></p>
<p><span style="font-size:small">1. Little complex to implement and extend.</span><br>
<span style="font-size:small">2. Concrete extension may have some redundent code, if we do not follow SOLID principle.</span></p>
<p><span style="color:#008000; font-size:medium">Reference Links:</span><br>
<span style="font-size:small">1. Wiki:&nbsp; <a href="http://en.wikipedia.org/wiki/Builder_pattern">
http://en.wikipedia.org/wiki/Builder_pattern</a> </span><br>
<span style="font-size:small">2. GoF: <a href="http://www.dofactory.com/Patterns/PatternBuilder.aspx">
http://www.dofactory.com/Patterns/PatternBuilder.aspx</a></span><br>
<span style="font-size:small">3. MSDN:&nbsp; <a href="http://msdn.microsoft.com/en-us/library/ff709878.aspx">
http://msdn.microsoft.com/en-us/library/ff709878.aspx</a></span><br>
<span style="font-size:small">4. Codeplex: <a href="http://objectbuilder.codeplex.com/">
http://objectbuilder.codeplex.com/</a></span></p>
&nbsp;
<div class="endscriptcode"><span style="color:#808000; font-size:small"><span style="color:#000000; font-size:small">Thank you for reading my article. Drop all your questions/comments in QA tab give me your feedback with
<span style="color:#3366ff"><img id="67168" src="http://i1.code.msdn.s-msft.com/oops-principles-solid-7a4e69bf/image/file/67168/1/ratings.png" alt="" width="74" height="15">
<span style="color:#000000">star rating (1 Star - Very Poor, 5&nbsp;Star -&nbsp;Very Good).
</span></span></span>
<div class="endscriptcode"><span style="color:#3366ff">&nbsp;</span></div>
<div class="endscriptcode"><span style="color:#808000; font-size:small">Visit my all other articles here
<a href="http://code.msdn.microsoft.com/site/search?f%5B0%5D.Type=User&f%5B0%5D.Value=Srigopal%20Chitrapu">
http://code.msdn.microsoft.com/site/search?f%5B0%5D.Type=User&amp;f%5B0%5D.Value=Srigopal%20Chitrapu</a></span></div>
</span></div>
</div>
</div>
