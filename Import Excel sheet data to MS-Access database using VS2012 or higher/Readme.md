# Import Excel sheet data to MS-Access database using VS2012 or higher
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Excel
- Data Access
- Access
## Topics
- Excel
- Data Access
## Updated
- 08/11/2014
## Description

<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p><span style="font-size:small">This article contains a sample project which shows how to import sheet data from an Microsoft Excel file into a Microsoft Access database using OleDb managed data provider. There are two projects, one a class project which contains
 functionality to do the import operation while the windows form project uses classes in the class project to do the import operation.</span></p>
<p><span style="font-size:small">By placing all the functionality into the class project means you can add this project to another solution to use the import operations. Alternately keep the class project in one location and when needed add the compiled DLL
 into another project.</span></p>
<p><span style="font-size:small">At the core of the import is really a simple SQL statement but to keep things in check this statement is wrapped into a class and this class uses two other classes to setup for the import operation. Simple usage, create an instance
 of the import class (see code block below which is two lines of code), setup several properties then execute the run method, done.</span></p>
<p><span style="font-size:small">There are several features to be aware of. First by default if the table already exists in the target Microsoft Access database we exit the process as by continuing this would raise an exception. To override this behavior set
 the property OverWriteExisting = True.</span></p>
<p><span style="font-size:small">There is a utility class in the class project which has some functions that may also be useful in other projects such as DropTable which if the table exists will drop it from the database. AccessTableNames returns a list of
 tables in the Microsoft Access database. AccessTableExists determines if a table exists in a Microsoft Access database.</span></p>
<p><span style="font-size:small">Run the solution, press the top button, Excel data is imported, press a second time and the operation will not complete as the table exists. Now press the bottom button and it will overwrite the table in the database.</span></p>
<p><span style="font-size:small">Note 1: I hard coded the table name in the code rather than making it dynamic from a TextBox but of course you are free to change this.</span></p>
<p><span style="font-size:small">Note 2: All rows are imported from the Excel sheet but you could easily add a WHERE condition which will take a tiny bit more code/logic. I did not because that would simply make the learning experience more difficult.</span></p>
<p><span style="font-size:small">Note 3: If using C#&nbsp;the class project&nbsp;will work, all you need to do is setup no different than the code shown below&nbsp;</span></p>
<p><em>&nbsp;&nbsp;&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">using ExcelToAccessLib;
using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string AccessFile = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, &quot;Database1.accdb&quot;);

        private string ExcelFile = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, &quot;Customers.xlsx&quot;);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Importer ImportData =
                new Importer(
                    new ExcelInfo
                    {
                        FileName = ExcelFile,
                        HasHeaders = true,
                        SheetName = &quot;Customers&quot;
                    },
                    new AccessInfo
                    {
                        FileName = AccessFile,
                        TableName = &quot;Customers1&quot;,
                        FieldNames = &quot;CompanyName,ContactName&quot;
                    });

            if (ImportData.Run())
            {
                MessageBox.Show(&quot;Import complete&quot;);
            }
        }
    }
}</pre>
<pre class="hidden">Dim ImportData As New Importer(
    New ExcelInfo With
        {
            .FileName = ExcelFile,
            .HasHeaders = True,
            .SheetName = &quot;Customers&quot;
        },
    New AccessInfo With
        {
            .FileName = AccessFile,
            .TableName = &quot;Customers3a&quot;,
            .FieldNames = &quot;CompanyName,ContactName&quot;
        }
    )

ImportData.Run()</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;ExcelToAccessLib;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.IO;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Windows.Forms;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;WindowsFormsApplication1&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;Form1&nbsp;:&nbsp;Form&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;AccessFile&nbsp;=&nbsp;Path.Combine(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AppDomain.CurrentDomain.BaseDirectory,&nbsp;<span class="cs__string">&quot;Database1.accdb&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ExcelFile&nbsp;=&nbsp;Path.Combine(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AppDomain.CurrentDomain.BaseDirectory,&nbsp;<span class="cs__string">&quot;Customers.xlsx&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Form1()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Importer&nbsp;ImportData&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;Importer(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;ExcelInfo&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileName&nbsp;=&nbsp;ExcelFile,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HasHeaders&nbsp;=&nbsp;<span class="cs__keyword">true</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SheetName&nbsp;=&nbsp;<span class="cs__string">&quot;Customers&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;AccessInfo&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileName&nbsp;=&nbsp;AccessFile,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TableName&nbsp;=&nbsp;<span class="cs__string">&quot;Customers1&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FieldNames&nbsp;=&nbsp;<span class="cs__string">&quot;CompanyName,ContactName&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ImportData.Run())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Import&nbsp;complete&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span><img id="122558" src="122558-121212.png" alt="" width="399" height="495"></span></h1>
<p><img id="122559" src="122559-sol.png" alt="" width="353" height="519"></p>
<h1><em>&nbsp;</em></h1>
