# Entity Framework in Windows forms part 1
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- Windows Forms
- Entity Framework
- Entity Framework 6
## Topics
- Data Access
- DataGridView
- Filter data
## Updated
- 05/26/2016
## Description

<h1>Description</h1>
<p><span style="font-size:small">This code sample is for showing basic methods to display data in a DataGridView which is sortable, filtering data and simple data binding. All the code is read operations only which in the next code sample will move you into
 add, edit and removal of data. There are three projects, one for a special BindingList for allowing the DataGridView to be sortable, another project for our Entity Framework classes and finally a windows forms project.</span></p>
<p><span style="font-size:small">I will not be going over setting up the model as there many examples that walk you through this process
<a href="https://msdn.microsoft.com/en-us/data/jj206878.aspx">like this one</a>.</span></p>
<p><span style="font-size:small"><strong>Part 2</strong> <a href="https://code.msdn.microsoft.com/Entity-Framework-in-025d5d7b">
is avaible here</a> which covers editing data and validation within EF rather than in a form.</span></p>
<p><span style="font-size:small"><strong>Part 3</strong> <a href="https://code.msdn.microsoft.com/Entity-Framework-in-165c34ee">
is available here</a>, refines the edit code and adds code to remove records,</span></p>
<p><span style="font-size:small"><strong>Part 4</strong> <a href="https://code.msdn.microsoft.com/Entity-Framework-in-764fa5ba">
is available here</a> which completes the series so you could jump right to it.</span></p>
<p>&nbsp;<span style="font-size:small">The objective here is to lay down a foundation for displaying and filtering data. Many developers are used to using a manage data provider e.g. SqlClient to populate either a DataSet or DataTable in tangent with a BindingSource
 to show data in a DataGridView but setting the DataGridView.DataSource to a list of a class in your EF model will display data but does not permit sorting. Here we need a custom BindingList to assist with.</span></p>
<p><span style="font-size:small">Conventional filtering is somewhat different also e.g. EF is case sensitive on string fields so I demonstrate in a language extension method how to do case insensitive filtering.</span></p>
<p><span style="font-size:small">Couple the two, reading and filtering we are almost there but there is one more thing, when sorting the DataGridView via its column headers the current row will not be current after the sort. Here I have code that shows how
 to keep the current row current after the sort.</span></p>
<p><span style="font-size:small">All data operations are done in a partial class of Customer where Customer is the class created by EF for reading data from the SQL-Server backend database. In the constructor of Customers first data is loaded into a List then
 (this is not used yet) a list of string gets column names for the table. There are no methods built into EF that does this so the code has to go through some hoops.</span></p>
<p><span style="font-size:small">The filtering is done via an enum with options e.g. starts with, ends with, contains and equals. The default for EF is to do case sensitive filtering so in this code we simple use .ToLower() to do the comparisons.</span></p>
<p><span style="font-size:small">There are several language extension methods provide for casting objects and filtering operations. Note that in the language extension ExpandColumns for a DataGridView AutoSizeMode is set for each column that is not of type
 ICollection`1. Here in this project there is one column of type Orders which has been hidden from view but this extension sees the column, tries to adjust the column but if not for the check would raise a runtime exceptions as this column cannot be shown or
 adjusted.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">Although visually little is done but the parts all matter and are important for a decent visual experience. In the next code sample I will get into CRUDE operations.</span></p>
<p><img id="149091" src="149091-pm.png" alt="" width="687" height="536">&nbsp;</p>
