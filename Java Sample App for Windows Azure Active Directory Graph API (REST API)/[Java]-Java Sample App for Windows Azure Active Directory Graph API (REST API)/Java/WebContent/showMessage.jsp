<%@ page language="java" contentType="text/html" import="java.util.HashMap" %>
<%@ page import="org.sampleapp.dto.UserPageInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<link rel="stylesheet" type="text/css" href="Site.css" />
<title>Java Sample App for GRAPH</title>
</head>
<body>


<h1 class="heading"> Windows Azure Active Directory Graph Sample Application</h1>

<div class="horiNavBar" style="margin-bottom:0px">
<ul class="horiNavBar">
<li class="horiNavBar"><a class="horiNavBar" href="index.jsp">Home</a></li>
<li class="horiNavBar"><a class="horiNavBar" href="/JavaSampleApp/requestHandler?op=about">About</a></li>
</ul>
</div>

<%
	String mssg = (String)request.getSession().getAttribute("message");
	if(mssg == null){
		mssg = "Unexpected Error Occured!";
	}
%>

<div class="main">
	<b> <%=mssg%> </b>	 	
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