<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZoomablePackLayout.aspx.cs" Inherits="D3Graphs_Charts.ZoomablePackLayout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/style.css" rel="stylesheet" type="text/css" />
     <style type="text/css">

text {
  font-size: 11px;
  pointer-events: none;
}

text.parent {
  fill: #1f77b4;
}

circle {
  fill: #ccc;
  stroke: #999;
  pointer-events: all;
}

circle.parent {
  fill: #1f77b4;
  fill-opacity: .1;
  stroke: steelblue;
}

circle.parent:hover {
  stroke: #ff7f0e;
  stroke-width: .5px;
}

circle.child {
  pointer-events: none;
}

    </style>
</head>
<body>
    <script src="Scripts/d3.js" type="text/javascript"></script>
    <script src="Scripts/d3.layout.js" type="text/javascript"></script>
    <script src="Scripts/ZPackLayout.js" type="text/javascript"></script>
    <form id="form1" runat="server">
   
    </form>
</body>
</html>
