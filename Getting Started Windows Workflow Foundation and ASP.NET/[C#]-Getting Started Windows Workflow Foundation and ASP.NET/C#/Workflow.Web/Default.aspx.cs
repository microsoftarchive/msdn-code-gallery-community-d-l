using System;
using System.Activities;
using System.Collections.Generic;
using WorkflowLibrary;

namespace Workflow.Web
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			
		}

		protected void ButtonCreateGreeting_Click(object sender, EventArgs e)
		{
			string username = TextBoxName.Text;

			Greeting greeting = new Greeting { ArgUserName = username };

			IDictionary<string, object> results = WorkflowInvoker.Invoke(greeting);
			LabelGreeting.Text = results["Result"].ToString();
		}
	}
}