# Draw ASP.Net Chart Using HTML5 and jQuery
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- ASP.NET
- jQuery
- Chart
- HTML5
- HTML5/JavaScript
## Topics
- ASP.NET
- jQuery
- HTML5
- Charts
- HTML5/JavaScript
## Updated
- 08/18/2015
## Description

<h1>Introduction</h1>
<div>
<div style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
&nbsp;</div>
<em><img id="141398" src="141398-1.png" alt="" width="619" height="310"></em></div>
<div style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
In this article we will learn to draw an ASP.Net chart like Line Chart,Bar chart,Pie chart,Bubble chart,Donut Chart,Line &amp; Bar Chart using HTML5 and JQuery.</div>
<div style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<ol style="outline:0px">
<li style="outline:0px">Line Chart </li><li style="outline:0px">Bar Chart </li><li style="outline:0px">Line &amp; Bar Chart </li><li style="outline:0px">Pie Chart </li><li style="outline:0px">Donut Chart </li><li style="outline:0px">Bubble Chart </li></ol>
</div>
<div style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
In the Source Code Zip file you can find Visual Studio 2013 solutions. You can&nbsp;also update to Visual Studio 2015.</div>
<div style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<br style="outline:0px">
<strong style="outline:0px">My Bar Chart Features<br style="outline:0px">
</strong><br style="outline:0px">
All this following features will be used for all chart types we can see one by one in code part.</div>
<div><em><img id="141399" src="141399-2.jpg" alt="" width="621" height="47"></em></div>
<div><em><strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:calibri; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">Chart
 Source Data<br style="outline:0px">
<br style="outline:0px">
</strong><span style="font:14px/21px calibri; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">The plot data from a database
 / Data Table / List / XML file or any source depending on your requirements. The only thing you need to do is get the data from your source and bind the result to a Dropdown List. (With the value and text. Here the value will be an integer for plotting the
 value and the text will be to be displayed in the label.)</span><br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:calibri; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">Chart
 Number of Category<br style="outline:0px">
<br style="outline:0px">
</strong><span style="font:14px/21px calibri; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">Here I have limited the
 Chart Category display from a minimum of 1 to a maximum of 12. This means here dynamically we can load the plots category depending on the data source. But limited, since the display plots value is within 12 plots. (But the user can redesign the code easily
 depending on requirements.)</span><br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:calibri; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">Chart
 Title Text<br style="outline:0px">
<br style="outline:0px">
</strong><span style="font:14px/21px calibri; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">The user can add their
 own Chart Title and dynamically change the titles if required. Here in my example I will draw the Title TextBox text at the bottom of the Bar Chart. (The user can redesign and customize this depending on requirements.)</span><br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:calibri; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">Chart
 Water Mark Text<br style="outline:0px">
<br style="outline:0px">
</strong><span style="font:14px/21px calibri; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">In some cases we need to
 add our company name as a Watermark to our Bar Chart. Here in my example I will draw the Water Mark TextBox text at the center of the Bar Chart. (The user can redesign and customize this depending on requirements.)</span><br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:calibri; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">Chart
 Company LOGO</strong><br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<span style="font:14px/21px calibri; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">The user can add their own company
 logo to the Chart. (Here for the sample I have added my own image as a log at the top-right corner. (The user can redesign and customize this depending on your requirements if needed.)</span><br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:calibri; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">Chart
 Alert Image<br style="outline:0px">
</strong><br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<span style="font:14px/21px calibri; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">Chart Alert Image Display: You can
 see from the article the first Image has Labels, I have displayed the Bar Chart label Text and Alert Image. If the &ldquo;Alert On&rdquo; radio button is checked I will display the Alert Image. If the &ldquo;Alert Off&rdquo; radio button is clicked then the
 Alert Image will not be displayed.</span><br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:calibri; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">The
 use of an Alert Image</strong><br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<span style="font:14px/21px calibri; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">Let's consider a real project. For
 example we need to display a Pie Chart for a manufacturing factory with production results Good and Bad. For example if the production result for each quality value is above 300 then we need to display the Alert Green image and if the quality value is below
 300 then we need to display the Red image with label bars.</span><br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<span style="font:14px/21px calibri; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">This Alert Image will be easy to
 identify each quality result as good or bad. (Here for a sample I have used 2 quality check and displayed using Green and Red images but users can customize depending on requirements and add your own image and logic.)</span><br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:calibri; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff"><br style="outline:0px">
Chart Color Theme<br style="outline:0px">
<br style="outline:0px">
</strong><span style="font:14px/21px calibri; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">The user can select any
 one Color Theme for the Chart as Green Theme or Blue Theme.</span><br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:calibri; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">Legend
 Display<br style="outline:0px">
<br style="outline:0px">
</strong><span style="font:14px/21px calibri; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">The user can enable or
 disable the display of the Legend for the Chart using the check box. If the &ldquo;Show Legend&ldquo; Checkbox is checked then the chart will be displayed with a label and alert image. If not checked then the legend will not be displayed in the chart.</span><br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:calibri; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">Save
 Chart as Image<br style="outline:0px">
<br style="outline:0px">
</strong><span style="font:14px/21px calibri; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">The user can save the chart
 as an image. Here we can see a Bar Chart with another theme with a Blue base but without displaying the Alert Image.</span></em></div>
<div><em></em>&nbsp;</div>
<h1><span>Building the Sample</span></h1>
<div><em><strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:calibri; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">Step
 1: Create new ASP.NET Web project</strong><br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<span style="font:14px/21px calibri; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">Click Start then All Programs then
 open Visual Studio 2013 or Visual Studio 2010 (depending on your installed version), select either one. Click &quot;File&quot; -&gt; &quot;New&quot; -&gt; &quot;Project...&quot; then select ASP.NET WEB Project then click Create.</span></em></div>
<div><span style="font-size:20px; font-weight:bold">Description</span></div>
<div><em><strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:calibri; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">Step
 2:Add canvas tag to your webform<br style="outline:0px">
<br style="outline:0px">
</strong><span style="font:14px/21px calibri; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">Add a new Webform and add
 a Canvas ELEMENT within the Section Tag.</span></em></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;SECTION&nbsp;style=<span class="js__string">&quot;border-style:&nbsp;solid;&nbsp;border-width:&nbsp;2px;&nbsp;width:&nbsp;800px;&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&lt;CANVAS&nbsp;HEIGHT=<span class="js__string">&quot;600px&quot;</span>&nbsp;WIDTH=<span class="js__string">&quot;800px&quot;</span>&nbsp;ID=<span class="js__string">&quot;canvas&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
Your&nbsp;browser&nbsp;is&nbsp;not&nbsp;supporting&nbsp;HTML5&nbsp;Canvas&nbsp;.Upgrade&nbsp;Browser&nbsp;to&nbsp;view&nbsp;<span class="js__operator">this</span>&nbsp;program&nbsp;or&nbsp;check&nbsp;<span class="js__statement">with</span>&nbsp;Chrome&nbsp;or&nbsp;<span class="js__operator">in</span>&nbsp;Firefox.&nbsp;&nbsp;&nbsp;
&lt;/CANVAS&gt;&nbsp;&nbsp;&nbsp;
&lt;/SECTION&gt;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<div style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px">Step 3: Script to Draw Chart in step-by-step<span class="Apple-converted-space">&nbsp;</span></strong><br style="outline:0px">
<br style="outline:0px">
<strong style="outline:0px">Script Global variable</strong></div>
<div style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px"><br style="outline:0px">
</strong>First add the global variable that needs to be used to draw a chart inside the script tag.<br style="outline:0px">
<br style="outline:0px">
I have commented the line before for each variable about its use. Here the ChartWidth and chartHeigth variables will be used to store and draw the Chart width and height depending on the Canvas size.</div>
</div>
</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//public&nbsp;Canvas&nbsp;object&nbsp;to&nbsp;use&nbsp;in&nbsp;all&nbsp;the&nbsp;functions.&nbsp;&nbsp;</span>&nbsp;
<span class="js__sl_comment">//this&nbsp;variable&nbsp;will&nbsp;be&nbsp;used&nbsp;to&nbsp;check&nbsp;for&nbsp;the&nbsp;result&nbsp;of&nbsp;Alert&nbsp;Image&nbsp;display&nbsp;&nbsp;</span>&nbsp;
<span class="js__statement">var</span>&nbsp;alertCheckValue&nbsp;=&nbsp;<span class="js__num">300</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__sl_comment">//Adding&nbsp;the&nbsp;Pic&nbsp;Chart&nbsp;Colors&nbsp;to&nbsp;array&nbsp;.Here&nbsp;i&nbsp;have&nbsp;fixed&nbsp;to&nbsp;12&nbsp;colors&nbsp;and&nbsp;12&nbsp;datas&nbsp;to&nbsp;add&nbsp;as&nbsp;Pic&nbsp;Chart.if&nbsp;you&nbsp;want&nbsp;you&nbsp;can&nbsp;add&nbsp;more&nbsp;from&nbsp;here.&nbsp;&nbsp;</span>&nbsp;
<span class="js__statement">var</span>&nbsp;pirChartColor&nbsp;=&nbsp;[<span class="js__string">&quot;#6CBB3C&quot;</span>,&nbsp;<span class="js__string">&quot;#F87217&quot;</span>,&nbsp;<span class="js__string">&quot;#EAC117&quot;</span>,&nbsp;<span class="js__string">&quot;#EDDA74&quot;</span>,&nbsp;<span class="js__string">&quot;#CD7F32&quot;</span>,&nbsp;<span class="js__string">&quot;#CCFB5D&quot;</span>,&nbsp;<span class="js__string">&quot;#FDD017&quot;</span>,&nbsp;<span class="js__string">&quot;#9DC209&quot;</span>,&nbsp;<span class="js__string">&quot;#E67451&quot;</span>,&nbsp;<span class="js__string">&quot;#728C00&quot;</span>,&nbsp;<span class="js__string">&quot;#617C58&quot;</span>,&nbsp;<span class="js__string">&quot;#64E986&quot;</span>];&nbsp;<span class="js__sl_comment">//&nbsp;green&nbsp;Color&nbsp;Combinations&nbsp;&nbsp;</span>&nbsp;
<span class="js__sl_comment">//&nbsp;var&nbsp;pirChartColor&nbsp;=&nbsp;[&quot;#3090C7&quot;,&nbsp;&quot;#BDEDFF&quot;,&nbsp;&quot;#78C7C7&quot;,&nbsp;&quot;#736AFF&quot;,&nbsp;&quot;#7FFFD4&quot;,&nbsp;&quot;#3EA99F&quot;,&nbsp;&quot;#EBF4FA&quot;,&nbsp;&quot;#F9B7FF&quot;,&nbsp;&quot;#8BB381&quot;,&nbsp;&quot;#BDEDFF&quot;,&nbsp;&quot;#B048B5&quot;,&nbsp;&quot;#4E387E&quot;];&nbsp;//&nbsp;Blue&nbsp;Color&nbsp;Combinations&nbsp;&nbsp;</span>&nbsp;
<span class="js__statement">var</span>&nbsp;lineColor&nbsp;=&nbsp;<span class="js__string">&quot;#3090C7&quot;</span>;&nbsp;&nbsp;&nbsp;
<span class="js__statement">var</span>&nbsp;lineOuterCircleColor&nbsp;=&nbsp;<span class="js__string">&quot;#6CBB3C&quot;</span>;&nbsp;&nbsp;&nbsp;
<span class="js__statement">var</span>&nbsp;lineInnerCircleColor&nbsp;=&nbsp;<span class="js__string">&quot;#FFFFFF&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__sl_comment">//declare&nbsp;the&nbsp;Canvas&nbsp;object&nbsp;&nbsp;</span>&nbsp;
<span class="js__statement">var</span>&nbsp;canvas;&nbsp;&nbsp;&nbsp;
<span class="js__statement">var</span>&nbsp;chartCTX;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__sl_comment">//&nbsp;declare&nbsp;the&nbsp;Border&nbsp;Space,Chart&nbsp;Start&nbsp;X&nbsp;and&nbsp;Y&nbsp;Position;&nbsp;&nbsp;</span>&nbsp;
<span class="js__statement">var</span>&nbsp;xSpace&nbsp;=&nbsp;<span class="js__num">80</span>;&nbsp;&nbsp;&nbsp;
<span class="js__statement">var</span>&nbsp;ySpace&nbsp;=&nbsp;<span class="js__num">80</span>;&nbsp;&nbsp;&nbsp;
<span class="js__sl_comment">//declare&nbsp;the&nbsp;Chart&nbsp;DrawWidth&nbsp;and&nbsp;Hegith&nbsp;&nbsp;</span>&nbsp;
<span class="js__statement">var</span>&nbsp;chartWidth,&nbsp;chartHeight;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__sl_comment">//&nbsp;declared&nbsp;the&nbsp;Chart&nbsp;Legend&nbsp;Width&nbsp;and&nbsp;Hegit&nbsp;&nbsp;</span>&nbsp;
<span class="js__statement">var</span>&nbsp;legendWidth,&nbsp;legendHeight;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__sl_comment">//declared&nbsp;the&nbsp;Chart&nbsp;data&nbsp;Minimum&nbsp;Value,maximum&nbsp;Value&nbsp;and&nbsp;Noofplots(Bars/Arc&nbsp;and&nbsp;Line&nbsp;points)&nbsp;&nbsp;</span>&nbsp;
<span class="js__statement">var</span>&nbsp;minDataVal,&nbsp;maxDataVal,&nbsp;noOfPlots;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__sl_comment">//here&nbsp;we&nbsp;declare&nbsp;the&nbsp;Image&nbsp;for&nbsp;the&nbsp;Chart&nbsp;legend&nbsp;alert&nbsp;status&nbsp;display.&nbsp;&nbsp;</span>&nbsp;
<span class="js__statement">var</span>&nbsp;greenImage&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Image();&nbsp;&nbsp;&nbsp;
<span class="js__statement">var</span>&nbsp;redImage&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Image();&nbsp;&nbsp;&nbsp;
<span class="js__sl_comment">//Alert&nbsp;Image&nbsp;Size&nbsp;widht&nbsp;and&nbsp;hegith&nbsp;&nbsp;</span>&nbsp;
<span class="js__statement">var</span>&nbsp;imagesize&nbsp;=&nbsp;<span class="js__num">20</span>;&nbsp;&nbsp;&nbsp;
<span class="js__statement">var</span>&nbsp;maxValdivValue;&nbsp;&nbsp;&nbsp;
<span class="js__sl_comment">//Here&nbsp;we&nbsp;declare&nbsp;the&nbsp;X,YAxis&nbsp;Font&nbsp;size&nbsp;and&nbsp;Color&nbsp;&nbsp;</span>&nbsp;
<span class="js__statement">var</span>&nbsp;fotnColor&nbsp;=&nbsp;<span class="js__string">&quot;#000000&quot;</span>;&nbsp;&nbsp;&nbsp;
<span class="js__statement">var</span>&nbsp;axisfontSize&nbsp;=&nbsp;<span class="js__num">10</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__statement">var</span>&nbsp;LogoImage&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Image();&nbsp;&nbsp;&nbsp;
<span class="js__statement">var</span>&nbsp;LogoImgWidth&nbsp;=&nbsp;<span class="js__num">120</span>;&nbsp;&nbsp;&nbsp;
<span class="js__statement">var</span>&nbsp;LogoImgHeight&nbsp;=&nbsp;<span class="js__num">70</span>;&nbsp;&nbsp;&nbsp;
<span class="js__sl_comment">//&nbsp;This&nbsp;arrawy&nbsp;wil&nbsp;be&nbsp;used&nbsp;to&nbsp;draw&nbsp;the&nbsp;Legends&nbsp;&nbsp;&nbsp;</span>&nbsp;
rect&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;&nbsp;&nbsp;
rectInner&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:calibri; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">Note:</strong><span style="font:14px/21px calibri; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff"><span class="Apple-converted-space">&nbsp;</span>I
 have used the Master pages so in the script before each control I will use the ContentPlaceHolderID.</span><br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<br style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<span style="font:14px/21px calibri; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">For example my Green color theme
 radio button id is rdoColorGreen. But for jQuery I will be use like this cphBody_rdoColorGreen. For example if we use a master page then we add a ContentPlaceHolderID like this in the script:</span></div>
<div><em>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">if</span>&nbsp;($(<span class="js__string">'#cphBody_rdoColorGreen:checked'</span>).val()&nbsp;==&nbsp;<span class="js__string">&quot;rdoColorGreen&quot;</span>)&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:calibri; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">2.
 Chart Color Theme<br style="outline:0px">
<br style="outline:0px">
</strong><span style="font:14px/21px calibri; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">This method depends on
 the user color selection checked from the radio button. I will select the Color Array to fill in the color for each plots. This is a common function that can be used to draw any chart like Line, Bar, Pie, Donut and and so on.</span></div>
</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;ChangeChartColor()&nbsp;&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span><span class="js__statement">if</span>&nbsp;($(<span class="js__string">'#cphBody_rdoColorGreen:checked'</span>).val()&nbsp;==&nbsp;<span class="js__string">&quot;rdoColorGreen&quot;</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pirChartColor&nbsp;=&nbsp;[<span class="js__string">&quot;#6CBB3C&quot;</span>,&nbsp;<span class="js__string">&quot;#F87217&quot;</span>,&nbsp;<span class="js__string">&quot;#EAC117&quot;</span>,&nbsp;<span class="js__string">&quot;#EDDA74&quot;</span>,&nbsp;<span class="js__string">&quot;#CD7F32&quot;</span>,&nbsp;<span class="js__string">&quot;#CCFB5D&quot;</span>,&nbsp;<span class="js__string">&quot;#FDD017&quot;</span>,&nbsp;<span class="js__string">&quot;#9DC209&quot;</span>,&nbsp;<span class="js__string">&quot;#E67451&quot;</span>,&nbsp;<span class="js__string">&quot;#728C00&quot;</span>,&nbsp;<span class="js__string">&quot;#617C58&quot;</span>,&nbsp;<span class="js__string">&quot;#64E986&quot;</span>];&nbsp;<span class="js__sl_comment">//&nbsp;green&nbsp;Color&nbsp;Combinations&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lineColor&nbsp;=&nbsp;<span class="js__string">&quot;#3090C7&quot;</span>;&nbsp;<span class="js__sl_comment">//&nbsp;Blue&nbsp;Color&nbsp;for&nbsp;Line&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lineOuterCircleColor&nbsp;=&nbsp;<span class="js__string">&quot;#6CBB3C&quot;</span>;&nbsp;<span class="js__sl_comment">//&nbsp;Green&nbsp;Color&nbsp;for&nbsp;Outer&nbsp;Circle&nbsp;&nbsp;</span><span class="js__brace">}</span><span class="js__statement">else</span><span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pirChartColor&nbsp;=&nbsp;[<span class="js__string">&quot;#3090C7&quot;</span>,&nbsp;<span class="js__string">&quot;#BDEDFF&quot;</span>,&nbsp;<span class="js__string">&quot;#78C7C7&quot;</span>,&nbsp;<span class="js__string">&quot;#736AFF&quot;</span>,&nbsp;<span class="js__string">&quot;#7FFFD4&quot;</span>,&nbsp;<span class="js__string">&quot;#3EA99F&quot;</span>,&nbsp;<span class="js__string">&quot;#EBF4FA&quot;</span>,&nbsp;<span class="js__string">&quot;#F9B7FF&quot;</span>,&nbsp;<span class="js__string">&quot;#8BB381&quot;</span>,&nbsp;<span class="js__string">&quot;#BDEDFF&quot;</span>,&nbsp;<span class="js__string">&quot;#B048B5&quot;</span>,&nbsp;<span class="js__string">&quot;#4E387E&quot;</span>];&nbsp;<span class="js__sl_comment">//&nbsp;Blue&nbsp;Color&nbsp;Combinations&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lineColor&nbsp;=&nbsp;<span class="js__string">&quot;#F87217&quot;</span>;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Orange&nbsp;Color&nbsp;for&nbsp;the&nbsp;Line&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lineOuterCircleColor&nbsp;=&nbsp;<span class="js__string">&quot;#F70D1A&nbsp;&quot;</span>;&nbsp;<span class="js__sl_comment">//&nbsp;Red&nbsp;Color&nbsp;for&nbsp;the&nbsp;outer&nbsp;circle&nbsp;&nbsp;</span><span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:calibri; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">Draw
 legend<br style="outline:0px">
<br style="outline:0px">
</strong><span style="font:14px/21px calibri; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">This method will be used
 to draw the legend for the chart. In this method I will draw a label with color and add label text and an Alert Image inside the label. This is a common function that can be used to draw any chart like Line, Bar, Pie, Donut and and so on. (In the Line chart
 I don't use this Legend since a line chart is not required for the Label display.)</span></div>
<div>
<div>
<div>
<div style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;This&nbsp;function&nbsp;is&nbsp;used&nbsp;to&nbsp;draw&nbsp;the&nbsp;Legend&nbsp;&nbsp;</span><span class="js__operator">function</span>&nbsp;drawLengends()&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillStyle&nbsp;=&nbsp;<span class="js__string">&quot;#7F462C&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillRect(rect.startX,&nbsp;rect.startY,&nbsp;rect.w,&nbsp;rect.h);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Drawing&nbsp;Inner&nbsp;White&nbsp;color&nbsp;Rectange&nbsp;with&nbsp;in&nbsp;Above&nbsp;brown&nbsp;rectangle&nbsp;to&nbsp;plot&nbsp;all&nbsp;the&nbsp;Lables&nbsp;with&nbsp;color,Text&nbsp;and&nbsp;Value.&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillStyle&nbsp;=&nbsp;<span class="js__string">&quot;#FFFFFF&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;rectInner.startX&nbsp;=&nbsp;rect.startX&nbsp;&#43;&nbsp;<span class="js__num">1</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;rectInner.startY&nbsp;=&nbsp;rect.startY&nbsp;&#43;&nbsp;<span class="js__num">1</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;rectInner.w&nbsp;=&nbsp;rect.w&nbsp;-&nbsp;<span class="js__num">2</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;rectInner.h&nbsp;=&nbsp;rect.h&nbsp;-&nbsp;<span class="js__num">2</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillRect(rectInner.startX,&nbsp;rectInner.startY,&nbsp;rectInner.w,&nbsp;rectInner.h);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;labelBarX&nbsp;=&nbsp;rectInner.startX&nbsp;&#43;&nbsp;<span class="js__num">4</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;labelBarY&nbsp;=&nbsp;rectInner.startY&nbsp;&#43;&nbsp;<span class="js__num">4</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;labelBarWidth&nbsp;=&nbsp;rectInner.w&nbsp;-&nbsp;<span class="js__num">10</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;labelBarHeight&nbsp;=&nbsp;(rectInner.h&nbsp;/&nbsp;noOfPlots)&nbsp;-&nbsp;<span class="js__num">5</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;colorval&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;here&nbsp;to&nbsp;draw&nbsp;all&nbsp;the&nbsp;rectangle&nbsp;for&nbsp;Lables&nbsp;with&nbsp;Image&nbsp;display&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#cphBody_DropDownList1&nbsp;option'</span>).each(<span class="js__operator">function</span>&nbsp;()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillStyle&nbsp;=&nbsp;pirChartColor[colorval];&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillRect(labelBarX,&nbsp;labelBarY,&nbsp;labelBarWidth,&nbsp;labelBarHeight);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Here&nbsp;we&nbsp;check&nbsp;for&nbsp;the&nbsp;rdoAlert&nbsp;Status&nbsp;is&nbsp;On&nbsp;-&nbsp;If&nbsp;the&nbsp;Alert&nbsp;is&nbsp;on&nbsp;then&nbsp;we&nbsp;display&nbsp;the&nbsp;Alert&nbsp;Image&nbsp;as&nbsp;per&nbsp;the&nbsp;&nbsp;Alert&nbsp;check&nbsp;value.&nbsp;&nbsp;</span><span class="js__statement">if</span>&nbsp;($(<span class="js__string">'#cphBody_rdoAlaramOn:checked'</span>).val()&nbsp;==&nbsp;<span class="js__string">&quot;rdoAlaramOn&quot;</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__sl_comment">//&nbsp;Here&nbsp;we&nbsp;can&nbsp;see&nbsp;fo&nbsp;ever&nbsp;chart&nbsp;value&nbsp;we&nbsp;check&nbsp;with&nbsp;the&nbsp;condition&nbsp;.we&nbsp;have&nbsp;initially&nbsp;declare&nbsp;the&nbsp;alertCheckValue&nbsp;as&nbsp;300.&nbsp;&nbsp;</span><span class="js__sl_comment">//so&nbsp;if&nbsp;the&nbsp;Chart&nbsp;Plot&nbsp;value&nbsp;is&nbsp;Greater&nbsp;then&nbsp;or&nbsp;equal&nbsp;to&nbsp;the&nbsp;check&nbsp;value&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;then&nbsp;we&nbsp;display&nbsp;the&nbsp;Green&nbsp;Image&nbsp;<span class="js__statement">else</span>&nbsp;we&nbsp;display&nbsp;the&nbsp;Red&nbsp;Image.&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//user&nbsp;can&nbsp;change&nbsp;this&nbsp;to&nbsp;your&nbsp;requiremnt&nbsp;if&nbsp;needed.This&nbsp;is&nbsp;optioan&nbsp;function&nbsp;for&nbsp;the&nbsp;Pie&nbsp;Chart.&nbsp;&nbsp;</span><span class="js__statement">if</span>&nbsp;(<span class="js__function">parseInt</span>($(<span class="js__operator">this</span>).val())&nbsp;&gt;=&nbsp;alertCheckValue)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.drawImage(greenImage,&nbsp;labelBarX,&nbsp;labelBarY&nbsp;&#43;&nbsp;(labelBarHeight&nbsp;/&nbsp;<span class="js__num">3</span>)&nbsp;-&nbsp;<span class="js__num">4</span>,&nbsp;imagesize,&nbsp;imagesize);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__statement">else</span><span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.drawImage(redImage,&nbsp;labelBarX,&nbsp;labelBarY&nbsp;&#43;&nbsp;(labelBarHeight&nbsp;/&nbsp;<span class="js__num">3</span>)&nbsp;-&nbsp;<span class="js__num">4</span>,&nbsp;imagesize,&nbsp;imagesize);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__sl_comment">//Draw&nbsp;the&nbsp;Pie&nbsp;Chart&nbsp;Label&nbsp;text&nbsp;and&nbsp;Value&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillStyle&nbsp;=&nbsp;<span class="js__string">&quot;#000000&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.font&nbsp;=&nbsp;<span class="js__string">'10pt&nbsp;Calibri'</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillText($(<span class="js__operator">this</span>).text(),&nbsp;labelBarX&nbsp;&#43;&nbsp;imagesize&nbsp;&#43;&nbsp;<span class="js__num">2</span>,&nbsp;labelBarY&nbsp;&#43;&nbsp;(labelBarHeight&nbsp;/&nbsp;<span class="js__num">2</span>));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;To&nbsp;Increment&nbsp;and&nbsp;draw&nbsp;the&nbsp;next&nbsp;bar&nbsp;,label&nbsp;Text&nbsp;and&nbsp;Alart&nbsp;Image.&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;labelBarY&nbsp;=&nbsp;labelBarY&nbsp;&#43;&nbsp;labelBarHeight&nbsp;&#43;&nbsp;<span class="js__num">4</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;&nbsp;labelTextYXVal&nbsp;=&nbsp;labelBarY&nbsp;&#43;&nbsp;labelBarHeight&nbsp;-&nbsp;4;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colorval&nbsp;=&nbsp;colorval&nbsp;&#43;&nbsp;<span class="js__num">1</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
</div>
<div style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px">Draw Chart<br style="outline:0px">
<br style="outline:0px">
</strong>This is the main method. the In button Draw Chart Image button clicks I will call this method first. From this method I will call other methods depending on requirements.<br style="outline:0px">
In this method I have explained in comments before each line of code. This method has 5 main code parts as we can see here. In the comments I have explained using steps at each part. &nbsp;</div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<ol style="outline:0px">
<li style="outline:0px; font-family:calibri">First we calculate and store all the necessary variables like Item Maximum Value, Item total Count, Chart Width, Chart Height, legend Width, Legend height at and so on.
</li><li style="outline:0px"><span style="outline:0px; font-family:calibri">Draw legend.</span>
</li><li style="outline:0px"><span style="outline:0px; font-family:calibri">Add Chart Title and Logo to chart.</span>
</li><li style="outline:0px"><span style="outline:0px; font-family:calibri">Draw X-Axis Line with Plot text.</span>
</li><li style="outline:0px"><span style="outline:0px; font-family:calibri">Draw Y- Axis Line with Y-Axis plot value.</span>
</li><li style="outline:0px"><span style="outline:0px; font-family:calibri">Draw Bar Chart method (Next we call the method to draw our chart. For each chart I have created a separate method. For example to draw the Bar Chart I will call the &ldquo;drawBarChart()&rdquo;
 method, to draw a line chart I will call the &ldquo;drawLineChart()&rdquo; method and so on.</span>
</li><li style="outline:0px"><span style="outline:0px; font-family:calibri">Draw the Watermark text for the chart.</span><span style="outline:0px; font-family:calibri">&nbsp;&nbsp;</span>
</li></ol>
</div>
</div>
</div>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;This&nbsp;is&nbsp;the&nbsp;main&nbsp;function&nbsp;to&nbsp;darw&nbsp;the&nbsp;Charts&nbsp;&nbsp;</span><span class="js__operator">function</span>&nbsp;drawChart()&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ChangeChartColor();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;asign&nbsp;the&nbsp;images&nbsp;path&nbsp;for&nbsp;both&nbsp;Alert&nbsp;images&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;greenImage.src&nbsp;=&nbsp;<span class="js__string">'../images/Green.png'</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;redImage.src&nbsp;=&nbsp;<span class="js__string">'../images/Red.png'</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;LogoImage.src&nbsp;=&nbsp;<span class="js__string">'../images/shanu.jpg'</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Get&nbsp;the&nbsp;minumum&nbsp;and&nbsp;maximum&nbsp;value.here&nbsp;i&nbsp;have&nbsp;used&nbsp;the&nbsp;hidden&nbsp;filed&nbsp;from&nbsp;code&nbsp;behind&nbsp;wich&nbsp;will&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stored&nbsp;the&nbsp;Maximum&nbsp;and&nbsp;Minimum&nbsp;value&nbsp;of&nbsp;the&nbsp;Drop&nbsp;down&nbsp;list&nbsp;box.&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;minDataVal&nbsp;=&nbsp;$(<span class="js__string">'#cphBody_hidListMin'</span>).val();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;maxDataVal&nbsp;=&nbsp;$(<span class="js__string">'#cphBody_hidListMax'</span>).val();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Total&nbsp;no&nbsp;of&nbsp;plots&nbsp;we&nbsp;are&nbsp;going&nbsp;to&nbsp;draw.&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;noOfPlots&nbsp;=&nbsp;$(<span class="js__string">&quot;#cphBody_DropDownList1&nbsp;option&quot;</span>).length;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;maxValdivValue&nbsp;=&nbsp;<span class="js__object">Math</span>.round((maxDataVal&nbsp;/&nbsp;noOfPlots));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//storing&nbsp;the&nbsp;Canvas&nbsp;Context&nbsp;to&nbsp;local&nbsp;variable&nbsp;ctx.This&nbsp;variable&nbsp;will&nbsp;be&nbsp;used&nbsp;to&nbsp;draw&nbsp;the&nbsp;Pie&nbsp;Chart&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;canvas&nbsp;=&nbsp;document.getElementById(<span class="js__string">&quot;canvas&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ctx&nbsp;=&nbsp;canvas.getContext(<span class="js__string">&quot;2d&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//globalAlpha&nbsp;-&nbsp;&gt;&nbsp;is&nbsp;used&nbsp;to&nbsp;display&nbsp;the&nbsp;100%&nbsp;opoacity&nbsp;of&nbsp;chart&nbsp;.because&nbsp;at&nbsp;the&nbsp;bottom&nbsp;of&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;the&nbsp;code&nbsp;I&nbsp;have&nbsp;used&nbsp;the&nbsp;opacity&nbsp;to&nbsp;<span class="js__num">0.1</span>&nbsp;to&nbsp;display&nbsp;the&nbsp;water&nbsp;mark&nbsp;text&nbsp;<span class="js__statement">with</span>&nbsp;fade&nbsp;effect.&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ctx.globalAlpha&nbsp;=&nbsp;<span class="js__num">1</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillStyle&nbsp;=&nbsp;<span class="js__string">&quot;#000000&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ctx.strokeStyle&nbsp;=&nbsp;<span class="js__string">'#000000'</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Every&nbsp;time&nbsp;we&nbsp;clear&nbsp;the&nbsp;canvas&nbsp;and&nbsp;draw&nbsp;the&nbsp;chart&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ctx.clearRect(<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;canvas.width,&nbsp;canvas.height);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//If&nbsp;need&nbsp;to&nbsp;draw&nbsp;with&nbsp;out&nbsp;legend&nbsp;for&nbsp;the&nbsp;Line&nbsp;Chart&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;chartWidth&nbsp;=&nbsp;canvas.width&nbsp;-&nbsp;xSpace;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;chartHeight&nbsp;=&nbsp;canvas.height&nbsp;-&nbsp;ySpace;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;&nbsp;step&nbsp;1)&nbsp;Draw&nbsp;legend&nbsp;$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$########################&nbsp;&nbsp;</span><span class="js__statement">if</span>&nbsp;($(<span class="js__string">'#cphBody_chkLegend:checked'</span>).val()&nbsp;==&nbsp;<span class="js__string">&quot;on&quot;</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chartWidth&nbsp;=&nbsp;canvas.width&nbsp;-&nbsp;((canvas.width&nbsp;/&nbsp;<span class="js__num">3</span>)&nbsp;-&nbsp;(xSpace&nbsp;/&nbsp;<span class="js__num">2</span>));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chartHeight&nbsp;=&nbsp;canvas.height&nbsp;-&nbsp;ySpace&nbsp;-&nbsp;<span class="js__num">10</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;legendWidth&nbsp;=&nbsp;canvas.width&nbsp;-&nbsp;((canvas.width&nbsp;/&nbsp;<span class="js__num">3</span>)&nbsp;-&nbsp;xSpace);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;legendHeight&nbsp;=&nbsp;ySpace;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rect.startX&nbsp;=&nbsp;legendWidth;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rect.startY&nbsp;=&nbsp;legendHeight;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rect.w&nbsp;=&nbsp;canvas.width&nbsp;/&nbsp;<span class="js__num">3</span>&nbsp;-&nbsp;xSpace&nbsp;-&nbsp;<span class="js__num">10</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rect.h&nbsp;=&nbsp;canvas.height&nbsp;-&nbsp;ySpace&nbsp;-&nbsp;<span class="js__num">10</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//In&nbsp;this&nbsp;method&nbsp;i&nbsp;will&nbsp;draw&nbsp;the&nbsp;legend&nbsp;with&nbsp;the&nbsp;Alert&nbsp;Image.&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;drawLengends();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;end&nbsp;step&nbsp;1)&nbsp;$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$&nbsp;&nbsp;</span><span class="js__statement">var</span>&nbsp;chartMidPosition&nbsp;=&nbsp;chartWidth&nbsp;/&nbsp;<span class="js__num">2</span>&nbsp;-&nbsp;<span class="js__num">60</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">////&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//If&nbsp;need&nbsp;to&nbsp;draw&nbsp;with&nbsp;legend&nbsp;&nbsp;</span><span class="js__sl_comment">////&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chartWidth&nbsp;=&nbsp;canvas.width&nbsp;-&nbsp;((canvas.width&nbsp;/&nbsp;3)&nbsp;-&nbsp;(xSpace&nbsp;/&nbsp;2));&nbsp;&nbsp;</span><span class="js__sl_comment">////&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chartHeight&nbsp;=&nbsp;canvas.height&nbsp;-&nbsp;ySpace&nbsp;-&nbsp;10;&nbsp;&nbsp;</span><span class="js__sl_comment">//&nbsp;Step&nbsp;2&nbsp;)&nbsp;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&nbsp;To&nbsp;Add&nbsp;Chart&nbsp;Titel&nbsp;and&nbsp;&nbsp;Company&nbsp;Logo&nbsp;&nbsp;</span><span class="js__sl_comment">//To&nbsp;Add&nbsp;Logo&nbsp;to&nbsp;Chart&nbsp;&nbsp;</span><span class="js__statement">var</span>&nbsp;logoXVal&nbsp;=&nbsp;canvas.width&nbsp;-&nbsp;LogoImgWidth&nbsp;-&nbsp;<span class="js__num">10</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;logolYVal&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//here&nbsp;we&nbsp;draw&nbsp;the&nbsp;Logo&nbsp;for&nbsp;teh&nbsp;chart&nbsp;and&nbsp;i&nbsp;have&nbsp;used&nbsp;the&nbsp;alpha&nbsp;to&nbsp;fade&nbsp;and&nbsp;display&nbsp;the&nbsp;Logo.&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.globalAlpha&nbsp;=&nbsp;<span class="js__num">0.6</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.drawImage(LogoImage,&nbsp;logoXVal,&nbsp;logolYVal,&nbsp;LogoImgWidth,&nbsp;LogoImgHeight);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.globalAlpha&nbsp;=&nbsp;<span class="js__num">1</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.font&nbsp;=&nbsp;<span class="js__string">'22pt&nbsp;Calibri'</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillStyle&nbsp;=&nbsp;<span class="js__string">&quot;#15317E&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillText($(<span class="js__string">'#cphBody_txtTitle'</span>).val(),&nbsp;chartMidPosition,&nbsp;chartHeight&nbsp;&#43;&nbsp;<span class="js__num">60</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillStyle&nbsp;=&nbsp;<span class="js__string">&quot;#000000&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.font&nbsp;=&nbsp;<span class="js__string">'10pt&nbsp;Calibri'</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;end&nbsp;step&nbsp;2)&nbsp;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&nbsp;End&nbsp;of&nbsp;Title&nbsp;and&nbsp;Company&nbsp;Logo&nbsp;Add&nbsp;&nbsp;</span><span class="js__sl_comment">//&nbsp;Step&nbsp;3&nbsp;)&nbsp;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&nbsp;toDraw&nbsp;the&nbsp;X-Axis&nbsp;and&nbsp;Y-Axis&nbsp;&nbsp;</span><span class="js__sl_comment">//&nbsp;&nbsp;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&nbsp;Draw&nbsp;Y-Axis&nbsp;and&nbsp;X-Axis&nbsp;Line(Horizontal&nbsp;Line)&nbsp;&nbsp;</span><span class="js__sl_comment">//&nbsp;Draw&nbsp;the&nbsp;axises&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.beginPath();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.moveTo(xSpace,&nbsp;ySpace);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;first&nbsp;Draw&nbsp;Y&nbsp;Axis&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.lineTo(xSpace,&nbsp;chartHeight);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Next&nbsp;draw&nbsp;the&nbsp;X-Axis&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.lineTo(chartWidth,&nbsp;chartHeight);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.stroke();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;&nbsp;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&nbsp;End&nbsp;of&nbsp;X-Axis&nbsp;Line&nbsp;Draw&nbsp;&nbsp;</span><span class="js__sl_comment">//end&nbsp;step&nbsp;3)&nbsp;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&nbsp;&nbsp;</span><span class="js__sl_comment">//&nbsp;Step&nbsp;4)&nbsp;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&nbsp;To&nbsp;Draw&nbsp;X&nbsp;-&nbsp;Axis&nbsp;Plot&nbsp;Values&nbsp;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&nbsp;}}}}}}&nbsp;&nbsp;</span><span class="js__sl_comment">//&nbsp;Draw&nbsp;the&nbsp;X&nbsp;value&nbsp;texts&nbsp;&nbsp;</span><span class="js__sl_comment">//&nbsp;---&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&nbsp;&nbsp;for&nbsp;the&nbsp;Bar&nbsp;Chart&nbsp;i&nbsp;have&nbsp;draw&nbsp;the&nbsp;X-Axis&nbsp;plot&nbsp;in&nbsp;&nbsp;drawBarChart&nbsp;&nbsp;</span><span class="js__sl_comment">//&nbsp;&nbsp;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&nbsp;End&nbsp;of&nbsp;X&nbsp;Axis&nbsp;Draw&nbsp;&nbsp;</span><span class="js__sl_comment">//&nbsp;end&nbsp;Step&nbsp;4)&nbsp;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&lt;&nbsp;&nbsp;</span><span class="js__sl_comment">//&nbsp;Step&nbsp;5){{{{{{{{{{{{&nbsp;&nbsp;</span><span class="js__sl_comment">//&nbsp;{{{{{{{{{{{{{To&nbsp;Draw&nbsp;the&nbsp;Y&nbsp;Axis&nbsp;Plot&nbsp;Values}}}}}}}}}}}}}}&nbsp;&nbsp;</span><span class="js__statement">var</span>&nbsp;vAxisPoints&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;max&nbsp;=&nbsp;maxDataVal;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;max&nbsp;&#43;=&nbsp;<span class="js__num">10</span>&nbsp;-&nbsp;max&nbsp;%&nbsp;<span class="js__num">10</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;=&nbsp;maxDataVal;&nbsp;i&nbsp;&#43;=&nbsp;maxValdivValue)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillStyle&nbsp;=&nbsp;fotnColor;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.font&nbsp;=&nbsp;axisfontSize&nbsp;&#43;&nbsp;<span class="js__string">'pt&nbsp;Calibri'</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillText(i,&nbsp;xSpace&nbsp;-&nbsp;<span class="js__num">40</span>,&nbsp;getYPlotVale(i));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Here&nbsp;we&nbsp;draw&nbsp;the&nbsp;Y-Axis&nbsp;point&nbsp;line&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.beginPath();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.moveTo(xSpace,&nbsp;getYPlotVale(i));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.lineTo(xSpace&nbsp;-&nbsp;<span class="js__num">10</span>,&nbsp;getYPlotVale(i));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.stroke();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;vAxisPoints&nbsp;=&nbsp;vAxisPoints&nbsp;&#43;&nbsp;maxValdivValue;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//{{{{{{{{{{{{{{&nbsp;End&nbsp;of&nbsp;Y-&nbsp;Axis&nbsp;Plot&nbsp;Values&nbsp;&nbsp;</span><span class="js__sl_comment">//end&nbsp;&nbsp;Step&nbsp;5)&nbsp;{{{{{{{{{{{{{{{{{{&nbsp;&nbsp;</span><span class="js__sl_comment">//Step&nbsp;5)&nbsp;*********************************************************&nbsp;&nbsp;</span><span class="js__sl_comment">//Function&nbsp;to&nbsp;Draw&nbsp;our&nbsp;Chart&nbsp;here&nbsp;we&nbsp;can&nbsp;Call/Bar&nbsp;Chart/Line&nbsp;Chart&nbsp;or&nbsp;Pie&nbsp;Chart&nbsp;&nbsp;</span><span class="js__sl_comment">//&nbsp;to&nbsp;Draw&nbsp;Bar&nbsp;Chart&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;drawBarChart();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;to&nbsp;Draw&nbsp;line&nbsp;Chart&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;drawLineChart();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;end&nbsp;step&nbsp;6)&nbsp;**************&nbsp;&nbsp;</span><span class="js__sl_comment">//Step&nbsp;7)&nbsp;&nbsp;::::::::::::::::::::&nbsp;to&nbsp;add&nbsp;the&nbsp;Water&nbsp;mark&nbsp;Text&nbsp;&nbsp;</span><span class="js__sl_comment">//&nbsp;Here&nbsp;add&nbsp;the&nbsp;Water&nbsp;mark&nbsp;text&nbsp;at&nbsp;center&nbsp;of&nbsp;the&nbsp;chart&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;ctx.globalAlpha&nbsp;=&nbsp;<span class="js__num">0.1</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;ctx.font&nbsp;=&nbsp;<span class="js__string">'86pt&nbsp;Calibri'</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;ctx.fillStyle&nbsp;=&nbsp;<span class="js__string">&quot;#000000&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;ctx.fillText($(<span class="js__string">'#cphBody_txtWatermark'</span>).val(),&nbsp;chartMidPosition&nbsp;-&nbsp;<span class="js__num">40</span>,&nbsp;chartHeight&nbsp;/&nbsp;<span class="js__num">2</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;ctx.font&nbsp;=&nbsp;<span class="js__string">'10pt&nbsp;Calibri'</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;ctx.globalAlpha&nbsp;=&nbsp;<span class="js__num">1</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;end&nbsp;step&nbsp;7)&nbsp;::::::::::::::::::::::::::::::::::::::&nbsp;&nbsp;</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
</em></div>
<div style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
Here we see the entire method one by one that will be used to draw the chart.</div>
<div style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px">Draw Bar Chart</strong><br style="outline:0px">
In this method I will calculate all the data with plot x and y point and draw the rectangle one by one to draw the Bar chart.&nbsp;</div>
<div style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
&nbsp;</div>
<div style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<img id="141403" src="141403-5.jpg" alt="" width="524" height="362"></div>
<div>&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;drawBarChart()&nbsp;&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;XvalPosition&nbsp;=&nbsp;xSpace;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;widthcalculation&nbsp;=&nbsp;<span class="js__function">parseInt</span>(((<span class="js__function">parseInt</span>(chartWidth)&nbsp;-&nbsp;<span class="js__num">100</span>)&nbsp;/&nbsp;noOfPlots));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colorval&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#cphBody_DropDownList1&nbsp;option'</span>).each(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Draw&nbsp;Xaxis&nbsp;Plots&nbsp;Line&nbsp;and&nbsp;Text&nbsp;&nbsp;&nbsp;***********&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XvalPosition&nbsp;=&nbsp;XvalPosition&nbsp;&#43;&nbsp;widthcalculation;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.moveTo(XvalPosition,&nbsp;chartHeight);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.lineTo(XvalPosition,&nbsp;chartHeight&nbsp;&#43;&nbsp;<span class="js__num">15</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.stroke();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillStyle&nbsp;=&nbsp;<span class="js__string">&quot;#000000&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.font&nbsp;=&nbsp;<span class="js__string">'10pt&nbsp;Calibri'</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillText(<span class="js__string">'Bar'</span>&nbsp;&#43;&nbsp;<span class="js__function">parseInt</span>(colorval&nbsp;&#43;&nbsp;<span class="js__num">1</span>),&nbsp;XvalPosition&nbsp;-&nbsp;<span class="js__num">28</span>,&nbsp;chartHeight&nbsp;&#43;&nbsp;<span class="js__num">24</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;&nbsp;End&nbsp;Xval&nbsp;Plotting&nbsp;&nbsp;************&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Draw&nbsp;Bar&nbsp;Graph&nbsp;&nbsp;**************==================********************&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;barRatio&nbsp;=&nbsp;<span class="js__function">parseInt</span>($(<span class="js__operator">this</span>).val())&nbsp;/&nbsp;maxDataVal;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//alert(ratio)&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;barfillHeight&nbsp;=&nbsp;<span class="js__function">parseInt</span>(barRatio&nbsp;*&nbsp;(<span class="js__function">parseInt</span>(chartHeight&nbsp;-&nbsp;xSpace)));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;alert(barHeight)&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillRect(XvalPosition&nbsp;-&nbsp;widthcalculation&nbsp;-&nbsp;<span class="js__num">1</span>,&nbsp;chartHeight&nbsp;-&nbsp;<span class="js__num">1</span>,&nbsp;widthcalculation&nbsp;&#43;&nbsp;<span class="js__num">2</span>,&nbsp;-barfillHeight);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillStyle&nbsp;=&nbsp;pirChartColor[colorval];&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;&nbsp;e.DrawRectangle(B1pen,&nbsp;XvalPosition_Start,&nbsp;Ystartval,&nbsp;XvalPosition_new,&nbsp;YEndval);&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillRect(XvalPosition&nbsp;-&nbsp;widthcalculation,&nbsp;chartHeight,&nbsp;widthcalculation,&nbsp;-barfillHeight);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//ctx.fillRect(XvalPosition&nbsp;-&nbsp;widthcalculation,&nbsp;yLineHeight,&nbsp;widthcalculation,&nbsp;yLineHeight-&nbsp;parseInt($(this).val()));&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;*****&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//////&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillStyle&nbsp;=&nbsp;&quot;#000000&quot;;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//////&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.font&nbsp;=&nbsp;'10pt&nbsp;Calibri';&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//////&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillText($(this).val(),&nbsp;XvalPosition&nbsp;-&nbsp;widthcalculation&nbsp;&#43;&nbsp;4,&nbsp;chartHeight&nbsp;-&nbsp;barfillHeight&nbsp;-&nbsp;8);&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillStyle&nbsp;=&nbsp;pirChartColor[colorval];&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//END&nbsp;Draw&nbsp;Bar&nbsp;Graph&nbsp;&nbsp;**************==================********************&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colorval&nbsp;=&nbsp;colorval&nbsp;&#43;&nbsp;<span class="js__num">1</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:calibri; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">Draw
 Line Chart<br style="outline:0px">
<br style="outline:0px">
</strong><span style="font:14px/21px calibri; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">In this method I will calculate
 all the data with plot x and y point and draw the line with Dot and Item text to be draw for each Line point.</span></div>
</div>
<div>&nbsp;</div>
<div><em></em>&nbsp;<img id="141400" src="141400-3.jpg" alt="" width="612" height="279"></div>
<div><em></em>&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;drawLineChart()&nbsp;&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;For&nbsp;Drawing&nbsp;Line&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.lineWidth&nbsp;=&nbsp;<span class="js__num">3</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;value&nbsp;=&nbsp;$(<span class="js__string">'select#cphBody_DropDownList1&nbsp;option:selected'</span>).val();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;alert(value);&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.beginPath();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;***************&nbsp;To&nbsp;Draw&nbsp;the&nbsp;Line&nbsp;and&nbsp;Plot&nbsp;Value&nbsp;in&nbsp;Line&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillStyle&nbsp;=&nbsp;<span class="js__string">&quot;#FFFFFF&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.strokeStyle&nbsp;=&nbsp;<span class="js__string">'#FFFFFF'</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.moveTo(getXPlotvalue(<span class="js__num">0</span>),&nbsp;getYPlotVale(value));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillStyle&nbsp;=&nbsp;<span class="js__string">&quot;#000000&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.font&nbsp;=&nbsp;<span class="js__string">'12pt&nbsp;Calibri'</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillText(value,&nbsp;getXPlotvalue(<span class="js__num">0</span>),&nbsp;getYPlotVale(value)&nbsp;-&nbsp;<span class="js__num">12</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;ival&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#cphBody_DropDownList1&nbsp;option'</span>).each(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(ival&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.lineTo(getXPlotvalue(ival),&nbsp;getYPlotVale($(<span class="js__operator">this</span>).val()));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.stroke();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillStyle&nbsp;=&nbsp;<span class="js__string">&quot;#000000&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.font&nbsp;=&nbsp;<span class="js__string">'12pt&nbsp;Calibri'</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillText($(<span class="js__operator">this</span>).val(),&nbsp;getXPlotvalue(ival),&nbsp;getYPlotVale($(<span class="js__operator">this</span>).val())&nbsp;-&nbsp;<span class="js__num">16</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ival&nbsp;=&nbsp;ival&nbsp;&#43;&nbsp;<span class="js__num">1</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillStyle&nbsp;=&nbsp;lineColor;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.strokeStyle&nbsp;=&nbsp;lineColor;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;***************&nbsp;To&nbsp;Draw&nbsp;the&nbsp;Line&nbsp;Dot&nbsp;Cericle&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//For&nbsp;Outer&nbsp;Blue&nbsp;Dot&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ival&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#cphBody_DropDownList1&nbsp;option'</span>).each(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillStyle&nbsp;=&nbsp;lineOuterCircleColor;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.strokeStyle&nbsp;=&nbsp;lineOuterCircleColor;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.beginPath();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.arc(getXPlotvalue(ival),&nbsp;getYPlotVale($(<span class="js__operator">this</span>).val()),&nbsp;<span class="js__num">7</span>,&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__object">Math</span>.PI&nbsp;*&nbsp;<span class="js__num">2</span>,&nbsp;true);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fill();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillStyle&nbsp;=&nbsp;lineInnerCircleColor;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.strokeStyle&nbsp;=&nbsp;lineInnerCircleColor;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.beginPath();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.arc(getXPlotvalue(ival),&nbsp;getYPlotVale($(<span class="js__operator">this</span>).val()),&nbsp;<span class="js__num">4</span>,&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__object">Math</span>.PI&nbsp;*&nbsp;<span class="js__num">2</span>,&nbsp;true);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fill();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ival&nbsp;=&nbsp;ival&nbsp;&#43;&nbsp;<span class="js__num">1</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.lineWidth&nbsp;=&nbsp;<span class="js__num">1</span>;&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;D<strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:calibri; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">raw
 Pie Char</strong><span style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">t</span><br style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<br style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<span style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">The same as for the Bar chart here I will calculate all the
 points and draw the pie chart using the &ldquo;arc&rdquo; method.</span></div>
</div>
<div><em></em>&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">using&nbsp;&ldquo;arc&rdquo;&nbsp;method.&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="js__operator">function</span>&nbsp;drawPieChart()&nbsp;&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;lastend&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;XvalPosition&nbsp;=&nbsp;xSpace;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chartWidth&nbsp;=&nbsp;(canvas.width&nbsp;/&nbsp;<span class="js__num">2</span>)&nbsp;-&nbsp;xSpace;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chartHeight&nbsp;=&nbsp;(canvas.height&nbsp;/&nbsp;<span class="js__num">2</span>)&nbsp;-&nbsp;(xSpace&nbsp;/&nbsp;<span class="js__num">2</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;widthcalculation&nbsp;=&nbsp;<span class="js__function">parseInt</span>(((<span class="js__function">parseInt</span>(chartWidth)&nbsp;-&nbsp;<span class="js__num">100</span>)&nbsp;/&nbsp;noOfPlots));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Draw&nbsp;Xaxis&nbsp;Line&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//--&nbsp;draw&nbsp;bar&nbsp;X-Axis&nbsp;and&nbsp;Y-Axis&nbsp;Line&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;XLineStartPosition&nbsp;=&nbsp;xSpace;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;yLineStartPosition&nbsp;=&nbsp;xSpace;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;yLineHeight&nbsp;=&nbsp;chartHeight;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;xLineWidth&nbsp;=&nbsp;chartWidth;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colorval&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;chartTotalResult&nbsp;=&nbsp;getChartTotal();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#cphBody_DropDownList1&nbsp;option'</span>).each(<span class="js__operator">function</span>&nbsp;()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillStyle&nbsp;=&nbsp;pirChartColor[colorval];&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.beginPath();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.moveTo(chartWidth,&nbsp;chartHeight);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Here&nbsp;we&nbsp;draw&nbsp;the&nbsp;each&nbsp;Pic&nbsp;Chart&nbsp;arc&nbsp;with&nbsp;values&nbsp;and&nbsp;size.&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.arc(chartWidth,&nbsp;chartHeight&nbsp;&#43;&nbsp;<span class="js__num">6</span>,&nbsp;chartHeight,&nbsp;lastend,&nbsp;lastend&nbsp;&#43;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="js__object">Math</span>.PI&nbsp;*&nbsp;<span class="js__num">2</span>&nbsp;*&nbsp;(<span class="js__function">parseInt</span>($(<span class="js__operator">this</span>).val())&nbsp;/&nbsp;chartTotalResult)),&nbsp;false);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.lineTo(chartWidth,&nbsp;chartHeight);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fill();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lastend&nbsp;&#43;=&nbsp;<span class="js__object">Math</span>.PI&nbsp;*&nbsp;<span class="js__num">2</span>&nbsp;*&nbsp;(<span class="js__function">parseInt</span>($(<span class="js__operator">this</span>).val())&nbsp;/&nbsp;chartTotalResult);&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//END&nbsp;Draw&nbsp;Bar&nbsp;Graph&nbsp;&nbsp;**************==================********************&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colorval&nbsp;=&nbsp;colorval&nbsp;&#43;&nbsp;<span class="js__num">1</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:calibri; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">Draw
 Donut Chart</strong><br style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<br style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<span style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">The same as for the Pie chart here I will calculate all the
 points and draw the Pie chart using the &ldquo;arc&rdquo; method. For the Donut chart to draw a donut shape we use the &ldquo;donutoutcircle&rdquo; and &ldquo;donutInnsercircle&rdquo; value. Here I will check for the Chart width and height I will draw the
 donut chart size.</span></div>
</div>
<div><em></em>&nbsp;</div>
<div>&nbsp;<img id="141401" src="141401-6.jpg" alt="" width="603" height="454"></div>
<div>&nbsp;</div>
<div>&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;drawDonutChart()&nbsp;&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;lastend&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;XvalPosition&nbsp;=&nbsp;xSpace;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chartWidth&nbsp;=&nbsp;(canvas.width&nbsp;/&nbsp;<span class="js__num">2</span>)&nbsp;-&nbsp;xSpace;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chartHeight&nbsp;=&nbsp;(canvas.height&nbsp;/&nbsp;<span class="js__num">2</span>)&nbsp;-&nbsp;(xSpace&nbsp;/&nbsp;<span class="js__num">2</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;widthcalculation&nbsp;=&nbsp;<span class="js__function">parseInt</span>(((<span class="js__function">parseInt</span>(chartWidth)&nbsp;-&nbsp;<span class="js__num">100</span>)&nbsp;/&nbsp;noOfPlots));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;donutOutercircle&nbsp;=&nbsp;chartHeight&nbsp;/&nbsp;<span class="js__num">2</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;donutinnersircle&nbsp;=&nbsp;(chartWidth&nbsp;/&nbsp;<span class="js__num">2</span>)&nbsp;&#43;&nbsp;xSpace;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colorval&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;chartTotalResult&nbsp;=&nbsp;getChartTotal();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;legend1&nbsp;=&nbsp;<span class="js__num">0</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#cphBody_DropDownList1&nbsp;option'</span>).each(<span class="js__operator">function</span>&nbsp;()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillStyle&nbsp;=&nbsp;pirChartColor[colorval];&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;legend1&nbsp;&#43;=&nbsp;(<span class="js__object">Math</span>.PI&nbsp;*&nbsp;<span class="js__num">2</span>&nbsp;*&nbsp;(<span class="js__function">parseInt</span>($(<span class="js__operator">this</span>).val())&nbsp;/&nbsp;chartTotalResult))&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//----&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.beginPath();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.moveTo(chartWidth,&nbsp;chartWidth);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.arc(chartWidth,&nbsp;chartWidth,&nbsp;donutOutercircle,&nbsp;lastend,&nbsp;legend1,&nbsp;false);&nbsp;<span class="js__sl_comment">//&nbsp;Outer:&nbsp;CCW&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.arc(chartWidth,&nbsp;chartWidth,&nbsp;donutinnersircle,&nbsp;legend1,&nbsp;lastend,&nbsp;true);&nbsp;<span class="js__sl_comment">//&nbsp;Inner:&nbsp;CW&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//------&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fill();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lastend&nbsp;&#43;=&nbsp;<span class="js__object">Math</span>.PI&nbsp;*&nbsp;<span class="js__num">2</span>&nbsp;*&nbsp;(<span class="js__function">parseInt</span>($(<span class="js__operator">this</span>).val())&nbsp;/&nbsp;chartTotalResult);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//END&nbsp;Draw&nbsp;Bar&nbsp;Graph&nbsp;&nbsp;**************==================********************&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colorval&nbsp;=&nbsp;colorval&nbsp;&#43;&nbsp;<span class="js__num">1</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:calibri; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">Draw
 Bubble Chart</strong><br style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<br style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<span style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">The same as for the Line chart we draw the Bubble chart but
 here use the &quot;arc&rdquo; method to draw our circle for each item.</span></div>
</div>
<div><em></em>&nbsp;<img id="141402" src="141402-4.jpg" alt="" width="570" height="410"></div>
<div><em></em>&nbsp;</div>
<div><em></em>&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;to&nbsp;Draw&nbsp;Bubble&nbsp;Chart&nbsp;&nbsp;</span>&nbsp;
&nbsp;<span class="js__operator">function</span>&nbsp;drawBubbleChart()&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;***************&nbsp;To&nbsp;Draw&nbsp;the&nbsp;Line&nbsp;Dot&nbsp;Cericle&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.globalAlpha&nbsp;=&nbsp;<span class="js__num">0.8</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//For&nbsp;Outer&nbsp;Blue&nbsp;Dot&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;bubbleSize&nbsp;=&nbsp;<span class="js__num">40</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ival&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#cphBody_DropDownList1&nbsp;option'</span>).each(<span class="js__operator">function</span>&nbsp;()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fillStyle&nbsp;=&nbsp;pirChartColor[ival];&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.strokeStyle&nbsp;=&nbsp;pirChartColor[ival];&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.beginPath();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.arc(getXPlotvalue(ival)&nbsp;&#43;&nbsp;<span class="js__num">14</span>,&nbsp;getYPlotVale($(<span class="js__operator">this</span>).val()),&nbsp;bubbleSize,&nbsp;bubbleSize,&nbsp;<span class="js__object">Math</span>.PI&nbsp;*&nbsp;<span class="js__num">2</span>,&nbsp;true);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.fill();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ival&nbsp;=&nbsp;ival&nbsp;&#43;&nbsp;<span class="js__num">1</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.lineWidth&nbsp;=&nbsp;<span class="js__num">1</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:calibri; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">Save
 Chart</strong><br style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<br style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<span style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">In the save method first I will check for the browser version.
 If the browser is not IE (that means Chrome or Firefox) then using the &ldquo;canvas.toDataURL&rdquo; method I will save the image. Because this method will not work in Internet Explorer. For Internet Explorer use the Ajax post method. I will save the image.</span>&nbsp;</div>
<div><em></em>&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;ShanuSaveImage()&nbsp;&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;m&nbsp;=&nbsp;confirm(<span class="js__string">&quot;Are&nbsp;you&nbsp;sure&nbsp;to&nbsp;Save&nbsp;&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(m)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(navigator.appName&nbsp;==&nbsp;<span class="js__string">'Microsoft&nbsp;Internet&nbsp;Explorer'</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;image_NEW&nbsp;=&nbsp;document.getElementById(<span class="js__string">&quot;canvas&quot;</span>).toDataURL(<span class="js__string">&quot;image/png&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;image_NEW&nbsp;=&nbsp;image_NEW.replace(<span class="js__string">'data:image/png;base64,'</span>,&nbsp;<span class="js__string">''</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.ajax(<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;<span class="js__string">'POST'</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;contentType:&nbsp;<span class="js__string">'application/json;&nbsp;charset=utf-8'</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;<span class="js__string">'/shanuHTML5PIEChart.aspx/SaveImage'</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data:&nbsp;<span class="js__string">'{&nbsp;&quot;imageData&quot;&nbsp;:&nbsp;&quot;'</span>&nbsp;&#43;&nbsp;image_NEW&nbsp;&#43;&nbsp;<span class="js__string">'&quot;&nbsp;}'</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;async:&nbsp;false,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;success:&nbsp;<span class="js__operator">function</span>&nbsp;(msg)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(msg.d);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;error:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Pie&nbsp;Chart&nbsp;Not&nbsp;Saved&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;save&nbsp;image&nbsp;without&nbsp;file&nbsp;type&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;canvas&nbsp;=&nbsp;document.getElementById(<span class="js__string">&quot;canvas&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.location.href&nbsp;=&nbsp;canvas.toDataURL(<span class="js__string">&quot;image/png&quot;</span>).replace(<span class="js__string">&quot;image/png&quot;</span>,&nbsp;<span class="js__string">&quot;image/octet-stream&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;ImageSave&nbsp;=&nbsp;document.createElement(<span class="js__string">'a'</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageSave.download&nbsp;=&nbsp;<span class="js__string">&quot;shanuPIEImage.png&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageSave.href&nbsp;=&nbsp;canvas.toDataURL(<span class="js__string">&quot;image/png&quot;</span>).replace(<span class="js__string">&quot;image/png&quot;</span>,&nbsp;<span class="js__string">&quot;image/octet-stream&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageSave.click();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Image&nbsp;Saved&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;&nbsp;</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<div><em>
<div style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
We can use the same logic to create Windows Forms Chart Controls. For example you can see my Pareto Chart control that was created for Windows Forms version at the following link:<br style="outline:0px">
<br style="outline:0px">
<a href="http://www.c-sharpcorner.com/UploadFile/asmabegam/pareto-chart-in-C-Sharp/" target="_blank" style="outline:0px; text-decoration:none">http://www.c-sharpcorner.com/UploadFile/asmabegam/pareto-chart-in-C-Sharp/</a><span class="Apple-converted-space">&nbsp;</span><br style="outline:0px">
<br style="outline:0px">
Working with HTML5 is really fun. I hope you enjoyed reading my article. I will be happy if someone benefits from my article.<br style="outline:0px">
<br style="outline:0px">
<strong style="outline:0px">Tested Browsers:&nbsp;</strong></div>
<div style="font:14px/21px calibri; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<ol style="outline:0px">
<li style="outline:0px">Chrome&nbsp; </li><li style="outline:0px">Firefox </li><li style="outline:0px">IE10 </li></ol>
</div>
</em></div>
