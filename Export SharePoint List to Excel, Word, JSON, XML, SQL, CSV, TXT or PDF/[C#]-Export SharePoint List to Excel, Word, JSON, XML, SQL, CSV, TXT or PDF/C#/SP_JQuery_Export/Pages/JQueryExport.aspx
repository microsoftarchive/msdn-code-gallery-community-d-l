<%-- The following 4 lines are ASP.NET directives needed when using SharePoint components --%>

<%@ Page Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" MasterPageFile="~masterurl/default.master" Language="C#" %>

<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%-- The markup and script in the following Content element will be placed in the <head> of the page --%>
<asp:Content ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script type="text/javascript" src="../Scripts/jquery-1.9.1.min.js"></script>
    <SharePoint:ScriptLink Name="sp.js" runat="server" OnDemand="true" LoadAfterUI="true" Localizable="false" />
    <meta name="WebPartPageExpansion" content="full" />

    <!-- Add your CSS styles to the following file -->
    <link rel="Stylesheet" type="text/css" href="../Content/App.css" />
    <link href="../Content/ionicons.min.css" type="text/css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" type="text/css" rel="stylesheet" />
    <link href="../Content/jquery.dataTables.css" type="text/css" rel="stylesheet" />
    <!-- Add your JavaScript to the following file -->
    <!--our custom js file-->
    <script type="text/javascript" src="../Scripts/App.js"></script>

    <script type="text/javascript" src="../Scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap.min.js"></script>
    <!--For export PDF file-->
    <script type="text/javascript" src="../Scripts/jspdf/libs/base64.js"></script>
    <script type="text/javascript" src="../Scripts/jspdf/libs/sprintf.js"></script>
    <script type="text/javascript" src="../Scripts/jspdf/jspdf.js"></script>
    <!--For export PNG file-->
    <script type="text/javascript" src="../Scripts/html2canvas.js"></script>
    <!--For export all other formats-->
    <script type="text/javascript" src="../Scripts/tableExport.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.base64.js"></script>
    <!--For HTML Table format-->
    <script type="text/javascript" src="../Scripts/jquery.dataTables.js"></script>
</asp:Content>

<%-- The markup in the following Content element will be placed in the TitleArea of the page --%>
<asp:Content ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    Export SharePoint using JQuery
</asp:Content>

<%-- The markup and script in the following Content element will be placed in the <body> of the page --%>
<asp:Content ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <div class="dropdown">
        <button class="btn btn-warning btn-sm dropdown-toggle" data-toggle="dropdown"><i class="fa fa-bars"></i>Export Table Data</button>
        <ul class="dropdown-menu " role="menu">
            <li><a href="#" onclick="$('#SPTable').tableExport({type:'json',escape:'false'});">
                <img src="../Images/json.png" width='24px' />
                JSON</a></li>
            <li><a href="#" onclick="$('#SPTable').tableExport({type:'json',escape:'false',ignoreColumn:'[0]'});">
                <img src='../Images/json.png' width='24px' />
                JSON (ignoreColumn)</a></li>
            <li><a href="#" onclick="$('#SPTable').tableExport({type:'json',escape:'true'});">
                <img src='../Images/json.png' width='24px' />
                JSON (with Escape)</a></li>
            <li class="divider"></li>
            <li><a href="#" onclick="$('#SPTable').tableExport({type:'xml',escape:'false'});">
                <img src='../Images/xml.png' width='24px' />
                XML</a></li>
            <li><a href="#" onclick="$('#SPTable').tableExport({type:'sql'});">
                <img src='../Images/sql.png' width='24px' />
                SQL</a></li>
            <li class="divider"></li>
            <li><a href="#" onclick="$('#SPTable').tableExport({type:'csv',escape:'false'});">
                <img src='../Images/csv.png' width='24px' />
                CSV</a></li>
            <li><a href="#" onclick="$('#SPTable').tableExport({type:'txt',escape:'false'});">
                <img src='../Images/txt.png' width='24px' />
                TXT</a></li>
            <li class="divider"></li>

            <li><a href="#" onclick="$('#SPTable').tableExport({type:'excel',escape:'false'});">
                <img src='../Images/xls.png' width='24px' />
                XLS</a></li>
            <li><a href="#" onclick="$('#SPTable').tableExport({type:'doc',escape:'false'});">
                <img src='../Images/word.png' width='24px' />
                Word</a></li>
            <li class="divider"></li>
            <li><a href="#" onclick="$('#SPTable').tableExport({type:'png',escape:'false'});">
                <img src='../Images/png.png' width='24px' />
                PNG</a></li>
            <li><a href="#" onclick="$('#SPTable').tableExport({type:'pdf',pdfFontSize:'7',escape:'false'});">
                <img src='../Images/pdf.png' width='24px' />
                PDF</a></li>


        </ul>
    </div>
            
    <div id="DivSPGrid">
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.dropdown-toggle').dropdown();
        });
    </script>
</asp:Content>
