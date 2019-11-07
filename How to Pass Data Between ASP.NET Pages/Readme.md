# How to Pass Data Between ASP.NET Pages
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- ASP.NET Web Forms
## Topics
- Controls
- User Interface
- Navigation
- ASP.NET Code Sample Downloads
## Updated
- 01/18/2012
## Description

<h1>Introduction</h1>
<p>A Visual Studio Project which demonstrates several ways to pass data from one ASP.NET Web Forms page to another one. For related MSDN documentation, see
<a href="http://msdn.microsoft.com/en-us/library/6c3yckfw.aspx">How to: Pass Values Between ASP.NET Web Pages</a>.</p>
<h1>Getting Started</h1>
<p>To build and run this sample, you must have Visual Studio 2010 installed. Unzip the PassingData.zip file into your Visual Studio Projects directory (My Documents\Visual Studio 2010\Projects) and open the PassingData.sln solution.</p>
<h1>Building the Sample</h1>
<p>To build the sample, use the Build | Build Solution menu command.</p>
<h1>Running the Sample</h1>
<p>To run the sample, hit F5 or choose the Debug | Start Debugging menu command. The Default.aspx page, which functions as the Source Page is displayed. The page has a text box and several buttons, each of which uses a different method to pass whatever value
 is in the text box to another page.</p>
<p><img src="19063-sourcepage.png" alt="" width="313" height="367"></p>
<p>When you click one of the buttons, control transfers to the selected page, and that page displays whatever value was entered in the text box.</p>
<p><img src="19064-querystringpage.png" alt="" width="403" height="185"></p>
<h1>Source Code Overview</h1>
<p>The source code in this sample demonstrates several techniques you can use to pass data from page to page, as described in the button labels shown in the
<strong>Running the Sample</strong> section. For example, to see how to pass data using a query string, you would look at the code for that button in Default.aspx and its code-behind file, and in QueryStringPage.aspx and its code-behind file.</p>
<h1>Project Files</h1>
<ul>
<li>Default.aspx (the Source Page) </li><li>QueryStringPage.aspx </li><li>HttpPostPage.aspx </li><li>SessionStatePage.aspx&nbsp; </li><li>PublicPropertiesPage.aspx </li><li>ControlInfoPage.aspx </li></ul>
