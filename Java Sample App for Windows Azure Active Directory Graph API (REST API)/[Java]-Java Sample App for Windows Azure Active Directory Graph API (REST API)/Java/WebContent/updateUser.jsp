<%@ page language="java" contentType="text/html" import="java.util.HashMap" %>
<%@ page import="org.sampleapp.dto.UserPageInfo" %>
<%@ page import="org.sampleapp.services.AppParameter" %>
<%@ page import="org.sampleapp.dto.User" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<link rel="stylesheet" type="text/css" href="Site.css" />
<title>Java Sample App for GRAPH</title>

<script type="text/javascript">
function validateInput()
{
var inputDisplayName = document.forms["queryUser"]["DisplayName"].value;
if( (inputDisplayName==null) || (inputDisplayName=="") )
	{
		alert("Display Name cannot be empty!");
		return false;
	}
var inputUPN = document.forms["queryUser"]["UserPrincipalName"].value;
if( (inputUPN==null) || (inputUPN=="") )
	{
		alert("UserPrincipalName cannot be empty!");
		return false;
	}

var usageLocationLength = document.forms["queryUser"]["UsageLocation"].value.length;
if(usageLocationLength > 2)
	{
		alert("Usage Location cannot exceed 2 characters!");
		return false;
	}
	
var accountEnabled = document.forms["queryUser"]["AccountEnabled"].value;
if(accountEnabled.toLowerCase() != "true" && accountEnabled.toLowerCase() != "false")
	{
		alert("Set AccountEnabled to true or false!");
		return false;
	}
	
	

<%for(int i = 0; i < AppParameter.getVerifiedDomainNumber(); i++){%>		

var atSymbol = "@";
var domainAdded = atSymbol.concat("<%=AppParameter.getVerifiedDomainName(i)%>");
var regExp = /[@]<%=AppParameter.getVerifiedDomainName(i)%>$/;

if((inputUPN.toLowerCase()).indexOf(domainAdded.toLowerCase()) != -1)
{
	return true;	
}


<%}%>

alert("The Domain of the UserPrincipalName is not verified!");
return false;

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

 <% 
 		User user = (User) session.getAttribute("userDetails");
		if(user == null){
			out.println("Sorry! Error Encountered.");
			return;
		}
%>


<div class="main">
	<h2> <font color=#000088>Update User:</font> </h2>
	<div class="queryUser" style="padding-top:30px">
 	<form name="queryUser" action="/JavaSampleApp/requestHandler" onsubmit="return validateInput()" method="post">
 	<input type="hidden" Name="op" Value="updateUser"/>
 	<table id="users" style="width:auto">

 	<tr>
		<td id="userDetails" style="padding-left:45px">Object ID<sup><font color="red">*</font></sup>:</td>
		<td id="userDetails">
 	 		<input type="text" name="ObjectId" value="<%=user.getObjectId() %>" readonly="readonly" style="width:300px; background-color:#AAAAAA;color:#666666"/>	 		
 	 	</td>
		
 	</tr>

 	<tr>
		<td id="userDetails" style="padding-left:45px">Display Name<sup><font color="red">*</font></sup>:</td>
		<td id="userDetails">
 	 		<input type="text" name="DisplayName" value="<%=user.getDisplayName() %>" readonly="readonly" style="width:300px; background-color:#AAAAAA;color:#666666"/>	 		
 	 	</td>
		
 	</tr>
 	
 	<tr>
		<td id="userDetails" style="padding-left:45px">User Principal Name<sup><font color="red">*</font></sup>:</td>
		<td id="userDetails">
 	 		<input type="text" name="UserPrincipalName" value="<%=user.getUserPrincipalName() %>" readonly="readonly" style="width:300px; background-color:#AAAAAA;color:#666666"/>	 		
 	 	</td>
		
 	</tr>

 	
 	<tr>
		<td id="userDetails" style="padding-left:45px">Immutable ID:</td>
		<td id="userDetails">
 	 		<input type="text" name="ImmutableId" value="<%=user.getImmutableId() %>" style="width:300px; background-color:#AAAAAA;color:#0000AA"/>	 		
 	 	</td>
		
 	</tr>

 	<tr>
		<td id="userDetails" style="padding-left:45px">First Name:</td>
		<td id="userDetails">
 	 		<input type="text" name="GivenName" value="<%=user.getGivenName()%>" style="width:300px; background-color:#AAAAAA;color:#0000AA"/>	 		
 	 	</td>
		
 	</tr>

 	<tr>
		<td id="userDetails" style="padding-left:45px">Last Name:</td>
		<td id="userDetails">
 	 		<input type="text" name="Surname" value="<%=user.getSurname() %>" style="width:300px; background-color:#AAAAAA;color:#0000AA"/>	 		
 	 	</td>
		
 	</tr>

 	


 	<tr>
		<td id="userDetails" style="padding-left:45px">Job Title:</td>
		<td id="userDetails">
 	 		<input type="text" name="JobTitle" value="<%=user.getJobTitle()%>" style="width:300px; background-color:#AAAAAA;color:#0000AA"/>	 		
 	 	</td>
		
 	</tr>

 	<tr>
		<td id="userDetails" style="padding-left:45px">Department:</td>
		<td id="userDetails">
 	 		<input type="text" name="Department" value="<%=user.getDepartment() %>" style="width:300px; background-color:#AAAAAA;color:#0000AA"/>	 		
 	 	</td>
 	 	
		
 	</tr>

 	<tr>
		<td id="userDetails" style="padding-left:45px">Street Address:</td>
		<td id="userDetails">
 	 		<input type="text" name="StreetAddress" value = "<%=user.getStreetAddress()%>"style="width:300px; background-color:#AAAAAA;color:#0000AA"/>	 		
 	 	</td>
 	</tr>
 	
 	<tr>
		<td id="userDetails" style="padding-left:45px">City</td>
		<td id="userDetails">
 	 		<input type="text" name="City" value= "<%=user.getCity() %>" style="width:300px; background-color:#AAAAAA;color:#0000AA"/>	 		
 	 	</td>
 	</tr>


 	
 	<tr>
		<td id="userDetails" style="padding-left:45px">State:</td>
		<td id="userDetails">
 	 		<input type="text" name="State" value="<%=user.getState() %>" style="width:300px; background-color:#AAAAAA;color:#0000AA"/>	 		
 	 	</td> 	 			
 	</tr>

 	<tr>
		<td id="userDetails" style="padding-left:45px">Postal Code:</td>
		<td id="userDetails">
 	 		<input type="text" name="PostalCode" value="<%=user.getPostalCode() %>" style="width:300px; background-color:#AAAAAA;color:#0000AA"/>	 		
 	 	</td> 	 			
 	</tr>

 	<tr>
		<td id="userDetails" style="padding-left:45px">Country:</td>
		<td id="userDetails">
 	 		<input type="text" name="Country" value="<%=user.getCountry() %>" style="width:300px; background-color:#AAAAAA;color:#0000AA"/>	 		
 	 	</td>
		
 	</tr>


 	<tr>
		<td id="userDetails" style="padding-left:45px">TelephoneNumber:</td>
		<td id="userDetails">
 	 		<input type="text" name="TelephoneNumber" value="<%=user.getTelephoneNumber() %>" style="width:300px; background-color:#AAAAAA;color:#0000AA"/>	 		
 	 	</td> 	 			
 	</tr>

 	<tr>
		<td id="userDetails" style="padding-left:45px">Mobile:</td>
		<td id="userDetails">
 	 		<input type="text" name="Mobile" value="<%=user.getMobile()%>" style="width:300px; background-color:#AAAAAA;color:#0000AA"/>	 		
 	 	</td> 	 			
 	</tr>


 	<tr>
		<td id="userDetails" style="padding-left:45px">Usage Location:</td>
		<td id="userDetails">
 	 		<input type="text" name="UsageLocation" value="<%=user.getUsageLocation()%>" style="width:300px; background-color:#AAAAAA;color:#0000AA"/>	 		
 	 	</td> 	 			
 	</tr>
 	
 	 	<tr>
		<td id="userDetails" style="padding-left:45px">AccountEnabled:</td>
		<td id="userDetails">
 	 		<input type="text" name="AccountEnabled" value="<%=user.getAccountEnabled()%>" style="width:300px; background-color:#AAAAAA;color:#0000AA"/>	 		
 	 	</td> 	 			
 	</tr>
 	
 	

 	<tr>
 	 	<td id="userDetails"></td>
 	 	<td id="userDetails" >
 	 		<input style="margin-left:150px;margin-right:10px;color:#EEEEEE; width:70px;" class="button" type="button" value="Cancel" onClick="javaScript:history.go(-1)">
			<input style="color:#EEEEEE;width:70px" class="button" type="Submit" value="Submit" />	 		
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