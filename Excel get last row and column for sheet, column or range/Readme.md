# Excel get last row and column for sheet, column or range
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- Excel
## Topics
- C#
- Excel
- Excel Automation
- Class Library
- Data Access
- Automation
- How to
- Classes
## Updated
- 02/17/2016
## Description

<h1>Description</h1>
<p><span style="font-size:small">For those who don&rsquo;t work much with Excel many times find themselves at a lost to query ranges within an Excel file to learn what the last used row/column are in a worksheet, last used row in a range which is part of a
 worksheet e.g. A1:B20. These samples show how to accomplish these task along with memory management of objected used to get the information we are after. I did a similar
<a href="https://code.msdn.microsoft.com/Excel-get-used-rows-and-15b43cb7">code sample for vb.net
</a>here which is the same topic but different methods.</span><br>
<br>
<span style="font-size:small">Actually getting used rows and columns is not all that difficult for those developers savvy using Excel automation but to the novice not so easy yet once you have studied the code it will become clear.</span><br>
<br>
<span style="font-size:small">Important, all the methods shown focus on getting used rows and columns but in an actual application we are not there simply to get last row and column but to use them in a larger task. With that said it&rsquo;s imperative to follow
 these guide lines when integrating these samples into your code. So integrating is the key here, inserting these methods and making sure they are created and released properly</span><br>
<br>
<span style="font-size:small">First, we create objects top down meaning we start at the application level, move down to ranges then cells and work with items.</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">Excel.Application xlApp = null;
Excel.Workbooks xlWorkBooks = null;
Excel.Workbook xlWorkBook = null;
Excel.Worksheet xlWorkSheet = null;
Excel.Sheets xlWorkSheets = null;

xlApp = new Excel.Application();
xlApp.DisplayAlerts = false;

xlWorkBooks = xlApp.Workbooks;
xlWorkBook = xlWorkBooks.Open(fileName);

xlApp.Visible = false;

xlWorkSheets = xlWorkBook.Sheets;</pre>
<div class="preview">
<pre class="js">Excel.Application&nbsp;xlApp&nbsp;=&nbsp;null;&nbsp;
Excel.Workbooks&nbsp;xlWorkBooks&nbsp;=&nbsp;null;&nbsp;
Excel.Workbook&nbsp;xlWorkBook&nbsp;=&nbsp;null;&nbsp;
Excel.Worksheet&nbsp;xlWorkSheet&nbsp;=&nbsp;null;&nbsp;
Excel.Sheets&nbsp;xlWorkSheets&nbsp;=&nbsp;null;&nbsp;
&nbsp;
xlApp&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Excel.Application();&nbsp;
xlApp.DisplayAlerts&nbsp;=&nbsp;false;&nbsp;
&nbsp;
xlWorkBooks&nbsp;=&nbsp;xlApp.Workbooks;&nbsp;
xlWorkBook&nbsp;=&nbsp;xlWorkBooks.Open(fileName);&nbsp;
&nbsp;
xlApp.Visible&nbsp;=&nbsp;false;&nbsp;
&nbsp;
xlWorkSheets&nbsp;=&nbsp;xlWorkBook.Sheets;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Next we drill down into a specific sheet.</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">for (int x = 1; x &lt;= xlWorkSheets.Count; x&#43;&#43;)
{
    xlWorkSheet = (Excel.Worksheet)xlWorkSheets[x];


    if (xlWorkSheet.Name == sheetName)
    {
        

        break;
    }

    Marshal.FinalReleaseComObject(xlWorkSheet);
    xlWorkSheet = null;

}</pre>
<div class="preview">
<pre class="js"><span class="js__statement">for</span>&nbsp;(int&nbsp;x&nbsp;=&nbsp;<span class="js__num">1</span>;&nbsp;x&nbsp;&lt;=&nbsp;xlWorkSheets.Count;&nbsp;x&#43;&#43;)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xlWorkSheet&nbsp;=&nbsp;(Excel.Worksheet)xlWorkSheets[x];&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(xlWorkSheet.Name&nbsp;==&nbsp;sheetName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Marshal.FinalReleaseComObject(xlWorkSheet);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xlWorkSheet&nbsp;=&nbsp;null;&nbsp;
&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Once finished with our objects they are released in reverse order they were created e.g.</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">for (int x = 1; x &lt;= xlWorkSheets.Count; x&#43;&#43;)
{
    xlWorkSheet = (Excel.Worksheet)xlWorkSheets[x];


    if (xlWorkSheet.Name == sheetName)
    {
        
        Excel.Range workRange = xlWorkSheet.get_Range(startCell,endCell);

		//  . . . 
        cellAddress = resultRange.Address;

        Marshal.FinalReleaseComObject(workRange);
        workRange = null;

        Marshal.FinalReleaseComObject(resultRange);
        resultRange = null;

        break;
    }

    Marshal.FinalReleaseComObject(xlWorkSheet);
    xlWorkSheet = null;

}
xlWorkBook.Close();
xlApp.UserControl = true;
xlApp.Quit();

Release(xlWorkSheets);
Release(xlWorkSheet);
Release(xlWorkBook);
Release(xlWorkBooks);
Release(xlApp);
</pre>
<div class="preview">
<pre class="js"><span class="js__statement">for</span>&nbsp;(int&nbsp;x&nbsp;=&nbsp;<span class="js__num">1</span>;&nbsp;x&nbsp;&lt;=&nbsp;xlWorkSheets.Count;&nbsp;x&#43;&#43;)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xlWorkSheet&nbsp;=&nbsp;(Excel.Worksheet)xlWorkSheets[x];&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(xlWorkSheet.Name&nbsp;==&nbsp;sheetName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Excel.Range&nbsp;workRange&nbsp;=&nbsp;xlWorkSheet.get_Range(startCell,endCell);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;&nbsp;.&nbsp;.&nbsp;.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellAddress&nbsp;=&nbsp;resultRange.Address;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Marshal.FinalReleaseComObject(workRange);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;workRange&nbsp;=&nbsp;null;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Marshal.FinalReleaseComObject(resultRange);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultRange&nbsp;=&nbsp;null;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Marshal.FinalReleaseComObject(xlWorkSheet);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xlWorkSheet&nbsp;=&nbsp;null;&nbsp;
&nbsp;
<span class="js__brace">}</span>&nbsp;
xlWorkBook.Close();&nbsp;
xlApp.UserControl&nbsp;=&nbsp;true;&nbsp;
xlApp.Quit();&nbsp;
&nbsp;
Release(xlWorkSheets);&nbsp;
Release(xlWorkSheet);&nbsp;
Release(xlWorkBook);&nbsp;
Release(xlWorkBooks);&nbsp;
Release(xlApp);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Note the method Release, there are many pumutations out there on the web, this is my version which first asserts that we have a valid object being passed in and if so destroy it. The catch part of the
 try is a last ditch effort to destroy the object. The thing here is we don't want to raise an exception when attempting to dispose of the third object of five as if an exception is raised we leave the objects hanging and can only be disposed of by Task Manager
 or restarting the computer. &nbsp;</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void Release(object sender)
{
    try
    {
        if (sender != null)
        {
            Marshal.ReleaseComObject(sender);
            sender = null;
        }
    }
    catch (Exception)
    {
        sender = null;
    }
}</pre>
<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;Release(object&nbsp;sender)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(sender&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Marshal.ReleaseComObject(sender);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sender&nbsp;=&nbsp;null;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sender&nbsp;=&nbsp;null;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Next important thing is, and this can be debated yet out of many operations with Excel and .NET Framework the following has failed twice and both times where in samples I have done here, not in projects.</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">Myself and another .NET developer wrote an article as follows&nbsp;<a href="http://www.siddharthrout.com/2012/08/06/vb-net-two-dot-rule-when-working-with-office-applications-2/">The Two Dots Rule</a>.
 The author mentions kevininstructor, that is my old MSDN handle. I would highly suggest reading this article.</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">So now down to the samples</span></div>
<div class="endscriptcode" style="padding-left:30px"><span style="font-size:small">UsedRowsColumns method will return the last used row and column for a worksheet. The key here is to use SpecialCells to return the last row and colum. This is the easiest of
 the three methods and most common found on the web. I use a class instance to return row and column.</span></div>
<div class="endscriptcode" style="padding-left:30px"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode" style="padding-left:30px"></div>
<div class="endscriptcode" style="padding-left:30px"><span style="font-size:small">LastColumnForRow, this one does not want to release memory, one range refuses to release and the only way out is to call the .NET Gargbage collector or perhaps not. What I
 mean is, if the task you are working on is done one or a handful of times once you close the application all memory is released then but if you need to call this method many times then you should consider calling the GC. In the demo project I allow you to
 try calling the method with and without the GC.</span></div>
<div class="endscriptcode" style="padding-left:30px"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode" style="padding-left:30px"></div>
<div class="endscriptcode" style="padding-left:30px"><span style="font-size:small">The tuff one was getting the last used row in a range of cells within a worksheet, this is done in the method LastRowInRange. Have not seen anyone ask for this but a handful
 of times but felt compelled to include it.</span></div>
<div class="endscriptcode" style="padding-left:30px"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode" style="padding-left:30px"></div>
<div class="endscriptcode" style="padding-left:30px"><span style="font-size:small">The tuff part was my brain refusing to use a method
<a href="https://msdn.microsoft.com/en-us/library/microsoft.office.tools.excel.worksheet.get_range%28v=vs.120%29.aspx?f=255&MSPPError=-2147217396">
get_range</a> simply because it does not show up in the members list of a range object. Once past this it was easy, did some research and found the
<a href="https://msdn.microsoft.com/en-us/library/microsoft.office.interop.excel.range.find.aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-1">
Find method</a> was the key.</span></div>
<div class="endscriptcode" style="padding-left:30px"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode" style="padding-left:30px"></div>
<div class="endscriptcode"><span style="font-size:small">All of the methods above have been placed into a class project so if needed to be used they can be easily placed into your solution but as mentioned above at the start more likely than not these methods
 will need to be folded into your solution/projects.</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small"><span style="text-decoration:underline">IMPORTANT</span>:</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"><span style="font-size:small">When building the solution you need Excel installed and your version may be different than mine, if so the build will fail and you will need to remove the references and add in one for your version
 of Excel.</span></div>
<div class="endscriptcode" style="padding-left:30px"></div>
<div class="endscriptcode" style="padding-left:30px"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
</div>
</div>
</div>
