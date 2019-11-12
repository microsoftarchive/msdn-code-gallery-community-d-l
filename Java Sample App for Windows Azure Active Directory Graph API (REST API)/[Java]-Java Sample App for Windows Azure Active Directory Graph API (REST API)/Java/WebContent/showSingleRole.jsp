<%@ page language="java" contentType="text/html" import="org.sampleapp.dto.Role" %>
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



<div class="userMain">
 	<% 
 		Role role = (Role) session.getAttribute("roleDetails");
		if(role == null){
			out.println("Sorry! Error Encountered.");
			return;
		}
 	%>


 	<h2> <font color=#000088> <%=role.getDisplayName() %> Group</font> </h2>
 	
 	<table class="userDetails">
 	<tr>
 		<th class="userDetails">Attributes</th>
 		<th class="userDetails">Value</th> 
 	</tr>
 	
 	<tr>
 		<td class="userDetails">DisplayName</td>
 		<td class="userDetails"><%=role.getDisplayName() %></td>
 	</tr>

 	<tr>
 		<td class="userDetails">ObjectId</td>
 		<td class="userDetails"><%=role.getObjectId() %></td>
 	</tr>
 	

 	<tr>
 		<td class="userDetails">Description</td>
 		<td class="userDetails"><%=role.getDescription() %></td>
 	</tr>

 	<tr>
 		<td class="userDetails">Builtin</td>
 		<td class="userDetails"><%=role.getBuiltin() %></td>
 	</tr>

 	<tr>
 		<td class="userDetails">Role Disabled</td>
 		<td class="userDetails"><%=role.getRoleDisabled() %></td>
 	</tr>
 	
  	<tr>
 		<td class="userDetails">Members</td>
 		<td class="userDetails"><a class="users" href="/JavaSampleApp/requestHandler?op=getRoleMembers&roleId=<%=role.getObjectId()%>"><b>Get All Members</b></a></td>
 	</tr>



 	</table>
	
	<form>
		<input style="margin-left:400px;margin-top:10px" class="button" type="button" value="OK"  onClick="javascript:history.go(-1)">
	</form>

</div>


<div class="footerRight">
 <a class="footer" href="http://community.office365.com/en-us/default.aspx">Community</a> &nbsp;|
 <a class="footer" href="http://support.microsoft.com/common/survey.aspx">FeedBack</a>
</div>


</body>
</html>