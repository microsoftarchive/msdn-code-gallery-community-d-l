<%@ page language="java" contentType="text/html" import="org.sampleapp.dto.Group" %>
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
 		Group group = (Group) session.getAttribute("groupDetails");
		if(group == null){
			out.println("Sorry! Error Encountered.");
			return;
		}
 	%>


 	<h2> <font color=#000088> <%=group.getDisplayName() %> Group</font> </h2>
 	
 	<table class="userDetails">
 	<tr>
 		<th class="userDetails">Attributes</th>
 		<th class="userDetails">Value</th> 
 	</tr>
 	
 	<tr>
 		<td class="userDetails">DisplayName</td>
 		<td class="userDetails"><%=group.getDisplayName() %></td>
 	</tr>

 	<tr>
 		<td class="userDetails">ObjectId</td>
 		<td class="userDetails"><%=group.getObjectId() %></td>
 	</tr>
 	

 	<tr>
 		<td class="userDetails">Description</td>
 		<td class="userDetails"><%=group.getDescription() %></td>
 	</tr>

 	<tr>
 		<td class="userDetails">Mail</td>
 		<td class="userDetails"><%=group.getMail() %></td>
 	</tr>

 	<tr>
 		<td class="userDetails">Mail Enabled</td>
 		<td class="userDetails"><%=group.getMailEnabled() %></td>
 	</tr>
 	
 	<tr>
 		<td class="userDetails">DirSyncEnabled</td>
 		<td class="userDetails"><%=group.getDirSyncEnabled() %></td>
 	</tr>

 	<tr>
 		<td class="userDetails">LastDirSyncTime</td>
 		<td class="userDetails"><%=group.getLastDirSyncTime() %></td>
 	</tr>

 	<tr>
 		<td class="userDetails">SecurityEnabled</td>
 		<td class="userDetails"><%=group.getSecurityEnabled() %></td>
 	</tr>

 	<tr>
 		<td class="userDetails">Members</td>
 		<td class="userDetails"><a class="users" href="/JavaSampleApp/requestHandler?op=getGroupMembers&groupId=<%=group.getObjectId()%>"><b>Get All Members</b></a></td>
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