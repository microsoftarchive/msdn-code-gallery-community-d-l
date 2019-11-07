# Entity Framework in Windows forms part 2
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
- Data Validation
## Updated
- 05/26/2016
## Description

<h1>Description</h1>
<p><span style="font-size:small">This is part two of a series of code samples (<a href="https://code.msdn.microsoft.com/Entity-Framework-in-dc34a410">part 1</a>) to hopefully have windows forms developer start thinking about using Entity Framework in forms
 solutions. Part one covered the basics of viewing, sorting and filtering in a DataGridView while this part focuses on two things, editing a record and secondly validating the edited record outside of the form, done in a backend class.&nbsp;<a href="https://code.msdn.microsoft.com/Entity-Framework-in-165c34ee">Part
 3</a> covers refining the edit and to delete rows. <a href="https://code.msdn.microsoft.com/Entity-Framework-in-764fa5ba">
Part 4</a> covers adding new records and a few final touches to complete the series.</span><br>
<br>
<span style="font-size:small">Many old time developers will do all their work within forms will an experienced developer will take it up a notch with separation of concerns and for many web developers will work with a repository pattern but here I want to keep
 things simple, allow a developer to get use to manipulating data outside of the form using Data Notation and implementing an interface to override default validation of the Validate method of Entity Framework.</span><br>
<br>
<span style="font-size:small">Before going any farther there are some classes and extension methods unused in this code sample but will be used in the next code sample so if you see things not being used, they will be, just getting ahead of myself.</span><br>
<br>
<span style="font-size:small">To keep code clean (and I favor these) I created several language extension methods for BindingSource component. &nbsp;</span></p>
<p><span style="font-size:small">One of the extensions to get the entire customer of the current DataGridView</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static Customer Customer(this BindingSource sender)
{
    return ((Customer)sender.Current);
}</pre>
<div class="preview">
<pre class="js">public&nbsp;static&nbsp;Customer&nbsp;Customer(<span class="js__operator">this</span>&nbsp;BindingSource&nbsp;sender)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;((Customer)sender.Current);&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">In Customers class Customer data is loaded into a List&lt;Customer&gt; which in turn becomes the DataSource of a custom BindingList, this in turn becomes the DataSource of our BindingSource so the extension
 methods retrieve customer information method based. &nbsp;To feed the current customer in the DataGridView the following is used, bsCustomers.Customer() which returns the current customer in the DataGridView. In the edit form there are two buttons, each with
 DialogResult set so when the edit form is closed we know their response. The UpdateCustomer method attempts to save the entity but does validation first. The validation class is in the Entity Framework class in the solution named CustomersPartial which is
 a partial class of Customer in the EF model. The class CustomerMetaData sets several fields/properties with data annatations where the validation is simple, is the field empty, if so and has been marked as required creates a ValidationResult which is evaluates
 by the save method and raises an exception which is captured in the try/catch surrounding the call to SaveChanges method. If this happens the record is rolled back using a private method in this class and the end-user is presented with a dialog indicating
 the problem(s). There are more complex methods for validating and as mentioned before, this code sample is simple to learn from and as you become more familar with EF you can step things up a notch or two.</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">EditorForm f = new EditorForm(bsCustomers.Customer(), ContactTitles);

try
{
    if (f.ShowDialog() == DialogResult.OK)
    {
        Customer customer = blCustomers.FirstOrDefault(cust =&gt; cust.CustomerIdentifier == bsCustomers.CustomerIdentifier());
        Customers customers = new Customers();
        if (customers.UpdateCustomer(customer))
        {
            bsCustomers.ResetCurrentItem();
        }
        else
        {
            MessageBox.Show(customers.ValidationMessage);
        }
    }
}
finally
{
    f.Dispose();
}</pre>
<div class="preview">
<pre class="csharp">EditorForm&nbsp;f&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EditorForm(bsCustomers.Customer(),&nbsp;ContactTitles);&nbsp;
&nbsp;
<span class="cs__keyword">try</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(f.ShowDialog()&nbsp;==&nbsp;DialogResult.OK)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Customer&nbsp;customer&nbsp;=&nbsp;blCustomers.FirstOrDefault(cust&nbsp;=&gt;&nbsp;cust.CustomerIdentifier&nbsp;==&nbsp;bsCustomers.CustomerIdentifier());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Customers&nbsp;customers&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Customers();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(customers.UpdateCustomer(customer))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bsCustomers.ResetCurrentItem();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(customers.ValidationMessage);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
<span class="cs__keyword">finally</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;f.Dispose();&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">The following is our code within the editor form which in the next code sample will also double for adding. In form constructor, the current customer record is passed in and controls are setup with
 field data, of course you could data binding but that brings in another complex peice. The save button sets field information into out customer which is evaluated back in the calling form. In the next code sample this will call validation in the editor form
 which is better but again, keeping this simple, gearing up for the next level.</span>&nbsp;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EntityFrameWorkNorthWind_cs;

namespace Example1_cs
{
    public partial class EditorForm : Form
    {
        public Customer Customer { get; set; }
        public bool Adding { get; set; }
        public EditorForm()
        {
            InitializeComponent();
        }
        public EditorForm(Customer customer, List&lt;string&gt; contactTitles)
        {
            InitializeComponent();

            this.Customer = customer;
            cboTitles.DataSource = contactTitles;
            cboCountry.DataSource = Countries.Names;

            if (customer == null)
            {
                Adding = true;
            }
            else
            {

                Adding = false;

                txtCompanyName.Text = Customer.CompanyName;
                txtContactName.Text = Customer.ContactName;
                int index = cboTitles.FindString(Customer.ContactTitle);
                if (index != -1)
                {
                    cboTitles.SelectedIndex = index;
                }

                index = cboCountry.FindString(Customer.Country);
                if (index != -1)
                {
                    cboCountry.SelectedIndex = index;
                }
            }
        }
        /// &lt;summary&gt;
        /// Validation is done in the main form.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
        /// &lt;remarks&gt;
        /// * No reason not to place validation here, I left that for you :-)
        /// * I avoided checking if the text properties of the TextBoxes 
        ///   are empty as we are focused on EF validation not form control 
        ///   validation
        /// &lt;/remarks&gt;
        private void cmdSave_Click(object sender, EventArgs e)
        {
            Customer.CompanyName = txtCompanyName.Text;
            Customer.ContactName = txtContactName.Text;
            Customer.ContactTitle = cboTitles.Text;
            Customer.Country = cboCountry.Text;
        }
    }
}
</pre>
<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;
using&nbsp;System.Collections.Generic;&nbsp;
using&nbsp;System.Windows.Forms;&nbsp;
using&nbsp;EntityFrameWorkNorthWind_cs;&nbsp;
&nbsp;
namespace&nbsp;Example1_cs&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;partial&nbsp;class&nbsp;EditorForm&nbsp;:&nbsp;Form&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;Customer&nbsp;Customer&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;bool&nbsp;Adding&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;EditorForm()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;EditorForm(Customer&nbsp;customer,&nbsp;List&lt;string&gt;&nbsp;contactTitles)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.Customer&nbsp;=&nbsp;customer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cboTitles.DataSource&nbsp;=&nbsp;contactTitles;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cboCountry.DataSource&nbsp;=&nbsp;Countries.Names;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(customer&nbsp;==&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adding&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adding&nbsp;=&nbsp;false;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtCompanyName.Text&nbsp;=&nbsp;Customer.CompanyName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtContactName.Text&nbsp;=&nbsp;Customer.ContactName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;index&nbsp;=&nbsp;cboTitles.FindString(Customer.ContactTitle);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(index&nbsp;!=&nbsp;-<span class="js__num">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cboTitles.SelectedIndex&nbsp;=&nbsp;index;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;index&nbsp;=&nbsp;cboCountry.FindString(Customer.Country);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(index&nbsp;!=&nbsp;-<span class="js__num">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cboCountry.SelectedIndex&nbsp;=&nbsp;index;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;Validation&nbsp;is&nbsp;done&nbsp;in&nbsp;the&nbsp;main&nbsp;form.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;sender&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;e&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;remarks&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;*&nbsp;No&nbsp;reason&nbsp;not&nbsp;to&nbsp;place&nbsp;validation&nbsp;here,&nbsp;I&nbsp;left&nbsp;that&nbsp;for&nbsp;you&nbsp;:-)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;*&nbsp;I&nbsp;avoided&nbsp;checking&nbsp;if&nbsp;the&nbsp;text&nbsp;properties&nbsp;of&nbsp;the&nbsp;TextBoxes&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&nbsp;&nbsp;are&nbsp;empty&nbsp;as&nbsp;we&nbsp;are&nbsp;focused&nbsp;on&nbsp;EF&nbsp;validation&nbsp;not&nbsp;form&nbsp;control&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&nbsp;&nbsp;validation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/remarks&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;cmdSave_Click(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Customer.CompanyName&nbsp;=&nbsp;txtCompanyName.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Customer.ContactName&nbsp;=&nbsp;txtContactName.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Customer.ContactTitle&nbsp;=&nbsp;cboTitles.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Customer.Country&nbsp;=&nbsp;cboCountry.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="152473" src="152473-43.jpg" alt="" width="771" height="433"></div>
</div>
<h1 class="endscriptcode">Closing remarks</h1>
<div class="endscriptcode"><span style="font-size:small">I would highly recommend that you build and run the project, try the edit functionality then run through the code with the Visual Studio debugger followed by viewing the code to learn from it.</span></div>
