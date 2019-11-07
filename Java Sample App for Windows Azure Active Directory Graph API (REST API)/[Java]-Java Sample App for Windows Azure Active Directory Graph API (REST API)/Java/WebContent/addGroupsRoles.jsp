<%@ page language="java" contentType="text/html" import="java.util.HashMap" %>
<%@ page import="org.sampleapp.dto.UserPageInfo" %>
<%@ page import="org.sampleapp.dto.User"%>
<%@ page import="org.sampleapp.services.AppParameter"%>
<%@ page import="java.util.Set" %>
<%@ page import="java.util.HashSet" %>
<%@ page import="java.util.ArrayList" %>
<%@ page import="org.sampleapp.dto.GroupInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<link rel="stylesheet" type="text/css" href="Site.css" />
<title>Java Sample App for GRAPH</title>

<script type="text/javascript">
function validateInput()
{
var input = document.linkOp.objectName.value;
if( (input==null) || (input=="") )
	{
		alert("Please select either group or role!");
		return false;
	}


var op = document.linkOp.opName.value;
if((op == null) || (op == "")){
	alert("Please slect an operation!");
	return false;
}

var instance = document.linkOp.instanceName.value;

if((instance == null) || (instance == ""))
	{
		alert("Please select a group/role.");
		return false;
	}
return true;
}
</script>

<%
	User user = (User) session.getAttribute("userDetails");
	if(user == null){
		out.println("Error Occured!");
		return;
	}
%>


<%
	Set<String> userGroups = new HashSet<String>();
	for(int i = 0; i < user.getGroupNumber(); i++){
		userGroups.add(user.getGroupDisplayName(i));
	}
	
	ArrayList<GroupInfo> groupsTobeAdded = new ArrayList<GroupInfo>();
	for(int i = 0; i < AppParameter.getGroupNumber(); i++){
		if(!userGroups.contains(AppParameter.getGroupDisplayName(i))){
			groupsTobeAdded.add(new GroupInfo(AppParameter.getGroupDisplayName(i), AppParameter.getGroupObjectId(i)));
		}
	}
	
	Set<String> userRoles = new HashSet<String>();
	for(int i = 0; i < user.getRolesNumber(); i++){
		userRoles.add(user.getRoleDisplayName(i));
	}
	
	ArrayList<GroupInfo> rolesTobeAdded = new ArrayList<GroupInfo>();
	for(int i = 0; i < AppParameter.getRoleNumber(); i++){
		if(!userRoles.contains(AppParameter.getRoleDisplayName(i))){
			rolesTobeAdded.add(new GroupInfo(AppParameter.getRoleDisplayName(i), AppParameter.getRoleObjectId(i)));
		}
	}

%>


<script type="text/javascript">
function changeOptions(chosenObject, chosenOp){
	var groups = document.linkOp.instanceName;
	if((chosenObject == "") || (chosenOp == "" )){
		groups.options.length=0;
		groups.options[0] = new Option("--Select--", "");
		return;
	}
	
	groups.options.length=0;
	if((chosenObject == "Group")&&(chosenOp == "Add")){
			groups.options[0] = new Option("--Select Group--", "");
		<%
		for(int i = 0; i < groupsTobeAdded.size(); i++ ){
		%>
			groups.options[<%=i+1%>] = new Option("<%=groupsTobeAdded.get(i).getDisplayName()%>", "<%=groupsTobeAdded.get(i).getObjectId()%>");
		<%
		}%>
	}
	
	if((chosenObject == "Group") && (chosenOp == "Delete")){
	groups.options[0] = new Option("--Select Group--", "");
	<%for(int i = 0; i < user.getGroupNumber(); i++ ){%>
		groups.options[<%=i+1%>] = new Option("<%=user.getGroupDisplayName(i)%>", "<%=user.getGroupObjectId(i)%>");
	<%}%>	

	}
	
	if((chosenObject == "Role") && (chosenOp == "Add")){
		groups.options[0] = new Option("--Select Role--", "");
	<%
	int numAddableRole = AppParameter.getRoleNumber() - userRoles.size();
	for(int i = 0; i < numAddableRole; i++ ){
	%>
		groups.options[<%=i+1%>] = new Option("<%=rolesTobeAdded.get(i).getDisplayName()%>", "<%=rolesTobeAdded.get(i).getObjectId()%>");
	<%}%>
	}
	
	if((chosenObject == "Role") && (chosenOp == "Delete")){
			groups.options[0] = new Option("--Select Role--", "");
		<%for(int i = 0; i < user.getRolesNumber(); i++ ){%>
			groups.options[<%=i+1%>] = new Option("<%=user.getRoleDisplayName(i)%>", "<%=user.getRoleObjectId(i)%>");	
		<%}%>	

	}

}



</script>


</head>

<body>

<img alt="office365 Logo" src="Images/office365Header.jpg" />

<h1 class="heading"> Windows Azure Active Directory Graph Sample Application</h1>

<div class="horiNavBar" style="margin-bottom:0px">
<ul class="horiNavBar">
<li class="horiNavBar"><a class="horiNavBar" href="index.jsp">Home</a></li>
<li class="horiNavBar"><a class="horiNavBar" href="/JavaSampleApp/requestHandler?op=about">About</a></li>
</ul>
</div>




<div class="main">
	<h2>Add or Remove Links:</h2>
	<div class="queryUser">
 	<form name="linkOp" action="/JavaSampleApp/requestHandler" onsubmit="return validateInput()" method="post">
 		<input type="hidden" Name="op" Value="updateLink"/>
 		<input type="hidden" Name="userId" Value="<%=user.getObjectId()%>"/>
 		<table id="users">
 			<tr>
				<td id="userDetails">Select Objects:</td>
				<td id="userDetails"> 
					<select name="objectName" style="width:250px;background-color:#AAAAAA;color:#0000AA" onChange="changeOptions(document.linkOp.objectName.value, document.linkOp.opName.value)">
						<option value="" selected="selected">--Select--</option>
						<option value="Group">Group</option>
						<option value="Role">Role</option>
					</select>		
				</td>
 			</tr>

 			<tr>
				<td id="userDetails">Select Operation:</td>
				<td id="userDetails"> 
					<select name="opName" style="width:250px;background-color:#AAAAAA;color:#0000AA" onChange="changeOptions(document.linkOp.objectName.value, document.linkOp.opName.value )" >
						<option value="" selected="selected"></option>
						<option value="Add">Add</option>
						<option value="Delete">Delete</option>
					</select>		
				</td>
 			</tr>
 	 
 	 		<tr>
 	 			<td id="userDetails">Select an Instance:</td>
 	 			<td id="userDetails">
					<select name="instanceName" style="width:250px;background-color:#AAAAAA;color:#0000AA">
						<option value="" selected="selected"></option>
					</select>		
				
 	 			</td>
 	 		</tr>

 	 		<tr>
 	 			<td id="userDetails"></td>
 	 			<td id="userDetails" style="padding-left:15px">
 	 				<input style="margin:0px;padding:0px; color:#EEEEEE; width:70px;" class="button" type="button" value="Cancel" onClick="javaScript:history.go(-1)">
					<input style="color:#EEEEEE;width:70px;margin:0px;padding:0px" class="button" type="Submit" value="Submit" />	 		
 	 			</td>
 	 		</tr>
 	 
 	 	
 		</table>
 	
 	</form>
  </div>	
</div>

<div class="footerLeft">
 &copy;2012 Microsoft Corporation &nbsp;|
 <a class="footer" href="http://www.microsoft.com/online/legal/v2/?docid=13&langid=en-us">Legal</a> &nbsp;|
 <a class="footer" href="http://www.microsoft.com/online/legal/v2/?docid=18&langid=en-us">Privacy</a>

</div>

<div class="footerRight">
 <a class="footer" href="http://community.office365.com/en-us/default.aspx">Community</a> &nbsp;|
 <a class="footer" href="http://support.microsoft.com/common/survey.aspx">FeedBack</a>
</div>


</body>
</html>