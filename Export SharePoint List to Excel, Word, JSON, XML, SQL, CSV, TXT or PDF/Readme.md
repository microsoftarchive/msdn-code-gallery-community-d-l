# Export SharePoint List to Excel, Word, JSON, XML, SQL, CSV, TXT or PDF
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- jQuery
- Javascript
- Sharepoint Online
- jQuery UI
- SharePoint Server 2013
- SharePoint 2016
- SharePoint Add-ins
## Topics
- SharePoint
- jQuery
- Javascript
- SharePoint 2013
- SharePoint Apps
- HTML5/JavaScript
- SharePoint 2016
## Updated
- 02/25/2016
## Description

<h1>Introduction</h1>
<p><span>Using JQuery we can export SharePoint list to&nbsp;Excel, Word, JSON, XML, SQL, CSV, TXT or PDF. Here I&rsquo;m going to&nbsp;explain step by step&nbsp;explanation to implement this same in your environment.&nbsp;</span></p>
<p><strong>Solution compatibility</strong></p>
<p>This sample is tested with SharePoint Online</p>
<p>This sample also compatible with SharePoint 2013 and SharePoint 2016</p>
<p><br>
<strong>To Modify and deploy this solution</strong></p>
<p>Open visual studio 2015</p>
<p>On the file menu select Open -&gt; Project (Ctrl &#43; Shift &#43; o)</p>
<p>In the Open Project window navigate the directory and select solution file (.sln)</p>
<p>Open solution explorer windows and select project solution and click (F4) to open project propertiesChange the site URL property on the property window&nbsp;</p>
<p>Edit the code if required and click play button or (F5) in visual studio&nbsp;</p>
<p>&nbsp;</p>
<p><strong>To add new resource file (.js or .css or Images) into project</strong></p>
<p>Select a folder from solution explorer based on your file type (Images or Scripts or Content for CSS)</p>
<p>Right click and select &ldquo;Open Folder in File Explorer&rdquo; option</p>
<p>Now paste your files into the folderAgain in the solution explorer window at the top, click &ldquo;Show All Files&rdquo; icon</p>
<p>Now you can find the file without active icon, right click and select &ldquo;Include in Project&rdquo; Option</p>
<p><strong>Permission configuration</strong></p>
<p>Double click AppManifest.xml file and select SharePoint list view permission, because here we are just going read data from a SharePoint list, I&rsquo;ve selected &ldquo;Documents&rdquo; list. List name and column name are hard coded &nbsp;in the App.js
 file,</p>
<p><em><img id="148684" src="148684-2016-02-17_23-46-38.jpg" alt="" width="813" height="618"><br>
</em></p>
<p>&nbsp;</p>
<p>*****************************************************************************************************</p>
<p>Hope you find this sample helpful, check out my other samples too.</p>
<p>Give five stars if you wish to appreciate my work.</p>
<p>Facebook page URL:&nbsp;<a title="https://www.facebook.com/sptechnet2016/" href="https://www.facebook.com/sptechnet2016/" target="_blank">https://www.facebook.com/sptechnet2016/</a></p>
<p>Blog URL:&nbsp;<a title="https://sptechnet.wordpress.com/" href="https://sptechnet.wordpress.com/" target="_blank">https://sptechnet.wordpress.com/</a></p>
<p>*****************************************************************************************************</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span><span class="hidden">js</span>
<pre class="hidden">&lt;%-- The following 4 lines are ASP.NET directives needed when using SharePoint components --%&gt;

&lt;%@ Page Inherits=&quot;Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c&quot; MasterPageFile=&quot;~masterurl/default.master&quot; Language=&quot;C#&quot; %&gt;

&lt;%@ Register TagPrefix=&quot;Utilities&quot; Namespace=&quot;Microsoft.SharePoint.Utilities&quot; Assembly=&quot;Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c&quot; %&gt;
&lt;%@ Register TagPrefix=&quot;WebPartPages&quot; Namespace=&quot;Microsoft.SharePoint.WebPartPages&quot; Assembly=&quot;Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c&quot; %&gt;
&lt;%@ Register TagPrefix=&quot;SharePoint&quot; Namespace=&quot;Microsoft.SharePoint.WebControls&quot; Assembly=&quot;Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c&quot; %&gt;

&lt;%-- The markup and script in the following Content element will be placed in the &lt;head&gt; of the page --%&gt;
&lt;asp:Content ContentPlaceHolderID=&quot;PlaceHolderAdditionalPageHead&quot; runat=&quot;server&quot;&gt;
    &lt;script type=&quot;text/javascript&quot; src=&quot;../Scripts/jquery-1.9.1.min.js&quot;&gt;&lt;/script&gt;
    &lt;SharePoint:ScriptLink Name=&quot;sp.js&quot; runat=&quot;server&quot; OnDemand=&quot;true&quot; LoadAfterUI=&quot;true&quot; Localizable=&quot;false&quot; /&gt;
    &lt;meta name=&quot;WebPartPageExpansion&quot; content=&quot;full&quot; /&gt;

    &lt;!-- Add your CSS styles to the following file --&gt;
    &lt;link rel=&quot;Stylesheet&quot; type=&quot;text/css&quot; href=&quot;../Content/App.css&quot; /&gt;
    &lt;link href=&quot;../Content/ionicons.min.css&quot; type=&quot;text/css&quot; rel=&quot;stylesheet&quot; /&gt;
    &lt;link href=&quot;../Content/bootstrap.min.css&quot; type=&quot;text/css&quot; rel=&quot;stylesheet&quot; /&gt;
    &lt;link href=&quot;../Content/jquery.dataTables.css&quot; type=&quot;text/css&quot; rel=&quot;stylesheet&quot; /&gt;
    &lt;!-- Add your JavaScript to the following file --&gt;
    &lt;!--our custom js file--&gt;
    &lt;script type=&quot;text/javascript&quot; src=&quot;../Scripts/App.js&quot;&gt;&lt;/script&gt;

    &lt;script type=&quot;text/javascript&quot; src=&quot;../Scripts/jquery-1.9.1.min.js&quot;&gt;&lt;/script&gt;
    &lt;script type=&quot;text/javascript&quot; src=&quot;../Scripts/bootstrap.min.js&quot;&gt;&lt;/script&gt;
    &lt;!--For export PDF file--&gt;
    &lt;script type=&quot;text/javascript&quot; src=&quot;../Scripts/jspdf/libs/base64.js&quot;&gt;&lt;/script&gt;
    &lt;script type=&quot;text/javascript&quot; src=&quot;../Scripts/jspdf/libs/sprintf.js&quot;&gt;&lt;/script&gt;
    &lt;script type=&quot;text/javascript&quot; src=&quot;../Scripts/jspdf/jspdf.js&quot;&gt;&lt;/script&gt;
    &lt;!--For export PNG file--&gt;
    &lt;script type=&quot;text/javascript&quot; src=&quot;../Scripts/html2canvas.js&quot;&gt;&lt;/script&gt;
    &lt;!--For export all other formats--&gt;
    &lt;script type=&quot;text/javascript&quot; src=&quot;../Scripts/tableExport.js&quot;&gt;&lt;/script&gt;
    &lt;script type=&quot;text/javascript&quot; src=&quot;../Scripts/jquery.base64.js&quot;&gt;&lt;/script&gt;
    &lt;!--For HTML Table format--&gt;
    &lt;script type=&quot;text/javascript&quot; src=&quot;../Scripts/jquery.dataTables.js&quot;&gt;&lt;/script&gt;
&lt;/asp:Content&gt;

&lt;%-- The markup in the following Content element will be placed in the TitleArea of the page --%&gt;
&lt;asp:Content ContentPlaceHolderID=&quot;PlaceHolderPageTitleInTitleArea&quot; runat=&quot;server&quot;&gt;
    Export SharePoint using JQuery
&lt;/asp:Content&gt;

&lt;%-- The markup and script in the following Content element will be placed in the &lt;body&gt; of the page --%&gt;
&lt;asp:Content ContentPlaceHolderID=&quot;PlaceHolderMain&quot; runat=&quot;server&quot;&gt;
    &lt;div class=&quot;dropdown&quot;&gt;
        &lt;button class=&quot;btn btn-warning btn-sm dropdown-toggle&quot; data-toggle=&quot;dropdown&quot;&gt;&lt;i class=&quot;fa fa-bars&quot;&gt;&lt;/i&gt;Export Table Data&lt;/button&gt;
        &lt;ul class=&quot;dropdown-menu &quot; role=&quot;menu&quot;&gt;
            &lt;li&gt;&lt;a href=&quot;#&quot; onclick=&quot;$('#SPTable').tableExport({type:'json',escape:'false'});&quot;&gt;
                &lt;img src=&quot;../Images/json.png&quot; width='24px' /&gt;
                JSON&lt;/a&gt;&lt;/li&gt;
            &lt;li&gt;&lt;a href=&quot;#&quot; onclick=&quot;$('#SPTable').tableExport({type:'json',escape:'false',ignoreColumn:'[0]'});&quot;&gt;
                &lt;img src='../Images/json.png' width='24px' /&gt;
                JSON (ignoreColumn)&lt;/a&gt;&lt;/li&gt;
            &lt;li&gt;&lt;a href=&quot;#&quot; onclick=&quot;$('#SPTable').tableExport({type:'json',escape:'true'});&quot;&gt;
                &lt;img src='../Images/json.png' width='24px' /&gt;
                JSON (with Escape)&lt;/a&gt;&lt;/li&gt;
            &lt;li class=&quot;divider&quot;&gt;&lt;/li&gt;
            &lt;li&gt;&lt;a href=&quot;#&quot; onclick=&quot;$('#SPTable').tableExport({type:'xml',escape:'false'});&quot;&gt;
                &lt;img src='../Images/xml.png' width='24px' /&gt;
                XML&lt;/a&gt;&lt;/li&gt;
            &lt;li&gt;&lt;a href=&quot;#&quot; onclick=&quot;$('#SPTable').tableExport({type:'sql'});&quot;&gt;
                &lt;img src='../Images/sql.png' width='24px' /&gt;
                SQL&lt;/a&gt;&lt;/li&gt;
            &lt;li class=&quot;divider&quot;&gt;&lt;/li&gt;
            &lt;li&gt;&lt;a href=&quot;#&quot; onclick=&quot;$('#SPTable').tableExport({type:'csv',escape:'false'});&quot;&gt;
                &lt;img src='../Images/csv.png' width='24px' /&gt;
                CSV&lt;/a&gt;&lt;/li&gt;
            &lt;li&gt;&lt;a href=&quot;#&quot; onclick=&quot;$('#SPTable').tableExport({type:'txt',escape:'false'});&quot;&gt;
                &lt;img src='../Images/txt.png' width='24px' /&gt;
                TXT&lt;/a&gt;&lt;/li&gt;
            &lt;li class=&quot;divider&quot;&gt;&lt;/li&gt;

            &lt;li&gt;&lt;a href=&quot;#&quot; onclick=&quot;$('#SPTable').tableExport({type:'excel',escape:'false'});&quot;&gt;
                &lt;img src='../Images/xls.png' width='24px' /&gt;
                XLS&lt;/a&gt;&lt;/li&gt;
            &lt;li&gt;&lt;a href=&quot;#&quot; onclick=&quot;$('#SPTable').tableExport({type:'doc',escape:'false'});&quot;&gt;
                &lt;img src='../Images/word.png' width='24px' /&gt;
                Word&lt;/a&gt;&lt;/li&gt;
            &lt;li class=&quot;divider&quot;&gt;&lt;/li&gt;
            &lt;li&gt;&lt;a href=&quot;#&quot; onclick=&quot;$('#SPTable').tableExport({type:'png',escape:'false'});&quot;&gt;
                &lt;img src='../Images/png.png' width='24px' /&gt;
                PNG&lt;/a&gt;&lt;/li&gt;
            &lt;li&gt;&lt;a href=&quot;#&quot; onclick=&quot;$('#SPTable').tableExport({type:'pdf',pdfFontSize:'7',escape:'false'});&quot;&gt;
                &lt;img src='../Images/pdf.png' width='24px' /&gt;
                PDF&lt;/a&gt;&lt;/li&gt;


        &lt;/ul&gt;
    &lt;/div&gt;
            
    &lt;div id=&quot;DivSPGrid&quot;&gt;
    &lt;/div&gt;
    &lt;script type=&quot;text/javascript&quot;&gt;
        $(document).ready(function () {
            $('.dropdown-toggle').dropdown();
        });
    &lt;/script&gt;
&lt;/asp:Content&gt;
</pre>
<pre class="hidden">'use strict';

ExecuteOrDelayUntilScriptLoaded(initializePage, &quot;sp.js&quot;);

function initializePage() {
    var context = SP.ClientContext.get_current();
    var user = context.get_web().get_currentUser();
    var hostweburl;
    var appweburl;
    var appContextSite;
    var list;
    var listItems;
    var web;


    // This code runs when the DOM is ready and creates a context object which is needed to use the SharePoint object model
    $(document).ready(function () {
        getUrl();
    });

    // This function get the URL informations
    function getUrl() {
        hostweburl = getQueryStringParameter(&quot;SPHostUrl&quot;);
        appweburl = getQueryStringParameter(&quot;SPAppWebUrl&quot;);
        hostweburl = decodeURIComponent(hostweburl);
        appweburl = decodeURIComponent(appweburl).toString().replace(&quot;#&quot;,&quot;&quot;);
        var scriptbase = hostweburl &#43; &quot;/_layouts/15/&quot;;
        $.getScript(scriptbase &#43; &quot;SP.RequestExecutor.js&quot;, execOperation);
    }

    // This function get list data from SharePoint
    function execOperation() {
        var factory = new SP.ProxyWebRequestExecutorFactory(appweburl);
        context.set_webRequestExecutorFactory(factory);
        appContextSite = new SP.AppContextSite(context, hostweburl);
        web = appContextSite.get_web();
        context.load(web);
        var camlQuery = new SP.CamlQuery();
        list = web.get_lists().getByTitle(&quot;Documents&quot;);
        listItems = list.getItems(camlQuery);
        context.load(list);
        context.load(listItems);
        context.executeQueryAsync(onGetSPListSuccess, onGetSPListFail);
    }


    // This function is executed if the above call is successful
    function onGetSPListSuccess() {
        $(&quot;#DivSPGrid&quot;).empty();
        var listInfo = '';
        var listEnumerator = listItems.getEnumerator();
        listInfo &#43;= &quot;&lt;table id='SPTable' class='display'&gt;&lt;thead&gt;&lt;tr&gt;&quot; &#43;
            &quot;&lt;th&gt;Id&lt;/th&gt;&quot; &#43;
            &quot;&lt;th&gt;Title&lt;/th&gt;&quot; &#43;
            &quot;&lt;th&gt;Colour&lt;/th&gt;&quot; &#43;
            &quot;&lt;th&gt;Modified By&lt;/th&gt;&quot; &#43;
            &quot;&lt;th&gt;Modified date&lt;/th&gt;&quot; &#43;
            &quot;&lt;/tr&gt;&lt;/thead&gt;&lt;tbody&gt;&quot;;
        while (listEnumerator.moveNext()) {
            var listItem = listEnumerator.get_current();
            listInfo &#43;= '&lt;tr&gt;&lt;td&gt;' &#43; listItem.get_item('ID') &#43; '&lt;/td&gt;'
            &#43; '&lt;td&gt;' &#43; listItem.get_item('FileLeafRef') &#43; '&lt;/td&gt;'
            &#43; '&lt;td&gt;' &#43; listItem.get_item('Colour') &#43; '&lt;/td&gt;'
            &#43; '&lt;td&gt;' &#43; listItem.get_item('Editor').get_lookupValue() &#43; '&lt;/td&gt;'
            &#43; '&lt;td&gt;' &#43; listItem.get_item('Modified').format('dd MMM yyyy, hh:ss') &#43; '&lt;/td&gt;'
            &#43; '&lt;/tr&gt;';
        }
        listInfo &#43;= '&lt;/tbody&gt;&lt;/table&gt;';
        $(&quot;#DivSPGrid&quot;).html(listInfo);
        $('#SPTable').dataTable();
    }

    // This function is executed if the above call fails
    function onGetSPListFail(sender, args) {
        alert('Failed to get list data. Error:' &#43; args.get_message());
    }

    //This function split the url and trim the App and Host web URLs
    function getQueryStringParameter(paramToRetrieve) {
        var params =
        document.URL.split(&quot;?&quot;)[1].split(&quot;&amp;&quot;);
        for (var i = 0; i &lt; params.length; i = i &#43; 1) {
            var singleParam = params[i].split(&quot;=&quot;);
            if (singleParam[0] == paramToRetrieve)
                return singleParam[1];
        }
    }
}
</pre>
<div class="preview">
<pre class="html">&lt;%--&nbsp;The&nbsp;following&nbsp;4&nbsp;lines&nbsp;are&nbsp;ASP.NET&nbsp;directives&nbsp;needed&nbsp;when&nbsp;using&nbsp;SharePoint&nbsp;components&nbsp;--%&gt;&nbsp;
&nbsp;
<span class="html__tag_start">&lt;%@&nbsp;Page</span>&nbsp;<span class="html__attr_name">Inherits</span>=<span class="html__attr_value">&quot;Microsoft.SharePoint.WebPartPages.WebPartPage,&nbsp;Microsoft.SharePoint,&nbsp;Version=15.0.0.0,&nbsp;Culture=neutral,&nbsp;PublicKeyToken=71e9bce111e9429c&quot;</span>&nbsp;<span class="html__attr_name">MasterPageFile</span>=<span class="html__attr_value">&quot;~masterurl/default.master&quot;</span>&nbsp;<span class="html__attr_name">Language</span>=<span class="html__attr_value">&quot;C#&quot;</span>&nbsp;<span class="html__tag_start">%&gt;</span>&nbsp;
&nbsp;
<span class="html__tag_start">&lt;%@&nbsp;Register</span>&nbsp;<span class="html__attr_name">TagPrefix</span>=<span class="html__attr_value">&quot;Utilities&quot;</span>&nbsp;<span class="html__attr_name">Namespace</span>=<span class="html__attr_value">&quot;Microsoft.SharePoint.Utilities&quot;</span>&nbsp;<span class="html__attr_name">Assembly</span>=<span class="html__attr_value">&quot;Microsoft.SharePoint,&nbsp;Version=15.0.0.0,&nbsp;Culture=neutral,&nbsp;PublicKeyToken=71e9bce111e9429c&quot;</span>&nbsp;<span class="html__tag_start">%&gt;</span>&nbsp;
<span class="html__tag_start">&lt;%@&nbsp;Register</span>&nbsp;<span class="html__attr_name">TagPrefix</span>=<span class="html__attr_value">&quot;WebPartPages&quot;</span>&nbsp;<span class="html__attr_name">Namespace</span>=<span class="html__attr_value">&quot;Microsoft.SharePoint.WebPartPages&quot;</span>&nbsp;<span class="html__attr_name">Assembly</span>=<span class="html__attr_value">&quot;Microsoft.SharePoint,&nbsp;Version=15.0.0.0,&nbsp;Culture=neutral,&nbsp;PublicKeyToken=71e9bce111e9429c&quot;</span>&nbsp;<span class="html__tag_start">%&gt;</span>&nbsp;
<span class="html__tag_start">&lt;%@&nbsp;Register</span>&nbsp;<span class="html__attr_name">TagPrefix</span>=<span class="html__attr_value">&quot;SharePoint&quot;</span>&nbsp;<span class="html__attr_name">Namespace</span>=<span class="html__attr_value">&quot;Microsoft.SharePoint.WebControls&quot;</span>&nbsp;<span class="html__attr_name">Assembly</span>=<span class="html__attr_value">&quot;Microsoft.SharePoint,&nbsp;Version=15.0.0.0,&nbsp;Culture=neutral,&nbsp;PublicKeyToken=71e9bce111e9429c&quot;</span>&nbsp;<span class="html__tag_start">%&gt;</span>&nbsp;
&nbsp;
&lt;%--&nbsp;The&nbsp;markup&nbsp;and&nbsp;script&nbsp;in&nbsp;the&nbsp;following&nbsp;Content&nbsp;element&nbsp;will&nbsp;be&nbsp;placed&nbsp;in&nbsp;the&nbsp;<span class="html__tag_start">&lt;head</span><span class="html__tag_start">&gt;&nbsp;</span>of&nbsp;the&nbsp;page&nbsp;--%&gt;&nbsp;
<span class="html__tag_start">&lt;asp</span>:Content&nbsp;<span class="html__attr_name">ContentPlaceHolderID</span>=<span class="html__attr_value">&quot;PlaceHolderAdditionalPageHead&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;../Scripts/jquery-1.9.1.min.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;SharePoint</span>:ScriptLink&nbsp;<span class="html__attr_name">Name</span>=<span class="html__attr_value">&quot;sp.js&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__attr_name">OnDemand</span>=<span class="html__attr_value">&quot;true&quot;</span>&nbsp;<span class="html__attr_name">LoadAfterUI</span>=<span class="html__attr_value">&quot;true&quot;</span>&nbsp;<span class="html__attr_name">Localizable</span>=<span class="html__attr_value">&quot;false&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;meta</span>&nbsp;<span class="html__attr_name">name</span>=<span class="html__attr_value">&quot;WebPartPageExpansion&quot;</span>&nbsp;<span class="html__attr_name">content</span>=<span class="html__attr_value">&quot;full&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__comment">&lt;!--&nbsp;Add&nbsp;your&nbsp;CSS&nbsp;styles&nbsp;to&nbsp;the&nbsp;following&nbsp;file&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;link</span>&nbsp;<span class="html__attr_name">rel</span>=<span class="html__attr_value">&quot;Stylesheet&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/css&quot;</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;../Content/App.css&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;link</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;../Content/ionicons.min.css&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/css&quot;</span>&nbsp;<span class="html__attr_name">rel</span>=<span class="html__attr_value">&quot;stylesheet&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;link</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;../Content/bootstrap.min.css&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/css&quot;</span>&nbsp;<span class="html__attr_name">rel</span>=<span class="html__attr_value">&quot;stylesheet&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;link</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;../Content/jquery.dataTables.css&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/css&quot;</span>&nbsp;<span class="html__attr_name">rel</span>=<span class="html__attr_value">&quot;stylesheet&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__comment">&lt;!--&nbsp;Add&nbsp;your&nbsp;JavaScript&nbsp;to&nbsp;the&nbsp;following&nbsp;file&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__comment">&lt;!--our&nbsp;custom&nbsp;js&nbsp;file--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;../Scripts/App.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;../Scripts/jquery-1.9.1.min.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;../Scripts/bootstrap.min.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__comment">&lt;!--For&nbsp;export&nbsp;PDF&nbsp;file--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;../Scripts/jspdf/libs/base64.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;../Scripts/jspdf/libs/sprintf.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;../Scripts/jspdf/jspdf.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__comment">&lt;!--For&nbsp;export&nbsp;PNG&nbsp;file--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;../Scripts/html2canvas.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__comment">&lt;!--For&nbsp;export&nbsp;all&nbsp;other&nbsp;formats--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;../Scripts/tableExport.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;../Scripts/jquery.base64.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__comment">&lt;!--For&nbsp;HTML&nbsp;Table&nbsp;format--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;../Scripts/jquery.dataTables.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/asp:Content&gt;</span>&nbsp;
&nbsp;
&lt;%--&nbsp;The&nbsp;markup&nbsp;in&nbsp;the&nbsp;following&nbsp;Content&nbsp;element&nbsp;will&nbsp;be&nbsp;placed&nbsp;in&nbsp;the&nbsp;TitleArea&nbsp;of&nbsp;the&nbsp;page&nbsp;--%&gt;&nbsp;
<span class="html__tag_start">&lt;asp</span>:Content&nbsp;<span class="html__attr_name">ContentPlaceHolderID</span>=<span class="html__attr_value">&quot;PlaceHolderPageTitleInTitleArea&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;Export&nbsp;SharePoint&nbsp;using&nbsp;JQuery&nbsp;
<span class="html__tag_end">&lt;/asp:Content&gt;</span>&nbsp;
&nbsp;
&lt;%--&nbsp;The&nbsp;markup&nbsp;and&nbsp;script&nbsp;in&nbsp;the&nbsp;following&nbsp;Content&nbsp;element&nbsp;will&nbsp;be&nbsp;placed&nbsp;in&nbsp;the&nbsp;<span class="html__tag_start">&lt;body</span><span class="html__tag_start">&gt;&nbsp;</span>of&nbsp;the&nbsp;page&nbsp;--%&gt;&nbsp;
<span class="html__tag_start">&lt;asp</span>:Content&nbsp;<span class="html__attr_name">ContentPlaceHolderID</span>=<span class="html__attr_value">&quot;PlaceHolderMain&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;dropdown&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;button</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btn&nbsp;btn-warning&nbsp;btn-sm&nbsp;dropdown-toggle&quot;</span>&nbsp;<span class="html__attr_name">data-toggle</span>=<span class="html__attr_value">&quot;dropdown&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;i</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;fa&nbsp;fa-bars&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/i&gt;</span>Export&nbsp;Table&nbsp;Data<span class="html__tag_end">&lt;/button&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;ul</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;dropdown-menu&nbsp;&quot;</span>&nbsp;<span class="html__attr_name">role</span>=<span class="html__attr_value">&quot;menu&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span><span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;#&quot;</span>&nbsp;<span class="html__attr_name">onclick</span>=<span class="html__attr_value">&quot;$('#SPTable').tableExport({type:'json',escape:'false'});&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;img</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;../Images/json.png&quot;</span>&nbsp;<span class="html__attr_name">width</span>=<span class="html__attr_value">'24px'</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;JSON<span class="html__tag_end">&lt;/a&gt;</span><span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span><span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;#&quot;</span>&nbsp;<span class="html__attr_name">onclick</span>=<span class="html__attr_value">&quot;$('#SPTable').tableExport({type:'json',escape:'false',ignoreColumn:'[0]'});&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;img</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">'../Images/json.png'</span>&nbsp;<span class="html__attr_name">width</span>=<span class="html__attr_value">'24px'</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;JSON&nbsp;(ignoreColumn)<span class="html__tag_end">&lt;/a&gt;</span><span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span><span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;#&quot;</span>&nbsp;<span class="html__attr_name">onclick</span>=<span class="html__attr_value">&quot;$('#SPTable').tableExport({type:'json',escape:'true'});&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;img</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">'../Images/json.png'</span>&nbsp;<span class="html__attr_name">width</span>=<span class="html__attr_value">'24px'</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;JSON&nbsp;(with&nbsp;Escape)<span class="html__tag_end">&lt;/a&gt;</span><span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;divider&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span><span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;#&quot;</span>&nbsp;<span class="html__attr_name">onclick</span>=<span class="html__attr_value">&quot;$('#SPTable').tableExport({type:'xml',escape:'false'});&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;img</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">'../Images/xml.png'</span>&nbsp;<span class="html__attr_name">width</span>=<span class="html__attr_value">'24px'</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XML<span class="html__tag_end">&lt;/a&gt;</span><span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span><span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;#&quot;</span>&nbsp;<span class="html__attr_name">onclick</span>=<span class="html__attr_value">&quot;$('#SPTable').tableExport({type:'sql'});&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;img</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">'../Images/sql.png'</span>&nbsp;<span class="html__attr_name">width</span>=<span class="html__attr_value">'24px'</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SQL<span class="html__tag_end">&lt;/a&gt;</span><span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;divider&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span><span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;#&quot;</span>&nbsp;<span class="html__attr_name">onclick</span>=<span class="html__attr_value">&quot;$('#SPTable').tableExport({type:'csv',escape:'false'});&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;img</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">'../Images/csv.png'</span>&nbsp;<span class="html__attr_name">width</span>=<span class="html__attr_value">'24px'</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CSV<span class="html__tag_end">&lt;/a&gt;</span><span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span><span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;#&quot;</span>&nbsp;<span class="html__attr_name">onclick</span>=<span class="html__attr_value">&quot;$('#SPTable').tableExport({type:'txt',escape:'false'});&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;img</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">'../Images/txt.png'</span>&nbsp;<span class="html__attr_name">width</span>=<span class="html__attr_value">'24px'</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TXT<span class="html__tag_end">&lt;/a&gt;</span><span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;divider&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span><span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;#&quot;</span>&nbsp;<span class="html__attr_name">onclick</span>=<span class="html__attr_value">&quot;$('#SPTable').tableExport({type:'excel',escape:'false'});&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;img</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">'../Images/xls.png'</span>&nbsp;<span class="html__attr_name">width</span>=<span class="html__attr_value">'24px'</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XLS<span class="html__tag_end">&lt;/a&gt;</span><span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span><span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;#&quot;</span>&nbsp;<span class="html__attr_name">onclick</span>=<span class="html__attr_value">&quot;$('#SPTable').tableExport({type:'doc',escape:'false'});&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;img</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">'../Images/word.png'</span>&nbsp;<span class="html__attr_name">width</span>=<span class="html__attr_value">'24px'</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Word<span class="html__tag_end">&lt;/a&gt;</span><span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;divider&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span><span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;#&quot;</span>&nbsp;<span class="html__attr_name">onclick</span>=<span class="html__attr_value">&quot;$('#SPTable').tableExport({type:'png',escape:'false'});&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;img</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">'../Images/png.png'</span>&nbsp;<span class="html__attr_name">width</span>=<span class="html__attr_value">'24px'</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PNG<span class="html__tag_end">&lt;/a&gt;</span><span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;li</span><span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;#&quot;</span>&nbsp;<span class="html__attr_name">onclick</span>=<span class="html__attr_value">&quot;$('#SPTable').tableExport({type:'pdf',pdfFontSize:'7',escape:'false'});&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;img</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">'../Images/pdf.png'</span>&nbsp;<span class="html__attr_name">width</span>=<span class="html__attr_value">'24px'</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PDF<span class="html__tag_end">&lt;/a&gt;</span><span class="html__tag_end">&lt;/li&gt;</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/ul&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;DivSPGrid&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span><span class="html__tag_start">&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(document).ready(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'.dropdown-toggle'</span>).dropdown();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/asp:Content&gt;</span>&nbsp;<span style="line-height:normal; white-space:normal">
</span></pre>
</div>
</div>
</div>
