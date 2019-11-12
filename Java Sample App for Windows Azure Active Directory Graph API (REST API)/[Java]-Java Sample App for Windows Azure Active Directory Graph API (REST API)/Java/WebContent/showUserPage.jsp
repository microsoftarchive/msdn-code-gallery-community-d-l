<%@ page language="java" contentType="text/html" import="java.util.HashMap" %>
<%@ page import="org.sampleapp.dto.UserPageInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<link rel="stylesheet" type="text/css" href="Site.css" />
<title>Java Sample App for GRAPH</title>

<script type="text/javascript">
function confirmAction(){
	var action = confirm("Do you really want to delete this user?");
	return action;
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
 	
 	<table id="users">
 	<tr>
 		<th>DisplayName</th>
 		<th>UserPrincipalName</th>
		<th>Delete</th>
 	</tr>
 	<% 
 		UserPageInfo userPage = (UserPageInfo) session.getAttribute("userPage");	
 	
		if(userPage == null){
			out.println("Sorry! Error Encountered.");
			return;
		}

		for(int i = 0; i < userPage.getUserNumber(); i++){
			out.println("<tr>");
			out.println("<td> <a class=\"users\" href='/JavaSampleApp/requestHandler?op=getuser&ObjectId=" +  userPage.getUserObjectId(i) +"'>" + userPage.getUserDisplayName(i) +"</a></td>");
			out.println("<td>" + userPage.getUserPrincipalName(i) + "</td>");
			out.println("<td> <a class=\"users\" href='/JavaSampleApp/requestHandler?op=deleteUser&ObjectId=" + userPage.getUserObjectId(i)+"' onClick=\"return confirmAction()\"><i><font color=\"#AA2121\">delete</font></i>" + "</a></td>");
			out.println("</tr>");
		}
		
 	%>
	
 	</table>
 	

 	
</div>


<div class="footerRight">
 <a class="footer" href="http://community.office365.com/en-us/default.aspx">Community</a> &nbsp;|
 <a class="footer" href="http://support.microsoft.com/common/survey.aspx">FeedBack</a>
</div>

<div class="footermiddle">
	<ul class="footermiddle">
		<li class="footermiddle">	
			<% 
				if(userPage.isHasPrevPage()){
					int prevPageNumber = userPage.getPageNumber() - 1;
					String urlNextPage = "'/JavaSampleApp/requestHandler?op=allusers&pageNumber=" + prevPageNumber;
					urlNextPage += "'";
			%>
			
			 <a class="footermiddle" href=<%=urlNextPage %>><b>&lt;prev</b></a></li>
			<%}else{
			%>	 
			<li class="footermiddle"><b>&lt;prev</b></li> <%} %>
		
		<li class="footermiddle">	
			<% 
				if(userPage.isHasNextPage()){
					int nextPageNumber = userPage.getPageNumber() + 1;
					String urlNextPage = "'/JavaSampleApp/requestHandler?op=allusers&pageNumber=" + nextPageNumber;
					urlNextPage += "'";
			%>
			
			 <a class="footermiddle" href=<%=urlNextPage %>><b>next&gt;</b></a></li>
			<%}else{
			%>	 
			<li class="footermiddle"><b>next&gt;</b></li> <%} %>
	</ul>
</div>

</body>
</html>