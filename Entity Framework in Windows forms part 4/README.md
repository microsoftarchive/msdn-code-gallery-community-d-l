# Entity Framework in Windows forms part 4
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Windows Forms
- Entity Framework 6
## Topics
- Data Access
- Entity Framework
- LINQ to Entities
## Updated
- 05/25/2016
## Description

<h1>Description</h1>
<p><span style="font-size:small">In this code example continues on the first three part of this series which focuses on working with Entity Framework for Windows forms. In the examples prior to this we began with viewing data in a DataGridView which is relatively
 easy except for sorting which introduced the use of a custom BindingList in tangent with a BindingSource and in this section a BindingNavigator too. The BindingNavigator is not for everyone but many customers appreciate it&rsquo;s functionality as many developer
 used them in MS-Access application and then brought forward into .NET applications.</span></p>
<p><span style="font-size:small">The edit a current record was done the current record was passed into the edit form via an overloaded form constructor while in add new record I pass in an empty Customer record. In the form constructor there is a check to see
 if we are adding or editing and a private Boolean property of the form is set so we now whether in the save button we are dealing with a add or edit of a record.</span></p>
<p><span style="font-size:small">In the click event for the saving a new record the Customer from the edit form is passed in to the AddNew method which then passes the Customer entity to the Add method of Customers for the NorthWindEntities followed by executing
 the save method. If there are validation issues they are kicked back by throwing an exception and if the save works without an exception we now have the new primary key which we need for adding the new customer record into our DataGridView so we can immediately
 edit the Customer record if we need to else there would be no way to edit and save.</span></p>
<p><span style="font-size:small">Also added were things like allow the user to double click a row in the DataGridView for editing. There is code also for when the user presses the DEL key this invokes our method to prompt for removal of the currently selected
 Customer.</span></p>
<p><span style="font-size:small">In the BindingNavigator I override the default behavior of the add and delete buttons which is done in the form load event.</span></p>
<p><span style="font-size:small">Note that all the above parts for working with add and edit methods I placed the code into private methods of the form rather than duplicate them into more than one event.</span></p>
<p><span style="font-size:small">At some point I broke the remove filter on the main form and have fixed it.</span></p>
<p><span style="font-size:small"><img id="153301" src="153301-10.jpg" alt="" width="600" height="377"><br>
</span></p>
<ul>
</ul>
<h1>More Information</h1>
<p><span style="font-size:small"><em>Recently I have seen other decent articles and code sampes on using Entity Framework with Windows forms which are good to learn from but still feel that what I have presented offers a different valid approach. So I would
 urge those who have read this far to explore what is out on the web and judge for yourself if mine or other code samples meet your needs one over the other.</em></span></p>
<p><span style="font-size:small"><em>I have also seen conversations that discourage using Entity Framework in Windows form solution which I am totally in disagreement with. There are still many customers without a web presense that need Window form applications
 so with that you know it's possible.</em></span></p>
<p><span style="font-size:small"><em>Thanks for reading and hope these samples are of some assistance.</em></span></p>
