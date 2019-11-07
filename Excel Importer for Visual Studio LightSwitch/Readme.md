# Excel Importer for Visual Studio LightSwitch
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Silverlight
- Visual Studio LightSwitch
- LightSwitch Extensibility
## Topics
- Rapid Application Development
## Updated
- 02/28/2012
## Description

<p><strong>Update</strong>: The Excel importer will now allow CSV files to be imported&nbsp;from LightSwitch web applications.&nbsp;</p>
<h2>Introduction</h2>
<p><strong>Excel Importer is a Visual Studio LightSwitch Extension</strong>.&nbsp; The extension will add the ability to import data from Microsoft Excel to Visual Studio LightSwitch applications.&nbsp; The importer can validate the data that is being imported
 and will even import data across relationships.&nbsp;</p>
<h2>Getting Started</h2>
<p>To install and use the extension in your LightSwitch applications, unzip the ExcelImporter zip file into your Visual Studio Projects directory (My Documents\Visual Studio 2010\Projects) and double-click on the ExcelImporter.vsix package located in the Binaries
 folder. You only need <a href="http://msdn.com/lightswitch">LightSwitch</a>&nbsp;installed to use the Excel Importer.</p>
<p>In order to build the extension sample code, Visual Studio 2010 Professional, <a href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=75568aa6-8107-475d-948a-ef22627e57a5&displaylang=en" target="_blank">
Service Pack 1</a>, the<a href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=21307c23-f0ff-4ef2-a0a4-dca54ddb1e21" target="_blank"> Visual Studio SDK
</a>and <a href="http://msdn.com/lightswitch">LightSwitch </a>are required.&nbsp; Unzip the ExcelImporter zip file into your Visual Studio Projects directory (My Documents\Visual Studio 2010\Projects) and open the ExcelImpoter.sln solution.</p>
<h2>Building the Sample</h2>
<p>To build the sample, make sure that the ExcelImporter solution is open and then use the Build | Build Solution menu command.</p>
<h2>Running the Sample</h2>
<p>To run the sample, navigate to the Vsix\Bin\Debug or the Vsix\Bin\Release folder.&nbsp; Double click the ExcelImporter.Vsix package.&nbsp; This will install the extension on your machine.&nbsp;</p>
<p>Create a new LightSwitch application.&nbsp; Double click on the Properties node underneath the application in Solution Explorer.&nbsp; Select Extensions and check off LightSwitch Utilities.&nbsp; This will enable the extension for your application.</p>
<p><img src="45119-extensionproperties.png" alt="" width="618" height="221"></p>
<p><img alt=""></p>
<h2>Using the Excel Importer</h2>
<p>In your application, add a screen for some table.&nbsp; For example, create a Table called Customer with a single String property called Name. Add a new Editable Grid screen for Customers.&nbsp; Create a new button for the screen called ImportfromExcel.&nbsp;
 In the button's code, call ExcelImporter.Importer.ImportFromExcel, passing in the screen collection you'd like to import data from.</p>
<p>Run the application and hit the Import From Excel button.&nbsp; This should prompt you&nbsp;to select an Excel file.&nbsp; This Excel file must be located in the Documents directory due to Silverlight limitations.&nbsp; The Excel file's first row should
 identify each column of data with Title.&nbsp;&nbsp;These titles will be displayed in the LightSwitch application to allow you to map them to properties on the corresponding LightSwitch table.</p>
<p><strong>For more details, please see <a class="internal-link x_x_x_x_x_x_x_x_x_x_x_x_view-post" href="http://blogs.msdn.com/b/lightswitch/archive/2011/04/13/how-to-import-data-from-excel.aspx">
How to Import Data from Excel Using the Excel Import Extension</a></strong></p>
<p>For more information on how to develop your own extensions for the community please see the
<a href="http://msdn.microsoft.com/en-us/library/ee256689.aspx" target="_blank">Visual Studio LightSwitch 2011 Extensibility Toolkit</a>. And please ask questions in the
<a href="http://social.msdn.microsoft.com/Forums/en-US/lsextensibility/threads" target="_blank">
LightSwitch Extensibility forum</a>.</p>
