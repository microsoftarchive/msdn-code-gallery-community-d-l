<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" ClassName="DateTimeUserControlClass" %>
<br />
The Date and time is getting displayed from the user control:
<%: DateTime.Now.ToLongDateString()  %>

<%: DateTime.Now.ToLongTimeString()  %>
<br />