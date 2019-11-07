# Insert, Update, Delete data in LINQ to SQL through DataGridView
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- C#
- LINQ to SQL
- LINQ
- Windows Forms
- .NET Framework
- DataGridView
- C# Language
- Visual C#
- Visual Studio 2012
- .NET 4.5
## Topics
- C#
- LINQ to SQL
- LINQ
- Windows Forms
- Visual Studio
- DataGridView
- desktop
- Button
- Visual Studio 2012
- CRUD
## Updated
- 01/31/2015
## Description

<p><strong>Introduction:</strong></p>
<p><strong>Today in this article(code sample) I will show you how to in insert, update, delete, display data in LINQ To SQL through DataGridView.</strong><strong>&nbsp;</strong></p>
<p>What problem does the sample solve ?</p>
<p>Ans:Sometimes we need to insert , delete, update record(data) we need GUI &nbsp;form to insert the data and also for update and deleting the data.For doing this we have to make three GUI for our CRUD operations and this is difficult task for the users who
 will use the application. So what is the solution for solving it. Here is the solution. In this code sample we will insert , update,delete data from a single GUI that is called DataGridView. This is easy approach for the user where he/she can operate his CRUD
 operations from a single GUI.</p>
<p>&nbsp;</p>
<p>Start</p>
<ul>
<li>Open your visual studio make new Windows Forms project&nbsp; with any name. </li><li>&nbsp;Then open server explorer the make a new database with some name and make a new table add some columns in the table.
</li><li>Then open your project and go in to solution explorer and right click on the project and then click add new item.
</li><li>There search LINQ-To-SQL and add this file and press ok button. </li><li>Then you will see a blank file there on that file you will drag your table in the sql server database file on to the LINQ-To-SQL .dbml file extension.
</li></ul>
<p>&nbsp;</p>
<p>Diagram:</p>
<p><img id="133239" src="133239-linq-to-sql.jpg" alt="" width="624" height="354"></p>
<p>Insert Data:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">  private void SaveButton_Click(object sender, EventArgs e)
        {
            StudentDataClasses1DataContext SDCD1 = new StudentDataClasses1DataContext(@&quot;Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\ehtesham mehmood\documents\visual studio 2012\Projects\FP1\FP1\abc.mdf;Integrated Security=True;Connect Timeout=30&quot;);
            StudentInfo SI = new StudentInfo();
            int rowindex = dataGridView1.CurrentRow.Index;  // here rowindex will get through currentrow property of datagridview.

            SI.Id = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[0].Value);
            SI.Name = Convert.ToString(dataGridView1.Rows[rowindex].Cells[1].Value);
            SI.Marks = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[2].Value);

            SI.Grade = Convert.ToString(dataGridView1.Rows[rowindex].Cells[3].Value);

            SDCD1.StudentInfos.InsertOnSubmit(SI);//InsertOnSubmit queries will automatic call thats the data context class handle it.
            SDCD1.SubmitChanges();
            MessageBox.Show(&quot;Saved&quot;);
            rowindex = 0;
        }
</pre>
<div class="preview">
<pre class="js">&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;SaveButton_Click(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StudentDataClasses1DataContext&nbsp;SDCD1&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;StudentDataClasses1DataContext(@<span class="js__string">&quot;Data&nbsp;Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\ehtesham&nbsp;mehmood\documents\visual&nbsp;studio&nbsp;2012\Projects\FP1\FP1\abc.mdf;Integrated&nbsp;Security=True;Connect&nbsp;Timeout=30&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StudentInfo&nbsp;SI&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;StudentInfo();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;rowindex&nbsp;=&nbsp;dataGridView1.CurrentRow.Index;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;here&nbsp;rowindex&nbsp;will&nbsp;get&nbsp;through&nbsp;currentrow&nbsp;property&nbsp;of&nbsp;datagridview.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SI.Id&nbsp;=&nbsp;Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[<span class="js__num">0</span>].Value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SI.Name&nbsp;=&nbsp;Convert.ToString(dataGridView1.Rows[rowindex].Cells[<span class="js__num">1</span>].Value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SI.Marks&nbsp;=&nbsp;Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[<span class="js__num">2</span>].Value);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SI.Grade&nbsp;=&nbsp;Convert.ToString(dataGridView1.Rows[rowindex].Cells[<span class="js__num">3</span>].Value);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SDCD1.StudentInfos.InsertOnSubmit(SI);<span class="js__sl_comment">//InsertOnSubmit&nbsp;queries&nbsp;will&nbsp;automatic&nbsp;call&nbsp;thats&nbsp;the&nbsp;data&nbsp;context&nbsp;class&nbsp;handle&nbsp;it.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SDCD1.SubmitChanges();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="js__string">&quot;Saved&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowindex&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>Delete Data:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void button1_Click(object sender, EventArgs e)
        {
            int iid = 0;
            StudentDataClasses1DataContext SDCD1 = new StudentDataClasses1DataContext(@&quot;Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\ehtesham mehmood\documents\visual studio 2012\Projects\FP1\FP1\abc.mdf;Integrated Security=True;Connect Timeout=30&quot;);
            StudentInfo SI = new StudentInfo();
            int rowindex = dataGridView1.CurrentRow.Index;  // here rowindex will get through currentrow property of datagridview.
            iid = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[0].Value);
            var delete = from p in SDCD1.StudentInfos
                         where p.Id == iid// match the ecords.
                         select p;
            SDCD1.StudentInfos.DeleteAllOnSubmit(delete);// DeleteAllOnSubmit function will call and queries will automatic call thats the data context class handle it.
            SDCD1.SubmitChanges();
         //   SI = SDCD1.StudentInfos.Single(c =&gt; c.Id == iid);   
            rowindex = 0;

            MessageBox.Show(&quot;deleted&quot;);
            Refresh();

        }
</pre>
<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;button1_Click(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;iid&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StudentDataClasses1DataContext&nbsp;SDCD1&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;StudentDataClasses1DataContext(@<span class="js__string">&quot;Data&nbsp;Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\ehtesham&nbsp;mehmood\documents\visual&nbsp;studio&nbsp;2012\Projects\FP1\FP1\abc.mdf;Integrated&nbsp;Security=True;Connect&nbsp;Timeout=30&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StudentInfo&nbsp;SI&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;StudentInfo();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;rowindex&nbsp;=&nbsp;dataGridView1.CurrentRow.Index;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;here&nbsp;rowindex&nbsp;will&nbsp;get&nbsp;through&nbsp;currentrow&nbsp;property&nbsp;of&nbsp;datagridview.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iid&nbsp;=&nbsp;Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[<span class="js__num">0</span>].Value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;<span class="js__operator">delete</span>&nbsp;=&nbsp;from&nbsp;p&nbsp;<span class="js__operator">in</span>&nbsp;SDCD1.StudentInfos&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;p.Id&nbsp;==&nbsp;iid//&nbsp;match&nbsp;the&nbsp;ecords.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;p;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SDCD1.StudentInfos.DeleteAllOnSubmit(<span class="js__operator">delete</span>);<span class="js__sl_comment">//&nbsp;DeleteAllOnSubmit&nbsp;function&nbsp;will&nbsp;call&nbsp;and&nbsp;queries&nbsp;will&nbsp;automatic&nbsp;call&nbsp;thats&nbsp;the&nbsp;data&nbsp;context&nbsp;class&nbsp;handle&nbsp;it.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SDCD1.SubmitChanges();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;&nbsp;&nbsp;SI&nbsp;=&nbsp;SDCD1.StudentInfos.Single(c&nbsp;=&gt;&nbsp;c.Id&nbsp;==&nbsp;iid);&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowindex&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="js__string">&quot;deleted&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Refresh();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>Update Data:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void button2_Click(object sender, EventArgs e)
        {
            int iid = 0;
            StudentDataClasses1DataContext SDCD1 = new StudentDataClasses1DataContext(@&quot;Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\ehtesham mehmood\documents\visual studio 2012\Projects\FP1\FP1\abc.mdf;Integrated Security=True;Connect Timeout=30&quot;);
            StudentInfo SI = new StudentInfo();
            int rowindex = dataGridView1.CurrentRow.Index;   // here rowindex will get through currentrow property of datagridview.
            iid = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[0].Value);
            var update = from s1 in SDCD1.StudentInfos
                         where s1.Id == iid
                         select s1;
            foreach (var v in update)
            {
                v.Id = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[0].Value);
                v.Name = Convert.ToString(dataGridView1.Rows[rowindex].Cells[1].Value);
                v.Marks = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[2].Value);
                v.Grade = Convert.ToString(dataGridView1.Rows[rowindex].Cells[3].Value);
            SDCD1.SubmitChanges(); // here will submitchanges function call and queries will automatic call.
            }
            MessageBox.Show(&quot;Updated&quot;);
            Refresh();// refresh the data gridview.

        }
</pre>
<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;button2_Click(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;iid&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StudentDataClasses1DataContext&nbsp;SDCD1&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;StudentDataClasses1DataContext(@<span class="js__string">&quot;Data&nbsp;Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\ehtesham&nbsp;mehmood\documents\visual&nbsp;studio&nbsp;2012\Projects\FP1\FP1\abc.mdf;Integrated&nbsp;Security=True;Connect&nbsp;Timeout=30&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StudentInfo&nbsp;SI&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;StudentInfo();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;rowindex&nbsp;=&nbsp;dataGridView1.CurrentRow.Index;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;here&nbsp;rowindex&nbsp;will&nbsp;get&nbsp;through&nbsp;currentrow&nbsp;property&nbsp;of&nbsp;datagridview.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iid&nbsp;=&nbsp;Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[<span class="js__num">0</span>].Value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;update&nbsp;=&nbsp;from&nbsp;s1&nbsp;<span class="js__operator">in</span>&nbsp;SDCD1.StudentInfos&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;s1.Id&nbsp;==&nbsp;iid&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;s1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(<span class="js__statement">var</span>&nbsp;v&nbsp;<span class="js__operator">in</span>&nbsp;update)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;v.Id&nbsp;=&nbsp;Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[<span class="js__num">0</span>].Value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;v.Name&nbsp;=&nbsp;Convert.ToString(dataGridView1.Rows[rowindex].Cells[<span class="js__num">1</span>].Value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;v.Marks&nbsp;=&nbsp;Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[<span class="js__num">2</span>].Value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;v.Grade&nbsp;=&nbsp;Convert.ToString(dataGridView1.Rows[rowindex].Cells[<span class="js__num">3</span>].Value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SDCD1.SubmitChanges();&nbsp;<span class="js__sl_comment">//&nbsp;here&nbsp;will&nbsp;submitchanges&nbsp;function&nbsp;call&nbsp;and&nbsp;queries&nbsp;will&nbsp;automatic&nbsp;call.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="js__string">&quot;Updated&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Refresh();<span class="js__sl_comment">//&nbsp;refresh&nbsp;the&nbsp;data&nbsp;gridview.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>Display/Refresh:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void Refresh()
        {
            StudentDataClasses1DataContext SDCD1 = new StudentDataClasses1DataContext(@&quot;Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\ehtesham mehmood\documents\visual studio 2012\Projects\FP1\FP1\abc.mdf;Integrated Security=True;Connect Timeout=30&quot;);
            StudentInfo SI = new StudentInfo();
            var query = from q in SDCD1.StudentInfos
                        select q;
            dataGridView1.DataSource = query;// Attaching the all data with Datagridview
        }
</pre>
<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StudentDataClasses1DataContext&nbsp;SDCD1&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;StudentDataClasses1DataContext(@<span class="js__string">&quot;Data&nbsp;Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\ehtesham&nbsp;mehmood\documents\visual&nbsp;studio&nbsp;2012\Projects\FP1\FP1\abc.mdf;Integrated&nbsp;Security=True;Connect&nbsp;Timeout=30&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StudentInfo&nbsp;SI&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;StudentInfo();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;query&nbsp;=&nbsp;from&nbsp;q&nbsp;<span class="js__operator">in</span>&nbsp;SDCD1.StudentInfos&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;q;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataGridView1.DataSource&nbsp;=&nbsp;query;<span class="js__sl_comment">//&nbsp;Attaching&nbsp;the&nbsp;all&nbsp;data&nbsp;with&nbsp;Datagridview</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<h1><em style="font-size:10px">&nbsp;&nbsp;</em></h1>
