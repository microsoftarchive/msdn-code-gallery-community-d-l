<%@ page language="java" contentType="text/html" import="java.util.HashMap" %>
<%@ page import="org.sampleapp.dto.UserPageInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<link rel="stylesheet" type="text/css" href="Site.css" />
<title>Java Sample App for GRAPH</title>

<script type="text/javascript">
function validateInput()
{
var input = document.forms["queryUser"]["searchString"].value;
if( (input==null) || (input=="") )
	{
		alert("Search String can not be empty!");
		return false;
	}
}

</script>


</head>
<body>


<h1 class="heading"> Windows Azure Active Directory Graph Sample Application</h1>

<div class="horiNavBar" style="margin-bottom:0px">
<ul class="horiNavBar">
<li class="horiNavBar"><a class="horiNavBar" href="index.jsp">Home</a></li>
<li class="horiNavBar"><a class="horiNavBar" href="/JavaSampleApp/requestHandler?op=about">About</a></li>
</ul>
</div>


<div class="main">

	<h2> <font color=#000088>Query User:</font> </h2>
	<div class="queryUser">
 	<form name="queryUser" action="/JavaSampleApp/requestHandler" onsubmit="return validateInput()" method="get">
 	<input type="hidden" Name="op" Value="queryUser"/>
 	<table id="users">
 	<tr>
		<td id="userDetails">Select Attribute:</td>
		<td id="userDetails"> 
			<select name="attributeName" style="width:166px;background-color:#AAAAAA;color:#0000AA">
				<option value="DisplayName" selected="selected">Display Name</option>
				<option value="UserPrincipalName">UserPrincipalName</option>
				<option value="City">City</option>
				<option value="Surname">Last Name</option>
				<option value="GivenName">First Name</option>
				<option value="Mail">E Mail</option>
			</select>		
		</td>
 	</tr>

 	<tr>
		<td id="userDetails">Select Search Criteria:</td>
		<td id="userDetails"> 
			<select name="opName" style="width:166px;background-color:#AAAAAA;color:#0000AA">
				<option value="eq" selected="selected">=</option>
				<option value="le">&le;</option>
				<option value="ge">&ge;</option>
				<option value="startswith">startswith</option>
			</select>		
		</td>
 	</tr>
 	 
 	 <tr>
 	 	<td id="userDetails">Enter Search String:</td>
 	 	<td id="userDetails">
 	 		<input type="text" name="searchString" style="width:160px; background-color:#AAAAAA;color:#0000AA"/>	 		
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


<div class="footerRight">
 <a class="footer" href="http://community.office365.com/en-us/default.aspx">Community</a> &nbsp;|
 <a class="footer" href="http://support.microsoft.com/common/survey.aspx">FeedBack</a>
</div>


</body>
</html>