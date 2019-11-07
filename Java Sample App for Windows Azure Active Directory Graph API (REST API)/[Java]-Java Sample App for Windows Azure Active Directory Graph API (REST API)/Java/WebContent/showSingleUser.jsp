<%@ page language="java" contentType="text/html" import="org.sampleapp.dto.User" %>
<%@ page import="java.util.Iterator" %>
<%@ page import="java.util.Set" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<link rel="stylesheet" type="text/css" href="Site.css" />
<title>User Details</title>
</head>
<body>


<h1 class="heading"> Windows Azure Active Directory Graph Sample Application</h1>

<div class="horiNavBar">
<ul class="horiNavBar">
<li class="horiNavBar"><a class="horiNavBar" href="index.jsp">Home</a></li>
<li class="horiNavBar"><a class="horiNavBar" href="/JavaSampleApp/requestHandler?op=about">About</a></li>
</ul>
</div>

<%! 
	public static int getMainPanelHeight(User user){
		int baseHeight = 760;
		int multiplyingFactor = 23;
		int multiple = (user.getDirectReportNumber() - 1) + (user.getGroupNumber() - 1) + (user.getRolesNumber() - 1);
		return (baseHeight + multiplyingFactor * multiple);
	}
%>


<div class="userMain">
 	<% 
 		User user = (User) session.getAttribute("userDetails");
		if(user == null){
			out.println("Sorry! Error Encountered.");
			return;
		}
 	%>


 	<h2> <font color=#000088> <%=user.getGivenName() %> <%=user.getSurname() %></font> </h2>
 	
 	<table class="userDetails">
 	<tr>
 		<th class="userDetails">Attributes</th>
 		<th class="userDetails">Value</th> 
 	</tr>
 	
 	<tr>
 		<td class="userDetails">DisplayName</td>
 		<td class="userDetails"><%=user.getDisplayName() %></td>
 	</tr>

 	<tr>
 		<td class="userDetails">UserPrincipalName</td>
 		<td class="userDetails"><%=user.getUserPrincipalName() %></td>
 	</tr>
 	
	<tr>
 		<td class="userDetails">ObjectId</td>
 		<td class="userDetails"><%=user.getObjectId() %></td>
 	</tr>

	<tr>
 		<td class="userDetails">ImmutableId</td>
 		<td class="userDetails"><%=user.getImmutableId()%></td>
 	</tr>

 	<tr>
 		<td class="userDetails">GivenName</td>
 		<td class="userDetails"><%=user.getGivenName() %></td>
 	</tr>

 	<tr>
 		<td class="userDetails">Surname</td>
 		<td class="userDetails"><%=user.getSurname() %></td>
 	</tr>

 	<tr>
 		<td class="userDetails">StreetAddress</td>
 		<td class="userDetails"><%=user.getStreetAddress() %></td>
 	</tr>
 	
 	<tr>
 		<td class="userDetails">City</td>
 		<td class="userDetails"><%=user.getCity() %></td>
 	</tr>

 	<tr>
 		<td class="userDetails">State</td>
 		<td class="userDetails"><%=user.getState() %></td>
 	</tr>

 	<tr>
 		<td class="userDetails">PostalCode</td>
 		<td class="userDetails"><%=user.getPostalCode() %></td>
 	</tr>

 	<tr>
 		<td class="userDetails">Country</td>
 		<td class="userDetails"><%=user.getCountry() %></td>
 	</tr>


 	<tr>
 		<td class="userDetails">UsageLocation</td>
 		<td class="userDetails"><%=user.getUsageLocation() %></td>
 	</tr>

 	<tr>
 		<td class="userDetails">TelephoneNumber</td>
 		<td class="userDetails"><%=user.getTelephoneNumber() %></td>
 	</tr>
	
 	<tr>
 		<td class="userDetails">Mail</td>
 		<td class="userDetails"><%=user.getMail() %></td>
 	</tr>
 	
 	 	<tr>
 		<td class="userDetails">MailNickName</td>
 		<td class="userDetails"><%=user.getMailnickName() %></td>
 	</tr>

 	<tr>
 		<td class="userDetails">Mobile</td>
 		<td class="userDetails"><%=user.getMobile() %></td>
 	</tr>

 	<tr>
 		<td class="userDetails">JobTitle</td>
 		<td class="userDetails"><%=user.getJobTitle() %></td>
 	</tr>

 	<tr>
 		<td class="userDetails">Department</td>
 		<td class="userDetails"><%=user.getDepartment() %></td>
 	</tr>

 	<tr>
 		<td class="userDetails">AccountEnabled</td>
 		<td class="userDetails"><%=user.getAccountEnabled() %></td>
 	</tr>

 	<tr>
 		<td class="userDetails">PasswordPolicies</td>
 		<td class="userDetails"><%=user.getPasswordPolicies() %></td>
 	</tr>
 	
 	<tr>
 		<td class="userDetails">DirSyncEnabled</td>
 		<td class="userDetails"><%=user.getDirSyncEnabled() %></td>
 	</tr>
 	
 	<tr>
 		<td class="userDetails">Manager</td>
 		<td class = "userDetails">
 		<%
 			if(user.getManagerDisplayName() != null){
 				out.println("<a class=\"users\" href='/JavaSampleApp/requestHandler?op=getuser&ObjectId=" +  user.getManagerObjectId()+"'>" +user.getManagerDisplayName()+"</a>");
 			}
 		%>
 		</td>
	</tr>


 	<tr>
 		<td class="userDetails">Direct Reports</td>
 		<td class="userDetails">
 		<%	
 			for(int i = 0; i < user.getDirectReportNumber(); i++ ){
 
 	 				out.println("<a class=\"users\" href='/JavaSampleApp/requestHandler?op=getuser&ObjectId=" +  user.getDirectReportObjectId(i) + "'>" + user.getDirectReportDisplayName(i)+"</a>");
 					out.println("<br>");
 			}
 		
 		%>
 		</td>
 		
	</tr>

 	<tr>
 		<td class="userDetails">Groups</td>
 		<td class="userDetails">
 		<%	
 			for(int i = 0; i < user.getGroupNumber(); i++ ){
 
 	 				out.println("<a class=\"users\" href='/JavaSampleApp/requestHandler?op=getgroup&ObjectId=" +  user.getGroupObjectId(i) + "'><b>" + user.getGroupDisplayName(i)+"</b></a>");
 					out.println("<br>");
 			}
 		
 		%>
 		</td>
 		
	</tr>

 	<tr>
 		<td class="userDetails">Roles</td>
 		<td class="userDetails">
 		<%	
 			for(int i = 0; i < user.getRolesNumber(); i++ ){
 
 	 				out.println("<a class=\"users\" href='/JavaSampleApp/requestHandler?op=getrole&roleId=" +  user.getRoleObjectId(i) + "'><b>" + user.getRoleDisplayName(i)+"</b></a>");
 					out.println("<br>");
 			}
 		
 		%>
 		</td>
 		
	</tr>

 	</table>

 	 <form action="updateUser.jsp">
		<input style="margin-left:200px; margin-top:10px" class="button" type="button" value="Cancel"  onClick="javascript:history.go(-1)">
		<input style="margin-top:10px" class="button" type="Submit" value="Edit">
		<input style="margin-top:10px" class="button" type="button" value="Links" onClick="location.href='addGroupsRoles.jsp'">
	    <input style="margin-top:10px" class="button" type="button" value="resetPswd" onClick="location.href='resetUserPassword.jsp'">	
	</form>
	<form action="addGroupsRoles.jsp">
	</form>	

	

</div>



<div class="footerRight">
 <a class="footer" href="http://community.office365.com/en-us/default.aspx">Community</a> &nbsp;|
 <a class="footer" href="http://support.microsoft.com/common/survey.aspx">FeedBack</a>
</div>


</body>
</html>