# Implementing CORS support in WCF
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WCF
## Topics
- WCF Extensibility
- HTTP
- Cross-Domain
## Updated
- 05/14/2012
## Description

<div><em>This sample was introduced in a blog post about implementing <a href="http://blogs.msdn.com/b/carlosfigueira/archive/2012/05/15/implementing-cors-support-in-wcf.aspx">
CORS support in WCF</a>. To run the sample, set both projects in the solution as startup projects, then F5. You'll need to use a browser with CORS support and browse to the Mashup project root.</em></div>
<div>A pair of <a href="http://blogs.msdn.com/b/carlosfigueira/archive/2012/02/20/implementing-cors-support-in-asp-net-web-apis.aspx">
popular</a> <a href="http://blogs.msdn.com/b/carlosfigueira/archive/2012/02/21/implementing-cors-support-in-asp-net-web-apis-take-2.aspx">
posts</a> which I did a couple months back was to show how one can implement CORS (Cross-Origin Resource Sharing) in the net ASP.NET Web API framework. This week I found a couple of posts in the WCF forums from a user who wanted to make cross-domain calls to
 a WCF REST service. They were trying to use JSONP, but it didn&rsquo;t work because the request needed to be made using non-GET verbs. So let&rsquo;s try to implement the same support which we did fairly easily in the new API in WCF.</div>
<h3>Cross-domain calls</h3>
<div>A quick recap about the problem: in order to prevent malicious sites to &ldquo;stealing&rdquo; cookies from good sites and using them to get access to protected resources (imagine going to a bad site, and scripts in that site accessing your online bank
 and transferring your money elsewhere), browsers block by default AJAX requests going to domains other than the one where the HTML page originated. This is good for security purposes, but it blocks some valid scenarios, such as mash-up applications which gather
 data from many sources. There are some alternatives to make this scenario work, including
<a href="http://en.wikipedia.org/wiki/JSONP">JSONP</a> (JSON with Padding), or using a separate &ldquo;proxy&rdquo; service on the same domain as the page to route the requests to the destination server. But those approaches have limitations: JSONP only works
 for GET requests (since it uses the &lt;script&gt; element in the HTML DOM, and proxy services need to be deployed on many places and add another level of indirection (and point of failure) to the system.</div>
<div><a href="http://www.w3.org/TR/cors/">CORS</a> (Cross-Origin Resource Sharing) is a new specification which defines a set of headers which can be exchanged between the client and the server which allow the server to relax the cross-domain restrictions for
 all HTTP verbs, not only GET. Also, since CORS is implemented in the same XmlHttpRequest as &ldquo;normal&rdquo; AJAX calls (in Firefox 3.5 and above, Safari 4 and above, Chrome 3 and above, IE 10 and above &ndash; in IE8/9, the code needs to use the XDomainRequest
 object instead), the JavaScript code doesn&rsquo;t need to worry about &ldquo;un-padding&rdquo; responses or adding dummy functions. The error handling is also improved with CORS, since services can use the full range of the HTTP response codes (instead of
 200, which is required by JSONP) and the code also has access to the full response instead of only its body.</div>
<h3>CORS operation</h3>
<div>There are two types of requests in the CORS world, &ldquo;normal&rdquo; requests and
<em>preflight</em> requests. Normal requests are the requests which the page would normally make to the service, with an additional header, &ldquo;Origin&rdquo;, which indicates the origin and the service can determine whether to allow cross-domain calls from
 that origin or not (via the &ldquo;Access-Control-Allow-Origin&rdquo; response header). &ldquo;Safe&rdquo; requests (GET and HEAD) only use that extra headers to work. The browser will add the Origin header to requests going to domains other than the one where
 the page originated, and if the service doesn&rsquo;t allow that domain, then the call will fail.</div>
<div>&ldquo;Unsafe&rdquo; requests, such as POST, PUT or DELETE, can&rsquo;t be done the same way. If the service isn&rsquo;t CORS-aware, it would ignore the &ldquo;Origin&rdquo; header and accept the request, with possible side effects (e.g., deleting a record),
 and at the time the client gets the response, the browser could still &ldquo;fail&rdquo; the request, but the damage has already been done. What the browser does in those cases is to first send a
<em>preflight</em> request, which is a HTTP OPTIONS request asking for permission to send the actual request. If the service answers that request allowing the call, only then the browser will send the user request to the service.</div>
<h3>CORS in WCF</h3>
<div>So let&rsquo;s start with the &ldquo;normal&rdquo; requests. That&rsquo;s actually fairly simple to implement &ndash; we can use an inspector to check the &ldquo;Origin&rdquo; header in the requests, and if it&rsquo;s present (and we want to allow the
 cross-domain request) on the reply we add the &ldquo;Access-Control-Allow-Origin&rdquo; header. As usual, we&rsquo;ll start with a simple example, and go from there. And to make the comparison between WCF and the version I wrote in ASP.NET Web API easier,
 let&rsquo;s use the exact same contract as that one.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[ServiceContract]
public interface IValues
{
    [WebGet(UriTemplate = &quot;values&quot;, ResponseFormat = WebMessageFormat.Json)]
    List&lt;string&gt; GetValues();
    [WebGet(UriTemplate = &quot;values/{id}&quot;, ResponseFormat = WebMessageFormat.Json)]
    string GetValue(string id);
    [WebInvoke(UriTemplate = &quot;/values&quot;, Method = &quot;POST&quot;, ResponseFormat = WebMessageFormat.Json)]
    void AddValue(string value);
    [WebInvoke(UriTemplate = &quot;/values/{id}&quot;, Method = &quot;DELETE&quot;, ResponseFormat = WebMessageFormat.Json)]
    void DeleteValue(string id);
    [WebInvoke(UriTemplate = &quot;/values/{id}&quot;, Method = &quot;PUT&quot;, ResponseFormat = WebMessageFormat.Json)]
    string UpdateValue(string id, string value);
}</pre>
<div class="preview">
<pre class="csharp">[ServiceContract]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;IValues&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[WebGet(UriTemplate&nbsp;=&nbsp;<span class="cs__string">&quot;values&quot;</span>,&nbsp;ResponseFormat&nbsp;=&nbsp;WebMessageFormat.Json)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;GetValues();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[WebGet(UriTemplate&nbsp;=&nbsp;<span class="cs__string">&quot;values/{id}&quot;</span>,&nbsp;ResponseFormat&nbsp;=&nbsp;WebMessageFormat.Json)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;GetValue(<span class="cs__keyword">string</span>&nbsp;id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[WebInvoke(UriTemplate&nbsp;=&nbsp;<span class="cs__string">&quot;/values&quot;</span>,&nbsp;Method&nbsp;=&nbsp;<span class="cs__string">&quot;POST&quot;</span>,&nbsp;ResponseFormat&nbsp;=&nbsp;WebMessageFormat.Json)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;AddValue(<span class="cs__keyword">string</span>&nbsp;<span class="cs__keyword">value</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[WebInvoke(UriTemplate&nbsp;=&nbsp;<span class="cs__string">&quot;/values/{id}&quot;</span>,&nbsp;Method&nbsp;=&nbsp;<span class="cs__string">&quot;DELETE&quot;</span>,&nbsp;ResponseFormat&nbsp;=&nbsp;WebMessageFormat.Json)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;DeleteValue(<span class="cs__keyword">string</span>&nbsp;id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[WebInvoke(UriTemplate&nbsp;=&nbsp;<span class="cs__string">&quot;/values/{id}&quot;</span>,&nbsp;Method&nbsp;=&nbsp;<span class="cs__string">&quot;PUT&quot;</span>,&nbsp;ResponseFormat&nbsp;=&nbsp;WebMessageFormat.Json)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;UpdateValue(<span class="cs__keyword">string</span>&nbsp;id,&nbsp;<span class="cs__keyword">string</span>&nbsp;<span class="cs__keyword">value</span>);&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:74a7132c-298f-43a5-a916-e3096b559edd" style="margin:0px; display:inline; float:none; padding:0px">
</div>
</div>
<div>The implementation is exactly the same as in the Web API one, so I&rsquo;ll leave it out. Now, we need one &ldquo;tagging&rdquo; attribute to indicate whether an operation can be called via cross-domain calls or not. We can use an empty operation behavior
 attribute, which will be easily accessible via the operation description later.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class CorsEnabledAttribute : Attribute, IOperationBehavior
{
    public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
    {
    }
 
    public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
    {
    }
 
    public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
    {
    }
 
    public void Validate(OperationDescription operationDescription)
    {
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;CorsEnabledAttribute&nbsp;:&nbsp;Attribute,&nbsp;IOperationBehavior&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;AddBindingParameters(OperationDescription&nbsp;operationDescription,&nbsp;BindingParameterCollection&nbsp;bindingParameters)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ApplyClientBehavior(OperationDescription&nbsp;operationDescription,&nbsp;ClientOperation&nbsp;clientOperation)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ApplyDispatchBehavior(OperationDescription&nbsp;operationDescription,&nbsp;DispatchOperation&nbsp;dispatchOperation)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Validate(OperationDescription&nbsp;operationDescription)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:85b4720b-82db-4d8e-a393-1dce75bd3491" style="margin:0px; display:inline; float:none; padding:0px">
</div>
</div>
<div>And by having the CorsEnabled attribute as a <a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.description.ioperationbehavior.aspx">
IOperationBehavior</a>, it allows us to filter through he operations for which we should implement the CORS handshake in our endpoint behavior.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">class EnableCorsEndpointBehavior : IEndpointBehavior
{
    public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
    {
    }
 
    public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
    {
    }
 
    public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
    {
        List&lt;OperationDescription&gt; corsEnabledOperations = endpoint.Contract.Operations
            .Where(o =&gt; o.Behaviors.Find&lt;CorsEnabledAttribute&gt;() != null)
            .ToList();
        endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new CorsEnabledMessageInspector(corsEnabledOperations));
    }
 
    public void Validate(ServiceEndpoint endpoint)
    {
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">class</span>&nbsp;EnableCorsEndpointBehavior&nbsp;:&nbsp;IEndpointBehavior&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;AddBindingParameters(ServiceEndpoint&nbsp;endpoint,&nbsp;BindingParameterCollection&nbsp;bindingParameters)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ApplyClientBehavior(ServiceEndpoint&nbsp;endpoint,&nbsp;ClientRuntime&nbsp;clientRuntime)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ApplyDispatchBehavior(ServiceEndpoint&nbsp;endpoint,&nbsp;EndpointDispatcher&nbsp;endpointDispatcher)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;OperationDescription&gt;&nbsp;corsEnabledOperations&nbsp;=&nbsp;endpoint.Contract.Operations&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Where(o&nbsp;=&gt;&nbsp;o.Behaviors.Find&lt;CorsEnabledAttribute&gt;()&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.ToList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;endpointDispatcher.DispatchRuntime.MessageInspectors.Add(<span class="cs__keyword">new</span>&nbsp;CorsEnabledMessageInspector(corsEnabledOperations));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Validate(ServiceEndpoint&nbsp;endpoint)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:8da4e928-3d48-4c53-9ca3-daac6ff7ef4e" style="margin:0px; display:inline; float:none; padding:0px">
</div>
</div>
<div>The inspector is divided in two parts: incoming requests and the verification whether the &ldquo;Origin&rdquo; header was sent and whether the operation for where the request is directed is one of those which are CORS-enabled. The first information we
 get via the <a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.channels.httprequestmessageproperty">
HttpRequestMessageProperty</a> property. The second one we could look at the request URI, but since the inspector is executed after the operation selector, that information is already available in the message properties via the
<a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.dispatcher.webhttpdispatchoperationselector.httpoperationnamepropertyname.aspx">
WebHttpDispatchOperationSelector.HttpOperationNamePropertyName</a> key. If those two conditions are met, then we return the value of the Origin header, which will be passed to the
<a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.dispatcher.idispatchmessageinspector.beforesendreply">
BeforeSendReply</a> method of the inspector.</div>
<div>The second part, for the response, starts by looking at the correlation state returned by the
<a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.dispatcher.idispatchmessageinspector.afterreceiverequest">
AfterReceiveRequest</a> method. If there is something, then the request had an Origin header, and we&rsquo;ll use the
<a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.channels.httpresponsemessageproperty">
HttpResponseMessageProperty</a> on the reply message to send back the Access-Control-Allow-Origin method.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">class CorsEnabledMessageInspector : IDispatchMessageInspector
{
    private List&lt;string&gt; corsEnabledOperationNames;
 
    public CorsEnabledMessageInspector(List&lt;OperationDescription&gt; corsEnabledOperations)
    {
        this.corsEnabledOperationNames = corsEnabledOperations.Select(o =&gt; o.Name).ToList();
    }
 
    public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
    {
        HttpRequestMessageProperty httpProp = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];
        object operationName;
        request.Properties.TryGetValue(WebHttpDispatchOperationSelector.HttpOperationNamePropertyName, out operationName);
        if (httpProp != null &amp;&amp; operationName != null &amp;&amp; this.corsEnabledOperationNames.Contains((string)operationName))
        {
            string origin = httpProp.Headers[CorsConstants.Origin];
            if (origin != null)
            {
                return origin;
            }
        }
 
        return null;
    }
 
    public void BeforeSendReply(ref Message reply, object correlationState)
    {
        string origin = correlationState as string;
        if (origin != null)
        {
            HttpResponseMessageProperty httpProp = null;
            if (reply.Properties.ContainsKey(HttpResponseMessageProperty.Name))
            {
                httpProp = (HttpResponseMessageProperty)reply.Properties[HttpResponseMessageProperty.Name];
            }
            else
            {
                httpProp = new HttpResponseMessageProperty();
                reply.Properties.Add(HttpResponseMessageProperty.Name, httpProp);
            }
 
            httpProp.Headers.Add(CorsConstants.AccessControlAllowOrigin, origin);
        }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">class</span>&nbsp;CorsEnabledMessageInspector&nbsp;:&nbsp;IDispatchMessageInspector&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;corsEnabledOperationNames;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;CorsEnabledMessageInspector(List&lt;OperationDescription&gt;&nbsp;corsEnabledOperations)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.corsEnabledOperationNames&nbsp;=&nbsp;corsEnabledOperations.Select(o&nbsp;=&gt;&nbsp;o.Name).ToList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;AfterReceiveRequest(<span class="cs__keyword">ref</span>&nbsp;Message&nbsp;request,&nbsp;IClientChannel&nbsp;channel,&nbsp;InstanceContext&nbsp;instanceContext)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpRequestMessageProperty&nbsp;httpProp&nbsp;=&nbsp;(HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">object</span>&nbsp;operationName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.Properties.TryGetValue(WebHttpDispatchOperationSelector.HttpOperationNamePropertyName,&nbsp;<span class="cs__keyword">out</span>&nbsp;operationName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(httpProp&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;&amp;&amp;&nbsp;operationName&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;&amp;&amp;&nbsp;<span class="cs__keyword">this</span>.corsEnabledOperationNames.Contains((<span class="cs__keyword">string</span>)operationName))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;origin&nbsp;=&nbsp;httpProp.Headers[CorsConstants.Origin];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(origin&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;origin;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;BeforeSendReply(<span class="cs__keyword">ref</span>&nbsp;Message&nbsp;reply,&nbsp;<span class="cs__keyword">object</span>&nbsp;correlationState)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;origin&nbsp;=&nbsp;correlationState&nbsp;<span class="cs__keyword">as</span>&nbsp;<span class="cs__keyword">string</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(origin&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseMessageProperty&nbsp;httpProp&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(reply.Properties.ContainsKey(HttpResponseMessageProperty.Name))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpProp&nbsp;=&nbsp;(HttpResponseMessageProperty)reply.Properties[HttpResponseMessageProperty.Name];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpProp&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpResponseMessageProperty();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reply.Properties.Add(HttpResponseMessageProperty.Name,&nbsp;httpProp);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpProp.Headers.Add(CorsConstants.AccessControlAllowOrigin,&nbsp;origin);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:5281677c-ad84-4fd0-8a09-6048d71dfe88" style="margin:0px; display:inline; float:none; padding:0px">
</div>
</div>
<div>And now, by decorating the GET operations with [CorsEnabled] and adding the EnableCorsEndpointBehavior to the endpoint, those operations can now be called via cross-domain.</div>
<h3>Implementing preflight requests</h3>
<div>The first part was easy. For the second part, we need to intercept the requests with the OPTIONS verb, and return the response immediately, without going to the operation. And that&rsquo;s probably one of the biggest features missing in the WCF extensions
 &ndash; the ability to bypass the rest of the WCF pipeline at a given point. The first option is to use a custom
<a href="http://blogs.msdn.com/b/carlosfigueira/archive/2011/07/19/wcf-extensibility-channels-server-side.aspx">
reply channel</a> (which, with anything in the channel layer, is really hard to write). The other option is to use a
<a href="http://blogs.msdn.com/b/carlosfigueira/archive/2011/05/17/wcf-extensibility-ioperationinvoker.aspx">
custom operation invoker</a> which can bypass the actual operation. But the invoker by itself doesn&rsquo;t work &ndash; on the invoker call you don&rsquo;t have a reference to either the incoming request (to look for CORS headers) or the outgoing response
 (to set the response headers). Also, in order for the invoker to be called for OPTIONS requests (instead of the actual request), we needed to also have an operation selector which will map requests for OPTIONS verb to the actual operation. And it would also
 need some way to not map multiple operations which have the same URI template (but different verbs) to different operations, since OPTIONS will be the common ground there. And we&rsquo;d also need to change the formatter so that the response for the OPTIONS
 request would be an empty response instead of the actual result of the operation&hellip; In short, not simple at all.</div>
<div>Another option, which I got the idea from the post about <a href="http://zamd.net/2010/02/05/adding-dynamic-methods-to-a-wcf-service/">
how to add dynamic operations</a> from <a href="http://zamd.net/">Zufilqar&rsquo;s blog</a>, is to not change the existing operations, but instead add new ones to handle the OPTIONS requests. Since I always try to avoid channels programming whenever possible,
 this seemed the best option given all the problems of using a custom invoker for the existing operations. Those operations actually need a custom invoker, but by making them operations with untyped messages (<a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.channels.message">Message</a>
 in, <a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.channels.message">
Message</a> out), we don&rsquo;t need a custom formatter, and we can access to the HTTP headers via the message properties as well.</div>
<div>To make this scenario simpler to use, let&rsquo;s create a custom service host (and service host factory) to wrap the logic for creating the new operations. The service host will use as the contract type either the service type itself (if it is decorated
 with <a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.servicecontractattribute.aspx">
ServiceContractAttribute</a>), or one interface the service type implements (and the interface is decorated with
<a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.servicecontractattribute.aspx">
ServiceContractAttribute</a>). More complex logic can be added if needed, but for this scenario, this is enough.</div>
<div>When the service host is being opened, we&rsquo;ll add the single endpoint, find all the operations which are decorated with the CorsEnabled attribute, and for those, add a corresponding operation which deals with the preflight requests.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">class CorsEnabledServiceHostFactory : ServiceHostFactory
{
    protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
    {
        return new CorsEnabledServiceHost(serviceType, baseAddresses);
    }
}
 
class CorsEnabledServiceHost : ServiceHost
{
    Type contractType;
    public CorsEnabledServiceHost(Type serviceType, Uri[] baseAddresses)
        : base(serviceType, baseAddresses)
    {
        this.contractType = GetContractType(serviceType);
    }
 
    protected override void OnOpening()
    {
        ServiceEndpoint endpoint = this.AddServiceEndpoint(this.contractType, new WebHttpBinding(), &quot;&quot;);
 
        List&lt;OperationDescription&gt; corsEnabledOperations = endpoint.Contract.Operations
            .Where(o =&gt; o.Behaviors.Find&lt;CorsEnabledAttribute&gt;() != null)
            .ToList();
 
        AddPreflightOperationSelectors(endpoint, corsEnabledOperations);
 
        endpoint.Behaviors.Add(new WebHttpBehavior());
        endpoint.Behaviors.Add(new EnableCorsEndpointBehavior());
 
        base.OnOpening();
    }
 
    private Type GetContractType(Type serviceType)
    {
        if (HasServiceContract(serviceType))
        {
            return serviceType;
        }
 
        Type[] possibleContractTypes = serviceType.GetInterfaces()
            .Where(i =&gt; HasServiceContract(i))
            .ToArray();
 
        switch (possibleContractTypes.Length)
        {
            case 0:
                throw new InvalidOperationException(&quot;Service type &quot; &#43; serviceType.FullName &#43; &quot; does not implement any interface decorated with the ServiceContractAttribute.&quot;);
            case 1:
                return possibleContractTypes[0];
            default:
                throw new InvalidOperationException(&quot;Service type &quot; &#43; serviceType.FullName &#43; &quot; implements multiple interfaces decorated with the ServiceContractAttribute, not supported by this factory.&quot;);
        }
    }
 
    private static bool HasServiceContract(Type type)
    {
        return Attribute.IsDefined(type, typeof(ServiceContractAttribute), false);
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">class</span>&nbsp;CorsEnabledServiceHostFactory&nbsp;:&nbsp;ServiceHostFactory&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;ServiceHost&nbsp;CreateServiceHost(Type&nbsp;serviceType,&nbsp;Uri[]&nbsp;baseAddresses)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;CorsEnabledServiceHost(serviceType,&nbsp;baseAddresses);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">class</span>&nbsp;CorsEnabledServiceHost&nbsp;:&nbsp;ServiceHost&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Type&nbsp;contractType;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;CorsEnabledServiceHost(Type&nbsp;serviceType,&nbsp;Uri[]&nbsp;baseAddresses)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<span class="cs__keyword">base</span>(serviceType,&nbsp;baseAddresses)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.contractType&nbsp;=&nbsp;GetContractType(serviceType);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnOpening()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ServiceEndpoint&nbsp;endpoint&nbsp;=&nbsp;<span class="cs__keyword">this</span>.AddServiceEndpoint(<span class="cs__keyword">this</span>.contractType,&nbsp;<span class="cs__keyword">new</span>&nbsp;WebHttpBinding(),&nbsp;<span class="cs__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;OperationDescription&gt;&nbsp;corsEnabledOperations&nbsp;=&nbsp;endpoint.Contract.Operations&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Where(o&nbsp;=&gt;&nbsp;o.Behaviors.Find&lt;CorsEnabledAttribute&gt;()&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.ToList();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddPreflightOperationSelectors(endpoint,&nbsp;corsEnabledOperations);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;endpoint.Behaviors.Add(<span class="cs__keyword">new</span>&nbsp;WebHttpBehavior());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;endpoint.Behaviors.Add(<span class="cs__keyword">new</span>&nbsp;EnableCorsEndpointBehavior());&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnOpening();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Type&nbsp;GetContractType(Type&nbsp;serviceType)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(HasServiceContract(serviceType))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;serviceType;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Type[]&nbsp;possibleContractTypes&nbsp;=&nbsp;serviceType.GetInterfaces()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Where(i&nbsp;=&gt;&nbsp;HasServiceContract(i))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.ToArray();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">switch</span>&nbsp;(possibleContractTypes.Length)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__number">0</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;InvalidOperationException(<span class="cs__string">&quot;Service&nbsp;type&nbsp;&quot;</span>&nbsp;&#43;&nbsp;serviceType.FullName&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;does&nbsp;not&nbsp;implement&nbsp;any&nbsp;interface&nbsp;decorated&nbsp;with&nbsp;the&nbsp;ServiceContractAttribute.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__number">1</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;possibleContractTypes[<span class="cs__number">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">default</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;InvalidOperationException(<span class="cs__string">&quot;Service&nbsp;type&nbsp;&quot;</span>&nbsp;&#43;&nbsp;serviceType.FullName&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;implements&nbsp;multiple&nbsp;interfaces&nbsp;decorated&nbsp;with&nbsp;the&nbsp;ServiceContractAttribute,&nbsp;not&nbsp;supported&nbsp;by&nbsp;this&nbsp;factory.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;HasServiceContract(Type&nbsp;type)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Attribute.IsDefined(type,&nbsp;<span class="cs__keyword">typeof</span>(ServiceContractAttribute),&nbsp;<span class="cs__keyword">false</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:4770db1b-2004-4950-9695-51beda80784c" style="margin:0px; display:inline; float:none; padding:0px">
</div>
</div>
<div>In order to add the preflight operations, we first iterate over all the CORS-enabled operations which need to respond to the preflight request (GET requests don&rsquo;t need those). For those operations, we first get the URI template for the operation,
 and <em>normalize</em> it (remove query string parameters, and remove the parameter lists replacing them with wildcards) so that two operations with similar URI templates (e.g., [WebInvoke(Method = &ldquo;POST&rdquo;, UriTemplate = &ldquo;/products/{param1}?x={param2}&rdquo;)]
 and [WebInvoke(Method = &ldquo;DELETE&rdquo;, UriTemplate = &ldquo;/products/{id}&rdquo;)]) will have only one new operation for the &ldquo;/products/*&rdquo; URI. If there is already an OPTIONS operation for the normalized URI we&rsquo;ll add HTTP verb to
 it, otherwise we&rsquo;ll create a new operation to handle the OPTIONS request.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void AddPreflightOperations(ServiceEndpoint endpoint, List&lt;OperationDescription&gt; corsOperations)
{
    Dictionary&lt;string, PreflightOperationBehavior&gt; uriTemplates = new Dictionary&lt;string, PreflightOperationBehavior&gt;(StringComparer.OrdinalIgnoreCase);
 
    foreach (var operation in corsOperations)
    {
        if (operation.Behaviors.Find&lt;WebGetAttribute&gt;() != null || operation.IsOneWay)
        {
            // no need to add preflight operation for GET requests, no support for 1-way messages
            continue;
        }
 
        string originalUriTemplate;
        WebInvokeAttribute originalWia = operation.Behaviors.Find&lt;WebInvokeAttribute&gt;();
 
        if (originalWia != null &amp;&amp; originalWia.UriTemplate != null)
        {
            originalUriTemplate = NormalizeTemplate(originalWia.UriTemplate);
        }
        else
        {
            originalUriTemplate = operation.Name;
        }
 
        string originalMethod = originalWia != null &amp;&amp; originalWia.Method != null ? originalWia.Method : &quot;POST&quot;;
 
        if (uriTemplates.ContainsKey(originalUriTemplate))
        {
            // there is already an OPTIONS operation for this URI, we can reuse it
            PreflightOperationBehavior operationBehavior = uriTemplates[originalUriTemplate];
            operationBehavior.AddAllowedMethod(originalMethod);
        }
        else
        {
            ContractDescription contract = operation.DeclaringContract;
            OperationDescription preflightOperation;
            PreflightOperationBehavior preflightOperationBehavior;
            CreatePreflightOperation(operation, originalUriTemplate, originalMethod, contract, out preflightOperation, out preflightOperationBehavior);
            uriTemplates.Add(originalUriTemplate, preflightOperationBehavior);
 
            contract.Operations.Add(preflightOperation);
        }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;AddPreflightOperations(ServiceEndpoint&nbsp;endpoint,&nbsp;List&lt;OperationDescription&gt;&nbsp;corsOperations)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;PreflightOperationBehavior&gt;&nbsp;uriTemplates&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;PreflightOperationBehavior&gt;(StringComparer.OrdinalIgnoreCase);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;operation&nbsp;<span class="cs__keyword">in</span>&nbsp;corsOperations)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(operation.Behaviors.Find&lt;WebGetAttribute&gt;()&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;||&nbsp;operation.IsOneWay)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;no&nbsp;need&nbsp;to&nbsp;add&nbsp;preflight&nbsp;operation&nbsp;for&nbsp;GET&nbsp;requests,&nbsp;no&nbsp;support&nbsp;for&nbsp;1-way&nbsp;messages</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">continue</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;originalUriTemplate;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebInvokeAttribute&nbsp;originalWia&nbsp;=&nbsp;operation.Behaviors.Find&lt;WebInvokeAttribute&gt;();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(originalWia&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;&amp;&amp;&nbsp;originalWia.UriTemplate&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;originalUriTemplate&nbsp;=&nbsp;NormalizeTemplate(originalWia.UriTemplate);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;originalUriTemplate&nbsp;=&nbsp;operation.Name;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;originalMethod&nbsp;=&nbsp;originalWia&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;&amp;&amp;&nbsp;originalWia.Method&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;?&nbsp;originalWia.Method&nbsp;:&nbsp;<span class="cs__string">&quot;POST&quot;</span>;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(uriTemplates.ContainsKey(originalUriTemplate))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;there&nbsp;is&nbsp;already&nbsp;an&nbsp;OPTIONS&nbsp;operation&nbsp;for&nbsp;this&nbsp;URI,&nbsp;we&nbsp;can&nbsp;reuse&nbsp;it</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PreflightOperationBehavior&nbsp;operationBehavior&nbsp;=&nbsp;uriTemplates[originalUriTemplate];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;operationBehavior.AddAllowedMethod(originalMethod);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContractDescription&nbsp;contract&nbsp;=&nbsp;operation.DeclaringContract;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OperationDescription&nbsp;preflightOperation;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PreflightOperationBehavior&nbsp;preflightOperationBehavior;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreatePreflightOperation(operation,&nbsp;originalUriTemplate,&nbsp;originalMethod,&nbsp;contract,&nbsp;<span class="cs__keyword">out</span>&nbsp;preflightOperation,&nbsp;<span class="cs__keyword">out</span>&nbsp;preflightOperationBehavior);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uriTemplates.Add(originalUriTemplate,&nbsp;preflightOperationBehavior);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;contract.Operations.Add(preflightOperation);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:70b0abab-678b-4d0a-8e32-52c39c6d4d5b" style="margin:0px; display:inline; float:none; padding:0px">
</div>
</div>
<div>Creating the preflight operation means creating a new operation description for the contract, adding two messages to it: an input message with a single body part of type
<a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.channels.message">
Message</a>, and an output message with a return value of the same type. We then use the same URI template as the original operation, and add a
<a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.web.webinvokeattribute">
WebInvokeAttribute</a> to the operation. We then add a <a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.description.datacontractserializeroperationbehavior.aspx">
DataContractSerializerOperationBehavior</a> to the operation description, since it will give us a formatter which understands the (<a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.channels.message">Message</a> in,
<a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.channels.message">
Message</a> out) pattern. Finally, we add our custom operation behavior, which we&rsquo;ll use to implement the operation invoker which will ultimately deal with the preflight request.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private static void CreatePreflightOperation(OperationDescription operation, string originalUriTemplate, string originalMethod, ContractDescription contract, out OperationDescription preflightOperation, out PreflightOperationBehavior preflightOperationBehavior)
{
    preflightOperation = new OperationDescription(operation.Name &#43; CorsConstants.PreflightSuffix, contract);
    MessageDescription inputMessage = new MessageDescription(operation.Messages[0].Action &#43; CorsConstants.PreflightSuffix, MessageDirection.Input);
    inputMessage.Body.Parts.Add(new MessagePartDescription(&quot;input&quot;, contract.Namespace) { Index = 0, Type = typeof(Message) });
    preflightOperation.Messages.Add(inputMessage);
    MessageDescription outputMessage = new MessageDescription(operation.Messages[1].Action &#43; CorsConstants.PreflightSuffix, MessageDirection.Output);
    outputMessage.Body.ReturnValue = new MessagePartDescription(preflightOperation.Name &#43; &quot;Return&quot;, contract.Namespace) { Type = typeof(Message) };
    preflightOperation.Messages.Add(outputMessage);
 
    WebInvokeAttribute wia = new WebInvokeAttribute();
    wia.UriTemplate = originalUriTemplate;
    wia.Method = &quot;OPTIONS&quot;;
 
    preflightOperation.Behaviors.Add(wia);
    preflightOperation.Behaviors.Add(new DataContractSerializerOperationBehavior(preflightOperation));
    preflightOperationBehavior = new PreflightOperationBehavior(preflightOperation);
    preflightOperationBehavior.AddAllowedMethod(originalMethod);
    preflightOperation.Behaviors.Add(preflightOperationBehavior);
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;CreatePreflightOperation(OperationDescription&nbsp;operation,&nbsp;<span class="cs__keyword">string</span>&nbsp;originalUriTemplate,&nbsp;<span class="cs__keyword">string</span>&nbsp;originalMethod,&nbsp;ContractDescription&nbsp;contract,&nbsp;<span class="cs__keyword">out</span>&nbsp;OperationDescription&nbsp;preflightOperation,&nbsp;<span class="cs__keyword">out</span>&nbsp;PreflightOperationBehavior&nbsp;preflightOperationBehavior)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;preflightOperation&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OperationDescription(operation.Name&nbsp;&#43;&nbsp;CorsConstants.PreflightSuffix,&nbsp;contract);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MessageDescription&nbsp;inputMessage&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MessageDescription(operation.Messages[<span class="cs__number">0</span>].Action&nbsp;&#43;&nbsp;CorsConstants.PreflightSuffix,&nbsp;MessageDirection.Input);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;inputMessage.Body.Parts.Add(<span class="cs__keyword">new</span>&nbsp;MessagePartDescription(<span class="cs__string">&quot;input&quot;</span>,&nbsp;contract.Namespace)&nbsp;{&nbsp;Index&nbsp;=&nbsp;<span class="cs__number">0</span>,&nbsp;Type&nbsp;=&nbsp;<span class="cs__keyword">typeof</span>(Message)&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;preflightOperation.Messages.Add(inputMessage);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MessageDescription&nbsp;outputMessage&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MessageDescription(operation.Messages[<span class="cs__number">1</span>].Action&nbsp;&#43;&nbsp;CorsConstants.PreflightSuffix,&nbsp;MessageDirection.Output);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;outputMessage.Body.ReturnValue&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MessagePartDescription(preflightOperation.Name&nbsp;&#43;&nbsp;<span class="cs__string">&quot;Return&quot;</span>,&nbsp;contract.Namespace)&nbsp;{&nbsp;Type&nbsp;=&nbsp;<span class="cs__keyword">typeof</span>(Message)&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;preflightOperation.Messages.Add(outputMessage);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;WebInvokeAttribute&nbsp;wia&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;WebInvokeAttribute();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wia.UriTemplate&nbsp;=&nbsp;originalUriTemplate;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wia.Method&nbsp;=&nbsp;<span class="cs__string">&quot;OPTIONS&quot;</span>;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;preflightOperation.Behaviors.Add(wia);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;preflightOperation.Behaviors.Add(<span class="cs__keyword">new</span>&nbsp;DataContractSerializerOperationBehavior(preflightOperation));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;preflightOperationBehavior&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PreflightOperationBehavior(preflightOperation);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;preflightOperationBehavior.AddAllowedMethod(originalMethod);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;preflightOperation.Behaviors.Add(preflightOperationBehavior);&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:8c35d5f4-c30d-42b2-ae20-df840c5d067b" style="margin:0px; display:inline; float:none; padding:0px">
</div>
</div>
<div>Finally, the custom invoker. The implementation of the <a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.dispatcher.ioperationinvoker.aspx">
IOperationInvoker</a> interface is fairly trivial: allocate 1 input, only work with synchronous operations. The
<a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.dispatcher.ioperationinvoker.invoke.aspx">
Invoke</a> calls the operation to handle the preflight request: take the incoming message
<a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.channels.httprequestmessageproperty">
HttpRequestMessageProperty</a> property, get any CORS-specific headers, then create an empty reply message, and add to it a
<a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.channels.httpresponsemessageproperty">
HttpResponseMessageProperty</a> property with the appropriate headers.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">class PreflightOperationInvoker : IOperationInvoker
{
    private string replyAction;
    List&lt;string&gt; allowedHttpMethods;
    
    public PreflightOperationInvoker(string replyAction, List&lt;string&gt; allowedHttpMethods)
    {
        this.replyAction = replyAction;
        this.allowedHttpMethods = allowedHttpMethods;
    }
 
    public object[] AllocateInputs()
    {
        return new object[1];
    }
 
    public object Invoke(object instance, object[] inputs, out object[] outputs)
    {
        Message input = (Message)inputs[0];
        outputs = null;
        return HandlePreflight(input);
    }
 
    public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
    {
        throw new NotSupportedException(&quot;Only synchronous invocation&quot;);
    }
 
    public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
    {
        throw new NotSupportedException(&quot;Only synchronous invocation&quot;);
    }
 
    public bool IsSynchronous
    {
        get { return true; }
    }
 
    Message HandlePreflight(Message input)
    {
        HttpRequestMessageProperty httpRequest = (HttpRequestMessageProperty)input.Properties[HttpRequestMessageProperty.Name];
        string origin = httpRequest.Headers[CorsConstants.Origin];
        string requestMethod = httpRequest.Headers[CorsConstants.AccessControlRequestMethod];
        string requestHeaders = httpRequest.Headers[CorsConstants.AccessControlRequestHeaders];
 
        Message reply = Message.CreateMessage(MessageVersion.None, replyAction);
        HttpResponseMessageProperty httpResponse = new HttpResponseMessageProperty();
        reply.Properties.Add(HttpResponseMessageProperty.Name, httpResponse);
 
        httpResponse.SuppressEntityBody = true;
        httpResponse.StatusCode = HttpStatusCode.OK;
        if (origin != null)
        {
            httpResponse.Headers.Add(CorsConstants.AccessControlAllowOrigin, origin);
        }
 
        if (requestMethod != null &amp;&amp; this.allowedHttpMethods.Contains(requestMethod))
        {
            httpResponse.Headers.Add(CorsConstants.AccessControlAllowMethods, string.Join(&quot;,&quot;, this.allowedHttpMethods));
        }
 
        if (requestHeaders != null)
        {
            httpResponse.Headers.Add(CorsConstants.AccessControlAllowHeaders, requestHeaders);
        }
 
        return reply;
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">class</span>&nbsp;PreflightOperationInvoker&nbsp;:&nbsp;IOperationInvoker&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;replyAction;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;allowedHttpMethods;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;PreflightOperationInvoker(<span class="cs__keyword">string</span>&nbsp;replyAction,&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;allowedHttpMethods)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.replyAction&nbsp;=&nbsp;replyAction;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.allowedHttpMethods&nbsp;=&nbsp;allowedHttpMethods;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">object</span>[]&nbsp;AllocateInputs()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">object</span>[<span class="cs__number">1</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;Invoke(<span class="cs__keyword">object</span>&nbsp;instance,&nbsp;<span class="cs__keyword">object</span>[]&nbsp;inputs,&nbsp;<span class="cs__keyword">out</span>&nbsp;<span class="cs__keyword">object</span>[]&nbsp;outputs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Message&nbsp;input&nbsp;=&nbsp;(Message)inputs[<span class="cs__number">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;outputs&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;HandlePreflight(input);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IAsyncResult&nbsp;InvokeBegin(<span class="cs__keyword">object</span>&nbsp;instance,&nbsp;<span class="cs__keyword">object</span>[]&nbsp;inputs,&nbsp;AsyncCallback&nbsp;callback,&nbsp;<span class="cs__keyword">object</span>&nbsp;state)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;NotSupportedException(<span class="cs__string">&quot;Only&nbsp;synchronous&nbsp;invocation&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;InvokeEnd(<span class="cs__keyword">object</span>&nbsp;instance,&nbsp;<span class="cs__keyword">out</span>&nbsp;<span class="cs__keyword">object</span>[]&nbsp;outputs,&nbsp;IAsyncResult&nbsp;result)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;NotSupportedException(<span class="cs__string">&quot;Only&nbsp;synchronous&nbsp;invocation&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsSynchronous&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Message&nbsp;HandlePreflight(Message&nbsp;input)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpRequestMessageProperty&nbsp;httpRequest&nbsp;=&nbsp;(HttpRequestMessageProperty)input.Properties[HttpRequestMessageProperty.Name];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;origin&nbsp;=&nbsp;httpRequest.Headers[CorsConstants.Origin];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;requestMethod&nbsp;=&nbsp;httpRequest.Headers[CorsConstants.AccessControlRequestMethod];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;requestHeaders&nbsp;=&nbsp;httpRequest.Headers[CorsConstants.AccessControlRequestHeaders];&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Message&nbsp;reply&nbsp;=&nbsp;Message.CreateMessage(MessageVersion.None,&nbsp;replyAction);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseMessageProperty&nbsp;httpResponse&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpResponseMessageProperty();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reply.Properties.Add(HttpResponseMessageProperty.Name,&nbsp;httpResponse);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpResponse.SuppressEntityBody&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpResponse.StatusCode&nbsp;=&nbsp;HttpStatusCode.OK;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(origin&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpResponse.Headers.Add(CorsConstants.AccessControlAllowOrigin,&nbsp;origin);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(requestMethod&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;&amp;&amp;&nbsp;<span class="cs__keyword">this</span>.allowedHttpMethods.Contains(requestMethod))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpResponse.Headers.Add(CorsConstants.AccessControlAllowMethods,&nbsp;<span class="cs__keyword">string</span>.Join(<span class="cs__string">&quot;,&quot;</span>,&nbsp;<span class="cs__keyword">this</span>.allowedHttpMethods));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(requestHeaders&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpResponse.Headers.Add(CorsConstants.AccessControlAllowHeaders,&nbsp;requestHeaders);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;reply;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:cb56d606-7d90-4541-89e4-463714ddd180" style="margin:0px; display:inline; float:none; padding:0px">
</div>
</div>
<div>That&rsquo;s it. We can now use the custom service host factory to webhost our service, and use a page in another web service to call our service &ndash; as long as the browser supports CORS (which means the latest Chrome and Firefox, and IE 10 and above).
 You can find the code for a sample page at the sample in the code gallery.</div>
<h3>Final thoughts: WCF vs. ASP.NET Web APIs</h3>
<div>This is a good example to compare the extensibility between WCF and the ASP.NET Web APIs. The implementation of this scenario took a lot more code (and a non-negligible number of extension points) to be done in WCF compared with a similar solution in Web
 API. This is a specific HTTP scenario, and for those cases, Web APIs will likely be easier. But what I tried to do (and did) was to show that it can be done in WCF, so if you have an investment in that technology, you don&rsquo;t need to hurry to make the
 change (if you&rsquo;re starting a new project, and the focus of the project is HTTP only and the Web, then Web API would be a logical choice).</div>
