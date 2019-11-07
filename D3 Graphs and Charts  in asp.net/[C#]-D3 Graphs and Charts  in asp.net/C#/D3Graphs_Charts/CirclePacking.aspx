<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CirclePacking.aspx.cs" Inherits="D3Graphs_Charts.CirclePacking" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
<style>

circle {
  fill: rgb(31, 119, 180);
  fill-opacity: .25;
  stroke: rgb(31, 119, 180);
  stroke-width: 1px;
}

.leaf circle {
  fill: #ff7f0e;
  fill-opacity: 1;
}

text {
  font: 10px sans-serif;
}

</style>
   
  

</head>
<body>
 <script src="Scripts/d3.v3.min.js" type="text/javascript"></script>
    <script src="Scripts/CirclePacking.js" type="text/javascript"></script>
    <form id="form1" runat="server">
  
    </form>
</body>
</html>
