<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GridVB.aspx.vb" Inherits="GridVB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
<style type="text/css">


img {border: none;}
.container {
	height: 360px;
	width: 910px;
	margin: -180px 0 0 -450px;
	top: 50%; left: 50%;
	position: absolute;
}
ul.thumb {
	float: left;
	list-style: none;
	margin: 0; padding: 10px;
	border-color:Green;
}
ul.thumb li {
	margin: 0; padding: 5px;
	float: left;
	position: relative;
	width: 110px;
	height: 110px;
	
}
ul.thumb li img {
	width: 100px; height: 100px;
	border: 1px solid #ddd;
	padding: 5px;
	background: #f0f0f0;
	position: absolute;
	left: 0; top: 0;
	-ms-interpolation-mode: bicubic; 
}
ul.thumb li img.hover {
	background:url(thumb_bg.png) no-repeat center center;
	border: none;
}
#main_view {
	float: left;
	padding: 9px 0;
	margin-left: -10px;
}

</style>
 <script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
<script src="Scripts/Scrolling.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
     <div class="page">
        <div class="header">
            <div class="title">
                <h1>
                 Infinite Scrolling - Like Bing & Google
                </h1>
            </div>
           
            
        </div>
        <div class="main">
            <asp:ListView ID="ImageGrid" runat="server" 
        EnableModelValidation="True">
   <LayoutTemplate>
            <ul ID="itemPlaceholderContainer" runat="server" class="thumb">
               <asp:PlaceHolder runat="server" id="itemPlaceholder" />
            </ul>
        </LayoutTemplate>
      
        <ItemTemplate>
            <li  >
             <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("image")%>'/>
            </li>
        </ItemTemplate>
        
        

    </asp:ListView>
         <div style="margin-left:auto;margin-right:auto; width:120px;"  id="divPostsLoader"></div>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="footer">
        
    </div>
    </form>
</body>
</html>
