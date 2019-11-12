# Get Currencies Actual Rate
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- WebAPI
## Topics
- Concurrency
- Currency Conversion Rates
## Updated
- 02/17/2015
## Description

<h1>Introduction</h1>
<p><em>A small sample that show how you can obtain the actual currencies rate using a free external service.</em></p>
<h1>Building the sample</h1>
<p><em>To build the sample, you have to install a NUGET package that helps you to invoke an external service and to parse the json response of this service.</em></p>
<p><em>From the Nuget Package Manager Console, you have to run the following command:</em></p>
<p><em><strong>Install-Package Microsoft.AspNet.WebApi.Client</strong></em></p>
<p><em><em>This command will add to you project all the needed references to invoke http services.</em></em></p>
<p>&quot;This package adds support for formatting and content negotiation to System.Net.Http. It includes support for JSON, XML, and form URL encoded data.&quot;</p>
<p><a href="https://www.nuget.org/packages/Microsoft.AspNet.WebApi.Client/">https://www.nuget.org/packages/Microsoft.AspNet.WebApi.Client/</a></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Often we have to convert a currency value to another currency, using the actual currencies rate.</p>
<p>There are some service that helps you to perform this operation, invoking external free or not free service, passing the right parameters for your conversion.</p>
<p><a href="http://stackoverflow.com/questions/3139879/how-do-i-get-currency-exchange-rates-via-an-api-such-as-google-finance">http://stackoverflow.com/questions/3139879/how-do-i-get-currency-exchange-rates-via-an-api-such-as-google-finance</a></p>
<p>Obviously all depends by your connectivity status, by the status of the external service, by your network traffic...</p>
<p>Too many variables for my enterprise application...</p>
<p>My idea is to cache all currency value to an internal structure (Database?, XML?, Static strutcture in memory?) so my application has to query a local table instead an external service.</p>
<p>A way may be to parse a page like this</p>
<p><a href="http://www.xe.com/it/currencytables/?from=EUR&date=2015-02-13">http://www.xe.com/it/currencytables/?from=EUR&amp;date=2015-02-13</a></p>
<p>but if you show the source of the page, you can see a link&nbsp;rather daunting</p>
<p><span><a href="http://www.xe.com/currencytables/parsehelp.htm">http://www.xe.com/currencytables/parsehelp.htm</a></span></p>
<p>Well, another way... this sample call&nbsp;asynchronously 165 times an external service and store the result into a in memory data structure.</p>
<p>The service is specified in this constant</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;SERVICEBASE&nbsp;=&nbsp;<span class="cs__string">&quot;http://rate-exchange.appspot.com&quot;</span>;</pre>
</div>
</div>
</div>
<p>and you can invoke this with a get call with the following parameters:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;SERVICEREQUEST&nbsp;=&nbsp;<span class="cs__string">&quot;currency?from={0}&amp;to=EUR&amp;q=1&quot;</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;The list of all currencies is specified in this List&lt;string&gt;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">static&nbsp;List&lt;string&gt;&nbsp;Currencies&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;List&lt;string&gt;()&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;AED&quot;</span>,&nbsp;<span class="js__string">&quot;AFN&quot;</span>,&nbsp;<span class="js__string">&quot;ALL&quot;</span>,&nbsp;<span class="js__string">&quot;AMD&quot;</span>,&nbsp;<span class="js__string">&quot;ANG&quot;</span>,&nbsp;<span class="js__string">&quot;AOA&quot;</span>,&nbsp;<span class="js__string">&quot;ARS&quot;</span>,&nbsp;<span class="js__string">&quot;AUD&quot;</span>,&nbsp;<span class="js__string">&quot;AWG&quot;</span>,&nbsp;<span class="js__string">&quot;AZN&quot;</span>,&nbsp;<span class="js__string">&quot;BAM&quot;</span>,&nbsp;<span class="js__string">&quot;BBD&quot;</span>,&nbsp;<span class="js__string">&quot;BDT&quot;</span>,&nbsp;<span class="js__string">&quot;BGN&quot;</span>,&nbsp;<span class="js__string">&quot;BHD&quot;</span>,&nbsp;<span class="js__string">&quot;BIF&quot;</span>,&nbsp;<span class="js__string">&quot;BMD&quot;</span>,&nbsp;<span class="js__string">&quot;BND&quot;</span>,&nbsp;<span class="js__string">&quot;BOB&quot;</span>,&nbsp;<span class="js__string">&quot;BRL&quot;</span>,&nbsp;<span class="js__string">&quot;BSD&quot;</span>,&nbsp;<span class="js__string">&quot;BTN&quot;</span>,&nbsp;<span class="js__string">&quot;BWP&quot;</span>,&nbsp;<span class="js__string">&quot;BYR&quot;</span>,&nbsp;<span class="js__string">&quot;BZD&quot;</span>,&nbsp;<span class="js__string">&quot;CAD&quot;</span>,&nbsp;<span class="js__string">&quot;CDF&quot;</span>,&nbsp;<span class="js__string">&quot;CHF&quot;</span>,&nbsp;<span class="js__string">&quot;CLP&quot;</span>,&nbsp;<span class="js__string">&quot;CNY&quot;</span>,&nbsp;<span class="js__string">&quot;COP&quot;</span>,&nbsp;<span class="js__string">&quot;CRC&quot;</span>,&nbsp;<span class="js__string">&quot;CUC&quot;</span>,&nbsp;<span class="js__string">&quot;CUP&quot;</span>,&nbsp;<span class="js__string">&quot;CVE&quot;</span>,&nbsp;<span class="js__string">&quot;CZK&quot;</span>,&nbsp;<span class="js__string">&quot;DJF&quot;</span>,&nbsp;<span class="js__string">&quot;DKK&quot;</span>,&nbsp;<span class="js__string">&quot;DOP&quot;</span>,&nbsp;<span class="js__string">&quot;DZD&quot;</span>,&nbsp;<span class="js__string">&quot;EGP&quot;</span>,&nbsp;<span class="js__string">&quot;ERN&quot;</span>,&nbsp;<span class="js__string">&quot;ETB&quot;</span>,&nbsp;<span class="js__string">&quot;EUR&quot;</span>,&nbsp;<span class="js__string">&quot;FJD&quot;</span>,&nbsp;<span class="js__string">&quot;FKP&quot;</span>,&nbsp;<span class="js__string">&quot;GBP&quot;</span>,&nbsp;<span class="js__string">&quot;GEL&quot;</span>,&nbsp;<span class="js__string">&quot;GGP&quot;</span>,&nbsp;<span class="js__string">&quot;GHS&quot;</span>,&nbsp;<span class="js__string">&quot;GIP&quot;</span>,&nbsp;<span class="js__string">&quot;GMD&quot;</span>,&nbsp;<span class="js__string">&quot;GNF&quot;</span>,&nbsp;<span class="js__string">&quot;GTQ&quot;</span>,&nbsp;<span class="js__string">&quot;GYD&quot;</span>,&nbsp;<span class="js__string">&quot;HKD&quot;</span>,&nbsp;<span class="js__string">&quot;HNL&quot;</span>,&nbsp;<span class="js__string">&quot;HRK&quot;</span>,&nbsp;<span class="js__string">&quot;HTG&quot;</span>,&nbsp;<span class="js__string">&quot;HUF&quot;</span>,&nbsp;<span class="js__string">&quot;IDR&quot;</span>,&nbsp;<span class="js__string">&quot;ILS&quot;</span>,&nbsp;<span class="js__string">&quot;IMP&quot;</span>,&nbsp;<span class="js__string">&quot;INR&quot;</span>,&nbsp;<span class="js__string">&quot;IQD&quot;</span>,&nbsp;<span class="js__string">&quot;IRR&quot;</span>,&nbsp;<span class="js__string">&quot;ISK&quot;</span>,&nbsp;<span class="js__string">&quot;JEP&quot;</span>,&nbsp;<span class="js__string">&quot;JMD&quot;</span>,&nbsp;<span class="js__string">&quot;JOD&quot;</span>,&nbsp;<span class="js__string">&quot;JPY&quot;</span>,&nbsp;<span class="js__string">&quot;KES&quot;</span>,&nbsp;<span class="js__string">&quot;KGS&quot;</span>,&nbsp;<span class="js__string">&quot;KHR&quot;</span>,&nbsp;<span class="js__string">&quot;KMF&quot;</span>,&nbsp;<span class="js__string">&quot;KPW&quot;</span>,&nbsp;<span class="js__string">&quot;KRW&quot;</span>,&nbsp;<span class="js__string">&quot;KWD&quot;</span>,&nbsp;<span class="js__string">&quot;KYD&quot;</span>,&nbsp;<span class="js__string">&quot;KZT&quot;</span>,&nbsp;<span class="js__string">&quot;LAK&quot;</span>,&nbsp;<span class="js__string">&quot;LBP&quot;</span>,&nbsp;<span class="js__string">&quot;LKR&quot;</span>,&nbsp;<span class="js__string">&quot;LRD&quot;</span>,&nbsp;<span class="js__string">&quot;LSL&quot;</span>,&nbsp;<span class="js__string">&quot;LYD&quot;</span>,&nbsp;<span class="js__string">&quot;MAD&quot;</span>,&nbsp;<span class="js__string">&quot;MDL&quot;</span>,&nbsp;<span class="js__string">&quot;MGA&quot;</span>,&nbsp;<span class="js__string">&quot;MKD&quot;</span>,&nbsp;<span class="js__string">&quot;MMK&quot;</span>,&nbsp;<span class="js__string">&quot;MNT&quot;</span>,&nbsp;<span class="js__string">&quot;MOP&quot;</span>,&nbsp;<span class="js__string">&quot;MRO&quot;</span>,&nbsp;<span class="js__string">&quot;MUR&quot;</span>,&nbsp;<span class="js__string">&quot;MVR&quot;</span>,&nbsp;<span class="js__string">&quot;MWK&quot;</span>,&nbsp;<span class="js__string">&quot;MXN&quot;</span>,&nbsp;<span class="js__string">&quot;MYR&quot;</span>,&nbsp;<span class="js__string">&quot;MZN&quot;</span>,&nbsp;<span class="js__string">&quot;NAD&quot;</span>,&nbsp;<span class="js__string">&quot;NGN&quot;</span>,&nbsp;<span class="js__string">&quot;NIO&quot;</span>,&nbsp;<span class="js__string">&quot;NOK&quot;</span>,&nbsp;<span class="js__string">&quot;NPR&quot;</span>,&nbsp;<span class="js__string">&quot;NZD&quot;</span>,&nbsp;<span class="js__string">&quot;OMR&quot;</span>,&nbsp;<span class="js__string">&quot;PAB&quot;</span>,&nbsp;<span class="js__string">&quot;PEN&quot;</span>,&nbsp;<span class="js__string">&quot;PGK&quot;</span>,&nbsp;<span class="js__string">&quot;PHP&quot;</span>,&nbsp;<span class="js__string">&quot;PKR&quot;</span>,&nbsp;<span class="js__string">&quot;PLN&quot;</span>,&nbsp;<span class="js__string">&quot;PYG&quot;</span>,&nbsp;<span class="js__string">&quot;QAR&quot;</span>,&nbsp;<span class="js__string">&quot;RON&quot;</span>,&nbsp;<span class="js__string">&quot;RSD&quot;</span>,&nbsp;<span class="js__string">&quot;RUB&quot;</span>,&nbsp;<span class="js__string">&quot;RWF&quot;</span>,&nbsp;<span class="js__string">&quot;SAR&quot;</span>,&nbsp;<span class="js__string">&quot;SBD&quot;</span>,&nbsp;<span class="js__string">&quot;SCR&quot;</span>,&nbsp;<span class="js__string">&quot;SDG&quot;</span>,&nbsp;<span class="js__string">&quot;SEK&quot;</span>,&nbsp;<span class="js__string">&quot;SGD&quot;</span>,&nbsp;<span class="js__string">&quot;SHP&quot;</span>,&nbsp;<span class="js__string">&quot;SLL&quot;</span>,&nbsp;<span class="js__string">&quot;SOS&quot;</span>,&nbsp;<span class="js__string">&quot;SPL&quot;</span>,&nbsp;<span class="js__string">&quot;SRD&quot;</span>,&nbsp;<span class="js__string">&quot;STD&quot;</span>,&nbsp;<span class="js__string">&quot;SVC&quot;</span>,&nbsp;<span class="js__string">&quot;SYP&quot;</span>,&nbsp;<span class="js__string">&quot;SZL&quot;</span>,&nbsp;<span class="js__string">&quot;THB&quot;</span>,&nbsp;<span class="js__string">&quot;TJS&quot;</span>,&nbsp;<span class="js__string">&quot;TMT&quot;</span>,&nbsp;<span class="js__string">&quot;TND&quot;</span>,&nbsp;<span class="js__string">&quot;TOP&quot;</span>,&nbsp;<span class="js__string">&quot;TRY&quot;</span>,&nbsp;<span class="js__string">&quot;TTD&quot;</span>,&nbsp;<span class="js__string">&quot;TVD&quot;</span>,&nbsp;<span class="js__string">&quot;TWD&quot;</span>,&nbsp;<span class="js__string">&quot;TZS&quot;</span>,&nbsp;<span class="js__string">&quot;UAH&quot;</span>,&nbsp;<span class="js__string">&quot;UGX&quot;</span>,&nbsp;<span class="js__string">&quot;USD&quot;</span>,&nbsp;<span class="js__string">&quot;UYU&quot;</span>,&nbsp;<span class="js__string">&quot;UZS&quot;</span>,&nbsp;<span class="js__string">&quot;VEF&quot;</span>,&nbsp;<span class="js__string">&quot;VND&quot;</span>,&nbsp;<span class="js__string">&quot;VUV&quot;</span>,&nbsp;<span class="js__string">&quot;WST&quot;</span>,&nbsp;<span class="js__string">&quot;XAF&quot;</span>,&nbsp;<span class="js__string">&quot;XAG&quot;</span>,&nbsp;<span class="js__string">&quot;XAU&quot;</span>,&nbsp;<span class="js__string">&quot;XCD&quot;</span>,&nbsp;<span class="js__string">&quot;XDR&quot;</span>,&nbsp;<span class="js__string">&quot;XOF&quot;</span>,&nbsp;<span class="js__string">&quot;XPD&quot;</span>,&nbsp;<span class="js__string">&quot;XPF&quot;</span>,&nbsp;<span class="js__string">&quot;XPT&quot;</span>,&nbsp;<span class="js__string">&quot;YER&quot;</span>,&nbsp;<span class="js__string">&quot;ZAR&quot;</span>,&nbsp;<span class="js__string">&quot;ZWD&quot;</span>&nbsp;<span class="js__brace">}</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">You can change this option in any time in your code.</div>
<div class="endscriptcode">The service call will return to you a JSON string like this:</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="js"><span class="js__brace">{</span><span class="js__string">&quot;to&quot;</span>:&nbsp;<span class="js__string">&quot;EUR&quot;</span>,&nbsp;<span class="js__string">&quot;rate&quot;</span>:&nbsp;<span class="js__num">0.87792700000000001</span>,&nbsp;<span class="js__string">&quot;from&quot;</span>:&nbsp;<span class="js__string">&quot;USD&quot;</span>,&nbsp;<span class="js__string">&quot;v&quot;</span>:&nbsp;<span class="js__num">0.87792700000000001</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;And I'll parse it into the following class:</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">&nbsp;public&nbsp;class&nbsp;Currency&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//{&quot;to&quot;:&nbsp;&quot;EUR&quot;,&nbsp;&quot;rate&quot;:&nbsp;0.87792700000000001,&nbsp;&quot;from&quot;:&nbsp;&quot;USD&quot;,&nbsp;&quot;v&quot;:&nbsp;0.87792700000000001}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;to&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;decimal&nbsp;rate&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;&nbsp;from&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;decimal&nbsp;v&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;override&nbsp;string&nbsp;ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;v.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Then, the result of all the call will be stored on a List of Currency.</div>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<ul>
</ul>
<h1>More Information</h1>
<p><em>For more information about my experience see...</em></p>
<p><em><a href="http://zsvipullo.blogspot.it/">http://zsvipullo.blogspot.it/</a></em></p>
<p><em>Thanks to my&nbsp;colleague Davide Funaro for the support to tame asynchronous calls :)</em></p>
